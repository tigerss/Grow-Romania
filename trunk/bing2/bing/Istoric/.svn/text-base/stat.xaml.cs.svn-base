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
        Canvas Buy;
        private bool mousepresstrades = false;
        private bool mousepressbuy = false;
        private bool mousepresssell = false;
        ControlCuColturiRotunde CBuy;
        Canvas Sell;
        ControlCuColturiRotunde CSell;
        public stat(Canvas canvas2)
        {
            ServiceReference1.TranzactiiClient wcf = new ServiceReference1.TranzactiiClient(bind, endpoint);
            wcf.PreiaDecesCompleted += new EventHandler<ServiceReference1.PreiaDecesCompletedEventArgs>(wcf_PreiaDecesCompleted);
            wcf.StatisticaAnimalCompleted += new EventHandler<ServiceReference1.StatisticaAnimalCompletedEventArgs>(wcf_StatisticaAnimalCompleted);
        
            canvas2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
            canvas2.Children.Clear();
       
            InitializeComponent();
            scrollViewer1.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            scrollViewer1.BorderThickness = new Thickness(0);
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
            #region Cbuy
            CBuy = new ControlCuColturiRotunde(canvas2, 150, 60, 162, 1, false, 1);
            CBuy.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            CBuy.AddTextBlock(new TextBlock(), "Overall", 23, 20, 10, "#FF959906");
            Buy = CBuy.intoarce();
            Buy.MouseEnter += new MouseEventHandler(Buy_MouseEnter);
            Buy.MouseLeave += new MouseEventHandler(Buy_MouseLeave);
            Buy.MouseLeftButtonDown += new MouseButtonEventHandler(Buy_MouseLeftButtonDown);
            #endregion
            #region
          
            CSell = new ControlCuColturiRotunde(canvas2, 150, 60, 314, 1, false, 1);
            CSell.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            CSell.AddTextBlock(new TextBlock(), "Statistics", 23, 20, 10, "#FF959906");
            Sell = CSell.intoarce();
            Sell.MouseEnter += new MouseEventHandler(Sell_MouseEnter);
            Sell.MouseLeave += new MouseEventHandler(Sell_MouseLeave);
            Sell.MouseLeftButtonDown += new MouseButtonEventHandler(Sell_MouseLeftButtonDown);
            #endregion
              wcf.PreiaDecesAsync(15);
              wcf.StatisticaAnimalAsync(11, 0);
                   }
        List<ServiceReference1.StatisticaAimal_Result> stat2 = new List<ServiceReference1.StatisticaAimal_Result>();
        void wcf_StatisticaAnimalCompleted(object sender, ServiceReference1.StatisticaAnimalCompletedEventArgs e)
        {
            foreach (var c in e.Result)
                stat2.Add(c);
            MessageBox.Show("SI eu am ajuns");
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

            #region ButoanDesSusNormal
            CBuy.Children.Clear();
            CBuy.AddTextBlock(new TextBlock(), "Overall", 23, 20, 10, "#FF959906");
            CBuy.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 80, 60);
            Buy.Height = 59;
            CSell.Children.Clear();
            CSell.AddTextBlock(new TextBlock(), "Statistics", 23, 20, 10, "#FF959906");
            CSell.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 80, 60);
            Sell.Height = 59;
           
            mousepresstrades = true;
            mousepressbuy = mousepresssell = false;
            #endregion
            // map.Visibility = Visibility.Collapsed;
            try
            {

              
                
            
                scrollViewer1.Content = null;
                List<string> list = new List<string>();

                for (int i = 0; i < lista2.Count; i++)
                {
                    list.Add(AI(i));
                }
                scrollViewer1.Content = new HistoryAnimal(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void MyTrades_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepresstrades == false)
            {
                Buton.Children.Clear();
                Buton.AddTextBlock(new TextBlock(), "History", 23, 20, 10, "#FF959906");
                Buton.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
                MyTrades.Height = 59;
            }
            
        }
        void MyTrades_MouseEnter(object sender, MouseEventArgs e)
        {
            Buton.Children.Clear();
            Buton.AddTextBlock(new TextBlock(), "History", 23, 20, 10, "#FFFFFFFF");
            Buton.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 162, 61);
            MyTrades.Height = 63;

        }
        void Buy_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepressbuy == false)
            {
                CBuy.Children.Clear();
                CBuy.AddTextBlock(new TextBlock(), "Overall", 23, 20, 10, "#FF959906");
                CBuy.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 150, 60);
                Buy.Height = 59;
            }
        }
        void Buy_MouseEnter(object sender, MouseEventArgs e)
        {
            CBuy.Children.Clear();
            CBuy.AddTextBlock(new TextBlock(), "Overall", 23, 20, 10, "#FFFFFFFF");
            CBuy.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 152, 61);
            Buy.Height = 63;

        }
        void Buy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            #region Aranjeaza
            mousepressbuy = true;
            mousepresssell = mousepresstrades = false;
            Buton.Children.Clear();
            Buton.AddTextBlock(new TextBlock(), "History", 23, 20, 10, "#FF959906");
            Buton.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
            MyTrades.Height = 59;
            CSell.Children.Clear();
            CSell.AddTextBlock(new TextBlock(), "Statistics", 23, 20, 10, "#FF959906");
            CSell.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 80, 60);
            Sell.Height = 59;
            #endregion
            scrollViewer1.Content = null;
            scrollViewer1.Content = new History(stat2);
        }
        void Sell_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepresssell == false)
            {
                CSell.Children.Clear();
                CSell.AddTextBlock(new TextBlock(), "Statistics", 23, 20, 10, "#FF959906");
                CSell.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 150, 60);
                Sell.Height = 59;
            }
        }
        void Sell_MouseEnter(object sender, MouseEventArgs e)
        {
            CSell.Children.Clear();
            CSell.AddTextBlock(new TextBlock(), "Statistics", 23, 20, 10, "#FFFFFFFF");
            CSell.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 152, 61);
            Sell.Height = 63;

        }
        void Sell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            #region Schimbari design
          
            //    canvas2.Children.Remove(DonationsDataGrid);
            
            mousepresssell = true;
            mousepressbuy = mousepresstrades = false;
            Buton.Children.Clear();
            Buton.AddTextBlock(new TextBlock(), "History", 23, 20, 10, "#FF959906");
            Buton.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
            MyTrades.Height = 59;
            CBuy.Children.Clear();
            CBuy.AddTextBlock(new TextBlock(), "Statistics", 23, 20, 10, "#FF959906");
            CBuy.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 80, 60);
            Buy.Height = 59;
            #endregion
           
            MyTrades.Height = 59;
        }
    }
  
}
