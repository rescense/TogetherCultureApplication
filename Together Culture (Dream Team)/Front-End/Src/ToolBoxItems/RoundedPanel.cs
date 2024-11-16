using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together_Culture__Dream_Team_.Front_End.Src.ToolBoxItems
{
    public class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 20; // You can set a default radius

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90); // Top-left corner
                path.AddArc(Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90); // Top-right corner
                path.AddArc(Width - CornerRadius, Height - CornerRadius, CornerRadius, CornerRadius, 0, 90); // Bottom-right corner
                path.AddArc(0, Height - CornerRadius, CornerRadius, CornerRadius, 90, 90); // Bottom-left corner
                path.CloseFigure();

                g.FillPath(new SolidBrush(BackColor), path);
                g.DrawPath(new Pen(ForeColor), path); // Optional: Draw the border
            }

            base.OnPaint(e);
        }
    }
}
