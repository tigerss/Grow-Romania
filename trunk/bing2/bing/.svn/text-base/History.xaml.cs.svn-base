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
using bing.ServiceReference1;
using System.Collections.ObjectModel;

namespace bing
{
    public partial class History : UserControl
    {
        List<StatisticaAimal_Result> lista;
        
        public History(List<StatisticaAimal_Result> lista)
        {
            InitializeComponent();
            textBlock2.Text = lista[0].Nume;
            this.lista = lista;
            List<Date> d = new List<Date>();
            for (int j = 0; j < lista.Count; j++)
            {
               d.Add(new Date(){Image=lista[j].Imagine1});
            }
            ObservableCollection<Writer> Team = new ObservableCollection<Writer>();
            int i = 0;
                Team.Add(new Writer("Foc",int.Parse(lista[i].Foc.ToString())));
                Team.Add(new Writer("Flood", int.Parse(lista[i].Inundatie.ToString())));
                Team.Add(new Writer("Poach", int.Parse(lista[i].Brac.ToString())));
                Team.Add(new Writer("Eaten", int.Parse(lista[i].Mancati.ToString())));
                Team.Add(new Writer("Hunted", int.Parse(lista[i].Vanati.ToString())));
            
            MyPie.DataContext = Team;
            dataGrid1.ItemsSource = d;
         //   All.DataContext = Team;
        }

        private void ColumnSeries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<Writer> Team = new ObservableCollection<Writer>();
            int i = dataGrid1.SelectedIndex;
            Team.Add(new Writer("Foc", int.Parse(lista[i].Foc.ToString())));
            Team.Add(new Writer("Flood", int.Parse(lista[i].Inundatie.ToString())));
            Team.Add(new Writer("Poach", int.Parse(lista[i].Brac.ToString())));
            Team.Add(new Writer("Eaten", int.Parse(lista[i].Mancati.ToString())));
            Team.Add(new Writer("Hunted", int.Parse(lista[i].Vanati.ToString())));
            MyPie.DataContext = Team;
            textBlock2.Text = lista[i].Nume;
        }

        private void All_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void ColumnSeries_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void All_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void All_MouseEnter(object sender, MouseEventArgs e)
        {
            ObservableCollection<Writer> Team = new ObservableCollection<Writer>();
            int max = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                Team.Add(new Writer(lista[i].Nume, int.Parse(lista[i].Foc.ToString())));
                if (lista[i].Foc > max)
                {
                    max =(int) lista[i].Foc;
                }
            }
            
            Max x = new Max() { maxim = max+50 };
            All.DataContext = Team;
        }
    }
    public class Date
    {
        public string Image { get; set; }
     
    }
    public class Writer
    {
        public Writer() { }
        public Writer(string writerName, int numOfTypes)
        {
            Name = writerName;
            Types = numOfTypes;
        }
        public string Name { get; set; }
        public int Types { get; set; }
    }
    public class Max
    {
        public int maxim { get; set; }
    }
}
