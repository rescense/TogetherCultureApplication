namespace Together_Culture__Dream_Team_.Front_End.Screens.Admin_Forms.User_Controls
{
    partial class ActionsSearchUsers
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
            confirmActionBtn = new Button();
            removeUsersRadioBtn = new RadioButton();
            addTagsRadioBtn = new RadioButton();
            seeEventsRadioBtn = new RadioButton();
            addTagPanel = new Panel();
            actionsSearchUsersGradientPanel.SuspendLayout();
            SuspendLayout();
            // 
            // actionsSearchUsersGradientPanel
            // 
            actionsSearchUsersGradientPanel.Controls.Add(confirmActionBtn);
            actionsSearchUsersGradientPanel.Controls.Add(removeUsersRadioBtn);
            actionsSearchUsersGradientPanel.Controls.Add(addTagsRadioBtn);
            actionsSearchUsersGradientPanel.Controls.Add(seeEventsRadioBtn);
            actionsSearchUsersGradientPanel.CustomizableEdges = customizableEdges1;
            actionsSearchUsersGradientPanel.FillColor = Color.Firebrick;
            actionsSearchUsersGradientPanel.FillColor2 = Color.Salmon;
            actionsSearchUsersGradientPanel.FillColor3 = Color.Firebrick;
            actionsSearchUsersGradientPanel.FillColor4 = Color.RosyBrown;
            actionsSearchUsersGradientPanel.Location = new Point(0, 0);
            actionsSearchUsersGradientPanel.Name = "actionsSearchUsersGradientPanel";
            actionsSearchUsersGradientPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            actionsSearchUsersGradientPanel.Size = new Size(181, 155);
            actionsSearchUsersGradientPanel.TabIndex = 2;
            // 
            // confirmActionBtn
            // 
            confirmActionBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            confirmActionBtn.BackColor = Color.Black;
            confirmActionBtn.FlatAppearance.BorderSize = 0;
            confirmActionBtn.FlatStyle = FlatStyle.Flat;
            confirmActionBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            confirmActionBtn.ForeColor = Color.White;
            confirmActionBtn.Location = new Point(30, 122);
            confirmActionBtn.Name = "confirmActionBtn";
            confirmActionBtn.Size = new Size(121, 24);
            confirmActionBtn.TabIndex = 3;
            confirmActionBtn.Text = "Confirm";
            confirmActionBtn.UseVisualStyleBackColor = false;
            confirmActionBtn.Click += confirmActionBtn_Click;
            // 
            // removeUsersRadioBtn
            // 
            removeUsersRadioBtn.AutoSize = true;
            removeUsersRadioBtn.BackColor = Color.Transparent;
            removeUsersRadioBtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            removeUsersRadioBtn.Location = new Point(13, 82);
            removeUsersRadioBtn.Name = "removeUsersRadioBtn";
            removeUsersRadioBtn.Size = new Size(158, 34);
            removeUsersRadioBtn.TabIndex = 2;
            removeUsersRadioBtn.TabStop = true;
            removeUsersRadioBtn.Text = "Remove User";
            removeUsersRadioBtn.UseVisualStyleBackColor = false;
            // 
            // addTagsRadioBtn
            // 
            addTagsRadioBtn.AutoSize = true;
            addTagsRadioBtn.BackColor = Color.Transparent;
            addTagsRadioBtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            addTagsRadioBtn.Location = new Point(13, 42);
            addTagsRadioBtn.Name = "addTagsRadioBtn";
            addTagsRadioBtn.Size = new Size(112, 34);
            addTagsRadioBtn.TabIndex = 1;
            addTagsRadioBtn.TabStop = true;
            addTagsRadioBtn.Text = "Add Tag";
            addTagsRadioBtn.UseVisualStyleBackColor = false;
            // 
            // seeEventsRadioBtn
            // 
            seeEventsRadioBtn.AutoSize = true;
            seeEventsRadioBtn.BackColor = Color.Transparent;
            seeEventsRadioBtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            seeEventsRadioBtn.Location = new Point(13, 3);
            seeEventsRadioBtn.Name = "seeEventsRadioBtn";
            seeEventsRadioBtn.Size = new Size(134, 34);
            seeEventsRadioBtn.TabIndex = 0;
            seeEventsRadioBtn.TabStop = true;
            seeEventsRadioBtn.Text = "See Events";
            seeEventsRadioBtn.UseVisualStyleBackColor = false;
            // 
            // addTagPanel
            // 
            addTagPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addTagPanel.BackColor = Color.White;
            addTagPanel.Location = new Point(0, 155);
            addTagPanel.Name = "addTagPanel";
            addTagPanel.Size = new Size(181, 84);
            addTagPanel.TabIndex = 47;
            // 
            // ActionsSearchUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(addTagPanel);
            Controls.Add(actionsSearchUsersGradientPanel);
            Name = "ActionsSearchUsers";
            Size = new Size(181, 239);
            actionsSearchUsersGradientPanel.ResumeLayout(false);
            actionsSearchUsersGradientPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel actionsSearchUsersGradientPanel;
        private RadioButton seeEventsRadioBtn;
        private RadioButton removeUsersRadioBtn;
        private RadioButton addTagsRadioBtn;
        private Button confirmActionBtn;
        private Panel addTagPanel;
    }
}
