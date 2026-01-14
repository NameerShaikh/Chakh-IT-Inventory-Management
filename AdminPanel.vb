Imports System.IO

Public Class AdminPanel

    ' Root folder
    Private ReadOnly ROOT_FOLDER As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder"
    Private ReadOnly ProductFile As String = Path.Combine(ROOT_FOLDER, "ProductConfiguration.csv")
    Private ReadOnly CustomerFile As String = Path.Combine(ROOT_FOLDER, "CustomerConfig.csv")
    Private ReadOnly RawMaterialFile As String = Path.Combine(ROOT_FOLDER, "RawMaterialsConfig.csv")
    Private ReadOnly PasswordFile As String = Path.Combine(ROOT_FOLDER, "Password.csv")
    Private ReadOnly logFile As String = Path.Combine(ROOT_FOLDER, "AdminChangesLog.csv")
    Private ReadOnly availableStockPath As String = Path.Combine(ROOT_FOLDER, "AvailableStock.csv")

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

    ' ==========================
    ' UI Theme
    ' ==========================
    Private Sub ApplyUniqueTheme()
        PanelButtons.BackColor = Color.FromArgb(0, 102, 102)
        For Each ctrl As Control In PanelButtons.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)
                btn.BackColor = Color.FromArgb(0, 128, 128)
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                AddHandler btn.MouseEnter, Sub(s, e) btn.BackColor = Color.FromArgb(0, 180, 180)
                AddHandler btn.MouseLeave, Sub(s, e) btn.BackColor = Color.FromArgb(0, 128, 128)
            End If
        Next
        PanelFormContainer.BackColor = Color.FromArgb(245, 250, 250)
        PanelFormContainer.BorderStyle = BorderStyle.FixedSingle
    End Sub

    ' ==========================
    ' Helper: Clear panel
    ' ==========================
    Private Sub ClearPanel()
        PanelFormContainer.Controls.Clear()
    End Sub

    ' ==========================
    ' Helper: Return X offset
    ' ==========================
    Private Function GetFieldLeft() As Integer
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
                                      For Each txt In textboxes
                                          txt.Clear()
                                      Next
                                  End Sub
        PanelFormContainer.Controls.Add(btnSave)
    End Sub

    Private Sub SaveProduct(name As String, mrp As String, pcs As String, outers As String)
        Dim newLine As String = $"{name},{mrp},{pcs},{outers}"
        File.AppendAllText(ProductFile, newLine & Environment.NewLine)

        If Not File.Exists(availableStockPath) Then
            File.WriteAllText(availableStockPath, "Product,MRP,PcsPerOuter,Outer,MasterOuters,TotalPcs" & Environment.NewLine)
        End If

        File.AppendAllText(availableStockPath, $"{name},{mrp},{pcs},0,0,0" & Environment.NewLine)

        LogChange("Add Product", $"{newLine} | Stock Initialized")
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
                                      Dim productToRemove As String = cmb.SelectedItem.ToString()
                                      RemoveLineFromCSV(ProductFile, productToRemove, 0, "Remove Product")

                                      ' Remove from AvailableStock.csv
                                      If File.Exists(availableStockPath) Then
                                          Dim lines As List(Of String) = File.ReadAllLines(availableStockPath).ToList()
                                          lines = lines.Where(Function(l) Not l.Split(","c)(0).Trim().Equals(productToRemove, StringComparison.OrdinalIgnoreCase)).ToList()
                                          File.WriteAllLines(availableStockPath, lines)
                                      End If

                                      MessageBox.Show($"Product '{productToRemove}' removed from software successfully!")
                                      ClearPanel()
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
                                      Dim productName As String = cmbProduct.SelectedItem.ToString()
                                      Dim newMRP As String = txtMRP.Text.Trim()
                                      If newMRP = "" Then
                                          MessageBox.Show("Please enter a new MRP.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                          Return
                                      End If

                                      ChangeCSVValue(ProductFile, productName, 0, 1, newMRP, "Change Product MRP")

                                      If File.Exists(availableStockPath) Then
                                          Dim lines As List(Of String) = File.ReadAllLines(availableStockPath).ToList()
                                          For i As Integer = 1 To lines.Count - 1
                                              Dim parts = lines(i).Split(","c)
                                              If parts.Length > 1 AndAlso parts(0).Trim().Equals(productName, StringComparison.OrdinalIgnoreCase) Then
                                                  parts(1) = newMRP
                                                  lines(i) = String.Join(",", parts)
                                                  Exit For
                                              End If
                                          Next
                                          File.WriteAllLines(availableStockPath, lines)
                                      End If

                                      cmbProduct.SelectedIndex = 0
                                      txtMRP.Clear()
                                      MessageBox.Show($"MRP of '{productName}' updated successfully!")
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
                                      Dim productName As String = cmbProduct.SelectedItem.ToString()
                                      Dim newPcsStr As String = txtPcs.Text.Trim()
                                      Dim newPcs As Integer = 0
                                      If Not Integer.TryParse(newPcsStr, newPcs) OrElse newPcs <= 0 Then
                                          MessageBox.Show("Please enter a valid number for Pcs per Outer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                          Return
                                      End If

                                      ChangeCSVValue(ProductFile, productName, 0, 2, newPcsStr, "Change Pcs per Outer")

                                      If File.Exists(availableStockPath) Then
                                          Dim lines As List(Of String) = File.ReadAllLines(availableStockPath).ToList()
                                          For i As Integer = 1 To lines.Count - 1
                                              Dim parts = lines(i).Split(","c)
                                              If parts.Length > 2 AndAlso parts(0).Trim().Equals(productName, StringComparison.OrdinalIgnoreCase) Then
                                                  parts(2) = newPcsStr
                                                  Dim currentOuter As Integer = 0
                                                  Integer.TryParse(parts(3).Trim(), currentOuter)
                                                  parts(5) = (currentOuter * newPcs).ToString()
                                                  lines(i) = String.Join(",", parts)
                                                  Exit For
                                              End If
                                          Next
                                          File.WriteAllLines(availableStockPath, lines)
                                      End If

                                      cmbProduct.SelectedIndex = 0
                                      txtPcs.Clear()
                                      MessageBox.Show($"Pcs per Outer for '{productName}' updated successfully!")
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
                                      cmbProduct.SelectedIndex = 0
                                      txtOuters.Clear()
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
                                      txt.Clear()
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
                                      Dim rawName = txtName.Text.Trim()
                                      Dim rawUnit = txtUnit.Text.Trim()

                                      If rawName = "" Or rawUnit = "" Then
                                          MessageBox.Show("Please enter both Raw Material name and Unit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                          Return
                                      End If

                                      ' --- Append to RawMaterialsConfig.csv ---
                                      File.AppendAllText(RawMaterialFile, $"{rawName},{rawUnit}" & Environment.NewLine)

                                      ' --- Ensure RawMaterials.csv exists with headers ---
                                      If Not File.Exists(Path.Combine(ROOT_FOLDER, "RawMaterials.csv")) Then
                                          File.WriteAllText(Path.Combine(ROOT_FOLDER, "RawMaterials.csv"),
                                                            "Raw Material,Unit,Quantity" & Environment.NewLine)
                                      End If

                                      ' --- Append to RawMaterials.csv with initial quantity 0 ---
                                      File.AppendAllText(Path.Combine(ROOT_FOLDER, "RawMaterials.csv"),
                                                         $"{rawName},{rawUnit},0" & Environment.NewLine)

                                      LogChange("Add Raw Material", $"{rawName},{rawUnit}")
                                      MessageBox.Show("Raw Material added successfully!")

                                      ' --- Clear fields ---
                                      txtName.Clear()
                                      txtUnit.Clear()
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
                                      Dim rmName = cmbRaw.SelectedItem.ToString()

                                      ' Remove from RawMaterialsConfig.csv
                                      If File.Exists(RawMaterialFile) Then
                                          Dim lines = File.ReadAllLines(RawMaterialFile).ToList()
                                          lines = lines.Where(Function(l) Not l.Split(","c)(0).Trim().Equals(rmName, StringComparison.OrdinalIgnoreCase)).ToList()
                                          File.WriteAllLines(RawMaterialFile, lines)
                                      End If

                                      ' Remove from RawMaterials.csv
                                      Dim rmCsvPath = Path.Combine(ROOT_FOLDER, "RawMaterials.csv")
                                      If File.Exists(rmCsvPath) Then
                                          Dim lines = File.ReadAllLines(rmCsvPath).ToList()
                                          lines = lines.Where(Function(l) Not l.Split(","c)(0).Trim().Equals(rmName, StringComparison.OrdinalIgnoreCase)).ToList()
                                          File.WriteAllLines(rmCsvPath, lines)
                                      End If

                                      LogChange("Remove Raw Material", rmName)
                                      MessageBox.Show($"Raw Material '{rmName}' removed successfully!")

                                      ' --- Clear panel ---
                                      ClearPanel()
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
                                      Dim oldPass = txtOld.Text.Trim()
                                      Dim newPass = txtNew.Text.Trim()

                                      ' Validate
                                      If oldPass = "" Or newPass = "" Then
                                          MessageBox.Show("Both old and new passwords are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                          Return
                                      End If

                                      Dim currentPass As String = ""
                                      If File.Exists(PasswordFile) Then
                                          currentPass = File.ReadAllText(PasswordFile).Trim()
                                      End If

                                      If oldPass <> currentPass Then
                                          MessageBox.Show("Old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                          Return
                                      End If

                                      ' Update password
                                      File.WriteAllText(PasswordFile, newPass)
                                      LogChange("Change Password", $"Password changed")
                                      MessageBox.Show("Password changed successfully!")

                                      ' --- Clear fields ---
                                      txtOld.Clear()
                                      txtNew.Clear()
                                  End Sub

        PanelFormContainer.Controls.Add(lblOld)
        PanelFormContainer.Controls.Add(txtOld)
        PanelFormContainer.Controls.Add(lblNew)
        PanelFormContainer.Controls.Add(txtNew)
        PanelFormContainer.Controls.Add(btnSave)
    End Sub


End Class
