using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace POSApp.Classes
{
    class CustomButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(graphicsPath);
            
            base.OnPaint(pevent);
        }
    }
}
