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
    public partial class HistoryAnimal : UserControl
    {
        public HistoryAnimal(List<string> lista)
        {
            InitializeComponent();
            List<Data> l = new List<Data>();
            foreach (string c in lista)
                l.Add(new Data() { Text = c });
            dataGrid1.ItemsSource = l;
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
     
    }
    public class Data
    {
        public string Text { get; set; }
    }
}
