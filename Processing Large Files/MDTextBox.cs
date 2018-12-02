using System.Drawing;
using System.Windows.Forms;

public class MDTextBox : TextBox
{
    public enum ThemeTypes
    {
        Light, Dark
    }
    public event ThemeTypeChangedEventHandler ThemeChanged;
    public delegate void ThemeTypeChangedEventHandler();

    private ThemeTypes mdThemeType;
    public ThemeTypes ThemeType
    {
        get { return mdThemeType; }
        set
        {
            mdThemeType = value;
            ThemeChanged?.Invoke();
        }
    }
    private bool setTabStop = false;
    public MDTextBox()
    {
        ThemeChanged += OnColorSchemeChanged;
        BorderStyle = BorderStyle.FixedSingle;
        Font = new Font("Microsoft PhagsPa", 9.75f);
        BackColor = Color.FromArgb(35, 35, 35);
        ForeColor = Color.White;
        Size = new Size(120, 24);
        TabStop = setTabStop;
        ThemeType = ThemeTypes.Dark;
    }
    protected void OnColorSchemeChanged()
    {
        Invalidate();
        switch (ThemeType)
        {
            case ThemeTypes.Dark:
            {
                BackColor = Color.FromArgb(35, 35, 35);
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
}