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
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using Forme;

namespace bing.Forme
{
    public class ButonAnimat
    {
        Canvas m_c;
        Canvas m_canvas;
        Popup m_popup;
        Image m_image;
        double m_top;
        double m_left;
        bool m_selectAnimals;

        #region animatie
        DoubleAnimation da = new DoubleAnimation();
        DoubleAnimation da1 = new DoubleAnimation();
        DoubleAnimation da2 = new DoubleAnimation();
        Storyboard sb = new Storyboard();
        Storyboard sb1 = new Storyboard();
        DoubleAnimation dai = new DoubleAnimation();
        DoubleAnimation dai1 = new DoubleAnimation();
        DoubleAnimation dai2 = new DoubleAnimation();
        Storyboard sb2 = new Storyboard();
        #endregion

        MeniuPicks m_meniuPicks;

        public ButonAnimat(Canvas c, String img, double top, double left, bool showAnimals, MeniuPicks picks)
        {
            m_c = c;
            m_top = top;
            m_left = left;
            m_selectAnimals = showAnimals;
            m_meniuPicks = picks;
            m_image = new Image()
            {
                Source = new BitmapImage(
                    new Uri(
                        img,
                        UriKind.Relative
                        )
                        ),
                Width = 38,
                Height = 21
            };
            m_canvas = new Canvas()
            {
                Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xcc, 0xdf, 0xf5)),
                Opacity = .46,
                Width = 50,
                Height = 50,
                Clip = new RectangleGeometry()
                {
                    RadiusX = 10,
                    RadiusY = 10,
                    Rect = new Rect(0, 0, 150, 40)
                },

            };
            m_canvas.Children.Add(m_image);
            Canvas.SetTop(m_image, 10);
            Canvas.SetLeft(m_image, 6);
            m_popup = new Popup();
            m_popup.Child = m_canvas;
            m_popup.IsOpen = true;
            if (m_c != null)
            m_c.Children.Add(m_popup);
            Canvas.SetTop(m_popup, top);
            Canvas.SetLeft(m_popup, left);
            m_canvas.MouseEnter += new MouseEventHandler(m_canvas_MouseEnter);
            m_canvas.MouseLeave += new MouseEventHandler(m_canvas_MouseLeave);
            m_canvas.MouseLeftButtonDown += new MouseButtonEventHandler(m_canvas_MouseLeftButtonDown);

            SetUpAnimation();
        }

        void m_canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (m_selectAnimals == true)
            {
                m_meniuPicks.showAnimals();
            }
            else
            {
                m_meniuPicks.showPlants();
            }
        }

        private void SetUpAnimation()
        {
            da.To = 200;
            da1.To = -100;
            da2.To = 200;
            sb.Duration = new Duration(new TimeSpan(0, 0, 0, 1));
            sb.SpeedRatio = 2;
            sb1.SpeedRatio = 3;
            sb1.Duration = new Duration(new TimeSpan(0, 0, 0, 1));
            Storyboard.SetTarget(da, m_canvas);
            Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.WidthProperty));
            Storyboard.SetTarget(da1, m_popup);
            Storyboard.SetTargetProperty(da1, new PropertyPath(Popup.HorizontalOffsetProperty));
            Storyboard.SetTarget(da2, m_popup);
            Storyboard.SetTargetProperty(da2, new PropertyPath(Popup.WidthProperty));
            sb1.Children.Add(da1);
            sb1.Children.Add(da2);
            sb.Children.Add(da);
            dai.To = 50;
            dai1.To = 0;
            sb2.Duration = new Duration(new TimeSpan(0, 0, 0, 3));
            Storyboard.SetTarget(dai, m_canvas);
            Storyboard.SetTargetProperty(dai, new PropertyPath(Canvas.WidthProperty));
            Storyboard.SetTarget(dai1, m_popup);
            Storyboard.SetTargetProperty(dai1, new PropertyPath(Popup.HorizontalOffsetProperty));
            sb2.Children.Add(dai1);
            sb2.Children.Add(dai);
        }

        void m_canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            sb.Stop();
            sb1.Stop();
            sb2.Begin();
        }

        void m_canvas_MouseEnter(object sender, MouseEventArgs e)
        {
            sb2.Stop();
            sb1.Begin();
            sb.Begin();
        }
    }
}
