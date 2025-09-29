Imports ClosedXML.Excel
Imports System.IO



Public Class FrmMain

    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        contentPanel.Refresh() ' forces redraw, usually optional
    End Sub



    ' Create DashboardForm instance
    Private dashboard As New DashboardForm()

    ' Create StockInForm instance
    Private stockInForm As New StockIn()

    ' Create StockOutForm instance
    Private stockOutForm As New StockOut()

    ' Create RawMaterialsForm instance
    Private rawMaterialsForm As New RawMaterials()

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
        ' Use the instance "dashboard", not the class
        ShowPanelInContentPanel(dashboard.dashboardPanel)
        Label2.Text = "Dashboard"
    End Sub

    ' Dashboard button
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ShowPanelInContentPanel(dashboard.dashboardPanel)
        Label2.Text = "Dashboard"
    End Sub

    ' Stock IN button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ShowPanelInContentPanel(stockInForm.stockInPanel)
        Label2.Text = "Stock IN"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ShowPanelInContentPanel(stockOutForm.stockOutPanel)
        Label2.Text = "Stock OUT"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ShowPanelInContentPanel(rawMaterialsForm.rawMaterialsPanel)
        Label2.Text = "Raw Materials"
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



