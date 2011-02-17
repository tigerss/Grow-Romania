using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Forme;

namespace bing
{
    public partial class DonatiiDetalii : UserControl
    {
        Canvas Donatii;
        public DonatiiDetalii()
        {
            InitializeComponent();
            //butonCanvas.Children.Clear();
            //ControlCuColturiRotunde Donate = new ControlCuColturiRotunde(butonCanvas, 40, 20, 5, 8, false, 1);
            //Donate.Colors("#ff8f9305", "#ff8f9305", new Point(0.5, 1), new Point(0.5, 0), null);
            //Donate.Colturi(10, 10, new Rect(0, 0, 87, 39));
            //Donate.AddTextBlock(new TextBlock(), "+ Donate", 20, 10, 10, "#FFFFFFFF");

            ControlCuColturiRotunde canvasforbutton = new ControlCuColturiRotunde(butonCanvas, 206, 39, 0, 0, false, 1);
            canvasforbutton.Colors("#FF969a07", "#FF7a7d04", new Point(0.5, 1), new Point(0.5, 0), null);
            canvasforbutton.Border(new CornerRadius(10, 10, 10, 10), "#FF9fa13a", new Thickness(1), 208, 40);
            canvasforbutton.Colturi(10, 10, new Rect(0, 0, 206, 38));
            canvasforbutton.AddTextBlock(new TextBlock(), "Log in", 17, 90, 5, "#ffe0e1c0");
            Donatii = canvasforbutton.intoarce();

            Line L = new Line();
            Linie L1 = new Linie(1, 1, 100, 1, "#FFFFFFFF", 1, lineCanvas, L);
            lineCanvas.Children.Add(L);
           // butonCanvas.Children.Add(Donatii);
        }
    }
}
