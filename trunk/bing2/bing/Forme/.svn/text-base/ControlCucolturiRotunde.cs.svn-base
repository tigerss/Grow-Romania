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
    public class ControlCuColturiRotunde:Canvas
    {
       private Canvas c=new Canvas();
       
       private Border myBorder;
        #region Constructor
       /// <summary>
        /// Apelati functiile Colors,Colturi,Borders
        /// </summary>
        /// <param name="can">Canvasul de care apartine spre ex MeniuDreapta</param>
        /// <param name="Width">lungimea</param>
        /// <param name="Height">latimea</param>
        /// <param name="transparent">true daca e transp</param>
       public ControlCuColturiRotunde(Canvas can, double Width, double Height, double left, double top, bool transparent, double opacity)
        {
            if (transparent == true)
            {
                c.SetValue(Canvas.BackgroundProperty, new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF)));
            }
            #region Border
            myBorder = new Border();
            Canvas.SetTop(myBorder, top);
            Canvas.SetLeft(myBorder, left);
        
            #endregion
            c.Width = Width;
            c.Height = Height;
            c.Opacity = opacity;
            Canvas.SetTop(c, top);
            Canvas.SetLeft(c, left);
            myBorder.Child = c;

            can.Children.Add(myBorder);
           
           
        }
        /// <summary>
        /// returneaza Canvasu pentru a se folosi pe post de buton
        /// </summary>
        /// <returns>retunreaza Canvas</returns>
        public Canvas intoarce()
        {
            return c;
        }
       
       #endregion
        #region Culori
        private  Color ConvertToColor(string colorString)
        {
            byte a = (byte)(Convert.ToUInt32(colorString.Substring(1, 2), 16));
           
            byte r = (byte)(Convert.ToUInt32(colorString.Substring(3, 2), 16));
            byte g = (byte)(Convert.ToUInt32(colorString.Substring(5, 2), 16));
            byte b = (byte)(Convert.ToUInt32(colorString.Substring(7, 2), 16));
            return Color.FromArgb(a, r, g, b);
        }
       /// <summary>
       /// Va fi desenat din doua culori cu gradient la jumatate
       /// </summary>
        /// <param name="color1">prima culoare format:#FF48657B</param>
        /// <param name="color2">a doua culoare format:#FF48657B</param>
        /// <param name="EndPoint">un Point de obicei cu coordonatele 0,5 1</param>
        ///  <param name="StartPoint">un Point de obicei cu coordonatele 0,5 0</param>
        ///  <param name="transparent">daca e sau nu transparent: 1 transparent</param>
        ///  <param name="opacitate">poate fi null sau valori intr 0 si 1</param>
        public void Colors(string color1,string color2,Point EndPoint,Point StartPoint,double? opacitate)
        {
           
                LinearGradientBrush lgb = new LinearGradientBrush()
                {
                    StartPoint = StartPoint,
                    EndPoint = EndPoint,
                    GradientStops =
                                      {
                                          new GradientStop(){Color=ConvertToColor(color1),Offset=0},
                                           new GradientStop(){Color=ConvertToColor(color2),Offset=1}
                                      }
                                      
                };
                if(opacitate!=null)
                c.Opacity = (double)opacitate;
                c.Background = lgb;
           
        }
        #endregion
        #region Colturi
        /// <summary>
        /// Colturile Canvasului 
        /// </summary>
        /// <param name="RadiusX">o valoare double</param>
        /// <param name="RadiusY"> o valoare dobule</param>
        /// <param name="rect">cat lungimea canvasului ex: 0, 0,240,40</param>
        public void Colturi(double RadiusX, double RadiusY, Rect rect)
        {
             RectangleGeometry rg;
            rg = new RectangleGeometry();
            rg.RadiusX = RadiusX;
            rg.RadiusY = RadiusY;
            rg.Rect = rect;
            c.Clip = rg;
        }
        #endregion
        #region Bordura
        /// <summary>
        /// Borderul pt control
        /// </summary>
        /// <param name="CornerRadius"> colturile sa fie rotunjite gen (12,12,12,12)</param>
        /// <param name="BorderBrush">culoare format #ff123456</param>
        /// <param name="thickness">grosimea </param>
        /// <param name="Width">lungimea sa fie putin mai mare decat controlul</param>
        /// <param name="Height">si latimea la fel</param>
        public void Border(CornerRadius CornerRadius, string BorderBrush, Thickness thickness, double Width, double Height)
        {
        
            myBorder.Width = Width;
            myBorder.Height = Height;
            myBorder.BorderThickness = thickness;
            myBorder.BorderBrush = new SolidColorBrush(ConvertToColor(BorderBrush));
            myBorder.CornerRadius = CornerRadius;
        }
        #endregion
        #region Elemente
        /// <summary>
        /// adauga TextBlock cu o singura linie
        /// </summary>
        /// <param name="element">nume element</param>   
        /// <param name="text">textul</param>
        /// <param name="fontsize">marimea</param>
        /// <param name="color">culoarea</param>
        public void AddTextBlock(TextBlock element,string text,int fontsize,double left,double top,string color)
        {

          
           element.Text = text;
           element.FontSize = fontsize;
            if(color!=null)
           element.Foreground = new SolidColorBrush(ConvertToColor(color));
            if (element.Parent != c)
            {
                c.Children.Add(element);
            }
           Canvas.SetLeft(element, left);
           Canvas.SetTop(element, top);
         
        }
        public void AddDropDown(ComboBox cb,string color,string background,int fontsize,double left,double top)
        {
            cb.Foreground = new SolidColorBrush(ConvertToColor(color));
            cb.Background = new SolidColorBrush(ConvertToColor(background));
            cb.FontSize = fontsize;
     
            c.Children.Add(cb);
            Canvas.SetLeft(cb, left);
            Canvas.SetTop(cb, top);
        }
        public void Ascunde()
        {
            myBorder.Visibility = Visibility.Collapsed;
        }
        public void Arata()
        {
            myBorder.Visibility = Visibility.Visible;
        }
        public void AddTextBlockMultiple(TextBlock element,int linii,string[] text,string[] culori,int[] sizes)
        {
            Run[] r = new Run[linii];
            int var = culori.Length;
            if (var == 1)
            {
                for (int i = 0; i < linii; i++)
                {
                    r[i] = new Run();
                    r[i].FontSize = sizes[0];
                    r[i].Foreground = new SolidColorBrush(ConvertToColor(culori[0]));
                    r[i].Text = text[i];
                    element.Inlines.Add(r[i]);
                    element.Inlines.Add(new LineBreak());
                }
            }
            else
            {
                for (int i = 0; i < linii; i++)
                {
                    r[i] = new Run();
                    r[i].FontSize = sizes[i];
                    if (culori[i] != null)
                        r[i].Foreground = new SolidColorBrush(ConvertToColor(culori[i]));
                    r[i].Text = text[i];
                    element.Inlines.Add(r[i]);
                    element.Inlines.Add(new LineBreak());
                }
            }
            c.Children.Add(element);
        }
        /// <summary>
        /// adauga un textbox
        /// </summary>
        /// <param name="textbox">textboxul</param>
        /// <param name="text">textul ex: blanbla</param>
        /// <param name="width">lungime</param>
        /// <param name="height">inaltime</param>
        /// <param name="borderthickness">laimea border</param>
        /// <param name="fontsize">marimea scrisului</param>
        /// <param name="CaretBrush">culoarea liniutei care clipoceste, poate fi nula</param>
        /// <param name="Foreground">culoarea textului, poate fi nul</param>
        /// <param name="SelectionBackground">culoarea backgroundului selectat, poate fi nula</param>
        /// <param name="SelectionForeground">culoarea textului selectat, poate fi nula</param>
        /// <param name="background">culoarea backgroundului,poate fi nul</param>
        /// <param name="transparent">daca e transparent sau nu poate fi nul</param>
        /// <param name="left">canvas.left</param>
        /// <param name="top">canvas.top</param>
        public void AddTextBox(TextBox textbox,
                               string text,
                               double width,
                               double height,
                               int borderthickness,
                               int fontsize,
                                string CaretBrush,
                               string Foreground,
                              string SelectionBackground,
                              string SelectionForeground,
                              string background,
                              bool transparent, 
                              double left, 
                              double top)
        {
            textbox.Text = text;
          
            textbox.Width = width;
            textbox.Height = height;
            textbox.BorderThickness = new Thickness(borderthickness);
            textbox.FontSize = fontsize;
            if (CaretBrush != null) 
                textbox.CaretBrush = new SolidColorBrush(ConvertToColor(CaretBrush));
            if (Foreground != null)
                textbox.Foreground = new SolidColorBrush(ConvertToColor(Foreground));
            if (SelectionBackground != null)
                textbox.SelectionBackground = new SolidColorBrush(ConvertToColor(SelectionBackground));
            if (SelectionForeground != null)
                textbox.CaretBrush = new SolidColorBrush(ConvertToColor(SelectionForeground));
            if (transparent == true)
            {
                
                    textbox.Background = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));
            }
            else
                if(background!=null)
                textbox.Background = new SolidColorBrush(ConvertToColor(background));
            c.Children.Add(textbox);
            Canvas.SetLeft(textbox, left);
            Canvas.SetTop(textbox, top);
          
        }
        /// <summary>
        /// la fel ca la Textbox
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="borderthickness"></param>
        /// <param name="fontsize"></param>
        /// <param name="CaretBrush"></param>
        /// <param name="Foreground"></param>
        /// <param name="SelectionBackground"></param>
        /// <param name="SelectionForeground"></param>
        /// <param name="background"></param>
        /// <param name="transparent"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void AddPasswordTextBox(PasswordBox textbox,
                              string text,
                              double width,
                              double height,
                              int borderthickness,
                              int fontsize,
                               string CaretBrush,
                              string Foreground,
                             string SelectionBackground,
                             string SelectionForeground,
                             string background,
                             bool transparent,
                             double left,
                             double top)
        {
            textbox.PasswordChar = '*';
            textbox.Width = width;
            textbox.Height = height;
            textbox.BorderThickness = new Thickness(borderthickness);
            textbox.FontSize = fontsize;
            if (CaretBrush != null)
                textbox.CaretBrush = new SolidColorBrush(ConvertToColor(CaretBrush));
            if (Foreground != null)
                textbox.Foreground = new SolidColorBrush(ConvertToColor(Foreground));
            if (SelectionBackground != null)
                textbox.SelectionBackground = new SolidColorBrush(ConvertToColor(SelectionBackground));
            if (SelectionForeground != null)
                textbox.SelectionForeground = new SolidColorBrush(ConvertToColor(SelectionForeground));
            if (transparent == true)
            {

                textbox.Background = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF));
            }
            else textbox.Background = new SolidColorBrush(ConvertToColor(background));
            c.Children.Add(textbox);
            Canvas.SetLeft(textbox, left);
            Canvas.SetTop(textbox, top);
           
        }
        public void AddImage(Image img,double width,double height,string cale,double left,double top)
        {
            img.Width = width;
            img.Height = height;
            img.Stretch = Stretch.Fill;
            img.Source = new BitmapImage(new Uri(cale, UriKind.Relative));
            c.Children.Add(img);
            Canvas.SetLeft(img, left);
            Canvas.SetTop(img, top);
        }
        #endregion
    }

}
