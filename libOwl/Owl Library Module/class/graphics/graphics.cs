using System;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LibraryOwl.Media.Graphics
{
	public static class FlowFont
	{
        public static Font LoadFont(string FilePath, Single FontSize, FontStyle FontStyle)
        {
            var font_usage = new System.Drawing.Text.PrivateFontCollection();
            font_usage.AddFontFile(FilePath);
            var _font = new Font(font_usage.Families[0], FontSize, FontStyle);
            return _font;
        }
	}
}
