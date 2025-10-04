Imports System.IO

Public Class AvailableRawMaterials

    Private Sub AvailableRawMaterials_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCSVToDGV("C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterials.csv")
        ApplyRawMaterialsStyles()
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
        RawMaterialsInForm.ShowDialog(Me)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RawMaterialsOutForm.ShowDialog(Me)
    End Sub



    Private Sub ApplyRawMaterialsStyles()

        ' === Header Style ===
        With dgvRawMaterials.ColumnHeadersDefaultCellStyle
            .BackColor = Color.FromArgb(0, 123, 167)   ' Professional blue header
            .ForeColor = Color.White
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        dgvRawMaterials.EnableHeadersVisualStyles = False

        ' === Grid & Background ===
        dgvRawMaterials.BackgroundColor = Color.FromArgb(250, 250, 252)   ' Light professional background
        dgvRawMaterials.GridColor = Color.FromArgb(200, 200, 200)         ' Subtle column separation lines

        ' === Rows ===
        dgvRawMaterials.RowsDefaultCellStyle.BackColor = Color.White
        dgvRawMaterials.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250)
        dgvRawMaterials.RowsDefaultCellStyle.Font = New Font("Segoe UI", 10)

        ' === Selection ===
        dgvRawMaterials.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230) ' Soft light blue
        dgvRawMaterials.DefaultCellStyle.SelectionForeColor = Color.Black

        ' === Border & Grid ===
        dgvRawMaterials.CellBorderStyle = DataGridViewCellBorderStyle.Single
        dgvRawMaterials.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dgvRawMaterials.RowHeadersVisible = False

        ' === Autosize Columns ===
        dgvRawMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    End Sub




End Class
