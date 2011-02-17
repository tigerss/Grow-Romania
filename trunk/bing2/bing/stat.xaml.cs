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
using System.ServiceModel;
using System.Threading;

namespace bing
{
    public partial class stat : UserControl
    {
        ControlCuColturiRotunde Buton;
        Canvas MyTrades;
        BasicHttpBinding bind = new BasicHttpBinding();
        EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Tranzactii.svc");
        Canvas canvas2;
      
        public stat(Canvas canvas2)
        {
            canvas2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
            canvas2.Children.Clear();
       
            InitializeComponent();
            this.canvas2 = canvas2;
            ControlCuColturiRotunde sus = new ControlCuColturiRotunde(canvas2, canvas2.Width - 2, 60, 0, 0, false, 1);
            sus.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            sus.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), canvas2.Width, 62);
            #region Trades
            Buton = new ControlCuColturiRotunde(canvas2, 160, 60, 0, 1, false, 1);
            Buton.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            Buton.AddTextBlock(new TextBlock(), "History", 23, 20, 10, "#FF959906");
            MyTrades = Buton.intoarce();
            MyTrades.MouseEnter += new MouseEventHandler(MyTrades_MouseEnter);
            MyTrades.MouseLeave += new MouseEventHandler(MyTrades_MouseLeave);
            MyTrades.MouseLeftButtonDown += new MouseButtonEventHandler(MyTrades_MouseLeftButtonDown);
            #endregion
            ServiceReference1.TranzactiiClient wcf = new ServiceReference1.TranzactiiClient(bind, endpoint);

            wcf.PreiaDecesAsync(15);
            wcf.PreiaDecesCompleted += new EventHandler<ServiceReference1.PreiaDecesCompletedEventArgs>(wcf_PreiaDecesCompleted);
            Thread.Sleep(new TimeSpan(0, 0, 0, 5));
                 }
        List<ServiceReference1.ProceduraDeces_Result1> lista2;
        void wcf_PreiaDecesCompleted(object sender, ServiceReference1.PreiaDecesCompletedEventArgs e)
        {
            lista2 = new List<ServiceReference1.ProceduraDeces_Result1>();
            foreach (var c in e.Result)
                lista2.Add(c);
            MessageBox.Show("am ajuns");
        }

        string AI(int i)
        {
            string c="";
            if (lista2[i].Numar.ToString() != "0")
            {
                c = lista2[i].Numar.ToString();
                if (lista2[i].Inundatie==true)
                {
                    c = c+" de "+lista2[i].Nume + " s-au inecat in Inundatie";
                }
                else
                    if (lista2[i].Vanat==true)
                    {
                        c = c + " au fost vanate";
                    }
                    else if (lista2[i].Foc==true)
                    {
                        c = c + " au murit in foc";
                    }
                    else if (lista2[i].Braconaj==true)
                    {
                        c = c + " au fost braconate";
                    }
                    else if (lista2[i].Mancat==true)
                    {
                        c = c + " au fost mancate";
                    }
            }
            else
                c = lista2[i].Description;

            return c;
        }
        void MyTrades_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
              
            

           // map.Visibility = Visibility.Collapsed;
            try
            {

              
                
                List<Data> l = new List<Data>();
                for (int i = 0; i < lista2.Count; i++)
                {
                    l.Add(new Data(){Text=AI(i)});
                }
                dataGrid1.ItemsSource = l;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void MyTrades_MouseLeave(object sender, MouseEventArgs e)
        {

            Buton.Children.Clear();
            Buton.AddTextBlock(new TextBlock(), "History", 23, 20, 10, "#FF959906");
            Buton.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
                MyTrades.Height = 59;
            
        }
        void MyTrades_MouseEnter(object sender, MouseEventArgs e)
        {
            Buton.Children.Clear();
            Buton.AddTextBlock(new TextBlock(), "History", 23, 20, 10, "#FFFFFFFF");
            Buton.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 162, 61);
            MyTrades.Height = 63;

        }
    }
    public  class Data
    {
        public  string Text { get; set; }
    }
}
