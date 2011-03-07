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
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using bing;

namespace Regiuni
{
    public class Banat
    {
        private static MapPolygon MPBanatRegiune1;
        private static MapPolygon MPBanatRegiune2;
        private static MapPolygon MPBanatRegiune3;
        bool i = false;
        Map map = new Map();
        private static Image img;
        Canvas can = new Canvas();
        DispatcherTimer dt;
        Canvas md;
        MapLayers mapl;
        Map m;
        List<bing.ServiceReference1.ProceduraRealJudet_Result> lista;
        private static double grade = 0;
        int reg1lista;
        int reg2lista;
        int reg3lista;
       
        private PlaneProjection p = new PlaneProjection();
        public Banat(Map m, Canvas c, Canvas md, MapLayers mapl, List<bing.ServiceReference1.ProceduraRealJudet_Result> lista, bool login)
        {
            i = login;
            this.md = md;
            this.m = m;
            this.mapl = mapl;
            this.lista = lista;
            for (int j = 0; j < lista.Count; j++)
            {
                if (lista[j].ID == 14)
                {
                    reg1lista = j;
                }
                if (lista[j].ID == 15)
                {
                    reg2lista = j;
                }
                if (lista[j].ID == 16)
                {
                    reg3lista = j;
                }
             }
            dt = new DispatcherTimer();
            MPBanatRegiune1 = new MapPolygon();
            MPBanatRegiune2 = new MapPolygon();
            MPBanatRegiune3 = new MapPolygon();

            MPBanatRegiune1.MouseEnter += new MouseEventHandler(MPBanatRegiune1_MouseEnter);
            MPBanatRegiune1.MouseLeave += new MouseEventHandler(MPBanatRegiune1_MouseLeave);
            MPBanatRegiune1.MouseLeftButtonDown += new MouseButtonEventHandler(MPBanatRegiune1_MouseLeftButtonDown);
            MPBanatRegiune2.MouseEnter += new MouseEventHandler(MPBanatRegiune2_MouseEnter);
            MPBanatRegiune2.MouseLeave += new MouseEventHandler(MPBanatRegiune2_MouseLeave);
            MPBanatRegiune2.MouseLeftButtonDown += new MouseButtonEventHandler(MPBanatRegiune2_MouseLeftButtonDown);
            MPBanatRegiune3.MouseEnter += new MouseEventHandler(MPBanatRegiune3_MouseEnter);
            MPBanatRegiune3.MouseLeave += new MouseEventHandler(MPBanatRegiune3_MouseLeave);
            MPBanatRegiune3.MouseLeftButtonDown += new MouseButtonEventHandler(MPBanatRegiune3_MouseLeftButtonDown);
            map = m;
            can = c;
            dt.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dt.Tick += new EventHandler(dt_Tick);
        }
        private void Intoarce()
        {
            can.Background = new SolidColorBrush(Colors.Black);
            dt.Start();
        }
        void MPBanatRegiune3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (i == true)
            {
                Intoarce();

            }
            else
            {
                can.Children.Clear();
                can.Children.Add(new Info(lista, 16, m, can));
            }
        }

        void MPBanatRegiune2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (i == true)
            {
                Intoarce();

            }
            else
            {
                can.Children.Clear();
                can.Children.Add(new Info(lista, 15, m, can));
            }
        }

        void MPBanatRegiune1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (i == true)
            {
                Intoarce();

            }
            else
            {
                can.Children.Clear();
                can.Children.Add(new Info(lista, 14, m, can));
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
        public bing.pesteHarta nueterm
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public MapPolygon BanatRegiune1()
        {
            MPBanatRegiune1.Stroke = new SolidColorBrush(Colors.Red);
            MPBanatRegiune1.Fill = new SolidColorBrush(Colors.Gray);
            MPBanatRegiune1.StrokeThickness = 0;
            MPBanatRegiune1.Opacity = 0.8;

            #region Puncte
            MPBanatRegiune1.Locations = new LocationCollection()
            {
                //arad
                new Location(46.62, 21.43), new Location(46.64, 21.36), new Location(46.63, 21.33), new Location(46.58, 21.30),
                new Location(46.58, 21.34), new Location(46.58, 21.34), new Location(46.50, 21.25), new Location(46.45, 21.33),
                new Location(46.40, 21.30), new Location(46.40, 21.20), new Location(46.35, 21.20), new Location(46.33, 21.17),
                new Location(46.30, 21.18), new Location(46.29, 21.10), new Location(46.25, 21.10), new Location(46.24, 21.05),
                new Location(46.26, 21.02), new Location(46.27, 20.95), new Location(46.29, 20.93), new Location(46.29, 20.93),
                new Location(46.26, 20.91), new Location(46.28, 20.86), new Location(46.28, 20.82), new Location(46.28, 20.78),
                new Location(46.23, 20.76), new Location(46.21, 20.75), new Location(46.20, 20.74), new Location(46.15, 20.71),
                
                //timis
                new Location(46.14, 20.61),  new Location(46.19, 20.513), new Location(46.15, 20.513), new Location(46.15, 20.40),
                new Location(46.16, 20.37),  new Location(46.16, 20.32), new Location(46.13, 20.28),  new Location(46.10, 20.28),
                new Location(46.05, 20.34),  new Location(46.00, 20.36), new Location(46.00, 20.36),  new Location(45.98, 20.38),
                new Location(45.97, 20.39),  new Location(45.965, 20.43), new Location(45.965, 20.455),new Location(45.955, 20.475),
                new Location(45.945, 20.475),new Location(45.905, 20.495), new Location(45.89, 20.515), new Location(45.905, 20.575),
                new Location(45.855, 20.62), new Location(45.815, 20.65), new Location(45.805, 20.68), new Location(45.775, 20.70),
                new Location(45.745, 20.71), new Location(45.755, 20.78), new Location(45.785, 20.78), new Location(45.785, 20.82),
                new Location(45.725, 20.80), new Location(45.685, 20.805), new Location(45.59, 20.78),  new Location(45.55, 20.83),
                new Location(45.52, 20.83),  new Location(45.50, 20.78), new Location(45.48, 20.78),  new Location(45.485, 20.84),
                new Location(45.47, 20.87),  new Location(45.45, 20.87), new Location(45.432, 20.868),

                //timis holbostresu
                new Location(45.432, 20.868), new Location(45.417, 20.9), new Location(45.419, 20.92), new Location(45.385, 20.9385),
                new Location(45.383, 20.95), new Location(45.36, 20.978), new Location(45.343, 20.994), new Location(45.342, 21.013),
                new Location(45.324, 21.017), new Location(45.332, 21.0495), new Location(45.33, 21.062), new Location(45.316, 21.062),
                new Location(45.317, 21.081), new Location(45.297, 21.1), new Location(45.322, 21.174), new Location(45.324, 21.186),
                new Location(45.31, 21.182), new Location(45.303, 21.19), new Location(45.287, 21.192), new Location(45.275, 21.211),
                new Location(45.266, 21.206), new Location(45.25, 21.22), new Location(45.253, 21.226), new Location(45.23, 21.277),
                new Location(45.244, 21.293), new Location(45.237, 21.331), new Location(45.223, 21.361), new Location(45.226, 21.372),
                new Location(45.219, 21.397), new Location(45.23, 21.405), new Location(45.204, 21.44),

                //caras-timis + hunedoara-gorj
                new Location(45.201, 21.51), new Location(45.212, 21.505), new Location(45.218, 21.505), new Location(45.232, 21.527),
                new Location(45.245, 21.521), new Location(45.264, 21.536), new Location(45.27, 21.555), new Location(45.282, 21.546),
                new Location(45.293, 21.57), new Location(45.302, 21.569), new Location(45.332, 21.526), new Location(45.37, 21.46),
                new Location(45.41, 21.444), new Location(45.422, 21.505), new Location(45.435, 21.47), new Location(45.48, 21.462),
                new Location(45.497, 21.54), new Location(45.513, 21.57), new Location(45.57, 21.591), new Location(45.568, 21.63),
                new Location(45.587, 21.677), new Location(45.573, 21.704), new Location(45.56, 21.706), new Location(45.553, 21.747),
                new Location(45.53, 21.76), new Location(45.54, 21.825), new Location(45.535, 21.876), new Location(45.56, 21.872),
                new Location(45.564, 21.91), new Location(45.537, 21.892), new Location(45.528, 21.904), new Location(45.536, 21.941),
                new Location(45.536, 21.941), new Location(45.523, 21.955), new Location(45.497, 21.945), new Location(45.488, 22.035),
                new Location(45.51, 22.041), new Location(45.512, 22.055), new Location(45.575, 22.047), new Location(45.58, 22.065),
                new Location(45.57, 22.073), new Location(45.604, 22.14), new Location(45.63, 22.165), new Location(45.603, 22.2),
                new Location(45.605, 22.24), new Location(45.585, 22.263), new Location(45.6, 22.283), new Location(45.658, 22.315),
                new Location(45.665, 22.327), new Location(45.65, 22.341), new Location(45.658, 22.382), new Location(45.666, 22.39),
                new Location(45.65, 22.406), new Location(45.668, 22.427), new Location(45.659, 22.457), new Location(45.659, 22.457),
                new Location(45.63, 22.474), new Location(45.615, 22.498), new Location(45.574, 22.519), new Location(45.584, 22.586),
                new Location(45.563, 22.597), new Location(45.568, 22.638), new Location(45.558, 22.643), new Location(45.535, 22.63),
                new Location(45.54, 22.646), new Location(45.515, 22.675), new Location(45.503, 22.664), new Location(45.49, 22.69),
                new Location(45.4, 22.703), new Location(45.374, 22.658), new Location(45.345, 22.668), new Location(45.3, 22.598),
                new Location(45.245, 22.594), new Location(45.235, 22.645), new Location(45.275, 22.82), new Location(45.253, 22.863),
                new Location(45.275, 22.9), new Location(45.278, 22.932), new Location(45.272, 22.957), new Location(45.295, 22.988),
                new Location(45.295, 22.988), new Location(45.257, 22.999), new Location(45.256, 23.014), new Location(45.225, 23.025),
                new Location(45.226, 23.042), new Location(45.252, 23.087), new Location(45.29, 23.09), new Location(45.27, 23.175),
                new Location(45.31, 23.25), new Location(45.3, 23.31), new Location(45.335, 23.345), new Location(45.335, 23.38),
                new Location(45.295, 23.445), new Location(45.301, 23.475), new Location(45.315, 23.485), new Location(45.35, 23.58),
                new Location(45.345, 23.60),

                //liniuta bucuclasa
                new Location(45.362, 23.59), new Location(45.378, 23.604), new Location(45.388, 23.605), new Location(45.4, 23.59),
                new Location(45.42, 23.595), new Location(45.425, 23.576), new Location(45.45, 23.595), new Location(45.48, 23.6),

                //hunedoara
                new Location(45.50, 23.59), new Location(45.52, 23.58), new Location(45.54, 23.55), new Location(45.55, 23.53),
                new Location(45.57, 23.51), new Location(45.57, 23.48), new Location(45.60, 23.42), new Location(45.63, 23.42),
                new Location(45.63, 23.40), new Location(45.64, 23.40), new Location(45.67, 23.43), new Location(45.72, 23.37), 
                new Location(45.75, 23.39), new Location(45.78, 23.35), new Location(45.82, 23.33), new Location(45.86, 23.34), 
                new Location(45.92, 23.33), new Location(45.92, 23.29), new Location(45.99, 23.23), new Location(46.03, 23.23), 
                new Location(46.03, 23.20), new Location(46.02, 23.20), new Location(46.05, 23.16), new Location(46.04, 23.10), 
                new Location(46.14, 23.07), new Location(46.16, 23.11), new Location(46.20, 23.08), new Location(46.21, 23.08),
                new Location(46.21, 23.05), new Location(46.22, 23.00), new Location(46.25, 22.95), new Location(46.28, 22.97),
                new Location(46.28, 22.97), new Location(46.32, 22.94), new Location(46.33, 22.94), new Location(46.33, 22.92),
                new Location(46.33, 22.82), new Location(46.34, 22.76),
                
                //arad
                new Location(46.36, 22.71), new Location(46.38, 22.71), new Location(46.39, 22.65), new Location(46.40, 22.60),
                new Location(46.40, 22.51), new Location(46.38, 22.51), new Location(46.39, 22.46), new Location(46.41, 22.42), 
                new Location(46.43, 22.40), new Location(46.45, 22.38), new Location(46.48, 22.38), new Location(46.48, 22.32),
                new Location(46.49, 22.28), new Location(46.48, 22.24), new Location(46.50, 22.22), new Location(46.54, 22.19),
                new Location(46.54, 22.17), new Location(46.57, 22.17), new Location(46.60, 22.17), new Location(46.60, 22.14),
                new Location(46.61, 22.10), new Location(46.64, 22.05), new Location(46.66, 22.04), new Location(46.66, 22.03),
                new Location(46.64, 22.03), new Location(46.62, 22.01), new Location(46.61, 21.98), new Location(46.62, 21.92),
                new Location(46.64, 21.89), new Location(46.65, 21.90), new Location(46.67, 21.90), new Location(46.67, 21.87),
                new Location(46.66, 21.85), new Location(46.65, 21.80), new Location(46.65, 21.80), new Location(46.66, 21.76),
                new Location(46.66, 21.74), new Location(46.65, 21.73), new Location(46.67, 21.67), new Location(46.65, 21.64),
                new Location(46.64, 21.61), new Location(46.65, 21.58), new Location(46.64, 21.58), new Location(46.62, 21.56),
                new Location(46.64, 21.53), new Location(46.66, 21.52), new Location(46.66, 21.51), new Location(46.66, 21.48),
                new Location(46.68, 21.44), new Location(46.62, 21.43)
            };
            #endregion

            return MPBanatRegiune1;
        }
        public MapPolygon BanatRegiune2()
        {
            MPBanatRegiune2.Stroke = new SolidColorBrush(Colors.Red);
            MPBanatRegiune2.Fill = new SolidColorBrush(Colors.Gray);
            MPBanatRegiune2.StrokeThickness = 0;
            MPBanatRegiune2.Opacity = 0.8;

            #region Puncte
            MPBanatRegiune2.Locations = new LocationCollection()
            {
                //gorj-valcea + mehedinti-dolj
                new Location(45.345, 23.60), new Location(45.335, 23.63), new Location(45.35, 23.64), new Location(45.345, 23.67),
                new Location(45.332, 23.681), new Location(45.326, 23.73), new Location(45.35, 23.777), new Location(45.348, 23.82),
                new Location(45.335, 23.832), new Location(45.337, 23.842), new Location(45.318, 23.85), new Location(45.3, 23.83),
                new Location(45.27, 23.803), new Location(45.25, 23.8), new Location(45.21, 23.822), new Location(45.19, 23.842),
                new Location(45.148, 23.86), new Location(45.133, 23.82), new Location(45.085, 23.823), new Location(45.05, 23.805),
                new Location(45.02, 23.785), new Location(45.005, 23.76), new Location(44.945, 23.77), new Location(44.904, 23.773),
                new Location(44.87, 23.76), new Location(44.87, 23.776), new Location(44.832, 23.8), new Location(44.827, 23.785),
                new Location(44.78, 23.772), new Location(44.75, 23.785), new Location(44.72, 23.773), new Location(44.71, 23.773),
                new Location(44.719, 23.738), new Location(44.71, 23.732), new Location(44.713, 23.724), new Location(44.7, 23.721),
                new Location(44.68, 23.726), new Location(44.657, 23.711), new Location(44.651, 23.718), new Location(44.644, 23.713),
                new Location(44.63, 23.725), new Location(44.607, 23.713), new Location(44.585, 23.713), new Location(44.594, 23.7),
                new Location(44.593, 23.693), new Location(44.604, 23.678), new Location(44.59, 23.63), new Location(44.595, 23.605),
                new Location(44.615, 23.595), new Location(44.606, 23.57), new Location(44.609, 23.542), new Location(44.597, 23.53),
                new Location(44.598, 23.513), new Location(44.585, 23.505), new Location(44.574, 23.489), new Location(44.572, 23.46),
                new Location(44.55, 23.454), new Location(44.548, 23.448), new Location(44.533, 23.434), new Location(44.54, 23.398),
                new Location(44.53, 23.378), new Location(44.54, 23.36), new Location(44.523, 23.34), new Location(44.525, 23.255),
                new Location(44.51, 23.28), new Location(44.465, 23.2), new Location(44.43, 23.188), new Location(44.421, 23.155),
                new Location(44.385, 23.25), new Location(44.375, 23.245), new Location(44.368, 23.195), new Location(44.33, 23.185),
                new Location(44.323, 23.135), new Location(44.245, 23.085), new Location(44.233, 23.121), new Location(44.146, 23.102),
                new Location(44.169, 23.043), new Location(44.115, 22.975), new Location(44.099, 22.973),
                
                //mehedinti
                new Location(44.13, 22.88), new Location(44.135, 22.87), new Location(44.143, 22.85), new Location(44.148, 22.84),
                new Location(44.153, 22.819), new Location(44.167, 22.79), new Location(44.192, 22.76), new Location(44.20, 22.74),
                new Location(44.204, 22.698), new Location(44.213, 22.678), new Location(44.227, 22.671), new Location(44.253, 22.685),
                new Location(44.27, 22.684), new Location(44.282, 22.676), new Location(44.291, 22.658), new Location(44.294, 22.61),
                new Location(44.308, 22.56), new Location(44.325, 22.548), new Location(44.333, 22.535), new Location(44.333, 22.535),
                new Location(44.35, 22.522), new Location(44.365, 22.517), new Location(44.385, 22.504), new Location(44.405, 22.50),
                new Location(44.418, 22.504), new Location(44.45, 22.468), new Location(44.46, 22.46), new Location(44.475, 22.461),
                new Location(44.48, 22.47), new Location(44.472, 22.523), new Location(44.481, 22.549), new Location(44.493, 22.56),
                new Location(44.53, 22.562), new Location(44.551, 22.588), new Location(44.549, 22.63), new Location(44.515, 22.7),
                new Location(44.536, 22.76), new Location(44.55, 22.765), new Location(44.605, 22.71), new Location(44.606, 22.69),
                new Location(44.62, 22.675), new Location(44.614, 22.63), new Location(44.63, 22.587), new Location(44.635, 22.576),
                new Location(44.64, 22.569), new Location(44.668, 22.538), new Location(44.68, 22.515), new Location(44.716, 22.465),
                new Location(44.706, 22.42), new Location(44.683, 22.398), new Location(44.674, 22.368), new Location(44.679, 22.348),
                new Location(44.668, 22.32), new Location(44.654, 22.303), new Location(44.64, 22.30), new Location(44.626, 22.276),
                new Location(44.617, 22.274), new Location(44.604, 22.271), new Location(44.583, 22.253), new Location(44.577, 22.246),
                new Location(44.51, 22.199), new Location(44.48, 22.186), new Location(44.472, 22.14), new Location(44.505, 22.07),
                new Location(44.52, 22.071), new Location(44.529, 22.07), new Location(44.537, 22.055), new Location(44.541, 22.039),
                new Location(44.572, 22.026), new Location(44.593, 22.027), new Location(44.606, 22.01), new Location(44.61, 22.005),
                new Location(44.621, 22.003),

                //caras-severin
                new Location(44.6335, 21.992), new Location(44.633, 21.956), new Location(44.647, 21.922), new Location(44.645, 21.885),
                new Location(44.652, 21.87), new Location(44.651, 21.814), new Location(44.662, 21.796), new Location(44.653, 21.72),
                new Location(44.661, 21.704), new Location(44.666, 21.666), new Location(44.66, 21.638), new Location(44.672, 21.616),
                new Location(44.696, 21.612), new Location(44.715, 21.616), new Location(44.74, 21.608), new Location(44.758, 21.59),
                new Location(44.773, 21.54), new Location(44.768, 21.511), new Location(44.776, 21.467), new Location(44.772, 21.421),
                new Location(44.779, 21.396), new Location(44.815, 21.379), new Location(44.821, 21.365), new Location(44.821, 21.36),
                new Location(44.86, 21.366), new Location(44.86, 21.366), new Location(44.868, 21.38), new Location(44.869, 21.41),
                new Location(44.874, 21.43), new Location(44.866, 21.444), new Location(44.872, 21.446), new Location(44.873, 21.459),
                new Location(44.867, 21.466), new Location(44.871, 21.471), new Location(44.87, 21.49), new Location(44.88, 21.513),
                new Location(44.889, 21.562), new Location(44.908, 21.56), new Location(44.918, 21.551), new Location(44.931, 21.547),
                new Location(44.94, 21.528), new Location(44.937, 21.52), new Location(44.956, 21.477), new Location(44.963, 21.45),
                new Location(44.98, 21.41), new Location(44.987, 21.417), new Location(45.02, 21.36), new Location(45.029, 21.388),
                new Location(45.026, 21.393), new Location(45.037, 21.425), new Location(45.04, 21.458), new Location(45.057, 21.453),
                new Location(45.093, 21.485), new Location(45.105, 21.473), new Location(45.122, 21.482), new Location(45.138, 21.53),
                new Location(45.171, 21.517), new Location(45.173, 21.494), new Location(45.193, 21.485),

                //caras-timis + hunedoara-gorj
                new Location(45.201, 21.51), new Location(45.212, 21.505), new Location(45.218, 21.505), new Location(45.232, 21.527),
                new Location(45.245, 21.521), new Location(45.264, 21.536), new Location(45.27, 21.555), new Location(45.282, 21.546),
                new Location(45.293, 21.57), new Location(45.302, 21.569), new Location(45.332, 21.526), new Location(45.37, 21.46),
                new Location(45.41, 21.444), new Location(45.422, 21.505), new Location(45.435, 21.47), new Location(45.48, 21.462),
                new Location(45.497, 21.54), new Location(45.513, 21.57), new Location(45.57, 21.591), new Location(45.568, 21.63),
                new Location(45.587, 21.677), new Location(45.573, 21.704), new Location(45.56, 21.706), new Location(45.553, 21.747),
                new Location(45.53, 21.76), new Location(45.54, 21.825), new Location(45.535, 21.876), new Location(45.56, 21.872),
                new Location(45.564, 21.91), new Location(45.537, 21.892), new Location(45.528, 21.904), new Location(45.536, 21.941),
                new Location(45.536, 21.941), new Location(45.523, 21.955), new Location(45.497, 21.945), new Location(45.488, 22.035),
                new Location(45.51, 22.041), new Location(45.512, 22.055), new Location(45.575, 22.047), new Location(45.58, 22.065),
                new Location(45.57, 22.073), new Location(45.604, 22.14), new Location(45.63, 22.165), new Location(45.603, 22.2),
                new Location(45.605, 22.24), new Location(45.585, 22.263), new Location(45.6, 22.283), new Location(45.658, 22.315),
                new Location(45.665, 22.327), new Location(45.65, 22.341), new Location(45.658, 22.382), new Location(45.666, 22.39),
                new Location(45.65, 22.406), new Location(45.668, 22.427), new Location(45.659, 22.457), new Location(45.659, 22.457),
                new Location(45.63, 22.474), new Location(45.615, 22.498), new Location(45.574, 22.519), new Location(45.584, 22.586),
                new Location(45.563, 22.597), new Location(45.568, 22.638), new Location(45.558, 22.643), new Location(45.535, 22.63),
                new Location(45.54, 22.646), new Location(45.515, 22.675), new Location(45.503, 22.664), new Location(45.49, 22.69),
                new Location(45.4, 22.703), new Location(45.374, 22.658), new Location(45.345, 22.668), new Location(45.3, 22.598),
                new Location(45.245, 22.594), new Location(45.235, 22.645), new Location(45.275, 22.82), new Location(45.253, 22.863),
                new Location(45.275, 22.9), new Location(45.278, 22.932), new Location(45.272, 22.957), new Location(45.295, 22.988),
                new Location(45.295, 22.988), new Location(45.257, 22.999), new Location(45.256, 23.014), new Location(45.225, 23.025),
                new Location(45.226, 23.042), new Location(45.252, 23.087), new Location(45.29, 23.09), new Location(45.27, 23.175),
                new Location(45.31, 23.25), new Location(45.3, 23.31), new Location(45.335, 23.345), new Location(45.335, 23.38),
                new Location(45.295, 23.445), new Location(45.301, 23.475), new Location(45.315, 23.485), new Location(45.35, 23.58),
                new Location(45.345, 23.60)
            };
            #endregion

            return MPBanatRegiune2;
        }
        public MapPolygon BanatRegiune3()
        {
            MPBanatRegiune3.Stroke = new SolidColorBrush(Colors.Red);
            MPBanatRegiune3.Fill = new SolidColorBrush(Colors.Gray);
            MPBanatRegiune3.StrokeThickness = 0;
            MPBanatRegiune3.Opacity = 0.8;

            #region Puncte
            MPBanatRegiune3.Locations = new LocationCollection()
            {
                //gorj-valcea + mehedinti-dolj
                new Location(45.345, 23.60), new Location(45.335, 23.63), new Location(45.35, 23.64), new Location(45.345, 23.67),
                new Location(45.332, 23.681), new Location(45.326, 23.73), new Location(45.35, 23.777), new Location(45.348, 23.82),
                new Location(45.335, 23.832), new Location(45.337, 23.842), new Location(45.318, 23.85), new Location(45.3, 23.83),
                new Location(45.27, 23.803), new Location(45.25, 23.8), new Location(45.21, 23.822), new Location(45.19, 23.842),
                new Location(45.148, 23.86), new Location(45.133, 23.82), new Location(45.085, 23.823), new Location(45.05, 23.805),
                new Location(45.02, 23.785), new Location(45.005, 23.76), new Location(44.945, 23.77), new Location(44.904, 23.773),
                new Location(44.87, 23.76), new Location(44.87, 23.776), new Location(44.832, 23.8), new Location(44.827, 23.785),
                new Location(44.78, 23.772), new Location(44.75, 23.785), new Location(44.72, 23.773), new Location(44.71, 23.773),
                new Location(44.719, 23.738), new Location(44.71, 23.732), new Location(44.713, 23.724), new Location(44.7, 23.721),
                new Location(44.68, 23.726), new Location(44.657, 23.711), new Location(44.651, 23.718), new Location(44.644, 23.713),
                new Location(44.63, 23.725), new Location(44.607, 23.713), new Location(44.585, 23.713), new Location(44.594, 23.7),
                new Location(44.593, 23.693), new Location(44.604, 23.678), new Location(44.59, 23.63), new Location(44.595, 23.605),
                new Location(44.615, 23.595), new Location(44.606, 23.57), new Location(44.609, 23.542), new Location(44.597, 23.53),
                new Location(44.598, 23.513), new Location(44.585, 23.505), new Location(44.574, 23.489), new Location(44.572, 23.46),
                new Location(44.55, 23.454), new Location(44.548, 23.448), new Location(44.533, 23.434), new Location(44.54, 23.398),
                new Location(44.53, 23.378), new Location(44.54, 23.36), new Location(44.523, 23.34), new Location(44.525, 23.255),
                new Location(44.51, 23.28), new Location(44.465, 23.2), new Location(44.43, 23.188), new Location(44.421, 23.155),
                new Location(44.385, 23.25), new Location(44.375, 23.245), new Location(44.368, 23.195), new Location(44.33, 23.185),
                new Location(44.323, 23.135), new Location(44.245, 23.085), new Location(44.233, 23.121), new Location(44.146, 23.102),
                new Location(44.169, 23.043), new Location(44.115, 22.975), new Location(44.099, 22.973),

                //dolj
                 new Location(44.098, 22.988), new Location(44.0955, 23.0),
                new Location(44.093, 23.027), new Location(44.07, 23.048), new Location(44.055, 23.047), new Location(44.014, 23.013),
                new Location(44.01, 22.997), new Location(44.004, 22.934), new Location(43.998, 22.92), new Location(43.992, 22.895),
                new Location(43.985, 22.884), new Location(43.976, 22.877), new Location(43.96, 22.875), new Location(43.943, 22.868),
                new Location(43.934, 22.86), new Location(43.932, 22.864), new Location(43.9, 22.845), new Location(43.87, 22.842),
                new Location(43.836, 22.87), new Location(43.827, 22.9), new Location(43.82, 22.943), new Location(43.811, 22.96),
                new Location(43.807, 22.99), new Location(43.803, 23.022), new Location(43.794, 23.05), new Location(43.80, 23.1),
                new Location(43.818, 23.173), new Location(43.847, 23.28), new Location(43.85, 23.32), new Location(43.848, 23.38),
                new Location(43.852, 23.425), new Location(43.838, 23.494), new Location(43.807, 23.548), new Location(43.80, 23.574),
                new Location(43.79, 23.63), new Location(43.802, 23.68), new Location(43.805, 23.72), new Location(43.802, 23.751),
                new Location(43.783, 23.771), new Location(43.78, 23.78), new Location(43.775, 23.8), new Location(43.773, 23.815),
                new Location(43.758, 23.855), new Location(43.748, 23.91), new Location(43.745, 23.975), new Location(43.72, 24.055),
                new Location(43.703, 24.085), new Location(43.703, 24.085),

                //granita teleorman
                new Location(43.73, 24.66), new Location(43.74, 24.66), new Location(43.76, 24.69), new Location(43.77, 24.69),
                new Location(43.77, 24.70), new Location(43.785, 24.70), new Location(43.785, 24.71), new Location(43.79, 24.73),
                new Location(43.805, 24.73), new Location(43.815, 24.75), new Location(43.82, 24.75), new Location(43.82, 24.69),
                new Location(43.84, 24.69), new Location(43.85, 24.70), new Location(43.90, 24.66), new Location(43.93, 24.65),
                new Location(43.95, 24.63), new Location(43.98, 24.59), new Location(44.0, 24.59), new Location(44.01, 24.60),
                new Location(44.02, 24.64), new Location(44.03, 24.65), new Location(44.03, 24.69), new Location(44.04, 24.72),
                new Location(44.06, 24.72), new Location(44.06, 24.75), new Location(44.07, 24.75), new Location(44.08, 24.79),
                new Location(44.09, 24.84), new Location(44.13, 24.83), new Location(44.15, 24.80), new Location(44.20, 24.80),
                new Location(44.23, 24.83), new Location(44.30, 24.83), new Location(44.32, 24.85), new Location(44.33, 24.83),
                new Location(44.35, 24.82), 
                
                //olt
                new Location(44.38, 24.815), new Location(44.39, 24.81), new Location(44.39, 24.80), new Location(44.392, 24.78),
                new Location(44.39, 24.77), new Location(44.39, 24.75), new Location(44.41, 24.73), new Location(44.420, 24.74),
                new Location(44.44, 24.73), new Location(44.45, 24.73), new Location(44.46, 24.735), new Location(44.48, 24.735),
                new Location(44.49, 24.725), new Location(44.505, 24.725), new Location(44.51, 24.737), new Location(44.53, 24.735),
                new Location(44.54, 24.729), new Location(44.554, 24.729), new Location(44.557, 24.725), new Location(44.56, 24.73),
                new Location(44.58, 24.73), new Location(44.585, 24.720), new Location(44.60, 24.72), new Location(44.605, 24.73),
                new Location(44.61, 24.728), new Location(44.625, 24.725), new Location(44.625, 24.717), new Location(44.64, 24.715),
                new Location(44.65, 24.705), new Location(44.67, 24.705), new Location(44.70, 24.685), new Location(44.71, 24.705),
                new Location(44.73, 24.705), new Location(44.735, 24.70), new Location(44.735, 24.64), new Location(44.73, 24.625),
                new Location(44.748, 24.61), new Location(44.75, 24.60), new Location(44.75, 24.597), new Location(44.78, 24.593),
                new Location(44.80, 24.587), new Location(44.80, 24.573), new Location(44.817, 24.569), new Location(44.825, 24.558),
                new Location(44.84, 24.555), new Location(44.853, 24.555), new Location(44.857, 24.546), new Location(44.88, 24.542),
                new Location(44.888, 24.544), new Location(44.893, 24.547), new Location(44.895, 24.543), new Location(44.892, 24.536),
                new Location(44.892, 24.53), new Location(44.894, 24.529), new Location(44.894, 24.526), new Location(44.89, 24.521),
                new Location(44.882, 24.519), new Location(44.877, 24.517), new Location(44.869, 24.517), new Location(44.867, 24.515),
                new Location(44.867, 24.506), new Location(44.865, 24.506), new Location(44.86, 24.508), new Location(44.853, 24.498),
                new Location(44.853, 24.494), new Location(44.85, 24.492), new Location(44.845, 24.497), new Location(44.84, 24.495),
                new Location(44.825, 24.49), new Location(44.825, 24.48), new Location(44.818, 24.47), new Location(44.818, 24.428),
                new Location(44.819, 24.428), new Location(44.844, 24.444), new Location(44.848, 24.44), 
                
                //granita valcea
                new Location(44.85, 24.43), new Location(44.86, 24.44), new Location(44.87, 24.44), new Location(44.878, 24.445),
                new Location(44.880, 24.450), new Location(44.880, 24.460), new Location(44.881, 24.466), new Location(44.885, 24.472),
                new Location(44.89, 24.47), new Location(44.902, 24.475), new Location(44.904, 24.467), new Location(44.91, 24.467),
                new Location(44.92, 24.47), new Location(44.94, 24.488), new Location(44.950, 24.488), new Location(44.952, 24.485),
                new Location(44.953, 24.479), new Location(44.95, 24.475), new Location(44.95, 24.469), new Location(44.956, 24.469),
                new Location(44.956, 24.469), new Location(44.987, 24.493), new Location(44.992, 24.500), new Location(44.996, 24.504),
                new Location(44.998, 24.507), new Location(45.00, 24.507), new Location(45.01, 24.495), new Location(45.015, 24.495),
                new Location(45.025, 24.505), new Location(45.035, 24.505), new Location(45.04, 24.51), new Location(45.052, 24.515),
                new Location(45.06, 24.50), new Location(45.070, 24.490), new Location(45.078, 24.493), new Location(45.078, 24.50),
                new Location(45.085, 24.51), new Location(45.095, 24.51), new Location(45.098, 24.49), new Location(45.10, 24.487),
                new Location(45.115, 24.495), new Location(45.11, 24.51), new Location(45.11, 24.515), new Location(45.140, 24.52),
                new Location(45.15, 24.505), new Location(45.165, 24.505), new Location(45.170, 24.52), new Location(45.177, 24.525),
                new Location(45.185, 24.52), new Location(45.185, 24.50), new Location(45.190, 24.50), new Location(45.20, 24.51), 
                new Location(45.23, 24.47), new Location(45.257, 24.480), new Location(45.257, 24.484), new Location(45.260, 24.484),
                new Location(45.268, 24.481), new Location(45.274, 24.49), new Location(45.282, 24.497), new Location(45.285, 24.497),
                new Location(45.287, 24.495), new Location(45.288, 24.49), new Location(45.292, 24.49), new Location(45.294, 24.492),
                new Location(45.296, 24.50), new Location(45.298, 24.50), new Location(45.30, 24.495), new Location(45.3055, 24.495),
                new Location(45.312, 24.490), new Location(45.315, 24.493), new Location(45.315, 24.493), new Location(45.320, 24.49),
                new Location(45.327, 24.49), new Location(45.328, 24.475), new Location(45.330, 24.475), new Location(45.34, 24.488),
                new Location(45.362, 24.485), new Location(45.367, 24.495), new Location(45.370, 24.495), new Location(45.373, 24.49),
                new Location(45.38, 24.47), new Location(45.405, 24.46), new Location(45.41, 24.455), new Location(45.425, 24.455),
                new Location(45.43, 24.45), new Location(45.45, 24.45), new Location(45.46, 24.44), new Location(45.474, 24.430),
                new Location(45.474, 24.430), new Location(45.478, 24.445), new Location(45.48, 24.455), new Location(45.51, 24.472),
                new Location(45.52, 24.48), new Location(45.53, 24.494), new Location(45.54, 24.495), new Location(45.56, 24.49),
                new Location(45.58, 24.50),

                //granita valcea
                new Location(45.58, 24.45), new Location(45.58, 24.38), new Location(45.59, 24.36),
                new Location(45.59, 24.33), new Location(45.57, 24.30), new Location(45.54, 24.27), new Location(45.56, 24.24),
                new Location(45.55, 24.23), new Location(45.53, 24.23), new Location(45.53, 24.21), new Location(45.52, 24.17),
                new Location(45.53, 24.14),  new Location(45.51, 24.10), new Location(45.51, 24.08), new Location(45.52, 24.06),
                new Location(45.53, 24.04), new Location(45.53, 23.96), new Location(45.52, 23.88),  new Location(45.54, 23.85),
                new Location(45.53, 23.82), new Location(45.53, 23.80), new Location(45.50, 23.72),  new Location(45.47, 23.70),
                new Location(45.47, 23.67),
                
                //alba iulia
                new Location(45.47, 23.62),   new Location(45.48, 23.60),
                
                //liniuta bucuclasa
                new Location(45.48, 23.6), new Location(45.45, 23.595), new Location(45.425, 23.576), new Location(45.42, 23.595),
                new Location(45.4, 23.59), new Location(45.388, 23.605), new Location(45.378, 23.604), new Location(45.362, 23.59)
            };
            #endregion

            return MPBanatRegiune3;
        }

        void MPBanatRegiune1_MouseLeave(object sender, MouseEventArgs e)
        {
            MPBanatRegiune1.StrokeThickness = 0;
            mapl.RemoveinfoCanvas();
        }
        void MPBanatRegiune1_MouseEnter(object sender, MouseEventArgs e)
        {
            MPBanatRegiune1.StrokeThickness = 3;
            mapl.ADDInfoCanvas(lista[reg1lista].Clima, lista[reg1lista].Temperatura.ToString(), lista[reg1lista].Precipitatii.ToString(), 46, 22);
     
        }

        void MPBanatRegiune2_MouseLeave(object sender, MouseEventArgs e)
        {
            MPBanatRegiune2.StrokeThickness = 0;
            mapl.RemoveinfoCanvas();
        }
        void MPBanatRegiune2_MouseEnter(object sender, MouseEventArgs e)
        {
            MPBanatRegiune2.StrokeThickness = 3;
            mapl.ADDInfoCanvas(lista[reg2lista].Clima, lista[reg2lista].Temperatura.ToString(), lista[reg2lista].Precipitatii.ToString(), 45, 21);
     
        }

        void MPBanatRegiune3_MouseLeave(object sender, MouseEventArgs e)
        {
            MPBanatRegiune3.StrokeThickness = 0;
            mapl.RemoveinfoCanvas();
        }
        void MPBanatRegiune3_MouseEnter(object sender, MouseEventArgs e)
        {
            MPBanatRegiune3.StrokeThickness = 3;
            mapl.ADDInfoCanvas(lista[reg3lista].Clima, lista[reg3lista].Temperatura.ToString(), lista[reg3lista].Precipitatii.ToString(), 45, 24);
     
        }
    }
}
