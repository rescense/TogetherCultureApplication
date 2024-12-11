namespace Together_Culture__Dream_Team_.Front_End.Screens.Admin_Forms.User_Controls
{
    partial class AddTag
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
            addTagsGradientPanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            confirmAddingTagBtn = new Button();
            addTagTxtBox = new TextBox();
            addTagsGradientPanel.SuspendLayout();
            SuspendLayout();
            // 
            // addTagsGradientPanel
            // 
            addTagsGradientPanel.Controls.Add(confirmAddingTagBtn);
            addTagsGradientPanel.Controls.Add(addTagTxtBox);
            addTagsGradientPanel.CustomizableEdges = customizableEdges1;
            addTagsGradientPanel.FillColor = Color.Firebrick;
            addTagsGradientPanel.FillColor2 = Color.Salmon;
            addTagsGradientPanel.FillColor3 = Color.Firebrick;
            addTagsGradientPanel.FillColor4 = Color.RosyBrown;
            addTagsGradientPanel.Location = new Point(0, 0);
            addTagsGradientPanel.Name = "addTagsGradientPanel";
            addTagsGradientPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            addTagsGradientPanel.Size = new Size(181, 84);
            addTagsGradientPanel.TabIndex = 4;
            // 
            // confirmAddingTagBtn
            // 
            confirmAddingTagBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            confirmAddingTagBtn.BackColor = Color.Black;
            confirmAddingTagBtn.FlatAppearance.BorderSize = 0;
            confirmAddingTagBtn.FlatStyle = FlatStyle.Flat;
            confirmAddingTagBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            confirmAddingTagBtn.ForeColor = Color.White;
            confirmAddingTagBtn.Location = new Point(33, 47);
            confirmAddingTagBtn.Name = "confirmAddingTagBtn";
            confirmAddingTagBtn.Size = new Size(121, 24);
            confirmAddingTagBtn.TabIndex = 4;
            confirmAddingTagBtn.Text = "Confirm";
            confirmAddingTagBtn.UseVisualStyleBackColor = false;
            confirmAddingTagBtn.Click += AddTagButton_Click;
            // 
            // addTagTxtBox
            // 
            addTagTxtBox.Location = new Point(5, 12);
            addTagTxtBox.Name = "addTagTxtBox";
            addTagTxtBox.Size = new Size(171, 23);
            addTagTxtBox.TabIndex = 0;
            addTagTxtBox.Text = "Type your tag...";
            // 
            // AddTag
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(addTagsGradientPanel);
            Name = "AddTag";
            Size = new Size(181, 84);
            addTagsGradientPanel.ResumeLayout(false);
            addTagsGradientPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel addTagsGradientPanel;
        public TextBox addTagTxtBox;
        private Button confirmAddingTagBtn;
    }
}
