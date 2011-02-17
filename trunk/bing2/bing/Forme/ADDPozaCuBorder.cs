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
using System.Windows.Media.Imaging;

namespace Forme
{
    public class ADDPozaCuBorder
    {
        Border myBorder ;
        public  ADDPozaCuBorder(Canvas c,Image img, double width, double height, string cale,double left, double top)
        { myBorder = new Border();
           
            img.Width = width;
            img.Cursor = Cursors.Hand;
            img.Height = height;
            img.Stretch = Stretch.Fill;
            if (cale != null)
                img.Source = new BitmapImage(new Uri(cale, UriKind.Relative));
            else
                img.Source = null;
            myBorder.Child = img;
            
            c.Children.Add(myBorder);
            Canvas.SetLeft(myBorder, left);
            Canvas.SetTop(myBorder, top);
        }
        public void Border(CornerRadius CornerRadius, Color culoare, Thickness thickness, double Width, double Height)
        {

            myBorder.Width = Width;
            myBorder.Height = Height;
            myBorder.BorderThickness = thickness;
            myBorder.BorderBrush = new SolidColorBrush(culoare);
            myBorder.CornerRadius = CornerRadius;
        }
    

    }
}
