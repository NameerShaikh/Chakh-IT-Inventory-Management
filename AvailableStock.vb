Imports System.IO

Public Class AvailableStock

    Private Sub AvailableStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCSVToDGV("C:\CHAKH IT Management Software\WindowsApp1\AppFolder\ProductList.csv")
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
            dgvAvailableStock.Rows.Add(values)
        Next

        ' Appearance
        dgvAvailableStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAvailableStock.ReadOnly = True
        dgvAvailableStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Create a new instance of StockInForm
        Dim stockForm As New StockInForm()
        stockForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        StockOutForm.Show()
    End Sub
End Class
