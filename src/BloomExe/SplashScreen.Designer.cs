﻿namespace Bloom
{
    partial class SplashScreen
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this._fadeOutTimer = new System.Windows.Forms.Timer(this.components);
			this._longVersionInfo = new System.Windows.Forms.Label();
			this._feedbackStatusLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this._shortVersionLabel = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this._channelLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::Bloom.Properties.Resources.BloomDarkGrey300_ish;
			this.pictureBox1.Location = new System.Drawing.Point(54, 53);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(302, 108);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// _fadeOutTimer
			// 
			this._fadeOutTimer.Tick += new System.EventHandler(this._fadeOutTimer_Tick);
			// 
			// _longVersionInfo
			// 
			this._longVersionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._longVersionInfo.AutoSize = true;
			this._longVersionInfo.BackColor = System.Drawing.Color.Transparent;
			this._longVersionInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._longVersionInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this._longVersionInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this._longVersionInfo.Location = new System.Drawing.Point(51, 220);
			this._longVersionInfo.Name = "_longVersionInfo";
			this._longVersionInfo.Size = new System.Drawing.Size(70, 15);
			this._longVersionInfo.TabIndex = 13;
			this._longVersionInfo.Text = "Version Info";
			// 
			// _feedbackStatusLabel
			// 
			this._feedbackStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this._feedbackStatusLabel.AutoSize = true;
			this._feedbackStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._feedbackStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(143)))), ((int)(((byte)(189)))));
			this._feedbackStatusLabel.Location = new System.Drawing.Point(52, 202);
			this._feedbackStatusLabel.Name = "_feedbackStatusLabel";
			this._feedbackStatusLabel.Size = new System.Drawing.Size(105, 15);
			this._feedbackStatusLabel.TabIndex = 17;
			this._feedbackStatusLabel.Text = "Feedback Disabled";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(51, 244);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(162, 15);
			this.label2.TabIndex = 19;
			this.label2.Text = "© 2011-2015 SIL International";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this._shortVersionLabel);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(209, 46);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(157, 34);
			this.flowLayoutPanel1.TabIndex = 22;
			// 
			// _shortVersionLabel
			// 
			this._shortVersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._shortVersionLabel.AutoSize = true;
			this._shortVersionLabel.Font = new System.Drawing.Font("Segoe UI", 20F);
			this._shortVersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(86)))), ((int)(((byte)(73)))));
			this._shortVersionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this._shortVersionLabel.Location = new System.Drawing.Point(38, 0);
			this._shortVersionLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this._shortVersionLabel.Name = "_shortVersionLabel";
			this._shortVersionLabel.Size = new System.Drawing.Size(119, 37);
			this._shortVersionLabel.TabIndex = 23;
			this._shortVersionLabel.Text = "19.8.710";
			this._shortVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox2.Image = global::Bloom.Properties.Resources.SIL_Logo_2014Small1;
			this.pictureBox2.Location = new System.Drawing.Point(284, 202);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(72, 80);
			this.pictureBox2.TabIndex = 0;
			this.pictureBox2.TabStop = false;
			// 
			// _channelLabel
			// 
			this._channelLabel.AutoSize = true;
			this._channelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._channelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(86)))), ((int)(((byte)(73)))));
			this._channelLabel.Location = new System.Drawing.Point(48, 164);
			this._channelLabel.Margin = new System.Windows.Forms.Padding(0);
			this._channelLabel.Name = "_channelLabel";
			this._channelLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._channelLabel.Size = new System.Drawing.Size(120, 36);
			this._channelLabel.TabIndex = 25;
			this._channelLabel.Text = "channel";
			this._channelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SplashScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
			this.ClientSize = new System.Drawing.Size(412, 309);
			this.ControlBox = false;
			this.Controls.Add(this._channelLabel);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._feedbackStatusLabel);
			this.Controls.Add(this._longVersionInfo);
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MinimizeBox = false;
			this.Name = "SplashScreen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bloom";
			this.Load += new System.EventHandler(this.SplashScreen_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SplashScreen_Paint);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer _fadeOutTimer;
		private System.Windows.Forms.Label _longVersionInfo;
		private System.Windows.Forms.Label _feedbackStatusLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label _shortVersionLabel;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label _channelLabel;
    }
}