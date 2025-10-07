<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillsTab
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
        Me.billsPanel = New System.Windows.Forms.Panel()
        Me.NewBill = New System.Windows.Forms.Button()
        Me.billsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'billsPanel
        '
        Me.billsPanel.Controls.Add(Me.NewBill)
        Me.billsPanel.Location = New System.Drawing.Point(45, 46)
        Me.billsPanel.Name = "billsPanel"
        Me.billsPanel.Size = New System.Drawing.Size(1012, 549)
        Me.billsPanel.TabIndex = 0
        '
        'NewBill
        '
        Me.NewBill.Location = New System.Drawing.Point(288, 409)
        Me.NewBill.Name = "NewBill"
        Me.NewBill.Size = New System.Drawing.Size(453, 67)
        Me.NewBill.TabIndex = 0
        Me.NewBill.Text = "New Bill"
        Me.NewBill.UseVisualStyleBackColor = True
        '
        'BillsTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1109, 607)
        Me.Controls.Add(Me.billsPanel)
        Me.Name = "BillsTab"
        Me.Text = "BillsTab"
        Me.billsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents billsPanel As Panel
    Friend WithEvents NewBill As Button
End Class
