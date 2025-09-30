Imports System.IO

Public Class AvailableStock

    Private productListPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\ProductList.csv"

    Private Sub AvailableStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCSVToDGV(productListPath)
    End Sub

    Public Sub LoadCSVToDGV(filePath As String)
        If Not File.Exists(filePath) Then
            MessageBox.Show("CSV file not found: " & filePath)
            Return
        End If

        dgvAvailableStock.Rows.Clear()

        ' Read all lines
        Dim lines() As String = File.ReadAllLines(filePath)

        ' Skip the header row
        For i As Integer = 1 To lines.Length - 1
            Dim values() As String = lines(i).Split(","c)
            If values.Length >= 4 Then
                Dim product As String = values(0)
                Dim mrp As String = values(1)
                Dim pcsPerOuter As Integer = CInt(values(2))
                Dim outer As Integer = CInt(values(3))
                Dim totalPcs As Integer = pcsPerOuter * outer

                dgvAvailableStock.Rows.Add(product, mrp, pcsPerOuter, outer, totalPcs)
            End If
        Next

        ' Appearance
        dgvAvailableStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAvailableStock.ReadOnly = True
        dgvAvailableStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub btnAddStock_Click(sender As Object, e As EventArgs) Handles btnAddStock.Click
        Dim stockForm As New StockInForm()
        stockForm.Show()
    End Sub

    Private Sub btnRemoveStock_Click(sender As Object, e As EventArgs) Handles btnRemoveStock.Click
        Dim stockOutForm As New StockOutForm()
        stockOutForm.Show()
    End Sub
End Class
