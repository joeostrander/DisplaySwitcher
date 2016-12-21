Imports Microsoft.Win32
Imports System.Management

Public Class Form1

    'Public boolTrayExit As Boolean = False
    Private boolStartup As Boolean = False

    Private intCode1 As Integer
    Private intCode2 As Integer

    Private boolWait As Boolean = False
    Private dtWaitStart As DateTime
    Private intWaitSeconds As Integer = 10
    Private intLastKeyboardCount As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NotifyIcon1.Text = Application.ProductName
        intLastKeyboardCount = GetKeyboardCount()
        LoadRegistrySettings()
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Text = Application.ProductName

        If Me.WindowState = FormWindowState.Minimized Then Me.Hide()

    End Sub

    Private Sub Form1_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        Else
            ShowMe()
        End If
    End Sub


    'Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    If boolTrayExit = False Then
    '        If MsgBox("Are you sure you want to exit?" & vbCrLf & vbCrLf & "(Click No to minimize to the Notification area)", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Exit " & Application.ProductName & "?") <> MsgBoxResult.Yes Then
    '            e.Cancel = True
    '            Me.WindowState = FormWindowState.Minimized
    '            Exit Sub
    '        End If
    '    End If
    'End Sub

    Private Sub LoadRegistrySettings()
        On Error Resume Next

        Dim regKey_RUN As RegistryKey
        regKey_RUN = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

        Dim appRegKey As RegistryKey
        appRegKey = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, True)

        If IsNothing(appRegKey) Then
            'Create the key
            Registry.CurrentUser.CreateSubKey("Software\" & Application.ProductName)
            appRegKey = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, True)
            If IsNothing(appRegKey) Then
                regKey_RUN.Close()
                Exit Sub
            End If

            'Ask user if they want it to launch auto...
            If MsgBox("Launch " & Application.ProductName & " at Startup?", _
                            MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
                            Application.ProductName) = MsgBoxResult.Yes Then
                boolStartup = True
            Else
                boolStartup = False
            End If

        Else
            'Load current Startup Value and set it in the interface
            boolStartup = appRegKey.GetValue("RunAtStartup", False)

            intCode1 = appRegKey.GetValue("Code1", 15)
            intCode2 = appRegKey.GetValue("Code2", 17)

            TextBoxCode1.Text = intCode1
            TextBoxCode2.Text = intCode2

        End If

        regKey_RUN.Close()
        appRegKey.Close()

        SaveRegistrySettings()

    End Sub

    Private Sub SaveRegistrySettings()
        On Error Resume Next

        Dim regKey_RUN As RegistryKey
        regKey_RUN = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

        Dim appRegKey As RegistryKey
        appRegKey = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, True)

        'Startup 
        appRegKey.SetValue("RunAtStartup", boolStartup, RegistryValueKind.DWord)

        'If boolStartup=true, add executable path to the Run registry key
        If boolStartup = True Then
            regKey_RUN.SetValue(Application.ProductName, Application.ExecutablePath)
        Else
            regKey_RUN.DeleteValue(Application.ProductName)
        End If

        If intCode1 = 0 Then intCode1 = 15
        If intCode2 = 0 Then intCode2 = 17

        If TextBoxCode1.Text <> intCode1 Then TextBoxCode1.Text = intCode1
        If TextBoxCode2.Text <> intCode2 Then TextBoxCode2.Text = intCode2

        'Save the Codes
        appRegKey.SetValue("Code1", intCode1, RegistryValueKind.DWord)
        appRegKey.SetValue("Code2", intCode2, RegistryValueKind.DWord)


        RunAtStartupToolStripMenuItemTRAY.Checked = boolStartup


        regKey_RUN.Close()
        appRegKey.Close()

    End Sub


    Private Sub SetDisplay(ByVal DisplayNum As Integer)

        Dim dp As New DisplayControl.DisplayControl


        Dim monitors As DisplayControl.NativeStructures.PHYSICAL_MONITOR() = dp.getMonitors()
        Dim mainMonitor As IntPtr = monitors(0).hPhysicalMonitor

        ' 0x60 = Set Input

        Dim success = DisplayControl.NativeMethods.SetVCPFeature(mainMonitor, &H60, DisplayNum)

        dp.cleanupMonitors(CUInt(monitors.Length), monitors)
    End Sub

    Private Sub RunAtStartupToolStripMenuItemTRAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunAtStartupToolStripMenuItemTRAY.Click
        boolStartup = RunAtStartupToolStripMenuItemTRAY.Checked
        SaveRegistrySettings()
    End Sub

    Private Sub ShowMe()
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        If Me.Location.X < 0 Or Me.Location.Y < 0 Then Me.CenterToScreen()

    End Sub

    Private Sub NotifyIcon1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        If e.Button = MouseButtons.Right Then
            'NotifyIcon1.ContextMenu = ContextMenuIcon
        End If
        If e.Button = MouseButtons.Left Then
            ShowMe()
        End If

    End Sub


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'boolTrayExit = True
        Application.Exit()
    End Sub

    Private Sub ButtonInput1_Click(sender As Object, e As EventArgs) Handles ButtonInput1.Click
        Dim myNum As Integer = 0
        Integer.TryParse(TextBoxCode1.Text, myNum)
        If myNum <> 0 Then SetDisplay(myNum)
    End Sub

    Private Sub ButtonInput2_Click(sender As Object, e As EventArgs) Handles ButtonInput2.Click
        Dim myNum As Integer = 0
        Integer.TryParse(TextBoxCode2.Text, myNum)
        If myNum <> 0 Then SetDisplay(myNum)
    End Sub

    Private Function GetKeyboardCount() As Integer
        Dim count As Integer
        Dim strQuery As String = "Select * from Win32_Keyboard"

        Try

            Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher(strQuery)

            Dim collection As ManagementObjectCollection = searcher.Get
            count = collection.Count
        Catch ex As Exception
            count = -1
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        Return count
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If boolWait Then
            Dim elapsedTime As TimeSpan
            elapsedTime = Now.Subtract(dtWaitStart)
            If elapsedTime.TotalSeconds < intWaitSeconds Then
                Exit Sub
            Else
                boolWait = False
            End If
        End If

        Dim intKeyboards As Integer = GetKeyboardCount()
        If intKeyboards <> intLastKeyboardCount Then
            If intKeyboards = 0 Then
                'no keyboards... switch to #2
                boolWait = True
                dtWaitStart = Now
                SetDisplay(intCode2)
            ElseIf intKeyboards = 2 Then    'mouse is a "keyboard" too
                'keyboard present, switch to PC
                boolWait = True
                dtWaitStart = Now
                SetDisplay(intCode1)
            End If
            intLastKeyboardCount = intKeyboards
        End If
        
    End Sub

    Private Sub TextBoxCode1_LostFocus(sender As Object, e As EventArgs) Handles TextBoxCode1.LostFocus
        If Integer.TryParse(TextBoxCode1.Text, intCode1) = False Then
            MsgBox("Invalid code!", vbExclamation)
            TextBoxCode1.Focus()
            TextBoxCode1.SelectAll()
        End If
    End Sub

    Private Sub TextBoxCode2_LostFocus(sender As Object, e As EventArgs) Handles TextBoxCode2.LostFocus
        If Integer.TryParse(TextBoxCode2.Text, intCode2) = False Then
            MsgBox("Invalid code!", vbExclamation)
            TextBoxCode2.Focus()
            TextBoxCode2.SelectAll()
        End If
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        SaveRegistrySettings()
        MsgBox("Settings saved.", MsgBoxStyle.Information)
    End Sub
End Class
