Partial Class ProductDialog
    Inherits Form

    Public Property ProductName As String
    Public Property MRP As String
    Public Property Pcs As String
    Public Property Outers As String

    Public Sub New()
        InitializeComponent()
        AddHandler btnOK.Click, AddressOf btnOK_Click
        AddHandler btnCancel.Click, AddressOf btnCancel_Click
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs)
        ' Validation
        If String.IsNullOrWhiteSpace(txtName.Text) OrElse
           String.IsNullOrWhiteSpace(txtMRP.Text) OrElse
           String.IsNullOrWhiteSpace(txtPcs.Text) OrElse
           String.IsNullOrWhiteSpace(txtOuters.Text) Then
            MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not Decimal.TryParse(txtMRP.Text, Nothing) Then
            MessageBox.Show("MRP must be a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not Integer.TryParse(txtPcs.Text, Nothing) OrElse Not Integer.TryParse(txtOuters.Text, Nothing) Then
            MessageBox.Show("Pieces and Outers must be integers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Assign values
        ProductName = txtName.Text.Trim()
        MRP = txtMRP.Text.Trim()
        Pcs = txtPcs.Text.Trim()
        Outers = txtOuters.Text.Trim()

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ProductDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
