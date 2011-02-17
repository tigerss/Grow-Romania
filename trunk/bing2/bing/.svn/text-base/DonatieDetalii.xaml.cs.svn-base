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

namespace bing
{
    public partial class DonatieDetalii : UserControl
    {
        public DonatieDetalii()
        {
            InitializeComponent();
        }
        public DonatieDetalii( string OcolSilvic,string Judet,string Probleme)
        {
            InitializeComponent();
            numeOcolTextBlock.Text = OcolSilvic;
            numeJudetTextBlock.Text = Judet;
            problemeTextBlock.Text = Probleme;
            double h = problemeTextBlock.ActualHeight;
            if (h > 50)
                LayoutRoot.Height += (h - 50);
        }
    }
}
