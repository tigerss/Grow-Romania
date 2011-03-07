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
using System.Windows.Media.Imaging;
using bing.Forme;
using Microsoft.Maps.MapControl;
using Regiuni;
using System.Collections.Generic;
using System.ServiceModel;
using bing.ServiceReference1;

namespace bing
{
    public class pesteHarta
    {
        BasicHttpBinding bind = new BasicHttpBinding();
        EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Tranzactii.svc");
        Path Padure;//regiunea padurii
        Path Campie;//regiunea campiei
        Path mijloc;
        Path el;
        Shazzam.Shaders.HHEffect hh = new Shazzam.Shaders.HHEffect();
        Canvas canv;//canvasul global
        DispatcherTimer tmr = new DispatcherTimer();
        bool? verifica;//verifica ce i apasat ca sa schimb in timer
        private static double grade = 180;
        PlaneProjection p;
        Image img;
        Canvas md;//canasu din
      public static PaginaUser Rember;
        MapLayers mapLayer;
        Map map;
        List<HistoryPadure_Result> lista = new List<HistoryPadure_Result>();
        public pesteHarta(Canvas can, PlaneProjection p,Image img, Canvas md,MapLayers mapLayer,Map map)
        {
            ServiceReference1.TranzactiiClient tc = new ServiceReference1.TranzactiiClient(bind, endpoint);
            tc.GetHistoryPadureCompleted += new EventHandler<ServiceReference1.GetHistoryPadureCompletedEventArgs>(tc_GetHistoryPadureCompleted);
            tc.GetHistoryPadureAsync();
           // retine = md;
            this.mapLayer = mapLayer;
            this.map = map;
            this.md = md;
            this.p = p;
            this.img = img;

            // Alex code
            // Preia meniul de login din LoginForm
            // La intoarcerea din padure sau campie Meniu Dreapta contine MeniuAnimal sau MeniuPlanta
            // iar la intoarcere este necesar ca in Meniu Dreapta sa se afle PaginaUser

            // Nu mai e nevoie de toata partea asta
            /*UIElement[] array = LoginForm.getInstance().getMeniuDreapta();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].GetType() == typeof(PaginaUser))
                {
                    Rember = (PaginaUser)array[i];
                    break;
                }
            }*/
            
            md.Children.Clear();

            // Preia instanta PaginaUser
            // Actualizeaza regiunea curenta
            Rember = PaginaUser.getInstance();
            Rember.updateCurrentRegion();

            // Adaug manual PaginaUser, altfel apare un bug in care nu am nici un
            // meniu in partea stanga
            // Verific daca are deja parinte sa nu dea eroare
            if (Rember.Parent == null)
            {
                this.md.Children.Add(Rember);
            }
            
            // End of Alex code

            verifica = null;
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
            #region Raul miscator
            #region Sus
             el = new Path();
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
             mijloc = new Path();

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
            #endregion

            AdaugCampie();
        }

        public void AdaugCampie()
        {
            Campie = new Path()
            {
                StrokeThickness = 2,
                Fill=new SolidColorBrush(Colors.Transparent),
                Cursor=Cursors.Hand
               
            };
            PathFigure PathFigureCampie = new PathFigure() { StartPoint = new Point(0, 400) };
            LineSegment l = new LineSegment() { Point = new Point(0, 505) };
            PathFigureCampie.Segments.Add(l);
            l = new LineSegment() { Point = new Point(canv.Width-1, canv.Height) };
            PathFigureCampie.Segments.Add(l);
            l = new LineSegment() { Point = new Point(canv.Width - 1, canv.Height-70) };
            PathFigureCampie.Segments.Add(l);
            BezierSegment bs = new BezierSegment() { Point1 = new Point(canv.Width - 1, canv.Height - 70), Point2 = new Point(690, 470), Point3 = new Point(655, 420) };
            PathFigureCampie.Segments.Add(bs);
            bs = new BezierSegment() { Point1 = new Point(655, 420), Point2 = new Point(655, 360), Point3 = new Point(565, 350) };
            PathFigureCampie.Segments.Add(bs);
            bs = new BezierSegment() { Point1 = new Point(565, 350), Point2 = new Point(520, 350), Point3 = new Point(465, 320) };
            PathFigureCampie.Segments.Add(bs);
            bs = new BezierSegment() { Point1 = new Point(465, 320), Point2 = new Point(380, 210), Point3 = new Point(320, 204) };
            PathFigureCampie.Segments.Add(bs);
            bs = new BezierSegment() { Point1 = new Point(320, 204), Point2 = new Point(200, 224), Point3 = new Point(180, 238) };
            PathFigureCampie.Segments.Add(bs);
            bs = new BezierSegment() { Point1 = new Point(180, 238), Point2 = new Point(100, 268), Point3 = new Point(97, 298) };
            PathFigureCampie.Segments.Add(bs);
            bs = new BezierSegment() { Point1 = new Point(97, 298), Point2 = new Point(140, 328), Point3 = new Point(0, 400) };
            PathFigureCampie.Segments.Add(bs);
            PathGeometry geometry = new PathGeometry();

            geometry.Figures.Add(PathFigureCampie);
            Campie.Data = geometry;
            canv.Children.Add(Campie);
            Campie.MouseEnter += new MouseEventHandler(Campie_MouseEnter);
            Campie.MouseLeave += new MouseEventHandler(Campie_MouseLeave);
            Campie.MouseLeftButtonDown += new MouseButtonEventHandler(Campie_MouseLeftButtonDown);
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            if (verifica == null)
            {
                Random r = new Random();
                double o = (double)r.Next(27, 30);
                hh.Scale = (double)(o / 1000);
                hh.Scaling = r.Next(95, 100);
            }
            else
            {
                if (grade == 360)
                {
                    tmr.Stop();

                }

                else grade = grade +4;
                if (grade == 272)
                {
                    canv.Children.Remove(Padure);
                    canv.Children.Remove(Campie);
                    canv.Children.Remove(mijloc);
                    canv.Children.Remove(el);
                    PlaneProjection planeproj = new PlaneProjection();
                    planeproj.RotationY = 0;
                    if (Animalule.getRegion() == "Padure")
                    {
                        img.Source = new BitmapImage(new Uri("Game/munte.jpg", UriKind.Relative));
                        AtributeGlobale.ZonaCurenta = AtributeGlobale.EnumZone.Forest;
                    }
                    else
                        if (Animalule.getRegion() == "Campie")
                        {
                            img.Source = new BitmapImage(new Uri("Game/campie.jpg", UriKind.Relative));
                            AtributeGlobale.ZonaCurenta = AtributeGlobale.EnumZone.Fields;
                        } 
                    img.Projection = planeproj;
                   // Regiuni.Padure pad = new Regiuni.Padure(canv,md);
                    
                  // pad.Peste();
                    Regiuni.Vizualizare pad = new Regiuni.Vizualizare(canv, md,lista);

                    pad.Peste();
                }
                p.RotationY = grade;
                p.CenterOfRotationY = 0.5;
                canv.Projection = p;
            }
        }
        Storyboard ab = new Storyboard();
        void Campie_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            verifica = true;
            tmr.Interval = new TimeSpan(0, 0, 0, 0, 20);
        }
        void Campie_MouseLeave(object sender, MouseEventArgs e)
        {
            AtributeGlobale.ZonaCurenta = AtributeGlobale.EnumZone.NoZoneSelected;
            md.Children.Clear();
            md.Children.Add(Rember);
            ab.Stop();
            ab.Children.Clear();

            DoubleAnimation da = new DoubleAnimation() { From = 0.5, To = 0, Duration = TimeSpan.FromMilliseconds(1) };
            Storyboard.SetTarget(da, Campie);
            Storyboard.SetTargetProperty(da, new PropertyPath(Path.OpacityProperty));

            ab.Children.Add(da);
            Campie.Fill = new SolidColorBrush(Colors.Transparent);
            ab.Begin();
        }
        void Campie_MouseEnter(object sender, MouseEventArgs e)
        {
            md.Children.Clear();
            Animalule l = new Animalule();
            Animalule.setRegion("Campie");
            AtributeGlobale.ZonaCurenta = AtributeGlobale.EnumZone.Fields;
            md.Children.Add(l);
            l.Aranjeaza(lista);
            ab.Stop();
            ab.Children.Clear();
            DoubleAnimation da = new DoubleAnimation() { From = 0, To = 0.5, Duration = TimeSpan.FromMilliseconds(1) };
            Storyboard.SetTarget(da, Campie);
            Storyboard.SetTargetProperty(da, new PropertyPath(Path.OpacityProperty));
            ab.Children.Add(da);
            Campie.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0x65, 0x70, 0x74));
            ab.Begin();
        }
        void tc_GetHistoryPadureCompleted(object sender, ServiceReference1.GetHistoryPadureCompletedEventArgs e)
        {
            
            foreach (var c in e.Result)
            {
                lista.Add(c);
            }
          
        }
        void Padure_MouseLeave(object sender, MouseEventArgs e)
        {
            AtributeGlobale.ZonaCurenta = AtributeGlobale.EnumZone.NoZoneSelected;
            md.Children.Clear();
            md.Children.Add(Rember);
            ab.Stop();
            ab.Children.Clear();
          
            DoubleAnimation da = new DoubleAnimation() { From = 0.5, To = 0, Duration = TimeSpan.FromMilliseconds(1) };
            Storyboard.SetTarget(da, Padure);
            Storyboard.SetTargetProperty(da, new PropertyPath(Path.OpacityProperty));
           
            ab.Children.Add(da);
            Padure.Fill = new SolidColorBrush(Colors.Transparent);
            ab.Begin();
        }
        void Padure_MouseEnter(object sender, MouseEventArgs e)
        {
            md.Children.Clear();
            Animalule l = new Animalule();
            Animalule.setRegion("Padure");
            AtributeGlobale.ZonaCurenta = AtributeGlobale.EnumZone.Forest;
            md.Children.Add(l);
        
            l.Aranjeaza(lista);
            ab.Stop();
            ab.Children.Clear();
            DoubleAnimation da = new DoubleAnimation() { From = 0, To = 0.5, Duration = TimeSpan.FromMilliseconds(1) };
            Storyboard.SetTarget(da, Padure);
            Storyboard.SetTargetProperty(da, new PropertyPath(Path.OpacityProperty));
            ab.Children.Add(da);
            Padure.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0x65, 0x70, 0x74));
            ab.Begin();

        }

        void Padure_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            verifica = true;
             tmr.Interval = new TimeSpan(0, 0, 0, 0,20);
           /* #region BackgroundCanvas
            Canvas background = new Canvas()
            {
                Width = 663,
                Height = 100,
                Background = new SolidColorBrush(Colors.Black),
                Opacity = 0.5
            };
            #endregion*/
          //  canv.Children.Add(background);
          //  Canvas.SetTop(background, 370);
          //  Canvas.SetLeft(background, 50);
         //   MeniuPicks p = new MeniuPicks(canv, 663, 100, "", 1, 50, 370);

         //   canv.Children.Add(p);
        }
        public Canvas Intoarce()
        {
            return canv;
        }

        public static void setGrade(double degrees)
        {
            grade = degrees;
        }
    }
}
