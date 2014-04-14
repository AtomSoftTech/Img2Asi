namespace Image2Hex
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
            this.imgMain = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdFormat = new System.Windows.Forms.ComboBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imgMain
            // 
            this.imgMain.Location = new System.Drawing.Point(12, 41);
            this.imgMain.Name = "imgMain";
            this.imgMain.Size = new System.Drawing.Size(480, 272);
            this.imgMain.TabIndex = 0;
            this.imgMain.TabStop = false;
            this.imgMain.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.imgMain_LoadCompleted);
            this.imgMain.SizeChanged += new System.EventHandler(this.imgMain_SizeChanged);
            this.imgMain.Click += new System.EventHandler(this.imgMain_Click);
            this.imgMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgMain_MouseMove);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 7);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(12, 333);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtUser.Size = new System.Drawing.Size(966, 332);
            this.txtUser.TabIndex = 2;
            this.txtUser.Visible = false;
            this.txtUser.WordWrap = false;
            this.txtUser.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Format";
            // 
            // cmdFormat
            // 
            this.cmdFormat.FormattingEnabled = true;
            this.cmdFormat.Items.AddRange(new object[] {
            "RGB565"});
            this.cmdFormat.Location = new System.Drawing.Point(290, 9);
            this.cmdFormat.Name = "cmdFormat";
            this.cmdFormat.Size = new System.Drawing.Size(121, 21);
            this.cmdFormat.TabIndex = 4;
            this.cmdFormat.Text = "RGB565";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(93, 7);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 23);
            this.btnGen.TabIndex = 5;
            this.btnGen.Text = "Generate";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(248, 218);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 95);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 327);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.cmdFormat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.imgMain);
            this.Name = "Form1";
            this.Text = "AtomSoftTech - Image2Hex";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgMain;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmdFormat;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

