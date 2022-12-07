using System;
using System.Windows.Forms;
using System.Drawing;

namespace FormulariosSistema
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class CustomPanel : Panel
    {
        public CustomPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(brush, ClientRectangle);
            e.Graphics.DrawRectangle(Pens.White, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }
    }
}