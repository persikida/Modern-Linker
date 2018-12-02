using System;
using System.Drawing;
using System.Windows.Forms;

class MDButton : Button
{
    public delegate void ColorChangedEH();

    MouseState State = MouseState.None;
    public enum MouseState
    {
        None, Over, Down
    }

    public enum ThemeTypes
    {
        Light, Dark
    }
    
    private ThemeTypes mdThemeType;
    public ThemeTypes ThemeType
    {
        get { return mdThemeType; }
        set
        {
            mdThemeType = value;
            Invalidate();
        }
    }
    
    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = MouseState.Over;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        State = MouseState.None;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        State = MouseState.Down;
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = MouseState.Over;
        Invalidate();
    }

    private Color mdColor;
    public Color MDColor
    {
        get { return mdColor; }
        set
        {
            mdColor = value;
        }
    }
    
    public MDButton() : base()
    {
        Size = new Size(120, 24);
        Font = new Font("Segoe UI Semilight", 9.75f);
        ForeColor = Color.White;
        BackColor = Color.FromArgb(50, 50, 50);
        MDColor = Color.FromArgb(41, 41, 41);
        ThemeType = ThemeTypes.Dark;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Bitmap B = new Bitmap(Width, Height);
        Graphics G = Graphics.FromImage(B);
        base.OnPaint(e);
        Color BGColor = default(Color);
        switch (ThemeType)
        {
            case ThemeTypes.Dark:
            {
                BGColor = Color.FromArgb(50, 50, 50);
                break;
            }
            case ThemeTypes.Light:
            {
                BGColor = Color.White;
                break;
            }
            default: break;
        }
        switch (State)
        {
            case MouseState.None:
            {
                G.Clear(BGColor);
                break;
            }
            case MouseState.Over:
            {
                G.Clear(MDColor);
                break;
            }
            case MouseState.Down:
            {
                G.Clear(MDColor);
                G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Black)), new Rectangle(0, 0, Width - 1, Height - 1));
                break;
            }
            default: break;
        }
        G.DrawRectangle(new Pen(Color.FromArgb(100, 100, 100)), new Rectangle(0, 0, Width - 1, Height - 1));
        StringFormat ButtonString = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        switch (ThemeType)
        {
            case ThemeTypes.Dark:
            {
                G.DrawString(Text, Font, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), ButtonString);
                break;
            }
            case ThemeTypes.Light:
            {
                G.DrawString(Text, Font, Brushes.Black, new Rectangle(0, 0, Width - 1, Height - 1), ButtonString);
                break;
            }
            default: break;
        }
        e.Graphics.DrawImage(B, new Point(0, 0));
        G.Dispose();
        B.Dispose();
    }
}