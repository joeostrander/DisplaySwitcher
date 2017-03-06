<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxCode1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxCode2 = New System.Windows.Forms.TextBox()
        Me.ButtonInput1 = New System.Windows.Forms.Button()
        Me.ButtonInput2 = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RunAtStartupToolStripMenuItemTRAY = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(239, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VCP Code #1 - auto sent when keyboard present"
        '
        'TextBoxCode1
        '
        Me.TextBoxCode1.Location = New System.Drawing.Point(12, 25)
        Me.TextBoxCode1.Name = "TextBoxCode1"
        Me.TextBoxCode1.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxCode1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(257, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "VCP Code #2 - auto sent when keyboard not present"
        '
        'TextBoxCode2
        '
        Me.TextBoxCode2.Location = New System.Drawing.Point(12, 70)
        Me.TextBoxCode2.Name = "TextBoxCode2"
        Me.TextBoxCode2.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxCode2.TabIndex = 4
        '
        'ButtonInput1
        '
        Me.ButtonInput1.Location = New System.Drawing.Point(121, 23)
        Me.ButtonInput1.Name = "ButtonInput1"
        Me.ButtonInput1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonInput1.TabIndex = 2
        Me.ButtonInput1.Text = "Input #&1"
        Me.ButtonInput1.UseVisualStyleBackColor = True
        '
        'ButtonInput2
        '
        Me.ButtonInput2.Location = New System.Drawing.Point(121, 68)
        Me.ButtonInput2.Name = "ButtonInput2"
        Me.ButtonInput2.Size = New System.Drawing.Size(75, 23)
        Me.ButtonInput2.TabIndex = 5
        Me.ButtonInput2.Text = "Input #&2"
        Me.ButtonInput2.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(15, 107)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(107, 23)
        Me.ButtonSave.TabIndex = 6
        Me.ButtonSave.Text = "&Save Settings"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunAtStartupToolStripMenuItemTRAY, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.ShowCheckMargin = True
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(152, 48)
        '
        'RunAtStartupToolStripMenuItemTRAY
        '
        Me.RunAtStartupToolStripMenuItemTRAY.CheckOnClick = True
        Me.RunAtStartupToolStripMenuItemTRAY.Name = "RunAtStartupToolStripMenuItemTRAY"
        Me.RunAtStartupToolStripMenuItemTRAY.Size = New System.Drawing.Size(151, 22)
        Me.RunAtStartupToolStripMenuItemTRAY.Text = "&Run At Startup"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 148)
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.ButtonInput2)
        Me.Controls.Add(Me.ButtonInput1)
        Me.Controls.Add(Me.TextBoxCode2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxCode1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCode1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCode2 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonInput1 As System.Windows.Forms.Button
    Friend WithEvents ButtonInput2 As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RunAtStartupToolStripMenuItemTRAY As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
