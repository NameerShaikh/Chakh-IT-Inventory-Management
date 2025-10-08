Imports System.IO

Partial Class RawMaterialsInForm

    Private stockInFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterialsIn.csv"
    Private availableStockPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterials.csv"
    Private configPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterialsConfig.csv"

    ' Dictionary to map raw material -> unit
    Private rawMaterialUnitMap As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

    Private Sub RawMaterialsInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Clear fields
        txtRawMaterial.Text = ""
        lblUnit.Text = ""
        numQuantity.Text = ""
        txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy")
        txtTime.Text = DateTime.Now.ToString("HH:mm:ss")

        ' Ensure CSVs exist
        If Not File.Exists(stockInFilePath) Then
            File.WriteAllText(stockInFilePath, "Date,Time,RawMaterial,Unit,Quantity" & Environment.NewLine)
        End If

        If Not File.Exists(availableStockPath) Then
            File.WriteAllText(availableStockPath, "Raw Material,Unit,Quantity" & Environment.NewLine)
        End If

        ' Load config
        If File.Exists(configPath) Then
            rawMaterialUnitMap.Clear()
            For Each line In File.ReadAllLines(configPath).Skip(1)
                Dim cols = line.Split(","c)
                If cols.Length >= 2 AndAlso Not rawMaterialUnitMap.ContainsKey(cols(0).Trim()) Then
                    rawMaterialUnitMap.Add(cols(0).Trim(), cols(1).Trim())
                End If
            Next
        End If

        ' Fill dropdown
        txtRawMaterial.Items.Clear()
        For Each rm In rawMaterialUnitMap.Keys
            txtRawMaterial.Items.Add(rm)
        Next

        ' Show dropdown on hover
        AddHandler txtRawMaterial.MouseEnter, Sub() txtRawMaterial.DroppedDown = True
        AddHandler txtRawMaterial.MouseLeave, Sub() txtRawMaterial.DroppedDown = False

        ' Map unit when raw material is selected
        AddHandler txtRawMaterial.SelectedIndexChanged, Sub()
                                                            Dim selectedRM As String = txtRawMaterial.Text.Trim()
                                                            If rawMaterialUnitMap.ContainsKey(selectedRM) Then
                                                                lblUnit.Text = rawMaterialUnitMap(selectedRM)
                                                            Else
                                                                lblUnit.Text = ""
                                                            End If
                                                            numQuantity.Focus()
                                                        End Sub
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim rawMaterial As String = txtRawMaterial.Text.Trim()
        Dim unit As String = lblUnit.Text.Trim()
        Dim quantity As Decimal

        ' Validate mandatory fields
        Dim missingFields As New List(Of String)
        If String.IsNullOrEmpty(rawMaterial) Then missingFields.Add("Raw Material")
        If String.IsNullOrEmpty(unit) Then missingFields.Add("Unit")
        If Not Decimal.TryParse(numQuantity.Text.Trim(), quantity) OrElse quantity <= 0 Then missingFields.Add("Quantity")

        If missingFields.Count > 0 Then
            MessageBox.Show("Please fill the mandatory fields: " & String.Join(", ", missingFields), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' ---------- 1️⃣ Append to RawMaterialsIn.csv (History) ----------
        Dim newLine As String = $"{txtDate.Text},{txtTime.Text},{rawMaterial},{unit},{quantity}"
        File.AppendAllLines(stockInFilePath, {newLine})

        ' ---------- 2️⃣ Update RawMaterials.csv (Available Stock) ----------
        Dim stockLines As List(Of String) = File.ReadAllLines(availableStockPath).ToList()
        Dim updated As Boolean = False

        For i As Integer = 1 To stockLines.Count - 1
            Dim cols = stockLines(i).Split(","c)
            If cols.Length >= 3 AndAlso cols(0).Trim().Equals(rawMaterial, StringComparison.OrdinalIgnoreCase) Then
                Dim currentQty As Decimal = 0
                Decimal.TryParse(cols(2).Trim(), currentQty)
                currentQty += quantity
                stockLines(i) = $"{cols(0).Trim()},{cols(1).Trim()},{currentQty}"
                updated = True
                Exit For
            End If
        Next

        If Not updated Then
            stockLines.Add($"{rawMaterial},{unit},{quantity}")
        End If

        File.WriteAllLines(availableStockPath, stockLines)

        ' ---------- 3️⃣ Refresh main form ----------
        If Application.OpenForms.OfType(Of FrmMain)().Any() Then
            Dim mainForm As FrmMain = Application.OpenForms.OfType(Of FrmMain)().First()
            mainForm.Invoke(Sub() mainForm.Button4.PerformClick())
        End If

        MessageBox.Show("Raw materials added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

End Class
