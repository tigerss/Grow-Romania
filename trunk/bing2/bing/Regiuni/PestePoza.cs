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
using Forme;
using System.Windows.Threading;

namespace bing
{
    public class PestePoza
    {
        Path Padure;
        Shazzam.Shaders.HHEffect hh = new Shazzam.Shaders.HHEffect();
        Canvas canv;
        DispatcherTimer tmr = new DispatcherTimer();
        public PestePoza(Canvas can)
        {
            tmr.Interval = new TimeSpan(0, 0, 0, 0, 200);
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
            #region Padure
            Padure = new Path()
            {
                StrokeThickness = 4,

            };
            Padure.MouseLeftButtonDown += new MouseButtonEventHandler(Padure_MouseLeftButtonDown);
            Padure.Cursor = Cursors.Hand;
            PathFigure PathFigurepadure = new PathFigure() { StartPoint = new Point(0, 2) };
            LineSegment l = new LineSegment() { Point = new Point(2, 333) };
            PathFigurepadure.Segments.Add(l);
            BezierSegment bs = new BezierSegment() { Point1 = new Point(14, 333), Point2 = new Point(30, 310), Point3 = new Point(30, 270) };
            PathFigurepadure.Segments.Add(bs);
            bs = new BezierSegment() { Point1 = new Point(30, 270), Point2 = new Point(30, 250), Point3 = new Point(50, 245) };
            PathFigurepadure.Segments.Add(bs);
            //bs = new BezierSegment() { Point1 = new Point(40, 250), Point2 = new Point(40, 254), Point3 = new Point(85, 235) };
            //PathFigurepadure.Segments.Add(bs);
            l = new LineSegment() { Point = new Point(400, 115) };
            PathFigurepadure.Segments.Add(l);
            bs = new BezierSegment() { Point1 = new Point(400, 115), Point2 = new Point(529, 65), Point3 = new Point(445, 2) };
            PathFigurepadure.Segments.Add(bs);
            l = new LineSegment() { Point = new Point(0, 2) };
            PathFigurepadure.Segments.Add(l);
            PathGeometry geometry = new PathGeometry();

            geometry.Figures.Add(PathFigurepadure);
            Padure.Data = geometry;

            Padure.Fill = new SolidColorBrush(Colors.Transparent);
            //  Padure.Stroke = new SolidColorBrush(Color.FromArgb(0xFF,0x00,0x00,0x00));
            Padure.MouseEnter += new MouseEventHandler(Padure_MouseEnter);
            Padure.MouseLeave += new MouseEventHandler(Padure_MouseLeave);

            can.Children.Add(Padure);
            #endregion
            canv = can;
            #region Sus
            Path el = new Path();
            BezierSegment b;
            PathFigure pf;
            PathGeometry j;
            el.Fill = new SolidColorBrush(Color.FromArgb(0x55, 0x0a, 0x76, 0xd1));
            //el.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
            el.Effect = hh;
            pf = new PathFigure() { StartPoint = new Point(500, 2) };
            b = new BezierSegment() { Point1 = new Point(500, 2), Point2 = new Point(600, 70), Point3 = new Point(430, 140) };

            pf.Segments.Add(b);
            LineSegment ls = new LineSegment() { Point = new Point(420, 130) };
            pf.Segments.Add(ls);
            b = new BezierSegment() { Point1 = new Point(420, 130), Point2 = new Point(550, 70), Point3 = new Point(480, 2) };
            pf.Segments.Add(b);
            j = new PathGeometry();
            j.Figures.Add(pf);
            el.Data = j;
            canv.Children.Add(el);
            #endregion
            Path mijloc = new Path();

            // mijloc.Fill = new SolidColorBrush(Color.FromArgb(0x55, 0x0a, 0x76, 0xd1));

            mijloc.StrokeThickness = 3;
            mijloc.Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
            //     mijloc.Fill = new SolidColorBrush(Color.FromArgb(0x99, 0x0d, 0x74, 0xd1));
            //        mijloc.Effect = hh;
            pf = new PathFigure() { StartPoint = new Point(370, 150) };
            b = new BezierSegment() { Point1 = new Point(370, 150), Point2 = new Point(400, 190), Point3 = new Point(330, 185) };

            pf.Segments.Add(b);
            ls = new LineSegment() { Point = new Point(320, 175) };
            pf.Segments.Add(ls);
            b = new BezierSegment() { Point1 = new Point(320, 175), Point2 = new Point(260, 170), Point3 = new Point(380, 150) };
            pf.Segments.Add(b);
            j = new PathGeometry();
            j.Figures.Add(pf);
            mijloc.Data = j;
            canv.Children.Add(mijloc);
        }
        void tmr_Tick(object sender, EventArgs e)
        {

            Random r = new Random();
            double o = (double)r.Next(27, 30);
            hh.Scale = (double)(o / 1000);
            hh.Scaling = r.Next(95, 100);
        }
        void Padure_MouseLeave(object sender, MouseEventArgs e)
        {
            //DoubleAnimation da = new DoubleAnimation() { From = 0.5, To =0, Duration = TimeSpan.FromMilliseconds(1) };
            //Storyboard.SetTarget(da, Padure);
            //Storyboard.SetTargetProperty(da, new PropertyPath(Path.OpacityProperty));
            //Storyboard ab = new Storyboard();
            //ab.Children.Add(da);
            //Padure.Fill = new SolidColorBrush(Colors.Transparent);
            //ab.Begin();
        }

        void Padure_MouseEnter(object sender, MouseEventArgs e)
        {

            //DoubleAnimation da = new DoubleAnimation() { From = 0, To = 0.5, Duration = TimeSpan.FromMilliseconds(1) };
            //Storyboard.SetTarget(da, Padure);
            //Storyboard.SetTargetProperty(da, new PropertyPath(Path.OpacityProperty));
            //Storyboard ab = new Storyboard();
            //ab.Children.Add(da);
            //Padure.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0x65, 0x70, 0x74));
            //ab.Begin();

        }

        void Padure_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            #region BackgroundCanvas
            Canvas background = new Canvas()
            {
                Width = 663,
                Height = 100,
                Background = new SolidColorBrush(Colors.Black),
                Opacity = 0.5
            };
            #endregion
            canv.Children.Add(background);
            Canvas.SetTop(background, 370);
            Canvas.SetLeft(background, 50);
            MeniuPicks p = new MeniuPicks(canv, 663, 100, "", 1, 50, 370);

            canv.Children.Add(p);
        }
        public Canvas Intoarce()
        {
            return canv;
        }
    }
}
