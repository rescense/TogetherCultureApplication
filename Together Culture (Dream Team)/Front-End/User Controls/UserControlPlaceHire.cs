using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class UserControlPlaceHire : UserControl
    {

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle rectxt1;
        private Rectangle rectxt2;

        public UserControlPlaceHire()
        {
            InitializeComponent();

            this.Resize += Form1_Resize;
            this.Resize += Form1_Reposition;

            formOriginalSize = this.Size;

            recBut1 = new Rectangle(pictureBox1.Location, pictureBox1.Size);
            recBut2 = new Rectangle(guna2Button1.Location, guna2Button1.Size);
            rectxt1 = new Rectangle(label1.Location, label1.Size);
            rectxt2 = new Rectangle(label2.Location, label2.Size);
        }

        private void UserControlPlaceHire_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Reposition(object sender, EventArgs e)
        {
            resize_Control(pictureBox1, recBut1);
            resize_Control(guna2Button1, recBut2);
            resize_Control(label1, rectxt1);
            resize_Control(label2, rectxt2);

        }
        // Resize the components w.r.t window size
        private void Form1_Resize(object sender, EventArgs e)
        {
            float newSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 40f; // Adjust the divisor as needed
            label2.Font = new Font(label2.Font.FontFamily, newSize, label2.Font.Style);
            label1.Font = new Font(label1.Font.FontFamily, newSize, label1.Font.Style);
        }
        // Resize Control cordinates and calculations
        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
