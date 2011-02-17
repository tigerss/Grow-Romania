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
using System.Windows.Media.Imaging;
using bing_maps;
using Microsoft.Maps.MapControl;
using Regiuni;
using bing.Forme;

namespace bing
{
    public partial class PaginaUser : UserControl
    {
        Canvas canvas2;
        public PaginaUser(BusyIndicator bIndic,List<ServiceReference1.LoginFunction_Result> lista,MapLayers mymap,Canvas canvas2)
        {
            this.canvas2 = canvas2;
            InitializeComponent();
            
            #region Adresa + Nume animal
            ControlCuColturiRotunde adresscur = new ControlCuColturiRotunde(LayoutRoot, 230, 100, 0, 7, true, 1);
            adresscur.Colturi(13, 13, new Rect(0, 0, 230, 100));
            adresscur.Colors("#FFF0F8FF", "#FFF0F8FF", new Point(0.5, 1), new Point(0.5, 0), 0.3);
            //    ControlCuColturiRotunde dd = new ControlCuColturiRotunde(can, 200, 100, 200, 100, false, 1);
            Canvas wrap = new Canvas() { Margin = new Thickness(12, 12, 12, 12), Width = 210, Height = 70 };
            TextBlock tb1 = new TextBlock() { Text = "You are here: ", Margin = new Thickness(0, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            TextBlock tb2 = new TextBlock() { Text = lista[0].Regiunenume, Margin = new Thickness(tb1.ActualWidth + 1, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            TextBlock tb3 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb1.ActualWidth + tb2.ActualWidth + 2, 1, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            TextBlock tb4 = new TextBlock() { Text = "subregiune", Margin = new Thickness(tb1.ActualWidth + tb2.ActualWidth + tb3.ActualWidth + 3, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            if (tb4.Margin.Left + tb4.ActualWidth > 210)//trecere urm rand
                tb4.Margin = new Thickness(15, 18, 0, 0);
            TextBlock tb5 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb4.Margin.Left != 0 ? tb4.ActualWidth + 16 : 15, 18, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            if (tb4.Margin.Left != 15)
                tb5.Margin = new Thickness(15, 18, 0, 0);
            TextBlock tb6 = new TextBlock() { Text = "Padure", Margin = new Thickness(tb5.Margin.Left + tb5.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            TextBlock tb7 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb6.Margin.Left + tb6.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            TextBlock tb8 = new TextBlock() { Text = "Animale", Margin = new Thickness(tb7.Margin.Left + tb7.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            wrap.Children.Add(tb1); wrap.Children.Add(tb2); wrap.Children.Add(tb3); wrap.Children.Add(tb4); wrap.Children.Add(tb5); wrap.Children.Add(tb6); wrap.Children.Add(tb7); wrap.Children.Add(tb8);
            LayoutRoot.Children.Add(wrap);

            TextBlock tb9 = new TextBlock() { Text = "Welcome,", Margin = new Thickness(12, 48, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black) };
            TextBlock tb10 = new TextBlock() { Text = lista[0].Nume, Margin = new Thickness(12, 58, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 23, Foreground = new SolidColorBrush(Colors.Black) };
            LayoutRoot.Children.Add(tb9);
            LayoutRoot.Children.Add(tb10);
            #endregion
            ImageSourceConverter c = new ImageSourceConverter();
            image1.Source = (ImageSource)c.ConvertFromString("Game/deer.jpg");
            Donatii.Text = lista[0].NrDonatii.ToString() + " Donations";
            Banidonati.Text = lista[0].BaniDonati.ToString() + " RON donated";
            Rank.Text = "Rank: "+lista[0].Rank.ToString();
            Scor.Text = "Scor: " + lista[0].Scor;
            //mymap.lol();
           
           
          
            
            bIndic.IsBusy = false;
        }
        #region MOUSE ENTER MOUSE  MOVE
        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("dfsd");
        }

        private void Achivments_MouseEnter(object sender, MouseEventArgs e)
        {
            Achivments.Opacity = 0.9;
        }

        private void Achivments_MouseLeave(object sender, MouseEventArgs e)
        {
            Achivments.Opacity =1;
        }

        private void Challanges_MouseEnter(object sender, MouseEventArgs e)
        {
            Challanges.Opacity = 0.9;
        }

        private void Challanges_MouseLeave(object sender, MouseEventArgs e)
        {
            Challanges.Opacity = 1;
        }

        private void Upgrades_MouseEnter(object sender, MouseEventArgs e)
        {
            Upgrades.Opacity = 0.9;
        }

        private void Upgrades_MouseLeave(object sender, MouseEventArgs e)
        {
            Upgrades.Opacity = 1;
        }

        private void Achivments_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RankingSystem ranking = new RankingSystem();
            ranking.get_AchievementsFromDB();
            canvas2.Children.Clear();
            canvas2.Children.Add(ranking);
        }

        #endregion
    }
}
