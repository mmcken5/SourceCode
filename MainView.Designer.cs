namespace assignment2_mmcken5
{
    partial class mainView
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
            this.checkBox_packet_report = new System.Windows.Forms.CheckBox();
            this.label_port = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.comboBox_video_name = new System.Windows.Forms.ComboBox();
            this.label_sever_ip = new System.Windows.Forms.Label();
            this.label_video = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_server_ip = new System.Windows.Forms.TextBox();
            this.button_setup = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.checkBox_print_header = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button_play = new System.Windows.Forms.Button();
            this.button_pause = new System.Windows.Forms.Button();
            this.button_teardown = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_packet_report
            // 
            this.checkBox_packet_report.AutoSize = true;
            this.checkBox_packet_report.Location = new System.Drawing.Point(439, 344);
            this.checkBox_packet_report.Name = "checkBox_packet_report";
            this.checkBox_packet_report.Size = new System.Drawing.Size(95, 17);
            this.checkBox_packet_report.TabIndex = 8;
            this.checkBox_packet_report.Text = "Packet Report";
            this.checkBox_packet_report.UseVisualStyleBackColor = true;
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(14, 13);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(26, 13);
            this.label_port.TabIndex = 2;
            this.label_port.Text = "Port";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(46, 10);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(71, 20);
            this.textBox_port.TabIndex = 1;
            this.textBox_port.Text = "3000";
            // 
            // comboBox_video_name
            // 
            this.comboBox_video_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_video_name.FormattingEnabled = true;
            this.comboBox_video_name.Items.AddRange(new object[] {
            "video1.mjpeg",
            "video2.mjpeg"});
            this.comboBox_video_name.Location = new System.Drawing.Point(413, 10);
            this.comboBox_video_name.Name = "comboBox_video_name";
            this.comboBox_video_name.Size = new System.Drawing.Size(121, 21);
            this.comboBox_video_name.TabIndex = 3;
            // 
            // label_sever_ip
            // 
            this.label_sever_ip.AutoSize = true;
            this.label_sever_ip.Location = new System.Drawing.Point(138, 13);
            this.label_sever_ip.Name = "label_sever_ip";
            this.label_sever_ip.Size = new System.Drawing.Size(92, 13);
            this.label_sever_ip.TabIndex = 2;
            this.label_sever_ip.Text = "Server IP Address";
            // 
            // label_video
            // 
            this.label_video.AutoSize = true;
            this.label_video.Location = new System.Drawing.Point(373, 13);
            this.label_video.Name = "label_video";
            this.label_video.Size = new System.Drawing.Size(34, 13);
            this.label_video.TabIndex = 2;
            this.label_video.Text = "Video";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Server Responses";
            // 
            // textBox_server_ip
            // 
            this.textBox_server_ip.Location = new System.Drawing.Point(236, 10);
            this.textBox_server_ip.Name = "textBox_server_ip";
            this.textBox_server_ip.Size = new System.Drawing.Size(100, 20);
            this.textBox_server_ip.TabIndex = 2;
            this.textBox_server_ip.Text = "127.0.0.1";
            // 
            // button_setup
            // 
            this.button_setup.BackColor = System.Drawing.SystemColors.Control;
            this.button_setup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_setup.ForeColor = System.Drawing.Color.Black;
            this.button_setup.Location = new System.Drawing.Point(6, 6);
            this.button_setup.Name = "button_setup";
            this.button_setup.Size = new System.Drawing.Size(75, 23);
            this.button_setup.TabIndex = 4;
            this.button_setup.Text = "Setup";
            this.button_setup.UseVisualStyleBackColor = false;
            this.button_setup.Click += new System.EventHandler(this.ST_Setup_Clicked);
            this.button_setup.MouseEnter += new System.EventHandler(this.button_setup_MouseEnter);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(468, 589);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 23);
            this.button_exit.TabIndex = 11;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(468, 560);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 10;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox3.Location = new System.Drawing.Point(16, 341);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(407, 117);
            this.textBox3.TabIndex = 3;
            this.textBox3.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox4.Location = new System.Drawing.Point(16, 487);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(407, 125);
            this.textBox4.TabIndex = 3;
            this.textBox4.TabStop = false;
            // 
            // checkBox_print_header
            // 
            this.checkBox_print_header.AutoSize = true;
            this.checkBox_print_header.Location = new System.Drawing.Point(439, 367);
            this.checkBox_print_header.Name = "checkBox_print_header";
            this.checkBox_print_header.Size = new System.Drawing.Size(85, 17);
            this.checkBox_print_header.TabIndex = 9;
            this.checkBox_print_header.Text = "Print Header";
            this.checkBox_print_header.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(508, 228);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(16, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 237);
            this.panel1.TabIndex = 6;
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::assignment2_mmcken5.Properties.Resources.Teardown;
            this.pictureBox5.Location = new System.Drawing.Point(450, 190);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(41, 34);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.ST_Teardown_Clicked);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::assignment2_mmcken5.Properties.Resources.Pause;
            this.pictureBox4.Location = new System.Drawing.Point(301, 190);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(41, 34);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.ST_Pause_Clicked);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::assignment2_mmcken5.Properties.Resources.Play;
            this.pictureBox3.Location = new System.Drawing.Point(165, 190);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(41, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.ST_Play_Clicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::assignment2_mmcken5.Properties.Resources.Setup;
            this.pictureBox2.Location = new System.Drawing.Point(21, 190);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.ST_Setup_Clicked);
            // 
            // button_play
            // 
            this.button_play.BackColor = System.Drawing.SystemColors.Control;
            this.button_play.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_play.ForeColor = System.Drawing.Color.Black;
            this.button_play.Location = new System.Drawing.Point(147, 6);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(75, 23);
            this.button_play.TabIndex = 5;
            this.button_play.Text = "Play";
            this.button_play.UseVisualStyleBackColor = false;
            this.button_play.Click += new System.EventHandler(this.ST_Play_Clicked);
            this.button_play.MouseEnter += new System.EventHandler(this.button_play_MouseEnter);
            // 
            // button_pause
            // 
            this.button_pause.BackColor = System.Drawing.SystemColors.Control;
            this.button_pause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_pause.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_pause.Location = new System.Drawing.Point(285, 6);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(75, 23);
            this.button_pause.TabIndex = 6;
            this.button_pause.Text = "Pause";
            this.button_pause.UseVisualStyleBackColor = false;
            this.button_pause.Click += new System.EventHandler(this.ST_Pause_Clicked);
            this.button_pause.MouseEnter += new System.EventHandler(this.button_pause_MouseEnter);
            // 
            // button_teardown
            // 
            this.button_teardown.BackColor = System.Drawing.SystemColors.Control;
            this.button_teardown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_teardown.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_teardown.Location = new System.Drawing.Point(434, 6);
            this.button_teardown.Name = "button_teardown";
            this.button_teardown.Size = new System.Drawing.Size(75, 23);
            this.button_teardown.TabIndex = 7;
            this.button_teardown.Text = "Teardown";
            this.button_teardown.UseVisualStyleBackColor = false;
            this.button_teardown.Click += new System.EventHandler(this.ST_Teardown_Clicked);
            this.button_teardown.MouseEnter += new System.EventHandler(this.button_teardown_MouseEnter);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.button_setup);
            this.panel2.Controls.Add(this.button_play);
            this.panel2.Controls.Add(this.button_pause);
            this.panel2.Controls.Add(this.button_teardown);
            this.panel2.Location = new System.Drawing.Point(16, 286);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 38);
            this.panel2.TabIndex = 6;
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            // 
            // mainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 624);
            this.Controls.Add(this.comboBox_video_name);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox_server_ip);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_video);
            this.Controls.Add(this.label_sever_ip);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.checkBox_print_header);
            this.Controls.Add(this.checkBox_packet_report);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.panel1);
            this.Name = "mainView";
            this.Text = "Video Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainView_FormClosing);
            this.MouseEnter += new System.EventHandler(this.mainView_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_packet_report;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.ComboBox comboBox_video_name;
        private System.Windows.Forms.Label label_sever_ip;
        private System.Windows.Forms.Label label_video;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_server_ip;
        private System.Windows.Forms.Button button_setup;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox_print_header;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_teardown;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel2;
    }
}

