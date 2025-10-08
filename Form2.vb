Imports ClosedXML.Excel
Imports System.IO



Public Class FrmMain


    ' Method to load any form into contentPanel
    Private Sub LoadFormInPanel(frm As Form)
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill

        ' Clear previous content
        contentPanel.Controls.Clear()
        contentPanel.Controls.Add(frm)

        ' Ensure layout is refreshed
        frm.Show()
        frm.BringToFront()
        contentPanel.Refresh()
    End Sub


    ' Create DashboardForm instance
    Private dashboard As New DashboardForm()

    ' Create StockInForm instance
    Public availableStockForm As New AvailableStock()

    ' Create RawMaterialsForm instance
    Private rawMaterialsForm As New AvailableRawMaterials()

    ' Create ReportsForm instance
    Private reportsForm As New Reports()

    ' Create  BillsForm instance
    Private billsForm As New BillsTab()

    ' Create  BillsForm instance
    Private financesForm As New Finances()

    ' Create  BillsForm instance
    Private AdminForm As New AdminPanel()



    ' Helper method to show a panel in contentPanel
    Private Sub ShowPanelInContentPanel(panelToShow As Panel)
        contentPanel.Controls.Clear()
        panelToShow.Dock = DockStyle.Fill
        contentPanel.Controls.Add(panelToShow)
        contentPanel.Refresh()
    End Sub




    ' In your main form Load or constructor
    Private Sub ApplyTheme()
        ' Fonts
        Me.Font = New Font("Segoe UI", 10)

        ' Background colors
        Me.BackColor = Color.FromArgb(240, 240, 240)   ' Light gray

        ' Panels and buttons
        Panel1.BackColor = Color.FromArgb(52, 73, 94)   ' Dark blue
        contentPanel.BackColor = Color.White

        For Each ctrl As Control In Panel1.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Font = New Font("Segoe UI Semibold", 10)
            End If
        Next

        ' Labels
        Label2.ForeColor = Color.FromArgb(52, 73, 94)
        Label2.Font = New Font("Segoe UI", 16, FontStyle.Bold)
    End Sub



    Private Sub ResizeButtonFont(btn As Button)
        Dim fontSize As Single = 1.0F
        Dim g As Graphics = btn.CreateGraphics()
        Dim stringSize As SizeF

        Do
            fontSize += 0.5F
            btn.Font = New Font(btn.Font.FontFamily, fontSize, btn.Font.Style)
            stringSize = g.MeasureString(btn.Text, btn.Font)
        Loop While stringSize.Width < btn.Width - 10 AndAlso stringSize.Height < btn.Height - 10

        ' Slightly reduce to fit perfectly
        btn.Font = New Font(btn.Font.FontFamily, fontSize - 0.5F, btn.Font.Style)
        g.Dispose()
    End Sub


    ' Active button reference
    Private activeButton As Button
    Private activeIndicator As Panel

    Private Sub StyleSidePanel()
        ' === Sidebar Panel ===
        Panel1.Dock = DockStyle.None   ' No full dock
        Panel1.Width = 200
        Panel1.Location = New Point(0, 100)   ' Start just below logo/title
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Panel1.BackColor = Color.FromArgb(36, 47, 61)

        ' Stretch to fill the remaining height
        Panel1.Height = Me.ClientSize.Height - Panel1.Top

        ' === Active Indicator ===
        activeIndicator = New Panel()
        activeIndicator.Size = New Size(5, 40)
        activeIndicator.BackColor = Color.FromArgb(0, 191, 255)
        activeIndicator.Visible = False
        Panel1.Controls.Add(activeIndicator)

        ' === Button Styling ===
        For Each ctrl As Control In Panel1.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)

                btn.Dock = DockStyle.Top
                btn.Height = 40
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0

                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 75, 95)
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 128, 185)

                btn.BackColor = Color.FromArgb(36, 47, 61)
                btn.ForeColor = Color.White
                btn.Font = New Font("Segoe UI", 10, FontStyle.Regular)
                btn.TextAlign = ContentAlignment.MiddleLeft
                btn.Padding = New Padding(12, 0, 0, 0)

                AddHandler btn.Click, AddressOf SideButton_Click
            End If
        Next
    End Sub

    ' Auto-resize when form size changes
    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Panel1.Height = Me.ClientSize.Height - Panel1.Top
    End Sub



    Private Sub SideButton_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Button = CType(sender, Button)

        ' Reset previous button
        If activeButton IsNot Nothing Then
            activeButton.BackColor = Color.FromArgb(36, 47, 61)
            activeButton.ForeColor = Color.White
        End If

        ' Set new active button
        activeButton = clickedButton
        activeButton.BackColor = Color.FromArgb(41, 128, 185) ' Active blue
        activeButton.ForeColor = Color.White

        ' Move active indicator
        activeIndicator.Visible = True
        activeIndicator.Top = activeButton.Top
        activeIndicator.BringToFront()
    End Sub




    Private appStartTime As DateTime = DateTime.Now ' Store app start time

    Private Sub AddMiniStatusPanel()
        ' Panel to hold status indicators
        Dim statusPanel As New Panel()
        statusPanel.Width = Panel1.Width
        statusPanel.Height = 170
        statusPanel.BackColor = Color.FromArgb(44, 62, 80) ' Darker than side panel
        statusPanel.Dock = DockStyle.Bottom
        statusPanel.Padding = New Padding(10)

        ' Define status items: Icon + Text
        Dim statuses As New List(Of Tuple(Of String, String)) From {
        New Tuple(Of String, String)("✅", "App Status: Running"),
        New Tuple(Of String, String)("📂", "Database: Connected"),
        New Tuple(Of String, String)("⚡", "User: Admin"),
        New Tuple(Of String, String)("🕒", $"App Started On:{Environment.NewLine}{appStartTime.ToString("dd-MM-yyyy")}{Environment.NewLine}{appStartTime.ToString("HH:mm:ss")}")
    }

        Dim yPos As Integer = 10

        For Each item In statuses
            ' Icon label
            Dim lblIcon As New Label()
            lblIcon.Text = item.Item1
            lblIcon.Font = New Font("Segoe UI", 14, FontStyle.Regular)
            lblIcon.ForeColor = Color.LimeGreen
            lblIcon.AutoSize = True
            lblIcon.Location = New Point(10, yPos)
            statusPanel.Controls.Add(lblIcon)

            ' Text label
            Dim lblText As New Label()
            lblText.Text = item.Item2
            lblText.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            lblText.ForeColor = Color.White
            lblText.AutoSize = True
            lblText.Location = New Point(40, yPos)
            statusPanel.Controls.Add(lblText)

            ' Adjust spacing
            Dim lineCount As Integer = item.Item2.Count(Function(c) c = vbLf) + 1
            yPos += 25 * lineCount + 5
        Next

        ' Add panel to sidebar
        Panel1.Controls.Add(statusPanel)
        statusPanel.BringToFront()
    End Sub






    ' Form Load
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'ApplyTheme()
        StyleSidePanel()
        AddMiniStatusPanel()



        ResizeButtonFont(Button1)
        ResizeButtonFont(Button2)
        ResizeButtonFont(Button3)
        ResizeButtonFont(Button4)
        ResizeButtonFont(Button5)
        ResizeButtonFont(Button6)
        ResizeButtonFont(Button7)




        Label2.Text = "Dashboard"


        ShowPanelInContentPanel(dashboard.dashboardPanel)

    End Sub

    ' Dashboard button
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Label2.Text = "Dashboard"

        ShowPanelInContentPanel(dashboard.dashboardPanel)

    End Sub

    ' Stock IN button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Label2.Text = "Stock"

        Dim stockForm As New AvailableStock()
        LoadFormInPanel(stockForm)


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Label2.Text = "Raw Materials"

        Dim rawForm As New AvailableRawMaterials()
        LoadFormInPanel(rawForm)

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Label2.Text = "Reports"
        ShowPanelInContentPanel(reportsForm.reportsPanel)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Label2.Text = "Bills"
        LoadFormInPanel(billsForm)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label2.Text = "Finances"
        LoadFormInPanel(financesForm)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Label2.Text = "Admin Panel"
        LoadFormInPanel(AdminForm)

    End Sub
End Class



