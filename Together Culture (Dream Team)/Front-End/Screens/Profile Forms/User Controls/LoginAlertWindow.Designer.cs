namespace Together_Culture__Dream_Team_.Front_End.User_Controls
{
    partial class LoginAlertWindow
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            label1 = new Label();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnOk = new Guna.UI2.WinForms.Guna2Button();
            guna2CustomGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2CustomGradientPanel1.Controls.Add(label1);
            guna2CustomGradientPanel1.Controls.Add(guna2HtmlLabel1);
            guna2CustomGradientPanel1.Controls.Add(btnOk);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges3;
            guna2CustomGradientPanel1.FillColor = Color.DarkRed;
            guna2CustomGradientPanel1.FillColor2 = Color.LightCoral;
            guna2CustomGradientPanel1.FillColor3 = Color.Maroon;
            guna2CustomGradientPanel1.FillColor4 = Color.Firebrick;
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Margin = new Padding(3, 2, 3, 2);
            guna2CustomGradientPanel1.MinimumSize = new Size(229, 174);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2CustomGradientPanel1.Size = new Size(333, 240);
            guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(31, 73);
            label1.Name = "label1";
            label1.Size = new Size(279, 25);
            label1.TabIndex = 1;
            label1.Text = "No Login Alerts at the moment";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(0, 0);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(3, 2);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = null;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnOk.CustomizableEdges = customizableEdges1;
            btnOk.DisabledState.BorderColor = Color.DarkGray;
            btnOk.DisabledState.CustomBorderColor = Color.DarkGray;
            btnOk.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnOk.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnOk.FillColor = Color.DodgerBlue;
            btnOk.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(108, 162);
            btnOk.Margin = new Padding(3, 2, 3, 2);
            btnOk.MinimumSize = new Size(58, 37);
            btnOk.Name = "btnOk";
            btnOk.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnOk.Size = new Size(111, 47);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.Click += btnOk_Click;
            // 
            // LoginAlertWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2CustomGradientPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LoginAlertWindow";
            Size = new Size(333, 240);
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2Button btnOk;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Label label1;
    }
}
