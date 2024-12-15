using System.Diagnostics;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class Shop : UserControl
    {

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle rectxt1;
        private Rectangle rectxt2;
        private Rectangle rectxt4;

        public Shop()
        {


            InitializeComponent();
            this.Resize += Form1_Resize;
            this.Resize += Form1_Reposition;

            formOriginalSize = this.Size;

            recBut1 = new Rectangle(pictureBox2.Location, pictureBox2.Size);
            recBut2 = new Rectangle(guna2Button1.Location, guna2Button1.Size);
            rectxt1 = new Rectangle(label1.Location, label1.Size);
            rectxt2 = new Rectangle(label2.Location, label2.Size);
            rectxt4 = new Rectangle(label4.Location, label4.Size);

        }

        // Position the components w.r.t window size
        private void Form1_Reposition(object sender, EventArgs e)
        {
            resize_Control(pictureBox2, recBut1);
            resize_Control(guna2Button1, recBut2);
            resize_Control(label1, rectxt1);
            resize_Control(label2, rectxt2);
            resize_Control(label4, rectxt4);

        }

        // Resize the components w.r.t window size
        private void Form1_Resize(object sender, EventArgs e)
        {
            float newSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 50f; // Adjust the divisor as needed
            label4.Font = new Font(label4.Font.FontFamily, newSize, label4.Font.Style);
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String url = "https://www.togetherculture.com/shop";
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

        
    }
}
