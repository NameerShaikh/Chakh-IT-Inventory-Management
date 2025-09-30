<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AvailableStock
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
        Me.availableStockPanel = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvAvailableStock = New System.Windows.Forms.DataGridView()
        Me.ProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mrp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Outer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MasterOuter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalPcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.availableStockPanel.SuspendLayout()
        CType(Me.dgvAvailableStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'availableStockPanel
        '
        Me.availableStockPanel.Controls.Add(Me.Button2)
        Me.availableStockPanel.Controls.Add(Me.Button1)
        Me.availableStockPanel.Controls.Add(Me.dgvAvailableStock)
        Me.availableStockPanel.Controls.Add(Me.Label1)
        Me.availableStockPanel.Location = New System.Drawing.Point(63, 36)
        Me.availableStockPanel.Name = "availableStockPanel"
        Me.availableStockPanel.Size = New System.Drawing.Size(1091, 608)
        Me.availableStockPanel.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(666, 567)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(381, 25)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Remove Stock"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(38, 569)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(319, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Add Stock"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvAvailableStock
        '
        Me.dgvAvailableStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAvailableStock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAvailableStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAvailableStock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductName, Me.Mrp, Me.Outer, Me.MasterOuter, Me.TotalPcs})
        Me.dgvAvailableStock.Location = New System.Drawing.Point(23, 15)
        Me.dgvAvailableStock.Name = "dgvAvailableStock"
        Me.dgvAvailableStock.RowHeadersWidth = 51
        Me.dgvAvailableStock.RowTemplate.Height = 24
        Me.dgvAvailableStock.Size = New System.Drawing.Size(1056, 532)
        Me.dgvAvailableStock.TabIndex = 1
        '
        'ProductName
        '
        Me.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ProductName.FillWeight = 41.44385!
        Me.ProductName.HeaderText = "Product"
        Me.ProductName.MinimumWidth = 6
        Me.ProductName.Name = "ProductName"
        Me.ProductName.ReadOnly = True
        '
        'Mrp
        '
        Me.Mrp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Mrp.FillWeight = 41.44385!
        Me.Mrp.HeaderText = "MRP"
        Me.Mrp.MinimumWidth = 6
        Me.Mrp.Name = "Mrp"
        Me.Mrp.ReadOnly = True
        '
        'Outer
        '
        Me.Outer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Outer.FillWeight = 41.44385!
        Me.Outer.HeaderText = "Outer (Pcs)"
        Me.Outer.MinimumWidth = 6
        Me.Outer.Name = "Outer"
        Me.Outer.ReadOnly = True
        '
        'MasterOuter
        '
        Me.MasterOuter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.MasterOuter.HeaderText = "Master Outer"
        Me.MasterOuter.MinimumWidth = 6
        Me.MasterOuter.Name = "MasterOuter"
        Me.MasterOuter.ReadOnly = True
        '
        'TotalPcs
        '
        Me.TotalPcs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TotalPcs.FillWeight = 41.44385!
        Me.TotalPcs.HeaderText = "Total pcs"
        Me.TotalPcs.MinimumWidth = 6
        Me.TotalPcs.Name = "TotalPcs"
        Me.TotalPcs.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1006, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Test"
        '
        'AvailableStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1186, 656)
        Me.Controls.Add(Me.availableStockPanel)
        Me.Name = "AvailableStock"
        Me.Text = "Available Stock"
        Me.availableStockPanel.ResumeLayout(False)
        Me.availableStockPanel.PerformLayout()
        CType(Me.dgvAvailableStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents dgvAvailableStock As DataGridView
    Friend WithEvents availableStockPanel As Panel
    Friend WithEvents ProductName As DataGridViewTextBoxColumn
    Friend WithEvents Mrp As DataGridViewTextBoxColumn
    Friend WithEvents Outer As DataGridViewTextBoxColumn
    Friend WithEvents MasterOuter As DataGridViewTextBoxColumn
    Friend WithEvents TotalPcs As DataGridViewTextBoxColumn
End Class
