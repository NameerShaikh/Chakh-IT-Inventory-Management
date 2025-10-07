Imports System.IO



Public Class Bills




    Private ReadOnly ROOT_FOLDER As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder"
    Private ReadOnly CUSTOMER_FILE As String = Path.Combine(ROOT_FOLDER, "CustomerConfig.csv")
    Private ReadOnly PRODUCT_FILE As String = Path.Combine(ROOT_FOLDER, "ProductConfiguration.csv")
    Private ReadOnly STOCK_FILE As String = Path.Combine(ROOT_FOLDER, "AvailableStock.csv")




    ' Product info dictionary: ProductName -> (MRP, PcsPerOuter, OutersPerMasterOuter)
    Public Class ProductInfo
        Public Property Mrp As Decimal
        Public Property PcsPerOuter As Integer
        Public Property OutersPerMasterOuter As Integer
    End Class



    ' ProductName -> ProductInfo
    Private ProductDict As New Dictionary(Of String, ProductInfo)

    ' (ProductName, Unit) -> TotalPcs
    Private StockDict As New Dictionary(Of (String, String), Integer)



    Private Sub Bills_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomers()
        FillDateTime()
        LoadProductData()
        MessageBox.Show("Products loaded: " & ProductDict.Count)
        LoadStockData()
        SetupDgvBill()
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
            For Each line In File.ReadAllLines(STOCK_FILE).Skip(1) ' skip header
                If String.IsNullOrWhiteSpace(line) Then Continue For

                Dim parts = line.Split(vbTab)
                If parts.Length < 5 Then
                    ' Skip malformed lines
                    Continue For
                End If

                Dim product = parts(0).Trim()
                Dim unit = parts(3).Trim() ' Outer / MasterOuter

                Dim totalPcs As Integer = 0
                Integer.TryParse(parts(4).Trim(), totalPcs)

                StockDict((product, unit)) = totalPcs
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
        If Not String.IsNullOrEmpty(unit) AndAlso StockDict.ContainsKey((product, unit)) Then
            row.Cells("AvailableStock").Value = StockDict((product, unit))
        End If

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
    End Sub







End Class