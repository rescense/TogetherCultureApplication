namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    partial class Shop
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shop));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox5 = new PictureBox();
            label20 = new Label();
            label19 = new Label();
            pictureBox2 = new PictureBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.BackColor = Color.LightGray;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(pictureBox5);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label19);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1446, 147);
            panel2.TabIndex = 23;
            panel2.Paint += panel2_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(2985, 94);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(193, 119);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.None;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(3622, 106);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(193, 119);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.None;
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.Location = new Point(423, 99);
            label20.Name = "label20";
            label20.Size = new Size(605, 21);
            label20.TabIndex = 8;
            label20.Text = "For every book bought from our shop, Together Culture earns a 10% commission rate.";
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.None;
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(645, 18);
            label19.Name = "label19";
            label19.Size = new Size(143, 65);
            label19.TabIndex = 7;
            label19.Text = "Shop";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(773, 147);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(673, 470);
            pictureBox2.TabIndex = 24;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Black;
            guna2Button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(100, 483);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(246, 87);
            guna2Button1.TabIndex = 25;
            guna2Button1.Text = "Shop Now";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(49, 182);
            label1.Name = "label1";
            label1.Size = new Size(620, 64);
            label1.TabIndex = 26;
            label1.Text = "You can order your printed copy of the Living Book here,\r\nor buy it in person at Together Culture. ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(49, 267);
            label2.Name = "label2";
            label2.Size = new Size(663, 75);
            label2.TabIndex = 27;
            label2.Text = "Together Culture member and illustrator Lele Saa has designed this collection\r\nbased on Together Culture's vision of a more inclusive and ecological \r\ncreative economy. ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(49, 360);
            label4.Name = "label4";
            label4.Size = new Size(525, 42);
            label4.TabIndex = 28;
            label4.Text = "Our 'Just People' tees are a reminder of the Together Culture community's \r\ncreative intent. All proceeds go towards building our permanent home.";
            // 
            // Shop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2Button1);
            Controls.Add(pictureBox2);
            Controls.Add(panel2);
            Name = "Shop";
            Size = new Size(1446, 614);
            Load += Shop_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox5;
        private Label label20;
        private Label label19;
        private PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label label1;
        private Label label2;
        private Label label4;
    }
}
