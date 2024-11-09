namespace togther_Culture
{
    partial class eventsBooking
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
            panel1 = new Panel();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            Cambridge = new Label();
            Culture = new Label();
            Together = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(Cambridge);
            panel1.Controls.Add(Culture);
            panel1.Controls.Add(Together);
            panel1.Location = new Point(1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1423, 193);
            panel1.TabIndex = 2;
            panel1.Paint += headerPanel;
            // 
            // button6
            // 
            button6.BackColor = Color.Maroon;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Microsoft JhengHei UI", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button6.ForeColor = SystemColors.Control;
            button6.Location = new Point(1160, 80);
            button6.Name = "button6";
            button6.Size = new Size(167, 79);
            button6.TabIndex = 8;
            button6.Text = "Profile";
            button6.UseVisualStyleBackColor = false;
            button6.Click += profileBtn;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.Control;
            button5.Location = new Point(928, 116);
            button5.Name = "button5";
            button5.Size = new Size(168, 43);
            button5.TabIndex = 7;
            button5.Text = "My Modules";
            button5.UseVisualStyleBackColor = true;
            button5.Click += myModulesBtn;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.Control;
            button4.Location = new Point(728, 116);
            button4.Name = "button4";
            button4.Size = new Size(150, 43);
            button4.TabIndex = 6;
            button4.Text = "Skill Share";
            button4.UseVisualStyleBackColor = true;
            button4.Click += skillShareBtn;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.Control;
            button3.Location = new Point(595, 118);
            button3.Name = "button3";
            button3.Size = new Size(104, 38);
            button3.TabIndex = 5;
            button3.Text = "Events";
            button3.UseVisualStyleBackColor = true;
            button3.Click += eventsBtn;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(436, 116);
            button2.Name = "button2";
            button2.Size = new Size(123, 43);
            button2.TabIndex = 4;
            button2.Text = "For you";
            button2.UseVisualStyleBackColor = true;
            button2.Click += forYouBtn;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(257, 116);
            button1.Name = "button1";
            button1.Size = new Size(150, 43);
            button1.TabIndex = 3;
            button1.Text = "Chat Space";
            button1.UseVisualStyleBackColor = true;
            button1.Click += chatSpaceBtn;
            // 
            // Cambridge
            // 
            Cambridge.AutoSize = true;
            Cambridge.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Cambridge.ForeColor = Color.White;
            Cambridge.Location = new Point(36, 116);
            Cambridge.Name = "Cambridge";
            Cambridge.Size = new Size(166, 36);
            Cambridge.TabIndex = 2;
            Cambridge.Text = "Cambridge";
            Cambridge.Click += Cambridge_Click;
            // 
            // Culture
            // 
            Culture.AutoSize = true;
            Culture.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Culture.ForeColor = Color.DarkRed;
            Culture.Location = new Point(36, 80);
            Culture.Name = "Culture";
            Culture.Size = new Size(116, 36);
            Culture.TabIndex = 1;
            Culture.Text = "Culture";
            Culture.Click += Culture_Click;
            // 
            // Together
            // 
            Together.AutoSize = true;
            Together.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Together.ForeColor = Color.DarkRed;
            Together.Location = new Point(36, 44);
            Together.Name = "Together";
            Together.Size = new Size(140, 36);
            Together.TabIndex = 0;
            Together.Text = "Together";
            Together.Click += Together_Click;
            // 
            // eventsBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1422, 977);
            Controls.Add(panel1);
            Name = "eventsBooking";
            Text = "Events Booking";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label Cambridge;
        private Label Culture;
        private Label Together;
    }
}