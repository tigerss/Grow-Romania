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
using Microsoft.Maps.MapControl;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using Forme;
using bing;
using System.ServiceModel;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;
using bing.Forme;

namespace Regiuni
{
    public class Moldova
    {
        BasicHttpBinding bind = new BasicHttpBinding();
       EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Service1.svc");
        
        bool i = false;
        private static MapPolygon MPMoldovaRegiune1;
        private static MapPolygon MPMoldovaRegiune2;
        private static MapPolygon MPMoldovaRegiune3;
        private static MapPolygon MPMoldovaRegiune4;
        Map map = new Map();
        private static Image img;
        Canvas can = new Canvas();
        DispatcherTimer dt;
        Canvas md;
        MapLayers mapl;
        Map m;
        List<bing.ServiceReference1.ProceduraRealJudet_Result> lista;
        private static double grade=0;
        private PlaneProjection p = new PlaneProjection();
        int reg1lista;
        int reg2lista;
        int reg3lista;
        int reg4lista;

        private static Moldova instance;

        public Moldova(Map m,Canvas c,Canvas md,MapLayers mapl,List<bing.ServiceReference1.ProceduraRealJudet_Result> lista,bool login)
        {
            i = login;
            this.md = md;
            this.m = m;
            this.mapl = mapl;
            this.lista = lista;
            for (int j = 0; j < lista.Count; j++)
            {
                if (lista[j].ID == 6)
                {
                    reg1lista = j;
                }
                if (lista[j].ID ==7)
                {
                    reg2lista = j;
                }
                if (lista[j].ID == 8)
                {
                    reg3lista = j;
                }
                if (lista[j].ID == 9)
                {
                    reg4lista = j;
                }
            }
            dt = new DispatcherTimer();
            MPMoldovaRegiune1 = new MapPolygon();
            MPMoldovaRegiune2 = new MapPolygon();
            MPMoldovaRegiune3 = new MapPolygon();
            MPMoldovaRegiune4 = new MapPolygon();

            MPMoldovaRegiune1.MouseEnter += new MouseEventHandler(MPMoldovaRegiune1_MouseEnter);
            MPMoldovaRegiune1.MouseLeave += new MouseEventHandler(MPMoldovaRegiune1_MouseLeave);
            MPMoldovaRegiune1.MouseLeftButtonDown += new MouseButtonEventHandler(MPMoldovaRegiune1_MouseLeftButtonDown);
            MPMoldovaRegiune2.MouseEnter += new MouseEventHandler(MPMoldovaRegiune2_MouseEnter);
            MPMoldovaRegiune2.MouseLeave += new MouseEventHandler(MPMoldovaRegiune2_MouseLeave);
            MPMoldovaRegiune2.MouseLeftButtonDown += new MouseButtonEventHandler(MPMoldovaRegiune2_MouseLeftButtonDown);
            MPMoldovaRegiune3.MouseEnter += new MouseEventHandler(MPMoldovaRegiune3_MouseEnter);
            MPMoldovaRegiune3.MouseLeave += new MouseEventHandler(MPMoldovaRegiune3_MouseLeave);
            MPMoldovaRegiune3.MouseLeftButtonDown += new MouseButtonEventHandler(MPMoldovaRegiune3_MouseLeftButtonDown);
            MPMoldovaRegiune4.MouseEnter += new MouseEventHandler(MPMoldovaRegiune4_MouseEnter);
            MPMoldovaRegiune4.MouseLeave += new MouseEventHandler(MPMoldovaRegiune4_MouseLeave);
            MPMoldovaRegiune4.MouseLeftButtonDown += new MouseButtonEventHandler(MPMoldovaRegiune4_MouseLeftButtonDown);
            map = m;
            can = c;
            dt.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dt.Tick += new EventHandler(dt_Tick);
            instance = this;
        }

        public bing.pesteHarta PestePoza
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        void dt_Tick(object sender, EventArgs e)
        {
            
            if (grade == 180)
            {
                dt.Stop();
            }
            else grade = grade + 2;
            if (grade == 90)
            {
                //intorc imaginea
                #region Adaug imagine scap de harta
                PlaneProjection planeproj = new PlaneProjection();
                planeproj.RotationY = 180;

                //sterg harta
                map.Visibility = Visibility.Collapsed;
                //can.Children.Remove(map);

                //remove children
                can.Children.Clear();

                // Add the Back Button
                CBackButton.getInstance().addButtonToCanvas();

                //iau imaginea
                img = new Image();
                img.Projection = planeproj;
                img.Width = can.Width;
                img.Height = can.Height;
                img.Stretch = Stretch.Fill;
                img.Source = new BitmapImage(new Uri("Game/testcupod.jpg", UriKind.Relative));
                #endregion
                
                can.Children.Add(img);
                Canvas.SetLeft(img, 0);
               //adaug strop
                pesteHarta pp = new pesteHarta(can,p,img,md,mapl,m);
                //pp.AdaugCampie();
                can = pp.Intoarce();
            }
            p.RotationY = grade;
            p.CenterOfRotationY = 0.5;
            can.Projection = p;
        }
    
        private void Intoarce()
        {
            can.Background = new SolidColorBrush(Colors.Black);
            dt.Start();
        }
        public MapPolygon MoldovaRegiune1()
        {
            MPMoldovaRegiune1.Stroke = new SolidColorBrush(Colors.Red);
            MPMoldovaRegiune1.Fill = new SolidColorBrush(Colors.Gray);
            MPMoldovaRegiune1.StrokeThickness = 0;
            MPMoldovaRegiune1.Opacity = 0.8;

            #region Puncte
            MPMoldovaRegiune1.Locations = new LocationCollection() 
            { 
                //Botosani
                new Location(47.62, 27.38), new Location(47.65, 27.34), new Location(47.72, 27.28), new Location(47.74, 27.27),
                new Location(47.76, 27.28), new Location(47.78, 27.29), new Location(47.82, 27.23), new Location(47.84, 27.24),
                new Location(47.86, 27.22), new Location(47.90, 27.22), new Location(47.94, 27.16), new Location(47.96, 27.18),
                new Location(47.98, 27.17), new Location(48.04, 27.08), new Location(48.06, 27.09), new Location(48.10, 27.03),
                new Location(48.14, 27.04), new Location(48.14, 27.00), new Location(48.13, 26.97), new Location(48.17, 26.97),  
                new Location(48.19, 26.94), new Location(48.23, 26.89), new Location(48.24, 26.85), new Location(48.24, 26.80),
                new Location(48.25, 26.76), new Location(48.26, 26.70), new Location(48.25, 26.66), new Location(48.24, 26.62),
                new Location(48.24, 26.62), new Location(48.22, 26.60), new Location(48.21, 26.52), new Location(48.21, 26.46),
                new Location(48.20, 26.44), new Location(48.19, 26.36), new Location(48.18, 26.32), new Location(48.16, 26.32),
                new Location(48.15, 26.34), new Location(48.14, 26.30), new Location(48.08, 26.28), new Location(48.06, 26.24),
                new Location(48.02, 26.22), new Location(47.99, 26.19), new Location(47.99, 26.10), new Location(47.98, 26.05),

                //Suceava
                new Location(47.99, 26.00), new Location(47.96, 25.96), new Location(47.97, 25.92), new Location(47.94, 25.90),
                new Location(47.96, 25.85), new Location(47.95, 25.83), new Location(47.94, 25.75), new Location(47.94, 25.73),
                new Location(47.95, 25.63), new Location(47.93, 25.60), new Location(47.92, 25.33), new Location(47.92, 25.33),
                new Location(47.89, 25.23), new Location(47.85, 25.21), new Location(47.77, 25.13), new Location(47.75, 25.14),
                new Location(47.75, 25.10), new Location(47.73, 25.05), new Location(47.72, 24.91),

                //Suceava granita  cu transilvania
                new Location(47.645, 25.045), new Location(47.62, 24.98), new Location(47.58, 24.98), new Location(47.54, 25.04),
                new Location(47.50, 25.04), new Location(47.50, 25.08), new Location(47.48, 25.09), new Location(47.46, 25.05),
                new Location(47.43, 25.05), new Location(47.43, 25.01), new Location(47.41, 25.00), new Location(47.39, 25.06),
                new Location(47.33, 25.08), new Location(47.30, 25.04), new Location(47.27, 25.04), new Location(47.24, 25.08),
                new Location(47.20, 25.05), new Location(47.13, 25.09), new Location(47.13, 25.15), new Location(47.15, 25.17),
                new Location(47.10, 25.23),

                //granita sucevei cu jud. harghita
                new Location(47.10, 25.26), new Location(47.13, 25.30), new Location(47.11, 25.33), new Location(47.10, 25.38),
                new Location(47.105, 25.40), new Location(47.13, 25.40), new Location(47.14, 25.45), new Location(47.135, 25.47),
                new Location(47.13, 25.50), new Location(47.13, 25.53), new Location(47.09, 25.53), new Location(47.07, 25.60),
                new Location(47.10, 25.60), new Location(47.095, 25.69),

                //Suceava Sud
                new Location(47.16,25.70), new Location(47.18,25.72), new Location(47.20,25.74), new Location(47.22,25.76),
                new Location(47.24,25.82), new Location(47.26,25.83), new Location(47.26,25.82), new Location(47.28,25.79),
                new Location(47.30,25.78), new Location(47.32,25.77), new Location(47.33,25.76), new Location(47.33,25.77),//?????
                new Location(47.31,25.78), new Location(47.31,25.85), new Location(47.29,25.88), new Location(47.28,25.90),
                new Location(47.27,25.92), new Location(47.28,25.95), new Location(47.29,25.98), new Location(47.29,26),
                new Location(47.28,26.03), new Location(47.27,26.06), new Location(47.28,26.08), new Location(47.28,26.11),
                new Location(47.29,26.13), new Location(47.29,26.18), new Location(47.285,26.25), new Location(47.30,26.28),
                new Location(47.32,26.32), new Location(47.32,26.35), new Location(47.33,26.39), new Location(47.34,26.41),
                new Location(47.27,26.50),  new Location(47.26,26.57), new Location(47.27,26.59), new Location(47.30,26.59),
                new Location(47.34,26.50),

                //Botosani sud
                new Location(47.39,26.49), new Location(47.40,26.51), new Location(47.35,26.60), new Location(47.355,26.67),
                new Location(47.47,26.67), new Location(47.53,26.73), new Location(47.52,26.78), new Location(47.50,26.87),
                new Location(47.50,26.99), new Location(47.43,27.04), new Location(47.48,27.09), new Location(47.56,27.09),
                new Location(47.56,27.10), new Location(47.53,27.17), new Location(47.53,27.25), new Location(47.58,27.28),
                new Location(47.59,27.40), new Location(47.63,27.41)
            };
            #endregion

            return MPMoldovaRegiune1;
        }
        public MapPolygon MoldovaRegiune2()
        {
            MPMoldovaRegiune2.Stroke = new SolidColorBrush(Colors.Red);
            MPMoldovaRegiune2.Fill = new SolidColorBrush(Colors.Gray);
            MPMoldovaRegiune2.StrokeThickness = 0;
            MPMoldovaRegiune2.Opacity = 0.7;

            #region Puncte
            MPMoldovaRegiune2.Locations = new LocationCollection() 
            { 
                //neamt
                new Location(46.68, 25.97), new Location(46.70, 25.95), new Location(46.70, 25.95), new Location(46.705, 25.91),
                new Location(46.69, 25.90), new Location(46.65, 25.92), new Location(46.65, 25.88), new Location(46.69, 25.83),
                new Location(46.72, 25.80), new Location(46.75, 25.82), new Location(46.78, 25.82), new Location(46.83, 25.80),
                new Location(46.83, 25.77), new Location(46.89, 25.76), new Location(46.92, 25.80), new Location(46.92, 25.835),
                new Location(46.94, 25.84), new Location(46.96, 25.86), new Location(46.98, 25.85), new Location(46.99, 25.83),
                new Location(46.97, 25.81), new Location(46.97, 25.79), new Location(47.00, 25.79), new Location(47.05, 25.75),
                new Location(47.08, 25.72),

                //Suceava Sud
                new Location(47.16,25.70), new Location(47.18,25.72), new Location(47.20,25.74), new Location(47.22,25.76),
                new Location(47.24,25.82), new Location(47.26,25.83), new Location(47.26,25.82), new Location(47.28,25.79),
                new Location(47.30,25.78), new Location(47.32,25.77), new Location(47.33,25.76), new Location(47.33,25.77),//?????
                new Location(47.31,25.78), new Location(47.31,25.85), new Location(47.29,25.88), new Location(47.28,25.90),
                new Location(47.27,25.92), new Location(47.28,25.95), new Location(47.29,25.98), new Location(47.29,26),
                new Location(47.28,26.03), new Location(47.27,26.06), new Location(47.28,26.08), new Location(47.28,26.11),
                new Location(47.29,26.13), new Location(47.29,26.18), new Location(47.285,26.25), new Location(47.30,26.28),
                new Location(47.32,26.32), new Location(47.32,26.35), new Location(47.33,26.39), new Location(47.34,26.41),
                new Location(47.27,26.50),  new Location(47.26,26.57), new Location(47.27,26.59), new Location(47.30,26.59),
                new Location(47.34,26.50),

                //Botosani sud
                new Location(47.39,26.49), new Location(47.40,26.51), new Location(47.35,26.60), new Location(47.355,26.67),
                new Location(47.47,26.67), new Location(47.53,26.73), new Location(47.52,26.78), new Location(47.50,26.87),
                new Location(47.50,26.99), new Location(47.43,27.04), new Location(47.48,27.09), new Location(47.56,27.09),
                new Location(47.56,27.10), new Location(47.53,27.17), new Location(47.53,27.25), new Location(47.58,27.28),
                new Location(47.59,27.40), new Location(47.63,27.41),

                //Iasi est
                new Location(47.58, 27.45), new Location(47.53, 27.45), new Location(47.48, 27.50),
                new Location(47.47, 27.60), new Location(47.45, 27.59), new Location(47.43, 27.56), new Location(47.39, 27.58),
                new Location(47.37, 27.60), new Location(47.35, 27.62), new Location(47.34, 27.60), new Location(47.31, 27.64),
                new Location(47.31, 27.65), new Location(47.30, 27.75), new Location(47.16, 27.80), new Location(47.06, 27.94),
                new Location(47.06, 28.00), new Location(46.98, 28.11), new Location(46.94, 28.10), new Location(46.92, 28.10),
                new Location(46.87, 28.13), new Location(46.85, 28.11),

                //iasi + neamt sud, est->vest
                new Location(46.85,28.00), new Location(46.86,27.94), new Location(46.81,27.94), new Location(46.89,27.81),
                new Location(46.93,27.79), new Location(46.93,27.76), new Location(46.90,27.76), new Location(46.90, 27.74),
                new Location(46.99,27.66), new Location(46.99,27.63), new Location(46.95,27.62), new Location(46.90,27.65),
                new Location(46.88,27.55), new Location(46.91,27.55), new Location(46.91,27.52), new Location(46.88,27.52),
                new Location(46.88, 27.45), new Location(46.90,27.37), new Location(46.87,27.30),
                new Location(46.87,27.20), new Location(46.80,27.205), new Location(46.75,27.16), new Location(46.75,27.13),
                new Location(46.77,27.09), new Location(46.77,26.94), new Location(46.82,26.89), new Location(46.82,26.87),
                new Location(46.74,26.82), new Location(46.74,26.79), new Location(46.77,26.73),
                new Location(46.76,26.70), new Location(46.75,26.66), new Location(46.71,26.61), new Location(46.68,26.58),
                new Location(46.68,26.54), new Location(46.69,26.51), new Location(46.69,26.50), new Location(46.65,26.37),
                new Location(46.66,26.31),new Location(46.71,26.27), new Location(46.71,26.24), new Location(46.64,26.17),
                new Location(46.66,26.13), new Location(46.66, 26.08), new Location(46.70,26.06), new Location(46.70,25.97)
            };
            #endregion

            return MPMoldovaRegiune2;
        }
        public MapPolygon MoldovaRegiune3()
        {
            MPMoldovaRegiune3.Fill = new SolidColorBrush(Colors.Gray);
            MPMoldovaRegiune3.Stroke = new SolidColorBrush(Colors.Red);
            MPMoldovaRegiune3.StrokeThickness = 0;
            MPMoldovaRegiune3.Opacity = 0.6;

            #region Puncte
            MPMoldovaRegiune3.Locations = new LocationCollection()
             {
                //vaslui
                new Location(46.10, 28.09), new Location(46.14, 28.14), new Location(46.16, 28.12),
                new Location(46.20, 28.14), new Location(46.22, 28.12), new Location(46.25, 28.14), new Location(46.27, 28.14),
                new Location(46.30, 28.17), new Location(46.34, 28.22), new Location(46.37, 28.19), new Location(46.39, 28.22),
                new Location(46.43, 28.25), new Location(46.46, 28.25), new Location(46.50, 28.23), new Location(46.54, 28.21),
                new Location(46.63, 28.26), new Location(46.73, 28.20), new Location(46.77, 28.19), new Location(46.82, 28.12),
                new Location(46.84, 28.12), new Location(46.85, 28.11),
               
                //iasi + neamt sud, est->vest
                new Location(46.85,28.00), new Location(46.86,27.94), new Location(46.81,27.94), new Location(46.89,27.81),
                new Location(46.93,27.79), new Location(46.93,27.76), new Location(46.90,27.76), new Location(46.90, 27.74),
                new Location(46.99,27.66), new Location(46.99,27.63), new Location(46.95,27.62), new Location(46.90,27.65),
                new Location(46.88,27.55), new Location(46.91,27.55), new Location(46.91,27.52), new Location(46.88,27.52),
                new Location(46.88, 27.45), new Location(46.90,27.37), new Location(46.87,27.30),
                new Location(46.87,27.20), new Location(46.80,27.205), new Location(46.75,27.16), new Location(46.75,27.13),
                new Location(46.77,27.09), new Location(46.77,26.94), new Location(46.82,26.89), new Location(46.82,26.87),
                new Location(46.74,26.82), new Location(46.74,26.79), new Location(46.77,26.73),
                new Location(46.76,26.70), new Location(46.75,26.66), new Location(46.71,26.61), new Location(46.68,26.58),
                new Location(46.68,26.54), new Location(46.69,26.51), new Location(46.69,26.50), new Location(46.65,26.37),
                new Location(46.66,26.31), new Location(46.71,26.27), new Location(46.71,26.24), new Location(46.64,26.17),
                new Location(46.66,26.13), new Location(46.66, 26.08), new Location(46.70,26.06), new Location(46.70,25.97),

                //bacau
                new Location(46.64, 26.01), new Location(46.62, 25.995), new Location(46.60, 26.03), new Location(46.55, 26.04),
                new Location(46.50, 26.08), new Location(46.47, 26.01), new Location(46.45, 25.98), new Location(46.42, 26.00),
                new Location(46.42, 26.03), new Location(46.40, 26.07), new Location(46.42, 26.105), new Location(46.41, 26.18),
                new Location(46.36, 26.18), new Location(46.33, 26.16), new Location(46.31, 26.17), new Location(46.31, 26.21),
                new Location(46.35, 26.25), new Location(46.35, 26.27), new Location(46.33, 26.30), new Location(46.27, 26.27),
                new Location(46.25, 26.27), new Location(46.25, 26.31), new Location(46.24, 26.33),
                new Location(46.15, 26.34), new Location(46.12, 26.33), new Location(46.09, 26.39), new Location(46.10, 26.42),

                //bacau + vaslui sud; vest->est
                new Location(46.05,26.43), new Location(46.03,26.44), new Location(46.03,26.51), new Location(46.02,26.55),
                new Location(46.06,26.64), new Location(46.08,26.68), new Location(46.09,26.75),
                new Location(46.06,26.84), new Location(46.08,26.86), new Location(46.07,26.94),
                new Location(46.12,26.98), new Location(46.12,26.99), new Location(46.08,27.05), new Location(46.08,27.07),
                new Location(46.11,27.09), new Location(46.11,27.15), new Location(46.14,27.12), new Location(46.18,27.21),
                new Location(46.17,27.25), new Location(46.20,27.29), new Location(46.19,27.33),
                new Location(46.16,27.35), new Location(46.16,27.38), new Location(46.20,27.41), new Location(46.20,27.44),
                new Location(46.10,27.53), new Location(46.03,27.53), new Location(46.01,27.60), new Location(46.08,27.60),
                new Location(46.07,27.64), new Location(46.14,27.60), new Location(46.14,27.75), new Location(46.10,27.77),
                new Location(46.10,27.80), new Location(46.15,27.86), new Location(46.15,27.89), new Location(46.14,27.96),
                new Location(46.12,28.03), new Location(46.11,28.10)
            };
            #endregion

            return MPMoldovaRegiune3;
        }
        public MapPolygon MoldovaRegiune4()
        {
            MPMoldovaRegiune4.Fill = new SolidColorBrush(Colors.Gray);
            MPMoldovaRegiune4.Stroke = new SolidColorBrush(Colors.Red);
            MPMoldovaRegiune4.StrokeThickness = 0;
            MPMoldovaRegiune4.Opacity = 0.5;

            #region Puncte
            MPMoldovaRegiune4.Locations = new LocationCollection()
             {   
                //granita tulceea
                new Location(45.44, 28.20), new Location(45.40, 28.20), new Location(45.40, 28.16), new Location(45.43, 28.16),
                new Location(45.45, 28.10), new Location(45.45, 28.06),

                //granita galati
                new Location(45.42, 28.03), new Location(45.39, 27.97), new Location(45.40, 27.92), new Location(45.43, 27.88),
                new Location(45.39, 27.86), new Location(45.41, 27.78), new Location(45.43, 27.79), new Location(45.43, 27.77),
                new Location(45.42, 27.74), new Location(45.44, 27.74), new Location(45.47, 27.66), new Location(45.50, 27.68),
                new Location(45.50, 27.66), new Location(45.46, 27.62), new Location(45.46, 27.60),
                   
                //granita braila
                new Location(45.50, 27.58), new Location(45.50, 27.57), new Location(45.47, 27.57), new Location(45.47, 27.52),
                new Location(45.41, 27.48), 
                  
                //granita buzau
                new Location(45.43, 27.45), new Location(45.41, 27.43), new Location(45.39, 27.43), new Location(45.37, 27.40),
                new Location(45.37, 27.31), new Location(45.39, 27.29), new Location(45.43, 27.29), new Location(45.45, 27.27),
                new Location(45.44, 27.23), new Location(45.45, 27.20), new Location(45.43, 27.18), new Location(45.45, 27.10),
                new Location(45.47, 27.14), new Location(45.48, 27.11), new Location(45.45, 27.08), new Location(45.45, 27.03),
                new Location(45.50, 26.99), new Location(45.53, 26.99), new Location(45.53, 26.97), new Location(45.54, 26.94),
                new Location(45.53, 26.90), new Location(45.53, 26.82), new Location(45.55, 26.80), new Location(45.55, 26.77), 
                new Location(45.57, 26.73), new Location(45.59, 26.70), new Location(45.59, 26.66), new Location(45.63, 26.64),
                new Location(45.63, 26.60), new Location(45.62, 26.57), new Location(45.63, 26.55), new Location(45.65, 26.52),
                new Location(45.70, 26.48), new Location(45.73, 26.46), new Location(45.73, 26.44), new Location(45.79, 26.43), 
                
                //vrancea
                new Location(45.80, 26.39), new Location(45.85, 26.37), new Location(45.87, 26.39), new Location(45.90, 26.37),
                new Location(45.93, 26.39), new Location(45.97, 26.41), new Location(46.00, 26.46), new Location(46.04, 26.46),
                  
                //bacau + vaslui sud; vest->est
                new Location(46.05,26.43), new Location(46.03,26.44), new Location(46.03,26.51), new Location(46.02,26.55),
                new Location(46.06,26.64), new Location(46.08,26.68), new Location(46.09,26.75),
                new Location(46.06,26.84), new Location(46.08,26.86), new Location(46.07,26.94),
                new Location(46.12,26.98), new Location(46.12,26.99), new Location(46.08,27.05), new Location(46.08,27.07),
                new Location(46.11,27.09), new Location(46.11,27.15), new Location(46.14,27.12), new Location(46.18,27.21),
                new Location(46.17,27.25), new Location(46.20,27.29), new Location(46.19,27.33),
                new Location(46.16,27.35), new Location(46.16,27.38), new Location(46.20,27.41), new Location(46.20,27.44),
                new Location(46.10,27.53), new Location(46.03,27.53), new Location(46.01,27.60), new Location(46.08,27.60),
                new Location(46.07,27.64), new Location(46.14,27.60), new Location(46.14,27.75), new Location(46.10,27.77),
                new Location(46.10,27.80), new Location(46.15,27.86), new Location(46.15,27.89), new Location(46.14,27.96),
                new Location(46.12,28.03), new Location(46.11,28.10),

                //galati
                new Location(46.14, 28.14), new Location(46.04, 28.09), new Location(46.02, 28.11), new Location(45.96, 28.12),
                new Location(45.90, 28.12), new Location(45.86, 28.10), new Location(45.84, 28.12), new Location(45.78, 28.12),
                new Location(45.76, 28.16), new Location(45.64, 28.16), new Location(45.63, 28.10), new Location(45.58, 28.10),
                new Location(45.57, 28.16), new Location(45.47, 28.20), new Location(45.47, 28.25)
            };
            #endregion

            return MPMoldovaRegiune4;
        }
         
        void MPMoldovaRegiune1_MouseEnter(object sender, MouseEventArgs e)
        {
            MPMoldovaRegiune1.StrokeThickness = 3;
         
                mapl.ADDInfoCanvas(lista[reg1lista].Clima,lista[reg1lista].Temperatura.ToString(),lista[reg1lista].Precipitatii.ToString(),48,27);
     
        }
        void MPMoldovaRegiune1_MouseLeave(object sender, MouseEventArgs e)
        {
            MPMoldovaRegiune1.StrokeThickness = 0;
            mapl.RemoveinfoCanvas();
        }
        void MPMoldovaRegiune1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Check if the user has logged in
            if (LoginForm.getInstance().userLoggedIn() ==true)
            {
                Intoarce();
            }
            else
            {
                can.Children.Add(new Info(lista, 6, m, can));
            }

            // Set the current SubRegion
            AtributeGlobale.SubRegiuneaCurenta = AtributeGlobale.EnumSubRegiuni.SubRegion1;
        }
        void MPMoldovaRegiune2_MouseEnter(object sender, MouseEventArgs e)
        {
            MPMoldovaRegiune2.StrokeThickness = 3;
            if ( reg2lista < lista.Count )
                mapl.ADDInfoCanvas(lista[reg2lista].Clima, lista[reg2lista].Temperatura.ToString(), lista[reg2lista].Precipitatii.ToString(),47,26);
     
        }
        void MPMoldovaRegiune2_MouseLeave(object sender, MouseEventArgs e)
        {
            MPMoldovaRegiune2.StrokeThickness = 0;
            mapl.RemoveinfoCanvas();
        }
        void MPMoldovaRegiune2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Check if the user has logged in
            if (LoginForm.getInstance().userLoggedIn() == true)
            {
                Intoarce();

            }
            else
            {
                can.Children.Add(new Info(lista, 7,m,can));
            }

            // Set the current SubRegion
            AtributeGlobale.SubRegiuneaCurenta = AtributeGlobale.EnumSubRegiuni.SubRegion2;
        }
        void MPMoldovaRegiune3_MouseEnter(object sender, MouseEventArgs e)
        {
            MPMoldovaRegiune3.StrokeThickness = 3;
            mapl.ADDInfoCanvas(lista[reg3lista].Clima, lista[reg3lista].Temperatura.ToString(), lista[reg3lista].Precipitatii.ToString(),47.23,25);
    
        }
        void MPMoldovaRegiune3_MouseLeave(object sender, MouseEventArgs e)
        {
            MPMoldovaRegiune3.StrokeThickness = 0;
            mapl.RemoveinfoCanvas();
        }
        void MPMoldovaRegiune3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Check if the user has logged in
            if (LoginForm.getInstance().userLoggedIn() == true)
            {
                Intoarce();

            }
            else
            {
                can.Children.Add(new Info(lista, 8, m, can));
            }

            // Set the current SubRegion
            AtributeGlobale.SubRegiuneaCurenta = AtributeGlobale.EnumSubRegiuni.SubRegion3;
        }
        void MPMoldovaRegiune4_MouseEnter(object sender, MouseEventArgs e)
        {
            mapl.ADDInfoCanvas(lista[reg4lista].Clima, lista[reg4lista].Temperatura.ToString(), lista[reg4lista].Precipitatii.ToString(),46,25);
    
            MPMoldovaRegiune4.StrokeThickness = 3;
        }
        void MPMoldovaRegiune4_MouseLeave(object sender, MouseEventArgs e)
        {
            MPMoldovaRegiune4.StrokeThickness = 0;
            mapl.RemoveinfoCanvas();
        }
        void MPMoldovaRegiune4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Check if the user has logged in
            if (LoginForm.getInstance().userLoggedIn() == true)
            {
                Intoarce();

            }
            else
            {
                can.Children.Add(new Info(lista, 9, m, can));
            }

            // Set the current SubRegion
            AtributeGlobale.SubRegiuneaCurenta = AtributeGlobale.EnumSubRegiuni.SubRegion4;
        }

        /// <summary>
        /// Setter for the projection degrees
        /// </summary>
        /// <param name="degrees"></param>
        public static void setGrade(double degrees)
        {
            grade = degrees;
        }

        /// <summary>
        /// Returns the current instance
        /// </summary>
        /// <returns></returns>
        public static Moldova getInstance()
        {
            if (instance != null)
                return instance;
            return null;
        }

        /// <summary>
        /// Call Intoarce() to go from other regions in Moldova
        /// </summary>
        public void goToMoldova()
        {
            Intoarce();
        }
    }
}
