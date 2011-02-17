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
using bing_maps.Forme;
namespace bing
{
    public partial class History : UserControl
    {
        public History()
        {
            InitializeComponent();
            List<Date> d = new List<Date>();
            int i=0;
            string[] poze = new string[] { "Game/bear.jpg", "Game/deer.jpg", "Game/boar.jpg", "Game/arici.jpg", "Game/vulpe.jpg", "Game/wolf.jpg", "Game/ras.jpg", "Game/jder.jpg", "Game/veverita.jpg" };
            foreach (string c in poze)
            {
                d.Add(new Date() { Image = poze[i], Fire = ((i + 1) * 10).ToString(),Flood=i.ToString() });
                i++;
            }
            dataGrid1.ItemsSource = d;
        }
    }
    public class Date
    {
        public string Image { get; set; }
        public string Fire { get; set; }
        public string Flood { get; set; }
    }
}
