<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Reports
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
        Me.reportsPanel = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExportPDF = New System.Windows.Forms.Button()
        Me.btnVisuals = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.FilterPanel = New System.Windows.Forms.Panel()
        Me.cmbReportType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClearFilters = New System.Windows.Forms.Button()
        Me.cmbFilterList = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGenerateReport = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.chkThisMonth = New System.Windows.Forms.CheckBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.reportsPanel.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FilterPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'reportsPanel
        '
        Me.reportsPanel.Controls.Add(Me.TableLayoutPanel1)
        Me.reportsPanel.Controls.Add(Me.dgvReport)
        Me.reportsPanel.Controls.Add(Me.FilterPanel)
        Me.reportsPanel.Controls.Add(Me.Label1)
        Me.reportsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reportsPanel.Location = New System.Drawing.Point(0, 0)
        Me.reportsPanel.Name = "reportsPanel"
        Me.reportsPanel.Size = New System.Drawing.Size(1172, 632)
        Me.reportsPanel.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnExportPDF, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnVisuals, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 569)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(674, 47)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'btnExportPDF
        '
        Me.btnExportPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportPDF.Location = New System.Drawing.Point(3, 3)
        Me.btnExportPDF.Name = "btnExportPDF"
        Me.btnExportPDF.Size = New System.Drawing.Size(310, 39)
        Me.btnExportPDF.TabIndex = 3
        Me.btnExportPDF.Text = "Export PDF"
        Me.btnExportPDF.UseVisualStyleBackColor = True
        '
        'btnVisuals
        '
        Me.btnVisuals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVisuals.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisuals.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVisuals.Location = New System.Drawing.Point(361, 3)
        Me.btnVisuals.Name = "btnVisuals"
        Me.btnVisuals.Size = New System.Drawing.Size(310, 39)
        Me.btnVisuals.TabIndex = 4
        Me.btnVisuals.Text = "Visuals"
        Me.btnVisuals.UseVisualStyleBackColor = True
        '
        'dgvReport
        '
        Me.dgvReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReport.BackgroundColor = System.Drawing.Color.Snow
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(13, 139)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.RowHeadersWidth = 51
        Me.dgvReport.RowTemplate.Height = 24
        Me.dgvReport.Size = New System.Drawing.Size(1147, 414)
        Me.dgvReport.TabIndex = 2
        '
        'FilterPanel
        '
        Me.FilterPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilterPanel.Controls.Add(Me.cmbReportType)
        Me.FilterPanel.Controls.Add(Me.Label4)
        Me.FilterPanel.Controls.Add(Me.btnClearFilters)
        Me.FilterPanel.Controls.Add(Me.cmbFilterList)
        Me.FilterPanel.Controls.Add(Me.Label5)
        Me.FilterPanel.Controls.Add(Me.Label3)
        Me.FilterPanel.Controls.Add(Me.btnGenerateReport)
        Me.FilterPanel.Controls.Add(Me.Label2)
        Me.FilterPanel.Controls.Add(Me.dtpFrom)
        Me.FilterPanel.Controls.Add(Me.chkThisMonth)
        Me.FilterPanel.Controls.Add(Me.dtpTo)
        Me.FilterPanel.Location = New System.Drawing.Point(13, 12)
        Me.FilterPanel.Name = "FilterPanel"
        Me.FilterPanel.Size = New System.Drawing.Size(1147, 121)
        Me.FilterPanel.TabIndex = 1
        '
        'cmbReportType
        '
        Me.cmbReportType.FormattingEnabled = True
        Me.cmbReportType.Items.AddRange(New Object() {"Stock In Report", "Stock Out Report", "Raw Materials In Report", "Raw Materials Out Report", "Finished Goods Report"})
        Me.cmbReportType.Location = New System.Drawing.Point(584, 22)
        Me.cmbReportType.Name = "cmbReportType"
        Me.cmbReportType.Size = New System.Drawing.Size(282, 24)
        Me.cmbReportType.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(451, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Report Type"
        '
        'btnClearFilters
        '
        Me.btnClearFilters.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearFilters.Location = New System.Drawing.Point(876, 76)
        Me.btnClearFilters.Name = "btnClearFilters"
        Me.btnClearFilters.Size = New System.Drawing.Size(249, 38)
        Me.btnClearFilters.TabIndex = 4
        Me.btnClearFilters.Text = "Clear Filters"
        Me.btnClearFilters.UseVisualStyleBackColor = True
        '
        'cmbFilterList
        '
        Me.cmbFilterList.FormattingEnabled = True
        Me.cmbFilterList.Location = New System.Drawing.Point(946, 24)
        Me.cmbFilterList.Name = "cmbFilterList"
        Me.cmbFilterList.Size = New System.Drawing.Size(249, 24)
        Me.cmbFilterList.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(872, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 20)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Select:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "To Date :"
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateReport.Location = New System.Drawing.Point(502, 71)
        Me.btnGenerateReport.Name = "btnGenerateReport"
        Me.btnGenerateReport.Size = New System.Drawing.Size(291, 43)
        Me.btnGenerateReport.TabIndex = 2
        Me.btnGenerateReport.Text = "Generate Report"
        Me.btnGenerateReport.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "From Date :"
        '
        'dtpFrom
        '
        Me.dtpFrom.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(210, 47)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(186, 22)
        Me.dtpFrom.TabIndex = 2
        '
        'chkThisMonth
        '
        Me.chkThisMonth.AutoSize = True
        Me.chkThisMonth.Location = New System.Drawing.Point(103, 20)
        Me.chkThisMonth.Name = "chkThisMonth"
        Me.chkThisMonth.Size = New System.Drawing.Size(94, 20)
        Me.chkThisMonth.TabIndex = 2
        Me.chkThisMonth.Text = "This Month"
        Me.chkThisMonth.UseVisualStyleBackColor = True
        '
        'dtpTo
        '
        Me.dtpTo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(210, 87)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(186, 22)
        Me.dtpTo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1040, 579)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reports"
        '
        'Reports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1172, 632)
        Me.Controls.Add(Me.reportsPanel)
        Me.Name = "Reports"
        Me.Text = "Reports"
        Me.reportsPanel.ResumeLayout(False)
        Me.reportsPanel.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FilterPanel.ResumeLayout(False)
        Me.FilterPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Public WithEvents reportsPanel As Panel
    Friend WithEvents FilterPanel As Panel
    Friend WithEvents cmbReportType As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkThisMonth As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents cmbFilterList As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents btnClearFilters As Button
    Friend WithEvents btnExportPDF As Button
    Friend WithEvents btnVisuals As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dtpTo As DateTimePicker
End Class
