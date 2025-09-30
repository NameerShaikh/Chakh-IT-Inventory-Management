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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.availableStockPanel = New System.Windows.Forms.Panel()
        Me.btnRemoveStock = New System.Windows.Forms.Button()
        Me.btnAddStock = New System.Windows.Forms.Button()
        Me.dgvAvailableStock = New System.Windows.Forms.DataGridView()
        Me.ProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mrp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PcsPerOuter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Outer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalPcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.availableStockPanel.SuspendLayout()
        CType(Me.dgvAvailableStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'availableStockPanel
        '
        Me.availableStockPanel.Controls.Add(Me.btnRemoveStock)
        Me.availableStockPanel.Controls.Add(Me.btnAddStock)
        Me.availableStockPanel.Controls.Add(Me.dgvAvailableStock)
        Me.availableStockPanel.Controls.Add(Me.Label1)
        Me.availableStockPanel.Location = New System.Drawing.Point(63, 36)
        Me.availableStockPanel.Name = "availableStockPanel"
        Me.availableStockPanel.Size = New System.Drawing.Size(1091, 608)
        Me.availableStockPanel.TabIndex = 0
        '
        'btnRemoveStock
        '
        Me.btnRemoveStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveStock.Location = New System.Drawing.Point(666, 567)
        Me.btnRemoveStock.Name = "btnRemoveStock"
        Me.btnRemoveStock.Size = New System.Drawing.Size(381, 25)
        Me.btnRemoveStock.TabIndex = 3
        Me.btnRemoveStock.Text = "Remove Stock"
        Me.btnRemoveStock.UseVisualStyleBackColor = True
        '
        'btnAddStock
        '
        Me.btnAddStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddStock.Location = New System.Drawing.Point(38, 569)
        Me.btnAddStock.Name = "btnAddStock"
        Me.btnAddStock.Size = New System.Drawing.Size(319, 23)
        Me.btnAddStock.TabIndex = 2
        Me.btnAddStock.Text = "Add Stock"
        Me.btnAddStock.UseVisualStyleBackColor = True
        '
        'dgvAvailableStock
        '
        Me.dgvAvailableStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAvailableStock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAvailableStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAvailableStock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductName, Me.Mrp, Me.PcsPerOuter, Me.Outer, Me.TotalPcs})
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
        'PcsPerOuter
        '
        Me.PcsPerOuter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.PcsPerOuter.HeaderText = "Pcs/Outer"
        Me.PcsPerOuter.MinimumWidth = 6
        Me.PcsPerOuter.Name = "PcsPerOuter"
        Me.PcsPerOuter.ReadOnly = True
        '
        'Outer
        '
        Me.Outer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Outer.FillWeight = 41.44385!
        Me.Outer.HeaderText = "No. Of Outer"
        Me.Outer.MinimumWidth = 6
        Me.Outer.Name = "Outer"
        Me.Outer.ReadOnly = True
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
    Friend WithEvents btnRemoveStock As Button
    Friend WithEvents btnAddStock As Button
    Friend WithEvents dgvAvailableStock As DataGridView
    Friend WithEvents availableStockPanel As Panel
    Friend WithEvents ProductName As DataGridViewTextBoxColumn
    Friend WithEvents Mrp As DataGridViewTextBoxColumn
    Friend WithEvents PcsPerOuter As DataGridViewTextBoxColumn
    Friend WithEvents Outer As DataGridViewTextBoxColumn
    Friend WithEvents TotalPcs As DataGridViewTextBoxColumn
End Class
