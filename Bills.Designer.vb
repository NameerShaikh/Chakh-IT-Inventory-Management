<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Bills
    Inherits System.Windows.Forms.Form

    ' Dispose
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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.cmbCustomer = New System.Windows.Forms.ComboBox()
        Me.btnNewCustomer = New System.Windows.Forms.Button()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.dgvBill = New System.Windows.Forms.DataGridView()
        Me.lblTotalItemPrice = New System.Windows.Forms.Label()
        Me.txtTotalItems = New System.Windows.Forms.TextBox()
        Me.lblGrandTotal = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New System.Windows.Forms.TextBox()
        Me.lblPaymentStatus = New System.Windows.Forms.Label()
        Me.cmbPaymentStatus = New System.Windows.Forms.ComboBox()
        Me.lblPaymentMode = New System.Windows.Forms.Label()
        Me.cmbPaymentMode = New System.Windows.Forms.ComboBox()
        Me.lblPartialNow = New System.Windows.Forms.Label()
        Me.txtPartialNow = New System.Windows.Forms.TextBox()
        Me.lblOutstanding = New System.Windows.Forms.Label()
        Me.txtOutstanding = New System.Windows.Forms.TextBox()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.btnSaveBill = New System.Windows.Forms.Button()
        Me.btnPartialEnter = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tlp1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp3 = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp2 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.dgvBill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tlp1.SuspendLayout()
        Me.tlp3.SuspendLayout()
        Me.tlp2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.Location = New System.Drawing.Point(14, 58)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(93, 23)
        Me.lblCustomer.TabIndex = 21
        Me.lblCustomer.Text = "Customer:"
        '
        'cmbCustomer
        '
        Me.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomer.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.Location = New System.Drawing.Point(133, 58)
        Me.cmbCustomer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(220, 31)
        Me.cmbCustomer.TabIndex = 20
        '
        'btnNewCustomer
        '
        Me.btnNewCustomer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNewCustomer.Location = New System.Drawing.Point(381, 55)
        Me.btnNewCustomer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNewCustomer.Name = "btnNewCustomer"
        Me.btnNewCustomer.Size = New System.Drawing.Size(222, 33)
        Me.btnNewCustomer.TabIndex = 19
        Me.btnNewCustomer.Text = "Add New Customer"
        Me.btnNewCustomer.UseVisualStyleBackColor = True
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(949, 59)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(53, 23)
        Me.lblDate.TabIndex = 18
        Me.lblDate.Text = "Date:"
        '
        'txtDate
        '
        Me.txtDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDate.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.Location = New System.Drawing.Point(1021, 56)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(120, 30)
        Me.txtDate.TabIndex = 17
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(1167, 62)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(55, 23)
        Me.lblTime.TabIndex = 16
        Me.lblTime.Text = "Time:"
        '
        'txtTime
        '
        Me.txtTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTime.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTime.Location = New System.Drawing.Point(1233, 55)
        Me.txtTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.ReadOnly = True
        Me.txtTime.Size = New System.Drawing.Size(120, 30)
        Me.txtTime.TabIndex = 15
        '
        'dgvBill
        '
        Me.dgvBill.AllowUserToDeleteRows = False
        Me.dgvBill.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBill.BackgroundColor = System.Drawing.Color.White
        Me.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBill.Location = New System.Drawing.Point(36, 124)
        Me.dgvBill.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvBill.Name = "dgvBill"
        Me.dgvBill.RowHeadersWidth = 51
        Me.dgvBill.Size = New System.Drawing.Size(1361, 437)
        Me.dgvBill.TabIndex = 0
        '
        'lblTotalItemPrice
        '
        Me.lblTotalItemPrice.AutoSize = True
        Me.lblTotalItemPrice.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalItemPrice.Location = New System.Drawing.Point(3, 0)
        Me.lblTotalItemPrice.Name = "lblTotalItemPrice"
        Me.lblTotalItemPrice.Size = New System.Drawing.Size(92, 20)
        Me.lblTotalItemPrice.TabIndex = 14
        Me.lblTotalItemPrice.Text = "Total Items:"
        '
        'txtTotalItems
        '
        Me.txtTotalItems.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalItems.Location = New System.Drawing.Point(186, 2)
        Me.txtTotalItems.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.ReadOnly = True
        Me.txtTotalItems.Size = New System.Drawing.Size(100, 27)
        Me.txtTotalItems.TabIndex = 13
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.AutoSize = True
        Me.lblGrandTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrandTotal.Location = New System.Drawing.Point(3, 0)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(95, 20)
        Me.lblGrandTotal.TabIndex = 12
        Me.lblGrandTotal.Text = "Grand Total:"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGrandTotal.Location = New System.Drawing.Point(107, 2)
        Me.txtGrandTotal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(100, 27)
        Me.txtGrandTotal.TabIndex = 11
        '
        'lblPaymentStatus
        '
        Me.lblPaymentStatus.AutoSize = True
        Me.lblPaymentStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPaymentStatus.Location = New System.Drawing.Point(3, 38)
        Me.lblPaymentStatus.Name = "lblPaymentStatus"
        Me.lblPaymentStatus.Size = New System.Drawing.Size(123, 20)
        Me.lblPaymentStatus.TabIndex = 10
        Me.lblPaymentStatus.Text = "Payment Status:"
        '
        'cmbPaymentStatus
        '
        Me.cmbPaymentStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbPaymentStatus.Location = New System.Drawing.Point(186, 40)
        Me.cmbPaymentStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbPaymentStatus.Name = "cmbPaymentStatus"
        Me.cmbPaymentStatus.Size = New System.Drawing.Size(178, 28)
        Me.cmbPaymentStatus.TabIndex = 9
        '
        'lblPaymentMode
        '
        Me.lblPaymentMode.AutoSize = True
        Me.lblPaymentMode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPaymentMode.Location = New System.Drawing.Point(3, 30)
        Me.lblPaymentMode.Name = "lblPaymentMode"
        Me.lblPaymentMode.Size = New System.Drawing.Size(75, 30)
        Me.lblPaymentMode.TabIndex = 8
        Me.lblPaymentMode.Text = "Payment Mode:"
        '
        'cmbPaymentMode
        '
        Me.cmbPaymentMode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbPaymentMode.Location = New System.Drawing.Point(107, 32)
        Me.cmbPaymentMode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbPaymentMode.Name = "cmbPaymentMode"
        Me.cmbPaymentMode.Size = New System.Drawing.Size(150, 28)
        Me.cmbPaymentMode.TabIndex = 7
        '
        'lblPartialNow
        '
        Me.lblPartialNow.AutoSize = True
        Me.lblPartialNow.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPartialNow.Location = New System.Drawing.Point(3, 0)
        Me.lblPartialNow.Name = "lblPartialNow"
        Me.lblPartialNow.Size = New System.Drawing.Size(92, 20)
        Me.lblPartialNow.TabIndex = 6
        Me.lblPartialNow.Text = "Partial Paid:"
        '
        'txtPartialNow
        '
        Me.txtPartialNow.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPartialNow.Location = New System.Drawing.Point(110, 2)
        Me.txtPartialNow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPartialNow.Name = "txtPartialNow"
        Me.txtPartialNow.Size = New System.Drawing.Size(161, 27)
        Me.txtPartialNow.TabIndex = 5
        '
        'lblOutstanding
        '
        Me.lblOutstanding.AutoSize = True
        Me.lblOutstanding.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOutstanding.Location = New System.Drawing.Point(3, 76)
        Me.lblOutstanding.Name = "lblOutstanding"
        Me.lblOutstanding.Size = New System.Drawing.Size(100, 20)
        Me.lblOutstanding.TabIndex = 4
        Me.lblOutstanding.Text = "Outstanding:"
        '
        'txtOutstanding
        '
        Me.txtOutstanding.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtOutstanding.Location = New System.Drawing.Point(186, 78)
        Me.txtOutstanding.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOutstanding.Name = "txtOutstanding"
        Me.txtOutstanding.ReadOnly = True
        Me.txtOutstanding.Size = New System.Drawing.Size(120, 27)
        Me.txtOutstanding.TabIndex = 3
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblContact.Location = New System.Drawing.Point(3, 60)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(67, 20)
        Me.lblContact.TabIndex = 2
        Me.lblContact.Text = "Contact:"
        '
        'txtContact
        '
        Me.txtContact.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtContact.Location = New System.Drawing.Point(107, 62)
        Me.txtContact.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(200, 27)
        Me.txtContact.TabIndex = 1
        '
        'btnSaveBill
        '
        Me.btnSaveBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveBill.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveBill.Location = New System.Drawing.Point(497, 131)
        Me.btnSaveBill.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSaveBill.Name = "btnSaveBill"
        Me.btnSaveBill.Size = New System.Drawing.Size(419, 44)
        Me.btnSaveBill.TabIndex = 0
        Me.btnSaveBill.Text = "Save & Generate Bill"
        Me.btnSaveBill.UseVisualStyleBackColor = True
        '
        'btnPartialEnter
        '
        Me.btnPartialEnter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPartialEnter.Location = New System.Drawing.Point(890, 55)
        Me.btnPartialEnter.Name = "btnPartialEnter"
        Me.btnPartialEnter.Size = New System.Drawing.Size(260, 27)
        Me.btnPartialEnter.TabIndex = 22
        Me.btnPartialEnter.Text = "Calculate Outstanding Amount"
        Me.btnPartialEnter.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGreen
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.PanelBottom)
        Me.Panel1.Controls.Add(Me.dgvBill)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1436, 767)
        Me.Panel1.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(542, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(311, 29)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Generate Invoice Window"
        '
        'PanelBottom
        '
        Me.PanelBottom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBottom.Controls.Add(Me.tlp2)
        Me.PanelBottom.Controls.Add(Me.tlp3)
        Me.PanelBottom.Controls.Add(Me.btnPartialEnter)
        Me.PanelBottom.Controls.Add(Me.tlp1)
        Me.PanelBottom.Controls.Add(Me.btnSaveBill)
        Me.PanelBottom.Location = New System.Drawing.Point(36, 566)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(1361, 189)
        Me.PanelBottom.TabIndex = 23
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtTime)
        Me.Panel3.Controls.Add(Me.lblTime)
        Me.Panel3.Controls.Add(Me.txtDate)
        Me.Panel3.Controls.Add(Me.lblCustomer)
        Me.Panel3.Controls.Add(Me.lblDate)
        Me.Panel3.Controls.Add(Me.cmbCustomer)
        Me.Panel3.Controls.Add(Me.btnNewCustomer)
        Me.Panel3.Location = New System.Drawing.Point(36, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1361, 116)
        Me.Panel3.TabIndex = 25
        '
        'tlp1
        '
        Me.tlp1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tlp1.ColumnCount = 2
        Me.tlp1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp1.Controls.Add(Me.lblPaymentStatus, 0, 1)
        Me.tlp1.Controls.Add(Me.lblTotalItemPrice, 0, 0)
        Me.tlp1.Controls.Add(Me.cmbPaymentStatus, 1, 1)
        Me.tlp1.Controls.Add(Me.txtTotalItems, 1, 0)
        Me.tlp1.Controls.Add(Me.lblOutstanding, 0, 2)
        Me.tlp1.Controls.Add(Me.txtOutstanding, 1, 2)
        Me.tlp1.Location = New System.Drawing.Point(154, 10)
        Me.tlp1.Name = "tlp1"
        Me.tlp1.RowCount = 3
        Me.tlp1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlp1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlp1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlp1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp1.Size = New System.Drawing.Size(367, 116)
        Me.tlp1.TabIndex = 26
        '
        'tlp3
        '
        Me.tlp3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tlp3.ColumnCount = 2
        Me.tlp3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.55914!))
        Me.tlp3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.44086!))
        Me.tlp3.Controls.Add(Me.lblPartialNow, 0, 0)
        Me.tlp3.Controls.Add(Me.txtPartialNow, 1, 0)
        Me.tlp3.Location = New System.Drawing.Point(879, 14)
        Me.tlp3.Name = "tlp3"
        Me.tlp3.RowCount = 1
        Me.tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp3.Size = New System.Drawing.Size(295, 35)
        Me.tlp3.TabIndex = 26
        '
        'tlp2
        '
        Me.tlp2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tlp2.ColumnCount = 2
        Me.tlp2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.74559!))
        Me.tlp2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.25441!))
        Me.tlp2.Controls.Add(Me.txtGrandTotal, 1, 0)
        Me.tlp2.Controls.Add(Me.cmbPaymentMode, 1, 1)
        Me.tlp2.Controls.Add(Me.txtContact, 1, 2)
        Me.tlp2.Controls.Add(Me.lblGrandTotal, 0, 0)
        Me.tlp2.Controls.Add(Me.lblContact, 0, 2)
        Me.tlp2.Controls.Add(Me.lblPaymentMode, 0, 1)
        Me.tlp2.Location = New System.Drawing.Point(540, 12)
        Me.tlp2.Name = "tlp2"
        Me.tlp2.RowCount = 3
        Me.tlp2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlp2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlp2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlp2.Size = New System.Drawing.Size(320, 90)
        Me.tlp2.TabIndex = 27
        '
        'Bills
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1436, 767)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "Bills"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bills"
        CType(Me.dgvBill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PanelBottom.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tlp1.ResumeLayout(False)
        Me.tlp1.PerformLayout()
        Me.tlp3.ResumeLayout(False)
        Me.tlp3.PerformLayout()
        Me.tlp2.ResumeLayout(False)
        Me.tlp2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblCustomer As Label
    Friend WithEvents cmbCustomer As ComboBox
    Friend WithEvents btnNewCustomer As Button
    Friend WithEvents lblDate As Label
    Friend WithEvents txtDate As TextBox
    Friend WithEvents lblTime As Label
    Friend WithEvents txtTime As TextBox
    Friend WithEvents dgvBill As DataGridView
    Friend WithEvents lblTotalItemPrice As Label
    Friend WithEvents txtTotalItems As TextBox
    Friend WithEvents lblGrandTotal As Label
    Friend WithEvents txtGrandTotal As TextBox
    Friend WithEvents lblPaymentStatus As Label
    Friend WithEvents cmbPaymentStatus As ComboBox
    Friend WithEvents lblPaymentMode As Label
    Friend WithEvents cmbPaymentMode As ComboBox
    Friend WithEvents lblPartialNow As Label
    Friend WithEvents txtPartialNow As TextBox
    Friend WithEvents lblOutstanding As Label
    Friend WithEvents txtOutstanding As TextBox
    Friend WithEvents lblContact As Label
    Friend WithEvents txtContact As TextBox
    Friend WithEvents btnSaveBill As Button
    Friend WithEvents btnPartialEnter As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelBottom As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents tlp1 As TableLayoutPanel
    Friend WithEvents tlp3 As TableLayoutPanel
    Friend WithEvents tlp2 As TableLayoutPanel
End Class
