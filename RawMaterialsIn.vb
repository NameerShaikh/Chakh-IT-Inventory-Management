Imports System.IO

Partial Class RawMaterialsInForm

    Private csvFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterials.csv"

    Private Sub RawMaterialsInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Your load logic
        ' Ensure CSV file exists
        If Not File.Exists(csvFilePath) Then
            File.WriteAllText(csvFilePath, "Product,Unit,Quantity" & Environment.NewLine)
        End If

        ' Load products into ComboBox
        LoadProducts()
    End Sub


    Private Sub LoadProducts()
        txtProduct.Items.Clear()
        Dim lines As String() = File.ReadAllLines(csvFilePath)
        For i As Integer = 1 To lines.Length - 1
            Dim cols() As String = lines(i).Split(","c)
            If cols.Length >= 3 Then
                If Not txtProduct.Items.Contains(cols(0).Trim()) Then
                    txtProduct.Items.Add(cols(0).Trim())
                End If
            End If
        Next
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim product As String = txtProduct.Text.Trim()
        Dim unit As String = txtUnit.Text.Trim()
        Dim quantity As Decimal

        ' Validate inputs
        If String.IsNullOrEmpty(product) Then
            MessageBox.Show("Please select or enter a product.")
            Return
        End If

        If String.IsNullOrEmpty(unit) Then
            MessageBox.Show("Please enter unit.")
            Return
        End If

        If Not Decimal.TryParse(numQuantity.Text.Trim(), quantity) OrElse quantity <= 0 Then
            MessageBox.Show("Please enter a valid quantity.")
            Return
        End If

        ' Load CSV
        Dim lines As List(Of String) = File.ReadAllLines(csvFilePath).ToList()
        Dim updated As Boolean = False

        ' Update quantity if product exists
        For i As Integer = 1 To lines.Count - 1
            Dim cols() As String = lines(i).Split(","c)
            If cols.Length >= 3 AndAlso cols(0).Trim().Equals(product, StringComparison.OrdinalIgnoreCase) Then
                Dim existingQty As Decimal = 0
                Decimal.TryParse(cols(2), existingQty)
                Dim newQty As Decimal = existingQty + quantity
                lines(i) = $"{cols(0)},{cols(1)},{newQty}"
                updated = True
                Exit For
            End If
        Next

        ' If product not found, add new row
        If Not updated Then
            lines.Add($"{product},{unit},{quantity}")
        End If

        ' Save CSV
        File.WriteAllLines(csvFilePath, lines)

        ' Refresh main form by invoking the Raw Materials button click
        If Application.OpenForms.OfType(Of FrmMain)().Any() Then
            Dim mainForm As FrmMain = Application.OpenForms.OfType(Of FrmMain)().First()
            mainForm.Invoke(Sub()
                                mainForm.Button4.PerformClick()
                            End Sub)
        End If

        MessageBox.Show("Raw materials added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

End Class
