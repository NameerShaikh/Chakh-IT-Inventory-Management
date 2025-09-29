<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockIn
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.stockInPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stockInPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'stockInPanel
        '
        Me.stockInPanel.Controls.Add(Me.Label1)
        Me.stockInPanel.Location = New System.Drawing.Point(63, 36)
        Me.stockInPanel.Name = "stockInPanel"
        Me.stockInPanel.Size = New System.Drawing.Size(656, 349)
        Me.stockInPanel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Test"
        '
        'StockIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.stockInPanel)
        Me.Name = "StockIn"
        Me.Text = "StockIn"
        Me.stockInPanel.ResumeLayout(False)
        Me.stockInPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents stockInPanel As Panel
    Friend WithEvents Label1 As Label
End Class
