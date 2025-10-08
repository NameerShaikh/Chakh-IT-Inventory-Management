<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductDialog
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblName As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblMRP As Label
    Friend WithEvents txtMRP As TextBox
    Friend WithEvents lblPcs As Label
    Friend WithEvents txtPcs As TextBox
    Friend WithEvents lblOuters As Label
    Friend WithEvents txtOuters As TextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblMRP = New System.Windows.Forms.Label()
        Me.txtMRP = New System.Windows.Forms.TextBox()
        Me.lblPcs = New System.Windows.Forms.Label()
        Me.txtPcs = New System.Windows.Forms.TextBox()
        Me.lblOuters = New System.Windows.Forms.Label()
        Me.txtOuters = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(20, 20)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(93, 16)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Product Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(150, 20)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(200, 22)
        Me.txtName.TabIndex = 1
        '
        'lblMRP
        '
        Me.lblMRP.AutoSize = True
        Me.lblMRP.Location = New System.Drawing.Point(20, 60)
        Me.lblMRP.Name = "lblMRP"
        Me.lblMRP.Size = New System.Drawing.Size(37, 16)
        Me.lblMRP.TabIndex = 2
        Me.lblMRP.Text = "MRP"
        '
        'txtMRP
        '
        Me.txtMRP.Location = New System.Drawing.Point(150, 60)
        Me.txtMRP.Name = "txtMRP"
        Me.txtMRP.Size = New System.Drawing.Size(200, 22)
        Me.txtMRP.TabIndex = 3
        '
        'lblPcs
        '
        Me.lblPcs.AutoSize = True
        Me.lblPcs.Location = New System.Drawing.Point(20, 100)
        Me.lblPcs.Name = "lblPcs"
        Me.lblPcs.Size = New System.Drawing.Size(107, 16)
        Me.lblPcs.TabIndex = 4
        Me.lblPcs.Text = "Pieces per Outer"
        '
        'txtPcs
        '
        Me.txtPcs.Location = New System.Drawing.Point(150, 100)
        Me.txtPcs.Name = "txtPcs"
        Me.txtPcs.Size = New System.Drawing.Size(200, 22)
        Me.txtPcs.TabIndex = 5
        '
        'lblOuters
        '
        Me.lblOuters.AutoSize = True
        Me.lblOuters.Location = New System.Drawing.Point(20, 140)
        Me.lblOuters.Name = "lblOuters"
        Me.lblOuters.Size = New System.Drawing.Size(145, 16)
        Me.lblOuters.TabIndex = 6
        Me.lblOuters.Text = "Outers per MasterOuter"
        '
        'txtOuters
        '
        Me.txtOuters.Location = New System.Drawing.Point(150, 140)
        Me.txtOuters.Name = "txtOuters"
        Me.txtOuters.Size = New System.Drawing.Size(200, 22)
        Me.txtOuters.TabIndex = 7
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(80, 190)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(200, 190)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        '
        'ProductDialog
        '
        Me.ClientSize = New System.Drawing.Size(380, 250)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblMRP)
        Me.Controls.Add(Me.txtMRP)
        Me.Controls.Add(Me.lblPcs)
        Me.Controls.Add(Me.txtPcs)
        Me.Controls.Add(Me.lblOuters)
        Me.Controls.Add(Me.txtOuters)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ProductDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Product"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
