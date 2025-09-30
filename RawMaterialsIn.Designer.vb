<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RawMaterialsInForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtProduct = New System.Windows.Forms.ComboBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.numQuantity = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtProduct
        '
        Me.txtProduct.FormattingEnabled = True
        Me.txtProduct.Location = New System.Drawing.Point(473, 68)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(408, 24)
        Me.txtProduct.TabIndex = 0
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(528, 258)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(407, 22)
        Me.txtUnit.TabIndex = 1
        '
        'numQuantity
        '
        Me.numQuantity.Location = New System.Drawing.Point(510, 398)
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(401, 22)
        Me.numQuantity.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(313, 511)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(408, 75)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Add Stock"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Product"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(80, 261)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Unit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 404)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Quantity"
        '
        'RawMaterialsInForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 643)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.numQuantity)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.txtProduct)
        Me.Name = "RawMaterialsInForm"
        Me.Text = "RawMaterialsIn"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtProduct As ComboBox
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents numQuantity As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
