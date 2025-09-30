<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockOutForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProduct = New System.Windows.Forms.ComboBox()
        Me.txtUnit = New System.Windows.Forms.ComboBox()
        Me.txtPaymentMode = New System.Windows.Forms.ComboBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.txtBatchNo = New System.Windows.Forms.TextBox()
        Me.txtSellingPrice = New System.Windows.Forms.TextBox()
        Me.btnRemoveStock = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(90, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(80, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Time"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(84, 214)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Product"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(91, 296)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Unit"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(69, 363)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Quantity"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(68, 429)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Batch No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(73, 474)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Selling Price"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(70, 538)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Payment Mode"
        '
        'txtProduct
        '
        Me.txtProduct.FormattingEnabled = True
        Me.txtProduct.Location = New System.Drawing.Point(287, 215)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(377, 24)
        Me.txtProduct.TabIndex = 8
        '
        'txtUnit
        '
        Me.txtUnit.FormattingEnabled = True
        Me.txtUnit.Location = New System.Drawing.Point(287, 288)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(377, 24)
        Me.txtUnit.TabIndex = 9
        '
        'txtPaymentMode
        '
        Me.txtPaymentMode.FormattingEnabled = True
        Me.txtPaymentMode.Location = New System.Drawing.Point(309, 535)
        Me.txtPaymentMode.Name = "txtPaymentMode"
        Me.txtPaymentMode.Size = New System.Drawing.Size(377, 24)
        Me.txtPaymentMode.TabIndex = 10
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(292, 57)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(342, 22)
        Me.txtDate.TabIndex = 11
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(296, 117)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(337, 22)
        Me.txtTime.TabIndex = 12
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(302, 368)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(361, 22)
        Me.txtQuantity.TabIndex = 13
        '
        'txtBatchNo
        '
        Me.txtBatchNo.Location = New System.Drawing.Point(297, 414)
        Me.txtBatchNo.Name = "txtBatchNo"
        Me.txtBatchNo.Size = New System.Drawing.Size(365, 22)
        Me.txtBatchNo.TabIndex = 14
        '
        'txtSellingPrice
        '
        Me.txtSellingPrice.Location = New System.Drawing.Point(308, 471)
        Me.txtSellingPrice.Name = "txtSellingPrice"
        Me.txtSellingPrice.Size = New System.Drawing.Size(353, 22)
        Me.txtSellingPrice.TabIndex = 15
        '
        'btnRemoveStock
        '
        Me.btnRemoveStock.Location = New System.Drawing.Point(289, 593)
        Me.btnRemoveStock.Name = "btnRemoveStock"
        Me.btnRemoveStock.Size = New System.Drawing.Size(454, 40)
        Me.btnRemoveStock.TabIndex = 16
        Me.btnRemoveStock.Text = "Remove Stock"
        Me.btnRemoveStock.UseVisualStyleBackColor = True
        '
        'StockOutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1189, 663)
        Me.Controls.Add(Me.btnRemoveStock)
        Me.Controls.Add(Me.txtSellingPrice)
        Me.Controls.Add(Me.txtBatchNo)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtPaymentMode)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.txtProduct)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "StockOutForm"
        Me.Text = "StockOutForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtProduct As ComboBox
    Friend WithEvents txtUnit As ComboBox
    Friend WithEvents txtPaymentMode As ComboBox
    Friend WithEvents txtDate As TextBox
    Friend WithEvents txtTime As TextBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents txtBatchNo As TextBox
    Friend WithEvents txtSellingPrice As TextBox
    Friend WithEvents btnRemoveStock As Button
End Class
