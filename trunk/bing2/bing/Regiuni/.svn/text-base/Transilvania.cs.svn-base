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

namespace Regiuni
{
    public class Transilvania
    {
        private static MapPolygon MPTransilvaniaRegiune1;
        private static MapPolygon MPTransilvaniaRegiune2;
        private static MapPolygon MPTransilvaniaRegiune3;
        private static MapPolygon MPTransilvaniaRegiune4;
        public Transilvania()
        {
            MPTransilvaniaRegiune1 = new MapPolygon();
            MPTransilvaniaRegiune2 = new MapPolygon();
            MPTransilvaniaRegiune3 = new MapPolygon();
            MPTransilvaniaRegiune4 = new MapPolygon();

            MPTransilvaniaRegiune1.MouseEnter += new MouseEventHandler(MPTransilvaniaRegiune1_MouseEnter);
            MPTransilvaniaRegiune2.MouseEnter += new MouseEventHandler(MPTransilvaniaRegiune2_MouseEnter);
            MPTransilvaniaRegiune3.MouseEnter += new MouseEventHandler(MPTransilvaniaRegiune3_MouseEnter);
            MPTransilvaniaRegiune4.MouseEnter += new MouseEventHandler(MPTransilvaniaRegiune4_MouseEnter);

            MPTransilvaniaRegiune1.MouseLeave += new MouseEventHandler(MPTransilvaniaRegiune1_MouseLeave);
            MPTransilvaniaRegiune2.MouseLeave += new MouseEventHandler(MPTransilvaniaRegiune2_MouseLeave);
            MPTransilvaniaRegiune3.MouseLeave += new MouseEventHandler(MPTransilvaniaRegiune3_MouseLeave);
            MPTransilvaniaRegiune4.MouseLeave += new MouseEventHandler(MPTransilvaniaRegiune4_MouseLeave);
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
                  
        public MapPolygon TransilvaniaRegiune1()
        {
            MPTransilvaniaRegiune1.Stroke = new SolidColorBrush(Colors.Red);
            MPTransilvaniaRegiune1.Fill = new SolidColorBrush(Colors.Gray);
            MPTransilvaniaRegiune1.StrokeThickness = 0;
            MPTransilvaniaRegiune1.Opacity = 0.8;

            #region Puncte
            MPTransilvaniaRegiune1.Locations = new LocationCollection()
            {
                //granita jud. harghita
                new Location(47.10, 25.26), new Location(47.13, 25.30), new Location(47.11, 25.33), new Location(47.10, 25.38),
                new Location(47.105, 25.40), new Location(47.13, 25.40), new Location(47.14, 25.45), new Location(47.135, 25.47),
                new Location(47.13, 25.50), new Location(47.13, 25.53), new Location(47.09, 25.53), new Location(47.07, 25.60),
                new Location(47.10, 25.60), new Location(47.095, 25.69),
                
                //neamt
                new Location(47.08, 25.72), new Location(47.05, 25.75), new Location(47.00, 25.79), new Location(46.97, 25.79),
                new Location(46.97, 25.81), new Location(46.99, 25.83), new Location(46.98, 25.85), new Location(46.96, 25.86),
                new Location(46.94, 25.84), new Location(46.92, 25.835), new Location(46.92, 25.80), new Location(46.89, 25.76),
                new Location(46.83, 25.77), new Location(46.83, 25.80), new Location(46.78, 25.82), new Location(46.75, 25.82),
                new Location(46.72, 25.80), new Location(46.69, 25.83), new Location(46.65, 25.88), new Location(46.65, 25.92),
                new Location(46.69, 25.90), new Location(46.705, 25.91), new Location(46.70, 25.95), new Location(46.70, 25.95),
                new Location(46.68, 25.97),
                
                //bacau
                new Location(46.64, 26.01), new Location(46.62, 25.995), new Location(46.60, 26.03), new Location(46.55, 26.04),
                new Location(46.50, 26.08), new Location(46.47, 26.01), new Location(46.45, 25.98), new Location(46.42, 26.00),
                new Location(46.42, 26.03), new Location(46.40, 26.07), new Location(46.42, 26.105), new Location(46.41, 26.18),
                new Location(46.36, 26.18), new Location(46.33, 26.16), new Location(46.31, 26.17), new Location(46.31, 26.21),
                new Location(46.35, 26.25), new Location(46.35, 26.27), new Location(46.33, 26.30), new Location(46.27, 26.27),
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

                //brasov sud->nord
                new Location(45.70,24.70), new Location(45.80,24.65), new Location(45.84,24.72), new Location(45.85,24.77),
                new Location(45.87,24.77), new Location(45.90,24.72), new Location(45.94,24.72), new Location(45.94,24.75),
                new Location(45.97,24.79), new Location(45.97,24.83), new Location(45.99,24.85), new Location(46.01,24.85),
                new Location(46.05,24.92), new Location(46.05,24.94), new Location(46.11,24.96), new Location(46.14,25.02),
                new Location(46.13,25.04), new Location(46.13,25.06), new Location(46.15,25.09), new Location(46.15,25.10),
                new Location(46.13,25.13), new Location(46.13,25.15), new Location(46.15,25.15), new Location(46.17,25.18),
                
                //harghita sud->nord
                new Location(46.18,25.14), new Location(46.21,25.11), new Location(46.24,25.10), new Location(46.25,25.06),
                new Location(46.25,25.03), new Location(46.24,24.99), new Location(46.24,24.97), new Location(46.28,24.93),
                new Location(46.29,24.87), new Location(46.31,24.85), new Location(46.31,24.85), new Location(46.33,24.88),
                new Location(46.33,24.86), new Location(46.38,24.84), new Location(46.39,24.85), new Location(46.37,24.94),
                new Location(46.37,24.96), new Location(46.38,24.98), new Location(46.43,24.94), new Location(46.44,24.97),
                new Location(46.45,25.00), new Location(46.48,25.01), new Location(46.51,25.00), new Location(46.54,25.025),
                new Location(46.57,25.09), new Location(46.57,25.15), new Location(46.63,25.21), new Location(46.69,25.29),
                new Location(46.78,25.30), new Location(46.78,25.32), new Location(46.81,25.28), new Location(46.84,25.28),
                new Location(46.86,25.26), new Location(46.91,25.28), new Location(47.03,25.275), new Location(47.06,25.24),
                new Location(47.09, 25.25),new Location(47.10, 25.26)
            };
            #endregion

            return MPTransilvaniaRegiune1;
        }
        public MapPolygon TransilvaniaRegiune2()
        {
            MPTransilvaniaRegiune2.Stroke = new SolidColorBrush(Colors.Red);
            MPTransilvaniaRegiune2.Fill = new SolidColorBrush(Colors.Gray);
            MPTransilvaniaRegiune2.StrokeThickness = 0;
            MPTransilvaniaRegiune2.Opacity = 0.5;

            #region Puncte
            MPTransilvaniaRegiune2.Locations = new LocationCollection() 
            { 
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

                //alba in sus
                new Location(46.40, 22.685),  new Location(46.42, 22.680), new Location(46.42, 22.676),  new Location(46.43, 22.665),
                new Location(46.45, 22.685),  new Location(46.46, 22.687), new Location(46.47, 22.685),  new Location(46.48, 22.6794),
                new Location(46.485, 22.674), new Location(46.49, 22.672), new Location(46.495, 22.679), new Location(46.51, 22.670),
                new Location(46.515, 22.679), new Location(46.525, 22.677), new Location(46.535, 22.69),  new Location(46.535, 22.697),
                new Location(46.545, 22.715), new Location(46.535, 22.715), new Location(46.535, 22.725), new Location(46.545, 22.725),
                new Location(46.555, 22.705), new Location(46.565, 22.695), new Location(46.569, 22.695), new Location(46.569, 22.695),
                new Location(46.569, 22.695),  new Location(46.59, 22.74), new Location(46.58, 22.79),    new Location(46.56, 22.82),
                new Location(46.54, 22.85),  new Location(46.55, 22.875), new Location(46.55, 22.95), new Location(46.54, 22.98),
                new Location(46.54, 22.98),  new Location(46.54, 23.03), new Location(46.50, 23.04),  new Location(46.495, 23.05),
                new Location(46.495, 23.06), new Location(46.485, 23.06), new Location(46.475, 23.05), new Location(46.468, 23.10),
                new Location(46.478, 23.10), new Location(46.49, 23.114), new Location(46.49, 23.12),   new Location(46.49, 23.13),
                new Location(46.51, 23.18),  new Location(46.49, 23.20), new Location(46.485, 23.235), new Location(46.499, 23.245),
                new Location(46.499, 23.27), new Location(46.515, 23.30), new Location(46.519, 23.32), new Location(46.519, 23.32),
                new Location(46.525, 23.33), new Location(46.53, 23.35), new Location(46.55, 23.37),  new Location(46.55, 23.39),
                new Location(46.54, 23.40),  new Location(46.52, 23.44), new Location(46.526, 23.45), new Location(46.506, 23.48),
                new Location(46.496, 23.48), new Location(46.486, 23.52), new Location(46.486, 23.55), new Location(46.50, 23.58),
                new Location(46.48, 23.62), new Location(46.46, 23.61), new Location(46.45, 23.59), new Location(46.42, 23.59),
                new Location(46.42, 23.59), new Location(46.42, 23.59), new Location(46.42, 23.62), new Location(46.40, 23.66),
                new Location(46.42, 23.67), new Location(46.44, 23.67), new Location(46.46, 23.75),  new Location(46.47, 23.80),
                new Location(46.47, 23.83), new Location(46.45, 23.84), new Location(46.455, 23.89), new Location(46.45, 23.93),
                new Location(46.452, 23.933),  new Location(46.452, 23.95), new Location(46.44, 23.96),  new Location(46.44, 23.98),
                new Location(46.45, 23.985),
                
                //mures
                new Location(46.462, 23.968), new Location(46.477, 23.968), new Location(46.48, 23.97),   new Location(46.486, 23.967),
                new Location(46.489, 23.97),  new Location(46.494, 23.967), new Location(46.50, 23.967),  new Location(46.507, 23.97),
                new Location(46.515, 23.962), new Location(46.520, 23.962), new Location(46.521, 23.966), new Location(46.53, 23.975),
                new Location(46.534, 23.973), new Location(46.54, 23.986), new Location(46.544, 23.995), new Location(46.542, 24.005),
                new Location(46.55, 24.03),  new Location(46.552, 24.03), new Location(46.56, 24.04),  new Location(46.565, 24.046),
                new Location(46.572, 24.046), new Location(46.577, 24.057), new Location(46.608, 24.071), new Location(46.615, 24.03),
                new Location(46.63, 24.025), new Location(46.632, 24.03), new Location(46.644, 24.035), new Location(46.655, 24.06),
                new Location(46.659, 24.105), new Location(46.67, 24.105), new Location(46.70, 24.125),  new Location(46.715, 24.09),
                new Location(46.715, 24.085), new Location(46.74, 24.07), new Location(46.745, 24.075), new Location(46.748, 24.10),
                new Location(46.758, 24.106), new Location(46.760, 24.125), new Location(46.763, 24.135), new Location(46.765, 24.136),
                new Location(46.775, 24.136), new Location(46.777, 24.145), new Location(46.783, 24.153), new Location(46.780, 24.17),
                new Location(46.780, 24.172), new Location(46.785, 24.174), new Location(46.788, 24.176), new Location(46.79, 24.185),
                new Location(46.795, 24.190), new Location(46.805, 24.182),
                
                //bistrita
                new Location(46.805,24.19),new Location(46.75,24.30), new Location(46.76,24.39), new Location(46.78,24.42),
                new Location(46.78,24.43), new Location(46.765,24.45), new Location(46.765,24.46), new Location(46.79,24.47),
                new Location(46.80,24.46), new Location(46.83,24.465), new Location(46.86,24.54), new Location(46.90,24.53),
                new Location(46.92,24.59), new Location(46.94,24.59), new Location(46.95,24.62), new Location(46.95,24.63),
                new Location(46.91,24.66), new Location(46.90,24.72), new Location(46.93,24.73), new Location(46.93,24.72),
                new Location(46.99,24.75), new Location(47.04,24.79), new Location(47.105,24.86), new Location(47.105,24.93),
                new Location(47.12,24.97), new Location(47.11,25.03), new Location(47.14,25.06),
                
                //Suceava
                new Location(47.14,25.07), new Location(47.12,25.10), new Location(47.12,25.14), new Location(47.13,25.19),
                new Location(47.10, 25.26),

                //harghita nord->sud
                new Location(47.10, 25.26), new Location(47.09, 25.25), new Location(47.06,25.24), new Location(47.03,25.275),
                new Location(46.91,25.28), new Location(46.86,25.26), new Location(46.84,25.28), new Location(46.81,25.28),
                new Location(46.78,25.32), new Location(46.78,25.30), new Location(46.69,25.29), new Location(46.63,25.21),
                new Location(46.57,25.15), new Location(46.57,25.09), new Location(46.54,25.025), new Location(46.51,25.00),
                new Location(46.48,25.01), new Location(46.45,25.00), new Location(46.44,24.97), new Location(46.43,24.94),
                new Location(46.38,24.98), new Location(46.37,24.96), new Location(46.37,24.94), new Location(46.39,24.85),
                new Location(46.38,24.84), new Location(46.38,24.84), new Location(46.33,24.88), new Location(46.31,24.85),
                new Location(46.31,24.85), new Location(46.29,24.87), new Location(46.28,24.93), new Location(46.24,24.97),
                new Location(46.24,24.99), new Location(46.25,25.03), new Location(46.25,25.06), new Location(46.24,25.10),
                new Location(46.21,25.11), new Location(46.18,25.14),
                   
                //brasov nord->sud
                new Location(46.17,25.18), new Location(46.15,25.15), new Location(46.13,25.15), new Location(46.13,25.13),
                new Location(46.15,25.10), new Location(46.15,25.09), new Location(46.13,25.06), new Location(46.13,25.04),
                new Location(46.14,25.02), new Location(46.11,24.96), new Location(46.05,24.94), new Location(46.05,24.92),
                new Location(46.01,24.85), new Location(45.99,24.85), new Location(45.97,24.83), new Location(45.97,24.79),
                new Location(45.94,24.75), new Location(45.94,24.72), new Location(45.90,24.72), new Location(45.87,24.77),
                new Location(45.85,24.77), new Location(45.84,24.72), new Location(45.80,24.65), new Location(45.70,24.69),
                new Location(45.63,24.68), new Location(45.60,24.66), new Location(45.59, 24.65)
            };
            #endregion

            return MPTransilvaniaRegiune2;
        }
        public MapPolygon TransilvaniaRegiune3()
        {
            MPTransilvaniaRegiune3.Stroke = new SolidColorBrush(Colors.Red);
            MPTransilvaniaRegiune3.Fill = new SolidColorBrush(Colors.Gray);
            MPTransilvaniaRegiune3.StrokeThickness = 0;
            MPTransilvaniaRegiune3.Opacity = 0.6;

            #region Puncte
            MPTransilvaniaRegiune3.Locations = new LocationCollection()
            {
                new Location(46.655, 21.44), new Location(46.66, 21.48), new Location(46.66, 21.51), new Location(46.66, 21.52),
                new Location(46.64, 21.53), new Location(46.62, 21.56), new Location(46.64, 21.58), new Location(46.65, 21.58),
                new Location(46.64, 21.61), new Location(46.65, 21.64), new Location(46.67, 21.67), new Location(46.65, 21.73),
                new Location(46.66, 21.74), new Location(46.66, 21.76), new Location(46.65, 21.80), new Location(46.65, 21.80), 
                new Location(46.66, 21.85), new Location(46.67, 21.87), new Location(46.67, 21.90), new Location(46.65, 21.90),
                new Location(46.64, 21.89), new Location(46.62, 21.92), new Location(46.61, 21.98), new Location(46.62, 22.01),
                new Location(46.64, 22.03), new Location(46.66, 22.03), new Location(46.66, 22.04), new Location(46.64, 22.05),
                new Location(46.61, 22.10), new Location(46.60, 22.14), new Location(46.60, 22.17), new Location(46.57, 22.17),
                new Location(46.54, 22.17), new Location(46.54, 22.19), new Location(46.50, 22.22), new Location(46.48, 22.24),
                new Location(46.49, 22.28), new Location(46.48, 22.32), new Location(46.48, 22.32), new Location(46.48, 22.38),
                new Location(46.45, 22.38), new Location(46.43, 22.40), new Location(46.41, 22.42), new Location(46.39, 22.46),
                new Location(46.38, 22.51), new Location(46.40, 22.51), new Location(46.40, 22.60), new Location(46.39, 22.65),
                new Location(46.39, 22.69),
                 
                //alba in sus
                new Location(46.40, 22.685), new Location(46.42, 22.680), new Location(46.42, 22.676), new Location(46.43, 22.665),
                new Location(46.45, 22.685), new Location(46.46, 22.687), new Location(46.47, 22.685), new Location(46.48, 22.6794),
                new Location(46.485, 22.674), new Location(46.49, 22.672), new Location(46.495, 22.679), new Location(46.51, 22.670),
                new Location(46.515, 22.679), new Location(46.525, 22.677), new Location(46.535, 22.69), new Location(46.535, 22.697),
                new Location(46.545, 22.715), new Location(46.535, 22.715), new Location(46.535, 22.725), new Location(46.545, 22.725),
                new Location(46.555, 22.705), new Location(46.565, 22.695), new Location(46.569, 22.695), new Location(46.569, 22.695),
                new Location(46.569, 22.695), new Location(46.59, 22.74), new Location(46.58, 22.79), new Location(46.56, 22.82),
                new Location(46.54, 22.85), new Location(46.55, 22.875), new Location(46.55, 22.95), new Location(46.54, 22.98),
                new Location(46.54, 22.98), new Location(46.54, 23.03), new Location(46.50, 23.04), new Location(46.495, 23.05),
                new Location(46.495, 23.06), new Location(46.485, 23.06), new Location(46.475, 23.05), new Location(46.468, 23.10),
                new Location(46.478, 23.10), new Location(46.49, 23.114), new Location(46.49, 23.12), new Location(46.49, 23.13),
                new Location(46.51, 23.18), new Location(46.49, 23.20), new Location(46.485, 23.235), new Location(46.499, 23.245),
                new Location(46.499, 23.27), new Location(46.515, 23.30), new Location(46.519, 23.32), new Location(46.519, 23.32),
                new Location(46.525, 23.33), new Location(46.53, 23.35), new Location(46.55, 23.37), new Location(46.55, 23.39),
                new Location(46.54, 23.40), new Location(46.52, 23.44), new Location(46.526, 23.45), new Location(46.506, 23.48),
                new Location(46.496, 23.48), new Location(46.486, 23.52), new Location(46.486, 23.55), new Location(46.50, 23.58),
                new Location(46.48, 23.62), new Location(46.46, 23.61), new Location(46.45, 23.59), new Location(46.42, 23.59),
                new Location(46.42, 23.59), new Location(46.42, 23.59), new Location(46.42, 23.62), new Location(46.40, 23.66),
                new Location(46.42, 23.67), new Location(46.44, 23.67), new Location(46.46, 23.75), new Location(46.47, 23.80),
                new Location(46.47, 23.83), new Location(46.45, 23.84), new Location(46.455, 23.89), new Location(46.45, 23.93),
                new Location(46.452, 23.933), new Location(46.452, 23.95), new Location(46.44, 23.96), new Location(46.44, 23.98),
                new Location(46.45, 23.985),

                //mures
                new Location(46.462, 23.968), new Location(46.477, 23.968), new Location(46.48, 23.97), new Location(46.486, 23.967),
                new Location(46.489, 23.97), new Location(46.494, 23.967), new Location(46.50, 23.967), new Location(46.507, 23.97),
                new Location(46.515, 23.962), new Location(46.520, 23.962), new Location(46.521, 23.966), new Location(46.53, 23.975),
                new Location(46.534, 23.973), new Location(46.54, 23.986), new Location(46.544, 23.995), new Location(46.542, 24.005),
                new Location(46.55, 24.03), new Location(46.552, 24.03), new Location(46.56, 24.04), new Location(46.565, 24.046),
                new Location(46.572, 24.046), new Location(46.577, 24.057), new Location(46.608, 24.071), new Location(46.615, 24.03),
                new Location(46.63, 24.025), new Location(46.632, 24.03), new Location(46.644, 24.035), new Location(46.655, 24.06),
                new Location(46.659, 24.105), new Location(46.67, 24.105), new Location(46.70, 24.125), new Location(46.715, 24.09),
                new Location(46.715, 24.085), new Location(46.74, 24.07), new Location(46.745, 24.075), new Location(46.748, 24.10),
                new Location(46.758, 24.106), new Location(46.760, 24.125), new Location(46.763, 24.135), new Location(46.765, 24.136),
                new Location(46.775, 24.136), new Location(46.777, 24.145), new Location(46.783, 24.153), new Location(46.780, 24.17),
                new Location(46.780, 24.172), new Location(46.785, 24.174), new Location(46.788, 24.176), new Location(46.79, 24.185),
                new Location(46.795, 24.190), new Location(46.805, 24.182),
                
                //bistrita
                new Location(46.815, 24.182),new Location(46.818, 24.19), new Location(46.830, 24.19), new Location(46.836, 24.206),
                new Location(46.840, 24.206),new Location(46.849, 24.209), new Location(46.885, 24.219), new Location(46.887, 24.239),
                new Location(46.890, 24.243),new Location(46.895, 24.23), new Location(46.91, 24.224), new Location(46.91, 24.224),
                new Location(46.92, 24.20), new Location(46.93, 24.198), new Location(46.937, 24.190), new Location(46.930, 24.16),
                new Location(46.95, 24.14), new Location(46.955, 24.165), new Location(46.958, 24.165), new Location(46.96, 24.12),
                new Location(46.975, 24.12), new Location(47.00, 24.105), new Location(47.01, 24.115), new Location(47.02, 24.118),
                new Location(47.03, 24.10), new Location(47.04, 24.114), new Location(47.04, 24.114), new Location(47.06, 24.124),
                new Location(47.08, 24.134), new Location(47.09, 24.134), new Location(47.11, 24.120), new Location(47.115, 24.11),
                new Location(47.125, 24.11), new Location(47.132, 24.10), new Location(47.130, 24.05), new Location(47.14, 24.04),
                new Location(47.16, 24.04), new Location(47.18, 24.02), new Location(47.175, 24.00), new Location(47.175, 24.00),  
                new Location(47.167, 24.01), new Location(47.167, 24.00), new Location(47.175, 23.99), new Location(47.18, 23.98),  
                new Location(47.18, 23.95), new Location(47.20, 23.93), new Location(47.21, 23.94), new Location(47.22, 23.93),  
                new Location(47.23, 23.931), new Location(47.24, 23.927), new Location(47.295, 23.927), new Location(47.315, 23.937), 
                new Location(47.315, 23.947), new Location(47.298, 23.974), new Location(47.328, 24.03), new Location(47.358, 24.025),
                
                //maramures
                new Location(47.370, 24.00), new Location(47.355, 23.90), new Location(47.370, 23.889), new Location(47.370, 23.859),
                new Location(47.344, 23.835), new Location(47.344, 23.835),

                //salaj
                new Location(47.334, 23.845), new Location(47.334, 23.835), new Location(47.344, 23.810), new Location(47.344, 23.80),
                new Location(47.338, 23.79), new Location(47.33, 23.74), new Location(47.332, 23.72), new Location(47.342, 23.72),
                new Location(47.352, 23.71), new Location(47.355, 23.70), new Location(47.355, 23.69), new Location(47.375, 23.678),
                new Location(47.385, 23.648), new Location(47.385, 23.645), new Location(47.380, 23.635), new Location(47.375, 23.61),
                new Location(47.370, 23.60), new Location(47.370, 23.60), new Location(47.372, 23.585), new Location(47.367, 23.575),
                new Location(47.367, 23.560), new Location(47.372, 23.557), new Location(47.375, 23.539), new Location(47.372, 23.530),
                new Location(47.372, 23.520), new Location(47.368, 23.513), new Location(47.372, 23.496), new Location(47.379, 23.496),
                new Location(47.382, 23.48), new Location(47.380, 23.46), new Location(47.380, 23.44), new Location(47.392, 23.42),
                new Location(47.402, 23.35), new Location(47.412, 23.35), new Location(47.412, 23.34), new Location(47.410, 23.335),
                new Location(47.415, 23.323), new Location(47.425, 23.313), new Location(47.424, 23.303), new Location(47.432, 23.285),
                new Location(47.430, 23.275), new Location(47.432, 23.267), new Location(47.430, 23.264), new Location(47.430, 23.260),
                new Location(47.435, 23.243), new Location(47.439, 23.228), new Location(47.447, 23.224), new Location(47.45, 23.204),
                new Location(47.453, 23.184), new Location(47.458, 23.182), new Location(47.458, 23.180), new Location(47.448, 23.162),
                new Location(47.445, 23.16), new Location(47.443, 23.158), new Location(47.443, 23.150), new Location(47.4456, 23.140),
                new Location(47.44, 23.135), new Location(47.440, 23.12), new Location(47.430, 23.10),

                //granita satu mare
                new Location(47.425, 23.10), new Location(47.422, 23.105), new Location(47.41, 23.115), new Location(47.40, 23.110),
                new Location(47.38, 23.10), new Location(47.355, 23.06), new Location(47.355, 23.06), new Location(47.365, 23.02),
                new Location(47.365, 23.00), new Location(47.355, 22.97), new Location(47.355, 22.965), new Location(47.385, 22.940),
                new Location(47.385, 22.92), new Location(47.39, 22.92), new Location(47.405, 22.925), new Location(47.405, 22.90),
                new Location(47.420, 22.85), new Location(47.420, 22.84), new Location(47.405, 22.81), new Location(47.409, 22.77),
                new Location(47.402, 22.74), new Location(47.402, 22.71), new Location(47.375, 22.68), new Location(47.38, 22.66),
                new Location(47.35, 22.63), new Location(47.35, 22.60),

                //bihor
                new Location(47.375, 22.57), new Location(47.390, 22.57), new Location(47.40, 22.56), new Location(47.403, 22.55),
                new Location(47.403, 22.55), new Location(47.403, 22.53), new Location(47.413, 22.52), new Location(47.423, 22.52),
                new Location(47.427, 22.50), new Location(47.437, 22.48), new Location(47.437, 22.475), new Location(47.420, 22.435),
                new Location(47.420, 22.430), new Location(47.430, 22.420), new Location(47.435, 22.410), new Location(47.435, 22.40), 
                new Location(47.430, 22.36), new Location(47.433, 22.356), new Location(47.453, 22.347), new Location(47.472, 22.338), 
                new Location(47.482, 22.345), new Location(47.49, 22.345), new Location(47.505, 22.29), new Location(47.515, 22.29),
                new Location(47.515, 22.30), new Location(47.52, 22.30), new Location(47.54, 22.29), new Location(47.54, 22.26),
                new Location(47.55, 22.26), new Location(47.555, 22.265), new Location(47.56, 22.260), new Location(47.565, 22.262),
                new Location(47.567, 22.262), new Location(47.567, 22.24), new Location(47.575, 22.24), new Location(47.575, 22.235),
                new Location(47.585, 22.230), new Location(47.595, 22.225), new Location(47.60, 22.20),

                //bihor
                new Location(47.60, 22.14), new Location(47.57, 22.11), new Location(47.55, 22.08), new Location(47.55, 22.05),
                new Location(47.49, 22.01), new Location(47.42, 22.04), new Location(47.38, 22.01), new Location(47.38, 21.96),
                new Location(47.22, 21.85), new Location(47.20, 21.87), new Location(47.18, 21.87), new Location(47.19, 21.83),
                new Location(47.10, 21.80), new Location(47.11, 21.73), new Location(47.05, 21.70), new Location(47.05, 21.66),
                new Location(46.96, 21.68), new Location(46.93, 21.64), new Location(46.93, 21.61), new Location(46.88, 21.62),
                new Location(46.86, 21.60), new Location(46.84, 21.53), new Location(46.79, 21.52), new Location(46.79, 21.52),
                new Location(46.76, 21.48), new Location(46.73, 21.53), new Location(46.69, 21.50), new Location(46.69, 21.43),
                new Location(46.67, 21.43),  new Location(46.66, 21.44),
            };
            #endregion

            return MPTransilvaniaRegiune3;
        }
        public MapPolygon TransilvaniaRegiune4()
        {
            MPTransilvaniaRegiune4.Stroke = new SolidColorBrush(Colors.Red);
            MPTransilvaniaRegiune4.Fill = new SolidColorBrush(Colors.Gray);
            MPTransilvaniaRegiune4.StrokeThickness = 0;
            MPTransilvaniaRegiune4.Opacity = 0.7;

            #region Puncte
            MPTransilvaniaRegiune4.Locations = new LocationCollection()
            {
                //bistrita
                new Location(46.815, 24.182), new Location(46.818, 24.19), new Location(46.830, 24.19), new Location(46.836, 24.206),
                new Location(46.840, 24.206), new Location(46.849, 24.209), new Location(46.885, 24.219), new Location(46.887, 24.239),
                new Location(46.890, 24.243), new Location(46.895, 24.23), new Location(46.91, 24.224), new Location(46.91, 24.224),
                new Location(46.92, 24.20), new Location(46.93, 24.198), new Location(46.937, 24.190), new Location(46.930, 24.16),
                new Location(46.95, 24.14), new Location(46.955, 24.165), new Location(46.958, 24.165), new Location(46.96, 24.12),
                new Location(46.975, 24.12), new Location(47.00, 24.105), new Location(47.01, 24.115), new Location(47.02, 24.118),
                new Location(47.03, 24.10), new Location(47.04, 24.114), new Location(47.04, 24.114), new Location(47.06, 24.124),
                new Location(47.08, 24.134), new Location(47.09, 24.134), new Location(47.11, 24.120), new Location(47.115, 24.11),
                new Location(47.125, 24.11), new Location(47.132, 24.10), new Location(47.130, 24.05), new Location(47.14, 24.04),
                new Location(47.16, 24.04),  new Location(47.18, 24.02), new Location(47.175, 24.00), new Location(47.175, 24.00),  
                new Location(47.167, 24.01), new Location(47.167, 24.00), new Location(47.175, 23.99), new Location(47.18, 23.98),  
                new Location(47.18, 23.95), new Location(47.20, 23.93), new Location(47.21, 23.94), new Location(47.22, 23.93),  
                new Location(47.23, 23.931), new Location(47.24, 23.927), new Location(47.295, 23.927), new Location(47.315, 23.937), 
                new Location(47.315, 23.947), new Location(47.298, 23.974), new Location(47.328, 24.03), new Location(47.358, 24.025),

                //maramures
                new Location(47.370, 24.00),  new Location(47.355, 23.90), new Location(47.370, 23.889), new Location(47.370, 23.859),
                new Location(47.344, 23.835), new Location(47.344, 23.835),

                //salaj
                new Location(47.334, 23.845), new Location(47.334, 23.835), new Location(47.344, 23.810), new Location(47.344, 23.80),
                new Location(47.338, 23.79), new Location(47.33, 23.74), new Location(47.332, 23.72), new Location(47.342, 23.72),
                new Location(47.352, 23.71), new Location(47.355, 23.70), new Location(47.355, 23.69), new Location(47.375, 23.678),
                new Location(47.385, 23.648), new Location(47.385, 23.645), new Location(47.380, 23.635), new Location(47.375, 23.61),
                new Location(47.370, 23.60), new Location(47.370, 23.60), new Location(47.372, 23.585), new Location(47.367, 23.575),
                new Location(47.367, 23.560), new Location(47.372, 23.557), new Location(47.375, 23.539), new Location(47.372, 23.530),
                new Location(47.372, 23.520), new Location(47.368, 23.513), new Location(47.372, 23.496), new Location(47.379, 23.496),
                new Location(47.382, 23.48),  new Location(47.380, 23.46), new Location(47.380, 23.44), new Location(47.392, 23.42),
                new Location(47.402, 23.35), new Location(47.412, 23.35), new Location(47.412, 23.34), new Location(47.410, 23.335),
                new Location(47.415, 23.323), new Location(47.425, 23.313), new Location(47.424, 23.303), new Location(47.432, 23.285),
                new Location(47.430, 23.275), new Location(47.432, 23.267), new Location(47.430, 23.264), new Location(47.430, 23.260),
                new Location(47.435, 23.243), new Location(47.439, 23.228), new Location(47.447, 23.224), new Location(47.45, 23.204),
                new Location(47.453, 23.184), new Location(47.458, 23.182), new Location(47.458, 23.180), new Location(47.448, 23.162),
                new Location(47.445, 23.16), new Location(47.443, 23.158), new Location(47.443, 23.150), new Location(47.4456, 23.140),
                new Location(47.44, 23.135), new Location(47.440, 23.12), new Location(47.430, 23.10),

                //granita satu mare
                new Location(47.425, 23.10), new Location(47.422, 23.105), new Location(47.41, 23.115), new Location(47.40, 23.110),
                new Location(47.38, 23.10), new Location(47.355, 23.06), new Location(47.355, 23.06), new Location(47.365, 23.02),
                new Location(47.365, 23.00), new Location(47.355, 22.97), new Location(47.355, 22.965), new Location(47.385, 22.940),
                new Location(47.385, 22.92), new Location(47.39, 22.92), new Location(47.405, 22.925), new Location(47.405, 22.90),
                new Location(47.420, 22.85), new Location(47.420, 22.84), new Location(47.405, 22.81), new Location(47.409, 22.77),
                new Location(47.402, 22.74), new Location(47.402, 22.71), new Location(47.375, 22.68), new Location(47.38, 22.66),
                new Location(47.35, 22.63), new Location(47.35, 22.60),

                //bihor
                new Location(47.375, 22.57), new Location(47.390, 22.57), new Location(47.40, 22.56), new Location(47.403, 22.55),
                new Location(47.403, 22.55), new Location(47.403, 22.53), new Location(47.413, 22.52), new Location(47.423, 22.52),
                new Location(47.427, 22.50), new Location(47.437, 22.48), new Location(47.437, 22.475), new Location(47.420, 22.435),
                new Location(47.420, 22.430), new Location(47.430, 22.420), new Location(47.435, 22.410), new Location(47.435, 22.40), 
                new Location(47.430, 22.36), new Location(47.433, 22.356), new Location(47.453, 22.347), new Location(47.472, 22.338), 
                new Location(47.482, 22.345), new Location(47.49, 22.345), new Location(47.505, 22.29), new Location(47.515, 22.29),
                new Location(47.515, 22.30), new Location(47.52, 22.30), new Location(47.54, 22.29), new Location(47.54, 22.26),
                new Location(47.55, 22.26), new Location(47.555, 22.265), new Location(47.56, 22.260), new Location(47.565, 22.262),
                new Location(47.567, 22.262), new Location(47.567, 22.24), new Location(47.575, 22.24), new Location(47.575, 22.235),
                new Location(47.585, 22.230), new Location(47.595, 22.225), new Location(47.60, 22.20),

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
                new Location(47.74, 24.88), 

                //Suceava granita  cu transilvania
                new Location(47.645, 25.045), new Location(47.62, 24.98), new Location(47.58, 24.98), new Location(47.54, 25.04),
                new Location(47.50, 25.04), new Location(47.50, 25.08), new Location(47.48, 25.09), new Location(47.46, 25.05),
                new Location(47.43, 25.05), new Location(47.43, 25.01), new Location(47.41, 25.00), new Location(47.39, 25.06),
                new Location(47.33, 25.08), new Location(47.30, 25.04), new Location(47.27, 25.04), new Location(47.24, 25.08),
                new Location(47.20, 25.05), new Location(47.13, 25.09), 

                //bistrita
                new Location(47.14,25.06), new Location(47.11,25.03), new Location(47.12,24.97), new Location(47.105,24.93),
                new Location(47.105,24.86), new Location(47.04,24.79), new Location(46.99,24.75), new Location(46.93,24.72),
                new Location(46.93,24.73), new Location(46.90,24.72), new Location(46.91,24.66), new Location(46.95,24.63),
                new Location(46.95,24.62), new Location(46.94,24.59), new Location(46.92,24.59), new Location(46.90,24.53),
                new Location(46.86,24.54), new Location(46.83,24.465), new Location(46.80,24.46), new Location(46.79,24.47),
                new Location(46.765,24.46), new Location(46.765,24.45), new Location(46.78,24.43), new Location(46.78,24.42),
                new Location(46.76,24.39), new Location(46.75,24.30), new Location(46.805,24.19)              
            };
            #endregion

            return MPTransilvaniaRegiune4;
        }

        void MPTransilvaniaRegiune1_MouseEnter(object sender, MouseEventArgs e)
        {
            MPTransilvaniaRegiune1.StrokeThickness = 3;
        }
        void MPTransilvaniaRegiune2_MouseEnter(object sender, MouseEventArgs e)
        {
            MPTransilvaniaRegiune2.StrokeThickness = 3;
        }
        void MPTransilvaniaRegiune3_MouseEnter(object sender, MouseEventArgs e)
        {
            MPTransilvaniaRegiune3.StrokeThickness = 3;
        }
        void MPTransilvaniaRegiune4_MouseEnter(object sender, MouseEventArgs e)
        {
            MPTransilvaniaRegiune4.StrokeThickness = 3;
        }

        void MPTransilvaniaRegiune1_MouseLeave(object sender, MouseEventArgs e)
        {
            MPTransilvaniaRegiune1.StrokeThickness = 0;
        }
        void MPTransilvaniaRegiune2_MouseLeave(object sender, MouseEventArgs e)
        {
            MPTransilvaniaRegiune2.StrokeThickness = 0;
        }
        void MPTransilvaniaRegiune3_MouseLeave(object sender, MouseEventArgs e)
        {
            MPTransilvaniaRegiune3.StrokeThickness = 0;
        }
        void MPTransilvaniaRegiune4_MouseLeave(object sender, MouseEventArgs e)
        {
            MPTransilvaniaRegiune4.StrokeThickness = 0;
        }
    }
}
