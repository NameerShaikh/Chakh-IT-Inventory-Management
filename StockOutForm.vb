Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class StockOutForm
    Inherits Form

    Private availableStockPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\AvailableStock.csv"
    Private stockOutCsvPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockOut.csv"
    Private stockOutExcelPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockOut.xlsx"
    Private configPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\ProductConfiguration.csv"

    Public Sub New()
        InitializeComponent()

        ' Auto-fill date and time
        txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy")
        txtTime.Text = DateTime.Now.ToString("HH:mm:ss")

        ' Load products from AvailableStock or config
        If File.Exists(configPath) Then
            Dim lines = File.ReadAllLines(configPath)
            For Each line In lines.Skip(1)
                Dim cols = line.Split(","c)
                If cols.Length > 0 Then txtProduct.Items.Add(cols(0).Trim())
            Next
        End If

        ' Unit
        txtUnit.Items.Clear()
        txtUnit.Items.AddRange(New String() {"Outer", "Master Outer"})
        txtUnit.SelectedIndex = 0

        ' Payment modes
        txtPaymentMode.Items.AddRange(New String() {"Cash", "Online", "Credit"})

        ' Configure ComboBox hover behavior
        ConfigureComboBoxHover(txtProduct)
        ConfigureComboBoxHover(txtUnit)
        ConfigureComboBoxHover(txtPaymentMode)
    End Sub

    Private Sub btnRemoveStock_Click(sender As Object, e As EventArgs) Handles btnRemoveStock.Click
        Dim product As String = txtProduct.Text.Trim()
        Dim stockUnit As String = txtUnit.Text.Trim()
        Dim quantity As Integer
        Dim batchNo As String = txtBatchNo.Text.Trim()
        Dim paymentMode As String = txtPaymentMode.Text.Trim()

        ' --- Mandatory field validation ---
        Dim missing As New List(Of String)
        If String.IsNullOrEmpty(product) Then
            missing.Add("Product")
            txtProduct.BackColor = Color.MistyRose
        Else
            txtProduct.BackColor = Color.White
        End If
        If String.IsNullOrEmpty(stockUnit) Then
            missing.Add("Unit")
            txtUnit.BackColor = Color.MistyRose
        Else
            txtUnit.BackColor = Color.White
        End If
        If Not Integer.TryParse(txtQuantity.Text.Trim(), quantity) OrElse quantity <= 0 Then
            missing.Add("Quantity")
            txtQuantity.BackColor = Color.MistyRose
        Else
            txtQuantity.BackColor = Color.White
        End If
        If missing.Count > 0 Then
            MessageBox.Show("Please fill the mandatory fields: " & String.Join(", ", missing), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- Load product config ---
        Dim pcsPerOuter As Integer = 0
        Dim outersPerMaster As Integer = 0
        If File.Exists(configPath) Then
            For Each line In File.ReadAllLines(configPath).Skip(1)
                Dim cols = line.Split(","c)
                If cols.Length >= 4 AndAlso cols(0).Trim().Equals(product, StringComparison.OrdinalIgnoreCase) Then
                    Integer.TryParse(cols(2).Trim(), pcsPerOuter)
                    Integer.TryParse(cols(3).Trim(), outersPerMaster)
                    Exit For
                End If
            Next
        End If
        If pcsPerOuter <= 0 Then
            MessageBox.Show("Product configuration missing or invalid (PcsPerOuter) for: " & product, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' --- Load AvailableStock ---
        If Not File.Exists(availableStockPath) Then
            MessageBox.Show("Available stock file not found: " & availableStockPath, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim lines = File.ReadAllLines(availableStockPath).ToList()
        Dim updated As Boolean = False
        Dim productFound As Boolean = False

        ' --- Find product in AvailableStock ---
        For i As Integer = 1 To lines.Count - 1
            Dim cols = lines(i).Split(","c).ToList()
            If cols.Count < 5 Then Continue For

            If cols(0).Trim().Equals(product, StringComparison.OrdinalIgnoreCase) Then
                productFound = True
                Dim currentOuter As Integer = 0
                Integer.TryParse(cols(3).Trim(), currentOuter)

                ' Deduct quantity
                Dim deductQty As Integer = 0
                If stockUnit.Equals("Outer", StringComparison.OrdinalIgnoreCase) Then
                    deductQty = quantity
                ElseIf stockUnit.Equals("Master Outer", StringComparison.OrdinalIgnoreCase) Then
                    If outersPerMaster <= 0 Then
                        MessageBox.Show("Configuration missing OutersPerMasterOuter for " & product, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                    deductQty = quantity * outersPerMaster
                End If

                If currentOuter < deductQty Then
                    MessageBox.Show("Not enough stock available!", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                currentOuter -= deductQty
                cols(3) = currentOuter.ToString()
                cols(4) = (currentOuter * pcsPerOuter).ToString()
                lines(i) = String.Join(",", cols)
                updated = True
                Exit For
            End If
        Next

        ' --- If product not found in stock ---
        If Not productFound Then
            MessageBox.Show("Product not available in stock yet. Please add stock first.", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- Write back AvailableStock ---
        If updated Then
            File.WriteAllLines(availableStockPath, lines)


            If Not File.Exists(stockOutCsvPath) Then
                File.WriteAllText(stockOutCsvPath, "Date,Time,Product,Unit,Quantity" & Environment.NewLine)
            End If




            ' --- Append to StockOut CSV ---
            Dim lineCsv As String = $"{txtDate.Text},{txtTime.Text},{product},{stockUnit},{quantity}"

            Using fs As New FileStream(stockOutCsvPath, FileMode.Append, FileAccess.Write, FileShare.Read)
                Using sw As New StreamWriter(fs)
                    sw.WriteLine(lineCsv)
                    sw.Flush()
                End Using
            End Using


            ' Refresh dashboard AFTER write
            If Application.OpenForms.OfType(Of DashboardForm).Any() Then
                Dim dash = Application.OpenForms.OfType(Of DashboardForm).First()
                dash.Invoke(Sub()
                                dash.ReloadDashboard()
                            End Sub)
            End If


            If Application.OpenForms.OfType(Of DashboardForm).Any() Then
                Dim dash = Application.OpenForms.OfType(Of DashboardForm).First()
                dash.Invoke(Sub()
                                dash.ReloadDashboard()
                            End Sub)
            End If


            ' --- Append to StockOut Excel ---
            Try
                Dim app As New Excel.Application
                Dim wb As Excel.Workbook
                Dim ws As Excel.Worksheet

                If File.Exists(stockOutExcelPath) Then
                    wb = app.Workbooks.Open(stockOutExcelPath)
                    ws = wb.Sheets(1)
                Else
                    wb = app.Workbooks.Add()
                    ws = wb.Sheets(1)
                    Dim headers = {"Date", "Time", "Product", "Unit", "Quantity", "BatchNo", "SellingPrice", "PaymentMode"}
                    For h As Integer = 0 To headers.Length - 1
                        ws.Cells(1, h + 1).Value = headers(h)
                    Next
                    wb.SaveAs(stockOutExcelPath)
                End If

                Dim lastRow As Integer = ws.Cells(ws.Rows.Count, 1).End(Excel.XlDirection.xlUp).Row + 1
                ws.Cells(lastRow, 1).Value = txtDate.Text
                ws.Cells(lastRow, 2).Value = txtTime.Text
                ws.Cells(lastRow, 3).Value = product
                ws.Cells(lastRow, 4).Value = stockUnit
                ws.Cells(lastRow, 5).Value = quantity
                ws.Cells(lastRow, 6).Value = batchNo
                ws.Cells(lastRow, 7).Value = txtSellingPrice.Text.Trim()
                ws.Cells(lastRow, 8).Value = paymentMode
                wb.Save()
                wb.Close()
                app.Quit()
            Catch ex As Exception
                MessageBox.Show("Warning: could not write to StockOut Excel file. " & ex.Message, "Excel Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            MessageBox.Show("Stock removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh main form stock display
            If Application.OpenForms.OfType(Of FrmMain)().Any() Then
                Dim mainForm As FrmMain = Application.OpenForms.OfType(Of FrmMain)().First()
                mainForm.Invoke(Sub()
                                    mainForm.Button2.PerformClick() ' Stock button
                                End Sub)
            End If

            Me.Close()
        End If
    End Sub

    ' Configure ComboBox hover & selection
    Private Sub ConfigureComboBoxHover(cmb As ComboBox)
        cmb.DropDownStyle = ComboBoxStyle.DropDownList

        AddHandler cmb.MouseEnter, Sub()
                                       If cmb.Items.Count > 0 Then cmb.DroppedDown = True
                                   End Sub
        AddHandler cmb.MouseLeave, Sub()
                                       cmb.DroppedDown = False
                                       cmb.FindForm().Focus()
                                   End Sub
        AddHandler cmb.SelectedIndexChanged, Sub()
                                                 cmb.DroppedDown = False
                                                 cmb.FindForm().SelectNextControl(cmb, True, True, True, True)
                                             End Sub
    End Sub

    Private Sub StockOutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
