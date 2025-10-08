Imports System.IO

Public Class AdminPanel

    ' Root folder
    Private ReadOnly ROOT_FOLDER As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder"
    Private ReadOnly ProductFile As String = Path.Combine(ROOT_FOLDER, "ProductConfiguration.csv")
    Private ReadOnly CustomerFile As String = Path.Combine(ROOT_FOLDER, "CustomerConfig.csv")
    Private ReadOnly RawMaterialFile As String = Path.Combine(ROOT_FOLDER, "RawMaterialsConfig.csv")
    Private ReadOnly PasswordFile As String = Path.Combine(ROOT_FOLDER, "Password.csv")
    Private ReadOnly logFile As String = Path.Combine(ROOT_FOLDER, "AdminChangesLog.csv")

    Public Sub New()
        InitializeComponent()
        ' Initialize log file if not exists
        If Not File.Exists(logFile) Then
            File.WriteAllText(logFile, "DateTime,Action,Details" & Environment.NewLine)
        End If

        ' Assign button events
        AddHandler btnAddProduct.Click, AddressOf btnAddProduct_Click
        AddHandler btnRemoveProduct.Click, AddressOf btnRemoveProduct_Click
        AddHandler btnChangeProductMRP.Click, AddressOf btnChangeProductMRP_Click
        AddHandler btnChangePcs.Click, AddressOf btnChangePcs_Click
        AddHandler btnChangeOuters.Click, AddressOf btnChangeOuters_Click
        AddHandler btnAddCustomer.Click, AddressOf btnAddCustomer_Click
        AddHandler btnRemoveCustomer.Click, AddressOf btnRemoveCustomer_Click
        AddHandler btnAddRawMaterial.Click, AddressOf btnAddRawMaterial_Click
        AddHandler btnRemoveRawMaterial.Click, AddressOf btnRemoveRawMaterial_Click
        AddHandler btnChangePassword.Click, AddressOf btnChangePassword_Click

        ApplyUniqueTheme()


    End Sub



    Private Sub ApplyUniqueTheme()
        ' -----------------------
        ' Side Panel
        ' -----------------------
        PanelButtons.BackColor = Color.FromArgb(0, 102, 102) ' Deep teal

        ' -----------------------
        ' Buttons in Side Panel
        ' -----------------------
        For Each ctrl As Control In PanelButtons.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)
                btn.BackColor = Color.FromArgb(0, 128, 128) ' Teal
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                ' Hover effect: cyan-ish
                AddHandler btn.MouseEnter, Sub(s, e) btn.BackColor = Color.FromArgb(0, 180, 180)
                AddHandler btn.MouseLeave, Sub(s, e) btn.BackColor = Color.FromArgb(0, 128, 128)
            End If
        Next

        ' -----------------------
        ' PanelFormContainer
        ' -----------------------
        PanelFormContainer.BackColor = Color.FromArgb(245, 250, 250) ' Soft off-white
        PanelFormContainer.BorderStyle = BorderStyle.FixedSingle

        ' -----------------------
        ' Controls inside PanelFormContainer
        ' -----------------------
        For Each ctrl As Control In PanelFormContainer.Controls
            If TypeOf ctrl Is TextBox Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.BackColor = Color.FromArgb(235, 245, 245) ' Light teal-ish
                txt.ForeColor = Color.FromArgb(20, 20, 20)   ' Dark text
                txt.BorderStyle = BorderStyle.FixedSingle
            ElseIf TypeOf ctrl Is Label Then
                Dim lbl As Label = CType(ctrl, Label)
                lbl.ForeColor = Color.FromArgb(0, 102, 102) ' Deep teal
            ElseIf TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)
                btn.BackColor = Color.FromArgb(0, 128, 128)
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                ' Hover effect
                AddHandler btn.MouseEnter, Sub(s, e) btn.BackColor = Color.FromArgb(0, 180, 180)
                AddHandler btn.MouseLeave, Sub(s, e) btn.BackColor = Color.FromArgb(0, 128, 128)
            End If
        Next
    End Sub




    ' ==========================
    ' Helper: Clear panel
    ' ==========================
    Private Sub ClearPanel()
        PanelFormContainer.Controls.Clear()
    End Sub

    ' ==========================
    ' Helper: Return starting X offset
    ' ==========================
    Private Function GetFieldLeft() As Integer
        ' Change this value to shift fields to the right
        Return 250
    End Function


    ' ==========================
    ' Helper: Load CSV into ComboBox
    ' ==========================
    Private Function LoadComboFromCSV(filePath As String, colIndex As Integer) As ComboBox
        Dim cmb As New ComboBox With {.Top = 20, .Left = 180, .Width = 200, .DropDownStyle = ComboBoxStyle.DropDownList}
        If File.Exists(filePath) Then
            Dim lines = File.ReadAllLines(filePath)
            For Each line In lines
                Dim parts = line.Split(","c)
                If parts.Length > colIndex Then
                    cmb.Items.Add(parts(colIndex))
                End If
            Next
        End If
        If cmb.Items.Count > 0 Then cmb.SelectedIndex = 0
        Return cmb
    End Function

    ' ==========================
    ' Logging
    ' ==========================
    Private Sub LogChange(actionName As String, details As String)
        File.AppendAllText(logFile, $"{DateTime.Now},{actionName},{details}" & Environment.NewLine)
    End Sub

    ' ==========================
    ' Remove line from CSV
    ' ==========================
    Private Sub RemoveLineFromCSV(filePath As String, searchValue As String, colIndex As Integer, actionName As String)
        If Not File.Exists(filePath) Then Exit Sub
        Dim lines As List(Of String) = File.ReadAllLines(filePath).ToList()
        Dim newLines As New List(Of String)
        For Each line In lines
            Dim parts() = line.Split(","c)
            If parts.Length > colIndex AndAlso parts(colIndex).Trim() <> searchValue Then
                newLines.Add(line)
            End If
        Next
        File.WriteAllLines(filePath, newLines)
        LogChange(actionName, searchValue)
        MessageBox.Show($"{actionName} done!")
    End Sub

    ' ==========================
    ' Change CSV Value
    ' ==========================
    Private Sub ChangeCSVValue(filePath As String, searchValue As String, searchCol As Integer, changeCol As Integer, newValue As String, actionName As String)
        If Not File.Exists(filePath) Then Exit Sub
        Dim lines As List(Of String) = File.ReadAllLines(filePath).ToList()
        For i As Integer = 0 To lines.Count - 1
            Dim parts() = lines(i).Split(","c)
            If parts.Length > Math.Max(searchCol, changeCol) AndAlso parts(searchCol).Trim() = searchValue Then
                parts(changeCol) = newValue
                lines(i) = String.Join(",", parts)
                LogChange(actionName, $"{searchValue} -> {newValue}")
                Exit For
            End If
        Next
        File.WriteAllLines(filePath, lines)
        MessageBox.Show($"{actionName} done!")
    End Sub

    ' ==========================
    ' 1. Add Product
    ' ==========================
    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs)
        ClearPanel()
        Dim xOffset As Integer = GetFieldLeft()
        Dim labels As String() = {"Product Name:", "MRP:", "Pcs per Outer:", "Outers per Master Outer:"}
        Dim yPos As Integer = 20
        Dim textboxes As New List(Of TextBox)

        For Each lblText In labels
            Dim lbl As New Label With {.Text = lblText, .Top = yPos, .Left = 20 + xOffset}
            Dim txt As New TextBox With {.Top = yPos, .Left = 180 + xOffset, .Width = 200}
            PanelFormContainer.Controls.Add(lbl)
            PanelFormContainer.Controls.Add(txt)
            textboxes.Add(txt)
            yPos += 40
        Next

        Dim btnSave As New Button With {.Text = "Save", .Top = yPos, .Left = 180 + xOffset}
        AddHandler btnSave.Click, Sub()
                                      SaveProduct(textboxes(0).Text, textboxes(1).Text, textboxes(2).Text, textboxes(3).Text)
                                  End Sub
        PanelFormContainer.Controls.Add(btnSave)
    End Sub

    Private Sub SaveProduct(name As String, mrp As String, pcs As String, outers As String)
        Dim newLine As String = $"{name},{mrp},{pcs},{outers}"
        File.AppendAllText(ProductFile, newLine & Environment.NewLine)
        LogChange("Add Product", newLine)
        MessageBox.Show("Product added successfully!")
    End Sub





    ' ==========================
    ' 2. Remove Product
    ' ==========================
    Private Sub btnRemoveProduct_Click(sender As Object, e As EventArgs)
        ClearPanel()
        Dim xOffset As Integer = GetFieldLeft()
        Dim lbl As New Label With {.Text = "Product Name:", .Top = 20, .Left = 20 + xOffset}
        Dim cmb = LoadComboFromCSV(ProductFile, 0)
        cmb.Top = 20
        cmb.Left = 180 + xOffset

        Dim btnSave As New Button With {.Text = "Remove Product", .Top = 60, .Left = 180 + xOffset}
        AddHandler btnSave.Click, Sub()
                                      RemoveLineFromCSV(ProductFile, cmb.SelectedItem.ToString(), 0, "Remove Product")
                                  End Sub

        PanelFormContainer.Controls.Add(lbl)
        PanelFormContainer.Controls.Add(cmb)
        PanelFormContainer.Controls.Add(btnSave)
    End Sub

    ' ==========================
    ' 3. Change Product MRP
    ' ==========================
    Private Sub btnChangeProductMRP_Click(sender As Object, e As EventArgs)
        ClearPanel()
        Dim xOffset As Integer = GetFieldLeft()
        Dim lblName As New Label With {.Text = "Product Name:", .Top = 20, .Left = 20 + xOffset}
        Dim cmbProduct = LoadComboFromCSV(ProductFile, 0)
        cmbProduct.Left = 180 + xOffset
        cmbProduct.Top = 20

        Dim lblMRP As New Label With {.Text = "New MRP:", .Top = 60, .Left = 20 + xOffset}
        Dim txtMRP As New TextBox With {.Top = 60, .Left = 180 + xOffset, .Width = 200}
        Dim btnSave As New Button With {.Text = "Change MRP", .Top = 100, .Left = 180 + xOffset}

        AddHandler btnSave.Click, Sub()
                                      ChangeCSVValue(ProductFile, cmbProduct.SelectedItem.ToString(), 0, 1, txtMRP.Text, "Change Product MRP")
                                  End Sub

        PanelFormContainer.Controls.Add(lblName)
        PanelFormContainer.Controls.Add(cmbProduct)
        PanelFormContainer.Controls.Add(lblMRP)
        PanelFormContainer.Controls.Add(txtMRP)
        PanelFormContainer.Controls.Add(btnSave)
    End Sub

    ' ==========================
    ' 4. Change Pcs per Outer
    ' ==========================
    Private Sub btnChangePcs_Click(sender As Object, e As EventArgs)
        ClearPanel()
        Dim xOffset As Integer = GetFieldLeft()
        Dim lblName As New Label With {.Text = "Product Name:", .Top = 20, .Left = 20 + xOffset}
        Dim cmbProduct = LoadComboFromCSV(ProductFile, 0)
        cmbProduct.Left = 180 + xOffset
        cmbProduct.Top = 20

        Dim lblPcs As New Label With {.Text = "New Pcs per Outer:", .Top = 60, .Left = 20 + xOffset}
        Dim txtPcs As New TextBox With {.Top = 60, .Left = 180 + xOffset, .Width = 200}
        Dim btnSave As New Button With {.Text = "Change Pcs", .Top = 100, .Left = 180 + xOffset}

        AddHandler btnSave.Click, Sub()
                                      ChangeCSVValue(ProductFile, cmbProduct.SelectedItem.ToString(), 0, 2, txtPcs.Text, "Change Pcs per Outer")
                                  End Sub

        PanelFormContainer.Controls.Add(lblName)
        PanelFormContainer.Controls.Add(cmbProduct)
        PanelFormContainer.Controls.Add(lblPcs)
        PanelFormContainer.Controls.Add(txtPcs)
        PanelFormContainer.Controls.Add(btnSave)
    End Sub

    ' ==========================
    ' 5. Change Outers per Master Outer
    ' ==========================
    Private Sub btnChangeOuters_Click(sender As Object, e As EventArgs)
        ClearPanel()
        Dim xOffset As Integer = GetFieldLeft()
        Dim lblName As New Label With {.Text = "Product Name:", .Top = 20, .Left = 20 + xOffset}
        Dim cmbProduct = LoadComboFromCSV(ProductFile, 0)
        cmbProduct.Left = 180 + xOffset
        cmbProduct.Top = 20

        Dim lblOuters As New Label With {.Text = "New Outers per Master:", .Top = 60, .Left = 20 + xOffset}
        Dim txtOuters As New TextBox With {.Top = 60, .Left = 180 + xOffset, .Width = 200}
        Dim btnSave As New Button With {.Text = "Change Outers", .Top = 100, .Left = 180 + xOffset}

        AddHandler btnSave.Click, Sub()
                                      ChangeCSVValue(ProductFile, cmbProduct.SelectedItem.ToString(), 0, 3, txtOuters.Text, "Change Outers per Master Outer")
                                  End Sub

        PanelFormContainer.Controls.Add(lblName)
        PanelFormContainer.Controls.Add(cmbProduct)
        PanelFormContainer.Controls.Add(lblOuters)
        PanelFormContainer.Controls.Add(txtOuters)
        PanelFormContainer.Controls.Add(btnSave)
    End Sub

    ' ==========================
    ' 6. Add Customer
    ' ==========================
    Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
        ClearPanel()
        Dim xOffset As Integer = GetFieldLeft()
        Dim lbl As New Label With {.Text = "Customer Name:", .Top = 20, .Left = 20 + xOffset}
        Dim txt As New TextBox With {.Top = 20, .Left = 180 + xOffset, .Width = 200}
        Dim btnSave As New Button With {.Text = "Add Customer", .Top = 60, .Left = 180 + xOffset}

        AddHandler btnSave.Click, Sub()
                                      File.AppendAllText(CustomerFile, txt.Text & Environment.NewLine)
                                      LogChange("Add Customer", txt.Text)
                                      MessageBox.Show("Customer added!")
                                  End Sub

        PanelFormContainer.Controls.Add(lbl)
        PanelFormContainer.Controls.Add(txt)
        PanelFormContainer.Controls.Add(btnSave)
    End Sub

    ' ==========================
    ' 7. Remove Customer
    ' ==========================
    Private Sub btnRemoveCustomer_Click(sender As Object, e As EventArgs)
        ClearPanel()
        Dim xOffset As Integer = GetFieldLeft()
        Dim lbl As New Label With {.Text = "Customer Name:", .Top = 20, .Left = 20 + xOffset}
        Dim cmbCustomer = LoadComboFromCSV(CustomerFile, 0)
        cmbCustomer.Left = 180 + xOffset
        cmbCustomer.Top = 20

        Dim btnSave As New Button With {.Text = "Remove Customer", .Top = 60, .Left = 180 + xOffset}
        AddHandler btnSave.Click, Sub()
                                      RemoveLineFromCSV(CustomerFile, cmbCustomer.SelectedItem.ToString(), 0, "Remove Customer")
                                  End Sub

        PanelFormContainer.Controls.Add(lbl)
        PanelFormContainer.Controls.Add(cmbCustomer)
        PanelFormContainer.Controls.Add(btnSave)
    End Sub

    ' ==========================
    ' 8. Add Raw Material
    ' ==========================
    Private Sub btnAddRawMaterial_Click(sender As Object, e As EventArgs)
        ClearPanel()
        Dim xOffset As Integer = GetFieldLeft()
        Dim lblName As New Label With {.Text = "Raw Material:", .Top = 20, .Left = 20 + xOffset}
        Dim txtName As New TextBox With {.Top = 20, .Left = 180 + xOffset, .Width = 200}
        Dim lblUnit As New Label With {.Text = "Unit:", .Top = 60, .Left = 20 + xOffset}
        Dim txtUnit As New TextBox With {.Top = 60, .Left = 180 + xOffset, .Width = 200}
        Dim btnSave As New Button With {.Text = "Add Raw Material", .Top = 100, .Left = 180 + xOffset}

        AddHandler btnSave.Click, Sub()
                                      Dim line As String = $"{txtName.Text},{txtUnit.Text}"
                                      File.AppendAllText(RawMaterialFile, line & Environment.NewLine)
                                      LogChange("Add Raw Material", line)
                                      MessageBox.Show("Raw Material added!")
                                  End Sub

        PanelFormContainer.Controls.Add(lblName)
        PanelFormContainer.Controls.Add(txtName)
        PanelFormContainer.Controls.Add(lblUnit)
        PanelFormContainer.Controls.Add(txtUnit)
        PanelFormContainer.Controls.Add(btnSave)
    End Sub

    ' ==========================
    ' 9. Remove Raw Material
    ' ==========================
    Private Sub btnRemoveRawMaterial_Click(sender As Object, e As EventArgs)
        ClearPanel()
        Dim xOffset As Integer = GetFieldLeft()
        Dim lbl As New Label With {.Text = "Raw Material Name:", .Top = 20, .Left = 20 + xOffset}
        Dim cmbRaw = LoadComboFromCSV(RawMaterialFile, 0)
        cmbRaw.Left = 180 + xOffset
        cmbRaw.Top = 20

        Dim btnSave As New Button With {.Text = "Remove Raw Material", .Top = 60, .Left = 180 + xOffset}
        AddHandler btnSave.Click, Sub()
                                      RemoveLineFromCSV(RawMaterialFile, cmbRaw.SelectedItem.ToString(), 0, "Remove Raw Material")
                                  End Sub

        PanelFormContainer.Controls.Add(lbl)
        PanelFormContainer.Controls.Add(cmbRaw)
        PanelFormContainer.Controls.Add(btnSave)
    End Sub

    ' ==========================
    ' 10. Change Password
    ' ==========================
    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs)
        ClearPanel()
        Dim xOffset As Integer = GetFieldLeft()
        Dim lblOld As New Label With {.Text = "Old Password:", .Top = 20, .Left = 20 + xOffset}
        Dim txtOld As New TextBox With {.Top = 20, .Left = 180 + xOffset, .Width = 200, .PasswordChar = "*"c}
        Dim lblNew As New Label With {.Text = "New Password:", .Top = 60, .Left = 20 + xOffset}
        Dim txtNew As New TextBox With {.Top = 60, .Left = 180 + xOffset, .Width = 200, .PasswordChar = "*"c}
        Dim btnSave As New Button With {.Text = "Change Password", .Top = 100, .Left = 180 + xOffset}

        AddHandler btnSave.Click, Sub()
                                      File.WriteAllText(PasswordFile, txtNew.Text)
                                      LogChange("Change Password", $"Old:{txtOld.Text}, New:{txtNew.Text}")
                                      MessageBox.Show("Password changed!")
                                  End Sub

        PanelFormContainer.Controls.Add(lblOld)
        PanelFormContainer.Controls.Add(txtOld)
        PanelFormContainer.Controls.Add(lblNew)
        PanelFormContainer.Controls.Add(txtNew)
        PanelFormContainer.Controls.Add(btnSave)
    End Sub


End Class
