﻿namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls
{
    partial class SelectedDetailsUserControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2CustomGradientPanel4 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            label3 = new Label();
            label2 = new Label();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2CustomGradientPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2CustomGradientPanel4
            // 
            guna2CustomGradientPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2CustomGradientPanel4.Controls.Add(label3);
            guna2CustomGradientPanel4.Controls.Add(label2);
            guna2CustomGradientPanel4.Controls.Add(guna2CirclePictureBox1);
            guna2CustomGradientPanel4.CustomizableEdges = customizableEdges2;
            guna2CustomGradientPanel4.FillColor = Color.FromArgb(64, 0, 30);
            guna2CustomGradientPanel4.FillColor2 = Color.FromArgb(64, 0, 60);
            guna2CustomGradientPanel4.FillColor3 = Color.FromArgb(64, 0, 60);
            guna2CustomGradientPanel4.FillColor4 = Color.FromArgb(64, 0, 60);
            guna2CustomGradientPanel4.Location = new Point(0, 0);
            guna2CustomGradientPanel4.Name = "guna2CustomGradientPanel4";
            guna2CustomGradientPanel4.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2CustomGradientPanel4.Size = new Size(583, 524);
            guna2CustomGradientPanel4.TabIndex = 36;
            guna2CustomGradientPanel4.Paint += guna2CustomGradientPanel4_Paint;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Firebrick;
            label3.Location = new Point(335, 155);
            label3.Name = "label3";
            label3.Size = new Size(213, 299);
            label3.TabIndex = 39;
            label3.Text = "Member Name\r\n\r\nAssistance Offered/\r\nRequested\r\n\r\nAssistance Category\r\n\r\nTime Required\r\n\r\nDescription\r\n\r\n\r\nContact Preference";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(30, 155);
            label2.Name = "label2";
            label2.Size = new Size(213, 299);
            label2.TabIndex = 38;
            label2.Text = "Member Name\r\n\r\nAssistance Offered/\r\nRequested\r\n\r\nAssistance Category\r\n\r\nTime Required\r\n\r\nDescription\r\n\r\n\r\nContact Preference";
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2CirclePictureBox1.BackColor = Color.Transparent;
            guna2CirclePictureBox1.Image = Properties.Resources.istockphoto_841152680_1024x10242;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(214, 18);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(160, 119);
            guna2CirclePictureBox1.TabIndex = 37;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // SelectedDetailsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2CustomGradientPanel4);
            Name = "SelectedDetailsUserControl";
            Size = new Size(583, 524);
            guna2CustomGradientPanel4.ResumeLayout(false);
            guna2CustomGradientPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel4;
        private Label label3;
        private Label label2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
    }
}