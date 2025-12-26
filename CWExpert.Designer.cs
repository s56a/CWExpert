namespace CWExpert
{
    partial class CWExpert
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
            Audio.callback_return = 2;
            Audio.StopAudio();

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
            this.txtCall = new System.Windows.Forms.TextBox();
            this.btnSendCall = new System.Windows.Forms.Button();
            this.btnF1 = new System.Windows.Forms.Button();
            this.btnF2 = new System.Windows.Forms.Button();
            this.btnF3 = new System.Windows.Forms.Button();
            this.btnF4 = new System.Windows.Forms.Button();
            this.btnF5 = new System.Windows.Forms.Button();
            this.btnF6 = new System.Windows.Forms.Button();
            this.btnF8 = new System.Windows.Forms.Button();
            this.btnF7 = new System.Windows.Forms.Button();
            this.btnStartMR = new System.Windows.Forms.CheckBox();
            this.btnSendRST = new System.Windows.Forms.Button();
            this.txtRST = new System.Windows.Forms.TextBox();
            this.btnSendNr = new System.Windows.Forms.Button();
            this.txtNr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChannel4 = new System.Windows.Forms.TextBox();
            this.btnclr = new System.Windows.Forms.Button();
            this.txtChannel5 = new System.Windows.Forms.TextBox();
            this.txtChannel6 = new System.Windows.Forms.TextBox();
            this.txtChannel7 = new System.Windows.Forms.TextBox();
            this.txtChannel11 = new System.Windows.Forms.TextBox();
            this.txtChannel10 = new System.Windows.Forms.TextBox();
            this.txtChannel9 = new System.Windows.Forms.TextBox();
            this.txtChannel8 = new System.Windows.Forms.TextBox();
            this.txtChannel15 = new System.Windows.Forms.TextBox();
            this.txtChannel14 = new System.Windows.Forms.TextBox();
            this.txtChannel13 = new System.Windows.Forms.TextBox();
            this.txtChannel12 = new System.Windows.Forms.TextBox();
            this.txtChannel16 = new System.Windows.Forms.TextBox();
            this.txtChannel3 = new System.Windows.Forms.TextBox();
            this.txtChannel2 = new System.Windows.Forms.TextBox();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtChannel1 = new System.Windows.Forms.TextBox();
            this.txtChannel20 = new System.Windows.Forms.TextBox();
            this.txtChannel17 = new System.Windows.Forms.TextBox();
            this.txtChannel18 = new System.Windows.Forms.TextBox();
            this.txtChannel19 = new System.Windows.Forms.TextBox();
            this.txtChannel0 = new System.Windows.Forms.TextBox();
            this.btnF9 = new System.Windows.Forms.Button();
            this.btnF10 = new System.Windows.Forms.Button();
            this.btnF11 = new System.Windows.Forms.Button();
            this.btnF12 = new System.Windows.Forms.Button();
            this.chkSWL = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCall
            // 
            this.txtCall.Location = new System.Drawing.Point(305, 48);
            this.txtCall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCall.MaxLength = 16;
            this.txtCall.Name = "txtCall";
            this.txtCall.Size = new System.Drawing.Size(87, 22);
            this.txtCall.TabIndex = 0;
            this.txtCall.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCall_KeyUp);
            // 
            // btnSendCall
            // 
            this.btnSendCall.Location = new System.Drawing.Point(305, 80);
            this.btnSendCall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSendCall.Name = "btnSendCall";
            this.btnSendCall.Size = new System.Drawing.Size(83, 28);
            this.btnSendCall.TabIndex = 1;
            this.btnSendCall.Text = "Call";
            this.btnSendCall.UseVisualStyleBackColor = true;
            this.btnSendCall.Click += new System.EventHandler(this.btnSendCall_Click);
            // 
            // btnF1
            // 
            this.btnF1.Location = new System.Drawing.Point(25, 457);
            this.btnF1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(53, 28);
            this.btnF1.TabIndex = 2;
            this.btnF1.Text = "F1";
            this.btnF1.UseVisualStyleBackColor = true;
            this.btnF1.Click += new System.EventHandler(this.btnF1_Click);
            // 
            // btnF2
            // 
            this.btnF2.Location = new System.Drawing.Point(87, 457);
            this.btnF2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF2.Name = "btnF2";
            this.btnF2.Size = new System.Drawing.Size(53, 28);
            this.btnF2.TabIndex = 3;
            this.btnF2.Text = "F2";
            this.btnF2.UseVisualStyleBackColor = true;
            this.btnF2.Click += new System.EventHandler(this.btnF2_Click);
            // 
            // btnF3
            // 
            this.btnF3.Location = new System.Drawing.Point(148, 457);
            this.btnF3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF3.Name = "btnF3";
            this.btnF3.Size = new System.Drawing.Size(53, 28);
            this.btnF3.TabIndex = 4;
            this.btnF3.Text = "F3";
            this.btnF3.UseVisualStyleBackColor = true;
            this.btnF3.Click += new System.EventHandler(this.btnF3_Click);
            // 
            // btnF4
            // 
            this.btnF4.Location = new System.Drawing.Point(209, 457);
            this.btnF4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF4.Name = "btnF4";
            this.btnF4.Size = new System.Drawing.Size(53, 28);
            this.btnF4.TabIndex = 5;
            this.btnF4.Text = "F4";
            this.btnF4.UseVisualStyleBackColor = true;
            this.btnF4.Click += new System.EventHandler(this.btnF4_Click);
            // 
            // btnF5
            // 
            this.btnF5.Location = new System.Drawing.Point(271, 457);
            this.btnF5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF5.Name = "btnF5";
            this.btnF5.Size = new System.Drawing.Size(53, 28);
            this.btnF5.TabIndex = 6;
            this.btnF5.Text = "F5";
            this.btnF5.UseVisualStyleBackColor = true;
            this.btnF5.Click += new System.EventHandler(this.btnF5_Click);
            // 
            // btnF6
            // 
            this.btnF6.Location = new System.Drawing.Point(332, 457);
            this.btnF6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF6.Name = "btnF6";
            this.btnF6.Size = new System.Drawing.Size(53, 28);
            this.btnF6.TabIndex = 7;
            this.btnF6.Text = "F6";
            this.btnF6.UseVisualStyleBackColor = true;
            this.btnF6.Click += new System.EventHandler(this.btnF6_Click);
            // 
            // btnF8
            // 
            this.btnF8.Location = new System.Drawing.Point(88, 492);
            this.btnF8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF8.Name = "btnF8";
            this.btnF8.Size = new System.Drawing.Size(53, 28);
            this.btnF8.TabIndex = 9;
            this.btnF8.Text = "F8";
            this.btnF8.UseVisualStyleBackColor = true;
            this.btnF8.Click += new System.EventHandler(this.btnF8_Click);
            // 
            // btnF7
            // 
            this.btnF7.Location = new System.Drawing.Point(27, 492);
            this.btnF7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF7.Name = "btnF7";
            this.btnF7.Size = new System.Drawing.Size(53, 28);
            this.btnF7.TabIndex = 8;
            this.btnF7.Text = "F7";
            this.btnF7.UseVisualStyleBackColor = true;
            this.btnF7.Click += new System.EventHandler(this.btnF7_Click);
            // 
            // btnStartMR
            // 
            this.btnStartMR.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnStartMR.Location = new System.Drawing.Point(305, 398);
            this.btnStartMR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartMR.Name = "btnStartMR";
            this.btnStartMR.Size = new System.Drawing.Size(83, 28);
            this.btnStartMR.TabIndex = 10;
            this.btnStartMR.Text = "Start ";
            this.btnStartMR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStartMR.UseVisualStyleBackColor = true;
            this.btnStartMR.CheckedChanged += new System.EventHandler(this.btnStartMR_CheckedChanged);
            // 
            // btnSendRST
            // 
            this.btnSendRST.Location = new System.Drawing.Point(305, 164);
            this.btnSendRST.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSendRST.Name = "btnSendRST";
            this.btnSendRST.Size = new System.Drawing.Size(83, 28);
            this.btnSendRST.TabIndex = 14;
            this.btnSendRST.Text = "RST";
            this.btnSendRST.UseVisualStyleBackColor = true;
            this.btnSendRST.Click += new System.EventHandler(this.btnSendRST_Click);
            // 
            // txtRST
            // 
            this.txtRST.Location = new System.Drawing.Point(305, 130);
            this.txtRST.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRST.MaxLength = 3;
            this.txtRST.Name = "txtRST";
            this.txtRST.Size = new System.Drawing.Size(81, 22);
            this.txtRST.TabIndex = 13;
            this.txtRST.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRST_KeyUp);
            // 
            // btnSendNr
            // 
            this.btnSendNr.Location = new System.Drawing.Point(305, 256);
            this.btnSendNr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSendNr.Name = "btnSendNr";
            this.btnSendNr.Size = new System.Drawing.Size(83, 28);
            this.btnSendNr.TabIndex = 16;
            this.btnSendNr.Text = "Nmbr";
            this.btnSendNr.UseVisualStyleBackColor = true;
            this.btnSendNr.Click += new System.EventHandler(this.btnSendNr_Click);
            // 
            // txtNr
            // 
            this.txtNr.Location = new System.Drawing.Point(305, 220);
            this.txtNr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNr.MaxLength = 5;
            this.txtNr.Name = "txtNr";
            this.txtNr.Size = new System.Drawing.Size(81, 22);
            this.txtNr.TabIndex = 15;
            this.txtNr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNr_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "S56A - DL7NX - GitHub";
            // 
            // txtChannel4
            // 
            this.txtChannel4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel4.Location = new System.Drawing.Point(27, 111);
            this.txtChannel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel4.MaxLength = 32768;
            this.txtChannel4.Name = "txtChannel4";
            this.txtChannel4.Size = new System.Drawing.Size(267, 15);
            this.txtChannel4.TabIndex = 22;
            // 
            // btnclr
            // 
            this.btnclr.Location = new System.Drawing.Point(305, 308);
            this.btnclr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnclr.Name = "btnclr";
            this.btnclr.Size = new System.Drawing.Size(83, 28);
            this.btnclr.TabIndex = 24;
            this.btnclr.Text = "Clear";
            this.btnclr.UseVisualStyleBackColor = true;
            this.btnclr.Click += new System.EventHandler(this.btnclr_Click);
            // 
            // txtChannel5
            // 
            this.txtChannel5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel5.Location = new System.Drawing.Point(27, 130);
            this.txtChannel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel5.MaxLength = 32768;
            this.txtChannel5.Name = "txtChannel5";
            this.txtChannel5.Size = new System.Drawing.Size(267, 15);
            this.txtChannel5.TabIndex = 25;
            // 
            // txtChannel6
            // 
            this.txtChannel6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel6.Location = new System.Drawing.Point(27, 150);
            this.txtChannel6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel6.MaxLength = 32768;
            this.txtChannel6.Name = "txtChannel6";
            this.txtChannel6.Size = new System.Drawing.Size(267, 15);
            this.txtChannel6.TabIndex = 26;
            // 
            // txtChannel7
            // 
            this.txtChannel7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel7.Location = new System.Drawing.Point(27, 170);
            this.txtChannel7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel7.MaxLength = 32768;
            this.txtChannel7.Name = "txtChannel7";
            this.txtChannel7.Size = new System.Drawing.Size(267, 15);
            this.txtChannel7.TabIndex = 27;
            // 
            // txtChannel11
            // 
            this.txtChannel11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel11.Location = new System.Drawing.Point(27, 249);
            this.txtChannel11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel11.MaxLength = 32768;
            this.txtChannel11.Name = "txtChannel11";
            this.txtChannel11.Size = new System.Drawing.Size(267, 15);
            this.txtChannel11.TabIndex = 31;
            // 
            // txtChannel10
            // 
            this.txtChannel10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel10.Location = new System.Drawing.Point(27, 229);
            this.txtChannel10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel10.MaxLength = 32768;
            this.txtChannel10.Name = "txtChannel10";
            this.txtChannel10.Size = new System.Drawing.Size(267, 15);
            this.txtChannel10.TabIndex = 30;
            // 
            // txtChannel9
            // 
            this.txtChannel9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel9.Location = new System.Drawing.Point(27, 209);
            this.txtChannel9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel9.MaxLength = 32768;
            this.txtChannel9.Name = "txtChannel9";
            this.txtChannel9.Size = new System.Drawing.Size(267, 15);
            this.txtChannel9.TabIndex = 29;
            // 
            // txtChannel8
            // 
            this.txtChannel8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel8.Location = new System.Drawing.Point(27, 190);
            this.txtChannel8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel8.MaxLength = 32768;
            this.txtChannel8.Name = "txtChannel8";
            this.txtChannel8.Size = new System.Drawing.Size(267, 15);
            this.txtChannel8.TabIndex = 28;
            // 
            // txtChannel15
            // 
            this.txtChannel15.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel15.Location = new System.Drawing.Point(27, 327);
            this.txtChannel15.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel15.MaxLength = 32768;
            this.txtChannel15.Name = "txtChannel15";
            this.txtChannel15.Size = new System.Drawing.Size(267, 15);
            this.txtChannel15.TabIndex = 35;
            // 
            // txtChannel14
            // 
            this.txtChannel14.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel14.Location = new System.Drawing.Point(27, 308);
            this.txtChannel14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel14.MaxLength = 32768;
            this.txtChannel14.Name = "txtChannel14";
            this.txtChannel14.Size = new System.Drawing.Size(267, 15);
            this.txtChannel14.TabIndex = 34;
            // 
            // txtChannel13
            // 
            this.txtChannel13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel13.Location = new System.Drawing.Point(27, 288);
            this.txtChannel13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel13.MaxLength = 32768;
            this.txtChannel13.Name = "txtChannel13";
            this.txtChannel13.Size = new System.Drawing.Size(267, 15);
            this.txtChannel13.TabIndex = 33;
            // 
            // txtChannel12
            // 
            this.txtChannel12.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel12.Location = new System.Drawing.Point(27, 268);
            this.txtChannel12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel12.MaxLength = 32768;
            this.txtChannel12.Name = "txtChannel12";
            this.txtChannel12.Size = new System.Drawing.Size(267, 15);
            this.txtChannel12.TabIndex = 32;
            // 
            // txtChannel16
            // 
            this.txtChannel16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChannel16.Location = new System.Drawing.Point(27, 347);
            this.txtChannel16.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel16.MaxLength = 32768;
            this.txtChannel16.Name = "txtChannel16";
            this.txtChannel16.Size = new System.Drawing.Size(267, 16);
            this.txtChannel16.TabIndex = 36;
            // 
            // txtChannel3
            // 
            this.txtChannel3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel3.Location = new System.Drawing.Point(27, 91);
            this.txtChannel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel3.MaxLength = 32768;
            this.txtChannel3.Name = "txtChannel3";
            this.txtChannel3.Size = new System.Drawing.Size(267, 15);
            this.txtChannel3.TabIndex = 40;
            this.txtChannel3.TextChanged += new System.EventHandler(this.txtChannel3_TextChanged);
            // 
            // txtChannel2
            // 
            this.txtChannel2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtChannel2.Location = new System.Drawing.Point(27, 71);
            this.txtChannel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel2.MaxLength = 32768;
            this.txtChannel2.Name = "txtChannel2";
            this.txtChannel2.Size = new System.Drawing.Size(267, 16);
            this.txtChannel2.TabIndex = 41;
            this.txtChannel2.TextChanged += new System.EventHandler(this.txtChannel2_TextChanged);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(396, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupMenuItem
            // 
            this.setupMenuItem.Name = "setupMenuItem";
            this.setupMenuItem.Size = new System.Drawing.Size(61, 24);
            this.setupMenuItem.Text = "Setup";
            this.setupMenuItem.Click += new System.EventHandler(this.setupMenuItem_Click);
            // 
            // txtChannel1
            // 
            this.txtChannel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtChannel1.Location = new System.Drawing.Point(27, 52);
            this.txtChannel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel1.MaxLength = 32768;
            this.txtChannel1.Name = "txtChannel1";
            this.txtChannel1.Size = new System.Drawing.Size(267, 16);
            this.txtChannel1.TabIndex = 42;
            // 
            // txtChannel20
            // 
            this.txtChannel20.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtChannel20.Location = new System.Drawing.Point(27, 426);
            this.txtChannel20.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel20.MaxLength = 32768;
            this.txtChannel20.Name = "txtChannel20";
            this.txtChannel20.Size = new System.Drawing.Size(267, 16);
            this.txtChannel20.TabIndex = 43;
            // 
            // txtChannel17
            // 
            this.txtChannel17.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChannel17.Location = new System.Drawing.Point(27, 367);
            this.txtChannel17.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel17.MaxLength = 32768;
            this.txtChannel17.Name = "txtChannel17";
            this.txtChannel17.Size = new System.Drawing.Size(267, 16);
            this.txtChannel17.TabIndex = 44;
            // 
            // txtChannel18
            // 
            this.txtChannel18.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChannel18.Location = new System.Drawing.Point(27, 386);
            this.txtChannel18.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel18.MaxLength = 32768;
            this.txtChannel18.Name = "txtChannel18";
            this.txtChannel18.Size = new System.Drawing.Size(267, 16);
            this.txtChannel18.TabIndex = 45;
            // 
            // txtChannel19
            // 
            this.txtChannel19.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChannel19.Location = new System.Drawing.Point(27, 406);
            this.txtChannel19.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel19.MaxLength = 32768;
            this.txtChannel19.Name = "txtChannel19";
            this.txtChannel19.Size = new System.Drawing.Size(267, 16);
            this.txtChannel19.TabIndex = 46;
            // 
            // txtChannel0
            // 
            this.txtChannel0.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChannel0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtChannel0.Location = new System.Drawing.Point(27, 32);
            this.txtChannel0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChannel0.MaxLength = 32768;
            this.txtChannel0.Name = "txtChannel0";
            this.txtChannel0.Size = new System.Drawing.Size(267, 16);
            this.txtChannel0.TabIndex = 47;
            // 
            // btnF9
            // 
            this.btnF9.Location = new System.Drawing.Point(149, 492);
            this.btnF9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF9.Name = "btnF9";
            this.btnF9.Size = new System.Drawing.Size(53, 28);
            this.btnF9.TabIndex = 48;
            this.btnF9.Text = "F9";
            this.btnF9.UseVisualStyleBackColor = true;
            // 
            // btnF10
            // 
            this.btnF10.Location = new System.Drawing.Point(211, 492);
            this.btnF10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(53, 28);
            this.btnF10.TabIndex = 49;
            this.btnF10.Text = "F10";
            this.btnF10.UseVisualStyleBackColor = true;
            // 
            // btnF11
            // 
            this.btnF11.Location = new System.Drawing.Point(272, 492);
            this.btnF11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(53, 28);
            this.btnF11.TabIndex = 50;
            this.btnF11.Text = "F11";
            this.btnF11.UseVisualStyleBackColor = true;
            // 
            // btnF12
            // 
            this.btnF12.Location = new System.Drawing.Point(332, 492);
            this.btnF12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(53, 28);
            this.btnF12.TabIndex = 51;
            this.btnF12.Text = "F12";
            this.btnF12.UseVisualStyleBackColor = true;
            // 
            // chkSWL
            // 
            this.chkSWL.AutoSize = true;
            this.chkSWL.Location = new System.Drawing.Point(308, 358);
            this.chkSWL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSWL.Name = "chkSWL";
            this.chkSWL.Size = new System.Drawing.Size(58, 20);
            this.chkSWL.TabIndex = 52;
            this.chkSWL.Text = "SWL";
            this.chkSWL.UseVisualStyleBackColor = true;
            // 
            // CWExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 514);
            this.Controls.Add(this.chkSWL);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF10);
            this.Controls.Add(this.btnF9);
            this.Controls.Add(this.txtChannel0);
            this.Controls.Add(this.txtChannel19);
            this.Controls.Add(this.txtChannel18);
            this.Controls.Add(this.txtChannel17);
            this.Controls.Add(this.txtChannel20);
            this.Controls.Add(this.txtChannel1);
            this.Controls.Add(this.txtChannel2);
            this.Controls.Add(this.txtChannel3);
            this.Controls.Add(this.txtChannel16);
            this.Controls.Add(this.txtChannel15);
            this.Controls.Add(this.txtChannel14);
            this.Controls.Add(this.txtChannel13);
            this.Controls.Add(this.txtChannel12);
            this.Controls.Add(this.txtChannel11);
            this.Controls.Add(this.txtChannel10);
            this.Controls.Add(this.txtChannel9);
            this.Controls.Add(this.txtChannel8);
            this.Controls.Add(this.txtChannel7);
            this.Controls.Add(this.txtChannel6);
            this.Controls.Add(this.txtChannel5);
            this.Controls.Add(this.btnclr);
            this.Controls.Add(this.txtChannel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendNr);
            this.Controls.Add(this.txtNr);
            this.Controls.Add(this.btnSendRST);
            this.Controls.Add(this.txtRST);
            this.Controls.Add(this.btnStartMR);
            this.Controls.Add(this.btnF8);
            this.Controls.Add(this.btnF7);
            this.Controls.Add(this.btnF6);
            this.Controls.Add(this.btnF5);
            this.Controls.Add(this.btnF4);
            this.Controls.Add(this.btnF3);
            this.Controls.Add(this.btnF2);
            this.Controls.Add(this.btnF1);
            this.Controls.Add(this.btnSendCall);
            this.Controls.Add(this.txtCall);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(414, 561);
            this.MinimumSize = new System.Drawing.Size(414, 561);
            this.Name = "CWExpert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CWExpert  v24.8.23";
            this.Load += new System.EventHandler(this.CWExpert_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CWExpert_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCall;
        private System.Windows.Forms.Button btnSendCall;
        private System.Windows.Forms.Button btnF1;
        private System.Windows.Forms.Button btnF2;
        private System.Windows.Forms.Button btnF3;
        private System.Windows.Forms.Button btnF4;
        private System.Windows.Forms.Button btnF5;
        private System.Windows.Forms.Button btnF6;
        private System.Windows.Forms.Button btnF8;
        private System.Windows.Forms.Button btnF7;
        public  System.Windows.Forms.CheckBox btnStartMR;
        private System.Windows.Forms.Button btnSendRST;
        private System.Windows.Forms.TextBox txtRST;
        private System.Windows.Forms.Button btnSendNr;
        private System.Windows.Forms.TextBox txtNr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnclr;
        public System.Windows.Forms.TextBox txtChannel4;
        public System.Windows.Forms.TextBox txtChannel5;
        public System.Windows.Forms.TextBox txtChannel6;
        public System.Windows.Forms.TextBox txtChannel7;
        public System.Windows.Forms.TextBox txtChannel11;
        public System.Windows.Forms.TextBox txtChannel10;
        public System.Windows.Forms.TextBox txtChannel9;
        public System.Windows.Forms.TextBox txtChannel8;
        public System.Windows.Forms.TextBox txtChannel15;
        public System.Windows.Forms.TextBox txtChannel14;
        public System.Windows.Forms.TextBox txtChannel13;
        public System.Windows.Forms.TextBox txtChannel12;
        public System.Windows.Forms.TextBox txtChannel16;
        public System.Windows.Forms.TextBox txtChannel3;
        public System.Windows.Forms.TextBox txtChannel2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.TextBox txtChannel1;
        public System.Windows.Forms.TextBox txtChannel20;
        public System.Windows.Forms.TextBox txtChannel17;
        public System.Windows.Forms.TextBox txtChannel18;
        public System.Windows.Forms.TextBox txtChannel19;
        public System.Windows.Forms.TextBox txtChannel0;
        private System.Windows.Forms.Button btnF9;
        private System.Windows.Forms.Button btnF10;
        private System.Windows.Forms.Button btnF11;
        private System.Windows.Forms.Button btnF12;
        private System.Windows.Forms.ToolStripMenuItem setupMenuItem;
        private System.Windows.Forms.CheckBox chkSWL;
    }
}

