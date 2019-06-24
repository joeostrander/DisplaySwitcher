namespace DisplaySwitcherCSharp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonInput2 = new System.Windows.Forms.Button();
            this.ButtonInput1 = new System.Windows.Forms.Button();
            this.TextBoxCode2 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TextBoxCode1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RunAtStartupToolStripMenuItemTRAY = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.LabelKeyboardCount = new System.Windows.Forms.Label();
            this.ContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(12, 107);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(107, 23);
            this.ButtonSave.TabIndex = 14;
            this.ButtonSave.Text = "&Save Settings";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonInput2
            // 
            this.ButtonInput2.Location = new System.Drawing.Point(121, 68);
            this.ButtonInput2.Name = "ButtonInput2";
            this.ButtonInput2.Size = new System.Drawing.Size(75, 23);
            this.ButtonInput2.TabIndex = 13;
            this.ButtonInput2.Text = "Input #&2";
            this.ButtonInput2.UseVisualStyleBackColor = true;
            this.ButtonInput2.Click += new System.EventHandler(this.ButtonInput2_Click);
            // 
            // ButtonInput1
            // 
            this.ButtonInput1.Location = new System.Drawing.Point(121, 23);
            this.ButtonInput1.Name = "ButtonInput1";
            this.ButtonInput1.Size = new System.Drawing.Size(75, 23);
            this.ButtonInput1.TabIndex = 10;
            this.ButtonInput1.Text = "Input #&1";
            this.ButtonInput1.UseVisualStyleBackColor = true;
            this.ButtonInput1.Click += new System.EventHandler(this.ButtonInput1_Click);
            // 
            // TextBoxCode2
            // 
            this.TextBoxCode2.Location = new System.Drawing.Point(12, 70);
            this.TextBoxCode2.Name = "TextBoxCode2";
            this.TextBoxCode2.Size = new System.Drawing.Size(100, 20);
            this.TextBoxCode2.TabIndex = 12;
            this.TextBoxCode2.TextChanged += new System.EventHandler(this.TextBoxCode2_TextChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 54);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(257, 13);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "VCP Code #2 - auto sent when keyboard not present";
            this.Label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // TextBoxCode1
            // 
            this.TextBoxCode1.Location = new System.Drawing.Point(12, 25);
            this.TextBoxCode1.Name = "TextBoxCode1";
            this.TextBoxCode1.Size = new System.Drawing.Size(100, 20);
            this.TextBoxCode1.TabIndex = 9;
            this.TextBoxCode1.TextChanged += new System.EventHandler(this.TextBoxCode1_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(239, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "VCP Code #1 - auto sent when keyboard present";
            this.Label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.ContextMenuStrip = this.ContextMenuStrip1;
            this.NotifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon1.Icon")));
            this.NotifyIcon1.Text = "NotifyIcon1";
            this.NotifyIcon1.Visible = true;
            this.NotifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunAtStartupToolStripMenuItemTRAY,
            this.ExitToolStripMenuItem});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ContextMenuStrip1.ShowCheckMargin = true;
            this.ContextMenuStrip1.ShowImageMargin = false;
            this.ContextMenuStrip1.Size = new System.Drawing.Size(152, 48);
            // 
            // RunAtStartupToolStripMenuItemTRAY
            // 
            this.RunAtStartupToolStripMenuItemTRAY.CheckOnClick = true;
            this.RunAtStartupToolStripMenuItemTRAY.Name = "RunAtStartupToolStripMenuItemTRAY";
            this.RunAtStartupToolStripMenuItemTRAY.Size = new System.Drawing.Size(180, 22);
            this.RunAtStartupToolStripMenuItemTRAY.Text = "&Run At Startup";
            this.RunAtStartupToolStripMenuItemTRAY.Click += new System.EventHandler(this.RunAtStartupToolStripMenuItemTRAY_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitToolStripMenuItem.Text = "E&xit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 500;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // LabelKeyboardCount
            // 
            this.LabelKeyboardCount.AutoSize = true;
            this.LabelKeyboardCount.Location = new System.Drawing.Point(139, 112);
            this.LabelKeyboardCount.Name = "LabelKeyboardCount";
            this.LabelKeyboardCount.Size = new System.Drawing.Size(85, 13);
            this.LabelKeyboardCount.TabIndex = 15;
            this.LabelKeyboardCount.Text = "Keyboard count:";
            this.LabelKeyboardCount.Click += new System.EventHandler(this.LabelKeyboardCount_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 148);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonInput2);
            this.Controls.Add(this.ButtonInput1);
            this.Controls.Add(this.TextBoxCode2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TextBoxCode1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.LabelKeyboardCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.ContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button ButtonSave;
        internal System.Windows.Forms.Button ButtonInput2;
        internal System.Windows.Forms.Button ButtonInput1;
        internal System.Windows.Forms.TextBox TextBoxCode2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TextBoxCode1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.NotifyIcon NotifyIcon1;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem RunAtStartupToolStripMenuItemTRAY;
        internal System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.Label LabelKeyboardCount;
    }
}

