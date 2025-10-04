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
        Me.dgvAvailableStock = New System.Windows.Forms.DataGridView()
        Me.btnRemoveStock = New System.Windows.Forms.Button()
        Me.btnAddStock = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mrp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PcsPerOuter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Outer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.masterOuters = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalPcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.availableStockPanel.SuspendLayout()
        CType(Me.dgvAvailableStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'availableStockPanel
        '
        Me.availableStockPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.availableStockPanel.Controls.Add(Me.dgvAvailableStock)
        Me.availableStockPanel.Location = New System.Drawing.Point(3, 1)
        Me.availableStockPanel.Name = "availableStockPanel"
        Me.availableStockPanel.Size = New System.Drawing.Size(1212, 609)
        Me.availableStockPanel.TabIndex = 0
        '
        'dgvAvailableStock
        '
        Me.dgvAvailableStock.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAvailableStock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAvailableStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAvailableStock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductName, Me.Mrp, Me.PcsPerOuter, Me.Outer, Me.masterOuters, Me.TotalPcs})
        Me.dgvAvailableStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAvailableStock.Location = New System.Drawing.Point(0, 0)
        Me.dgvAvailableStock.Name = "dgvAvailableStock"
        Me.dgvAvailableStock.RowHeadersWidth = 51
        Me.dgvAvailableStock.RowTemplate.Height = 24
        Me.dgvAvailableStock.Size = New System.Drawing.Size(1212, 609)
        Me.dgvAvailableStock.TabIndex = 1
        '
        'btnRemoveStock
        '
        Me.btnRemoveStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveStock.Location = New System.Drawing.Point(392, 6)
        Me.btnRemoveStock.Name = "btnRemoveStock"
        Me.btnRemoveStock.Size = New System.Drawing.Size(367, 36)
        Me.btnRemoveStock.TabIndex = 3
        Me.btnRemoveStock.Text = "Remove Stock"
        Me.btnRemoveStock.UseVisualStyleBackColor = True
        '
        'btnAddStock
        '
        Me.btnAddStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddStock.Location = New System.Drawing.Point(3, 6)
        Me.btnAddStock.Name = "btnAddStock"
        Me.btnAddStock.Size = New System.Drawing.Size(367, 36)
        Me.btnAddStock.TabIndex = 2
        Me.btnAddStock.Text = "Add Stock"
        Me.btnAddStock.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnRemoveStock, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddStock, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(252, 619)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(762, 45)
        Me.TableLayoutPanel1.TabIndex = 4
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
        Me.Outer.HeaderText = "No. Of Outers"
        Me.Outer.MinimumWidth = 6
        Me.Outer.Name = "Outer"
        Me.Outer.ReadOnly = True
        '
        'masterOuters
        '
        Me.masterOuters.HeaderText = "No. Of Master Outers"
        Me.masterOuters.MinimumWidth = 6
        Me.masterOuters.Name = "masterOuters"
        Me.masterOuters.ReadOnly = True
        Me.masterOuters.Width = 125
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
        'AvailableStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1219, 676)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.availableStockPanel)
        Me.Name = "AvailableStock"
        Me.Text = "Available Stock"
        Me.availableStockPanel.ResumeLayout(False)
        CType(Me.dgvAvailableStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRemoveStock As Button
    Friend WithEvents btnAddStock As Button
    Friend WithEvents dgvAvailableStock As DataGridView
    Friend WithEvents availableStockPanel As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ProductName As DataGridViewTextBoxColumn
    Friend WithEvents Mrp As DataGridViewTextBoxColumn
    Friend WithEvents PcsPerOuter As DataGridViewTextBoxColumn
    Friend WithEvents Outer As DataGridViewTextBoxColumn
    Friend WithEvents masterOuters As DataGridViewTextBoxColumn
    Friend WithEvents TotalPcs As DataGridViewTextBoxColumn
End Class
