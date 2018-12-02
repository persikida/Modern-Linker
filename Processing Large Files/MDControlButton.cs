using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class HelperMethods
{
    public GraphicsPath GP = null;
    public enum MouseMode
    {
        NormalMode, Hovered, Pushed
    };

    public SolidBrush SolidBrushHTMlColor(String C_WithoutHash)
    {
        return new SolidBrush(GetHTMLColor(C_WithoutHash));
    }

    public Pen PenHTMlColor(String C_WithoutHash, float Thick)
    {
        return new Pen(GetHTMLColor(C_WithoutHash), Thick);
    }

    public Color GetHTMLColor(String C_WithoutHash)
    {
        return ColorTranslator.FromHtml("#" + C_WithoutHash);
    }
}

public class MDCOntrolButton : Control
{
    private HelperMethods.MouseMode State;
    private Style _ControlStyle = Style.Close;
    private static HelperMethods H = new HelperMethods();
 
    public enum Style
    {
        Close,
        Minimize,
        Maximize
    }

    public MDCOntrolButton()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
        ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        UpdateStyles();
        Anchor = AnchorStyles.Top | AnchorStyles.Right;
        Size = new Size(18, 18);
    }
	
    protected override void OnPaint(PaintEventArgs e)
    {
        using (Bitmap B = new Bitmap(Width, Height))
        using (Graphics G = Graphics.FromImage(B))
        {
             G.SmoothingMode = SmoothingMode.HighQuality;
            switch(State)
            {
				case HelperMethods.MouseMode.NormalMode:
				{
				   G.DrawEllipse(new Pen(Color.FromArgb(150, H.GetHTMLColor("fc3955")), 2), new Rectangle(1, 1, 15, 15));
				   G.FillEllipse(new SolidBrush(Color.FromArgb(150, H.GetHTMLColor("fc3955"))), new Rectangle(5, 5, 7, 7));
				   break;
				}
				case HelperMethods.MouseMode.Hovered:
				{
					Cursor = Cursors.Hand;
                    G.DrawEllipse(H.PenHTMlColor("fc3955", 2), new Rectangle(1, 1, 15, 15));
					G.FillEllipse(H.SolidBrushHTMlColor("fc3955"), new Rectangle(5, 5, 7, 7));
					break;
				}
				case HelperMethods.MouseMode.Pushed:
				{
					G.DrawEllipse(H.PenHTMlColor("24273e", 2), new Rectangle(1, 1, 15, 15));
					G.FillEllipse(H.SolidBrushHTMlColor("24273e"), new Rectangle(5, 5, 7, 7));
					break;
				}
				default: break;
            }
            e.Graphics.DrawImage(B, 0, 0);
        }
    }
    public Style ControlStyle
    {
        get
        {
            return _ControlStyle;
        }
        set
        {
            _ControlStyle = value;
            Invalidate();
        }
    }
 
    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        if (ControlStyle == Style.Close)
        {
            //Environment.Exit(0);
            //Application.Exit();
        }
        else if(ControlStyle == Style.Minimize)
        {
			if (FindForm().WindowState == FormWindowState.Normal) FindForm().WindowState = FormWindowState.Minimized;
        }
        else if (ControlStyle == Style.Maximize)
        {
			if (FindForm().WindowState == FormWindowState.Normal) FindForm().WindowState = FormWindowState.Maximized;
            else if (FindForm().WindowState == FormWindowState.Maximized) FindForm().WindowState = FormWindowState.Normal;
        }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }
 
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }
 
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        State = HelperMethods.MouseMode.Pushed;
        Invalidate();
    }
 
    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        State = HelperMethods.MouseMode.NormalMode;
        Invalidate();
	}
}
