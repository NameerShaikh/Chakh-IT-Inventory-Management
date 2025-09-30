Imports System.IO

Public Class AvailableRawMaterials

    Private Sub AvailableRawMaterials_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCSVToDGV("C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterials.csv")
    End Sub

    Public Sub LoadCSVToDGV(filePath As String)
        If Not File.Exists(filePath) Then
            MessageBox.Show("CSV file not found: " & filePath)
            Return
        End If

        dgvRawMaterials.Rows.Clear()

        Dim lines() As String = File.ReadAllLines(filePath)

        ' Skip header
        For i As Integer = 1 To lines.Length - 1
            Dim values() As String = lines(i).Split(","c)
            dgvRawMaterials.Rows.Add(values)
        Next

        dgvRawMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvRawMaterials.ReadOnly = True
        dgvRawMaterials.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RawMaterialsInForm.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RawMaterialsOutForm.Show()
    End Sub
End Class
