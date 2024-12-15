namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    partial class SideMenuBar
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnAdminLogin = new Guna.UI2.WinForms.Guna2Button();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            tableLayoutPanel1.SuspendLayout();
            guna2CustomGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnAdminLogin, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(194, 98);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAdminLogin
            // 
            btnAdminLogin.CustomizableEdges = customizableEdges1;
            btnAdminLogin.DisabledState.BorderColor = Color.DarkGray;
            btnAdminLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdminLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdminLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdminLogin.FillColor = Color.Transparent;
            btnAdminLogin.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdminLogin.ForeColor = Color.White;
            btnAdminLogin.Location = new Point(3, 3);
            btnAdminLogin.Name = "btnAdminLogin";
            btnAdminLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdminLogin.Size = new Size(182, 92);
            btnAdminLogin.TabIndex = 0;
            btnAdminLogin.Text = "Admin";
            btnAdminLogin.Click += btnAdminLogin_Click;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(tableLayoutPanel1);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges3;
            guna2CustomGradientPanel1.FillColor = Color.Firebrick;
            guna2CustomGradientPanel1.FillColor2 = Color.Salmon;
            guna2CustomGradientPanel1.FillColor3 = Color.Firebrick;
            guna2CustomGradientPanel1.FillColor4 = Color.RosyBrown;
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2CustomGradientPanel1.Size = new Size(202, 104);
            guna2CustomGradientPanel1.TabIndex = 1;
            // 
            // SideMenuBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2CustomGradientPanel1);
            Name = "SideMenuBar";
            Size = new Size(197, 103);
            tableLayoutPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnAdminLogin;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
    }
}
