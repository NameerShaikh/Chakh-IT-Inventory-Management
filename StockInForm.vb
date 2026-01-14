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
        txtEntryDate.Text = DateTime.Now.ToString("dd-MM-yy")
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
        Dim quantity As Integer = 0
        Dim batchNo As String = txtBatchNo.Text.Trim()
        Dim purchasePrice As String = txtPurchasePrice.Text.Trim()
        Dim paymentMode As String = txtPaymentMode.Text.Trim()

        ' --- Reset visual hints ---
        txtProduct.BackColor = Color.White
        txtUnit.BackColor = Color.White
        numQuantity.BackColor = Color.White

        ' --- Validation ---
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

        ' --- Load product configuration ---
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

        ' --- Load AvailableStock ---
        Dim lines As New List(Of String)
        If File.Exists(availableStockPath) Then
            lines = File.ReadAllLines(availableStockPath).ToList()
        Else
            ' Create header if file doesn't exist
            lines.Add("Product,MRP,PcsPerOuter,Outer,MasterOuters,TotalPcs")

            File.WriteAllLines(availableStockPath, lines)
        End If

        Dim updated As Boolean = False
        Dim productFound As Boolean = False

        ' --- Try to find product in AvailableStock ---
        For i As Integer = 1 To lines.Count - 1
            Dim cols = lines(i).Split(","c).ToList()

            ' Ensure column safety
            While cols.Count < 6
                cols.Add("0")
            End While

            If cols(0).Trim().Equals(product, StringComparison.OrdinalIgnoreCase) Then
                productFound = True

                Dim currentOuter As Integer = 0
                Integer.TryParse(cols(3).Trim(), currentOuter)

                ' 🔹 APPLY STOCK IN FIRST
                If stockUnit.Equals("Outer", StringComparison.OrdinalIgnoreCase) Then
                    currentOuter += quantity
                ElseIf stockUnit.Equals("Master Outer", StringComparison.OrdinalIgnoreCase) Then
                    currentOuter += quantity * outersPerMaster
                End If

                If currentOuter < 0 Then currentOuter = 0

                Dim masterOuters As Integer = 0
                If outersPerMaster > 0 Then
                    masterOuters = currentOuter \ outersPerMaster
                End If

                Dim totalPcs As Integer = currentOuter * pcsPerOuter

                cols(3) = currentOuter.ToString()      ' Outer
                cols(4) = masterOuters.ToString()      ' MasterOuters
                cols(5) = totalPcs.ToString()          ' TotalPcs

                lines(i) = String.Join(",", cols)
                updated = True
                Exit For
            End If
        Next

        ' --- If product not found, add new row ---
        If Not productFound Then
            Dim newOuter As Integer = 0

            If stockUnit.Equals("Outer", StringComparison.OrdinalIgnoreCase) Then
                newOuter = quantity
            ElseIf stockUnit.Equals("Master Outer", StringComparison.OrdinalIgnoreCase) Then
                newOuter = quantity * outersPerMaster
            End If

            Dim masterOuters As Integer = 0
            If outersPerMaster > 0 Then
                masterOuters = newOuter \ outersPerMaster
            End If

            Dim newTotalPcs As Integer = newOuter * pcsPerOuter

            ' ✅ FULL 6-COLUMN ROW (MATCHES HEADER)
            Dim newLine As String =
        $"{product},0,{pcsPerOuter},{newOuter},{masterOuters},{newTotalPcs}"

            lines.Add(newLine)
            updated = True
        End If


        ' --- Write back to AvailableStock ---
        File.WriteAllLines(availableStockPath, lines)

        ' --- Append to StockIn CSV ---
        Dim stockCsv As String = $"{txtEntryDate.Text},{txtEntryTime.Text},{product},{stockUnit},{quantity},{pcsPerOuter},{pcsPerOuter * quantity},{batchNo},{purchasePrice},{paymentMode}"
        File.AppendAllText(csvFilePath, stockCsv & Environment.NewLine)

        ' --- Append to Excel ---
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
                Dim headers = {"Date", "Time", "Product", "Unit", "Quantity", "PcsPerOuter", "TotalPcs", "BatchNo", "PurchasePrice", "PaymentMode"}
                For h As Integer = 0 To headers.Length - 1
                    ws.Cells(1, h + 1).Value = headers(h)
                Next
                wb.SaveAs(excelFilePath)
            End If

            Dim lastRow As Integer = ws.Cells(ws.Rows.Count, 1).End(Excel.XlDirection.xlUp).Row + 1
            ws.Cells(lastRow, 1).Value = txtEntryDate.Text
            ws.Cells(lastRow, 2).Value = txtEntryTime.Text
            ws.Cells(lastRow, 3).Value = product
            ws.Cells(lastRow, 4).Value = stockUnit
            ws.Cells(lastRow, 5).Value = quantity
            ws.Cells(lastRow, 6).Value = pcsPerOuter
            ws.Cells(lastRow, 7).Value = pcsPerOuter * quantity
            ws.Cells(lastRow, 8).Value = batchNo
            ws.Cells(lastRow, 9).Value = purchasePrice
            ws.Cells(lastRow, 10).Value = paymentMode
            wb.Save()
            wb.Close()
            app.Quit()
        Catch ex As Exception
            MessageBox.Show("Warning: could not write to Excel. " & ex.Message, "Excel Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        MessageBox.Show("Stock added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        ' Refresh stock view in main form
        If Application.OpenForms.OfType(Of FrmMain)().Any() Then
            Dim mainForm As FrmMain = Application.OpenForms.OfType(Of FrmMain)().First()
            mainForm.Invoke(Sub() mainForm.Button2.PerformClick())
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
