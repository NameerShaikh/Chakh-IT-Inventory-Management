Imports System.IO
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing.Drawing2D

Partial Public Class BillsTab

    Private ReadOnly BILLS_FILE As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\Bills.csv"
    Private ReadOnly INVOICE_FOLDER As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\Invoices"
    Private ReadOnly CUSTOMER_FILE As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\CustomerConfig.csv"

    Private Sub BillsTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureFormStyle()
        ConfigureDGV()
        LoadCustomers()
        LoadBills()
    End Sub

    '================== UI STYLING ==================
    Private Sub ConfigureFormStyle()
        Me.BackColor = Color.WhiteSmoke
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                Dim btn = DirectCast(ctrl, Button)
                btn.FlatStyle = FlatStyle.Flat
                btn.BackColor = Color.FromArgb(40, 167, 69)
                btn.ForeColor = Color.White
                btn.FlatAppearance.BorderSize = 0
                btn.Cursor = Cursors.Hand
            ElseIf TypeOf ctrl Is ComboBox Then
                Dim cb = DirectCast(ctrl, ComboBox)
                cb.FlatStyle = FlatStyle.Flat
                cb.DropDownStyle = ComboBoxStyle.DropDownList
                cb.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub ConfigureDGV()
        With dgvBills
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowTemplate.Height = 40
            .AllowUserToAddRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    '================== LOAD CUSTOMER FILTER ==================
    Private Sub LoadCustomers()
        If Not File.Exists(CUSTOMER_FILE) Then Return

        Dim lines = File.ReadAllLines(CUSTOMER_FILE).Skip(1)
        Dim customers As New List(Of String)
        For Each line In lines
            Dim parts = line.Split(","c)
            If parts.Length > 0 AndAlso Not String.IsNullOrWhiteSpace(parts(0)) Then
                customers.Add(parts(0).Trim())
            End If
        Next

        cmbSearchCustomer.Items.Clear()
        cmbSearchCustomer.Items.Add("All Customers")
        cmbSearchCustomer.Items.AddRange(customers.ToArray())
        cmbSearchCustomer.SelectedIndex = 0
    End Sub

    '================== LOAD BILLS ==================
    Private Sub LoadBills(Optional fromDate As DateTime? = Nothing, Optional toDate As DateTime? = Nothing)
        If Not File.Exists(BILLS_FILE) Then
            MessageBox.Show("Bills file not found.")
            Return
        End If

        Dim lines = File.ReadAllLines(BILLS_FILE).ToList()
        If lines.Count <= 1 Then Return

        Dim dt As New DataTable()
        dt.Columns.AddRange({
            New DataColumn("Invoice ID"),
            New DataColumn("Customer Name"),
            New DataColumn("Contact"),
            New DataColumn("Date"),
            New DataColumn("Time"),
            New DataColumn("Total Items"),
            New DataColumn("Grand Total"),
            New DataColumn("Payment Status"),
            New DataColumn("Outstanding"),
            New DataColumn("Download", GetType(Image))
        })

        ' Reverse for newest first
        Dim dataLines = lines.Skip(1).Reverse().Take(15)
        For Each line In dataLines
            Dim parts = SplitCsv(line)
            If parts.Length < 12 Then Continue For

            Dim billDate As Date
            If Not Date.TryParse(parts(3), billDate) Then Continue For

            ' Date filter
            If fromDate.HasValue AndAlso toDate.HasValue Then
                If billDate < fromDate.Value OrElse billDate > toDate.Value Then Continue For
            End If

            ' Customer filter
            If cmbSearchCustomer.SelectedIndex > 0 Then
                Dim selectedCustomer = cmbSearchCustomer.SelectedItem.ToString()
                If Not parts(1).Equals(selectedCustomer, StringComparison.OrdinalIgnoreCase) Then Continue For
            End If

            dt.Rows.Add(parts(0), parts(1), parts(2), parts(3), parts(4),
                        parts(6), parts(7), parts(8), parts(11),
                        GetDownloadIcon())
        Next

        dgvBills.DataSource = dt
        dgvBills.Columns("Download").Width = 60
        dgvBills.Columns("Download").HeaderText = ""
        CType(dgvBills.Columns("Download"), DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom
    End Sub

    '================== CSV HELPER ==================
    Private Function SplitCsv(line As String) As String()
        Dim pattern = ",(?=(?:[^""]*""[^""]*"")*[^""]*$)"
        Return System.Text.RegularExpressions.Regex.Split(line, pattern).Select(Function(s) s.Trim(""""c)).ToArray()
    End Function

    '================== ICON CREATOR ==================
    Private Function GetDownloadIcon() As Image
        Dim bmp As New Bitmap(24, 24)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.Clear(Color.Transparent)

            Dim pen As New Pen(Color.SeaGreen, 2)
            g.DrawLine(pen, 12, 4, 12, 16)
            g.DrawLine(pen, 8, 12, 12, 16)
            g.DrawLine(pen, 16, 12, 12, 16)
            g.DrawLine(New Pen(Color.SeaGreen, 2), 8, 18, 16, 18)
        End Using
        Return bmp
    End Function

    '================== EVENTS ==================
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        LoadBills(dtpFrom.Value.Date, dtpTo.Value.Date)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cmbSearchCustomer.SelectedIndex = 0
        LoadBills()
    End Sub

    Private Sub cmbCustomerFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchCustomer.SelectedIndexChanged
        LoadBills()
    End Sub

    Private Sub NewBill_Click(sender As Object, e As EventArgs) Handles NewBill.Click
        Bills.ShowDialog(Me)
        LoadBills() ' Refresh after new bill
    End Sub

    Private Sub dgvBills_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBills.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvBills.Columns(e.ColumnIndex).HeaderText = "" Then
            Dim invoiceID As String = dgvBills.Rows(e.RowIndex).Cells("Invoice ID").Value.ToString()
            Dim pdfPath As String = Path.Combine(INVOICE_FOLDER, invoiceID & ".pdf")

            If File.Exists(pdfPath) Then
                Process.Start(New ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
            Else
                MessageBox.Show("Invoice not found at: " & pdfPath)
            End If
        End If
    End Sub

End Class
