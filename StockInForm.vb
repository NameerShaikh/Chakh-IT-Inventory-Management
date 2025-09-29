Imports ClosedXML.Excel
Imports System.Drawing.Imaging
Imports System.IO

Public Class StockInForm



    Private mainForm As frmMain
    Dim stockFile As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockIn.xlsx"
    Dim productFile As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\Products.txt"

    Public Sub New()
    End Sub

    Public Sub New(frm As FrmMain)
        InitializeComponent()
        mainForm = frm
        LoadProductDropdown()
        SetCurrentDateTime()
    End Sub

    ' Load products into combobox (readonly; settings tab handles adding/removing)
    Private Sub LoadProductDropdown()
            cmbProductIn.Items.Clear()
            If File.Exists(productFile) Then
                Dim products = File.ReadAllLines(productFile).Where(Function(x) x.Trim() <> "").ToArray()
                cmbProductIn.Items.AddRange(products)
            End If
        End Sub

        ' Set current date and time
        Private Sub SetCurrentDateTime()
            txtEntryDate.Text = DateTime.Now.ToString("dd-MM-yyyy")
            txtEntryTime.Text = DateTime.Now.ToString("HH:mm:ss")
            txtEntryDate.ReadOnly = True
            txtEntryTime.ReadOnly = True
        End Sub

        ' Save stock record to Excel
        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            ' Validate
            If cmbProductIn.Text = "" Or txtQuantity.Text = "" Or txtBatchNo.Text = "" Or txtPurchasePrice.Text = "" Then
                MessageBox.Show("Please fill all required fields.")
                Return
            End If

            Dim quantity As Decimal
            Dim price As Decimal

            If Not Decimal.TryParse(txtQuantity.Text, quantity) Then
                MessageBox.Show("Quantity must be a number.")
                Return
            End If

            If Not Decimal.TryParse(txtPurchasePrice.Text, price) Then
                MessageBox.Show("Purchase Price must be a number.")
                Return
            End If


        ' Create Excel file if it doesn't exist
        If Not File.Exists(stockFile) Then
            Using wb As New XLWorkbook()
                Dim ws = wb.Worksheets.Add("StockIn")
                ' Headers
                ws.Cell(1, 1).Value = "Entry Date"
                ws.Cell(1, 2).Value = "Entry Time"
                ws.Cell(1, 3).Value = "Product"
                ws.Cell(1, 4).Value = "Quantity"
                ws.Cell(1, 5).Value = "Batch No."
                ws.Cell(1, 6).Value = "Purchase Price"
                wb.SaveAs(stockFile)
            End Using
        End If

        ' Open workbook and append new record
        Using wb As New XLWorkbook(stockFile)
            Dim ws As IXLWorksheet = wb.Worksheet("StockIn")
            Dim lastRow As Integer

            ' Check if worksheet has data
            If ws.LastRowUsed() IsNot Nothing Then
                lastRow = ws.LastRowUsed().RowNumber() + 1
            Else
                lastRow = 2 ' First row is headers
            End If

            ' Add new row
            ws.Cell(lastRow, 1).Value = txtEntryDate.Text
            ws.Cell(lastRow, 2).Value = txtEntryTime.Text
            ws.Cell(lastRow, 3).Value = cmbProductIn.Text
            ws.Cell(lastRow, 4).Value = Convert.ToDecimal(txtQuantity.Text)
            ws.Cell(lastRow, 5).Value = txtBatchNo.Text
            ws.Cell(lastRow, 6).Value = Convert.ToDecimal(txtPurchasePrice.Text)

            wb.Save()
        End Using

        MessageBox.Show("Stock record saved successfully!")

        ' Reload last 10 records in main form
        'mainForm.StockInLoadLastTenRecords()

        Me.Close()
        End Sub

    Private Sub StockInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class



