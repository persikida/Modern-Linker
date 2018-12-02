using System;
using System.Drawing;
using System.Windows.Forms;

class MDForm : ContainerControl
{
    public enum ThemeTypes
    {
        Light, Dark
    }

    public event ThemeTypeChangedEH ThemeTypeChanged;
    public delegate void SplitterColorChangedEH();
    public delegate void ThemeTypeChangedEH();

    private Color mdSplitter;
    private bool Header = false;
    private int MoveHeight;
    private Point MouseP = new Point(0, 0);

    private ThemeTypes mdThemeType;
    public ThemeTypes ThemeType
    {
        get { return mdThemeType; }
        set
        {
            mdThemeType = value;
            ThemeTypeChanged?.Invoke();
        }
    }

    protected void OnThemeTypeChanged()
    {
        Invalidate();
        switch (ThemeType)
        {
            case ThemeTypes.Dark:
            {
                BackColor = Color.FromArgb(50, 50, 50);
                ForeColor = Color.White;
                break;
            }
            case ThemeTypes.Light:
            {
                BackColor = Color.White;
                ForeColor = Color.Black;
                break;
            }
            default: break;
        }
    }

    public Color Splitter
    {
        get { return mdSplitter; }
        set
        {
            mdSplitter = value;
            OnSplitterColorChanged();
        }
    }

    public MDForm() : base()
    {
        ThemeTypeChanged += OnThemeTypeChanged;
        DoubleBuffered = true;
        Font = new Font("Segoe UI Semilight", 9.75f);
        Splitter = Color.FromArgb(169, 55, 70);
        ThemeType = ThemeTypes.Dark;
        ForeColor = Color.White;
        BackColor = Color.FromArgb(50, 50, 50);
        MoveHeight = 32;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
        {
            Header = true;
            MouseP = e.Location;
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (Header) Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        Header = false;
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        Dock = DockStyle.Fill;
        Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Bitmap B = new Bitmap(Width, Height);
        Graphics G = Graphics.FromImage(B);
        base.OnPaint(e);

        G.Clear(BackColor);
        G.DrawLine(new Pen(mdSplitter, 2), new Point(0, 30), new Point(Width, 30));
        G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(8, 6, Width - 1, Height - 1), StringFormat.GenericDefault);
        G.DrawRectangle(new Pen(Color.FromArgb(100, 100, 100)), new Rectangle(0, 0, Width - 1, Height - 1));
        e.Graphics.DrawImage(B, new Point(0, 0));
        G.Dispose();
        B.Dispose();
    }

    protected void OnSplitterColorChanged()
    {
        Invalidate();
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Invalidate();
    }
}