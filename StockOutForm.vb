Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class StockOutForm
    Inherits Form

    Private productFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\ProductList.csv"
    Private stockOutExcelPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockOut.xlsx"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub StockOutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Auto-fill date and time
        txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy")
        txtTime.Text = DateTime.Now.ToString("HH:mm:ss")

        ' Load products
        If File.Exists(productFilePath) Then
            Dim lines = File.ReadAllLines(productFilePath)
            For Each line In lines.Skip(1)
                Dim cols = line.Split(","c)
                If cols.Length > 0 Then txtProduct.Items.Add(cols(0))
            Next
        End If

        ' Unit
        txtUnit.Items.Add("Outer")
        txtUnit.SelectedIndex = 0

        ' Payment modes
        txtPaymentMode.Items.AddRange(New String() {"Cash", "Online", "Credit"})
    End Sub

    Private Sub btnRemoveStock_Click(sender As Object, e As EventArgs) Handles btnRemoveStock.Click
        Dim entryDate As String = txtDate.Text
        Dim entryTime As String = txtTime.Text
        Dim product As String = txtProduct.Text.Trim()
        Dim quantity As Integer
        Dim unit As String = txtUnit.Text.Trim()
        Dim batchNo As String = txtBatchNo.Text.Trim()
        Dim paymentMode As String = txtPaymentMode.Text.Trim()

        If String.IsNullOrEmpty(product) OrElse Not Integer.TryParse(txtQuantity.Text.Trim(), quantity) OrElse quantity <= 0 Then
            MessageBox.Show("Please select product and enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Update ProductList.csv (only Outer and Total Pcs)
        Dim lines As List(Of String) = File.ReadAllLines(productFilePath).ToList()
        For i As Integer = 1 To lines.Count - 1
            Dim cols = lines(i).Split(","c)
            If cols(0).Trim() = product Then
                Dim pcsPerOuter As Integer = CInt(cols(2))
                Dim outerQty As Integer = CInt(cols(3))

                If outerQty < quantity Then
                    MessageBox.Show("Not enough stock available!", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                outerQty -= quantity
                cols(3) = outerQty.ToString()
                cols(4) = (outerQty * pcsPerOuter).ToString() ' Update total pcs

                lines(i) = String.Join(",", cols)
                Exit For
            End If
        Next
        File.WriteAllLines(productFilePath, lines)

        ' Save entry to StockOut.xlsx
        Dim sellingPrice As String = txtSellingPrice.Text.Trim()

        ' ... stock removal logic remains the same ...

        ' Save entry to StockOut.xlsx
        Dim app As New Excel.Application
        Dim wb As Excel.Workbook
        Dim ws As Excel.Worksheet

        If File.Exists(stockOutExcelPath) Then
            wb = app.Workbooks.Open(stockOutExcelPath)
            ws = wb.Sheets(1)
        Else
            wb = app.Workbooks.Add()
            ws = wb.Sheets(1)
            ws.Cells(1, 1).Value = "Date"
            ws.Cells(1, 2).Value = "Time"
            ws.Cells(1, 3).Value = "Product"
            ws.Cells(1, 4).Value = "Unit"
            ws.Cells(1, 5).Value = "Quantity"
            ws.Cells(1, 6).Value = "BatchNo"
            ws.Cells(1, 7).Value = "SellingPrice"
            ws.Cells(1, 8).Value = "PaymentMode"
            wb.SaveAs(stockOutExcelPath)
        End If

        Dim lastRow As Integer = ws.Cells(ws.Rows.Count, 1).End(Excel.XlDirection.xlUp).Row + 1
        ws.Cells(lastRow, 1).Value = entryDate
        ws.Cells(lastRow, 2).Value = entryTime
        ws.Cells(lastRow, 3).Value = product
        ws.Cells(lastRow, 4).Value = unit
        ws.Cells(lastRow, 5).Value = quantity
        ws.Cells(lastRow, 6).Value = batchNo
        ws.Cells(lastRow, 7).Value = sellingPrice
        ws.Cells(lastRow, 8).Value = paymentMode

        wb.Save()
        wb.Close()
        app.Quit()


        ' Confirmation
        MessageBox.Show("Stock removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Refresh main form stock display by performing the Stock button click
        If Application.OpenForms.OfType(Of FrmMain)().Any() Then
            Dim mainForm As FrmMain = Application.OpenForms.OfType(Of FrmMain)().First()
            mainForm.Invoke(Sub()
                                mainForm.Button2.PerformClick() ' Button2 = Stock button
                            End Sub)
        End If

        Me.Close()
    End Sub
End Class
