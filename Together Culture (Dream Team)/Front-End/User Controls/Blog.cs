using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class Blog : UserControl
    {

        private Size formOriginalSize;
        private Rectangle recpic1;
        private Rectangle recpic2;
        private Rectangle recpic3;
        private Rectangle recpic4;
        private Rectangle rectxt1;
        private Rectangle rectxt2;
        private Rectangle rectxt3;
        private Rectangle rectxt4;


        public Blog()
        {
            InitializeComponent();

            this.Resize += Form1_Resize;
            this.Resize += Form1_Reposition;

            formOriginalSize = this.Size;

            recpic1 = new Rectangle(pictureBox1.Location, pictureBox1.Size);
            recpic2 = new Rectangle(pictureBox2.Location, pictureBox2.Size);
            recpic3 = new Rectangle(pictureBox3.Location, pictureBox3.Size);
            recpic4 = new Rectangle(pictureBox4.Location, pictureBox4.Size);
            rectxt1 = new Rectangle(linkLabel1.Location, linkLabel1.Size);
            rectxt2 = new Rectangle(linkLabel2.Location, linkLabel2.Size);
            rectxt3 = new Rectangle(linkLabel3.Location, linkLabel3.Size);
            rectxt4 = new Rectangle(linkLabel4.Location, linkLabel4.Size);
        }

        // Position the components w.r.t window size
        private void Form1_Reposition(object sender, EventArgs e)
        {
            resize_Control(pictureBox1, recpic1);
            resize_Control(pictureBox2, recpic2);
            resize_Control(pictureBox3, recpic3);
            resize_Control(pictureBox4, recpic4);
            resize_Control(linkLabel1, rectxt1);
            resize_Control(linkLabel2, rectxt2);
            resize_Control(linkLabel3, rectxt3);
            resize_Control(linkLabel4, rectxt4);

        }

        // Resize the Text w.r.t window size
        private void Form1_Resize(object sender, EventArgs e)
        {
            float newSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 60f; // Adjust the divisor as needed
            linkLabel1.Font = new Font(linkLabel1.Font.FontFamily, newSize, linkLabel1.Font.Style);
            linkLabel2.Font = new Font(linkLabel2.Font.FontFamily, newSize, linkLabel2.Font.Style);
            linkLabel3.Font = new Font(linkLabel3.Font.FontFamily, newSize, linkLabel3.Font.Style);
            linkLabel4.Font = new Font(linkLabel4.Font.FontFamily, newSize, linkLabel4.Font.Style);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String url = "https://www.togetherculture.com/blog/we-are-together-culture-meet-niketa";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Ensures compatibility with modern systems
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the link: {ex.Message}");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String url = "https://www.togetherculture.com/blog/we-are-together-culture-meet-francesco";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Ensures compatibility with modern systems
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the link: {ex.Message}");
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String url = "https://www.togetherculture.com/blog/we-are-together-culture-meet-vicky";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Ensures compatibility with modern systems
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the link: {ex.Message}");
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String url = "https://www.togetherculture.com/blog/we-are-together-culture-meet-bel";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Ensures compatibility with modern systems
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the link: {ex.Message}");
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Black;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Black;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Black;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Black;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }
    }
}
