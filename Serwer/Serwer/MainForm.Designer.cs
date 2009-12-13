namespace Serwer
{
    partial class MainForm
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
            this.logTxt = new System.Windows.Forms.RichTextBox();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabSerwer = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMapMaxPlayers = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.btnMapDefault = new System.Windows.Forms.Button();
            this.btnMapSet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMapRateH = new System.Windows.Forms.TextBox();
            this.txtMapRateW = new System.Windows.Forms.TextBox();
            this.txtMapMaxY = new System.Windows.Forms.TextBox();
            this.txtMapMaxX = new System.Windows.Forms.TextBox();
            this.tabPowerUps = new System.Windows.Forms.TabPage();
            this.tabPlugins = new System.Windows.Forms.TabPage();
            this.tabSet = new System.Windows.Forms.TabPage();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.treeUser = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabSettings.SuspendLayout();
            this.tabSerwer.SuspendLayout();
            this.tabMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // logTxt
            // 
            this.logTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logTxt.Location = new System.Drawing.Point(12, 12);
            this.logTxt.Name = "logTxt";
            this.logTxt.Size = new System.Drawing.Size(514, 311);
            this.logTxt.TabIndex = 1;
            this.logTxt.Text = "";
            // 
            // tabSettings
            // 
            this.tabSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSettings.Controls.Add(this.tabSerwer);
            this.tabSettings.Controls.Add(this.tabMap);
            this.tabSettings.Controls.Add(this.tabPowerUps);
            this.tabSettings.Controls.Add(this.tabPlugins);
            this.tabSettings.Controls.Add(this.tabSet);
            this.tabSettings.Controls.Add(this.tabInfo);
            this.tabSettings.Location = new System.Drawing.Point(12, 329);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(499, 125);
            this.tabSettings.TabIndex = 2;
            // 
            // tabSerwer
            // 
            this.tabSerwer.Controls.Add(this.label7);
            this.tabSerwer.Controls.Add(this.txtMapMaxPlayers);
            this.tabSerwer.Controls.Add(this.btnStop);
            this.tabSerwer.Controls.Add(this.btnStart);
            this.tabSerwer.Controls.Add(this.label2);
            this.tabSerwer.Controls.Add(this.label1);
            this.tabSerwer.Controls.Add(this.txtPort);
            this.tabSerwer.Controls.Add(this.txtIP);
            this.tabSerwer.Location = new System.Drawing.Point(4, 22);
            this.tabSerwer.Name = "tabSerwer";
            this.tabSerwer.Padding = new System.Windows.Forms.Padding(3);
            this.tabSerwer.Size = new System.Drawing.Size(491, 99);
            this.tabSerwer.TabIndex = 0;
            this.tabSerwer.Text = "Serwer";
            this.tabSerwer.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(112, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Max Graczy:";
            // 
            // txtMapMaxPlayers
            // 
            this.txtMapMaxPlayers.Location = new System.Drawing.Point(112, 18);
            this.txtMapMaxPlayers.Name = "txtMapMaxPlayers";
            this.txtMapMaxPlayers.Size = new System.Drawing.Size(100, 20);
            this.txtMapMaxPlayers.TabIndex = 6;
            this.txtMapMaxPlayers.Text = "4";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(218, 61);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(218, 15);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(6, 64);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "2610";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(6, 18);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "127.0.0.1";
            // 
            // tabMap
            // 
            this.tabMap.Controls.Add(this.btnMapDefault);
            this.tabMap.Controls.Add(this.btnMapSet);
            this.tabMap.Controls.Add(this.label6);
            this.tabMap.Controls.Add(this.label5);
            this.tabMap.Controls.Add(this.label4);
            this.tabMap.Controls.Add(this.label3);
            this.tabMap.Controls.Add(this.txtMapRateH);
            this.tabMap.Controls.Add(this.txtMapRateW);
            this.tabMap.Controls.Add(this.txtMapMaxY);
            this.tabMap.Controls.Add(this.txtMapMaxX);
            this.tabMap.Location = new System.Drawing.Point(4, 22);
            this.tabMap.Name = "tabMap";
            this.tabMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabMap.Size = new System.Drawing.Size(491, 99);
            this.tabMap.TabIndex = 1;
            this.tabMap.Text = "Mapa";
            this.tabMap.UseVisualStyleBackColor = true;
            // 
            // btnMapDefault
            // 
            this.btnMapDefault.Location = new System.Drawing.Point(218, 61);
            this.btnMapDefault.Name = "btnMapDefault";
            this.btnMapDefault.Size = new System.Drawing.Size(75, 23);
            this.btnMapDefault.TabIndex = 9;
            this.btnMapDefault.Text = "Domyślne";
            this.btnMapDefault.UseVisualStyleBackColor = true;
            // 
            // btnMapSet
            // 
            this.btnMapSet.Location = new System.Drawing.Point(218, 15);
            this.btnMapSet.Name = "btnMapSet";
            this.btnMapSet.Size = new System.Drawing.Size(75, 23);
            this.btnMapSet.TabIndex = 8;
            this.btnMapSet.Text = "Zmień";
            this.btnMapSet.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Stosunek Wysokość";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Stosunek Szerokość";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "MaxY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "MaxX";
            // 
            // txtMapRateH
            // 
            this.txtMapRateH.Location = new System.Drawing.Point(112, 64);
            this.txtMapRateH.Name = "txtMapRateH";
            this.txtMapRateH.Size = new System.Drawing.Size(100, 20);
            this.txtMapRateH.TabIndex = 3;
            this.txtMapRateH.Text = "9";
            // 
            // txtMapRateW
            // 
            this.txtMapRateW.Location = new System.Drawing.Point(6, 63);
            this.txtMapRateW.Name = "txtMapRateW";
            this.txtMapRateW.Size = new System.Drawing.Size(100, 20);
            this.txtMapRateW.TabIndex = 2;
            this.txtMapRateW.Text = "16";
            // 
            // txtMapMaxY
            // 
            this.txtMapMaxY.Location = new System.Drawing.Point(112, 17);
            this.txtMapMaxY.Name = "txtMapMaxY";
            this.txtMapMaxY.Size = new System.Drawing.Size(100, 20);
            this.txtMapMaxY.TabIndex = 1;
            this.txtMapMaxY.Text = "18";
            // 
            // txtMapMaxX
            // 
            this.txtMapMaxX.Location = new System.Drawing.Point(6, 18);
            this.txtMapMaxX.Name = "txtMapMaxX";
            this.txtMapMaxX.Size = new System.Drawing.Size(100, 20);
            this.txtMapMaxX.TabIndex = 0;
            this.txtMapMaxX.Text = "32";
            // 
            // tabPowerUps
            // 
            this.tabPowerUps.Location = new System.Drawing.Point(4, 22);
            this.tabPowerUps.Name = "tabPowerUps";
            this.tabPowerUps.Padding = new System.Windows.Forms.Padding(3);
            this.tabPowerUps.Size = new System.Drawing.Size(491, 99);
            this.tabPowerUps.TabIndex = 2;
            this.tabPowerUps.Text = "PowerUp\'y";
            this.tabPowerUps.UseVisualStyleBackColor = true;
            // 
            // tabPlugins
            // 
            this.tabPlugins.Location = new System.Drawing.Point(4, 22);
            this.tabPlugins.Name = "tabPlugins";
            this.tabPlugins.Size = new System.Drawing.Size(491, 99);
            this.tabPlugins.TabIndex = 3;
            this.tabPlugins.Text = "Pluginy";
            this.tabPlugins.UseVisualStyleBackColor = true;
            // 
            // tabSet
            // 
            this.tabSet.Location = new System.Drawing.Point(4, 22);
            this.tabSet.Name = "tabSet";
            this.tabSet.Size = new System.Drawing.Size(491, 99);
            this.tabSet.TabIndex = 5;
            this.tabSet.Text = "Ustawienia";
            this.tabSet.UseVisualStyleBackColor = true;
            // 
            // tabInfo
            // 
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(491, 99);
            this.tabInfo.TabIndex = 4;
            this.tabInfo.Text = "Info";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // treeUser
            // 
            this.treeUser.Location = new System.Drawing.Point(532, 12);
            this.treeUser.Name = "treeUser";
            this.treeUser.Size = new System.Drawing.Size(230, 311);
            this.treeUser.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(536, 351);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 102);
            this.panel1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 466);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeUser);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.logTxt);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 34);
            this.Name = "MainForm";
            this.Text = "Brain-Blaster Serwer";
            this.tabSettings.ResumeLayout(false);
            this.tabSerwer.ResumeLayout(false);
            this.tabSerwer.PerformLayout();
            this.tabMap.ResumeLayout(false);
            this.tabMap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox logTxt;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabSerwer;
        private System.Windows.Forms.TabPage tabMap;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtMapMaxX;
        private System.Windows.Forms.TextBox txtMapMaxY;
        private System.Windows.Forms.Button btnMapDefault;
        private System.Windows.Forms.Button btnMapSet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMapRateH;
        private System.Windows.Forms.TextBox txtMapRateW;
        private System.Windows.Forms.TabPage tabPowerUps;
        private System.Windows.Forms.TabPage tabPlugins;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabSet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMapMaxPlayers;
        private System.Windows.Forms.TreeView treeUser;
        private System.Windows.Forms.Panel panel1;
    }
}

