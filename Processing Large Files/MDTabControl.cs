using System;
using System.Drawing;
using System.Windows.Forms;

public class Helpers
{
    public static System.Drawing.Drawing2D.GraphicsPath RoundRectangle(Rectangle R, int Curve)
    {
        System.Drawing.Drawing2D.GraphicsPath GP = new System.Drawing.Drawing2D.GraphicsPath(System.Drawing.Drawing2D.FillMode.Winding);
        GP.AddArc(R.X, R.Y, Curve, Curve, 180.0F, 90.0F);
        GP.AddArc(R.Right - Curve, R.Y, Curve, Curve, 270.0F, 90.0F);
        GP.AddArc(R.Right - Curve, R.Bottom - Curve, Curve, Curve, 0.0F, 90.0F);
        GP.AddArc(R.X, R.Bottom - Curve, Curve, Curve, 90.0F, 90.0F);
        GP.CloseFigure();
        return GP;
    }
}

public class MDTabControl : TabControl
{
    private MouseState State;

    public struct MouseState
    {
        public bool Hover;
        public Point Coordinates;
    };

    public MDTabControl()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        SizeMode = TabSizeMode.Fixed;
        Dock = DockStyle.None;
        ItemSize = new Size(40, 140);
        Alignment = TabAlignment.Left;
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        State.Hover = true;
        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        State.Hover = false;
        foreach (TabPage Tab in TabPages)
        {
            if (Tab.DisplayRectangle.Contains(State.Coordinates))
            {
                Invalidate();
                break;
            }
        }
        base.OnMouseLeave(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        State.Coordinates = e.Location;
        foreach (TabPage Tab in TabPages)
        {
            if (Tab.DisplayRectangle.Contains(e.Location))
            {
                Invalidate();
                break;
            }
        }
        base.OnMouseMove(e);
    }

    protected override void OnCreateControl()
    {
        foreach (TabPage Tab in TabPages) Tab.BackColor = Color.FromArgb(38, 38, 38);
        base.OnCreateControl();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Bitmap B = new Bitmap(Width, Height);
        using (Graphics G = Graphics.FromImage(B))
        {
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            G.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            G.Clear(Color.FromArgb(38, 38, 38));
            G.FillPath(new SolidBrush(Color.FromArgb(38, 38, 38)), Helpers.RoundRectangle(new Rectangle(0, 0, Width, Height), 5));
            G.FillPath(new SolidBrush(Color.FromArgb(41, 41, 41)), Helpers.RoundRectangle(new Rectangle(1, 1, 140, Height - 1), 5));

            for (int i = 0; i <= TabPages.Count - 1; i++)
            {
                Rectangle R = GetTabRect(i);
                if (i == SelectedIndex)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(27, 27, 27)), new Rectangle(R.X, Convert.ToInt32(R.Y + 1.5), R.Width, R.Height - 3));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(196, 48, 43)), new Rectangle(R.X, Convert.ToInt32(R.Y + 1.5), 5, Convert.ToInt32(R.Height - 3.4)));
                    G.DrawString(TabPages[i].Text.ToUpper(), new Font("Lucida Sans Unicode", 8, FontStyle.Regular), new SolidBrush(Color.FromArgb(196, 48, 43)), R.X + 38, R.Y + 11);
                }
                else
                {
                    if (State.Hover & R.Contains(State.Coordinates))
                    {
                        Cursor = Cursors.Hand;
                        G.FillRectangle(new SolidBrush(Color.FromArgb(28, 28, 28)), new Rectangle(R.X, R.Y, R.Width + 1, R.Height));
                        G.FillRectangle(new SolidBrush(Color.FromArgb(69, 69, 69)), new Rectangle(R.X, R.Y + 1, 5, R.Height - 2));
                    }
                    G.DrawString(TabPages[i].Text.ToUpper(), new Font("Lucida Sans Unicode", 8, FontStyle.Regular), Brushes.White, R.X + 38, Convert.ToInt32(R.Y + 11.5));
                }

                if (!(ImageList == null)) G.DrawImage(ImageList.Images[i], new Rectangle(R.X + 12, R.Y + 11, 16, 16));
                G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                G.DrawLine(new Pen(Color.FromArgb(31, 31, 31)), new Point(0, R.Bottom + 1), new Point(Convert.ToInt32(R.Width + 2.5), Convert.ToInt32(R.Bottom + 1)));
            }
            G.DrawLine(new Pen(Color.FromArgb(35, 35, 35), 2), ItemSize.Height + 2, 0, ItemSize.Height + 2, Height);
            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
        }
    }
}