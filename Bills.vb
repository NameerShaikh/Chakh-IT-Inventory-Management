Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO


Public Class Bills




    Private ReadOnly ROOT_FOLDER As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder"
    Private ReadOnly CUSTOMER_FILE As String = Path.Combine(ROOT_FOLDER, "CustomerConfig.csv")
    Private ReadOnly PRODUCT_FILE As String = Path.Combine(ROOT_FOLDER, "ProductConfiguration.csv")
    Private ReadOnly STOCK_FILE As String = Path.Combine(ROOT_FOLDER, "AvailableStock.csv")
    Private BILLS_FILE As String = Path.Combine(ROOT_FOLDER, "Bills.csv")
    Private CREDIT_FILE As String = Path.Combine(ROOT_FOLDER, "Credit.csv")


    ' Product info dictionary: ProductName -> (MRP, PcsPerOuter, OutersPerMasterOuter)
    Public Class ProductInfo
        Public Property Mrp As Decimal
        Public Property PcsPerOuter As Integer
        Public Property OutersPerMasterOuter As Integer
    End Class



    ' ProductName -> ProductInfo
    Private ProductDict As New Dictionary(Of String, ProductInfo)

    ' (ProductName, Unit) -> TotalPcs
    Private StockDict As New Dictionary(Of String, Integer) ' Product -> Outer available

    Private Sub CenterControls()
        ' Horizontally center Label1
        Label1.Left = (Me.ClientSize.Width - Label1.Width) \ 2
        ' Place btnSaveBill below Label1, centered
        btnSaveBill.Left = (Me.ClientSize.Width - btnSaveBill.Width) \ 2
    End Sub

    Private Sub Bills_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomers()
        FillDateTime()
        LoadProductData()
        LoadStockData()
        SetupDgvBill()
        ConfigurePaymentCombos()
        CenterControls()
    End Sub



    Private Sub LoadCustomers()
        Try
            Dim customers As New List(Of String)

            ' Keep the combobox empty initially
            customers.Add("") ' Optional: empty selection

            ' Load existing customers if file exists
            If File.Exists(CUSTOMER_FILE) Then
                For Each line As String In File.ReadAllLines(CUSTOMER_FILE).Skip(1) ' Skip header
                    If Not String.IsNullOrWhiteSpace(line) Then
                        customers.Add(line.Trim())
                    End If
                Next
            End If

            ' Add the special "Add Customer..." option at the end
            customers.Add("Add Customer...")

            cmbCustomer.DataSource = customers
            cmbCustomer.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error loading customers: " & ex.Message)
        End Try
    End Sub




    Private Sub cmbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        If cmbCustomer.SelectedItem IsNot Nothing AndAlso cmbCustomer.SelectedItem.ToString() = "Add Customer..." Then
            Dim newCustomer As String = InputBox("Enter new customer name:", "Add Customer")
            If Not String.IsNullOrWhiteSpace(newCustomer) Then
                Try
                    ' If file doesn't exist, create it with a header
                    If Not File.Exists(CUSTOMER_FILE) Then
                        File.WriteAllText(CUSTOMER_FILE, "CustomerName" & Environment.NewLine)
                    End If

                    ' Append the new customer
                    File.AppendAllText(CUSTOMER_FILE, newCustomer & Environment.NewLine)

                    ' Reload ComboBox
                    LoadCustomers()

                    ' Select the newly added customer
                    cmbCustomer.SelectedItem = newCustomer
                Catch ex As Exception
                    MessageBox.Show("Error adding customer: " & ex.Message)
                End Try
            Else
                ' Reset selection if nothing entered
                cmbCustomer.SelectedIndex = 0
            End If
        End If
    End Sub




    Private Sub btnNewCustomer_Click(sender As Object, e As EventArgs) Handles btnNewCustomer.Click
        Try
            Dim newCustomer As String = InputBox("Enter new customer name:", "Add Customer")
            If Not String.IsNullOrWhiteSpace(newCustomer) Then
                ' Check if the file exists, else create with header
                If Not File.Exists(CUSTOMER_FILE) Then
                    File.WriteAllText(CUSTOMER_FILE, "CustomerName" & Environment.NewLine)
                End If

                ' Optional: prevent duplicates
                Dim existingCustomers As List(Of String) = File.ReadAllLines(CUSTOMER_FILE).Skip(1).ToList()
                If existingCustomers.Contains(newCustomer.Trim(), StringComparer.OrdinalIgnoreCase) Then
                    MessageBox.Show("Customer already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' Append new customer
                File.AppendAllText(CUSTOMER_FILE, newCustomer.Trim() & Environment.NewLine)

                ' Reload ComboBox
                LoadCustomers()

                ' Select newly added customer
                cmbCustomer.SelectedItem = newCustomer.Trim()
            End If
        Catch ex As Exception
            MessageBox.Show("Error adding customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillDateTime()
        ' Set the date in txtDate (format: dd-MM-yyyy)
        txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy")

        ' Set the time in txtTime (format: HH:mm:ss)
        txtTime.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub







    Private Sub LoadProductData()
        If File.Exists(PRODUCT_FILE) Then
            For Each line In File.ReadAllLines(PRODUCT_FILE).Skip(1) ' skip header
                If String.IsNullOrWhiteSpace(line) Then Continue For

                ' Split line safely
                Dim parts = line.Split(","c) ' Use comma if your CSV uses commas

                If parts.Length < 4 Then
                    ' Skip lines that don’t have enough columns
                    Continue For
                End If

                ' Parse values safely
                Dim productName = parts(0).Trim()
                Dim mrp As Decimal = 0
                Decimal.TryParse(parts(1).Trim(), mrp)
                Dim pcsPerOuter As Integer = 0
                Integer.TryParse(parts(2).Trim(), pcsPerOuter)
                Dim outersPerMasterOuter As Integer = 0
                Integer.TryParse(parts(3).Trim(), outersPerMasterOuter)

                Dim info As New ProductInfo With {
                .Mrp = mrp,
                .PcsPerOuter = pcsPerOuter,
                .OutersPerMasterOuter = outersPerMasterOuter
            }

                ProductDict(productName) = info
            Next
        End If
    End Sub


    Private Sub LoadStockData()
        If File.Exists(STOCK_FILE) Then
            For Each line In File.ReadAllLines(STOCK_FILE).Skip(1)
                If String.IsNullOrWhiteSpace(line) Then Continue For
                Dim parts = line.Split(","c)
                If parts.Length < 4 Then Continue For

                Dim product = parts(0).Trim()
                Dim outerAvailable As Integer = 0
                Integer.TryParse(parts(3).Trim(), outerAvailable)

                StockDict(product) = outerAvailable
            Next
        End If
    End Sub




    Private Sub SetupDgvBill()
        dgvBill.Columns.Clear()

        ' Product column - dropdown
        Dim productCol As New DataGridViewComboBoxColumn()
        productCol.Name = "Product"
        productCol.HeaderText = "Product"
        productCol.DataSource = ProductDict.Keys.ToList()
        dgvBill.Columns.Add(productCol)

        ' MRP column - readonly
        Dim mrpCol As New DataGridViewTextBoxColumn()
        mrpCol.Name = "MRP"
        mrpCol.HeaderText = "MRP"
        mrpCol.ReadOnly = True
        dgvBill.Columns.Add(mrpCol)

        ' Unit column - dropdown
        Dim unitCol As New DataGridViewComboBoxColumn()
        unitCol.Name = "Unit"
        unitCol.HeaderText = "Unit"
        unitCol.Items.AddRange("Outers", "MasterOuters")
        dgvBill.Columns.Add(unitCol)

        ' Available Stock column - readonly
        Dim stockCol As New DataGridViewTextBoxColumn()
        stockCol.Name = "AvailableStock"
        stockCol.HeaderText = "Available Stock"
        stockCol.ReadOnly = True
        dgvBill.Columns.Add(stockCol)

        ' Quantity column
        dgvBill.Columns.Add("Quantity", "Quantity")

        ' TotalPcs column - readonly
        Dim totalPcsCol As New DataGridViewTextBoxColumn()
        totalPcsCol.Name = "TotalPcs"
        totalPcsCol.HeaderText = "TotalPcs"
        totalPcsCol.ReadOnly = True
        dgvBill.Columns.Add(totalPcsCol)

        ' Amount column - readonly
        Dim amountCol As New DataGridViewTextBoxColumn()
        amountCol.Name = "Amount"
        amountCol.HeaderText = "Amount"
        amountCol.ReadOnly = True
        dgvBill.Columns.Add(amountCol)
    End Sub



    Private Sub dgvBill_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBill.CellValueChanged
        If e.RowIndex < 0 Then Return
        Dim row = dgvBill.Rows(e.RowIndex)

        Dim product = If(row.Cells("Product").Value, "").ToString()
        Dim unit = If(row.Cells("Unit").Value, "").ToString()
        Dim quantityText = If(row.Cells("Quantity").Value, "0").ToString()
        Dim quantity As Integer = 0
        Integer.TryParse(quantityText, quantity)

        ' Set MRP
        If ProductDict.ContainsKey(product) Then
            row.Cells("MRP").Value = ProductDict(product).Mrp
        End If

        ' Set Available Stock
        Dim availableStock As Integer = 0
        If Not String.IsNullOrEmpty(product) AndAlso StockDict.ContainsKey(product) Then
            Dim outerAvailable = StockDict(product)

            If unit = "Outers" Then
                availableStock = outerAvailable
            ElseIf unit = "MasterOuters" Then
                ' Calculate master outers = floor(Outer / OutersPerMasterOuter)
                Dim outersPerMaster As Integer = 1
                If ProductDict.ContainsKey(product) Then
                    outersPerMaster = ProductDict(product).OutersPerMasterOuter
                End If
                If outersPerMaster > 0 Then
                    availableStock = outerAvailable \ outersPerMaster
                End If
            End If
        End If
        row.Cells("AvailableStock").Value = availableStock

        ' Calculate TotalPcs
        Dim totalPcs As Integer = 0
        If ProductDict.ContainsKey(product) Then
            Dim info = ProductDict(product)
            If unit = "Outers" Then
                totalPcs = quantity * info.PcsPerOuter
            ElseIf unit = "MasterOuters" Then
                totalPcs = quantity * info.PcsPerOuter * info.OutersPerMasterOuter
            End If
        End If
        row.Cells("TotalPcs").Value = totalPcs

        ' Calculate Amount
        Dim mrpValue As Decimal = 0
        Decimal.TryParse(row.Cells("MRP").Value?.ToString(), mrpValue)
        row.Cells("Amount").Value = totalPcs * mrpValue

        ' Update total items
        UpdateTotalItems()
        UpdateGrandTotal()

    End Sub


    Private Sub dgvBill_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBill.CellEndEdit
        If e.RowIndex < 0 Then Return
        Dim row = dgvBill.Rows(e.RowIndex)

        ' Only handle Quantity column
        If dgvBill.Columns(e.ColumnIndex).Name <> "Quantity" Then Return

        Dim product = If(row.Cells("Product").Value, "").ToString()
        Dim unit = If(row.Cells("Unit").Value, "").ToString()
        Dim quantity As Integer = 0
        Integer.TryParse(row.Cells("Quantity").Value?.ToString(), quantity)

        ' Get available stock
        Dim availableStock As Integer = 0
        If StockDict.ContainsKey(product) Then
            Dim outerAvailable = StockDict(product)
            If unit = "Outers" Then
                availableStock = outerAvailable
            ElseIf unit = "MasterOuters" Then
                If ProductDict.ContainsKey(product) Then
                    Dim outersPerMaster = ProductDict(product).OutersPerMasterOuter
                    If outersPerMaster > 0 Then
                        availableStock = outerAvailable \ outersPerMaster
                    End If
                End If
            End If
        End If

        ' Validate quantity
        If quantity > availableStock Then
            MessageBox.Show($"Quantity for '{product}' exceeds available stock ({availableStock})!", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            row.Cells("Quantity").Value = 0
            dgvBill.CurrentCell = row.Cells("Quantity")
            row.Cells("Quantity").Selected = True
        End If

        ' Recalculate totals after change
        dgvBill_CellValueChanged(sender, New DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex))
    End Sub





    Private Sub dgvBill_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvBill.RowsAdded
        UpdateTotalItems()
        UpdateGrandTotal()
    End Sub



    Private Sub UpdateTotalItems()
        Dim totalItems As Integer = 0

        For Each row As DataGridViewRow In dgvBill.Rows
            If row.IsNewRow Then Continue For
            Dim qty As Integer = 0
            Integer.TryParse(row.Cells("Quantity").Value?.ToString(), qty)
            totalItems += qty
        Next

        txtTotalItems.Text = totalItems.ToString()
    End Sub



    Private Sub UpdateGrandTotal()
        Dim grandTotal As Decimal = 0

        For Each row As DataGridViewRow In dgvBill.Rows
            If row.IsNewRow Then Continue For
            Dim amount As Decimal = 0
            Decimal.TryParse(row.Cells("Amount").Value?.ToString(), amount)
            grandTotal += amount
        Next

        txtGrandTotal.Text = grandTotal.ToString("0.00") ' formatted with 2 decimals
    End Sub


    Private Sub ConfigurePaymentCombos()
        ' Payment Status options
        cmbPaymentStatus.Items.Clear()
        cmbPaymentStatus.Items.AddRange({"Complete Payment", "Complete Credit", "Partial Payment"})

        ' Payment Mode options
        cmbPaymentMode.Items.Clear()
        cmbPaymentMode.Items.AddRange({"Online", "Cash", "Card"})
        cmbPaymentMode.Enabled = False ' default disabled
    End Sub




    Private Sub cmbPaymentStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaymentStatus.SelectedIndexChanged
        Dim status = cmbPaymentStatus.SelectedItem?.ToString()
        Dim grandTotal As Decimal = 0
        Decimal.TryParse(txtGrandTotal.Text.Trim(), grandTotal)

        Select Case status
            Case "Complete Payment"
                cmbPaymentMode.Enabled = True
                cmbPaymentMode.Text = "" ' reset
                txtPartialNow.Enabled = False
                txtPartialNow.Text = ""
                txtOutstanding.Text = "0.00"

            Case "Partial Payment"
                cmbPaymentMode.Enabled = True
                cmbPaymentMode.Text = "" ' reset
                txtPartialNow.Enabled = True
                txtPartialNow.Text = ""
                txtOutstanding.Text = grandTotal.ToString("0.00") ' initially full amount outstanding

            Case "Complete Credit"
                cmbPaymentMode.Enabled = False
                cmbPaymentMode.Text = "CREDIT"
                txtPartialNow.Enabled = False
                txtPartialNow.Text = ""
                txtOutstanding.Text = grandTotal.ToString("0.00") ' full amount outstanding
        End Select
    End Sub




    Private Sub btnPartialEnter_Click(sender As Object, e As EventArgs) Handles btnPartialEnter.Click
        Dim partialPaid As Decimal = 0
        Decimal.TryParse(txtPartialNow.Text.Trim(), partialPaid)

        Dim grandTotal As Decimal = 0
        Decimal.TryParse(txtGrandTotal.Text.Trim(), grandTotal)

        If partialPaid > grandTotal Then
            MessageBox.Show("Partial paid amount cannot exceed Grand Total")
            Return
        End If

        Dim outstanding As Decimal = grandTotal - partialPaid
        txtOutstanding.Text = outstanding.ToString("0.00")
    End Sub








    Private Sub UpdateBillAndCreditCSV(invoiceID As String)
        Try
            ' --- Paths ---
            Dim billsFile As String = Path.Combine(ROOT_FOLDER, "Bills.csv")
            Dim creditFile As String = Path.Combine(ROOT_FOLDER, "Credit.csv")

            ' --- Prepare Products string for the bill ---
            Dim productsList As New List(Of String)
            For Each row As DataGridViewRow In dgvBill.Rows
                If row.IsNewRow Then Continue For
                Dim productName = row.Cells("Product").Value?.ToString()
                Dim qty = row.Cells("Quantity").Value?.ToString()
                Dim unit = row.Cells("Unit").Value?.ToString()
                productsList.Add($"{productName} x{qty} ({unit})")
            Next
            Dim productsStr As String = String.Join(" | ", productsList)

            ' --- Save Bills.csv ---
            Dim billsHeader As String = "InvoiceID,CustomerName,Contact,Date,Time,Products,TotalItems,GrandTotal,PaymentStatus,PaymentMode,PartialPaid,Outstanding"
            If Not File.Exists(billsFile) Then
                File.WriteAllText(billsFile, billsHeader & Environment.NewLine)
            End If

            Dim billLine As String = String.Join(",", New String() {
            invoiceID,
            cmbCustomer.Text,
            txtContact.Text,
            txtDate.Text,
            txtTime.Text,
            """" & productsStr & """",   ' wrap in quotes to avoid comma issues
            txtTotalItems.Text,
            txtGrandTotal.Text,
            cmbPaymentStatus.Text,
            cmbPaymentMode.Text,
            txtPartialNow.Text,
            txtOutstanding.Text
        })

            File.AppendAllText(billsFile, billLine & Environment.NewLine)

            ' --- Save Credit.csv if payment is not complete ---
            If cmbPaymentStatus.Text = "Complete Credit" Or cmbPaymentStatus.Text = "Partial Payment" Then
                Dim creditHeader As String = "InvoiceID,CustomerName,Contact,Date,Time,GrandTotal,PaidAmount,OutstandingAmount,PaymentStatus,PaymentMode,Products"
                If Not File.Exists(creditFile) Then
                    File.WriteAllText(creditFile, creditHeader & Environment.NewLine)
                End If

                Dim paidAmount As String = If(cmbPaymentStatus.Text = "Complete Credit", "0", txtPartialNow.Text)
                Dim creditLine As String = String.Join(",", New String() {
                invoiceID,
                cmbCustomer.Text,
                txtContact.Text,
                txtDate.Text,
                txtTime.Text,
                txtGrandTotal.Text,
                paidAmount,
                txtOutstanding.Text,
                cmbPaymentStatus.Text,
                cmbPaymentMode.Text,
                """" & productsStr & """"
            })

                File.AppendAllText(creditFile, creditLine & Environment.NewLine)
            End If

            MessageBox.Show("Bill and Credit saved successfully!")

        Catch ex As Exception
            MessageBox.Show("Error saving Bill/Credit: " & ex.Message)
        End Try
    End Sub









    Private Sub UpdateStockAfterBill()
        ' Load current stock
        Dim stockLines = File.ReadAllLines(STOCK_FILE).ToList()
        Dim headers = stockLines(0)
        Dim newStockLines As New List(Of String)
        newStockLines.Add(headers)

        For i As Integer = 1 To stockLines.Count - 1
            Dim parts = stockLines(i).Split(","c)
            If parts.Length < 4 Then Continue For

            Dim product = parts(0).Trim()
            Dim mrp = parts(1).Trim()
            Dim pcsPerOuter = parts(2).Trim()
            Dim outerAvailable As Integer = 0
            Integer.TryParse(parts(3).Trim(), outerAvailable)

            ' Find total outers sold for this product
            Dim outersSold As Integer = 0
            For Each row As DataGridViewRow In dgvBill.Rows
                If row.IsNewRow Then Continue For
                If row.Cells("Product").Value?.ToString() = product Then
                    Dim qty As Integer = 0
                    Integer.TryParse(row.Cells("Quantity").Value?.ToString(), qty)
                    Dim unit = row.Cells("Unit").Value?.ToString()

                    If unit = "Outers" Then
                        outersSold += qty
                    ElseIf unit = "MasterOuters" Then
                        ' Convert MasterOuters to outers
                        Dim outersPerMaster = 1
                        If ProductDict.ContainsKey(product) Then
                            outersPerMaster = ProductDict(product).OutersPerMasterOuter
                        End If
                        outersSold += qty * outersPerMaster
                    End If
                End If
            Next

            ' Deduct sold outers
            outerAvailable -= outersSold
            If outerAvailable < 0 Then outerAvailable = 0

            ' Recalculate MasterOuters
            Dim masterOuters As Integer = 0
            Dim outersPerMasterValue As Integer = 1
            If ProductDict.ContainsKey(product) Then outersPerMasterValue = ProductDict(product).OutersPerMasterOuter
            If outersPerMasterValue > 0 Then masterOuters = outerAvailable \ outersPerMasterValue

            ' Total Pcs
            Dim totalPcs As Integer = 0
            If ProductDict.ContainsKey(product) Then
                totalPcs = outerAvailable * ProductDict(product).PcsPerOuter
            End If

            newStockLines.Add(String.Join(",", product, mrp, pcsPerOuter, outerAvailable, masterOuters, totalPcs))
        Next

        File.WriteAllLines(STOCK_FILE, newStockLines)
    End Sub







    Private Function GenerateInvoicePDF() As String
        Try
            ' --- Generate unique Invoice ID: INV DayMonthYearHoursMinutes ---
            Dim invoiceID As String = "INV" & DateTime.Now.ToString("ddMMyyyyHHmm")

            ' --- File path: save in Invoices folder ---
            Dim invoicesFolder As String = Path.Combine(ROOT_FOLDER, "Invoices")
            If Not Directory.Exists(invoicesFolder) Then Directory.CreateDirectory(invoicesFolder)
            Dim pdfPath As String = Path.Combine(invoicesFolder, invoiceID & ".pdf")

            ' --- Create document ---
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30)
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New FileStream(pdfPath, FileMode.Create))
            doc.Open()

            ' --- Fonts ---
            Dim titleFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 16)
            Dim headerFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 12)
            Dim normalFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10)

            ' --- Title ---
            Dim title As New iTextSharp.text.Paragraph("INVOICE", titleFont)
            title.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            doc.Add(title)
            doc.Add(New iTextSharp.text.Paragraph(" "))

            ' --- Invoice Info ---
            Dim infoTable As New iTextSharp.text.pdf.PdfPTable(2)
            infoTable.WidthPercentage = 100
            infoTable.SetWidths(New Single() {1.5F, 3.5F})

            infoTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Invoice ID:", headerFont)) With {.Border = 0})
            infoTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(invoiceID, normalFont)) With {.Border = 0})

            infoTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Customer:", headerFont)) With {.Border = 0})
            infoTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(cmbCustomer.Text, normalFont)) With {.Border = 0})

            infoTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Contact No:", headerFont)) With {.Border = 0})
            infoTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(txtContact.Text, normalFont)) With {.Border = 0})

            infoTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Date:", headerFont)) With {.Border = 0})
            infoTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(txtDate.Text, normalFont)) With {.Border = 0})

            infoTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Time:", headerFont)) With {.Border = 0})
            infoTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(txtTime.Text, normalFont)) With {.Border = 0})

            doc.Add(infoTable)
            doc.Add(New iTextSharp.text.Paragraph(" "))

            ' --- Products Table ---
            Dim prodTable As New iTextSharp.text.pdf.PdfPTable(6)
            prodTable.WidthPercentage = 100
            prodTable.SetWidths(New Single() {3, 1.5F, 1.5F, 1.5F, 1.5F, 1.5F})

            ' Header
            prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Product", headerFont)) With {.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY})
            prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("MRP", headerFont)) With {.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY})
            prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Unit", headerFont)) With {.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY})
            prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Quantity", headerFont)) With {.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY})
            prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Total Pcs", headerFont)) With {.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY})
            prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Amount", headerFont)) With {.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY})

            ' Add data
            For Each row As DataGridViewRow In dgvBill.Rows
                If row.IsNewRow Then Continue For
                prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(row.Cells("Product").Value?.ToString(), normalFont)))
                prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(row.Cells("MRP").Value?.ToString(), normalFont)))
                prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(row.Cells("Unit").Value?.ToString(), normalFont)))
                prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(row.Cells("Quantity").Value?.ToString(), normalFont)))
                prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(row.Cells("TotalPcs").Value?.ToString(), normalFont)))
                prodTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(row.Cells("Amount").Value?.ToString(), normalFont)))
            Next

            doc.Add(prodTable)
            doc.Add(New iTextSharp.text.Paragraph(" "))

            ' --- Totals Table ---
            Dim totalTable As New iTextSharp.text.pdf.PdfPTable(2)
            totalTable.WidthPercentage = 40
            totalTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            totalTable.SetWidths(New Single() {2, 1})

            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Total Items:", headerFont)) With {.Border = 0})
            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(txtTotalItems.Text, normalFont)) With {.Border = 0})
            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Grand Total:", headerFont)) With {.Border = 0})
            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(txtGrandTotal.Text, normalFont)) With {.Border = 0})
            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Payment Status:", headerFont)) With {.Border = 0})
            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(cmbPaymentStatus.Text, normalFont)) With {.Border = 0})
            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Payment Mode:", headerFont)) With {.Border = 0})
            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(cmbPaymentMode.Text, normalFont)) With {.Border = 0})
            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Partial Paid:", headerFont)) With {.Border = 0})
            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(txtPartialNow.Text, normalFont)) With {.Border = 0})
            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Outstanding:", headerFont)) With {.Border = 0})
            totalTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(txtOutstanding.Text, normalFont)) With {.Border = 0})

            doc.Add(totalTable)
            doc.Close()

            ' --- Close the Bills form ---
            Me.Close()

            Return invoiceID
        Catch ex As Exception
            MessageBox.Show("Error generating PDF: " & ex.Message)
            Return ""
        End Try
    End Function











    Private Sub btnSaveBill_Click(sender As Object, e As EventArgs) Handles btnSaveBill.Click
        ' 1️⃣ Validate stock for all rows (quantity <= available)
        For Each row As DataGridViewRow In dgvBill.Rows
            If row.IsNewRow Then Continue For
            Dim product = row.Cells("Product").Value?.ToString()
            Dim unit = row.Cells("Unit").Value?.ToString()
            Dim qty As Integer = 0
            Integer.TryParse(row.Cells("Quantity").Value?.ToString(), qty)

            ' Get available stock
            Dim availableStock As Integer = 0
            If StockDict.ContainsKey(product) Then
                Dim outerAvailable = StockDict(product)
                If unit = "Outers" Then
                    availableStock = outerAvailable
                ElseIf unit = "MasterOuters" Then
                    If ProductDict.ContainsKey(product) Then
                        availableStock = outerAvailable \ ProductDict(product).OutersPerMasterOuter
                    End If
                End If
            End If

            If qty > availableStock Then
                MessageBox.Show($"Quantity for '{product}' exceeds available stock ({availableStock})!", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Next

        ' 2️⃣ Generate PDF
        Dim invoiceID = GenerateInvoicePDF()

        ' 3️⃣ Update Available Stock
        UpdateStockAfterBill()

        'Update the Bills.csv and Credit.csv
        UpdateBillAndCreditCSV(invoiceID)

        MessageBox.Show("Bill saved, invoice generated, and stock updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub






End Class