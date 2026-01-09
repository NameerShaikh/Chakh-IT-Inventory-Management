Imports System.IO

Public Class AvailableStock

    Private stockFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\AvailableStock.csv"
    Private configFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\ProductConfiguration.csv"



    Private Sub ApplyStyles()
        ' === HEADER STYLE ===
        With dgvAvailableStock
            .EnableHeadersVisualStyles = False
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = 35 ' Taller header for ERP look
        End With

        With dgvAvailableStock.ColumnHeadersDefaultCellStyle
            .BackColor = Color.FromArgb(44, 62, 80)   ' Strong dark header
            .ForeColor = Color.White
            .Font = New Font("Segoe UI", 11, FontStyle.Bold)
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .WrapMode = DataGridViewTriState.True
        End With

        ' === ROW STYLE ===
        dgvAvailableStock.RowsDefaultCellStyle.BackColor = Color.White
        dgvAvailableStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250)
        dgvAvailableStock.RowsDefaultCellStyle.Font = New Font("Segoe UI", 10)

        ' === ROW SELECTION ===
        dgvAvailableStock.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255) ' DodgerBlue
        dgvAvailableStock.DefaultCellStyle.SelectionForeColor = Color.White

        ' === GRID LINES ===
        dgvAvailableStock.CellBorderStyle = DataGridViewCellBorderStyle.Single ' Show both row & column lines
        dgvAvailableStock.GridColor = Color.FromArgb(200, 200, 200)            ' Softer gray grid

        ' === GENERAL ===
        dgvAvailableStock.BackgroundColor = Color.FromArgb(240, 236, 229)  ' Warm beige


        dgvAvailableStock.BorderStyle = BorderStyle.FixedSingle

    End Sub













    Private Sub AvailableStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyStyles()

        LoadCSVToDGV(stockFilePath, configFilePath)
    End Sub

    Public Sub LoadCSVToDGV(stockFilePath As String, configFilePath As String)
        ' Validate files
        If Not IO.File.Exists(stockFilePath) Then
            MessageBox.Show("Stock CSV not found: " & stockFilePath)
            Return
        End If
        If Not IO.File.Exists(configFilePath) Then
            MessageBox.Show("Product configuration CSV not found: " & configFilePath)
            Return
        End If

        Try
            ' --- Load product configuration into dictionaries (case-insensitive) ---
            Dim outersPerMasterDict As New Dictionary(Of String, Integer)(StringComparer.InvariantCultureIgnoreCase)
            Dim configPcsPerOuter As New Dictionary(Of String, Integer)(StringComparer.InvariantCultureIgnoreCase)
            Dim configMrpDict As New Dictionary(Of String, Integer)(StringComparer.InvariantCultureIgnoreCase)

            Dim cfgLines() As String = IO.File.ReadAllLines(configFilePath)
            For i As Integer = 1 To cfgLines.Length - 1 ' skip header
                Dim line As String = cfgLines(i).Trim()
                If line = "" Then Continue For
                Dim parts() As String = line.Split(","c)
                ' Expecting: ProductName, Mrp, PcsPerOuter, OutersPerMasterOuter






                If parts.Length >= 4 Then
                        Dim prodName As String = parts(0).Trim()

                        Dim mrpVal As Integer = 0
                        Integer.TryParse(parts(1).Trim(), mrpVal)

                        Dim pcsPerOuterVal As Integer = 0
                        Integer.TryParse(parts(2).Trim(), pcsPerOuterVal)

                        Dim outersPerMasterVal As Integer = 0
                        Integer.TryParse(parts(3).Trim(), outersPerMasterVal)

                        If mrpVal > 0 AndAlso Not configMrpDict.ContainsKey(prodName) Then
                            configMrpDict.Add(prodName, mrpVal)
                        End If

                        If pcsPerOuterVal > 0 AndAlso Not configPcsPerOuter.ContainsKey(prodName) Then
                            configPcsPerOuter.Add(prodName, pcsPerOuterVal)
                        End If

                        If outersPerMasterVal > 0 AndAlso Not outersPerMasterDict.ContainsKey(prodName) Then
                            outersPerMasterDict.Add(prodName, outersPerMasterVal)
                        End If
                    End If

            Next

            ' --- Prepare DataGridView ---
            dgvAvailableStock.Rows.Clear()
            dgvAvailableStock.Columns.Clear()

            ' Add columns in required order:
            ' ProductName, MRP, PcsPerOuter, Outer, MasterOuters, TotalPcs
            dgvAvailableStock.Columns.Add("ProductName", "Product Name")
            dgvAvailableStock.Columns.Add("MRP", "MRP")
            dgvAvailableStock.Columns.Add("PcsPerOuter", "Pcs / Outer")
            dgvAvailableStock.Columns.Add("Outer", "Outer (pcs)")
            dgvAvailableStock.Columns.Add("MasterOuters", "Master Outers")
            dgvAvailableStock.Columns.Add("TotalPcs", "Total Pcs")

            ' --- Read stock CSV and populate rows ---
            Dim stockLines() As String = IO.File.ReadAllLines(stockFilePath)
            For i As Integer = 1 To stockLines.Length - 1 ' skip header
                Dim line As String = stockLines(i).Trim()
                If line = "" Then Continue For
                Dim cols() As String = line.Split(","c)
                ' Expected at least: Product, MRP, PcsPerOuter, OutersAvailable
                If cols.Length < 4 Then Continue For


                ' Dim configMrpDict As New Dictionary(Of String, Integer)(StringComparer.InvariantCultureIgnoreCase)

                Dim product As String = cols(0).Trim()
                Dim mrpText As Integer = 0
                If configMrpDict.ContainsKey(product) Then
                    mrpText = configMrpDict(product)
                End If


                ' PcsPerOuter: prefer stock file value; fallback to config
                Dim pcsPerOuter As Integer = 0
                If Not Integer.TryParse(cols(2).Trim(), pcsPerOuter) OrElse pcsPerOuter <= 0 Then
                    If configPcsPerOuter.ContainsKey(product) Then
                        pcsPerOuter = configPcsPerOuter(product)
                    End If
                End If

                ' Outer available
                Dim outerAvailable As Integer = 0
                Integer.TryParse(cols(3).Trim(), outerAvailable)

                ' Outers per master from config (required for master calculation)
                Dim outersPerMaster As Integer = 0
                If outersPerMasterDict.ContainsKey(product) Then
                    outersPerMaster = outersPerMasterDict(product)
                End If

                ' Calculate master outers (whole number)
                Dim masterOuters As Integer = 0
                If outersPerMaster > 0 Then
                    masterOuters = outerAvailable \ outersPerMaster   ' integer division -> floor
                End If

                ' Calculate total pieces
                Dim totalPcs As Integer = pcsPerOuter * outerAvailable

                ' Add to DGV in the order defined
                dgvAvailableStock.Rows.Add(product, mrpText, pcsPerOuter, outerAvailable, masterOuters, totalPcs)
            Next

            ' --- Appearance & sizing ---
            dgvAvailableStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvAvailableStock.ReadOnly = True
            dgvAvailableStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            ' Make Product column wider and numeric columns equal
            If dgvAvailableStock.Columns.Count >= 6 Then
                dgvAvailableStock.Columns("ProductName").FillWeight = 40
                dgvAvailableStock.Columns("MRP").FillWeight = 12
                dgvAvailableStock.Columns("PcsPerOuter").FillWeight = 12
                dgvAvailableStock.Columns("Outer").FillWeight = 12
                dgvAvailableStock.Columns("MasterOuters").FillWeight = 12
                dgvAvailableStock.Columns("TotalPcs").FillWeight = 12

                ' Align numeric columns center
                dgvAvailableStock.Columns("MRP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvAvailableStock.Columns("PcsPerOuter").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvAvailableStock.Columns("Outer").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvAvailableStock.Columns("MasterOuters").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvAvailableStock.Columns("TotalPcs").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading CSVs: " & ex.Message)
        End Try
    End Sub




    Private Sub btnAddStock_Click(sender As Object, e As EventArgs) Handles btnAddStock.Click

        Dim stockInForm As New StockInForm()
        stockInForm.ShowDialog(Me)   ' <-- Pass the main form as owner
    End Sub

    Private Sub btnRemoveStock_Click(sender As Object, e As EventArgs) Handles btnRemoveStock.Click
        Dim stockOutForm As New StockOutForm()
        stockOutForm.ShowDialog(Me)
    End Sub

    Private Sub dgvAvailableStock_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailableStock.CellContentClick

    End Sub
End Class
