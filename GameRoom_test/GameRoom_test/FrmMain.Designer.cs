namespace GameRoom_test
{
    partial class FrmMain
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.flowRoomList = new System.Windows.Forms.FlowLayoutPanel();
            this.checkRoomList = new System.Windows.Forms.Timer(this.components);
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.TabServersRoom = new System.Windows.Forms.TabControl();
            this.tabServers = new System.Windows.Forms.TabPage();
            this.tabRoom = new System.Windows.Forms.TabPage();
            this.separator1 = new System.Windows.Forms.Panel();
            this.gbRoomSettings = new System.Windows.Forms.GroupBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.lblMaxPlayers = new System.Windows.Forms.Label();
            this.numMaxPlayers = new System.Windows.Forms.NumericUpDown();
            this.tabRoomSeparator = new System.Windows.Forms.Panel();
            this.flowPlayersList = new System.Windows.Forms.FlowLayoutPanel();
            this.separatorTopMain = new System.Windows.Forms.Panel();
            this.separatorBottomMain = new System.Windows.Forms.Panel();
            this.btnCloseRoom = new System.Windows.Forms.Button();
            this.checkPlayersRoom = new System.Windows.Forms.Timer(this.components);
            this.TabServersRoom.SuspendLayout();
            this.tabServers.SuspendLayout();
            this.tabRoom.SuspendLayout();
            this.separator1.SuspendLayout();
            this.gbRoomSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPlayers)).BeginInit();
            this.tabRoomSeparator.SuspendLayout();
            this.separatorTopMain.SuspendLayout();
            this.separatorBottomMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(16, 18);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(36, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "#User";
            // 
            // flowRoomList
            // 
            this.flowRoomList.BackColor = System.Drawing.Color.Transparent;
            this.flowRoomList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowRoomList.Location = new System.Drawing.Point(3, 3);
            this.flowRoomList.Name = "flowRoomList";
            this.flowRoomList.Size = new System.Drawing.Size(786, 342);
            this.flowRoomList.TabIndex = 1;
            // 
            // checkRoomList
            // 
            this.checkRoomList.Enabled = true;
            this.checkRoomList.Interval = 2000;
            this.checkRoomList.Tick += new System.EventHandler(this.CheckRoomList_Tick);
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.Location = new System.Drawing.Point(718, 6);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(75, 23);
            this.btnCreateRoom.TabIndex = 2;
            this.btnCreateRoom.Text = "Criar Sala";
            this.btnCreateRoom.UseVisualStyleBackColor = true;
            this.btnCreateRoom.Click += new System.EventHandler(this.BtnCreateRoom_Click);
            // 
            // TabServersRoom
            // 
            this.TabServersRoom.Controls.Add(this.tabServers);
            this.TabServersRoom.Controls.Add(this.tabRoom);
            this.TabServersRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabServersRoom.Location = new System.Drawing.Point(0, 41);
            this.TabServersRoom.Name = "TabServersRoom";
            this.TabServersRoom.SelectedIndex = 0;
            this.TabServersRoom.Size = new System.Drawing.Size(800, 374);
            this.TabServersRoom.TabIndex = 3;
            // 
            // tabServers
            // 
            this.tabServers.Controls.Add(this.flowRoomList);
            this.tabServers.Location = new System.Drawing.Point(4, 22);
            this.tabServers.Name = "tabServers";
            this.tabServers.Padding = new System.Windows.Forms.Padding(3);
            this.tabServers.Size = new System.Drawing.Size(792, 348);
            this.tabServers.TabIndex = 0;
            this.tabServers.Text = "Servers";
            this.tabServers.UseVisualStyleBackColor = true;
            // 
            // tabRoom
            // 
            this.tabRoom.Controls.Add(this.separator1);
            this.tabRoom.Controls.Add(this.tabRoomSeparator);
            this.tabRoom.Location = new System.Drawing.Point(4, 22);
            this.tabRoom.Name = "tabRoom";
            this.tabRoom.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoom.Size = new System.Drawing.Size(792, 348);
            this.tabRoom.TabIndex = 1;
            this.tabRoom.Text = "Room";
            this.tabRoom.UseVisualStyleBackColor = true;
            // 
            // separator1
            // 
            this.separator1.Controls.Add(this.gbRoomSettings);
            this.separator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.separator1.Location = new System.Drawing.Point(616, 3);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(173, 342);
            this.separator1.TabIndex = 1;
            // 
            // gbRoomSettings
            // 
            this.gbRoomSettings.Controls.Add(this.lblPassword);
            this.gbRoomSettings.Controls.Add(this.btnSettings);
            this.gbRoomSettings.Controls.Add(this.txtPw);
            this.gbRoomSettings.Controls.Add(this.lblMaxPlayers);
            this.gbRoomSettings.Controls.Add(this.numMaxPlayers);
            this.gbRoomSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRoomSettings.Location = new System.Drawing.Point(0, 0);
            this.gbRoomSettings.Name = "gbRoomSettings";
            this.gbRoomSettings.Size = new System.Drawing.Size(173, 342);
            this.gbRoomSettings.TabIndex = 0;
            this.gbRoomSettings.TabStop = false;
            this.gbRoomSettings.Text = "Room Settings";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 82);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password:";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(14, 313);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(154, 23);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "Update Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // txtPw
            // 
            this.txtPw.Location = new System.Drawing.Point(18, 98);
            this.txtPw.Name = "txtPw";
            this.txtPw.Size = new System.Drawing.Size(120, 20);
            this.txtPw.TabIndex = 8;
            // 
            // lblMaxPlayers
            // 
            this.lblMaxPlayers.AutoSize = true;
            this.lblMaxPlayers.Location = new System.Drawing.Point(15, 28);
            this.lblMaxPlayers.Name = "lblMaxPlayers";
            this.lblMaxPlayers.Size = new System.Drawing.Size(67, 13);
            this.lblMaxPlayers.TabIndex = 7;
            this.lblMaxPlayers.Text = "Max Players:";
            // 
            // numMaxPlayers
            // 
            this.numMaxPlayers.Location = new System.Drawing.Point(18, 44);
            this.numMaxPlayers.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMaxPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMaxPlayers.Name = "numMaxPlayers";
            this.numMaxPlayers.Size = new System.Drawing.Size(120, 20);
            this.numMaxPlayers.TabIndex = 6;
            this.numMaxPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tabRoomSeparator
            // 
            this.tabRoomSeparator.Controls.Add(this.flowPlayersList);
            this.tabRoomSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabRoomSeparator.Location = new System.Drawing.Point(3, 3);
            this.tabRoomSeparator.Name = "tabRoomSeparator";
            this.tabRoomSeparator.Size = new System.Drawing.Size(576, 342);
            this.tabRoomSeparator.TabIndex = 0;
            // 
            // flowPlayersList
            // 
            this.flowPlayersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPlayersList.Location = new System.Drawing.Point(0, 0);
            this.flowPlayersList.Name = "flowPlayersList";
            this.flowPlayersList.Size = new System.Drawing.Size(576, 342);
            this.flowPlayersList.TabIndex = 0;
            // 
            // separatorTopMain
            // 
            this.separatorTopMain.Controls.Add(this.lblUsername);
            this.separatorTopMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.separatorTopMain.Location = new System.Drawing.Point(0, 0);
            this.separatorTopMain.Name = "separatorTopMain";
            this.separatorTopMain.Size = new System.Drawing.Size(800, 41);
            this.separatorTopMain.TabIndex = 4;
            // 
            // separatorBottomMain
            // 
            this.separatorBottomMain.Controls.Add(this.btnCloseRoom);
            this.separatorBottomMain.Controls.Add(this.btnCreateRoom);
            this.separatorBottomMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separatorBottomMain.Location = new System.Drawing.Point(0, 415);
            this.separatorBottomMain.Name = "separatorBottomMain";
            this.separatorBottomMain.Size = new System.Drawing.Size(800, 35);
            this.separatorBottomMain.TabIndex = 5;
            // 
            // btnCloseRoom
            // 
            this.btnCloseRoom.Location = new System.Drawing.Point(718, 6);
            this.btnCloseRoom.Name = "btnCloseRoom";
            this.btnCloseRoom.Size = new System.Drawing.Size(75, 23);
            this.btnCloseRoom.TabIndex = 3;
            this.btnCloseRoom.Text = "Sair da Sala";
            this.btnCloseRoom.UseVisualStyleBackColor = true;
            this.btnCloseRoom.Visible = false;
            this.btnCloseRoom.Click += new System.EventHandler(this.BtnCloseRoom_Click);
            // 
            // checkPlayersRoom
            // 
            this.checkPlayersRoom.Interval = 2000;
            this.checkPlayersRoom.Tick += new System.EventHandler(this.CheckPlayersRoom_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabServersRoom);
            this.Controls.Add(this.separatorTopMain);
            this.Controls.Add(this.separatorBottomMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servidores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.TabServersRoom.ResumeLayout(false);
            this.tabServers.ResumeLayout(false);
            this.tabRoom.ResumeLayout(false);
            this.separator1.ResumeLayout(false);
            this.gbRoomSettings.ResumeLayout(false);
            this.gbRoomSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPlayers)).EndInit();
            this.tabRoomSeparator.ResumeLayout(false);
            this.separatorTopMain.ResumeLayout(false);
            this.separatorTopMain.PerformLayout();
            this.separatorBottomMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.FlowLayoutPanel flowRoomList;
        private System.Windows.Forms.Timer checkRoomList;
        private System.Windows.Forms.Button btnCreateRoom;
        private System.Windows.Forms.TabControl TabServersRoom;
        private System.Windows.Forms.TabPage tabServers;
        private System.Windows.Forms.TabPage tabRoom;
        private System.Windows.Forms.Panel separator1;
        private System.Windows.Forms.Panel tabRoomSeparator;
        private System.Windows.Forms.FlowLayoutPanel flowPlayersList;
        private System.Windows.Forms.GroupBox gbRoomSettings;
        private System.Windows.Forms.Panel separatorTopMain;
        private System.Windows.Forms.Panel separatorBottomMain;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.Label lblMaxPlayers;
        private System.Windows.Forms.NumericUpDown numMaxPlayers;
        private System.Windows.Forms.Button btnCloseRoom;
        private System.Windows.Forms.Timer checkPlayersRoom;
    }
}