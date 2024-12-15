using System.Diagnostics;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class AboutUs : UserControl
    {
        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle rectxt1;
        private Rectangle rectxt2;
        private Rectangle rectxt3;
        private Rectangle rectxt4;

        public AboutUs()
        {
            InitializeComponent();

            // Initialize form and component sizes
            this.Resize += Form1_Resize;
            this.Resize += Form1_Reposition;

            formOriginalSize = this.Size;

            recBut1 = new Rectangle(pictureBox3.Location, pictureBox3.Size);
            recBut2 = new Rectangle(guna2Button1.Location, guna2Button1.Size);
            rectxt1 = new Rectangle(label1.Location, label1.Size);
            rectxt2 = new Rectangle(label2.Location, label2.Size);
            rectxt3 = new Rectangle(label3.Location, label3.Size);
            rectxt4 = new Rectangle(label4.Location, label4.Size);
        }

        // Reposition components dynamically based on window size
        private void Form1_Reposition(object sender, EventArgs e)
        {
            resize_Control(pictureBox3, recBut1);
            resize_Control(guna2Button1, recBut2);
            resize_Control(label1, rectxt1);
            resize_Control(label2, rectxt2);
            resize_Control(label3, rectxt3);
            resize_Control(label4, rectxt4);
        }

        // Dynamically adjust font size of labels on resize
        private void Form1_Resize(object sender, EventArgs e)
        {
            float newSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 50f; // Adjust font size proportionally

            UpdateLabelFontSize(label1, newSize);
            UpdateLabelFontSize(label2, newSize);
            UpdateLabelFontSize(label3, newSize);
            UpdateLabelFontSize(label4, newSize);
        }

        // Update the font size of a label
        private void UpdateLabelFontSize(Label label, float newSize)
        {
            label.Font = new Font(label.Font.FontFamily, newSize, label.Font.Style);
        }

        // Resize control dimensions and position dynamically
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

        // Handle button click to open the "Story of Us" page
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string url = "https://www.togetherculture.com/story-of-us";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Ensure compatibility with modern systems
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the link: {ex.Message}");
            }
        }
    }
}
