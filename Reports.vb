Imports System.IO
Imports System.Data
'Imports DocumentFormat.OpenXml.Office2010.PowerPoint
'Imports DocumentFormat.OpenXml.Wordprocessing
Imports System.Windows
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Windows.Forms.DataVisualization.Charting



Partial Public Class Reports
    Inherits Form



    ' Config file paths
    Private productConfigPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\ProductConfiguration.csv"
    Private rawMaterialsConfigPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterialsConfig.csv"
    Private finishedGoodsConfigPath As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\FinishedGoodsConfig.csv"

    Private Sub Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' Initialize report types
        cmbReportType.Items.Clear()
        cmbReportType.Items.AddRange(New String() {
            "Stock In Report",
            "Stock Out Report",
            "Raw Materials In Report",
            "Raw Materials Out Report",
            "Finished Goods Report"
        })
        cmbReportType.SelectedIndex = 0 ' Default selection

        ' Default date range = this month
        dtpFrom.Value = New DateTime(Now.Year, Now.Month, 1)
        dtpTo.Value = DateTime.Now

        chkThisMonth.Checked = True
    End Sub

    ' Handle "This Month" checkbox
    Private Sub chkThisMonth_CheckedChanged(sender As Object, e As EventArgs) Handles chkThisMonth.CheckedChanged
        If chkThisMonth.Checked Then
            dtpFrom.Value = New DateTime(Now.Year, Now.Month, 1)
            dtpTo.Value = DateTime.Now
        Else
            ' Set dtpFrom to current system date
            dtpFrom.Value = DateTime.Now
        End If
    End Sub

    ' Handle report type selection → update filter list
    Private Sub cmbReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReportType.SelectedIndexChanged
        cmbFilterList.Items.Clear()

        Select Case cmbReportType.Text
            Case "Stock In Report", "Stock Out Report"
                LoadItemsFromCSV(productConfigPath, cmbFilterList, 0)

            Case "Raw Materials In Report", "Raw Materials Out Report"
                LoadItemsFromCSV(rawMaterialsConfigPath, cmbFilterList, 0)

            Case "Finished Goods Report"
                LoadItemsFromCSV(finishedGoodsConfigPath, cmbFilterList, 0)
        End Select
    End Sub

    ' Utility function to load names into ComboBox
    Private Sub LoadItemsFromCSV(path As String, combo As ComboBox, nameColumnIndex As Integer)
        If Not File.Exists(path) Then Return
        combo.Items.Clear()

        ' Add "All" option at the top
        combo.Items.Add("All")

        Dim lines = File.ReadAllLines(path)
        For Each line In lines.Skip(1) ' skip header
            Dim cols = line.Split(","c)
            If cols.Length > nameColumnIndex Then
                Dim name = cols(nameColumnIndex).Trim()
                If Not String.IsNullOrWhiteSpace(name) AndAlso Not combo.Items.Contains(name) Then
                    combo.Items.Add(name)
                End If
            End If
        Next

        combo.SelectedIndex = 0
    End Sub

    ' Generate Report Button
    ' Generate Report Button
    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        Dim filePath As String = ""
        Select Case cmbReportType.Text
            Case "Stock In Report"
                filePath = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockIn.csv"
            Case "Stock Out Report"
                filePath = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockOut.csv"
            Case "Raw Materials In Report"
                filePath = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterialsIn.csv"
            Case "Raw Materials Out Report"
                filePath = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\RawMaterialsOut.csv"
            Case "Finished Goods Report"
                filePath = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\FinishedGoods.csv"
        End Select

        If filePath = "" OrElse Not File.Exists(filePath) Then
            MessageBox.Show("Report file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        ' Read CSV into DataTable dynamically
        Dim dt As New DataTable()
        Dim lines = File.ReadAllLines(filePath)

        If lines.Length > 0 Then
            Dim headers = lines(0).Split(","c)
            For Each header In headers
                dt.Columns.Add(header.Trim())
            Next

            For Each line In lines.Skip(1)
                Dim cols = line.Split(","c)

                ' Ensure row matches column count
                If cols.Length > dt.Columns.Count Then
                    ' Add missing columns
                    For i As Integer = dt.Columns.Count To cols.Length - 1
                        dt.Columns.Add("Column" & (i + 1).ToString())
                    Next
                End If

                ' Resize row values to match DataTable columns
                Dim rowValues(dt.Columns.Count - 1) As Object
                Array.Copy(cols, rowValues, Math.Min(cols.Length, rowValues.Length))
                dt.Rows.Add(rowValues)
            Next
        End If


        ' --- Apply filter ---
        Dim filterItem As String = cmbFilterList.Text
        Dim fromDate As DateTime = dtpFrom.Value.Date
        Dim toDate As DateTime = dtpTo.Value.Date

        ' Get column index for Date (assume first column = Date)
        Dim dateColumnIndex As Integer = 0

        Dim filtered = dt.AsEnumerable().Where(Function(r)
                                                   ' Parse date in format dd-MM-yy
                                                   Dim recDate As DateTime
                                                   Dim dateStr As String = r(dateColumnIndex).ToString().Trim()

                                                   Dim formats() As String = {
                                                       "dd-MM-yy",
                                                       "dd-MM-yyyy",
                                                       "dd/MM/yyyy",
                                                       "dd/MM/yy",
                                                       "yyyy-MM-dd",
                                                       "dd-MM-yyyy HH:mm:ss",
                                                       "dd/MM/yyyy HH:mm:ss"
                                                   }

                                                   If DateTime.TryParseExact(
                                                           dateStr,
                                                           formats,
                                                           Globalization.CultureInfo.InvariantCulture,
                                                           Globalization.DateTimeStyles.AllowWhiteSpaces,
                                                           recDate) Then

                                                       ' Apply Date Range filter
                                                       If recDate >= fromDate AndAlso recDate <= toDate Then
                                                           ' Apply Item filter if not "All"
                                                           If filterItem = "All" OrElse r(2).ToString().Trim().Equals(filterItem, StringComparison.OrdinalIgnoreCase) Then
                                                               Return True
                                                           End If
                                                       End If
                                                   End If
                                                   Return False
                                               End Function)

        If filtered.Any() Then
            dgvReport.DataSource = filtered.CopyToDataTable()
        Else
            dgvReport.DataSource = Nothing
            MessageBox.Show("No records found for the selected filter and date range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If




        ' ===== Configure DataGridView appearance =====
        With dgvReport
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            .DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Regular)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .RowHeadersVisible = False



        End With



    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        ' Reset all filters
        cmbReportType.SelectedIndex = 0
        cmbFilterList.SelectedIndex = 0
        chkThisMonth.Checked = False
        dtpFrom.Value = New DateTime(Now.Year, Now.Month, 1)
        dtpTo.Value = DateTime.Now

        ' Clear DataGridView
        dgvReport.DataSource = Nothing
        dgvReport.Rows.Clear()
        dgvReport.Columns.Clear()
    End Sub



    ' --- Export PDF with alternating row colors and page numbers ---
    Private Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click
        If dgvReport.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using sfd As New SaveFileDialog()
            sfd.Filter = "PDF files (*.pdf)|*.pdf"
            sfd.FileName = "Report.pdf"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim pdfDoc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 20, 20)
                    Dim writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, New FileStream(sfd.FileName, FileMode.Create))
                    writer.PageEvent = New PDFPageEvents()
                    pdfDoc.Open()

                    Dim titleFont = iTextSharp.text.FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD)
                    Dim title = New iTextSharp.text.Paragraph(cmbReportType.Text & " (" & dtpFrom.Value.ToShortDateString() & " - " & dtpTo.Value.ToShortDateString() & ")", titleFont)
                    title.Alignment = iTextSharp.text.Element.ALIGN_CENTER
                    title.SpacingAfter = 20
                    pdfDoc.Add(title)

                    Dim pdfTable As New iTextSharp.text.pdf.PdfPTable(dgvReport.Columns.Count)
                    pdfTable.WidthPercentage = 100

                    ' Headers
                    For Each column As DataGridViewColumn In dgvReport.Columns
                        Dim cell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(column.HeaderText))
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                        pdfTable.AddCell(cell)
                    Next

                    ' Rows with alternating colors
                    For i As Integer = 0 To dgvReport.Rows.Count - 1
                        Dim row = dgvReport.Rows(i)
                        If row.IsNewRow Then Continue For
                        For Each cell As DataGridViewCell In row.Cells
                            Dim pdfCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(cell.Value?.ToString(), "")))
                            If i Mod 2 = 0 Then
                                pdfCell.BackgroundColor = iTextSharp.text.BaseColor.WHITE
                            Else
                                pdfCell.BackgroundColor = New iTextSharp.text.BaseColor(240, 248, 255) ' AliceBlue
                            End If
                            pdfTable.AddCell(pdfCell)
                        Next
                    Next

                    pdfDoc.Add(pdfTable)
                    pdfDoc.Close()
                    MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error exporting PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    ' --- PDF Page Events for page numbers ---
    Private Class PDFPageEvents
        Inherits iTextSharp.text.pdf.PdfPageEventHelper
        Public Overrides Sub OnEndPage(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document)
            Dim cb = writer.DirectContent
            cb.BeginText()
            Dim bf = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.CP1252, False)
            cb.SetFontAndSize(bf, 10)
            cb.ShowTextAligned(iTextSharp.text.Element.ALIGN_RIGHT, "Page " & document.PageNumber, document.Right - 10, document.Bottom - 10, 0)
            cb.EndText()
        End Sub
    End Class




    Private Sub btnVisuals_Click(sender As Object, e As EventArgs) Handles btnVisuals.Click
        If dgvReport.Rows.Count = 0 Then
            MessageBox.Show("No data to visualize.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Ask user chart type
        Dim chartType As String = InputBox("Enter Chart Type: Column / Pie / Line", "Select Chart Type", "Column")
        If String.IsNullOrWhiteSpace(chartType) Then Return
        chartType = chartType.Trim().ToLower()

        ' Create new form
        Dim visualForm As New Form()
        visualForm.Text = cmbReportType.Text & " - Visuals"
        visualForm.Size = New System.Drawing.Size(800, 600)

        ' Create Chart control
        Dim chart As New System.Windows.Forms.DataVisualization.Charting.Chart()
        chart.Dock = DockStyle.Fill
        visualForm.Controls.Add(chart)

        ' ChartArea
        Dim chartArea As New System.Windows.Forms.DataVisualization.Charting.ChartArea("MainArea")
        chart.ChartAreas.Add(chartArea)

        ' Series
        Dim series As New System.Windows.Forms.DataVisualization.Charting.Series("Data")
        Select Case chartType
            Case "column" : series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            Case "pie" : series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
            Case "line" : series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            Case Else : series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
        End Select
        series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String
        chart.Series.Add(series)

        ' --- Detect label and numeric column ---
        Dim labelColIndex As Integer = 0
        Dim valueColIndex As Integer = -1

        ' Pick the first numeric column for values
        For i As Integer = 0 To dgvReport.Columns.Count - 1
            Dim isNumeric As Boolean = True
            For Each row As DataGridViewRow In dgvReport.Rows
                If row.IsNewRow Then Continue For
                Dim val = row.Cells(i).Value
                If val IsNot Nothing AndAlso Not Double.TryParse(val.ToString(), 0) Then
                    isNumeric = False
                    Exit For
                End If
            Next
            If isNumeric Then
                valueColIndex = i
                Exit For
            End If
        Next

        If valueColIndex = -1 Then
            MessageBox.Show("No numeric column found for chart values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Use first column for labels
        labelColIndex = 0

        ' Aggregate data
        Dim dataDict As New Dictionary(Of String, Double)
        For Each row As DataGridViewRow In dgvReport.Rows
            If row.IsNewRow Then Continue For
            Dim key As String = If(row.Cells(labelColIndex).Value IsNot Nothing, row.Cells(labelColIndex).Value.ToString(), "Unknown")
            Dim val As Double = 0
            Double.TryParse(If(row.Cells(valueColIndex).Value IsNot Nothing, row.Cells(valueColIndex).Value.ToString(), "0"), val)
            If dataDict.ContainsKey(key) Then
                dataDict(key) += val
            Else
                dataDict.Add(key, val)
            End If
        Next

        ' Add points to series
        For Each kvp In dataDict
            series.Points.AddXY(kvp.Key, kvp.Value)
        Next

        ' Beautify
        chart.Legends.Add(New System.Windows.Forms.DataVisualization.Charting.Legend("Legend"))
        chart.ChartAreas(0).AxisX.Interval = 1
        chart.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        chart.ChartAreas(0).AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray

        visualForm.ShowDialog()
    End Sub

End Class