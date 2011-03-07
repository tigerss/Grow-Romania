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
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace bing
{
    public partial class Upgrades : UserControl
    {
        ControlCuColturiRotunde Trades;
        Canvas MyTrades;
        private bool mousepresstrades = false;
        DispatcherTimer t = new DispatcherTimer();
        int i = 0;
        ServiceReference1.ProcedureUpgrades_Result lista;
        List<UIElement> listaElemente = new List<UIElement>();
        Canvas canvas2;
#region booleane
        bool profits=false;
        bool tree = false;
        bool power = false;
        bool bear = false;
        bool windmill = false;
        bool savetheforest = false;
        bool takeaction = false;
        bool antibugs = false;
        bool buy = false;
        bool flood = false;
        bool h2o = false;
        bool eco = false;
        bool plants = false;
        bool house = false;
        bool earth = false;
#endregion
        public Upgrades(ServiceReference1.ProcedureUpgrades_Result lista,Canvas canvas2)
        {
            AtributeGlobale.i++;
            InitializeComponent();
            this.canvas2 = canvas2;
            this.lista = lista;
            #region ifuri
            #region randul de sus
            if (lista.Profits == true)
            {
                profits = true;
                i1.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.Tree == true)
            {
                tree = true;
                i2.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.Power == true)
            {
                power = true;
                i3.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.Bear == true)
            {
                bear = true;
                i4.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.WindMill == true)
            {
                windmill = true;
                i5.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
          
            }
            #endregion
            #region randul mijlociu
            if (lista.SaveForest == true)
            {
                profits = true;
                i6.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.TakeAction == true)
            {
                takeaction = true;
                i7.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.AntiBugs == true)
            {
                antibugs = true;
                i8.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.Flood == true)
            {
                flood = true;
                i9.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.Buy == true)
            {
                buy = true;
                i10.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));

            }
            #endregion
            #region ultimul
            if (lista.H20 == true)
            {
                h2o = true;
                i11.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.Eco == true)
            {
                eco = true;
                i12.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.Plants == true)
            {
                plants = true;
                i13.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.House == true)
            {
                house = true;
                i14.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));
            }
            if (lista.Earth == true)
            {
                earth = true;
                i15.Source = new BitmapImage(new Uri("Upgrades/Analyst-Upgradesluat.jpg", UriKind.Relative));

            }
            #endregion
            #endregion
            border6.Opacity = border7.Opacity = border8.Opacity = border9.Opacity=border10.Opacity = 0;
            border11.Opacity = border12.Opacity = border13.Opacity = border14.Opacity = border15.Opacity = 0;
            sb1.Begin();
            t.Interval = new TimeSpan(0, 0, 0, 0, 10);
            t.Tick += new EventHandler(t_Tick);
            t.Start();
            sb1.Completed += new EventHandler(sb1_Completed);
            Trades = new ControlCuColturiRotunde(LayoutRoot, 160, 60, 0, 1, false, 1);
            Trades.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            Trades.AddTextBlock(new TextBlock(), "Upgrades", 23, 20, 10, "#FF959906");
            MyTrades = Trades.intoarce();
            MyTrades.MouseEnter += new MouseEventHandler(MyTrades_MouseEnter);
            MyTrades.MouseLeave += new MouseEventHandler(MyTrades_MouseLeave);
          
        }
        public void Back(List<UIElement> lista)
        {
            listaElemente = lista;

        }
        void t_Tick(object sender, EventArgs e)
        {
            if (i == 25)
                sb2.Begin();
            if (i == 50)
            { sb3.Begin(); t.Stop(); }
            i++;
        }

        void sb1_Completed(object sender, EventArgs e)
        {
            sb1.Stop();
          
        }
        void MyTrades_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepresstrades == false)
            {
                Trades.Children.Clear();
                Trades.AddTextBlock(new TextBlock(), "Upgrades", 23, 20, 10, "#FF959906");
                Trades.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
                MyTrades.Height = 59;
            }
        }
        void MyTrades_MouseEnter(object sender, MouseEventArgs e)
        {
            Trades.Children.Clear();
            Trades.AddTextBlock(new TextBlock(), "Upgrades", 23, 20, 10, "#FFFFFFFF");
            Trades.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 162, 61);
            MyTrades.Height = 63;

        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            if (((Image)sender).Name == "i1")
            {
                if (profits == false)
                {
                    DynamicTextBoxName.Visibility = Visibility.Visible;
                    DynamicTextBoxName.Text = "Upgrade your profits";
                    Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border1) - 60);
                    Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border1) - 30);
                }
            }
            else if (((Image)sender).Name == "i2")
            {
                DynamicTextBoxName.Visibility = Visibility.Visible;
                DynamicTextBoxName.Text = "Special Tree";
                Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border2) - 20);
                Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border1) - 30);
            }
            else if (((Image)sender).Name == "i3")
            {
                DynamicTextBoxName.Visibility = Visibility.Visible;
                DynamicTextBoxName.Text = "Power";
                Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border3)+5);
                Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border1) - 30);
            }
            else if (((Image)sender).Name == "i4")
            {
                DynamicTextBoxName.Visibility = Visibility.Visible;
                DynamicTextBoxName.Text = "Bear";
                Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border4)+10);
                Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border1) - 30);
            }
            else if (((Image)sender).Name == "i5")
            {
                DynamicTextBoxName.Visibility = Visibility.Visible;
                DynamicTextBoxName.Text = "WindMill";
                Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border5) -5);
                Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border1) - 30);
            }
            else if (((Image)sender).Name == "i6")
            {
                DynamicTextBoxName.Visibility = Visibility.Visible;
                DynamicTextBoxName.Text = "Save the forest";
                Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border6) - 30);
                Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border6) - 30);
            }
            else if (((Image)sender).Name == "i7")
            {
                DynamicTextBoxName.Visibility = Visibility.Visible;
                DynamicTextBoxName.Text = "Take action now";
                Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border7) - 30);
                Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border6) - 30);
            }
            else if (((Image)sender).Name == "i8")
            {
                DynamicTextBoxName.Visibility = Visibility.Visible;
                DynamicTextBoxName.Text = "AntiBugs";
                Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border8) );
                Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border6) - 30);
            }
            else if (((Image)sender).Name == "i9")
            {
                DynamicTextBoxName.Visibility = Visibility.Visible;
                DynamicTextBoxName.Text = "Flood";
                Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border9));
                Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border6) - 30);
            }
            else if (((Image)sender).Name == "i10")
            {
                DynamicTextBoxName.Visibility = Visibility.Visible;
                DynamicTextBoxName.Text = "Buy cheaper";
                Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border10)+5);
                Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border6) - 30);
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            DynamicTextBoxName.Visibility = Visibility.Collapsed;
        }

        private void image1_MouseEnter(object sender, MouseEventArgs e)
        {
            image1.Width = 30;
            image1.Height = 30;
        }

        private void image1_MouseLeave(object sender, MouseEventArgs e)
        {
            image1.Width = 25;
            image1.Height = 25;
        }

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           canvas2.Children.Clear();
     
            PlaneProjection p = (PlaneProjection)canvas2.Projection;
            if (p != null)
            {
                if (p.RotationY == 0)
                {
                    if (AtributeGlobale.i == 1)
                    {
                        p.RotationY = 180;
                        AtributeGlobale.i = 0;
                    }
                    else { p.RotationY = 0; AtributeGlobale.i--; }
                    canvas2.Projection = p;
                }
            }
            AtributeGlobale.upgrades = false;
            foreach (UIElement c in listaElemente)
            {
                canvas2.Children.Add(c);
            }
        }
    }
}
