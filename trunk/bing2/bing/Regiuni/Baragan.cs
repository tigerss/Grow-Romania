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
using bing;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace Regiuni
{
    public class Baragan
    {
        bool i = false;
        Map map = new Map();
        private static Image img;
        Canvas can = new Canvas();
        DispatcherTimer dt;
        Canvas md;
        MapLayers mapl;
        Map m;
        List<bing.ServiceReference1.ProceduraRealJudet_Result> lista;
        private PlaneProjection p = new PlaneProjection();
        private static double grade = 0;
        int reg1lista;
        int reg2lista;
        int reg3lista;
        int reg4lista;
        public Baragan(Map m, Canvas c, Canvas md, MapLayers mapl, List<bing.ServiceReference1.ProceduraRealJudet_Result> lista, bool login)
        {
            i = login;
            this.md = md;
            this.m = m;
            this.mapl = mapl;
            this.lista = lista;
            for (int j = 0; j < lista.Count; j++)
            {
                if (lista[j].ID == 10)
                {
                    reg1lista = j;
                }
                if (lista[j].ID == 11)
                {
                    reg2lista = j;
                }
                if (lista[j].ID == 12)
                {
                    reg3lista = j;
                }
                if (lista[j].ID == 13)
                {
                    reg4lista = j;
                }
            }
            dt = new DispatcherTimer();
            MPBaraganRegiune1 = new MapPolygon();
            MPBaraganRegiune2 = new MapPolygon();
            MPBaraganRegiune3 = new MapPolygon();
            MPBaraganRegiune4 = new MapPolygon();
            MPBaraganRegiune1.MouseEnter += new MouseEventHandler(MPBaraganRegiune1_MouseEnter);
            MPBaraganRegiune1.MouseLeave += new MouseEventHandler(MPBaraganRegiune1_MouseLeave);
            MPBaraganRegiune1.MouseLeftButtonDown += new MouseButtonEventHandler(MPBaraganRegiune1_MouseLeftButtonDown);
            MPBaraganRegiune2.MouseEnter += new MouseEventHandler(MPBaraganRegiune2_MouseEnter);
            MPBaraganRegiune2.MouseLeave += new MouseEventHandler(MPBaraganRegiune2_MouseLeave);
            MPBaraganRegiune2.MouseLeftButtonDown += new MouseButtonEventHandler(MPBaraganRegiune2_MouseLeftButtonDown);
            MPBaraganRegiune3.MouseEnter += new MouseEventHandler(MPBaraganRegiune3_MouseEnter);
            MPBaraganRegiune3.MouseLeave += new MouseEventHandler(MPBaraganRegiune3_MouseLeave);
            MPBaraganRegiune3.MouseLeftButtonDown += new MouseButtonEventHandler(MPBaraganRegiune3_MouseLeftButtonDown);
            MPBaraganRegiune4.MouseEnter += new MouseEventHandler(MPBaraganRegiune4_MouseEnter);
            MPBaraganRegiune4.MouseLeave += new MouseEventHandler(MPBaraganRegiune4_MouseLeave);
            MPBaraganRegiune4.MouseLeftButtonDown += new MouseButtonEventHandler(MPBaraganRegiune4_MouseLeftButtonDown);

            map = m;
            can = c;
            dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dt.Tick += new EventHandler(dt_Tick);
        }

        void MPBaraganRegiune4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (i == true)
            {
                Intoarce();

            }
            else
            {
                can.Children.Clear();

                can.Children.Add(new Info(lista, 13, m, can));
            }
        }

        void MPBaraganRegiune3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (i == true)
            {
                Intoarce();

            }
            else
            {
                can.Children.Clear();

                can.Children.Add(new Info(lista, 12, m, can));
            }
        }

        void MPBaraganRegiune2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (i == true)
            {
                Intoarce();

            }
            else
            {
                can.Children.Clear();

                can.Children.Add(new Info(lista, 11, m, can));
            }
        }

        void MPBaraganRegiune1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (i == true)
            {
                Intoarce();

            }
            else
            {
                can.Children.Clear();

                can.Children.Add(new Info(lista, 10, m, can));
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
            {//intorc imaginea
                #region Adaug imagine scap de harta
                PlaneProjection planeproj = new PlaneProjection();
                planeproj.RotationY = 180;
                //terg harta
                map.Visibility = Visibility.Collapsed;
                can.Children.Remove(map);
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
                pesteHarta pp = new pesteHarta(can, p, img, md, mapl, m);
                pp.AdaugCampie();
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
      
        #region Variabile
        private static MapPolygon MPBaraganRegiune1;
        private static MapPolygon MPBaraganRegiune2;
        private static MapPolygon MPBaraganRegiune3;
        private static MapPolygon MPBaraganRegiune4;
        #endregion
        #region Harti-Subregiuni
        public MapPolygon BaraganRegiune1()
        {

            MPBaraganRegiune1.Stroke = new SolidColorBrush(Colors.Red);
            MPBaraganRegiune1.Fill = new SolidColorBrush(Colors.Gray);
            MPBaraganRegiune1.StrokeThickness = 0;
            MPBaraganRegiune1.Opacity = 0.7;
            MPBaraganRegiune1.Locations = new LocationCollection() { 
            //constanta
                new Location(44.128, 27.274), new Location(44.074, 27.29),
                new Location(44.056, 27.36), new Location(44.013, 27.4),
                new Location(44.022, 27.47), new Location(44.012, 27.611),
                new Location(44.012, 27.611), new Location(44.05, 27.642),
                new Location(44.03, 27.675), new Location(43.961, 27.71),
                new Location(43.952, 27.74), new Location(43.958, 27.76),
                new Location(43.965, 27.84), new Location(44.009, 27.916),
                new Location(43.987, 27.944), new Location(43.94, 27.955),
                new Location(43.91, 27.97), new Location(43.846, 27.994),
                new Location(43.83, 28.03), new Location(43.757, 28.24),
                new Location(43.753, 28.35), new Location(43.735, 28.45),
                //litoral
                new Location(43.74, 28.585), new Location(43.76, 28.58),
                new Location(43.80, 28.59), new Location(43.845, 28.62),
                new Location(43.885, 28.62), new Location(43.91, 28.645),
                new Location(43.95, 28.65), new Location(43.985, 28.677),
                new Location(44.0, 28.67), new Location(44.078, 28.65),
                new Location(44.083, 28.685), new Location(44.15, 28.68),
                new Location(44.22, 28.654), new Location(44.275, 28.634),
                new Location(44.313, 28.65), new Location(44.3, 28.68),
                new Location(44.41, 28.812), new Location(44.48, 28.875),
                new Location(44.52, 28.92), new Location(44.55, 28.93),
                new Location(44.7, 29.05), new Location(44.75, 29.20),
                new Location(44.77, 29.35), new Location(44.75, 29.57),
                new Location(44.81, 29.61), new Location(44.98, 29.65),
                new Location(45.16, 29.70),
              //DELTA DUNARII
              new Location(45.20, 29.70),  new Location(45.24, 29.67), 
              new Location(45.27, 29.70),  new Location(45.35, 29.69), 
              new Location(45.38, 29.64),  new Location(45.43, 29.47),
              new Location(45.45, 29.45),  new Location(45.42, 29.20),
              new Location(45.39, 29.18),  new Location(45.38, 29.10),
              new Location(45.37, 29.05),  new Location(45.35, 29.00),
              new Location(45.32, 28.95),  new Location(45.28, 28.94),
              new Location(45.34, 28.80),  new Location(45.30, 28.80),
              new Location(45.30, 28.76),  new Location(45.24, 28.79),
              new Location(45.22, 28.72),  new Location(45.27, 28.50),
              new Location(45.31, 28.35),  new Location(45.35, 28.33),
              new Location(45.40, 28.30),  new Location(45.46, 28.28),

              //tulcea vest nord->sud
             new Location(45.48,28.19), new Location(45.42,28.19),
             new Location(45.41,28.18), new Location(45.44,28.13),
             new Location(45.44,28.09), new Location(45.41,28.04),
             new Location(45.28,28.00), new Location(45.25,28.09),
             new Location(45.25,28.12), new Location(45.24,28.13),
             new Location(45.21,28.13), new Location(45.19,28.10),
             new Location(45.18,28.10), new Location(45.13,28.19),
             new Location(45.11,28.17), new Location(45.10,28.17),
             new Location(45.09,28.17), new Location(45.09,28.14),
             new Location(45.05,28.14), new Location(45.04,28.16),
             new Location(45.01,28.14), new Location(44.96,28.15),
             new Location(44.92, 28.13), new Location(44.88,28.14),
             new Location(44.86,28.11), new Location(44.80,28.08),
             new Location(44.76,28.04), new Location(44.75,28.01),
             new Location(44.78,27.95), new Location(44.77,27.89),
             
             //constanta vest nord->sud
             new Location(44.71,27.88), new Location(44.68,27.94),
             new Location(44.68,27.94), new Location(44.64,28.03),
             new Location(44.61,28.03), new Location(44.59,28.01),
             new Location(44.57,28.01), new Location(44.53,28.04),
             new Location(44.51,28.04), new Location(44.48, 28.09),
             new Location(44.45,28.09), new Location(44.42,28.11),
             new Location(44.41,28.08), new Location(44.36,28.02),
             new Location(44.32,28.02), new Location(44.28,27.98),
             new Location(44.27,27.98), new Location(44.25,27.95),
             new Location(44.25,27.89), new Location(44.24,27.87),
             new Location(44.24,27.82), new Location(44.19,27.73),
             new Location(44.21,27.64), new Location(44.18,27.56),
             new Location(44.13,27.47), new Location(44.12,27.36),
             new Location(44.14,27.33), new Location(44.14,27.30),
             new Location(44.128, 27.274)

           };
            return MPBaraganRegiune1;
        }
        public MapPolygon BaraganRegiune2()
        {
         
            MPBaraganRegiune2.Stroke = new SolidColorBrush(Colors.Red);
            MPBaraganRegiune2.Fill = new SolidColorBrush(Colors.Gray);
            MPBaraganRegiune2.StrokeThickness = 0;

            MPBaraganRegiune2.Opacity = 0.6;
            MPBaraganRegiune2.Locations = new LocationCollection() { 
            
             //granita buzau
             new Location(45.79, 26.43), new Location(45.73, 26.44),
             new Location(45.73, 26.46), new Location(45.70, 26.48),
             new Location(45.65, 26.52), new Location(45.63, 26.55),
             new Location(45.62, 26.57), new Location(45.63, 26.60),
             new Location(45.63, 26.64), new Location(45.59, 26.66),
             new Location(45.59, 26.70), new Location(45.57, 26.73),
             new Location(45.55, 26.77), new Location(45.55, 26.80),
             new Location(45.53, 26.82), new Location(45.53, 26.90),
             new Location(45.54, 26.94), new Location(45.53, 26.97),
             new Location(45.53, 26.99), new Location(45.50, 26.99),
             new Location(45.45, 27.03), new Location(45.45, 27.08),
             new Location(45.48, 27.11), new Location(45.47, 27.14),
             new Location(45.45, 27.10), new Location(45.43, 27.18),
             new Location(45.45, 27.20), new Location(45.44, 27.23),
             new Location(45.45, 27.27), new Location(45.43, 27.29),
             new Location(45.39, 27.29), new Location(45.37, 27.31),
             new Location(45.37, 27.40), new Location(45.39, 27.43),
             new Location(45.41, 27.43), new Location(45.43, 27.45),
             //granita braila
             new Location(45.41, 27.48), new Location(45.47, 27.52),
             new Location(45.47, 27.57), new Location(45.50, 27.57),
             new Location(45.50, 27.58),

              //granita galati
             new Location(45.46, 27.60), new Location(45.46, 27.62),
             new Location(45.50, 27.66), new Location(45.50, 27.68),
             new Location(45.47, 27.66), new Location(45.44, 27.74),
             new Location(45.42, 27.74), new Location(45.43, 27.77),
             new Location(45.43, 27.79), new Location(45.41, 27.78),
             new Location(45.39, 27.86), new Location(45.43, 27.88), 
             new Location(45.40, 27.92), new Location(45.39, 27.97), 
             new Location(45.42, 28.03),
             //tulcea vest nord->sud
             new Location(45.28,28.00), new Location(45.25,28.09),
             new Location(45.25,28.12), new Location(45.24,28.13),
             new Location(45.21,28.13), new Location(45.19,28.10),
             new Location(45.18,28.10), new Location(45.13,28.19),
             new Location(45.11,28.17), new Location(45.10,28.17),
             new Location(45.09,28.17), new Location(45.09,28.14),
             new Location(45.05,28.14), new Location(45.04,28.16),
             new Location(45.01,28.14), new Location(44.96,28.15),
             new Location(44.92, 28.13), new Location(44.88,28.14),
             new Location(44.86,28.11), new Location(44.80,28.08),
             new Location(44.76,28.04), new Location(44.75,28.01),
             new Location(44.78,27.95), new Location(44.77,27.89),

             //braila+buzau+prahova sud
             new Location(44.78,27.86),new Location(44.77,27.72),
             new Location(44.78,27.60), new Location(44.78,27.44),
             new Location(44.80,27.42), new Location(44.77,27.39),
             new Location(44.77,27.38), new Location(44.81,27.33),
             new Location(44.81,27.32), new Location(44.75,27.27),
             new Location(44.79,27.20), new Location(44.79,27.16),
             new Location(44.76,27.16), new Location(44.75,27.20),
             new Location(44.73,27.18), new Location(44.74,27.10),
             new Location(44.78,27.11), new Location(44.82,27.02),
             new Location(44.78,27.00), new Location(44.81,26.90),
             new Location(44.81,26.88), new Location(44.78,26.82),
             new Location(44.78,26.80), new Location(44.82,26.75),
             new Location(44.81,26.65), new Location(44.85,26.62),
             new Location(44.85,26.60), new Location(44.79,26.50),
             new Location(44.82,26.46), new Location(44.77,26.41),
             new Location(44.77,26.39), new Location(44.79,26.35),

              //ialomita + Prahova vest sud->nord
             new Location(44.77,26.31),
             new Location(44.77,26.29), new Location(44.73,26.25),
             new Location(44.75,26.23), new Location(44.75,26.13),
             new Location(44.74,26.05), new Location(44.74,25.99),
             new Location(44.71,25.95), new Location(44.71,25.93),
             new Location(44.73,25.91), new Location(44.74,25.95),
             new Location(44.77,25.93), new Location(44.77,25.91),
             new Location(44.79,25.91), new Location(44.83,25.87),
             new Location(44.82,25.85), new Location(44.83,25.80),
             new Location(44.87,25.79), new Location(44.89,25.81),
             new Location(44.91,25.81), new Location(44.95,25.76),
             new Location(44.96,25.75), new Location(44.96,25.68),
             new Location(45.04,25.69), new Location(45.09,25.68),
             new Location(45.09,25.65), new Location(45.15,25.60),
             new Location(45.17,25.57), new Location(45.19,25.57),
             new Location(45.19,25.53), new Location(45.25,25.53),
             new Location(45.27,25.56), new Location(45.33,25.51),
             new Location(45.33,25.47), new Location(45.43,25.47),

              //granita prahova
             new Location(45.46, 25.46),new Location(45.48, 25.51),
             new Location(45.48, 25.51),new Location(45.46, 25.52),
             new Location(45.45, 25.55),new Location(45.45, 25.60),
             new Location(45.47, 25.60),new Location(45.48, 25.63),
             new Location(45.49, 25.70),new Location(45.46, 25.74),
             new Location(45.46, 25.76),new Location(45.48, 25.78),
             new Location(45.48, 25.80),new Location(45.44, 25.83),
             new Location(45.44, 25.86),new Location(45.44, 25.87),
             new Location(45.48, 25.89),new Location(45.52, 25.92),
             new Location(45.52, 25.98), 
             
             //brasov
             new Location(45.48, 26.02),new Location(45.48, 26.02),
             new Location(45.48, 26.05),new Location(45.52, 26.08), 
             //granita buzau
             new Location(45.52, 26.12),new Location(45.54, 26.16),
             new Location(45.58, 26.19),new Location(45.62, 26.19),
             new Location(45.62, 26.19),new Location(45.62, 26.21),
             new Location(45.60, 26.25),new Location(45.58, 26.28),
             new Location(45.65, 26.33),new Location(45.68, 26.33),
             new Location(45.71, 26.35),new Location(45.72, 26.36),
             new Location(45.74, 26.39),new Location(45.80, 26.39), 
             new Location(45.79, 26.43), 
           };
            return MPBaraganRegiune2;
        }
        public MapPolygon BaraganRegiune3()
        {

            MPBaraganRegiune3.Stroke = new SolidColorBrush(Colors.Red);
            MPBaraganRegiune3.Fill = new SolidColorBrush(Colors.Gray);
            MPBaraganRegiune3.StrokeThickness = 0;

            MPBaraganRegiune3.Opacity = 0.5;
            MPBaraganRegiune3.Locations = new LocationCollection() { 
            //constanta vest nord->sud
             new Location(44.71,27.88), new Location(44.68,27.94),
             new Location(44.68,27.94), new Location(44.64,28.03),
             new Location(44.61,28.03), new Location(44.59,28.01),
             new Location(44.57,28.01), new Location(44.53,28.04),
             new Location(44.51,28.04), new Location(44.48, 28.09),
             new Location(44.45,28.09), new Location(44.42,28.11),
             new Location(44.41,28.08), new Location(44.36,28.02),
             new Location(44.32,28.02), new Location(44.28,27.98),
             new Location(44.27,27.98), new Location(44.25,27.95),
             new Location(44.25,27.89), new Location(44.24,27.87),
             new Location(44.24,27.82), new Location(44.19,27.73),
             new Location(44.21,27.64), new Location(44.18,27.56),
             new Location(44.13,27.47), new Location(44.12,27.36),
             new Location(44.14,27.33), new Location(44.14,27.30),
             new Location(44.128, 27.274),

             
             //calarasi
             new Location(44.115, 27.24),new Location(44.12, 27.19),
             new Location(44.14, 27.123), new Location(44.136, 27.16),
             new Location(44.133, 27.087),new Location(44.144, 27.038),
             new Location(44.134, 26.996),new Location(44.135, 26.94),
             new Location(44.125, 26.88),new Location(44.083, 26.77),
             new Location(44.073, 26.74),new Location(44.08, 26.718),
             new Location(44.064, 26.66),new Location(44.053, 26.6),
             new Location(44.055, 26.55),new Location(44.045, 26.497),
             new Location(44.043, 26.47),new Location(44.039, 26.43),
             new Location(44.042, 26.4),new Location(44.037, 26.37), 
             //calarasi vest sud->nord
             new Location(43.983, 26.195),new Location(43.989, 26.16), 
             new Location(43.967, 26.11), new Location(43.94, 26.08), 
             new Location(43.905, 26.059),new Location(43.896, 26.028), 
             new Location(43.861, 25.955),new Location(43.84, 25.927), 
             new Location(43.77, 25.87),  new Location(43.76, 25.857),
             new Location(43.755, 25.825),new Location(43.734, 25.8), 
             new Location(43.72, 25.793), new Location(43.695, 25.745), 
             new Location(43.69, 25.713), new Location(43.692, 25.675), 
             new Location(43.82, 25.66),  new Location(43.82, 25.63), 
             new Location(43.83, 25.62),  new Location(43.85, 25.62), 
             new Location(43.87, 25.60),  new Location(43.875, 25.60), 
             new Location(43.875, 25.61), new Location(43.88, 25.62), 
             new Location(43.93, 25.615), new Location(43.94, 25.62), 
             new Location(43.95, 25.61),  new Location(43.96, 25.61),
             new Location(43.97, 25.62),  new Location(43.98, 25.605), 
             new Location(44.046, 25.60), new Location(44.0465, 25.635),     
             new Location(44.06, 25.635), new Location(44.06, 25.62),   
             new Location(44.07, 25.62),  new Location(44.09, 25.64),
             new Location(44.10, 25.64),   new Location(44.1, 25.65),  
             new Location(44.115, 25.655),  new Location(44.115, 25.66),       
             new Location(44.105, 25.66),  new Location(44.09, 25.68),
             new Location(44.09, 25.685),new Location(44.11, 25.68), 
             new Location(44.115, 25.68),new Location(44.12, 25.695),
             new Location(44.10, 25.70), new Location(44.10, 25.71),
             new Location(44.13, 25.71), new Location(44.14, 25.71),
             new Location(44.16, 25.67), new Location(44.17, 25.65),
             new Location(44.19, 25.67), new Location(44.21, 25.67),
             new Location(44.26, 25.70), new Location(44.27, 25.68),
             new Location(44.27, 25.67), new Location(44.29, 25.67),
             new Location(44.29, 25.66),  new Location(44.28, 25.65),
             new Location(44.28, 25.63),  new Location(44.31, 25.63),
             new Location(44.32, 25.60),  new Location(44.32, 25.55),
             new Location(44.31, 25.52),  new Location(44.31, 25.48),
              new Location(44.33, 25.48), new Location(44.35, 25.49),
              new Location(44.38, 25.49), new Location(44.41, 25.52),
              new Location(44.42, 25.50), new Location(44.43, 25.467),
              new Location(44.45, 25.48), new Location(44.46, 25.47),
              new Location(44.47, 25.48), new Location(44.48, 25.47),
              //dambovita
              new Location(44.53, 25.52), new Location(44.53, 25.545),
              new Location(44.55, 25.545), new Location(44.55, 25.55),
              new Location(44.53, 25.56), new Location(44.54, 25.57),
              new Location(44.54, 25.58), new Location(44.53, 25.58),
              new Location(44.53, 25.60), new Location(44.55, 25.62),
              new Location(44.56, 25.63), new Location(44.56, 25.64),
              new Location(44.55, 25.65), new Location(44.535, 25.68),
              new Location(44.52, 25.68),   new Location(44.52, 25.685),
              new Location(44.52, 25.685),  new Location(44.545, 25.715),
              new Location(44.545, 25.725), new Location(44.54, 25.73),
              new Location(44.54, 25.75),  new Location(44.53, 25.78),
              new Location(44.54, 25.80),  new Location(44.543, 25.82),
              new Location(44.543, 25.83),  new Location(44.53, 25.85),
              new Location(44.54, 25.86), new Location(44.54, 25.865),
              new Location(44.538, 25.88),  new Location(44.54, 25.895),
              //granita ilfov
              new Location(44.55, 25.88),  new Location(44.56, 25.89),
              new Location(44.575, 25.87),  new Location(44.59, 25.875),
              new Location(44.59, 25.88),   new Location(44.56, 25.91),
              new Location(44.59, 25.95),  new Location(44.61, 25.99),
              new Location(44.63, 25.99),   new Location(44.63, 25.98),
              new Location(44.645, 25.94), new Location(44.66, 25.94),
              new Location(44.66, 25.97),  new Location(44.67, 25.98),
              new Location(44.685, 25.97),  new Location(44.685, 25.98),
              new Location(44.69, 25.98), new Location(44.70, 25.99),
              new Location(44.705, 25.99), new Location(44.705, 25.97),
               new Location(44.72, 25.97),
               //prahova
          
                new Location(44.72,25.97),  new Location(44.74,25.99), 
                new Location(44.74,26.05), new Location(44.75,26.13),
                 new Location(44.75,26.23), new Location(44.73,26.25),
                 new Location(44.77,26.29),  new Location(44.77,26.31),
       
                     
            //braila+buzau+prahova sud
            new Location(44.79,26.35),new Location(44.77,26.39),
            new Location(44.77,26.41),new Location(44.82,26.46),
            new Location(44.79,26.50),new Location(44.85,26.60),
            new Location(44.85,26.62),new Location(44.81,26.65),
            new Location(44.82,26.75),new Location(44.78,26.80),
            new Location(44.78,26.82),new Location(44.81,26.88),
            new Location(44.81,26.90),new Location(44.78,27.00),
            new Location(44.82,27.02),new Location(44.78,27.11),
            new Location(44.74,27.10),new Location(44.73,27.18),
            new Location(44.75,27.20),new Location(44.76,27.16),
            new Location(44.79,27.16),new Location(44.79,27.20),
            new Location(44.75,27.27),new Location(44.81,27.32),
            new Location(44.81,27.33),new Location(44.77,27.38),
            new Location(44.77,27.39),new Location(44.80,27.42),
            new Location(44.78,27.44),new Location(44.78,27.60),
            new Location(44.77,27.72), new Location(44.78,27.86),
            new Location(44.71,27.88) ,
           };
            return MPBaraganRegiune3;
        }
        public MapPolygon BaraganRegiune4()
        {

            MPBaraganRegiune4.Stroke = new SolidColorBrush(Colors.Red);
           MPBaraganRegiune4.Fill = new SolidColorBrush(Colors.Gray);
            MPBaraganRegiune4.StrokeThickness = 0;

            MPBaraganRegiune4.Opacity = 0.8;
            #region Puncte
            MPBaraganRegiune4.Locations = new LocationCollection() { 
             //granita valcea
                   new Location(45.56, 24.49), new Location(45.54, 24.495), new Location(45.53, 24.494), 
                  new Location(45.52, 24.48),  new Location(45.51, 24.472), new Location(45.48, 24.455), new Location(45.478, 24.445),
                  new Location(45.474, 24.430), new Location(45.474, 24.430), new Location(45.46, 24.44),   new Location(45.45, 24.45),
                  new Location(45.43, 24.45),   new Location(45.425, 24.455), new Location(45.41, 24.455),  new Location(45.405, 24.46),
                  new Location(45.38, 24.47),   new Location(45.373, 24.49),new Location(45.370, 24.495), new Location(45.367, 24.495),
                  new Location(45.362, 24.485), new Location(45.34, 24.488),new Location(45.330, 24.475), new Location(45.328, 24.475),
                  new Location(45.327, 24.49),  new Location(45.320, 24.49),new Location(45.315, 24.493), new Location(45.315, 24.493),
                  new Location(45.312, 24.490), new Location(45.3055, 24.495),new Location(45.30, 24.495),  new Location(45.298, 24.50),
                  new Location(45.296, 24.50),  new Location(45.294, 24.492), new Location(45.292, 24.49),  new Location(45.288, 24.49),
                  new Location(45.287, 24.495), new Location(45.285, 24.497),new Location(45.282, 24.497),  new Location(45.274, 24.49),
                  new Location(45.268, 24.481),  new Location(45.260, 24.484),new Location(45.257, 24.484),  new Location(45.257, 24.480),
                  new Location(45.23, 24.47),  new Location(45.20, 24.51),new Location(45.190, 24.50), new Location(45.185, 24.50),
                  new Location(45.185, 24.52), new Location(45.177, 24.525),new Location(45.170, 24.52), new Location(45.165, 24.505),
                  new Location(45.15, 24.505), new Location(45.140, 24.52),new Location(45.11, 24.515), new Location(45.11, 24.51),
                  new Location(45.115, 24.495),new Location(45.10, 24.487),new Location(45.098, 24.49), new Location(45.095, 24.51),
                  new Location(45.085, 24.51), new Location(45.078, 24.50),new Location(45.078, 24.493),new Location(45.070, 24.490),
                  new Location(45.06, 24.50),  new Location(45.052, 24.515),new Location(45.04, 24.51),  new Location(45.035, 24.505),
                  new Location(45.025, 24.505),new Location(45.015, 24.495), new Location(45.01, 24.495), new Location(45.00, 24.507),
                  new Location(44.998, 24.507),new Location(44.996, 24.504), new Location(44.992, 24.500),new Location(44.987, 24.493),
                  new Location(44.956, 24.469), new Location(44.956, 24.469),new Location(44.95, 24.469),  new Location(44.95, 24.475),
                  new Location(44.953, 24.479), new Location(44.952, 24.485),new Location(44.950, 24.488), new Location(44.94, 24.488),
                  new Location(44.92, 24.47),    new Location(44.91, 24.467), new Location(44.904, 24.467), new Location(44.902, 24.475),
                  new Location(44.89, 24.47), new Location(44.885, 24.472),  new Location(44.881, 24.466),new Location(44.880, 24.460),
                  new Location(44.880, 24.450),new Location(44.878, 24.445), new Location(44.87, 24.44),  new Location(44.86, 24.44),
                  new Location(44.85, 24.43),
                  //olt
                  new Location(44.848, 24.44), new Location(44.844, 24.444), 
                  new Location(44.819, 24.428),new Location(44.818, 24.428),
                  new Location(44.818, 24.47), new Location(44.825, 24.48),
                  new Location(44.825, 24.49), new Location(44.84, 24.495),
                  new Location(44.845, 24.497),new Location(44.85, 24.492),
                  new Location(44.853, 24.494),new Location(44.853, 24.498),
                  new Location(44.86, 24.508), new Location(44.865, 24.506),
                  new Location(44.867, 24.506),new Location(44.867, 24.515),
                  new Location(44.869, 24.517),new Location(44.877, 24.517),
                  new Location(44.882, 24.519),new Location(44.89, 24.521), 
                  new Location(44.894, 24.526),new Location(44.894, 24.529), 
                  new Location(44.892, 24.53), new Location(44.892, 24.536), 
                  new Location(44.895, 24.543),new Location(44.893, 24.547), 
                  new Location(44.888, 24.544),new Location(44.88, 24.542), 
                  new Location(44.857, 24.546),new Location(44.853, 24.555), 
                  new Location(44.84, 24.555), new Location(44.825, 24.558), 
                  new Location(44.817, 24.569),new Location(44.80, 24.573), 
                  new Location(44.80, 24.587), new Location(44.78, 24.593), 
                  new Location(44.75, 24.597), new Location(44.75, 24.60), 
                  new Location(44.748, 24.61), new Location(44.73, 24.625), 
                  new Location(44.735, 24.64), new Location(44.735, 24.70),
                  new Location(44.73, 24.705), new Location(44.71, 24.705),
                  new Location(44.70, 24.685), new Location(44.67, 24.705),
                  new Location(44.65, 24.705), new Location(44.64, 24.715),
                  new Location(44.625, 24.717),new Location(44.625, 24.725),
                  new Location(44.61, 24.728), new Location(44.605, 24.73),
                  new Location(44.60, 24.72),  new Location(44.585, 24.720),
                  new Location(44.58, 24.73), new Location(44.56, 24.73),
                  new Location(44.557, 24.725),new Location(44.554, 24.729),
                  new Location(44.54, 24.729), new Location(44.53, 24.735),
                  new Location(44.51, 24.737), new Location(44.505, 24.725),
                  new Location(44.49, 24.725), new Location(44.48, 24.735),
                  new Location(44.46, 24.735), new Location(44.45, 24.73),
                  new Location(44.44, 24.73), new Location(44.420, 24.74),
                  new Location(44.41, 24.73),  new Location(44.39, 24.75),
                  new Location(44.39, 24.77), new Location(44.392, 24.78),
                  new Location(44.39, 24.80), new Location(44.39, 24.81),
                  new Location(44.38, 24.815),
                  //granita teleorman
                    new Location(44.35, 24.82), new Location(44.33, 24.83),
                    new Location(44.32, 24.85), new Location(44.30, 24.83),
                    new Location(44.23, 24.83), new Location(44.20, 24.80),
                    new Location(44.15, 24.80), new Location(44.13, 24.83),
                    new Location(44.09, 24.84), new Location(44.08, 24.79),
                    new Location(44.07, 24.75), new Location(44.06, 24.75),
                    new Location(44.06, 24.72), new Location(44.04, 24.72),
                    new Location(44.03, 24.69), new Location(44.03, 24.65),
                    new Location(44.02, 24.64), new Location(44.01, 24.60),
                    new Location(44.0, 24.59),  new Location(43.98, 24.59),
                    new Location(43.95, 24.63), new Location(43.93, 24.65),
                    new Location(43.90, 24.66), new Location(43.85, 24.70),
                    new Location(43.84, 24.69), new Location(43.82, 24.69),
                    new Location(43.82, 24.75),  new Location(43.815, 24.75),
                    new Location(43.805, 24.73),  new Location(43.79, 24.73),
                    new Location(43.785, 24.71), new Location(43.785, 24.70),
                    new Location(43.77, 24.70),  new Location(43.77, 24.69),
                    new Location(43.76, 24.69), new Location(43.74, 24.66),
                     new Location(43.73, 24.66),
                     //teleorman
                new Location(43.726, 24.654), new Location(43.71, 24.675),
                new Location(43.686, 24.732), new Location(43.687, 24.75),
                new Location(43.71, 24.8), new Location(43.714, 24.83),
                new Location(43.706, 24.87), new Location(43.718, 24.925),
                new Location(43.719, 24.95), new Location(43.729, 24.984),
                new Location(43.725, 25.008), new Location(43.714, 25.017),
                new Location(43.691, 25.06), new Location(43.684, 25.111),
                new Location(43.698, 25.164), new Location(43.698, 25.188),
                new Location(43.692, 25.2), new Location(43.685, 25.248),
                new Location(43.654, 25.297), new Location(43.64, 25.33),
                new Location(43.628, 25.355), new Location(43.62, 25.393),
                new Location(43.623, 25.42), new Location(43.647, 25.5),
                new Location(43.646, 25.526), new Location(43.645, 25.553),
                new Location(43.652, 25.58),
          
        //giurgiu in sus   
              new Location(43.692, 25.675), 
             new Location(43.82, 25.66),  new Location(43.82, 25.63), 
             new Location(43.83, 25.62),  new Location(43.85, 25.62), 
             new Location(43.87, 25.60),  new Location(43.875, 25.60), 
             new Location(43.875, 25.61), new Location(43.88, 25.62), 
             new Location(43.93, 25.615), new Location(43.94, 25.62), 
             new Location(43.95, 25.61),  new Location(43.96, 25.61),
             new Location(43.97, 25.62),  new Location(43.98, 25.605), 
             new Location(44.046, 25.60), new Location(44.0465, 25.635),     
             new Location(44.06, 25.635), new Location(44.06, 25.62),   
             new Location(44.07, 25.62),  new Location(44.09, 25.64),
             new Location(44.10, 25.64),   new Location(44.1, 25.65),  
             new Location(44.115, 25.655),  new Location(44.115, 25.66),       
             new Location(44.105, 25.66),  new Location(44.09, 25.68),
             new Location(44.09, 25.685),new Location(44.11, 25.68), 
             new Location(44.115, 25.68),new Location(44.12, 25.695),
             new Location(44.10, 25.70), new Location(44.10, 25.71),
             new Location(44.13, 25.71), new Location(44.14, 25.71),
             new Location(44.16, 25.67), new Location(44.17, 25.65),
             new Location(44.19, 25.67), new Location(44.21, 25.67),
             new Location(44.26, 25.70), new Location(44.27, 25.68),
             new Location(44.27, 25.67), new Location(44.29, 25.67),
             new Location(44.29, 25.66),  new Location(44.28, 25.65),
             new Location(44.28, 25.63),  new Location(44.31, 25.63),
             new Location(44.32, 25.60),  new Location(44.32, 25.55),
             new Location(44.31, 25.52),  new Location(44.31, 25.48),
              new Location(44.33, 25.48), new Location(44.35, 25.49),
              new Location(44.38, 25.49), new Location(44.41, 25.52),
              new Location(44.42, 25.50), new Location(44.43, 25.467),
              new Location(44.45, 25.48), new Location(44.46, 25.47),
              new Location(44.47, 25.48), new Location(44.48, 25.47),
              //dambovita
              new Location(44.53, 25.52), new Location(44.53, 25.545),
              new Location(44.55, 25.545), new Location(44.55, 25.55),
              new Location(44.53, 25.56), new Location(44.54, 25.57),
              new Location(44.54, 25.58), new Location(44.53, 25.58),
              new Location(44.53, 25.60), new Location(44.55, 25.62),
              new Location(44.56, 25.63), new Location(44.56, 25.64),
              new Location(44.55, 25.65), new Location(44.535, 25.68),
              new Location(44.52, 25.68),   new Location(44.52, 25.685),
              new Location(44.52, 25.685),  new Location(44.545, 25.715),
              new Location(44.545, 25.725), new Location(44.54, 25.73),
              new Location(44.54, 25.75),  new Location(44.53, 25.78),
              new Location(44.54, 25.80),  new Location(44.543, 25.82),
              new Location(44.543, 25.83),  new Location(44.53, 25.85),
              new Location(44.54, 25.86), new Location(44.54, 25.865),
              new Location(44.538, 25.88),  new Location(44.54, 25.895),
              //granita ilfov
              new Location(44.55, 25.88),  new Location(44.56, 25.89),
              new Location(44.575, 25.87),  new Location(44.59, 25.875),
              new Location(44.59, 25.88),   new Location(44.56, 25.91),
              new Location(44.59, 25.95),  new Location(44.61, 25.99),
              new Location(44.63, 25.99),   new Location(44.63, 25.98),
              new Location(44.645, 25.94), new Location(44.66, 25.94),
              new Location(44.66, 25.97),  new Location(44.67, 25.98),
              new Location(44.685, 25.97),  new Location(44.685, 25.98),
              new Location(44.69, 25.98), new Location(44.70, 25.99),
              new Location(44.705, 25.99), new Location(44.705, 25.97),
            
               //prahova
          
            
          
             new Location(44.71,25.95), new Location(44.71,25.93),
             new Location(44.73,25.91), new Location(44.74,25.95),
             new Location(44.77,25.93), new Location(44.77,25.91),
             new Location(44.79,25.91), new Location(44.83,25.87),
             new Location(44.82,25.85), new Location(44.83,25.80),
             new Location(44.87,25.79), new Location(44.89,25.81),
             new Location(44.91,25.81), new Location(44.95,25.76),
             new Location(44.96,25.75), new Location(44.96,25.68),
             new Location(45.04,25.69), new Location(45.09,25.68),
             new Location(45.09,25.65), new Location(45.15,25.60),
             new Location(45.17,25.57), new Location(45.19,25.57),
             new Location(45.19,25.53), new Location(45.25,25.53),
             new Location(45.27,25.56), new Location(45.33,25.51),
             new Location(45.33,25.47), new Location(45.43,25.47),              
             
                  new Location(45.43, 25.43), new Location(45.43, 25.41),
                  new Location(45.38, 25.41), new Location(45.38, 25.38),
                  new Location(45.39, 25.36), new Location(45.39, 25.32),
                  //granita arges
                  new Location(45.42, 25.31), new Location(45.42, 25.28),
                  new Location(45.42, 25.26), new Location(45.46, 25.26),
                  new Location(45.48, 25.24), new Location(45.52, 25.24),
                  new Location(45.53, 25.20), new Location(45.53, 25.18),
                  new Location(45.54, 25.16), new Location(45.57, 25.14),
                  new Location(45.58, 25.10), new Location(45.58, 25.05),
                  new Location(45.60, 25.02), new Location(45.59, 24.98),
                  new Location(45.59, 24.95), new Location(45.60, 24.94),
                  new Location(45.59, 24.90), new Location(45.59, 24.85),
                  new Location(45.62, 24.82), new Location(45.61, 24.80),
                  new Location(45.61, 24.76), new Location(45.60, 24.72),
                  new Location(45.61, 24.67),
                  //Sibiu
                   new Location(45.59, 24.65), new Location(45.60, 24.63), 
                   new Location(45.60, 24.60), new Location(45.58, 24.57),
                   new Location(45.58, 24.55), new Location(45.58, 24.50),
                   new Location(45.56, 24.49), 
             
           };
            #endregion
            return MPBaraganRegiune4;
        }
        #endregion
        #region Evenimente
        void MPBaraganRegiune1_MouseEnter(object sender, MouseEventArgs e)
        {
            mapl.ADDInfoCanvas(lista[reg1lista].Clima, lista[reg1lista].Temperatura.ToString(), lista[reg1lista].Precipitatii.ToString(),44.2,28);
     
            MPBaraganRegiune1.StrokeThickness = 3;
        }
        void MPBaraganRegiune1_MouseLeave(object sender, MouseEventArgs e)
        {
            MPBaraganRegiune1.StrokeThickness = 0;
            mapl.RemoveinfoCanvas();
        }

       
        void MPBaraganRegiune2_MouseEnter(object sender, MouseEventArgs e)
        {
            mapl.ADDInfoCanvas(lista[reg2lista].Clima, lista[reg2lista].Temperatura.ToString(), lista[reg2lista].Precipitatii.ToString(),45,27);
     
            MPBaraganRegiune2.StrokeThickness = 3;
        }
        void MPBaraganRegiune2_MouseLeave(object sender, MouseEventArgs e)
        {
            MPBaraganRegiune2.StrokeThickness = 0;
            mapl.RemoveinfoCanvas();
        }

   
        void MPBaraganRegiune3_MouseEnter(object sender, MouseEventArgs e)
        {
            mapl.ADDInfoCanvas(lista[reg3lista].Clima, lista[reg3lista].Temperatura.ToString(), lista[reg3lista].Precipitatii.ToString(),45,25);
     
            MPBaraganRegiune3.StrokeThickness = 3;
        }
        void MPBaraganRegiune3_MouseLeave(object sender, MouseEventArgs e)
        {
            mapl.RemoveinfoCanvas();
            MPBaraganRegiune3.StrokeThickness = 0;
        }

        void MPBaraganRegiune4_MouseLeave(object sender, MouseEventArgs e)
        {
            mapl.RemoveinfoCanvas();
            MPBaraganRegiune4.StrokeThickness = 0;
        }

        void MPBaraganRegiune4_MouseEnter(object sender, MouseEventArgs e)
        {
            mapl.ADDInfoCanvas(lista[reg4lista].Clima, lista[reg4lista].Temperatura.ToString(), lista[reg4lista].Precipitatii.ToString(), 44.5, 25.5);
          
            MPBaraganRegiune4.StrokeThickness = 3;
        }
        #endregion

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

    }
}
