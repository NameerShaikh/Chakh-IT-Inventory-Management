Imports System.IO
Imports System.Linq
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Threading

Public Class DashboardForm
    Inherits Form

    ' CSV Paths
    Private ReadOnly stockOutCSV As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\StockOut.csv"
    Private ReadOnly creditCSV As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\Credit.csv"
    Private ReadOnly customerCSV As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\CustomerConfig.csv"
    Private ReadOnly stockCSV As String = "C:\CHAKH IT Management Software\WindowsApp1\AppFolder\AvailableStock.csv"

    ' KPI labels
    Private lblTotalSales As Label
    Private lblTotalCustomers As Label
    Private lblProductsSold As Label
    Private lblTotalBills As Label

    ' Scrollable panels
    Private flpFastestProduct As FlowLayoutPanel
    Private flpUnpaidCredits As FlowLayoutPanel

    ' Chart
    Private chartFastest As Chart

    Public Sub New()
        InitializeComponent()
        SetupUI()
        LoadData()
    End Sub

    Private Sub SetupUI()
        ' --- Form ---
        Me.Text = "Dashboard"
        Me.Size = New Size(1000, 700)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(230, 230, 230)

        ' --- Main content panel ---
        Dim pnlContent As New Panel With {
            .Dock = DockStyle.Fill,
            .Padding = New Padding(20),
            .AutoScroll = True
        }
        Me.Controls.Add(pnlContent)

        ' --- KPI Panel ---
        Dim pnlKPIs As New TableLayoutPanel With {
            .Dock = DockStyle.Top,
            .Height = 120,
            .AutoSize = False,
            .ColumnCount = 4,
            .RowCount = 1,
            .Padding = New Padding(0),
            .Margin = New Padding(0)
        }
        For i As Integer = 0 To 3
            pnlKPIs.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25))
        Next

        ' Add KPI Cards
        lblTotalSales = AddKPICard(pnlKPIs, 0, "Total Sales This Month", "₹0", Color.FromArgb(102, 205, 170))
        lblTotalCustomers = AddKPICard(pnlKPIs, 1, "Total Customers", "0", Color.FromArgb(255, 218, 185))
        lblProductsSold = AddKPICard(pnlKPIs, 2, "Products Sold", "0", Color.FromArgb(135, 206, 235))
        lblTotalBills = AddKPICard(pnlKPIs, 3, "Total Bills", "0", Color.FromArgb(250, 128, 114))

        pnlContent.Controls.Add(pnlKPIs)

        ' --- Scrollable Panels Container ---
        Dim pnlScrollableContainer As New FlowLayoutPanel With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False,
            .AutoScroll = True,
            .Padding = New Padding(0, 150, 0, 0) ' top padding for KPI cards
        }
        pnlContent.Controls.Add(pnlScrollableContainer)

        ' --- Fastest Running Products Panel ---
        Dim pnlFastest = CreateScrollablePanel("Fastest Running Products (This Month)", Color.FromArgb(245, 245, 245), 180)
        flpFastestProduct = pnlFastest.Controls.OfType(Of FlowLayoutPanel)().First()
        pnlScrollableContainer.Controls.Add(pnlFastest)

        ' --- Unpaid Credits Panel ---
        Dim pnlCredits = CreateScrollablePanel("Unpaid Credits", Color.FromArgb(245, 245, 245), 180)
        flpUnpaidCredits = pnlCredits.Controls.OfType(Of FlowLayoutPanel)().First()
        pnlScrollableContainer.Controls.Add(pnlCredits)

        ' --- Chart Panel below Unpaid Credits ---
        Dim pnlChart As New Panel With {
            .Height = 300,
            .Width = pnlScrollableContainer.ClientSize.Width - 25,
            .Margin = New Padding(0, 0, 0, 20),
            .BackColor = Color.FromArgb(245, 245, 245),
            .BorderStyle = BorderStyle.FixedSingle
        }

        chartFastest = New Chart With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.FromArgb(230, 230, 230)
        }

        Dim chartArea As New ChartArea()
        chartArea.BackColor = Color.FromArgb(245, 245, 245)
        chartFastest.ChartAreas.Add(chartArea)
        chartFastest.Legends.Add(New Legend() With {.Docking = Docking.Top, .Alignment = StringAlignment.Center})

        pnlChart.Controls.Add(chartFastest)
        pnlScrollableContainer.Controls.Add(pnlChart)


        ' --- Cursor feedback ---
        AddHandler chartFastest.MouseEnter, Sub()
                                                chartFastest.Cursor = Cursors.Hand
                                            End Sub

        AddHandler chartFastest.MouseLeave, Sub()
                                                chartFastest.Cursor = Cursors.Default
                                            End Sub



        ' --- Click to enlarge chart ---
        AddHandler chartFastest.Click, Sub(sender, e)
                                           ShowChartInCenter(DirectCast(sender, Chart))
                                       End Sub


        ' --- Resize handler ---
        AddHandler Me.Resize, Sub(s, e)
                                  For Each pnl In pnlScrollableContainer.Controls.OfType(Of Panel)()
                                      pnl.Width = pnlScrollableContainer.ClientSize.Width - 25
                                      Dim flp = pnl.Controls.OfType(Of FlowLayoutPanel)().FirstOrDefault()
                                      If flp IsNot Nothing Then flp.Width = pnl.Width - 10
                                  Next
                              End Sub
    End Sub

    ' --- Add KPI Card ---
    Private Function AddKPICard(parent As TableLayoutPanel, columnIndex As Integer, title As String, value As String, cardColor As Color) As Label
        Dim pnl As New Panel With {
            .Dock = DockStyle.Fill,
            .Margin = New Padding(5),
            .BackColor = cardColor,
            .BorderStyle = BorderStyle.FixedSingle,
            .Cursor = Cursors.Hand,
            .Width = 220,
            .Height = 100
        }

        ' Tooltip
        Dim tt As New ToolTip()
        tt.SetToolTip(pnl, title & ": " & value)

        ' Hover effect
        AddHandler pnl.MouseEnter, Sub() pnl.BackColor = ControlPaint.Light(cardColor)
        AddHandler pnl.MouseLeave, Sub() pnl.BackColor = cardColor

        Dim lblTitle As New Label With {
            .Text = title,
            .ForeColor = Color.Black,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Dock = DockStyle.Top,
            .Height = 25,
            .TextAlign = ContentAlignment.MiddleCenter
        }

        Dim lblValue As New Label With {
            .Text = value,
            .ForeColor = Color.Black,
            .Font = New Font("Segoe UI", 14, FontStyle.Bold),
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleCenter
        }

        pnl.Controls.Add(lblValue)
        pnl.Controls.Add(lblTitle)
        parent.Controls.Add(pnl, columnIndex, 0)
        Return lblValue
    End Function

    ' --- Create Scrollable Panel ---
    Private Function CreateScrollablePanel(title As String, bgColor As Color, panelHeight As Integer) As Panel
        Dim pnl As New Panel With {
            .BackColor = bgColor,
            .Height = panelHeight,
            .Width = 900,
            .Margin = New Padding(0, 0, 0, 20),
            .BorderStyle = BorderStyle.FixedSingle
        }

        ' Panel header label
        Dim lbl As New Label With {
            .Text = title,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Dock = DockStyle.Top,
            .Height = 30,
            .Padding = New Padding(10, 0, 0, 0),
            .BackColor = Color.FromArgb(135, 206, 250),
            .ForeColor = Color.Black
        }
        pnl.Controls.Add(lbl)

        ' Scrollable content
        Dim flp As New FlowLayoutPanel With {
            .Width = pnl.Width - 10,
            .Height = pnl.Height - lbl.Height - 10,
            .Top = lbl.Height + 5,
            .Left = 5,
            .AutoScroll = True,
            .Padding = New Padding(5),
            .BackColor = Color.FromArgb(240, 240, 240),
            .WrapContents = False,
            .FlowDirection = FlowDirection.TopDown
        }
        pnl.Controls.Add(flp)
        Return pnl
    End Function

    ' --- Load Data ---
    Private Sub LoadData()
        flpFastestProduct.Controls.Clear()
        flpUnpaidCredits.Controls.Clear()
        chartFastest.Series.Clear()

        Dim totalProducts As Integer = 0
        Dim totalBills As Integer = 0
        Dim productDict As New Dictionary(Of String, Integer)

        Dim stockLines = If(File.Exists(stockCSV), File.ReadAllLines(stockCSV).Skip(1).ToArray(), {})

        ' --- StockOut / Fastest Products ---
        If File.Exists(stockOutCSV) Then
            Dim nowMonth = DateTime.Now.Month
            Dim nowYear = DateTime.Now.Year

            For Each line In File.ReadAllLines(stockOutCSV).Skip(1) ' skip header
                Dim parts = line.Split(","c)
                If parts.Length < 5 Then Continue For

                Dim saleDate As DateTime
                If Not DateTime.TryParse(parts(0).Trim(), saleDate) Then Continue For


                ' ✅ Correct month & year check
                If saleDate.Month = nowMonth AndAlso saleDate.Year = nowYear Then
                    Dim qty As Integer = 0
                    Integer.TryParse(parts(4), qty)

                    totalProducts += qty
                    totalBills += 1

                    Dim product = parts(2).Trim()
                    If productDict.ContainsKey(product) Then
                        productDict(product) += qty
                    Else
                        productDict(product) = qty
                    End If
                End If
            Next

        End If

        ' --- Animate other KPI numbers ---
        AnimateKPI(lblProductsSold, totalProducts)
        AnimateKPI(lblTotalBills, totalBills)
        AnimateKPI(lblTotalCustomers, If(File.Exists(customerCSV), File.ReadAllLines(customerCSV).Length, 0))

        ' --- Fastest Products ---
        Dim i As Integer = 0
        Dim topProducts = productDict.OrderByDescending(Function(x) x.Value).Take(5)
        For Each kvp In topProducts
            Dim clr = If(i Mod 2 = 0, Color.LightGreen, Color.FromArgb(144, 238, 144))
            flpFastestProduct.Controls.Add(CreateListItem($"{kvp.Key} - {kvp.Value} pcs sold", clr))
            i += 1
        Next
        If flpFastestProduct.Controls.Count = 0 Then
            flpFastestProduct.Controls.Add(CreateListItem("No sales this month", Color.LightGray))
        End If

        ' --- Unpaid Credits ---
        If File.Exists(creditCSV) Then
            i = 0
            For Each line In File.ReadAllLines(creditCSV)
                Dim clr = If(i Mod 2 = 0, Color.LightBlue, Color.FromArgb(173, 216, 230))
                flpUnpaidCredits.Controls.Add(CreateListItem(line, clr))
                i += 1
            Next
            If flpUnpaidCredits.Controls.Count = 0 Then
                flpUnpaidCredits.Controls.Add(CreateListItem("No unpaid credits", Color.LightGray))
            End If
        End If

        ' --- Populate Chart ---
        Dim series As New Series With {
        .ChartType = SeriesChartType.Column,
        .IsValueShownAsLabel = True
    }
        chartFastest.Series.Add(series)
        For Each kvp In topProducts
            series.Points.AddXY(kvp.Key, kvp.Value)
        Next







        ' Change KPI card title from "Total Sales This Month" to something else
        lblTotalSales.Parent.Controls.OfType(Of Label)().First(Function(l) l.Dock = DockStyle.Top).Text = "Chakh It!"


        ' --- Total Sales KPI: show placeholder text with emoji ---
        lblTotalSales.Text = "🍬 People are lovin' it!"
        lblTotalSales.Font = New Font("Segoe UI Emoji", 14, FontStyle.Bold)
        lblTotalSales.TextAlign = ContentAlignment.MiddleCenter









    End Sub



    Public Sub ReloadDashboard()
        LoadData()
    End Sub





    ' --- Animate KPI ---
    Private Sub AnimateKPI(lbl As Label, targetValue As Decimal, Optional prefix As String = "")
        Dim currentValue As Decimal = 0
        Dim stepValue As Decimal = Math.Max(1, targetValue / 50)

        ' Use WinForms Timer explicitly
        Dim timer As New System.Windows.Forms.Timer()
        timer.Interval = 20

        AddHandler timer.Tick, Sub()
                                   currentValue += stepValue
                                   If currentValue >= targetValue Then
                                       currentValue = targetValue
                                       timer.Stop()
                                   End If
                                   lbl.Text = $"{prefix}{Math.Round(currentValue)}"
                               End Sub
        timer.Start()
    End Sub

    ' --- List Item ---
    Private Function CreateListItem(text As String, bgColor As Color) As Panel
        Dim pnl As New Panel With {.Height = 30, .Width = 850, .BackColor = bgColor, .Margin = New Padding(5)}
        Dim lbl As New Label With {.Text = text, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleLeft, .Padding = New Padding(5, 0, 0, 0)}
        pnl.Controls.Add(lbl)
        Return pnl
    End Function

    ' --- Show chart in center on hover ---
    Private Sub ShowChartInCenter(originalChart As Chart)
        Dim frm As New Form With {
            .Size = New Size(600, 400),
            .StartPosition = FormStartPosition.CenterScreen
        }
        Dim chartCopy As New Chart With {
            .Dock = DockStyle.Fill
        }
        ' Copy series
        For Each s As Series In originalChart.Series
            Dim newSeries As New Series(s.Name) With {.ChartType = s.ChartType, .IsValueShownAsLabel = s.IsValueShownAsLabel}
            For Each pt As DataPoint In s.Points
                newSeries.Points.AddXY(pt.AxisLabel, pt.YValues(0))
            Next
            chartCopy.Series.Add(newSeries)
        Next
        ' Copy chart areas
        For Each ca As ChartArea In originalChart.ChartAreas
            Dim newCA As New ChartArea(ca.Name)
            chartCopy.ChartAreas.Add(newCA)
        Next
        ' Copy legends
        For Each lg As Legend In originalChart.Legends
            Dim newLg As New Legend(lg.Name)
            chartCopy.Legends.Add(newLg)
        Next
        frm.Controls.Add(chartCopy)
        frm.ShowDialog()
    End Sub

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
