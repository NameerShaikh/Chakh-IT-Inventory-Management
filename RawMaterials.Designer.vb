<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RawMaterials
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
        Me.rawMaterialsPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rawMaterialsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'rawMaterialsPanel
        '
        Me.rawMaterialsPanel.Controls.Add(Me.Label1)
        Me.rawMaterialsPanel.Location = New System.Drawing.Point(24, 15)
        Me.rawMaterialsPanel.Name = "rawMaterialsPanel"
        Me.rawMaterialsPanel.Size = New System.Drawing.Size(731, 390)
        Me.rawMaterialsPanel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(97, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(265, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RawMaterials Test"
        '
        'RawMaterials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.rawMaterialsPanel)
        Me.Name = "RawMaterials"
        Me.Text = "RawMaterials"
        Me.rawMaterialsPanel.ResumeLayout(False)
        Me.rawMaterialsPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Public WithEvents rawMaterialsPanel As Panel
End Class
