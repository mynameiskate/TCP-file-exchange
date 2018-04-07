namespace TCPClientApp
{
    partial class FileSender
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
            this.IPBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.userIPTextBox = new System.Windows.Forms.TextBox();
            this.receiverPortTB = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.pathTB = new System.Windows.Forms.TextBox();
            this.youLbl = new System.Windows.Forms.Label();
            this.peerLbl = new System.Windows.Forms.Label();
            this.port1Lbl = new System.Windows.Forms.Label();
            this.port2Lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IPBox
            // 
            this.IPBox.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPBox.ForeColor = System.Drawing.Color.Black;
            this.IPBox.Location = new System.Drawing.Point(326, 131);
            this.IPBox.Multiline = true;
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(255, 39);
            this.IPBox.TabIndex = 0;
            this.IPBox.Text = "IP-address of the receiver..";
            // 
            // sendBtn
            // 
            this.sendBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.sendBtn.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendBtn.Location = new System.Drawing.Point(308, 478);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(196, 57);
            this.sendBtn.TabIndex = 2;
            this.sendBtn.Text = "Send!";
            this.sendBtn.UseVisualStyleBackColor = false;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusTextBox.Location = new System.Drawing.Point(12, 237);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusTextBox.Size = new System.Drawing.Size(569, 235);
            this.statusTextBox.TabIndex = 3;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // portTextBox
            // 
            this.portTextBox.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTextBox.ForeColor = System.Drawing.Color.Black;
            this.portTextBox.Location = new System.Drawing.Point(85, 86);
            this.portTextBox.Multiline = true;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(57, 39);
            this.portTextBox.TabIndex = 4;
            this.portTextBox.Text = "905";
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.startBtn.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startBtn.Location = new System.Drawing.Point(85, 478);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(196, 57);
            this.startBtn.TabIndex = 5;
            this.startBtn.Text = "Start server";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // userIPTextBox
            // 
            this.userIPTextBox.Enabled = false;
            this.userIPTextBox.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIPTextBox.ForeColor = System.Drawing.Color.Black;
            this.userIPTextBox.Location = new System.Drawing.Point(12, 131);
            this.userIPTextBox.Multiline = true;
            this.userIPTextBox.Name = "userIPTextBox";
            this.userIPTextBox.Size = new System.Drawing.Size(269, 39);
            this.userIPTextBox.TabIndex = 6;
            this.userIPTextBox.Text = "Your IP";
            // 
            // receiverPortTB
            // 
            this.receiverPortTB.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receiverPortTB.ForeColor = System.Drawing.Color.Black;
            this.receiverPortTB.Location = new System.Drawing.Point(447, 86);
            this.receiverPortTB.Multiline = true;
            this.receiverPortTB.Name = "receiverPortTB";
            this.receiverPortTB.Size = new System.Drawing.Size(57, 39);
            this.receiverPortTB.TabIndex = 7;
            this.receiverPortTB.Text = "905";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\";
            // 
            // pathTB
            // 
            this.pathTB.Enabled = false;
            this.pathTB.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathTB.ForeColor = System.Drawing.Color.Black;
            this.pathTB.Location = new System.Drawing.Point(12, 180);
            this.pathTB.Multiline = true;
            this.pathTB.Name = "pathTB";
            this.pathTB.Size = new System.Drawing.Size(269, 39);
            this.pathTB.TabIndex = 8;
            this.pathTB.Text = "Save path";
            // 
            // youLbl
            // 
            this.youLbl.AutoSize = true;
            this.youLbl.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.youLbl.Location = new System.Drawing.Point(143, 26);
            this.youLbl.Name = "youLbl";
            this.youLbl.Size = new System.Drawing.Size(60, 37);
            this.youLbl.TabIndex = 9;
            this.youLbl.Text = "You";
            // 
            // peerLbl
            // 
            this.peerLbl.AutoSize = true;
            this.peerLbl.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.peerLbl.Location = new System.Drawing.Point(335, 26);
            this.peerLbl.Name = "peerLbl";
            this.peerLbl.Size = new System.Drawing.Size(230, 37);
            this.peerLbl.TabIndex = 10;
            this.peerLbl.Text = "Connected computer";
            // 
            // port1Lbl
            // 
            this.port1Lbl.AutoSize = true;
            this.port1Lbl.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.port1Lbl.Location = new System.Drawing.Point(12, 81);
            this.port1Lbl.Name = "port1Lbl";
            this.port1Lbl.Size = new System.Drawing.Size(64, 32);
            this.port1Lbl.TabIndex = 11;
            this.port1Lbl.Text = "Port";
            // 
            // port2Lbl
            // 
            this.port2Lbl.AutoSize = true;
            this.port2Lbl.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.port2Lbl.Location = new System.Drawing.Point(369, 81);
            this.port2Lbl.Name = "port2Lbl";
            this.port2Lbl.Size = new System.Drawing.Size(64, 32);
            this.port2Lbl.TabIndex = 12;
            this.port2Lbl.Text = "Port";
            // 
            // FileSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(593, 547);
            this.Controls.Add(this.port2Lbl);
            this.Controls.Add(this.port1Lbl);
            this.Controls.Add(this.peerLbl);
            this.Controls.Add(this.youLbl);
            this.Controls.Add(this.pathTB);
            this.Controls.Add(this.receiverPortTB);
            this.Controls.Add(this.userIPTextBox);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.IPBox);
            this.Name = "FileSender";
            this.Text = "File Sender";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileSender_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox userIPTextBox;
        private System.Windows.Forms.TextBox receiverPortTB;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox pathTB;
        private System.Windows.Forms.Label youLbl;
        private System.Windows.Forms.Label peerLbl;
        private System.Windows.Forms.Label port1Lbl;
        private System.Windows.Forms.Label port2Lbl;
    }
}

