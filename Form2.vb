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
    Private billsForm As New Bills()



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




    ' Form Load
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ApplyTheme()
        ResizeButtonFont(Button1)
        ResizeButtonFont(Button2)
        ResizeButtonFont(Button3)
        ResizeButtonFont(Button4)
        ResizeButtonFont(Button5)
        ResizeButtonFont(Button6)




        Label2.Text = "Dashboard"

        ' Use the instance "dashboard", not the class
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
        ShowPanelInContentPanel(reportsForm.reportsPanel)
        Label2.Text = "Reports"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ShowPanelInContentPanel(billsForm.billsPanel)
        Label2.Text = "Bills"
    End Sub
End Class



