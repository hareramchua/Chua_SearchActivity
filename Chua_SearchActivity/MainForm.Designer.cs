namespace Chua_SearchActivity
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
            this.buttonAbout = new System.Windows.Forms.Button();
            this.lblPathCaption = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.bDraw = new System.Windows.Forms.RadioButton();
            this.bFind = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(619, 341);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(146, 32);
            this.buttonAbout.TabIndex = 16;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // lblPathCaption
            // 
            this.lblPathCaption.AutoSize = true;
            this.lblPathCaption.Location = new System.Drawing.Point(642, 306);
            this.lblPathCaption.Name = "lblPathCaption";
            this.lblPathCaption.Size = new System.Drawing.Size(0, 16);
            this.lblPathCaption.TabIndex = 15;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(653, 138);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 16);
            this.lblPath.TabIndex = 14;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(619, 379);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(146, 30);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(619, 306);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(146, 30);
            this.buttonReset.TabIndex = 12;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.bDraw);
            this.groupBoxSettings.Controls.Add(this.bFind);
            this.groupBoxSettings.Location = new System.Drawing.Point(604, 42);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(181, 74);
            this.groupBoxSettings.TabIndex = 11;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // bDraw
            // 
            this.bDraw.AutoSize = true;
            this.bDraw.Location = new System.Drawing.Point(15, 21);
            this.bDraw.Name = "bDraw";
            this.bDraw.Size = new System.Drawing.Size(123, 20);
            this.bDraw.TabIndex = 1;
            this.bDraw.TabStop = true;
            this.bDraw.Text = "Draw Obstacles";
            this.bDraw.UseVisualStyleBackColor = true;
            this.bDraw.CheckedChanged += new System.EventHandler(this.bDraw_CheckedChanged);
            // 
            // bFind
            // 
            this.bFind.AutoSize = true;
            this.bFind.Location = new System.Drawing.Point(15, 47);
            this.bFind.Name = "bFind";
            this.bFind.Size = new System.Drawing.Size(84, 20);
            this.bFind.TabIndex = 2;
            this.bFind.TabStop = true;
            this.bFind.Text = "Find Path";
            this.bFind.UseVisualStyleBackColor = true;
            this.bFind.CheckedChanged += new System.EventHandler(this.bFind_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(540, 424);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 458);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.lblPathCaption);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Label lblPathCaption;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.RadioButton bDraw;
        private System.Windows.Forms.RadioButton bFind;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}