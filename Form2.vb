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

    ' Form Load
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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



