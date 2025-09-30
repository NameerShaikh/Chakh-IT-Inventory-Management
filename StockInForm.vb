Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class StockInForm
    Inherits Form

    Private csvFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockIn.csv"
    Private excelFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockIn.xlsx"
    Private productListPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\ProductList.csv"

    Public Sub New()
        InitializeComponent()

        ' Fill products
        If File.Exists(productListPath) Then
            Dim lines = File.ReadAllLines(productListPath)
            For Each line In lines.Skip(1)
                Dim cols = line.Split(","c)
                If cols.Length > 0 Then txtProduct.Items.Add(cols(0))
            Next
        End If

        ' Payment modes
        txtPaymentMode.Items.AddRange(New String() {"Cash", "Online", "Credit"})

        ' Units
        txtUnit.Items.Clear()
        txtUnit.Items.Add("Outer")
        txtUnit.SelectedIndex = 0

        ' Auto-fill date/time
        txtEntryDate.Text = DateTime.Now.ToString("dd-MM-yyyy")
        txtEntryTime.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim product As String = txtProduct.Text.Trim()
        Dim stockUnit As String = txtUnit.Text.Trim()
        Dim quantity As Integer
        Dim batchNo As String = txtBatchNo.Text.Trim()
        Dim purchasePrice As String = txtPurchasePrice.Text.Trim()
        Dim paymentMode As String = txtPaymentMode.Text.Trim()

        If String.IsNullOrEmpty(product) OrElse Not Integer.TryParse(numQuantity.Text, quantity) Then
            MessageBox.Show("Please fill Product and Quantity correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Load product list
        Dim lines = File.ReadAllLines(productListPath).ToList()
        For i = 1 To lines.Count - 1
            Dim cols = lines(i).Split(","c)
            If cols(0) = product Then
                Dim pcsPerOuter As Integer = CInt(cols(2))
                Dim currentOuter As Integer = CInt(cols(3))

                ' Update outer quantity
                currentOuter += quantity
                cols(3) = currentOuter.ToString()

                ' Update line
                lines(i) = String.Join(",", cols)

                ' Calculate total pcs
                Dim totalPcs As Integer = pcsPerOuter * currentOuter

                ' Append to StockIn CSV
                Dim lineCsv As String = $"{txtEntryDate.Text},{txtEntryTime.Text},{product},{stockUnit},{quantity},{pcsPerOuter},{totalPcs},{batchNo},{purchasePrice},{paymentMode}"
                File.AppendAllText(csvFilePath, lineCsv & Environment.NewLine)

                ' Append to StockIn Excel
                Dim app As New Excel.Application
                Dim wb = app.Workbooks.Open(excelFilePath)
                Dim ws = wb.Sheets(1)
                Dim lastRow As Integer = ws.Cells(ws.Rows.Count, 1).End(Excel.XlDirection.xlUp).Row + 1
                ws.Cells(lastRow, 1).Value = txtEntryDate.Text
                ws.Cells(lastRow, 2).Value = txtEntryTime.Text
                ws.Cells(lastRow, 3).Value = product
                ws.Cells(lastRow, 4).Value = stockUnit
                ws.Cells(lastRow, 5).Value = quantity
                ws.Cells(lastRow, 6).Value = pcsPerOuter
                ws.Cells(lastRow, 7).Value = totalPcs
                ws.Cells(lastRow, 8).Value = batchNo
                ws.Cells(lastRow, 9).Value = purchasePrice
                ws.Cells(lastRow, 10).Value = paymentMode
                wb.Save()
                wb.Close()
                app.Quit()

                Exit For
            End If
        Next

        ' Save updated product list
        File.WriteAllLines(productListPath, lines)

        ' Confirmation
        MessageBox.Show("Stock added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Close form
        Me.Close()

        ' Refresh main form stock display by performing the Stock button click
        If Application.OpenForms.OfType(Of FrmMain)().Any() Then
            Dim mainForm As FrmMain = Application.OpenForms.OfType(Of FrmMain)().First()
            mainForm.Invoke(Sub()
                                mainForm.Button2.PerformClick() ' Button2 = Stock button
                            End Sub)
        End If
    End Sub

    Private Sub StockInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
