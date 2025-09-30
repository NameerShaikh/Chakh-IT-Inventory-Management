<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RawMaterialsOutForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProduct = New System.Windows.Forms.ComboBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.numQuantity = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(79, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(79, 234)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(79, 371)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Label3"
        '
        'txtProduct
        '
        Me.txtProduct.FormattingEnabled = True
        Me.txtProduct.Location = New System.Drawing.Point(415, 81)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(360, 24)
        Me.txtProduct.TabIndex = 3
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(427, 217)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(421, 22)
        Me.txtUnit.TabIndex = 4
        '
        'numQuantity
        '
        Me.numQuantity.Location = New System.Drawing.Point(422, 378)
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(470, 22)
        Me.numQuantity.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(352, 488)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(480, 77)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Remove Stock"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'RawMaterialsOutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1157, 626)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.numQuantity)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.txtProduct)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "RawMaterialsOutForm"
        Me.Text = "RawMaterialsOut"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProduct As ComboBox
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents numQuantity As TextBox
    Friend WithEvents btnSave As Button
End Class
