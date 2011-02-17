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
    public class ControlCuColturi:Canvas
    {
        private Canvas canvas = new Canvas();
        /// <summary>
        /// canvas ffarra border si colturi
        /// </summary>
        /// <param name="can">canvasul din care face parte</param>
        /// <param name="Width">lungime</param>
        /// <param name="Height">latime</param>
        /// <param name="left">distanta fata de left</param>
        /// <param name="top">distanta fata de sus</param>
        /// <param name="transparent">daca e transparent</param>
        /// <param name="opacity">opacitatea</param>
        public ControlCuColturi(Canvas can, double Width, double Height, double left, double top, bool transparent, double opacity)

        {
            if (transparent == true)
            {
                canvas.SetValue(Canvas.BackgroundProperty, new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF)));
            }
           
            canvas.Width = Width;
            canvas.Height = Height;
            canvas.Opacity = opacity;
            can.Children.Add(canvas);
            Canvas.SetTop(canvas, top);
            Canvas.SetLeft(canvas, left);
         
        }
        public Canvas intoarce()
        {
            return canvas;
        }
        private Color ConvertToColor(string colorString)
        {
            byte a = 255;

            byte r = (byte)(Convert.ToUInt32(colorString.Substring(3, 2), 16));
            byte g = (byte)(Convert.ToUInt32(colorString.Substring(5, 2), 16));
            byte b = (byte)(Convert.ToUInt32(colorString.Substring(7, 2), 16));
            return Color.FromArgb(a, r, g, b);
        }
        /// <summary>
        /// adauga TextBlock cu o singura linie
        /// </summary>
        /// <param name="element">nume element</param>   
        /// <param name="text">textul</param>
        /// <param name="fontsize">marimea</param>
        /// <param name="color">culoarea</param>
        public void AddTextBlock(TextBlock element, string text, int fontsize, double left, double top, string color)
        {


            element.Text = text;
            element.FontSize = fontsize;
            if (color != null)
                element.Foreground = new SolidColorBrush(ConvertToColor(color));
            if (element.Parent != canvas)
            {
                canvas.Children.Add(element);
            }
            Canvas.SetLeft(element, left);
            Canvas.SetTop(element, top);

        }
        public void AddImage(Image img, double width, double height, string cale, double left, double top)
        {
            img.Width = width;
            img.Height = height;
            img.Stretch = Stretch.Fill;
            img.Source = new BitmapImage(new Uri(cale, UriKind.Relative));
            canvas.Children.Add(img);
            Canvas.SetLeft(img, left);
            Canvas.SetTop(img, top);
        }
    }
}
