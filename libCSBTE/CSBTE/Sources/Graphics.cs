using System;
using System.Drawing.Text;
using System.Drawing;

namespace CSBTE
{
    class Graphics
    {
        public static Font LoadFont(string path, Single fontSize, FontStyle fontStyle)
        {
            try
            {
                var fnt = new PrivateFontCollection();
                fnt.AddFontFile(path);
                Font font = new Font(fnt.Families[0], fontSize, fontStyle);
                return font;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Exception: " + ex.Message);
            }
        }
            public static Image DrawTextOnImage(string Text,Image source,Font font,PointF point,Brush brush)
        {
            Bitmap bmp = new Bitmap(source);
            System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bmp);
            
            graphic.DrawString(Text, font, brush, point);
            return bmp;
          
        }
        public static Image DrawImageOnImage(Image source,Image imgToDraw, Point point)
        {
            Bitmap bmp = new Bitmap(source);
            System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bmp);

            graphic.DrawImage(imgToDraw, point);
            return bmp;
        }
	}
}
