namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label7 = new Label();
            pictureBox2 = new PictureBox();
            progressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Clash Grotesk", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(211, 142);
            label7.Name = "label7";
            label7.Size = new Size(194, 126);
            label7.TabIndex = 18;
            label7.Text = "Together\r\nCulture\r\nCambridge";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(455, 142);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(127, 126);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.CustomizableEdges = customizableEdges1;
            progressBar1.Location = new Point(12, 408);
            progressBar1.Name = "progressBar1";
            progressBar1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            progressBar1.Size = new Size(776, 30);
            progressBar1.TabIndex = 19;
            progressBar1.Text = "guna2ProgressBar1";
            progressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Location = new Point(411, 127);
            panel1.Name = "panel1";
            panel1.Size = new Size(4, 155);
            panel1.TabIndex = 20;
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(progressBar1);
            Controls.Add(label7);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Welcome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Welcome";
            Load += Welcome_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar1;
        private Panel panel1;
    }
}