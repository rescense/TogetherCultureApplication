using System.Diagnostics;

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

            // Attach resize event handlers
            this.Resize += Form1_Resize;
            this.Resize += Form1_Reposition;

            formOriginalSize = this.Size;

            // Store initial positions and sizes
            recpic1 = new Rectangle(pictureBox1.Location, pictureBox1.Size);
            recpic2 = new Rectangle(pictureBox2.Location, pictureBox2.Size);
            recpic3 = new Rectangle(pictureBox3.Location, pictureBox3.Size);
            recpic4 = new Rectangle(pictureBox4.Location, pictureBox4.Size);
            rectxt1 = new Rectangle(linkLabel1.Location, linkLabel1.Size);
            rectxt2 = new Rectangle(linkLabel2.Location, linkLabel2.Size);
            rectxt3 = new Rectangle(linkLabel3.Location, linkLabel3.Size);
            rectxt4 = new Rectangle(linkLabel4.Location, linkLabel4.Size);
        }

        // Dynamically reposition components
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

        // Dynamically resize text
        private void Form1_Resize(object sender, EventArgs e)
        {
            float newSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 60f; // Adjust as needed

            UpdateFontSize(linkLabel1, newSize);
            UpdateFontSize(linkLabel2, newSize);
            UpdateFontSize(linkLabel3, newSize);
            UpdateFontSize(linkLabel4, newSize);
        }

        // Update the font size of a control
        private void UpdateFontSize(LinkLabel label, float newSize)
        {
            label.Font = new Font(label.Font.FontFamily, newSize, label.Font.Style);
        }

        // Dynamically resize and reposition a control
        private void resize_Control(Control control, Rectangle originalRect)
        {
            float xRatio = (float)this.Width / formOriginalSize.Width;
            float yRatio = (float)this.Height / formOriginalSize.Height;

            int newX = (int)(originalRect.X * xRatio);
            int newY = (int)(originalRect.Y * yRatio);
            int newWidth = (int)(originalRect.Width * xRatio);
            int newHeight = (int)(originalRect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }

        // Opens the specified URL in the default browser
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the link: {ex.Message}");
            }
        }

        // Event handlers for link clicks
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://www.togetherculture.com/blog/we-are-together-culture-meet-niketa");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://www.togetherculture.com/blog/we-are-together-culture-meet-francesco");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://www.togetherculture.com/blog/we-are-together-culture-meet-vicky");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://www.togetherculture.com/blog/we-are-together-culture-meet-bel");
        }

        // Event handlers for mouse hover effects on pictures
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
