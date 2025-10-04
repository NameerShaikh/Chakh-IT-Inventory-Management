Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class StockInForm
    Inherits Form

    Private csvFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockIn.csv"
    Private excelFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockIn.xlsx"
    Private availableStockPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\AvailableStock.csv"
    Private configPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\ProductConfiguration.csv"

    Public Sub New()
        InitializeComponent()

        ' Fill products from ProductConfiguration.csv
        If File.Exists(configPath) Then
            Dim lines = File.ReadAllLines(configPath)
            For Each line In lines.Skip(1)
                Dim cols = line.Split(","c)
                If cols.Length > 0 Then txtProduct.Items.Add(cols(0).Trim())
            Next
        End If

        ' Payment modes
        txtPaymentMode.Items.AddRange(New String() {"Cash", "Online", "Credit"})

        ' Units
        txtUnit.Items.Clear()
        txtUnit.Items.AddRange(New String() {"Outer", "Master Outer"})
        txtUnit.SelectedIndex = 0

        ' Auto-fill date/time
        txtEntryDate.Text = DateTime.Now.ToString("dd-MM-yyyy")
        txtEntryTime.Text = DateTime.Now.ToString("HH:mm:ss")

        ' === ComboBox Hover Dropdown Configuration ===
        ' ComboBox hover dropdown
        AddHandler txtProduct.MouseEnter, Sub()
                                              If txtProduct.Items.Count > 0 Then
                                                  txtProduct.DroppedDown = True
                                              End If
                                          End Sub

        AddHandler txtProduct.MouseLeave, Sub()
                                              txtProduct.DroppedDown = False
                                              ' Transfer focus back to the form or another control
                                              Me.Focus() ' sets focus to the form
                                          End Sub

        AddHandler txtProduct.SelectedIndexChanged, Sub()
                                                        txtProduct.DroppedDown = False
                                                        ' Move focus to the next control
                                                        Me.SelectNextControl(txtProduct, True, True, True, True)
                                                    End Sub



        AddHandler txtUnit.MouseEnter, Sub()
                                           If txtUnit.Items.Count > 0 Then
                                               txtUnit.DroppedDown = True
                                           End If
                                       End Sub

        AddHandler txtUnit.MouseLeave, Sub()
                                           If Not txtUnit.Focused Then
                                               txtUnit.DroppedDown = False
                                           End If
                                       End Sub

        AddHandler txtUnit.SelectedIndexChanged, Sub()
                                                     txtUnit.DroppedDown = False
                                                     Me.SelectNextControl(txtUnit, True, True, True, True)
                                                 End Sub


        AddHandler txtPaymentMode.MouseEnter, Sub()
                                                  If txtPaymentMode.Items.Count > 0 Then
                                                      txtPaymentMode.DroppedDown = True
                                                  End If
                                              End Sub

        AddHandler txtPaymentMode.MouseLeave, Sub()
                                                  If Not txtPaymentMode.Focused Then
                                                      txtPaymentMode.DroppedDown = False
                                                  End If
                                              End Sub

        AddHandler txtPaymentMode.SelectedIndexChanged, Sub()
                                                            txtPaymentMode.DroppedDown = False
                                                            Me.SelectNextControl(txtPaymentMode, True, True, True, True)
                                                        End Sub



    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' --- Gather inputs ---
        Dim product As String = txtProduct.Text.Trim()
        Dim stockUnit As String = txtUnit.Text.Trim()
        Dim quantity As Integer = 0        ' <-- DECLARED here
        Dim batchNo As String = txtBatchNo.Text.Trim()
        Dim purchasePrice As String = txtPurchasePrice.Text.Trim()
        Dim paymentMode As String = txtPaymentMode.Text.Trim()

        ' --- Reset visual hints ---
        txtProduct.BackColor = Color.White
        txtUnit.BackColor = Color.White
        numQuantity.BackColor = Color.White

        ' --- Validation: mandatory fields ---
        Dim missing As New List(Of String)
        If String.IsNullOrEmpty(product) Then
            missing.Add("Product")
            txtProduct.BackColor = Color.MistyRose
        End If
        If String.IsNullOrEmpty(stockUnit) Then
            missing.Add("Unit")
            txtUnit.BackColor = Color.MistyRose
        End If
        If Not Integer.TryParse(numQuantity.Text.Trim(), quantity) OrElse quantity <= 0 Then
            missing.Add("Quantity")
            numQuantity.BackColor = Color.MistyRose
        End If

        If missing.Count > 0 Then
            MessageBox.Show("Please fill the mandatory fields: " & String.Join(", ", missing), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- Load product config (pcsPerOuter and outersPerMasterOuter) ---
        Dim pcsPerOuter As Integer = 0
        Dim outersPerMaster As Integer = 0
        If File.Exists(configPath) Then
            For Each line In File.ReadAllLines(configPath).Skip(1)
                Dim cols = line.Split(","c)
                If cols.Length >= 4 AndAlso cols(0).Trim().Equals(product, StringComparison.OrdinalIgnoreCase) Then
                    Integer.TryParse(cols(2).Trim(), pcsPerOuter)
                    Integer.TryParse(cols(3).Trim(), outersPerMaster)
                    Exit For
                End If
            Next
        End If

        If pcsPerOuter <= 0 Then
            MessageBox.Show("Product configuration missing or invalid (PcsPerOuter) for: " & product, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' --- Load AvailableStock CSV and update counts ---
        If Not File.Exists(availableStockPath) Then
            MessageBox.Show("Available stock file not found: " & availableStockPath, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim lines = File.ReadAllLines(availableStockPath).ToList()
        Dim updated As Boolean = False

        For i As Integer = 1 To lines.Count - 1
            Dim cols = lines(i).Split(","c).ToList()
            If cols.Count < 5 Then
                ' ensure row has enough columns (product, mrp, pcsPerOuter, outer, totalPcs) - if not skip
                Continue For
            End If

            If cols(0).Trim().Equals(product, StringComparison.OrdinalIgnoreCase) Then
                Dim currentOuter As Integer = 0
                Integer.TryParse(cols(3).Trim(), currentOuter) ' outer column index 3

                If stockUnit.Equals("Outer", StringComparison.OrdinalIgnoreCase) Then
                    currentOuter += quantity
                ElseIf stockUnit.Equals("Master Outer", StringComparison.OrdinalIgnoreCase) Then
                    If outersPerMaster <= 0 Then
                        MessageBox.Show("Configuration missing OutersPerMasterOuter for " & product, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                    currentOuter += (quantity * outersPerMaster)
                End If

                ' Update outer and total pcs columns
                cols(3) = currentOuter.ToString()
                Dim totalPcs As Integer = pcsPerOuter * currentOuter
                ' Ensure TotalPcs is at the expected index (you said you use index 4 for TotalPcs)
                If cols.Count >= 5 Then
                    cols(4) = totalPcs.ToString()
                Else
                    ' if file has fewer columns, extend safely
                    While cols.Count < 5
                        cols.Add("")
                    End While
                    cols(4) = totalPcs.ToString()
                End If

                lines(i) = String.Join(",", cols)
                updated = True

                ' Append to StockIn CSV
                Dim lineCsv As String = $"{txtEntryDate.Text},{txtEntryTime.Text},{product},{stockUnit},{quantity},{pcsPerOuter},{totalPcs},{batchNo},{purchasePrice},{paymentMode}"
                File.AppendAllText(csvFilePath, lineCsv & Environment.NewLine)

                ' Append to StockIn Excel (safe create if missing)
                Try
                    Dim app As New Excel.Application
                    Dim wb As Excel.Workbook
                    Dim ws As Excel.Worksheet
                    If File.Exists(excelFilePath) Then
                        wb = app.Workbooks.Open(excelFilePath)
                        ws = wb.Sheets(1)
                    Else
                        wb = app.Workbooks.Add()
                        ws = wb.Sheets(1)
                        ws.Cells(1, 1).Value = "Date"
                        ws.Cells(1, 2).Value = "Time"
                        ws.Cells(1, 3).Value = "Product"
                        ws.Cells(1, 4).Value = "Unit"
                        ws.Cells(1, 5).Value = "Quantity"
                        ws.Cells(1, 6).Value = "PcsPerOuter"
                        ws.Cells(1, 7).Value = "TotalPcs"
                        ws.Cells(1, 8).Value = "BatchNo"
                        ws.Cells(1, 9).Value = "PurchasePrice"
                        ws.Cells(1, 10).Value = "PaymentMode"
                        wb.SaveAs(excelFilePath)
                    End If

                    Dim lastRow As Integer = ws.Cells(ws.Rows.Count, 1).End(Excel.XlDirection.xlUp).Row + 1
                    ws.Cells(lastRow, 1).Value = txtEntryDate.Text
                    ws.Cells(lastRow, 2).Value = txtEntryTime.Text
                    ws.Cells(lastRow, 3).Value = product
                    ws.Cells(lastRow, 4).Value = stockUnit
                    ws.Cells(lastRow, 5).Value = quantity
                    ws.Cells(lastRow, 6).Value = pcsPerOuter
                    ws.Cells(lastRow, 7).Value = totalPcs
                    ws.Cells(lastRow, 8).Value = batchNo
                    ws.Cells(lastRow, 9).Value = purchasePrice
                    ws.Cells(lastRow, 10).Value = paymentMode
                    wb.Save()
                    wb.Close()
                    app.Quit()
                Catch ex As Exception
                    ' If Excel interop fails, do not block — just warn
                    MessageBox.Show("Warning: could not write to StockIn Excel file. " & ex.Message, "Excel Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try

                Exit For
            End If
        Next

        If updated Then
            File.WriteAllLines(availableStockPath, lines)

            MessageBox.Show("Stock added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Close form
            Me.Close()

            ' Refresh the available stock view by performing the Stock button click
            If Application.OpenForms.OfType(Of FrmMain)().Any() Then
                Dim mainForm As FrmMain = Application.OpenForms.OfType(Of FrmMain)().First()
                mainForm.Invoke(Sub()
                                    mainForm.Button2.PerformClick() ' Stock button
                                End Sub)
            End If
        Else
            MessageBox.Show("Product not found in AvailableStock file: " & product, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



    ' Call this for each ComboBox you want to configure
    Private Sub ConfigureComboBoxHover(cmb As ComboBox)
        ' Make dropdown-only
        cmb.DropDownStyle = ComboBoxStyle.DropDownList

        ' Show dropdown on mouse hover
        AddHandler cmb.MouseEnter, Sub()
                                       If cmb.Items.Count > 0 Then
                                           cmb.DroppedDown = True
                                       End If
                                   End Sub

        ' Collapse dropdown and focus form when mouse leaves
        AddHandler cmb.MouseLeave, Sub()
                                       cmb.DroppedDown = False
                                       cmb.FindForm().Focus() ' Focus back to the form
                                   End Sub

        ' Move focus to next control when selection is made
        AddHandler cmb.SelectedIndexChanged, Sub()
                                                 cmb.DroppedDown = False
                                                 cmb.FindForm().SelectNextControl(cmb, True, True, True, True)
                                             End Sub
    End Sub







    Private Sub StockInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureComboBoxHover(txtProduct)
        ConfigureComboBoxHover(txtUnit)
        ConfigureComboBoxHover(txtPaymentMode)

    End Sub

    Private Sub txtEntryTime_TextChanged(sender As Object, e As EventArgs) Handles txtEntryTime.TextChanged

    End Sub
End Class
