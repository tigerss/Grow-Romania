using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Forme
{
    public class Linie
    {
        public Linie(double x1, double y1, double x2, double y2, string color, double grosime,Canvas canvas,Line l)
        {
            
            l.X1 = x1;
            l.X2 = x2;
            l.Y1 = y1;
            l.Y2 = y2;
            l.StrokeThickness = grosime;
            l.Stroke = new SolidColorBrush(ConvertToColor(color));
            if(l.Parent!=canvas)
            canvas.Children.Add(l);
        }

        private Color ConvertToColor(string colorString)
        {
            byte a = 255;

            byte r = (byte)(Convert.ToUInt32(colorString.Substring(3, 2), 16));
            byte g = (byte)(Convert.ToUInt32(colorString.Substring(5, 2), 16));
            byte b = (byte)(Convert.ToUInt32(colorString.Substring(7, 2), 16));
            return Color.FromArgb(a, r, g, b);
        }
    }
}
