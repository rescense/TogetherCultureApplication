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
        // Adjustable radius to control the roundness of the corners
        private int _radius = 20;

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; Invalidate(); } // Invalidate the panel to re-draw it when the radius changes
        }

        // Override OnPaint to create custom drawing
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a GraphicsPath with rounded corners
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, _radius, _radius, 180, 90); // Top left corner
            path.AddArc(this.Width - _radius - 1, 0, _radius, _radius, 270, 90); // Top right corner
            path.AddArc(this.Width - _radius - 1, this.Height - _radius - 1, _radius, _radius, 0, 90); // Bottom right corner
            path.AddArc(0, this.Height - _radius - 1, _radius, _radius, 90, 90); // Bottom left corner
            path.CloseAllFigures();

            // Set the Region property to the path to apply the rounded shape
            this.Region = new Region(path);
        }

        // Override OnResize to adjust the region when resizing the panel
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // Re-draw the panel when resized
        }
    }
}
