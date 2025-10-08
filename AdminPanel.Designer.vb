<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminPanel
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Private btnAddProduct As Button
    Private btnRemoveProduct As Button
    Private btnChangeProductMRP As Button
    Private btnChangePcs As Button
    Private btnChangeOuters As Button
    Private btnAddCustomer As Button
    Private btnRemoveCustomer As Button
    Private btnAddRawMaterial As Button
    Private btnRemoveRawMaterial As Button
    Private btnChangePassword As Button
    Private PanelFormContainer As Panel
    Private PanelButtons As Panel

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelButtons = New System.Windows.Forms.Panel()
        Me.PanelFormContainer = New System.Windows.Forms.Panel()
        Me.SuspendLayout()

        ' =======================
        ' PanelButtons
        ' =======================
        Me.PanelButtons.Dock = DockStyle.Left
        Me.PanelButtons.Width = 220
        Me.PanelButtons.Padding = New Padding(10)
        Me.PanelButtons.BackColor = Color.FromArgb(44, 62, 80)
        Me.PanelButtons.AutoScroll = True
        Me.Controls.Add(Me.PanelButtons)

        ' =======================
        ' Buttons in Panel
        ' =======================
        Dim btns As Button() = {btnAddProduct, btnRemoveProduct, btnChangeProductMRP, btnChangePcs, btnChangeOuters, btnAddCustomer, btnRemoveCustomer, btnAddRawMaterial, btnRemoveRawMaterial, btnChangePassword}
        Dim texts As String() = {"Add Product", "Remove Product", "Change Product MRP", "Change Pcs per Outer", "Change Outers per Master Outer", "Add Customer", "Remove Customer", "Add Raw Material", "Remove Raw Material", "Change Password"}

        Dim yPos As Integer = 10
        For i As Integer = 0 To btns.Length - 1
            btns(i) = New Button()
            btns(i).Text = texts(i)
            btns(i).Width = PanelButtons.Width - 20
            btns(i).Height = 40
            btns(i).Top = yPos
            btns(i).Left = 10
            btns(i).BackColor = Color.FromArgb(52, 152, 219)
            btns(i).ForeColor = Color.White
            btns(i).FlatStyle = FlatStyle.Flat
            btns(i).Font = New Font("Segoe UI", 10, FontStyle.Bold)
            AddHandler btns(i).MouseEnter, Sub(sender, e) CType(sender, Button).BackColor = Color.FromArgb(41, 128, 185)
            AddHandler btns(i).MouseLeave, Sub(sender, e) CType(sender, Button).BackColor = Color.FromArgb(52, 152, 219)
            Me.PanelButtons.Controls.Add(btns(i))
            yPos += 50
        Next

        ' Assign class-level buttons
        btnAddProduct = btns(0)
        btnRemoveProduct = btns(1)
        btnChangeProductMRP = btns(2)
        btnChangePcs = btns(3)
        btnChangeOuters = btns(4)
        btnAddCustomer = btns(5)
        btnRemoveCustomer = btns(6)
        btnAddRawMaterial = btns(7)
        btnRemoveRawMaterial = btns(8)
        btnChangePassword = btns(9)

        ' =======================
        ' PanelFormContainer
        ' =======================
        Me.PanelFormContainer.Dock = DockStyle.Fill
        Me.PanelFormContainer.Padding = New Padding(15)
        Me.PanelFormContainer.BackColor = Color.White
        Me.PanelFormContainer.AutoScroll = True
        Me.Controls.Add(Me.PanelFormContainer)

        ' =======================
        ' AdminPanel Form
        ' =======================
        Me.BackColor = Color.FromArgb(236, 240, 241)
        Me.Font = New Font("Segoe UI", 10)
        Me.Dock = DockStyle.Fill
        Me.ResumeLayout(False)
    End Sub
End Class
