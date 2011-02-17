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
using bing_maps.Forme;

namespace bing
{
    public partial class UnitTranzactii : UserControl
    {
        public int ID;
        public bool BuySell;
        public UnitTranzactii()
        {
            InitializeComponent();
        }
        public UnitTranzactii(string _NumeAnimal, string _Regiune,string _Username, string _Airline, short _Quantity, float _Price,int id,bool BuySell)
        {
            InitializeComponent();
            NumeAnimal.Text = _NumeAnimal;
            Regiune.Text = _Regiune;
            Username.Text = _Username;
            Airline.Text = _Airline;
            Quantity.Text = _Quantity.ToString();
            Price.Text = _Price.ToString();
            ID = id;
            this.BuySell = BuySell;
            if (BuySell == true) buy.Text = "Buy";
            else buy.Text = "Sell";
            Regiune.Margin = new Thickness(textBlock1.Margin.Left + textBlock1.ActualWidth + 5, 33, 0, 0);
            textBlock2.Margin = new Thickness(Regiune.Margin.Left + Regiune.ActualWidth +10, 33, 0, 0);
            Username.Margin = new Thickness(textBlock2.Margin.Left + textBlock2.ActualWidth + 5, 33, 0, 0);
            textBlock3.Margin = new Thickness(Username.Margin.Left + Username.ActualWidth + 10, 33, 0, 0);
            Airline.Margin = new Thickness(textBlock3.Margin.Left + textBlock3.ActualWidth + 5, 33, 0, 0);
            buy.MouseEnter += new MouseEventHandler(buy_MouseEnter);
            buy.MouseLeave += new MouseEventHandler(buy_MouseLeave);
            buy.MouseLeftButtonDown += new MouseButtonEventHandler(buy_MouseLeftButtonDown);
        }

        void buy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {



            if (BuySell == true)
            {
                var a = MessageBox.Show("Do you want to buy it?", "Buy", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    TranzactiiClient tc = new TranzactiiClient();
                    tc.AddCumparareAsync(Username.Text, "test", NumeAnimal.Text, "bla", int.Parse(Price.Text), short.Parse(Quantity.Text), ID);
                    tc.AddCumparareCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(tc_AddCumparareCompleted);
                }
            }
               

            else
            {
                var a = MessageBox.Show("Do you want to sell it?", "Sell", MessageBoxButton.OKCancel);
                if (a == MessageBoxResult.OK)
                {
                    TranzactiiClient tc = new TranzactiiClient();
                    tc.AddCumparareAsync("test", Username.Text, NumeAnimal.Text, "bla", int.Parse(Price.Text), short.Parse(Quantity.Text), ID);
                    tc.AddCumparareCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(tc_AddCumparareCompleted);
                }
            }
            
        }
        void tc_AddCumparareCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
        }
        void buy_MouseLeave(object sender, MouseEventArgs e)
        {
            buy.Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0x8b, 0x92, 0x05));
        }

        void buy_MouseEnter(object sender, MouseEventArgs e)
        {
            buy.Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0xd0, 0xda, 0x08));
        }
    }
}
