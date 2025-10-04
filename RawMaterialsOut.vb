Imports System.IO

Partial Class RawMaterialsOutForm
    Inherits Form

    Private stockFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterials.csv"
    Private configFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterialsConfiguration.csv"
    Private historyFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterialsOut.csv"

    Private Sub RawMaterialsOutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Clear input fields
        txtRawMaterial.Text = ""
        lblUnit.Text = ""
        numQuantity.Text = ""


        txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy")
        txtTime.Text = DateTime.Now.ToString("HH:mm:ss")

        ' Ensure stock CSV exists
        If Not File.Exists(stockFilePath) Then
            File.WriteAllText(stockFilePath, "RawMaterial,Unit,Quantity" & Environment.NewLine)
        End If

        ' Ensure config CSV exists (create sample if missing)
        If Not File.Exists(configFilePath) Then
            File.WriteAllText(configFilePath,
                              "RawMaterial,Unit" & Environment.NewLine &
                              "Sticks,Kg" & Environment.NewLine &
                              "Tie,Packets" & Environment.NewLine &
                              "Polybag,Kg" & Environment.NewLine &
                              "Outer,Pcs" & Environment.NewLine &
                              "Sticker,Pcs" & Environment.NewLine &
                              "Master Outer,Pcs" & Environment.NewLine &
                              "Jelly,Kg" & Environment.NewLine &
                              "Cubes,Kg" & Environment.NewLine)
        End If

        ' Ensure history CSV exists
        If Not File.Exists(historyFilePath) Then
            File.WriteAllText(historyFilePath, "Date,Time,RawMaterial,Unit,Quantity" & Environment.NewLine)
        End If

        LoadRawMaterials()
        ConfigureHoverDropdown()
    End Sub

    Private Sub LoadRawMaterials()
        txtRawMaterial.Items.Clear()
        If File.Exists(configFilePath) Then
            For Each line In File.ReadAllLines(configFilePath).Skip(1)
                Dim cols = line.Split(","c)
                If cols.Length >= 2 AndAlso Not txtRawMaterial.Items.Contains(cols(0).Trim()) Then
                    txtRawMaterial.Items.Add(cols(0).Trim())
                End If
            Next
        End If
    End Sub

    Private Function GetUnitForRawMaterial(rawMaterial As String) As String
        If File.Exists(configFilePath) Then
            For Each line In File.ReadAllLines(configFilePath).Skip(1)
                Dim cols = line.Split(","c)
                If cols.Length >= 2 AndAlso cols(0).Trim().Equals(rawMaterial, StringComparison.OrdinalIgnoreCase) Then
                    Return cols(1).Trim()
                End If
            Next
        End If
        Return ""
    End Function

    Private Sub ConfigureHoverDropdown()
        AddHandler txtRawMaterial.MouseEnter, Sub()
                                                  If txtRawMaterial.Items.Count > 0 Then txtRawMaterial.DroppedDown = True
                                              End Sub
        AddHandler txtRawMaterial.MouseLeave, Sub()
                                                  txtRawMaterial.DroppedDown = False
                                              End Sub
        AddHandler txtRawMaterial.SelectedIndexChanged, Sub()
                                                            lblUnit.Text = GetUnitForRawMaterial(txtRawMaterial.Text)
                                                        End Sub
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim rawMaterial As String = txtRawMaterial.Text.Trim()
        Dim unit As String = lblUnit.Text.Trim()
        Dim quantityOut As Decimal

        ' Mandatory field check
        Dim missing As New List(Of String)
        If String.IsNullOrEmpty(rawMaterial) Then missing.Add("Raw Material")
        If String.IsNullOrEmpty(unit) Then missing.Add("Unit")
        If Not Decimal.TryParse(numQuantity.Text.Trim(), quantityOut) OrElse quantityOut <= 0 Then missing.Add("Quantity")

        If missing.Count > 0 Then
            MessageBox.Show("Please fill the mandatory fields: " & String.Join(", ", missing), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Update stock CSV
        Dim lines As List(Of String) = File.ReadAllLines(stockFilePath).ToList()
        Dim updated As Boolean = False

        For i As Integer = 1 To lines.Count - 1
            Dim cols() = lines(i).Split(","c)
            If cols.Length >= 3 AndAlso cols(0).Trim().Equals(rawMaterial, StringComparison.OrdinalIgnoreCase) Then
                Dim existingQty As Decimal
                Decimal.TryParse(cols(2), existingQty)
                If quantityOut > existingQty Then
                    MessageBox.Show("Not enough stock available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                lines(i) = $"{cols(0)},{cols(1)},{existingQty - quantityOut}"
                updated = True
                Exit For
            End If
        Next

        If Not updated Then
            MessageBox.Show("Raw Material not found in stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        File.WriteAllLines(stockFilePath, lines)

        ' Append to history CSV in order: Date,Time,RawMaterial,Unit,Quantity
        File.AppendAllText(historyFilePath,
                           $"{txtDate.Text},{txtTime.Text},{rawMaterial},{unit},{quantityOut}" & Environment.NewLine)

        ' Refresh main form
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
