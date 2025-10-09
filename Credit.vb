Imports System.IO
Imports System.Data
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class Credit
    Inherits Form

    Private creditFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\Credit.csv"
    Private creditClearedPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\CreditCleared.csv"
    Private customerFilePath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\CustomerConfig.csv"
    Private creditTable As New DataTable()

    ' Controls
    Private WithEvents dgvCredits As New DataGridView()
    Private lblTotalOutstanding As New Label()
    Private lblTotalOutstandingValue As New Label()
    Private WithEvents cmbCustomers As New ComboBox()
    Private dtpFrom As New DateTimePicker()
    Private dtpTo As New DateTimePicker()
    Private WithEvents btnRefresh As New Button()
    Private WithEvents btnExportPDF As New Button()

    Private Sub Credit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupLayout()
        SetupDataGrid()
        LoadCustomerCombo()
        LoadCreditData()
        SetComboPlaceholder()
    End Sub

#Region "Layout & DataGrid"
    Private Sub SetupLayout()
        Me.Text = "Credit Management"
        Me.BackColor = Color.White
        Me.Dock = DockStyle.Fill

        ' ComboBox
        cmbCustomers.Width = 250
        cmbCustomers.DropDownStyle = ComboBoxStyle.DropDown
        cmbCustomers.Font = New System.Drawing.Font("Segoe UI", 10)
        AddHandler cmbCustomers.TextChanged, AddressOf ApplyFilters
        AddHandler cmbCustomers.GotFocus, AddressOf ComboGotFocus
        AddHandler cmbCustomers.LostFocus, AddressOf ComboLostFocus

        ' DatePickers
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd-MM-yyyy"
        dtpFrom.Value = DateTime.Now.AddMonths(-1)
        AddHandler dtpFrom.ValueChanged, AddressOf ApplyFilters

        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd-MM-yyyy"
        dtpTo.Value = DateTime.Now
        AddHandler dtpTo.ValueChanged, AddressOf ApplyFilters

        ' Buttons
        btnRefresh.Text = "Refresh"
        btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
        btnRefresh.Width = 100
        btnRefresh.Height = 35
        btnRefresh.BackColor = Color.LightGray

        btnExportPDF.Text = "Export to PDF"
        btnExportPDF.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
        btnExportPDF.Width = 120
        btnExportPDF.Height = 35
        btnExportPDF.BackColor = Color.FromArgb(46, 204, 113)
        btnExportPDF.ForeColor = Color.White

        ' Labels
        lblTotalOutstanding.Text = "Total Outstanding:"
        lblTotalOutstanding.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
        lblTotalOutstanding.AutoSize = True

        lblTotalOutstandingValue.Font = New System.Drawing.Font("Segoe UI", 10)
        lblTotalOutstandingValue.AutoSize = True
        lblTotalOutstandingValue.ForeColor = Color.Red

        ' Top panel
        Dim topPanel As New FlowLayoutPanel()
        topPanel.Dock = DockStyle.Top
        topPanel.Height = 60
        topPanel.Padding = New Padding(10)
        topPanel.FlowDirection = FlowDirection.LeftToRight
        topPanel.Controls.AddRange({cmbCustomers, dtpFrom, dtpTo, btnRefresh, btnExportPDF, lblTotalOutstanding, lblTotalOutstandingValue})

        Me.Controls.Add(dgvCredits)
        Me.Controls.Add(topPanel)
    End Sub

    Private Sub SetupDataGrid()
        dgvCredits.Dock = DockStyle.Fill
        dgvCredits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCredits.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
        dgvCredits.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10)
        dgvCredits.BackgroundColor = Color.WhiteSmoke
        dgvCredits.BorderStyle = BorderStyle.None
        dgvCredits.AllowUserToAddRows = False
        dgvCredits.AllowUserToDeleteRows = False
        dgvCredits.ReadOnly = False
        dgvCredits.RowTemplate.Height = 50
        dgvCredits.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvCredits.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvCredits.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        dgvCredits.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft

        ' Serial Number Column
        Dim snCol As New DataGridViewTextBoxColumn()
        snCol.Name = "SNo"
        snCol.HeaderText = "S.No"
        snCol.ReadOnly = True
        dgvCredits.Columns.Add(snCol)

        ' Mark Complete button
        Dim btnCol As New DataGridViewButtonColumn()
        btnCol.Name = "MarkComplete"
        btnCol.HeaderText = "Mark Complete"
        btnCol.Text = "✔ Complete"
        btnCol.UseColumnTextForButtonValue = True
        dgvCredits.Columns.Add(btnCol)

        AddHandler dgvCredits.CellContentClick, AddressOf dgvCredits_CellContentClick
        AddHandler dgvCredits.DataBindingComplete, AddressOf dgvCredits_DataBindingComplete
    End Sub

    Private Sub SetComboPlaceholder()
        cmbCustomers.Text = "Search by Customer Name"
        cmbCustomers.ForeColor = Color.Gray
    End Sub

    Private Sub ComboGotFocus(sender As Object, e As EventArgs)
        If cmbCustomers.Text = "Search by Customer Name" Then
            cmbCustomers.Text = ""
            cmbCustomers.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ComboLostFocus(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(cmbCustomers.Text) Then
            cmbCustomers.Text = "Search by Customer Name"
            cmbCustomers.ForeColor = Color.Gray
        End If
    End Sub
#End Region

#Region "Load Data"
    Private Sub LoadCustomerCombo()
        cmbCustomers.Items.Clear()
        cmbCustomers.Items.Add("All Customers") ' top option

        If Not File.Exists(customerFilePath) Then Return
        Dim customers = File.ReadAllLines(customerFilePath).Skip(1)
        For Each line In customers
            Dim parts = line.Split(vbTab)
            If parts.Length >= 1 Then cmbCustomers.Items.Add(parts(0))
        Next
    End Sub

    Private Sub LoadCreditData()
        creditTable = New DataTable()
        creditTable.Columns.AddRange({
            New DataColumn("InvoiceID"),
            New DataColumn("CustomerName"),
            New DataColumn("CustomerContact"),
            New DataColumn("Date"),
            New DataColumn("Time"),
            New DataColumn("GrandTotal"),
            New DataColumn("PaidAmount"),
            New DataColumn("OutstandingAmount"),
            New DataColumn("PaymentStatus"),
            New DataColumn("PaymentMode"),
            New DataColumn("ProductsString")
        })

        If Not File.Exists(creditFilePath) Then Return
        Dim lines = File.ReadAllLines(creditFilePath)
        For Each line In lines.Skip(1)
            If String.IsNullOrWhiteSpace(line) Then Continue For
            ' CSV split with quoted ProductsString
            Dim parts = SplitCSVLine(line)
            If parts.Length >= 11 Then creditTable.Rows.Add(parts)
        Next

        dgvCredits.DataSource = creditTable
        UpdateTotalOutstanding()
    End Sub

    ' Helper to handle CSV with quoted field
    Private Function SplitCSVLine(line As String) As String()
        Dim pattern As String = "(?<=^|,)(?:""(?<val>[^""]*)""|(?<val>[^,]*))"
        Dim matches = System.Text.RegularExpressions.Regex.Matches(line, pattern)
        Return matches.Cast(Of System.Text.RegularExpressions.Match).Select(Function(m) m.Groups("val").Value).ToArray()
    End Function
#End Region

#Region "Filters & Refresh"
    Private Sub ApplyFilters(sender As Object, e As EventArgs)
        If creditTable Is Nothing Then Return

        Dim fromDate As DateTime = dtpFrom.Value.Date
        Dim toDate As DateTime = dtpTo.Value.Date

        Dim filtered As DataTable = creditTable.Clone()
        For Each row As DataRow In creditTable.Rows
            Dim rowDate As DateTime
            If DateTime.TryParseExact(row("Date").ToString(), "dd-MM-yy", Nothing, Globalization.DateTimeStyles.None, rowDate) Then
                If rowDate.Date >= fromDate AndAlso rowDate.Date <= toDate Then
                    If cmbCustomers.Text <> "" AndAlso cmbCustomers.Text <> "Search by Customer Name" AndAlso cmbCustomers.Text <> "All Customers" Then
                        If row("CustomerName").ToString().Contains(cmbCustomers.Text.Trim()) Then
                            filtered.ImportRow(row)
                        End If
                    Else
                        filtered.ImportRow(row)
                    End If
                End If
            End If
        Next

        dgvCredits.DataSource = filtered
        UpdateTotalOutstanding()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        cmbCustomers.Text = "All Customers"
        dtpFrom.Value = DateTime.Now.AddMonths(-1)
        dtpTo.Value = DateTime.Now
        LoadCreditData()
    End Sub

    Private Sub UpdateTotalOutstanding()
        Dim total As Double = 0
        For Each row As DataGridViewRow In dgvCredits.Rows
            If Not IsDBNull(row.Cells("OutstandingAmount").Value) AndAlso row.Cells("OutstandingAmount").Value.ToString() <> "" Then
                total += Val(row.Cells("OutstandingAmount").Value)
            End If
        Next
        lblTotalOutstandingValue.Text = "₹" & total.ToString("N2")
    End Sub

    Private Sub dgvCredits_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        ' Add serial numbers
        For i As Integer = 0 To dgvCredits.Rows.Count - 1
            dgvCredits.Rows(i).Cells("SNo").Value = (i + 1).ToString()
        Next
    End Sub
#End Region

#Region "PDF Export"
    Private Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click
        Try
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "PDF Files|*.pdf"
            sfd.FileName = "Credit_Report.pdf"
            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Dim doc As New Document(PageSize.A4, 20, 20, 20, 20)
            PdfWriter.GetInstance(doc, New FileStream(sfd.FileName, FileMode.Create))
            doc.Open()

            Dim titleFont As iTextSharp.text.Font = FontFactory.GetFont("Segoe UI", 16, iTextSharp.text.Font.BOLD)
            Dim tableFont As iTextSharp.text.Font = FontFactory.GetFont("Segoe UI", 10, iTextSharp.text.Font.NORMAL)

            doc.Add(New Paragraph("Credit Report", titleFont))
            doc.Add(New Paragraph("Generated on: " & DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")))
            doc.Add(New Paragraph(" "))

            Dim pdfTable As New PdfPTable(dgvCredits.Columns.Count - 2) ' exclude serial & button columns
            pdfTable.WidthPercentage = 100

            ' Headers
            For Each col As DataGridViewColumn In dgvCredits.Columns
                If col.Name <> "MarkComplete" AndAlso col.Name <> "SNo" Then
                    pdfTable.AddCell(New Phrase(col.HeaderText, tableFont))
                End If
            Next

            ' Rows
            For Each row As DataGridViewRow In dgvCredits.Rows
                For Each cell As DataGridViewCell In row.Cells
                    If cell.OwningColumn.Name <> "MarkComplete" AndAlso cell.OwningColumn.Name <> "SNo" Then
                        pdfTable.AddCell(New Phrase(cell.Value?.ToString(), tableFont))
                    End If
                Next
            Next

            doc.Add(pdfTable)
            doc.Close()
            MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error exporting PDF: " & ex.Message)
        End Try
    End Sub
#End Region

#Region "Mark as Complete"
    Private Sub dgvCredits_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        If dgvCredits.Columns(e.ColumnIndex).Name = "MarkComplete" Then
            Dim row As DataGridViewRow = dgvCredits.Rows(e.RowIndex)
            Dim invoiceId = row.Cells("InvoiceID").Value.ToString()

            ' Dialog for Payment Mode & Remarks
            Dim dlg As New Form()
            dlg.Size = New Size(350, 200)
            dlg.Text = "Complete Payment"
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog
            dlg.StartPosition = FormStartPosition.CenterParent

            Dim lblPay As New Label() With {.Text = "Payment Mode:", .Location = New Point(20, 20)}
            Dim cmbPay As New ComboBox() With {.Location = New Point(120, 18), .Width = 180}
            cmbPay.Items.AddRange({"Cash", "UPI", "Card", "Other"})
            cmbPay.DropDownStyle = ComboBoxStyle.DropDownList
            cmbPay.SelectedIndex = 0

            Dim lblRemarks As New Label() With {.Text = "Remarks:", .Location = New Point(20, 60)}
            Dim txtRemarks As New TextBox() With {.Location = New Point(120, 58), .Width = 180}

            Dim btnOk As New Button() With {.Text = "OK", .Location = New Point(50, 120), .Width = 80}
            Dim btnCancel As New Button() With {.Text = "Cancel", .Location = New Point(150, 120), .Width = 80}

            dlg.Controls.AddRange({lblPay, cmbPay, lblRemarks, txtRemarks, btnOk, btnCancel})

            AddHandler btnOk.Click, Sub(s, ev)
                                        ' Save to CreditCleared.csv in CSV format (comma, quotes)
                                        If Not File.Exists(creditClearedPath) Then
                                            Dim headers = String.Join(",", creditTable.Columns.Cast(Of DataColumn).Select(Function(c) c.ColumnName)) & ",PaymentMode,Remarks"
                                            File.WriteAllText(creditClearedPath, headers & vbCrLf)
                                        End If
                                        Dim clearedLine = String.Join(",", row.Cells.Cast(Of DataGridViewCell).Take(creditTable.Columns.Count).Select(Function(c)
                                                                                                                                                          Dim val = c.Value?.ToString().Replace("""", "'")
                                                                                                                                                          If c.OwningColumn.Name = "ProductsString" Then val = $"""{val}"""
                                                                                                                                                          Return val
                                                                                                                                                      End Function))
                                        clearedLine &= $",{cmbPay.Text},{txtRemarks.Text.Replace(",", ";")}"
                                        File.AppendAllText(creditClearedPath, clearedLine & vbCrLf)

                                        ' Remove from Credit.csv
                                        Dim allLines = File.ReadAllLines(creditFilePath).ToList()
                                        allLines = allLines.Where(Function(l) Not l.StartsWith(invoiceId & ",")).ToList()
                                        File.WriteAllLines(creditFilePath, allLines)

                                        LoadCreditData()
                                        dlg.Close()
                                    End Sub
            AddHandler btnCancel.Click, Sub(s, ev) dlg.Close()
            dlg.ShowDialog()
        End If
    End Sub
#End Region

End Class
