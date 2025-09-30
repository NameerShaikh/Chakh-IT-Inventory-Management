Imports System.IO

Partial Class RawMaterialsOutForm

    Private csvFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterials.csv"

    Private Sub RawMaterialsOutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists(csvFilePath) Then
            File.WriteAllText(csvFilePath, "Product,Unit,Quantity" & Environment.NewLine)
        End If
        LoadProducts()
    End Sub

    Private Sub LoadProducts()
        txtProduct.Items.Clear()
        Dim lines As String() = File.ReadAllLines(csvFilePath)
        For i As Integer = 1 To lines.Length - 1
            Dim cols() As String = lines(i).Split(","c)
            If cols.Length >= 3 AndAlso Not txtProduct.Items.Contains(cols(0).Trim()) Then
                txtProduct.Items.Add(cols(0).Trim())
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim product As String = txtProduct.Text.Trim()
        Dim quantityOut As Decimal

        If String.IsNullOrEmpty(product) Then
            MessageBox.Show("Please select a product.")
            Return
        End If

        If Not Decimal.TryParse(numQuantity.Text.Trim(), quantityOut) OrElse quantityOut <= 0 Then
            MessageBox.Show("Please enter a valid quantity to remove.")
            Return
        End If

        Dim lines As List(Of String) = File.ReadAllLines(csvFilePath).ToList()
        Dim updated As Boolean = False

        For i As Integer = 1 To lines.Count - 1
            Dim cols() = lines(i).Split(","c)
            If cols.Length >= 3 AndAlso cols(0).Trim().Equals(product, StringComparison.OrdinalIgnoreCase) Then
                Dim existingQty As Decimal
                Decimal.TryParse(cols(2), existingQty)
                If quantityOut > existingQty Then
                    MessageBox.Show("Not enough stock available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                Dim newQty As Decimal = existingQty - quantityOut
                lines(i) = $"{cols(0)},{cols(1)},{newQty}"
                updated = True
                Exit For
            End If
        Next

        If Not updated Then
            MessageBox.Show("Product not found in stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        File.WriteAllLines(csvFilePath, lines)

        ' Refresh main form DataGridView
        If Application.OpenForms.OfType(Of FrmMain)().Any() Then
            Dim mainForm As FrmMain = Application.OpenForms.OfType(Of FrmMain)().First()
            mainForm.Invoke(Sub()
                                mainForm.Button4.PerformClick()
                            End Sub)
        End If

        MessageBox.Show("Stock removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()
    End Sub

End Class
