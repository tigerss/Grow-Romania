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
using System.Globalization;
using bing;
using System.Collections.Generic;
using Forme;
using System.ServiceModel;

namespace Regiuni
{
    public class MapLayers
    {
        #region Variabile Interne
        BasicHttpBinding bind = new BasicHttpBinding();
        EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Tranzactii.svc");
        
        public  MapPolygon poligonMoldova = new MapPolygon();
        public  MapPolygon poligonBaragan = new MapPolygon();
        public  MapPolygon poligonTransilvania = new MapPolygon();
        public  MapPolygon poligonBanat = new MapPolygon();
        /// <summary>
        /// Harta de baza trimisa ca parametru
        /// </summary>
       private Map map = new Map();
       public Canvas c = new Canvas();
       
        internal DispatcherTimer timer = new DispatcherTimer();

        /// <summary>
        /// Timeru e pornit dak e True
        /// </summary>
        internal bool TimeIsOn = false;
        /// <summary>
        /// Latitudinea pe Romania
        /// </summary>
        public readonly double latitudine = 45.80191;
        /// <summary>
        /// Longitudinea pe Romania
        /// </summary>
        public readonly double longitudine = 24.89479;
        /// <summary>
        /// Zoomu pe Romania
        /// </summary>
        public  readonly double zoom = 6;
        /// <sumary>
        /// Instanta curenta
        /// </sumary>
        private static MapLayers mapLayers;

        #endregion
        #region Variabile Trimise
        /// <summary>
        /// Zoom dinamic
        /// </summary>
        public double Z { get; set; }
        /// <summary>
        /// Longitudine dinamica
        /// </summary>
        public double Long { get; set; }
        /// <summary>
        /// Latitudine dinamica
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// Mouseu este apasat pe Moldova
        /// </summary>
        public bool bIsMousePressedMoldova = false;
        /// <summary>
        /// Mouseu este apasat pe Baragan
        /// </summary>
        public bool bIsMousePressedBaragan = false;
        /// <summary>
        /// Mouseu este apasat pe Transilvania
        /// </summary>
        public bool bIsMousePressedTransilvania = false;
        /// <summary>
        /// Mouseu este apasat pe Banat
        /// </summary>
        public bool bIsMousePressedBanat = false;
        #endregion
        #region Constructori
        public MapLayers()
        { }
        Canvas md;
        List<bing.ServiceReference1.ProceduraRealJudet_Result> lista = new List<bing.ServiceReference1.ProceduraRealJudet_Result>();
        public MapLayers(Map m,Canvas can,Canvas MeniuDreapta)
        {
           
            bing.ServiceReference1.TranzactiiClient tc = new bing.ServiceReference1.TranzactiiClient(bind, endpoint) ;
            tc.GetProceduraRealCompleted += new EventHandler<bing.ServiceReference1.GetProceduraRealCompletedEventArgs>(tc_GetProceduraRealCompleted);
            tc.GetProceduraRealAsync(1);
            md = MeniuDreapta;
            this.map = m;
            c = can;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += new EventHandler(t_Tick);
            Z = zoom;
            Long = longitudine;
            Lat = latitudine;
            mapLayers = this;
        }

        void tc_GetProceduraRealCompleted(object sender, bing.ServiceReference1.GetProceduraRealCompletedEventArgs e)
        {
            foreach (var c in e.Result)
            {
                lista.Add(c);
            }
        }
        #endregion
        #region Harti
        /// <summary>
        /// Conturul Moldovei
        /// </summary>
        /// <returns>MapPolyline cu Conturul Moldovei</returns>
        public MapPolygon PoligonMoldova()
        {
            poligonMoldova.Stroke = new SolidColorBrush(Colors.Yellow);
            poligonMoldova.Fill = new SolidColorBrush(Colors.Green);
            poligonMoldova.StrokeThickness = 5;
            poligonMoldova.Opacity = 0.0;
            poligonMoldova.MouseLeftButtonDown += new MouseButtonEventHandler(p_MouseLeftButtonDown_Moldova);
            poligonMoldova.MouseEnter += new MouseEventHandler(p_MouseEnter_Moldova);
            poligonMoldova.MouseLeave += new MouseEventHandler(p_MouseLeave_Moldova);

            #region Puncte
            poligonMoldova.Locations = new LocationCollection()
            {
                new Location(45.47, 28.20), new Location(45.57, 28.16),  new Location(45.58, 28.10),
                new Location(45.63, 28.10), new Location(45.64, 28.16), new Location(45.76, 28.16), new Location(45.78, 28.12),
                new Location(45.84, 28.12), new Location(45.86, 28.10), new Location(45.90, 28.12), new Location(45.96, 28.12),
                new Location(46.02, 28.11), new Location(46.04, 28.09), new Location(46.14, 28.14), new Location(46.16, 28.12),
                new Location(46.20, 28.14), new Location(46.22, 28.12), new Location(46.25, 28.14), new Location(46.27, 28.14),
                new Location(46.30, 28.17), new Location(46.34, 28.22), new Location(46.37, 28.19), new Location(46.39, 28.22),
                new Location(46.43, 28.25), new Location(46.46, 28.25), new Location(46.50, 28.23), new Location(46.54, 28.21),
                new Location(46.63, 28.26), new Location(46.73, 28.20), new Location(46.77, 28.19), new Location(46.82, 28.12),
                new Location(46.84, 28.12), new Location(46.85, 28.11),
              
                //Iasi Inceput Judet
                new Location(46.85, 28.11), new Location(46.87, 28.13), new Location(46.92, 28.10), new Location(46.94, 28.10),
                new Location(46.98, 28.11), new Location(47.06, 28.00), new Location(47.06, 27.94), new Location(47.16, 27.80),  
                new Location(47.30, 27.75), new Location(47.31, 27.65), new Location(47.31, 27.64), new Location(47.34, 27.60),
                new Location(47.35, 27.62), new Location(47.37, 27.60), new Location(47.39, 27.58), new Location(47.43, 27.56),
                new Location(47.45, 27.59), new Location(47.47, 27.60), new Location(47.48, 27.50), new Location(47.53, 27.45),
                new Location(47.58, 27.45),
               
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

                //Suceava in jos
                new Location(47.645, 25.045), new Location(47.62, 24.98), new Location(47.58, 24.98), new Location(47.54, 25.04),
                new Location(47.50, 25.04), new Location(47.50, 25.08), new Location(47.48, 25.09), new Location(47.46, 25.05),
                new Location(47.43, 25.05), new Location(47.43, 25.01), new Location(47.41, 25.00), new Location(47.39, 25.06),
                new Location(47.33, 25.08), new Location(47.30, 25.04), new Location(47.27, 25.04), new Location(47.24, 25.08),
                new Location(47.20, 25.05), new Location(47.13, 25.09), new Location(47.13, 25.15),  new Location(47.15, 25.17),
                new Location(47.10, 25.23),

                //granita jud mures
                //granita jud. harghita
                new Location(47.10, 25.26), new Location(47.13, 25.30), new Location(47.11, 25.33), new Location(47.10, 25.38),
                new Location(47.105, 25.40), new Location(47.13, 25.40), new Location(47.14, 25.45),  new Location(47.135, 25.47),
                new Location(47.13, 25.50),  new Location(47.13, 25.53), new Location(47.09, 25.53),  new Location(47.07, 25.60),
                new Location(47.10, 25.60),  new Location(47.095, 25.69),
                
                //neamt
                new Location(47.08, 25.72),  new Location(47.05, 25.75), new Location(47.00, 25.79),  new Location(46.97, 25.79),
                new Location(46.97, 25.81),  new Location(46.99, 25.83), new Location(46.98, 25.85),  new Location(46.96, 25.86),
                new Location(46.94, 25.84),  new Location(46.92, 25.835), new Location(46.92, 25.80),  new Location(46.89, 25.76),
                new Location(46.83, 25.77),  new Location(46.83, 25.80), new Location(46.78, 25.82),  new Location(46.75, 25.82),
                new Location(46.72, 25.80),  new Location(46.69, 25.83), new Location(46.65, 25.88),  new Location(46.65, 25.92),
                new Location(46.69, 25.90),  new Location(46.705, 25.91), new Location(46.70, 25.95),  new Location(46.70, 25.95),
                new Location(46.68, 25.97),
                 
                //bacau
                new Location(46.64, 26.01), new Location(46.62, 25.995), new Location(46.60, 26.03), new Location(46.55, 26.04),
                new Location(46.50, 26.08), new Location(46.47, 26.01), new Location(46.45, 25.98), new Location(46.42, 26.00),
                new Location(46.42, 26.03), new Location(46.40, 26.07), new Location(46.42, 26.105), new Location(46.41, 26.18),
                new Location(46.36, 26.18),  new Location(46.33, 26.16), new Location(46.31, 26.17),  new Location(46.31, 26.21),
                new Location(46.35, 26.25),  new Location(46.35, 26.27), new Location(46.33, 26.30), new Location(46.27, 26.27),
                new Location(46.25, 26.27),
                
                //granita covasna
                new Location(46.25, 26.31), new Location(46.24, 26.33), new Location(46.15, 26.34), new Location(46.12, 26.33),
                new Location(46.09, 26.39), new Location(46.10, 26.42), new Location(46.08, 26.43), new Location(46.06, 26.41),
                new Location(46.05, 26.44), 
                
                //vrancea
                new Location(46.04, 26.46), new Location(46.00, 26.46), new Location(45.97, 26.41), new Location(45.93, 26.39),
                new Location(45.90, 26.37), new Location(45.87, 26.39), new Location(45.85, 26.37), new Location(45.80, 26.39),
                
                //granita buzau
                new Location(45.79, 26.43), new Location(45.73, 26.44), new Location(45.73, 26.46), new Location(45.70, 26.48),
                new Location(45.65, 26.52), new Location(45.63, 26.55), new Location(45.62, 26.57), new Location(45.63, 26.60),
                new Location(45.63, 26.64), new Location(45.59, 26.66), new Location(45.59, 26.70), new Location(45.57, 26.73),
                new Location(45.55, 26.77), new Location(45.55, 26.80), new Location(45.53, 26.82), new Location(45.53, 26.90),
                new Location(45.54, 26.94), new Location(45.53, 26.97), new Location(45.53, 26.99), new Location(45.50, 26.99),
                new Location(45.45, 27.03), new Location(45.45, 27.08), new Location(45.48, 27.11), new Location(45.47, 27.14),
                new Location(45.45, 27.10), new Location(45.43, 27.18), new Location(45.45, 27.20), new Location(45.44, 27.23),
                new Location(45.45, 27.27), new Location(45.43, 27.29), new Location(45.39, 27.29), new Location(45.37, 27.31),
                new Location(45.37, 27.40), new Location(45.39, 27.43), new Location(45.41, 27.43), new Location(45.43, 27.45),
                
                //granita braila
                new Location(45.41, 27.48), new Location(45.47, 27.52), new Location(45.47, 27.57), new Location(45.50, 27.57),
                new Location(45.50, 27.58),

                //granita galati
                new Location(45.46, 27.60), new Location(45.46, 27.62), new Location(45.50, 27.66), new Location(45.50, 27.68),
                new Location(45.47, 27.66), new Location(45.44, 27.74), new Location(45.42, 27.74), new Location(45.43, 27.77),
                new Location(45.43, 27.79), new Location(45.41, 27.78), new Location(45.39, 27.86), new Location(45.43, 27.88), 
                new Location(45.40, 27.92), new Location(45.39, 27.97), new Location(45.42, 28.03), 
                  
                //granita tulceea
                new Location(45.45, 28.06), new Location(45.45, 28.10), new Location(45.43, 28.16),new Location(45.40, 28.16),
                new Location(45.40, 28.20), new Location(45.44, 28.20),
            };
            #endregion

            return poligonMoldova;
        }
        /// <summary>
        /// Conturul Baraganului
        /// </summary>
        /// <returns>MapPolyline cu Conturul Baraganului</returns>
        public MapPolygon PoligonBaragan()
        {
            poligonBaragan.Stroke = new SolidColorBrush(Colors.Yellow);
            poligonBaragan.Fill = new SolidColorBrush(Colors.Green);
            poligonBaragan.StrokeThickness = 5;
            poligonBaragan.Opacity = 0.0;
            poligonBaragan.MouseEnter += new MouseEventHandler(poligonBaragan_MouseEnter);
            poligonBaragan.MouseLeave += new MouseEventHandler(poligonBaragan_MouseLeave);
            poligonBaragan.MouseLeftButtonDown += new MouseButtonEventHandler(poligonBaragan_MouseLeftButtonDown);

            #region Puncte
            poligonBaragan.Locations = new LocationCollection() 
            {
                //calarasi
                new Location(44.115, 27.24), new Location(44.12, 27.19), new Location(44.14, 27.123), new Location(44.136, 27.16),
                new Location(44.133, 27.087), new Location(44.144, 27.038), new Location(44.134, 26.996), new Location(44.135, 26.94),
                new Location(44.125, 26.88), new Location(44.083, 26.77), new Location(44.073, 26.74), new Location(44.08, 26.718),
                new Location(44.064, 26.66), new Location(44.053, 26.6), new Location(44.055, 26.55), new Location(44.045, 26.497),
                new Location(44.043, 26.47), new Location(44.039, 26.43), new Location(44.042, 26.4), new Location(44.037, 26.37),

                //giurgiu
                new Location(43.983, 26.195), new Location(43.989, 26.16), new Location(43.967, 26.11), new Location(43.94, 26.08),
                new Location(43.905, 26.059), new Location(43.896, 26.028), new Location(43.861, 25.955), new Location(43.84, 25.927),
                new Location(43.77, 25.87), new Location(43.76, 25.857), new Location(43.755, 25.825), new Location(43.734, 25.8),
                new Location(43.72, 25.793), new Location(43.695, 25.745), new Location(43.69, 25.713), new Location(43.692, 25.675),

                //teleorman
                new Location(43.652, 25.58), new Location(43.645, 25.553), new Location(43.646, 25.526), new Location(43.647, 25.5),
                new Location(43.623, 25.42), new Location(43.62, 25.393), new Location(43.628, 25.355), new Location(43.64, 25.33),
                new Location(43.654, 25.297), new Location(43.685, 25.248), new Location(43.692, 25.2), new Location(43.698, 25.188),
                new Location(43.698, 25.164), new Location(43.684, 25.111), new Location(43.691, 25.06), new Location(43.714, 25.017),
                new Location(43.725, 25.008), new Location(43.729, 24.984), new Location(43.719, 24.95), new Location(43.718, 24.925),
                new Location(43.706, 24.87), new Location(43.714, 24.83), new Location(43.71, 24.8), new Location(43.687, 24.75),
                new Location(43.686, 24.732), new Location(43.71, 24.675), new Location(43.726, 24.654),

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

                //granita arges
                new Location(45.61, 24.67), new Location(45.60, 24.72), new Location(45.61, 24.76), new Location(45.61, 24.80),
                new Location(45.62, 24.82), new Location(45.59, 24.85), new Location(45.59, 24.90), new Location(45.60, 24.94),
                new Location(45.59, 24.95), new Location(45.59, 24.98), new Location(45.60, 25.02), new Location(45.58, 25.05),
                new Location(45.58, 25.10), new Location(45.57, 25.14), new Location(45.54, 25.16), new Location(45.53, 25.18),
                new Location(45.53, 25.20), new Location(45.52, 25.24), new Location(45.48, 25.24), new Location(45.46, 25.26),
                new Location(45.42, 25.26), new Location(45.42, 25.28), new Location(45.42, 25.31), 
                
                //granita dambovita
                new Location(45.39, 25.32), new Location(45.39, 25.36), new Location(45.38, 25.38),new Location(45.38, 25.41),
                new Location(45.43, 25.41), new Location(45.43, 25.43),
                 
                //granita prahova
                new Location(45.46, 25.46), new Location(45.48, 25.51), new Location(45.48, 25.51), new Location(45.46, 25.52),
                new Location(45.45, 25.55), new Location(45.45, 25.60), new Location(45.47, 25.60), new Location(45.48, 25.63),
                new Location(45.49, 25.70), new Location(45.46, 25.74), new Location(45.46, 25.76), new Location(45.48, 25.78),
                new Location(45.48, 25.80), new Location(45.44, 25.83), new Location(45.44, 25.86), new Location(45.44, 25.87),
                new Location(45.48, 25.89), new Location(45.52, 25.92), new Location(45.52, 25.98),

                //brasov
                new Location(45.48, 26.02), new Location(45.48, 26.02), new Location(45.48, 26.05), new Location(45.52, 26.08),

                //granita buzau
                new Location(45.52, 26.12),new Location(45.54, 26.16), new Location(45.58, 26.19),new Location(45.62, 26.19),
                new Location(45.62, 26.19),new Location(45.62, 26.21), new Location(45.60, 26.25),new Location(45.58, 26.28),
                new Location(45.65, 26.33),new Location(45.68, 26.33), new Location(45.71, 26.35),new Location(45.72, 26.36),
                new Location(45.74, 26.39),new Location(45.80, 26.39), new Location(45.79, 26.43), 

                //granita buzau
                new Location(45.79, 26.43), new Location(45.73, 26.44), new Location(45.73, 26.46), new Location(45.70, 26.48),
                new Location(45.65, 26.52), new Location(45.63, 26.55), new Location(45.62, 26.57), new Location(45.63, 26.60),
                new Location(45.63, 26.64), new Location(45.59, 26.66), new Location(45.59, 26.70), new Location(45.57, 26.73),
                new Location(45.55, 26.77), new Location(45.55, 26.80), new Location(45.53, 26.82), new Location(45.53, 26.90),
                new Location(45.54, 26.94), new Location(45.53, 26.97), new Location(45.53, 26.99), new Location(45.50, 26.99),
                new Location(45.45, 27.03), new Location(45.45, 27.08), new Location(45.48, 27.11), new Location(45.47, 27.14),
                new Location(45.45, 27.10), new Location(45.43, 27.18), new Location(45.45, 27.20), new Location(45.44, 27.23),
                new Location(45.45, 27.27), new Location(45.43, 27.29), new Location(45.39, 27.29), new Location(45.37, 27.31),
                new Location(45.37, 27.40), new Location(45.39, 27.43), new Location(45.41, 27.43), new Location(45.43, 27.45),

                //granita braila
                new Location(45.41, 27.48), new Location(45.47, 27.52), new Location(45.47, 27.57), new Location(45.50, 27.57),
                new Location(45.50, 27.58),

                //granita galati
                new Location(45.46, 27.60), new Location(45.46, 27.62), new Location(45.50, 27.66), new Location(45.50, 27.68),
                new Location(45.47, 27.66), new Location(45.44, 27.74), new Location(45.42, 27.74), new Location(45.43, 27.77),
                new Location(45.43, 27.79), new Location(45.41, 27.78), new Location(45.39, 27.86), new Location(45.43, 27.88), 
                new Location(45.40, 27.92), new Location(45.39, 27.97), new Location(45.42, 28.03), 

                //tulcea
                new Location(45.41,28.04),new Location(45.44,28.09), new Location(45.44,28.13),new Location(45.41,28.18),
                new Location(45.42,28.19),new Location(45.48,28.19),
              
                //DELTA DUNARII
                new Location(45.46, 28.28),new Location(45.40, 28.30), new Location(45.35, 28.33),new Location(45.31, 28.35),
                new Location(45.27, 28.50),new Location(45.22, 28.72), new Location(45.24, 28.79),new Location(45.30, 28.76),
                new Location(45.30, 28.80),new Location(45.34, 28.80), new Location(45.28, 28.94),new Location(45.32, 28.95),
                new Location(45.35, 29.00),new Location(45.37, 29.05), new Location(45.38, 29.10),new Location(45.39, 29.18),
                new Location(45.42, 29.20),new Location(45.45, 29.45), new Location(45.43, 29.47),new Location(45.38, 29.64),
                new Location(45.35, 29.69),new Location(45.27, 29.70), new Location(45.24, 29.67),new Location(45.20, 29.70),   
              
                //litoral
                new Location(45.16, 29.70), new Location(44.98, 29.65), new Location(44.81, 29.61), new Location(44.75, 29.57),
                new Location(44.77, 29.35), new Location(44.75, 29.20), new Location(44.7, 29.05), new Location(44.55, 28.93),
                new Location(44.52, 28.92), new Location(44.48, 28.875), new Location(44.41, 28.812), new Location(44.3, 28.68),
                new Location(44.313, 28.65), new Location(44.275, 28.634), new Location(44.22, 28.654), new Location(44.15, 28.68),
                new Location(44.083, 28.685), new Location(44.078, 28.65), new Location(44.0, 28.67), new Location(43.985, 28.677),
                new Location(43.95, 28.65), new Location(43.91, 28.645), new Location(43.885, 28.62), new Location(43.845, 28.62),
                new Location(43.80, 28.59), new Location(43.76, 28.58), new Location(43.74, 28.585), 

                //constanta
                new Location(43.735, 28.45), new Location(43.753, 28.35), new Location(43.757, 28.24), new Location(43.83, 28.03),
                new Location(43.846, 27.994), new Location(43.91, 27.97), new Location(43.94, 27.955), new Location(43.987, 27.944),
                new Location(44.009, 27.916), new Location(43.965, 27.84), new Location(43.958, 27.76), new Location(43.952, 27.74),
                new Location(43.961, 27.71), new Location(44.03, 27.675), new Location(44.05, 27.642), new Location(44.012, 27.611),
                new Location(44.012, 27.611), new Location(44.022, 27.47), new Location(44.013, 27.4), new Location(44.056, 27.36),
                new Location(44.074, 27.29), new Location(44.128, 27.274), new Location(44.115, 27.24)
           };
            #endregion

            return poligonBaragan;
        }
        /// <summary>
        /// Conturul Banatului
        /// </summary>
        /// <returns>MapPolyline cu Conturul Banatului</returns>
        public MapPolygon PoligonBanat()
        {
            poligonBanat.Stroke = new SolidColorBrush(Colors.Yellow);
            poligonBanat.Fill = new SolidColorBrush(Colors.Green);
            poligonBanat.StrokeThickness = 5;
            poligonBanat.Opacity = 0.0;
            poligonBanat.MouseEnter += new MouseEventHandler(poligonBanat_MouseEnter);
            poligonBanat.MouseLeave += new MouseEventHandler(poligonBanat_MouseLeave);
            poligonBanat.MouseLeftButtonDown += new MouseButtonEventHandler(poligonBanat_MouseLeftButtonDown);

            #region Puncte
            poligonBanat.Locations = new LocationCollection() 
            {
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
                new Location(46.64, 21.53), new Location(46.66, 21.52), new Location(46.66, 21.51),  new Location(46.66, 21.48),
                new Location(46.68, 21.44),
                
                //arad - granita cu hunii
                new Location(46.63, 21.33), new Location(46.58, 21.30), new Location(46.58, 21.34), new Location(46.58, 21.34),
                new Location(46.50, 21.25), new Location(46.45, 21.33), new Location(46.40, 21.30), new Location(46.40, 21.20),
                new Location(46.35, 21.20), new Location(46.33, 21.17), new Location(46.30, 21.18), new Location(46.29, 21.10),
                new Location(46.25, 21.10), new Location(46.24, 21.05), new Location(46.26, 21.02), new Location(46.27, 20.95),
                new Location(46.29, 20.93), new Location(46.29, 20.93), new Location(46.26, 20.91), new Location(46.28, 20.86),
                new Location(46.28, 20.82), new Location(46.28, 20.78), new Location(46.23, 20.76), new Location(46.21, 20.75),
                new Location(46.20, 20.74), new Location(46.15, 20.71),
                
                //timis
                new Location(46.14, 20.61), new Location(46.19, 20.513), new Location(46.15, 20.513), new Location(46.15, 20.40),
                new Location(46.16, 20.37), new Location(46.16, 20.32), new Location(46.13, 20.28), new Location(46.10, 20.28),
                new Location(46.05, 20.34), new Location(46.00, 20.36), new Location(46.00, 20.36), new Location(45.98, 20.38),
                new Location(45.97, 20.39), new Location(45.965, 20.43), new Location(45.965, 20.455),new Location(45.955, 20.475),
                new Location(45.945, 20.475), new Location(45.905, 20.495), new Location(45.89, 20.515), new Location(45.905, 20.575),
                new Location(45.855, 20.62), new Location(45.815, 20.65), new Location(45.805, 20.68), new Location(45.775, 20.70),
                new Location(45.745, 20.71), new Location(45.755, 20.78), new Location(45.785, 20.78), new Location(45.785, 20.82),
                new Location(45.725, 20.80), new Location(45.685, 20.805), new Location(45.59, 20.78), new Location(45.55, 20.83),
                new Location(45.52, 20.83), new Location(45.50, 20.78), new Location(45.48, 20.78), new Location(45.485, 20.84),
                new Location(45.47, 20.87), new Location(45.45, 20.87), new Location(45.432, 20.868),

                //timis holbostresu
                new Location(45.432, 20.868), new Location(45.417, 20.9), new Location(45.419, 20.92), new Location(45.385, 20.9385),
                new Location(45.383, 20.95), new Location(45.36, 20.978), new Location(45.343, 20.994), new Location(45.342, 21.013),
                new Location(45.324, 21.017), new Location(45.332, 21.0495), new Location(45.33, 21.062), new Location(45.316, 21.062),
                new Location(45.317, 21.081), new Location(45.297, 21.1), new Location(45.322, 21.174), new Location(45.324, 21.186),
                new Location(45.31, 21.182), new Location(45.303, 21.19), new Location(45.287, 21.192), new Location(45.275, 21.211),
                new Location(45.266, 21.206), new Location(45.25, 21.22), new Location(45.253, 21.226), new Location(45.23, 21.277),
                new Location(45.244, 21.293), new Location(45.237, 21.331), new Location(45.223, 21.361), new Location(45.226, 21.372),
                new Location(45.219, 21.397), new Location(45.23, 21.405), new Location(45.204, 21.44),

                //caras-severin
                new Location(45.193, 21.485), new Location(45.173, 21.494), new Location(45.171, 21.517), new Location(45.138, 21.53),
                new Location(45.122, 21.482), new Location(45.105, 21.473), new Location(45.093, 21.485), new Location(45.057, 21.453),
                new Location(45.04, 21.458), new Location(45.037, 21.425), new Location(45.026, 21.393), new Location(45.029, 21.388),
                new Location(45.02, 21.36), new Location(44.987, 21.417), new Location(44.98, 21.41), new Location(44.963, 21.45),
                new Location(44.956, 21.477), new Location(44.937, 21.52), new Location(44.94, 21.528), new Location(44.931, 21.547),
                new Location(44.918, 21.551), new Location(44.908, 21.56), new Location(44.889, 21.562), new Location(44.88, 21.513),
                new Location(44.87, 21.49), new Location(44.871, 21.471), new Location(44.867, 21.466), new Location(44.873, 21.459),
                new Location(44.872, 21.446), new Location(44.866, 21.444), new Location(44.874, 21.43), new Location(44.869, 21.41),
                new Location(44.868, 21.38), new Location(44.86, 21.366), new Location(44.86, 21.366), new Location(44.821, 21.36),
                new Location(44.821, 21.365), new Location(44.815, 21.379), new Location(44.779, 21.396), new Location(44.772, 21.421),
                new Location(44.776, 21.467), new Location(44.768, 21.511), new Location(44.773, 21.54), new Location(44.758, 21.59),
                new Location(44.74, 21.608), new Location(44.715, 21.616), new Location(44.696, 21.612), new Location(44.672, 21.616),
                new Location(44.66, 21.638), new Location(44.666, 21.666), new Location(44.661, 21.704), new Location(44.653, 21.72),
                new Location(44.662, 21.796), new Location(44.651, 21.814), new Location(44.652, 21.87), new Location(44.645, 21.885),
                new Location(44.647, 21.922), new Location(44.633, 21.956), new Location(44.6335, 21.992), 

                //mehedinti
                new Location(44.621, 22.003), new Location(44.61, 22.005), new Location(44.606, 22.01), new Location(44.593, 22.027),
                new Location(44.572, 22.026), new Location(44.541, 22.039), new Location(44.537, 22.055), new Location(44.529, 22.07),
                new Location(44.52, 22.071), new Location(44.505, 22.07), new Location(44.472, 22.14), new Location(44.48, 22.186),
                new Location(44.51, 22.199), new Location(44.577, 22.246), new Location(44.583, 22.253), new Location(44.604, 22.271),
                new Location(44.617, 22.274), new Location(44.626, 22.276), new Location(44.64, 22.30), new Location(44.654, 22.303),
                new Location(44.668, 22.32), new Location(44.679, 22.348), new Location(44.674, 22.368), new Location(44.683, 22.398),
                new Location(44.706, 22.42), new Location(44.716, 22.465), new Location(44.68, 22.515), new Location(44.668, 22.538),
                new Location(44.64, 22.569), new Location(44.635, 22.576), new Location(44.63, 22.587), new Location(44.614, 22.63),
                new Location(44.62, 22.675), new Location(44.606, 22.69), new Location(44.605, 22.71), new Location(44.55, 22.765),
                new Location(44.536, 22.76), new Location(44.515, 22.7), new Location(44.549, 22.63), new Location(44.551, 22.588),
                new Location(44.53, 22.562), new Location(44.493, 22.56), new Location(44.481, 22.549), new Location(44.472, 22.523),
                new Location(44.48, 22.47), new Location(44.475, 22.461), new Location(44.46, 22.46), new Location(44.45, 22.468),
                new Location(44.418, 22.504), new Location(44.405, 22.50), new Location(44.385, 22.504), new Location(44.365, 22.517),
                new Location(44.35, 22.522), new Location(44.333, 22.535), new Location(44.333, 22.535), new Location(44.325, 22.548),
                new Location(44.308, 22.56), new Location(44.294, 22.61), new Location(44.291, 22.658), new Location(44.282, 22.676),
                new Location(44.27, 22.684), new Location(44.253, 22.685), new Location(44.227, 22.671), new Location(44.213, 22.678),
                new Location(44.204, 22.698), new Location(44.20, 22.74), new Location(44.192, 22.76), new Location(44.167, 22.79),
                new Location(44.153, 22.819), new Location(44.148, 22.84), new Location(44.143, 22.85), new Location(44.135, 22.87),
                new Location(44.13, 22.88),

                //dolj
                new Location(44.115, 22.898), new Location(44.101, 22.935), new Location(44.098, 22.988), new Location(44.0955, 23.0),
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

                //olt
                new Location(43.70, 24.125), new Location(43.687, 24.15), new Location(43.683, 24.18), new Location(43.685, 24.2),
                new Location(43.689, 24.23), new Location(43.701, 24.313), new Location(43.695, 24.34), new Location(43.709, 24.37),
                new Location(43.72, 24.415), new Location(43.735, 24.435), new Location(43.763, 24.505), new Location(43.757, 24.55),
                new Location(43.749, 24.6), new Location(43.74, 24.634),

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
                new Location(45.58, 24.50)
           };
            #endregion

            return poligonBanat;
        }
        /// <summary>
        /// Conturul Transilvaniei
        /// </summary>
        /// <returns>MapPolyline cu Conturul Transilvaniei</returns>
        public MapPolygon PoligonTransilvania()
        {
            poligonTransilvania.Stroke = new SolidColorBrush(Colors.Yellow);
            poligonTransilvania.Fill = new SolidColorBrush(Colors.Green);
            poligonTransilvania.StrokeThickness = 5;
            poligonTransilvania.Opacity = 0.0;
            poligonTransilvania.MouseEnter += new MouseEventHandler(MPTransilvania_MouseEnter);
            poligonTransilvania.MouseLeave += new MouseEventHandler(MPTransilvania_MouseLeave);
            poligonTransilvania.MouseLeftButtonDown += new MouseButtonEventHandler(MPTransilvania_MouseLeftButtonDown);

            #region Puncte
            poligonTransilvania.Locations = new LocationCollection()
            {
                new Location(47.72, 24.91),
                //Suceava in jos
                new Location(47.645, 25.045), new Location(47.62, 24.98), new Location(47.58, 24.98), new Location(47.54, 25.04),
                new Location(47.50, 25.04), new Location(47.50, 25.08), new Location(47.48, 25.09), new Location(47.46, 25.05),
                new Location(47.43, 25.05), new Location(47.43, 25.01), new Location(47.41, 25.00), new Location(47.39, 25.06),
                new Location(47.33, 25.08), new Location(47.30, 25.04), new Location(47.27, 25.04), new Location(47.24, 25.08),
                new Location(47.20, 25.05), new Location(47.13, 25.09), new Location(47.13, 25.15),  new Location(47.15, 25.17),
                new Location(47.10, 25.23),
               
                //granita jud mures
                //granita jud. harghita
                new Location(47.10, 25.26), new Location(47.13, 25.30), new Location(47.11, 25.33), new Location(47.10, 25.38),
                new Location(47.105, 25.40),new Location(47.13, 25.40), new Location(47.14, 25.45),  new Location(47.135, 25.47),
                new Location(47.13, 25.50),  new Location(47.13, 25.53), new Location(47.09, 25.53),  new Location(47.07, 25.60),
                new Location(47.10, 25.60),  new Location(47.095, 25.69),
                
                //neamt
                new Location(47.08, 25.72),  new Location(47.05, 25.75), new Location(47.00, 25.79),  new Location(46.97, 25.79),
                new Location(46.97, 25.81),  new Location(46.99, 25.83), new Location(46.98, 25.85),  new Location(46.96, 25.86),
                new Location(46.94, 25.84),  new Location(46.92, 25.835), new Location(46.92, 25.80),  new Location(46.89, 25.76),
                new Location(46.83, 25.77),  new Location(46.83, 25.80), new Location(46.78, 25.82),  new Location(46.75, 25.82),
                new Location(46.72, 25.80),  new Location(46.69, 25.83), new Location(46.65, 25.88),  new Location(46.65, 25.92),
                new Location(46.69, 25.90),  new Location(46.705, 25.91), new Location(46.70, 25.95),  new Location(46.70, 25.95),
                new Location(46.68, 25.97),
                 
                //bacau
                new Location(46.64, 26.01), new Location(46.62, 25.995), new Location(46.60, 26.03), new Location(46.55, 26.04),
                new Location(46.50, 26.08), new Location(46.47, 26.01), new Location(46.45, 25.98), new Location(46.42, 26.00),
                new Location(46.42, 26.03), new Location(46.40, 26.07), new Location(46.42, 26.105), new Location(46.41, 26.18),
                new Location(46.36, 26.18),  new Location(46.33, 26.16), new Location(46.31, 26.17),  new Location(46.31, 26.21),
                new Location(46.35, 26.25),  new Location(46.35, 26.27), new Location(46.33, 26.30), new Location(46.27, 26.27),
                new Location(46.25, 26.27),
                
                //granita covasna
                new Location(46.25, 26.31), new Location(46.24, 26.33), new Location(46.15, 26.34), new Location(46.12, 26.33),
                new Location(46.09, 26.39), new Location(46.10, 26.42), new Location(46.08, 26.43), new Location(46.06, 26.41),
                new Location(46.05, 26.44),
                //vrancea
                new Location(46.04, 26.46), new Location(46.00, 26.46), new Location(45.97, 26.41), new Location(45.93, 26.39),
                new Location(45.90, 26.37), new Location(45.87, 26.39), new Location(45.85, 26.37), new Location(45.80, 26.39 ),
                
                //granita buzau
                new Location(45.74, 26.39), new Location(45.72, 26.36), new Location(45.71, 26.35), new Location(45.68, 26.33),
                new Location(45.65, 26.33), new Location(45.58, 26.28), new Location(45.60, 26.25), new Location(45.62, 26.21),
                new Location(45.62, 26.19), new Location(45.62, 26.19), new Location(45.58, 26.19), new Location(45.54, 26.16),
                new Location(45.52, 26.12),
                  
                //brasov
                new Location(45.52, 26.08), new Location(45.48, 26.05), new Location(45.48, 26.02),  new Location(45.48, 26.02),
                  
                //granita prahova
                new Location(45.52, 25.98), new Location(45.52, 25.92), new Location(45.48, 25.89), new Location(45.44, 25.87),
                new Location(45.44, 25.86),  new Location(45.44, 25.83), new Location(45.48, 25.80), new Location(45.48, 25.78),
                new Location(45.46, 25.76), new Location(45.46, 25.74), new Location(45.49, 25.70), new Location(45.48, 25.63),
                new Location(45.47, 25.60), new Location(45.45, 25.60), new Location(45.45, 25.55), new Location(45.46, 25.52),
                new Location(45.48, 25.51), new Location(45.48, 25.51), new Location(45.46, 25.46),
                
                //granita dambovita
                new Location(45.43, 25.43), new Location(45.43, 25.41), new Location(45.38, 25.41), new Location(45.38, 25.38),
                new Location(45.39, 25.36), new Location(45.39, 25.32),

                //granita arges
                new Location(45.42, 25.31), new Location(45.42, 25.28), new Location(45.42, 25.26), new Location(45.46, 25.26),
                new Location(45.48, 25.24), new Location(45.52, 25.24), new Location(45.53, 25.20), new Location(45.53, 25.18),
                new Location(45.54, 25.16), new Location(45.57, 25.14), new Location(45.58, 25.10), new Location(45.58, 25.05),
                new Location(45.60, 25.02), new Location(45.59, 24.98), new Location(45.59, 24.95), new Location(45.60, 24.94),
                new Location(45.59, 24.90), new Location(45.59, 24.85), new Location(45.62, 24.82), new Location(45.61, 24.80),
                new Location(45.61, 24.76), new Location(45.60, 24.72), new Location(45.61, 24.67),
                
                //Sibiu
                new Location(45.59, 24.65), new Location(45.60, 24.63), new Location(45.60, 24.60), new Location(45.58, 24.57),
                new Location(45.58, 24.55), new Location(45.58, 24.50), new Location(45.56, 24.49), 
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
                new Location(46.68, 21.44),

                //bihor
                new Location(46.69, 21.43), new Location(46.69, 21.50), new Location(46.73, 21.53), new Location(46.76, 21.48),
                new Location(46.79, 21.52), new Location(46.79, 21.52), new Location(46.84, 21.53), new Location(46.86, 21.60),
                new Location(46.88, 21.62), new Location(46.93, 21.61), new Location(46.93, 21.64), new Location(46.96, 21.68),
                new Location(47.05, 21.66), new Location(47.05, 21.70), new Location(47.11, 21.73), new Location(47.10, 21.80),
                new Location(47.19, 21.83), new Location(47.18, 21.87), new Location(47.20, 21.87), new Location(47.22, 21.85),
                new Location(47.38, 21.96), new Location(47.38, 22.01), new Location(47.42, 22.04), new Location(47.49, 22.01),
                new Location(47.55, 22.05), new Location(47.55, 22.08), new Location(47.57, 22.11), new Location(47.60, 22.14),

                //Satu mare
                new Location(47.60, 22.19), new Location(47.70, 22.23), new Location(47.71, 22.28), new Location(47.73, 22.25),
                new Location(47.74, 22.33), new Location(47.76, 22.34), new Location(47.74, 22.42), new Location(47.81, 22.44),
                new Location(47.81, 22.48), new Location(47.81, 22.50), new Location(47.79, 22.55), new Location(47.77, 22.54),
                new Location(47.77, 22.56), new Location(47.77, 22.60), new Location(47.79, 22.68), new Location(47.84, 22.71),
                new Location(47.83, 22.76), new Location(47.86, 22.80), new Location(47.88, 22.75), new Location(47.90, 22.76), 
                new Location(47.89, 22.79), new Location(47.90, 22.84), new Location(47.95, 22.88), new Location(47.96, 22.94),
                new Location(48.01, 22.93), new Location(48.01, 22.99), new Location(47.98, 23.01), new Location(48.00, 23.04),
                new Location(48.01, 23.10), new Location(48.03, 23.12), new Location(48.07, 23.13), new Location(48.09, 23.14),
                new Location(48.11, 23.16), new Location(48.12, 23.19), new Location(48.11, 23.21), new Location(48.10, 23.19),
                new Location(48.08, 23.23), new Location(48.10, 23.25), new Location(48.08, 23.30), new Location(48.05, 23.27),
                new Location(48.03, 23.30), new Location(48.04, 23.33), new Location(48.00, 23.37), new Location(48.00, 23.41),
              
                //Maramures
                new Location(47.98, 23.47), new Location(47.98, 23.51), new Location(48.00, 23.54), new Location(48.01, 23.64),
                new Location(47.99, 23.66), new Location(48.00, 23.75), new Location(47.98, 23.83), new Location(47.94, 23.86),
                new Location(47.95, 23.94), new Location(47.97, 23.98), new Location(47.96, 24.04), new Location(47.94, 24.09),
                new Location(47.92, 24.10), new Location(47.91, 24.12), new Location(47.93, 24.19), new Location(47.90, 24.22),
                new Location(47.91, 24.26), new Location(47.93, 24.34), new Location(47.91, 24.35), new Location(47.92, 24.38),
                new Location(47.96, 24.40), new Location(47.97, 24.48), new Location(47.96, 24.48), new Location(47.95, 24.55),
                new Location(47.96, 24.58), new Location(47.94, 24.66), new Location(47.93, 24.64), new Location(47.90, 24.69),
                new Location(47.87, 24.67), new Location(47.84, 24.72), new Location(47.84, 24.76), new Location(47.82, 24.82),
                new Location(47.74, 24.88)
            };
            #endregion

            return poligonTransilvania;
        }
        /// <summary>
        /// Conturul Romaniei
        /// </summary>
        /// <returns>MapPolyline cu Conturul Romaniei</returns>
        public MapPolyline RomaniaMap()
        {
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new SolidColorBrush(Colors.Yellow);
            polyline.StrokeThickness = 5;
            polyline.Opacity = 0.5;

            #region Puncte
            polyline.Locations = new LocationCollection() 
            {
                //timis holbostresu
                new Location(45.432, 20.868), new Location(45.417, 20.9), new Location(45.419, 20.92), new Location(45.385, 20.9385),
                new Location(45.383, 20.95), new Location(45.36, 20.978), new Location(45.343, 20.994), new Location(45.342, 21.013),
                new Location(45.324, 21.017), new Location(45.332, 21.0495), new Location(45.33, 21.062), new Location(45.316, 21.062),
                new Location(45.317, 21.081), new Location(45.297, 21.1), new Location(45.322, 21.174), new Location(45.324, 21.186),
                new Location(45.31, 21.182), new Location(45.303, 21.19), new Location(45.287, 21.192), new Location(45.275, 21.211),
                new Location(45.266, 21.206), new Location(45.25, 21.22), new Location(45.253, 21.226), new Location(45.23, 21.277),
                new Location(45.244, 21.293), new Location(45.237, 21.331), new Location(45.223, 21.361), new Location(45.226, 21.372),
                new Location(45.219, 21.397), new Location(45.23, 21.405), new Location(45.204, 21.44),

                //caras-severin
                new Location(45.193, 21.485), new Location(45.173, 21.494), new Location(45.171, 21.517), new Location(45.138, 21.53),
                new Location(45.122, 21.482), new Location(45.105, 21.473), new Location(45.093, 21.485), new Location(45.057, 21.453),
                new Location(45.04, 21.458), new Location(45.037, 21.425), new Location(45.026, 21.393), new Location(45.029, 21.388),
                new Location(45.02, 21.36), new Location(44.987, 21.417), new Location(44.98, 21.41), new Location(44.963, 21.45),
                new Location(44.956, 21.477), new Location(44.937, 21.52), new Location(44.94, 21.528), new Location(44.931, 21.547),
                new Location(44.918, 21.551), new Location(44.908, 21.56), new Location(44.889, 21.562), new Location(44.88, 21.513),
                new Location(44.87, 21.49), new Location(44.871, 21.471), new Location(44.867, 21.466), new Location(44.873, 21.459),
                new Location(44.872, 21.446), new Location(44.866, 21.444), new Location(44.874, 21.43), new Location(44.869, 21.41),
                new Location(44.868, 21.38), new Location(44.86, 21.366), new Location(44.86, 21.366), new Location(44.821, 21.36),
                new Location(44.821, 21.365), new Location(44.815, 21.379), new Location(44.779, 21.396), new Location(44.772, 21.421),
                new Location(44.776, 21.467), new Location(44.768, 21.511), new Location(44.773, 21.54), new Location(44.758, 21.59),
                new Location(44.74, 21.608), new Location(44.715, 21.616), new Location(44.696, 21.612), new Location(44.672, 21.616),
                new Location(44.66, 21.638), new Location(44.666, 21.666), new Location(44.661, 21.704), new Location(44.653, 21.72),
                new Location(44.662, 21.796), new Location(44.651, 21.814), new Location(44.652, 21.87), new Location(44.645, 21.885),
                new Location(44.647, 21.922), new Location(44.633, 21.956), new Location(44.6335, 21.992), 

                //mehedinti
                new Location(44.621, 22.003), new Location(44.61, 22.005), new Location(44.606, 22.01), new Location(44.593, 22.027),
                new Location(44.572, 22.026), new Location(44.541, 22.039), new Location(44.537, 22.055), new Location(44.529, 22.07),
                new Location(44.52, 22.071), new Location(44.505, 22.07), new Location(44.472, 22.14), new Location(44.48, 22.186),
                new Location(44.51, 22.199), new Location(44.577, 22.246), new Location(44.583, 22.253), new Location(44.604, 22.271),
                new Location(44.617, 22.274), new Location(44.626, 22.276), new Location(44.64, 22.30), new Location(44.654, 22.303),
                new Location(44.668, 22.32), new Location(44.679, 22.348), new Location(44.674, 22.368), new Location(44.683, 22.398),
                new Location(44.706, 22.42), new Location(44.716, 22.465), new Location(44.68, 22.515), new Location(44.668, 22.538),
                new Location(44.64, 22.569), new Location(44.635, 22.576), new Location(44.63, 22.587), new Location(44.614, 22.63),
                new Location(44.62, 22.675), new Location(44.606, 22.69), new Location(44.605, 22.71), new Location(44.55, 22.765),
                new Location(44.536, 22.76), new Location(44.515, 22.7), new Location(44.549, 22.63), new Location(44.551, 22.588),
                new Location(44.53, 22.562), new Location(44.493, 22.56), new Location(44.481, 22.549), new Location(44.472, 22.523),
                new Location(44.48, 22.47), new Location(44.475, 22.461), new Location(44.46, 22.46), new Location(44.45, 22.468),
                new Location(44.418, 22.504), new Location(44.405, 22.50), new Location(44.385, 22.504), new Location(44.365, 22.517),
                new Location(44.35, 22.522), new Location(44.333, 22.535), new Location(44.333, 22.535), new Location(44.325, 22.548),
                new Location(44.308, 22.56), new Location(44.294, 22.61), new Location(44.291, 22.658), new Location(44.282, 22.676),
                new Location(44.27, 22.684), new Location(44.253, 22.685), new Location(44.227, 22.671), new Location(44.213, 22.678),
                new Location(44.204, 22.698), new Location(44.20, 22.74), new Location(44.192, 22.76), new Location(44.167, 22.79),
                new Location(44.153, 22.819), new Location(44.148, 22.84), new Location(44.143, 22.85), new Location(44.135, 22.87),
                new Location(44.13, 22.88),

                //dolj
                new Location(44.115, 22.898), new Location(44.101, 22.935), new Location(44.098, 22.988), new Location(44.0955, 23.0),
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

                //olt
                new Location(43.70, 24.125), new Location(43.687, 24.15), new Location(43.683, 24.18), new Location(43.685, 24.2),
                new Location(43.689, 24.23), new Location(43.701, 24.313), new Location(43.695, 24.34), new Location(43.709, 24.37),
                new Location(43.72, 24.415), new Location(43.735, 24.435), new Location(43.763, 24.505), new Location(43.757, 24.55),
                new Location(43.749, 24.6), new Location(43.74, 24.634),

                //teleorman
                new Location(43.726, 24.654), new Location(43.71, 24.675), new Location(43.686, 24.732), new Location(43.687, 24.75),
                new Location(43.71, 24.8), new Location(43.714, 24.83), new Location(43.706, 24.87), new Location(43.718, 24.925),
                new Location(43.719, 24.95), new Location(43.729, 24.984), new Location(43.725, 25.008), new Location(43.714, 25.017),
                new Location(43.691, 25.06), new Location(43.684, 25.111), new Location(43.698, 25.164), new Location(43.698, 25.188),
                new Location(43.692, 25.2), new Location(43.685, 25.248), new Location(43.654, 25.297), new Location(43.64, 25.33),
                new Location(43.628, 25.355), new Location(43.62, 25.393), new Location(43.623, 25.42), new Location(43.647, 25.5),
                new Location(43.646, 25.526), new Location(43.645, 25.553), new Location(43.652, 25.58),

                //giurgiu
                new Location(43.692, 25.675), new Location(43.69, 25.713), new Location(43.695, 25.745), new Location(43.72, 25.793),
                new Location(43.734, 25.8), new Location(43.755, 25.825), new Location(43.76, 25.857), new Location(43.77, 25.87),
                new Location(43.84, 25.927), new Location(43.861, 25.955), new Location(43.896, 26.028), new Location(43.905, 26.059),
                new Location(43.94, 26.08), new Location(43.967, 26.11), new Location(43.989, 26.16), new Location(43.983, 26.195),

                //calarasi
                new Location(44.037, 26.35), new Location(44.042, 26.4), new Location(44.039, 26.43), new Location(44.043, 26.47),
                new Location(44.045, 26.497), new Location(44.055, 26.55), new Location(44.053, 26.6), new Location(44.064, 26.66),
                new Location(44.08, 26.718), new Location(44.073, 26.74), new Location(44.083, 26.77), new Location(44.125, 26.88),
                new Location(44.135, 26.94), new Location(44.134, 26.996), new Location(44.144, 27.038), new Location(44.133, 27.087),
                new Location(44.14, 27.123), new Location(44.136, 27.16), new Location(44.12, 27.19), new Location(44.115, 27.24),

                //constanta
                new Location(44.128, 27.274), new Location(44.074, 27.29), new Location(44.056, 27.36), new Location(44.013, 27.4),
                new Location(44.022, 27.47), new Location(44.012, 27.611), new Location(44.012, 27.611), new Location(44.05, 27.642),
                new Location(44.03, 27.675), new Location(43.961, 27.71), new Location(43.952, 27.74), new Location(43.958, 27.76),
                new Location(43.965, 27.84), new Location(44.009, 27.916), new Location(43.987, 27.944), new Location(43.94, 27.955),
                new Location(43.91, 27.97), new Location(43.846, 27.994), new Location(43.83, 28.03), new Location(43.757, 28.24),
                new Location(43.753, 28.35), new Location(43.735, 28.45), 
                
                //litoral
                new Location(43.74, 28.585), new Location(43.76, 28.58), new Location(43.80, 28.59), new Location(43.845, 28.62),
                new Location(43.885, 28.62), new Location(43.91, 28.645), new Location(43.95, 28.65), new Location(43.985, 28.677),
                new Location(44.0, 28.67), new Location(44.078, 28.65), new Location(44.083, 28.685), new Location(44.15, 28.68),
                new Location(44.22, 28.654), new Location(44.275, 28.634), new Location(44.313, 28.65), new Location(44.3, 28.68),
                new Location(44.41, 28.812), new Location(44.48, 28.875), new Location(44.52, 28.92), new Location(44.55, 28.93),
                new Location(44.7, 29.05), new Location(44.75, 29.20), new Location(44.77, 29.35), new Location(44.75, 29.57),
                new Location(44.81, 29.61), new Location(44.98, 29.65), new Location(45.16, 29.70),

                //DELTA DUNARII
                new Location(45.20, 29.70), new Location(45.24, 29.67), new Location(45.27, 29.70), new Location(45.35, 29.69), 
                new Location(45.38, 29.64), new Location(45.43, 29.47), new Location(45.45, 29.45), new Location(45.42, 29.20),
                new Location(45.39, 29.18), new Location(45.38, 29.10), new Location(45.37, 29.05), new Location(45.35, 29.00),
                new Location(45.32, 28.95), new Location(45.28, 28.94), new Location(45.34, 28.80), new Location(45.30, 28.80),
                new Location(45.30, 28.76), new Location(45.24, 28.79), new Location(45.22, 28.72), new Location(45.27, 28.50),
                new Location(45.31, 28.35), new Location(45.35, 28.33), new Location(45.40, 28.30), new Location(45.46, 28.28),

                //Reni Republica Moldova+galati+vaslui
                new Location(45.47, 28.25), new Location(45.47, 28.20), new Location(45.57, 28.16), new Location(45.58, 28.10),
                new Location(45.63, 28.10), new Location(45.64, 28.16), new Location(45.76, 28.16), new Location(45.78, 28.12),
                new Location(45.84, 28.12), new Location(45.86, 28.10), new Location(45.90, 28.12), new Location(45.96, 28.12),
                new Location(46.02, 28.11), new Location(46.04, 28.09), new Location(46.14, 28.14), new Location(46.16, 28.12),
                new Location(46.20, 28.14), new Location(46.22, 28.12), new Location(46.25, 28.14), new Location(46.27, 28.14),
                new Location(46.30, 28.17), new Location(46.34, 28.22), new Location(46.37, 28.19), new Location(46.39, 28.22),
                new Location(46.43, 28.25), new Location(46.46, 28.25), new Location(46.50, 28.23), new Location(46.54, 28.21),
                new Location(46.63, 28.26), new Location(46.73, 28.20), new Location(46.77, 28.19), new Location(46.82, 28.12),
                new Location(46.84, 28.12), new Location(46.85, 28.11),

                //Iasi Inceput Judet
                new Location(46.85, 28.11), new Location(46.87, 28.13), new Location(46.92, 28.10), new Location(46.94, 28.10),
                new Location(46.98, 28.11), new Location(47.06, 28.00), new Location(47.06, 27.94), new Location(47.16, 27.80),  
                new Location(47.30, 27.75), new Location(47.31, 27.65), new Location(47.31, 27.64), new Location(47.34, 27.60),
                new Location(47.35, 27.62), new Location(47.37, 27.60), new Location(47.39, 27.58), new Location(47.43, 27.56),
                new Location(47.45, 27.59), new Location(47.47, 27.60), new Location(47.48, 27.50), new Location(47.53, 27.45),
                new Location(47.58, 27.45),

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

                //Maramures
                new Location(47.74, 24.88), new Location(47.82, 24.82), new Location(47.84, 24.76), new Location(47.84, 24.72),
                new Location(47.87, 24.67), new Location(47.90, 24.69), new Location(47.93, 24.64), new Location(47.94, 24.66),
                new Location(47.96, 24.58), new Location(47.95, 24.55), new Location(47.96, 24.48), new Location(47.97, 24.48),
                new Location(47.96, 24.40), new Location(47.92, 24.38), new Location(47.91, 24.35), new Location(47.93, 24.34), 
                new Location(47.91, 24.26), new Location(47.90, 24.22), new Location(47.93, 24.19), new Location(47.91, 24.12),
                new Location(47.92, 24.10), new Location(47.94, 24.09), new Location(47.96, 24.04), new Location(47.97, 23.98),
                new Location(47.95, 23.94), new Location(47.94, 23.86), new Location(47.98, 23.83), new Location(48.00, 23.75),
                new Location(47.99, 23.66), new Location(48.01, 23.64), new Location(48.00, 23.54), new Location(47.98, 23.51),
                new Location(47.98, 23.47),

                //Satu mare
                new Location(48.00, 23.41), new Location(48.00, 23.37), new Location(48.04, 23.33), new Location(48.03, 23.30),
                new Location(48.05, 23.27), new Location(48.08, 23.30), new Location(48.10, 23.25), new Location(48.08, 23.23),
                new Location(48.10, 23.19), new Location(48.11, 23.21), new Location(48.12, 23.19), new Location(48.11, 23.16),
                new Location(48.09, 23.14), new Location(48.07, 23.13), new Location(48.03, 23.12), new Location(48.01, 23.10),
                new Location(48.00, 23.04), new Location(47.98, 23.01), new Location(48.01, 22.99), new Location(48.01, 22.93),
                new Location(47.96, 22.94), new Location(47.95, 22.88), new Location(47.90, 22.84), new Location(47.89, 22.79),
                new Location(47.90, 22.76), new Location(47.88, 22.75), new Location(47.86, 22.80), new Location(47.83, 22.76),
                new Location(47.84, 22.71), new Location(47.79, 22.68), new Location(47.77, 22.60), new Location(47.77, 22.56),
                new Location(47.77, 22.54), new Location(47.79, 22.55), new Location(47.81, 22.50), new Location(47.81, 22.48), 
                new Location(47.81, 22.44), new Location(47.74, 22.42), new Location(47.76, 22.34), new Location(47.74, 22.33),
                new Location(47.73, 22.25), new Location(47.71, 22.28), new Location(47.70, 22.23), new Location(47.60, 22.19),

                //bihor
                new Location(47.60, 22.14), new Location(47.57, 22.11), new Location(47.55, 22.08), new Location(47.55, 22.05),
                new Location(47.49, 22.01), new Location(47.42, 22.04), new Location(47.38, 22.01), new Location(47.38, 21.96),
                new Location(47.22, 21.85), new Location(47.20, 21.87), new Location(47.18, 21.87), new Location(47.19, 21.83),
                new Location(47.10, 21.80), new Location(47.11, 21.73), new Location(47.05, 21.70), new Location(47.05, 21.66),
                new Location(46.96, 21.68), new Location(46.93, 21.64), new Location(46.93, 21.61), new Location(46.88, 21.62),
                new Location(46.86, 21.60), new Location(46.84, 21.53), new Location(46.79, 21.52), new Location(46.79, 21.52),
                new Location(46.76, 21.48), new Location(46.73, 21.53), new Location(46.69, 21.50), new Location(46.69, 21.43),
                new Location(46.62, 21.43), new Location(46.64, 21.36),

                //arad
                new Location(46.63, 21.33), new Location(46.58, 21.30), new Location(46.58, 21.34), new Location(46.58, 21.34),
                new Location(46.50, 21.25), new Location(46.45, 21.33), new Location(46.40, 21.30), new Location(46.40, 21.20),
                new Location(46.35, 21.20), new Location(46.33, 21.17), new Location(46.30, 21.18), new Location(46.29, 21.10),
                new Location(46.25, 21.10), new Location(46.24, 21.05), new Location(46.26, 21.02), new Location(46.27, 20.95),
                new Location(46.29, 20.93), new Location(46.29, 20.93), new Location(46.26, 20.91), new Location(46.28, 20.86),
                new Location(46.28, 20.82), new Location(46.28, 20.78), new Location(46.23, 20.76), new Location(46.21, 20.75),
                new Location(46.20, 20.74), new Location(46.15, 20.71),
              
                //timis
                new Location(46.14, 20.61), new Location(46.19, 20.513), new Location(46.15, 20.513), new Location(46.15, 20.40),
                new Location(46.16, 20.37), new Location(46.16, 20.32), new Location(46.13, 20.28), new Location(46.10, 20.28),
                new Location(46.05, 20.34), new Location(46.00, 20.36), new Location(46.00, 20.36), new Location(45.98, 20.38),
                new Location(45.97, 20.39), new Location(45.965, 20.43), new Location(45.965, 20.455), new Location(45.955, 20.475),
                new Location(45.945, 20.475), new Location(45.905, 20.495), new Location(45.89, 20.515), new Location(45.905, 20.575),
                new Location(45.855, 20.62), new Location(45.815, 20.65), new Location(45.805, 20.68), new Location(45.775, 20.70),
                new Location(45.745, 20.71), new Location(45.755, 20.78), new Location(45.785, 20.78), new Location(45.785, 20.82),
                new Location(45.725, 20.80), new Location(45.685, 20.805), new Location(45.59, 20.78), new Location(45.55, 20.83),
                new Location(45.52, 20.83), new Location(45.50, 20.78), new Location(45.48, 20.78), new Location(45.485, 20.84),
                new Location(45.47, 20.87), new Location(45.45, 20.87), new Location(45.432, 20.868)
            };
            #endregion

            return polyline;
        }
        #endregion
        public void lol()
        {
            if (TimeIsOn == false)
            {
                TimeIsOn = true;
                timer.Start();
                bIsMousePressedMoldova = true;

                Moldova m = new Moldova(map, c, md,this,lista,false);

                map.Children.Add(m.MoldovaRegiune1());
                map.Children.Add(m.MoldovaRegiune2());
                map.Children.Add(m.MoldovaRegiune3());
                map.Children.Add(m.MoldovaRegiune4());
                poligonMoldova.Visibility = Visibility.Collapsed;
                poligonBaragan.Visibility = Visibility.Collapsed;
                poligonTransilvania.Visibility = Visibility.Collapsed;
                poligonBanat.Visibility = Visibility.Collapsed;
                AtributeGlobale.RegiuneaCurenta = AtributeGlobale.EnumRegiuni.Moldova;//Holban code;do not delete
            }
        }
        #region Evenimente
        void t_Tick(object sender, EventArgs e)
        {
          
            if (Z > 7)
            {
                timer.Stop(); 
                TimeIsOn = false; }
            if (bIsMousePressedMoldova)
            { Z += 0.1; Long += 0.19; Lat += 0.10; }
            if (bIsMousePressedBaragan)
            { Z += 0.1; Long += 0.25; Lat -= 0.1; }
            if (bIsMousePressedTransilvania)
            { Z += 0.1; Long -= 0.07; Lat += 0.10; }
            if (bIsMousePressedBanat)
            { Z += 0.1; Long -= 0.2; Lat -= 0.04; }
            map.SetView(new Location(Lat, Long), Z);
            
        }

        #region Evenimente Moldova
      
       
        void p_MouseLeftButtonDown_Moldova(object sender, MouseButtonEventArgs e)
        {
            if (TimeIsOn == false)
            {
                TimeIsOn = true;
                timer.Start();
                bIsMousePressedMoldova = true;
              
                Moldova m = new Moldova(map,c,md,this,lista,true);
               
                map.Children.Add(m.MoldovaRegiune1());
                map.Children.Add(m.MoldovaRegiune2());
                map.Children.Add(m.MoldovaRegiune3());
                map.Children.Add(m.MoldovaRegiune4());
                poligonMoldova.Visibility = Visibility.Collapsed;
                poligonBaragan.Visibility = Visibility.Collapsed;
                poligonTransilvania.Visibility = Visibility.Collapsed;
                poligonBanat.Visibility = Visibility.Collapsed;
                AtributeGlobale.RegiuneaCurenta = AtributeGlobale.EnumRegiuni.Moldova;//Holban code;do not delete
                PaginaUser.getInstance().updateCurrentRegion();
            }
        }
        void p_MouseLeave_Moldova(object sender, MouseEventArgs e)
        {
            if (bIsMousePressedMoldova == false)
                poligonMoldova.Opacity = 0.0;
            else poligonMoldova.Opacity = 0.5;
        }
        void p_MouseEnter_Moldova(object sender, MouseEventArgs e)
        {
            poligonMoldova.Fill = new SolidColorBrush(Colors.Green);
            poligonMoldova.Opacity = 0.5;
        }
        #endregion

        #region Evenimente Baragan
        void poligonBaragan_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TimeIsOn == false)
            {
                TimeIsOn = true;
                timer.Start();
                bIsMousePressedBaragan = true;
                Baragan b = new Baragan(map, c, md, this, lista, false);
                map.Children.Add(b.BaraganRegiune1());
                map.Children.Add(b.BaraganRegiune2());
                map.Children.Add(b.BaraganRegiune3());
                map.Children.Add(b.BaraganRegiune4());
                poligonMoldova.Visibility = Visibility.Collapsed;
                poligonBaragan.Visibility = Visibility.Collapsed;
                poligonTransilvania.Visibility = Visibility.Collapsed;
                poligonBanat.Visibility = Visibility.Collapsed;
                AtributeGlobale.RegiuneaCurenta = AtributeGlobale.EnumRegiuni.Baragan;//Holban code;do not delete
            }
        }
        void poligonBaragan_MouseLeave(object sender, MouseEventArgs e)
        {
            if (bIsMousePressedBaragan == false)
                poligonBaragan.Opacity = 0.0;
            else poligonBaragan.Opacity = 0.5;
        }
        void poligonBaragan_MouseEnter(object sender, MouseEventArgs e)
        {
            poligonBaragan.Fill = new SolidColorBrush(Colors.Green);
            poligonBaragan.Opacity = 0.5;
        }
        #endregion

        #region Evenimente Transilvania
        void MPTransilvania_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TimeIsOn == false)
            {
                TimeIsOn = true;
                timer.Start();
                bIsMousePressedTransilvania = true;
                Transilvania t = new Transilvania(map, c, md, this, lista, false);
                map.Children.Add(t.TransilvaniaRegiune1());
                map.Children.Add(t.TransilvaniaRegiune2());
                map.Children.Add(t.TransilvaniaRegiune3());
                map.Children.Add(t.TransilvaniaRegiune4());
                poligonMoldova.Visibility = Visibility.Collapsed;
                poligonBaragan.Visibility = Visibility.Collapsed;
                poligonTransilvania.Visibility = Visibility.Collapsed;
                poligonBanat.Visibility = Visibility.Collapsed;
                AtributeGlobale.RegiuneaCurenta = AtributeGlobale.EnumRegiuni.Transilvania;//Holban code;do not delete
            }
        }
        void MPTransilvania_MouseLeave(object sender, MouseEventArgs e)
        {
            if (bIsMousePressedTransilvania == false)
                poligonTransilvania.Opacity = 0.0;
            else poligonTransilvania.Opacity = 0.5;
        }
        void MPTransilvania_MouseEnter(object sender, MouseEventArgs e)
        {
            poligonTransilvania.Fill = new SolidColorBrush(Colors.Green);
            poligonTransilvania.Opacity = 0.5;
        }
        #endregion

        #region Evenimente Banat
        void poligonBanat_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TimeIsOn == false)
            {
                TimeIsOn = true;
                bIsMousePressedBanat = true;
                Banat m = new Banat(map, c, md, this, lista, false);
                map.Children.Add(m.BanatRegiune1());
                map.Children.Add(m.BanatRegiune2());
                map.Children.Add(m.BanatRegiune3());
                poligonMoldova.Visibility = Visibility.Collapsed;
                poligonBaragan.Visibility = Visibility.Collapsed;
                poligonTransilvania.Visibility = Visibility.Collapsed;
                poligonBanat.Visibility = Visibility.Collapsed;
                AtributeGlobale.RegiuneaCurenta = AtributeGlobale.EnumRegiuni.Banat;//Holban code;do not delete
                timer.Start();
            }
        }
        void poligonBanat_MouseLeave(object sender, MouseEventArgs e)
        {
            if (bIsMousePressedBanat == false)
                poligonBanat.Opacity = 0.0;
            else poligonBanat.Opacity = 0.5;
        }
        void poligonBanat_MouseEnter(object sender, MouseEventArgs e)
        {
            poligonBanat.Fill = new SolidColorBrush(Colors.Green);
            poligonBanat.Opacity = 0.5;
        }
        #endregion

        public bing.MainPage MainPage
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        #endregion
        #region PushPin
        public void AddPushPin(List<ListaReal> list)
        {
            map.Children.Clear();
            map.Children.Add(RomaniaMap());
            foreach (var lol in list)
            {
               
                    Canvas c = new Canvas() { Width = 7, Height = 7 };
                    #region NivelProblema
                    if (lol.InivelProblema == 1)
                    { c.Background = new SolidColorBrush(Colors.Red); c.Opacity = 0.99; }
                    else if (lol.InivelProblema == 2)
                    { c.Background = new SolidColorBrush(Colors.White); c.Opacity = 0.98; }
                    else if (lol.InivelProblema == 3)
                    { c.Background = new SolidColorBrush(Colors.Orange); c.Opacity = 0.97; }
                    #endregion
              
                c.MouseEnter += new MouseEventHandler(c_MouseEnter);
                c.MouseLeave += new MouseEventHandler(c_MouseLeave);
                c.MouseLeftButtonDown += new MouseButtonEventHandler(c_MouseLeftButtonDown);
                MapLayer l = new MapLayer();
                   #region NumeCampanie
                TextBlock tx = new TextBlock() { Foreground = new SolidColorBrush(Colors.White), FontSize = 15, FontFamily = new FontFamily("Tahoma") };
                tx.Text = lol.nume;
                tx.Visibility = Visibility.Collapsed;
                c.Children.Add(tx);
                Canvas.SetLeft(tx,50);
                Canvas.SetTop(tx, 5);
                 #endregion    
                tx = new TextBlock() { Foreground = new SolidColorBrush(Colors.White), FontSize = 13, FontFamily = new FontFamily("Tahoma") };
                tx.Text ="Location: "+ lol.locatie;
                tx.Visibility = Visibility.Collapsed;
                c.Children.Add(tx);
                Canvas.SetLeft(tx, 10);
                Canvas.SetTop(tx, 30);
                l.AddChild(c, lol.x);
                map.Children.Add(l);
            }
        }
        private static bool bisAddedInfoCanvas = false;
        MapLayer MaplayerinfoJudet = new MapLayer();
       public  void ADDInfoCanvas(string temp,string temperatura,string precipitatii,double lat,double longi)
        {
            if (bisAddedInfoCanvas == false)
            {
                MaplayerinfoJudet.Children.Clear();
                Canvas c = new Canvas() { Width = 250, Height = 100 };
                c.Background = new SolidColorBrush(Colors.Black); c.Opacity = 0.99;
                RectangleGeometry rg = new RectangleGeometry() { Rect = new Rect(0, 0, 250, 100), RadiusX = 10, RadiusY = 10 };
                c.Clip = rg;
                MaplayerinfoJudet.AddChild(c, new Location(lat, longi));
                TextBlock t = new TextBlock() { Text = "Info", Foreground = new SolidColorBrush(Colors.White), FontSize = 16 };
                c.Children.Add(t);
                Canvas.SetLeft(t, 80);
                Canvas.SetTop(t, 5);
                TextBlock climate = new TextBlock() { Text = "Climate: "+temp, Foreground = new SolidColorBrush(Colors.White), FontSize = 14 };
                c.Children.Add(climate);
                Canvas.SetLeft(climate, 10);
                Canvas.SetTop(climate, 30);
                TextBlock temperature = new TextBlock() { Text = "Temperature: "+ temperatura, Foreground = new SolidColorBrush(Colors.White), FontSize = 14 };
                c.Children.Add(temperature);
                Canvas.SetLeft(temperature, 10);
                Canvas.SetTop(temperature, 50);
                TextBlock precipitation = new TextBlock() { Text = "Precipitation: "+precipitatii, Foreground = new SolidColorBrush(Colors.White), FontSize = 14 };
                c.Children.Add(precipitation);
                Canvas.SetLeft(precipitation, 10);
                Canvas.SetTop(precipitation, 70);
                map.Children.Add(MaplayerinfoJudet);
                bisAddedInfoCanvas = true;
            }
        }
       public void RemoveinfoCanvas()
       {
           map.Children.Remove(MaplayerinfoJudet);
           bisAddedInfoCanvas = false;
       }
        void c_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Canvas z = (Canvas)sender;
            MeniuSus s = new MeniuSus(c);
        }

        void c_MouseLeave(object sender, MouseEventArgs e)
        {
            Canvas c = (Canvas)sender;
            foreach (var z in c.Children)
            {
                z.Visibility = Visibility.Collapsed;
            }
            #region NivelProblema
            if (Math.Round(c.Opacity,2) == 0.99)
            {
                c.Background = new SolidColorBrush(Colors.Red);
            }
            else if (Math.Round(c.Opacity, 2) == 0.98)
            {
                c.Background = new SolidColorBrush(Colors.White);
            }
            else if (Math.Round(c.Opacity, 2) == 0.97)
            {
                c.Background = new SolidColorBrush(Colors.Orange);
            }
            #endregion NivelProblema
            RectangleGeometry rg = new RectangleGeometry() { Rect = new Rect(0, 0,7, 7) };
            c.Clip = rg;
            c.Width = 7;
            c.Height = 7;
        }

        void c_MouseEnter(object sender, MouseEventArgs e)
        {
            Canvas c = (Canvas)sender;
            foreach (var z in c.Children)
            {
                z.Visibility = Visibility.Visible;
            }
         
            RectangleGeometry rg = new RectangleGeometry() { Rect = new Rect(0, 0, 200, 88), RadiusX = 10, RadiusY = 10 };
            c.Clip = rg;
           
            c.Background = new SolidColorBrush(Colors.Black);
            c.Width = 200;
            c.Height = 88;
        }
        #endregion
        public Transilvania Transilvania
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Moldova Moldova
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Baragan Baragan
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Banat Banat
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Get the current instance for global use
        /// </summary>
        /// <returns> current instance </returns>
        public static MapLayers getInstance()
        {
            if (mapLayers != null)
                return mapLayers;
            return null;
        }

        public Canvas getMeniuDreapta()
        {
            return md;
        }
    }
}
