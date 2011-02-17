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

namespace bing.Forme
{
    public partial class LoadingBar : UserControl
    {
        public LoadingBar()
        {
            InitializeComponent();
        }

        public LoadingBar(Canvas canvas, int value, double left, double top)
        {
            InitializeComponent();

            Canvas.SetLeft((FrameworkElement)canvas1.Parent, left);
            Canvas.SetTop((FrameworkElement)canvas1.Parent, top);

            Rectangle.Width = (value * 147) / 100;
            textBlock1.Text = ""+value+"%";

            canvas.Children.Add((FrameworkElement)canvas1.Parent);
        }
    }
}
