<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AvailableRawMaterials
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.rawMaterialsPanel = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvRawMaterials = New System.Windows.Forms.DataGridView()
        Me.Product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rawMaterialsPanel.SuspendLayout()
        CType(Me.dgvRawMaterials, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rawMaterialsPanel
        '
        Me.rawMaterialsPanel.Controls.Add(Me.Button2)
        Me.rawMaterialsPanel.Controls.Add(Me.Button1)
        Me.rawMaterialsPanel.Controls.Add(Me.dgvRawMaterials)
        Me.rawMaterialsPanel.Controls.Add(Me.Label1)
        Me.rawMaterialsPanel.Location = New System.Drawing.Point(24, 15)
        Me.rawMaterialsPanel.Name = "rawMaterialsPanel"
        Me.rawMaterialsPanel.Size = New System.Drawing.Size(1144, 649)
        Me.rawMaterialsPanel.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(647, 590)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(337, 39)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Raw Materials Out"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(128, 590)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(337, 39)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Raw Materials In"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvRawMaterials
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRawMaterials.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRawMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRawMaterials.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Product, Me.Unit, Me.Quantity})
        Me.dgvRawMaterials.Location = New System.Drawing.Point(42, 34)
        Me.dgvRawMaterials.Name = "dgvRawMaterials"
        Me.dgvRawMaterials.RowHeadersWidth = 51
        Me.dgvRawMaterials.RowTemplate.Height = 24
        Me.dgvRawMaterials.Size = New System.Drawing.Size(1080, 537)
        Me.dgvRawMaterials.TabIndex = 1
        '
        'Product
        '
        Me.Product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Product.HeaderText = "Product"
        Me.Product.MinimumWidth = 6
        Me.Product.Name = "Product"
        Me.Product.ReadOnly = True
        '
        'Unit
        '
        Me.Unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Unit.HeaderText = "Unit"
        Me.Unit.MinimumWidth = 6
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        '
        'Quantity
        '
        Me.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.MinimumWidth = 6
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(876, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(265, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RawMaterials Test"
        '
        'AvailableRawMaterials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1180, 676)
        Me.Controls.Add(Me.rawMaterialsPanel)
        Me.Name = "AvailableRawMaterials"
        Me.Text = "RawMaterials"
        Me.rawMaterialsPanel.ResumeLayout(False)
        Me.rawMaterialsPanel.PerformLayout()
        CType(Me.dgvRawMaterials, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Public WithEvents rawMaterialsPanel As Panel
    Friend WithEvents dgvRawMaterials As DataGridView
    Friend WithEvents Product As DataGridViewTextBoxColumn
    Friend WithEvents Unit As DataGridViewTextBoxColumn
    Friend WithEvents Quantity As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
