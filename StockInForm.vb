Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class StockInForm
    Inherits Form

    Private csvFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockIn.csv"
    Private excelFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockIn.xlsx"

    ' ✅ Constructor
    Public Sub New()
        InitializeComponent()

        ' Fill products from ProductList.csv
        Dim productListPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\ProductList.csv"
        If File.Exists(productListPath) Then
            Dim lines = File.ReadAllLines(productListPath)
            For Each line In lines.Skip(1) ' Skip header
                Dim cols = line.Split(","c)
                If cols.Length > 0 Then txtProduct.Items.Add(cols(0))
            Next
        End If

        ' Fill payment mode
        txtPaymentMode.Items.AddRange(New String() {"Cash", "Online", "Credit"})

        ' Fill units
        txtUnit.Items.Clear()
        txtUnit.Items.AddRange(New String() {"Outer", "Master Outer"})
        txtUnit.SelectedIndex = 0   ' Default to "Pcs"


        ' Auto-fill date and time
        txtEntryDate.Text = DateTime.Now.ToString("dd-MM-yyyy")
        txtEntryTime.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim entryDate As String = txtEntryDate.Text
        Dim entryTime As String = txtEntryTime.Text
        Dim product As String = txtProduct.Text.Trim()
        Dim quantity As Integer
        Dim stockUnit As String = txtUnit.Text.Trim()
        Dim batchNo As String = txtBatchNo.Text.Trim()
        Dim purchasePrice As String = txtPurchasePrice.Text.Trim()
        Dim paymentMode As String = txtPaymentMode.Text.Trim()

        ' Validation
        If String.IsNullOrEmpty(product) OrElse String.IsNullOrEmpty(stockUnit) OrElse Not Integer.TryParse(numQuantity.Text, quantity) Then
            MessageBox.Show("Please fill Product, Quantity, and Unit correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Read product list to get Outer & MasterOuter
        Dim lines = File.ReadAllLines("C:\CHAKH IT Management Software\WindowsApp1\AppFolder\ProductList.csv").ToList()
        Dim header = lines(0)
        Dim piecesPerOuter As Integer = 1
        Dim outerPerMaster As Integer = 1
        Dim productFound As Boolean = False

        For i = 1 To lines.Count - 1
            Dim cols = lines(i).Split(","c)
            If cols(0) = product Then
                piecesPerOuter = CInt(cols(2))
                outerPerMaster = CInt(cols(3))

                ' Update Outer/MasterOuter if needed
                Select Case stockUnit
                    Case "Outer"
                        piecesPerOuter += quantity
                    Case "Master Outer"
                        outerPerMaster += quantity
                End Select

                cols(2) = piecesPerOuter.ToString()
                cols(3) = outerPerMaster.ToString()
                lines(i) = String.Join(",", cols)
                productFound = True
                Exit For
            End If
        Next

        ' Save updated ProductList
        File.WriteAllLines("C:\CHAKH IT Management Software\WindowsApp1\AppFolder\ProductList.csv", lines)

        ' Compute total pieces
        Dim totalPieces As Integer
        Select Case stockUnit
            Case "Outer"
                totalPieces = quantity * piecesPerOuter
            Case "Master Outer"
                totalPieces = quantity * outerPerMaster * piecesPerOuter
        End Select

        ' Append to StockIn CSV
        Dim lineCsv As String = $"{entryDate},{entryTime},{product},{stockUnit},{quantity},{totalPieces},{batchNo},{purchasePrice},{paymentMode}"
        File.AppendAllText(csvFilePath, lineCsv & Environment.NewLine)

        ' Append to StockIn Excel
        Dim app As New Excel.Application
        Dim wb = app.Workbooks.Open(excelFilePath)
        Dim ws = wb.Sheets(1)
        Dim lastRow As Integer = ws.Cells(ws.Rows.Count, 1).End(Excel.XlDirection.xlUp).Row + 1
        ws.Cells(lastRow, 1).Value = entryDate
        ws.Cells(lastRow, 2).Value = entryTime
        ws.Cells(lastRow, 3).Value = product
        ws.Cells(lastRow, 4).Value = stockUnit
        ws.Cells(lastRow, 5).Value = quantity
        ws.Cells(lastRow, 6).Value = totalPieces
        ws.Cells(lastRow, 7).Value = batchNo
        ws.Cells(lastRow, 8).Value = purchasePrice
        ws.Cells(lastRow, 9).Value = paymentMode
        ws.Cells(lastRow, 10).Value = piecesPerOuter
        ws.Cells(lastRow, 11).Value = outerPerMaster
        wb.Save()
        wb.Close()
        app.Quit()

        ' Confirmation
        MessageBox.Show("Stock added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Close form
        Me.Close()

        ' Refresh main form stock DGV
        If Application.OpenForms.OfType(Of FrmMain)().Any() Then
            Dim mainForm As FrmMain = Application.OpenForms.OfType(Of FrmMain)().First()
            mainForm.Invoke(Sub()
                                mainForm.Button2.PerformClick() ' Stock button
                            End Sub)
        End If
    End Sub



    Private Sub StockInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
