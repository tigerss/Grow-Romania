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
using System.Windows.Data;
using Forme;

namespace bing
{
    public partial class StiriDesign : UserControl
    {
        ControlCuColturiRotunde Trades;
        Canvas MyTrades;
        private bool mousepresstrades = false;
        public StiriDesign(List<Stire> stire)
        {
            InitializeComponent();
            Trades = new ControlCuColturiRotunde(LayoutRoot, 160, 60, 0, 1, false, 1);
            Trades.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            Trades.AddTextBlock(new TextBlock(), "News", 23, 20, 10, "#FF959906");
            MyTrades = Trades.intoarce();
            MyTrades.MouseEnter += new MouseEventHandler(MyTrades_MouseEnter);
           MyTrades.MouseLeave += new MouseEventHandler(MyTrades_MouseLeave);
      //      MyTrades.MouseLeftButtonDown += new MouseButtonEventHandler(MyTrades_MouseLeftButtonDown);
            PagedCollectionView pages=new PagedCollectionView(stire);
            pages.PageSize = 10;
            dataGrid1.ItemsSource = pages;
            dataPager1.Source = pages;
            this.DataContext = stire;
            
        }
        void MyTrades_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepresstrades == false)
            {
                Trades.Children.Clear();
                Trades.AddTextBlock(new TextBlock(), "News", 23, 20, 10, "#FF959906");
                Trades.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
                MyTrades.Height = 59;
            }
        }
        void MyTrades_MouseEnter(object sender, MouseEventArgs e)
        {
            Trades.Children.Clear();
            Trades.AddTextBlock(new TextBlock(), "News", 23, 20, 10, "#FFFFFFFF");
            Trades.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 162, 61);
            MyTrades.Height = 63;

        }
    }
  

}
