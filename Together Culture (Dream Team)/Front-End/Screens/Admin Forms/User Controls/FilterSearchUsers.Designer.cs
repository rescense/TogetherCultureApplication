namespace Together_Culture__Dream_Team_.Front_End.Screens.Admin_Forms.User_Controls
{
    partial class FilterSearchUsers
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
            actionsSearchUsersGradientPanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            nameDescRadioBtn = new RadioButton();
            nameAscRadioBtn = new RadioButton();
            actionsSearchUsersGradientPanel.SuspendLayout();
            SuspendLayout();
            // 
            // actionsSearchUsersGradientPanel
            // 
            actionsSearchUsersGradientPanel.Controls.Add(nameDescRadioBtn);
            actionsSearchUsersGradientPanel.Controls.Add(nameAscRadioBtn);
            actionsSearchUsersGradientPanel.CustomizableEdges = customizableEdges1;
            actionsSearchUsersGradientPanel.FillColor = Color.Firebrick;
            actionsSearchUsersGradientPanel.FillColor2 = Color.Salmon;
            actionsSearchUsersGradientPanel.FillColor3 = Color.Firebrick;
            actionsSearchUsersGradientPanel.FillColor4 = Color.RosyBrown;
            actionsSearchUsersGradientPanel.Location = new Point(0, 0);
            actionsSearchUsersGradientPanel.Name = "actionsSearchUsersGradientPanel";
            actionsSearchUsersGradientPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            actionsSearchUsersGradientPanel.Size = new Size(181, 81);
            actionsSearchUsersGradientPanel.TabIndex = 3;
            // 
            // nameDescRadioBtn
            // 
            nameDescRadioBtn.AutoSize = true;
            nameDescRadioBtn.BackColor = Color.Transparent;
            nameDescRadioBtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            nameDescRadioBtn.Location = new Point(13, 42);
            nameDescRadioBtn.Name = "nameDescRadioBtn";
            nameDescRadioBtn.Size = new Size(67, 34);
            nameDescRadioBtn.TabIndex = 1;
            nameDescRadioBtn.TabStop = true;
            nameDescRadioBtn.Text = "Z-A";
            nameDescRadioBtn.UseVisualStyleBackColor = false;
            nameDescRadioBtn.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // nameAscRadioBtn
            // 
            nameAscRadioBtn.AutoSize = true;
            nameAscRadioBtn.BackColor = Color.Transparent;
            nameAscRadioBtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            nameAscRadioBtn.Location = new Point(13, 3);
            nameAscRadioBtn.Name = "nameAscRadioBtn";
            nameAscRadioBtn.Size = new Size(67, 34);
            nameAscRadioBtn.TabIndex = 0;
            nameAscRadioBtn.TabStop = true;
            nameAscRadioBtn.Text = "A-Z";
            nameAscRadioBtn.UseVisualStyleBackColor = false;
            nameAscRadioBtn.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // FilterSearchUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(actionsSearchUsersGradientPanel);
            Name = "FilterSearchUsers";
            Size = new Size(181, 81);
            actionsSearchUsersGradientPanel.ResumeLayout(false);
            actionsSearchUsersGradientPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel actionsSearchUsersGradientPanel;
        private RadioButton nameDescRadioBtn;
        private RadioButton nameAscRadioBtn;
    }
}
