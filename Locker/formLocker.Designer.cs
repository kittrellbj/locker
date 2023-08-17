namespace Locker
{
    partial class formLocker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLocker));
            this.lblPrompt = new System.Windows.Forms.Label();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.viewStatus = new System.Windows.Forms.ProgressBar();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblPrompt
            // 
            this.lblPrompt.Location = new System.Drawing.Point(230, 9);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(558, 94);
            this.lblPrompt.TabIndex = 1;
            this.lblPrompt.Text = resources.GetString("lblPrompt.Text");
            // 
            // btnPopulate
            // 
            this.btnPopulate.Location = new System.Drawing.Point(337, 351);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(117, 47);
            this.btnPopulate.TabIndex = 2;
            this.btnPopulate.Text = "Populate";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.PopulateButton_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(460, 351);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(117, 47);
            this.btnUnlock.TabIndex = 3;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.UnlockButton_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(583, 351);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(117, 47);
            this.btnLock.TabIndex = 4;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.LockButton_Click);
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Location = new System.Drawing.Point(460, 404);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(117, 40);
            this.btnOpenDir.TabIndex = 5;
            this.btnOpenDir.Text = "Users Directory";
            this.btnOpenDir.UseVisualStyleBackColor = true;
            this.btnOpenDir.Click += new System.EventHandler(this.UsersDirectoryButton_Click);
            // 
            // viewStatus
            // 
            this.viewStatus.Location = new System.Drawing.Point(230, 322);
            this.viewStatus.Name = "viewStatus";
            this.viewStatus.Size = new System.Drawing.Size(558, 23);
            this.viewStatus.TabIndex = 6;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.Location = new System.Drawing.Point(230, 106);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.PlaceholderText = "Standing by...";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(558, 210);
            this.txtConsole.TabIndex = 7;
            this.txtConsole.WordWrap = false;
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 20;
            this.lstUsers.Location = new System.Drawing.Point(12, 9);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(212, 424);
            this.lstUsers.TabIndex = 8;
            // 
            // formLocker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.viewStatus);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnPopulate);
            this.Controls.Add(this.lblPrompt);
            this.Name = "formLocker";
            this.Text = "Locker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblPrompt;
        private Button btnPopulate;
        private Button btnUnlock;
        private Button btnLock;
        private Button btnOpenDir;
        private ProgressBar viewStatus;
        private TextBox txtConsole;
        private ListBox lstUsers;
    }
}