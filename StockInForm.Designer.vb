<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockInForm
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
        Me.txtEntryDate = New System.Windows.Forms.TextBox()
        Me.txtEntryTime = New System.Windows.Forms.TextBox()
        Me.txtProduct = New System.Windows.Forms.ComboBox()
        Me.numQuantity = New System.Windows.Forms.TextBox()
        Me.txtBatchNo = New System.Windows.Forms.TextBox()
        Me.txtPurchasePrice = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtPaymentMode = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtEntryDate
        '
        Me.txtEntryDate.Location = New System.Drawing.Point(515, 89)
        Me.txtEntryDate.Name = "txtEntryDate"
        Me.txtEntryDate.Size = New System.Drawing.Size(366, 22)
        Me.txtEntryDate.TabIndex = 0
        '
        'txtEntryTime
        '
        Me.txtEntryTime.Location = New System.Drawing.Point(524, 157)
        Me.txtEntryTime.Name = "txtEntryTime"
        Me.txtEntryTime.Size = New System.Drawing.Size(356, 22)
        Me.txtEntryTime.TabIndex = 1
        '
        'txtProduct
        '
        Me.txtProduct.FormattingEnabled = True
        Me.txtProduct.Location = New System.Drawing.Point(527, 248)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(352, 24)
        Me.txtProduct.TabIndex = 2
        '
        'numQuantity
        '
        Me.numQuantity.Location = New System.Drawing.Point(527, 392)
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(386, 22)
        Me.numQuantity.TabIndex = 3
        '
        'txtBatchNo
        '
        Me.txtBatchNo.Location = New System.Drawing.Point(516, 434)
        Me.txtBatchNo.Name = "txtBatchNo"
        Me.txtBatchNo.Size = New System.Drawing.Size(419, 22)
        Me.txtBatchNo.TabIndex = 4
        '
        'txtPurchasePrice
        '
        Me.txtPurchasePrice.Location = New System.Drawing.Point(537, 476)
        Me.txtPurchasePrice.Name = "txtPurchasePrice"
        Me.txtPurchasePrice.Size = New System.Drawing.Size(423, 22)
        Me.txtPurchasePrice.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(174, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Entry Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(186, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Entry Time"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(186, 251)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Product"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(188, 392)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Quantity"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(214, 437)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Batch No."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(199, 482)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Purchase Price"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(400, 590)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(358, 39)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Add Stock"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtPaymentMode
        '
        Me.txtPaymentMode.FormattingEnabled = True
        Me.txtPaymentMode.Location = New System.Drawing.Point(441, 518)
        Me.txtPaymentMode.Name = "txtPaymentMode"
        Me.txtPaymentMode.Size = New System.Drawing.Size(493, 24)
        Me.txtPaymentMode.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(198, 512)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Payment Mode"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(184, 320)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Unit"
        '
        'txtUnit
        '
        Me.txtUnit.FormattingEnabled = True
        Me.txtUnit.Location = New System.Drawing.Point(538, 313)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(360, 24)
        Me.txtUnit.TabIndex = 16
        '
        'StockInForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1171, 673)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPaymentMode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtBatchNo)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtEntryDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEntryTime)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtProduct)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numQuantity)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPurchasePrice)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "StockInForm"
        Me.Text = "StockInForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtEntryDate As TextBox
    Friend WithEvents txtEntryTime As TextBox
    Friend WithEvents txtProduct As ComboBox
    Friend WithEvents numQuantity As TextBox
    Friend WithEvents txtBatchNo As TextBox
    Friend WithEvents txtPurchasePrice As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents txtPaymentMode As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtUnit As ComboBox
End Class
