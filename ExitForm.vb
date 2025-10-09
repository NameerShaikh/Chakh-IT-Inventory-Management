Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class ExitForm
    Private cancelExit As Boolean = False
    Private exitTimer As Timer
    Private fadeTimer As Timer
    Private elapsed As Integer = 0
    Private progress As ProgressBar
    Private lbl As Label
    Private btnCancel As Button

    ' Rounded corners
    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(
        nLeftRect As Integer,
        nTopRect As Integer,
        nRightRect As Integer,
        nBottomRect As Integer,
        nWidthEllipse As Integer,
        nHeightEllipse As Integer
    ) As IntPtr
    End Function

    Private Sub ExitForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ===== Form Setup =====
        Me.Text = "Exiting..."
        Me.Size = New Size(420, 220)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.FromArgb(25, 25, 25)
        Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Me.Width, Me.Height, 25, 25))
        Me.Opacity = 0

        ' ===== Center the form on screen =====
        Me.StartPosition = FormStartPosition.Manual
        Dim screenBounds As Rectangle = Screen.FromPoint(Me.Location).WorkingArea
        Me.Location = New Point(
        screenBounds.Left + (screenBounds.Width - Me.Width) \ 2,
        screenBounds.Top + (screenBounds.Height - Me.Height) \ 2
    )

        ' ===== Gradient Background =====
        AddHandler Me.Paint, Sub(sender2, e2)
                                 Using brush As New Drawing2D.LinearGradientBrush(Me.ClientRectangle,
                                 Color.FromArgb(30, 30, 30),
                                 Color.FromArgb(15, 15, 15),
                                 Drawing2D.LinearGradientMode.Vertical)
                                     e2.Graphics.FillRectangle(brush, Me.ClientRectangle)
                                 End Using
                             End Sub

        ' ===== Title Label =====
        lbl = New Label With {
        .Text = "Preparing to close application...",
        .ForeColor = Color.WhiteSmoke,
        .Font = New Font("Segoe UI", 11, FontStyle.Regular),
        .AutoSize = False,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Dock = DockStyle.Top,
        .Height = 60
    }

        ' ===== Progress Bar =====
        progress = New ProgressBar With {
        .Style = ProgressBarStyle.Continuous,
        .Dock = DockStyle.None,
        .Size = New Size(320, 22),
        .ForeColor = Color.LimeGreen,
        .BackColor = Color.FromArgb(45, 45, 45),
        .Location = New Point((Me.Width - 320) \ 2, 90)
    }

        ' ===== Cancel Button =====
        btnCancel = New Button With {
        .Text = "Abort Exit",
        .FlatStyle = FlatStyle.Flat,
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .BackColor = Color.FromArgb(60, 60, 60),
        .ForeColor = Color.White,
        .Size = New Size(120, 40),
        .Location = New Point((Me.Width - 120) \ 2, 140),
        .Cursor = Cursors.Hand
    }
        btnCancel.FlatAppearance.BorderSize = 0
        AddHandler btnCancel.Click, AddressOf CancelExit_Click

        ' ===== Decorative Glow Bar =====
        Dim glowBar As New Panel With {
        .Dock = DockStyle.Top,
        .Height = 6,
        .BackColor = Color.FromArgb(0, 120, 255)
    }

        ' ===== Add Controls =====
        Me.Controls.Add(btnCancel)
        Me.Controls.Add(progress)
        Me.Controls.Add(lbl)
        Me.Controls.Add(glowBar)

        ' ===== Fade-in effect =====
        fadeTimer = New Timer() With {.Interval = 25}
        AddHandler fadeTimer.Tick, Sub()
                                       If Me.Opacity < 1 Then
                                           Me.Opacity += 0.08
                                       Else
                                           fadeTimer.Stop()
                                       End If
                                   End Sub
        fadeTimer.Start()

        ' ===== Exit countdown =====
        exitTimer = New Timer() With {.Interval = 300}
        AddHandler exitTimer.Tick, AddressOf ExitTimer_Tick
        exitTimer.Start()
    End Sub


    Private Sub ExitTimer_Tick(sender As Object, e As EventArgs)
        elapsed += 300
        progress.Value = Math.Min(100, CInt((elapsed / 3000) * 100))

        Select Case progress.Value
            Case < 30
                lbl.Text = "Saving all data..."
            Case < 70
                lbl.Text = "Closing connections..."
            Case < 100
                lbl.Text = "Cleaning up resources..."
            Case Else
                lbl.Text = "Goodbye! Come back soon..."
        End Select

        If elapsed >= 3000 Then
            exitTimer.Stop()
            If Not cancelExit Then
                Application.Exit()
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Async Sub CancelExit_Click(sender As Object, e As EventArgs)
        cancelExit = True
        lbl.Text = "Exit cancelled. Returning to application..."
        lbl.ForeColor = Color.LightGreen
        progress.Value = 0
        Await Task.Delay(800)
        If Not Me.IsDisposed Then
            Me.Close()
        End If
    End Sub

    ' Allow dragging of borderless form
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle, &HA1, &H2, 0)
        End If
    End Sub

    <DllImport("user32.dll")>
    Public Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.dll")>
    Public Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
End Class
