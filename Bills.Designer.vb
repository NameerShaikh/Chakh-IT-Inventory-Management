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
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.dgvBill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCustomer.Location = New System.Drawing.Point(51, 73)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(82, 20)
        Me.lblCustomer.TabIndex = 21
        Me.lblCustomer.Text = "Customer:"
        '
        'cmbCustomer
        '
        Me.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCustomer.Location = New System.Drawing.Point(160, 70)
        Me.cmbCustomer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(220, 28)
        Me.cmbCustomer.TabIndex = 20
        '
        'btnNewCustomer
        '
        Me.btnNewCustomer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNewCustomer.Location = New System.Drawing.Point(406, 64)
        Me.btnNewCustomer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNewCustomer.Name = "btnNewCustomer"
        Me.btnNewCustomer.Size = New System.Drawing.Size(140, 33)
        Me.btnNewCustomer.TabIndex = 19
        Me.btnNewCustomer.Text = "Add New"
        Me.btnNewCustomer.UseVisualStyleBackColor = True
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDate.Location = New System.Drawing.Point(793, 70)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(46, 20)
        Me.lblDate.TabIndex = 18
        Me.lblDate.Text = "Date:"
        '
        'txtDate
        '
        Me.txtDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDate.Location = New System.Drawing.Point(843, 68)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(120, 27)
        Me.txtDate.TabIndex = 17
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTime.Location = New System.Drawing.Point(983, 70)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(48, 20)
        Me.lblTime.TabIndex = 16
        Me.lblTime.Text = "Time:"
        '
        'txtTime
        '
        Me.txtTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTime.Location = New System.Drawing.Point(1033, 68)
        Me.txtTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.ReadOnly = True
        Me.txtTime.Size = New System.Drawing.Size(120, 27)
        Me.txtTime.TabIndex = 15
        '
        'dgvBill
        '
        Me.dgvBill.AllowUserToDeleteRows = False
        Me.dgvBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBill.BackgroundColor = System.Drawing.Color.White
        Me.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBill.Location = New System.Drawing.Point(36, 124)
        Me.dgvBill.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvBill.Name = "dgvBill"
        Me.dgvBill.RowHeadersWidth = 51
        Me.dgvBill.Size = New System.Drawing.Size(1122, 304)
        Me.dgvBill.TabIndex = 0
        '
        'lblTotalItemPrice
        '
        Me.lblTotalItemPrice.AutoSize = True
        Me.lblTotalItemPrice.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalItemPrice.Location = New System.Drawing.Point(15, 18)
        Me.lblTotalItemPrice.Name = "lblTotalItemPrice"
        Me.lblTotalItemPrice.Size = New System.Drawing.Size(92, 20)
        Me.lblTotalItemPrice.TabIndex = 14
        Me.lblTotalItemPrice.Text = "Total Items:"
        '
        'txtTotalItems
        '
        Me.txtTotalItems.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalItems.Location = New System.Drawing.Point(124, 18)
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
        Me.lblGrandTotal.Location = New System.Drawing.Point(351, 18)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(95, 20)
        Me.lblGrandTotal.TabIndex = 12
        Me.lblGrandTotal.Text = "Grand Total:"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGrandTotal.Location = New System.Drawing.Point(464, 15)
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
        Me.lblPaymentStatus.Location = New System.Drawing.Point(15, 50)
        Me.lblPaymentStatus.Name = "lblPaymentStatus"
        Me.lblPaymentStatus.Size = New System.Drawing.Size(123, 20)
        Me.lblPaymentStatus.TabIndex = 10
        Me.lblPaymentStatus.Text = "Payment Status:"
        '
        'cmbPaymentStatus
        '
        Me.cmbPaymentStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbPaymentStatus.Location = New System.Drawing.Point(141, 48)
        Me.cmbPaymentStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbPaymentStatus.Name = "cmbPaymentStatus"
        Me.cmbPaymentStatus.Size = New System.Drawing.Size(180, 28)
        Me.cmbPaymentStatus.TabIndex = 9
        '
        'lblPaymentMode
        '
        Me.lblPaymentMode.AutoSize = True
        Me.lblPaymentMode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPaymentMode.Location = New System.Drawing.Point(351, 50)
        Me.lblPaymentMode.Name = "lblPaymentMode"
        Me.lblPaymentMode.Size = New System.Drawing.Size(119, 20)
        Me.lblPaymentMode.TabIndex = 8
        Me.lblPaymentMode.Text = "Payment Mode:"
        '
        'cmbPaymentMode
        '
        Me.cmbPaymentMode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbPaymentMode.Location = New System.Drawing.Point(481, 48)
        Me.cmbPaymentMode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbPaymentMode.Name = "cmbPaymentMode"
        Me.cmbPaymentMode.Size = New System.Drawing.Size(150, 28)
        Me.cmbPaymentMode.TabIndex = 7
        '
        'lblPartialNow
        '
        Me.lblPartialNow.AutoSize = True
        Me.lblPartialNow.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPartialNow.Location = New System.Drawing.Point(661, 50)
        Me.lblPartialNow.Name = "lblPartialNow"
        Me.lblPartialNow.Size = New System.Drawing.Size(92, 20)
        Me.lblPartialNow.TabIndex = 6
        Me.lblPartialNow.Text = "Partial Paid:"
        '
        'txtPartialNow
        '
        Me.txtPartialNow.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPartialNow.Location = New System.Drawing.Point(759, 47)
        Me.txtPartialNow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPartialNow.Name = "txtPartialNow"
        Me.txtPartialNow.Size = New System.Drawing.Size(120, 27)
        Me.txtPartialNow.TabIndex = 5
        '
        'lblOutstanding
        '
        Me.lblOutstanding.AutoSize = True
        Me.lblOutstanding.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOutstanding.Location = New System.Drawing.Point(15, 82)
        Me.lblOutstanding.Name = "lblOutstanding"
        Me.lblOutstanding.Size = New System.Drawing.Size(100, 20)
        Me.lblOutstanding.TabIndex = 4
        Me.lblOutstanding.Text = "Outstanding:"
        '
        'txtOutstanding
        '
        Me.txtOutstanding.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtOutstanding.Location = New System.Drawing.Point(141, 80)
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
        Me.lblContact.Location = New System.Drawing.Point(351, 93)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(67, 20)
        Me.lblContact.TabIndex = 2
        Me.lblContact.Text = "Contact:"
        '
        'txtContact
        '
        Me.txtContact.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtContact.Location = New System.Drawing.Point(431, 86)
        Me.txtContact.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(200, 27)
        Me.txtContact.TabIndex = 1
        '
        'btnSaveBill
        '
        Me.btnSaveBill.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveBill.Location = New System.Drawing.Point(401, 127)
        Me.btnSaveBill.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSaveBill.Name = "btnSaveBill"
        Me.btnSaveBill.Size = New System.Drawing.Size(252, 28)
        Me.btnSaveBill.TabIndex = 0
        Me.btnSaveBill.Text = "Save & Generate"
        Me.btnSaveBill.UseVisualStyleBackColor = True
        '
        'btnPartialEnter
        '
        Me.btnPartialEnter.Location = New System.Drawing.Point(665, 82)
        Me.btnPartialEnter.Name = "btnPartialEnter"
        Me.btnPartialEnter.Size = New System.Drawing.Size(214, 37)
        Me.btnPartialEnter.TabIndex = 22
        Me.btnPartialEnter.Text = "Calculate Outstanding Amount"
        Me.btnPartialEnter.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgvBill)
        Me.Panel1.Controls.Add(Me.lblCustomer)
        Me.Panel1.Controls.Add(Me.cmbCustomer)
        Me.Panel1.Controls.Add(Me.btnNewCustomer)
        Me.Panel1.Controls.Add(Me.lblDate)
        Me.Panel1.Controls.Add(Me.txtDate)
        Me.Panel1.Controls.Add(Me.lblTime)
        Me.Panel1.Controls.Add(Me.txtTime)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1197, 634)
        Me.Panel1.TabIndex = 23
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblTotalItemPrice)
        Me.Panel2.Controls.Add(Me.lblPaymentStatus)
        Me.Panel2.Controls.Add(Me.btnPartialEnter)
        Me.Panel2.Controls.Add(Me.txtGrandTotal)
        Me.Panel2.Controls.Add(Me.cmbPaymentStatus)
        Me.Panel2.Controls.Add(Me.btnSaveBill)
        Me.Panel2.Controls.Add(Me.lblGrandTotal)
        Me.Panel2.Controls.Add(Me.lblPaymentMode)
        Me.Panel2.Controls.Add(Me.txtContact)
        Me.Panel2.Controls.Add(Me.txtTotalItems)
        Me.Panel2.Controls.Add(Me.cmbPaymentMode)
        Me.Panel2.Controls.Add(Me.lblContact)
        Me.Panel2.Controls.Add(Me.lblPartialNow)
        Me.Panel2.Controls.Add(Me.txtPartialNow)
        Me.Panel2.Controls.Add(Me.txtOutstanding)
        Me.Panel2.Controls.Add(Me.lblOutstanding)
        Me.Panel2.Location = New System.Drawing.Point(36, 452)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1122, 170)
        Me.Panel2.TabIndex = 23
        '
        'Bills
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1197, 634)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Bills"
        Me.Text = "Bills"
        CType(Me.dgvBill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
    Friend WithEvents Panel2 As Panel
End Class
