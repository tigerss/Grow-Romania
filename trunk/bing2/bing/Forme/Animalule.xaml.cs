﻿using System;
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
using bing;
using System.Windows.Media.Imaging;


namespace bing.Forme
{
    public partial class Animalule : UserControl
    {
        static TextBlock tb6 = new TextBlock();
        static string region;

        public Animalule()
        {
            InitializeComponent();
           // Imagine1.Source = new BitmapImage(new Uri("Game/bear.jpg", UriKind.Relative));
        }
        public void Aranjeaza()
        {
            #region Adresa + Nume animal
            ControlCuColturiRotunde adresscur = new ControlCuColturiRotunde(can, 230, 74, 0, 7, true, 1);
            adresscur.Colturi(13, 13, new Rect(0, 0, 230, 74));
            adresscur.Colors("#FFF0F8FF", "#FFF0F8FF", new Point(0.5, 1), new Point(0.5, 0), 0.3);

            Canvas wrap = new Canvas() { Margin = new Thickness(12, 12, 12, 12), Width = 210, Height = 60 };
            TextBlock tb1 = new TextBlock() { Text = "You are here: ", Margin = new Thickness(0, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            TextBlock tb2 = new TextBlock() { Text = "dsfs", Margin = new Thickness(tb1.ActualWidth + 1, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            TextBlock tb3 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb1.ActualWidth + tb2.ActualWidth + 2, 1, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            TextBlock tb4 = new TextBlock() { Text = "sfsdfsd", Margin = new Thickness(tb1.ActualWidth + tb2.ActualWidth + tb3.ActualWidth + 3, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            if (tb4.Margin.Left + tb4.ActualWidth > 210)//trecere urm rand
                tb4.Margin = new Thickness(15, 18, 0, 0);
            TextBlock tb5 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb4.Margin.Left != 0 ? tb4.ActualWidth + 16 : 15, 18, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            if (tb4.Margin.Left != 15)
                tb5.Margin = new Thickness(15, 18, 0, 0);
            tb6 = new TextBlock() { Text = region, Margin = new Thickness(tb5.Margin.Left + tb5.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            TextBlock tb7 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb6.Margin.Left + tb6.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            TextBlock tb8 = new TextBlock() { Text = "Animale", Margin = new Thickness(tb7.Margin.Left + tb7.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            wrap.Children.Add(tb1); wrap.Children.Add(tb2); wrap.Children.Add(tb3); wrap.Children.Add(tb4); wrap.Children.Add(tb5); wrap.Children.Add(tb6); wrap.Children.Add(tb7); wrap.Children.Add(tb8);
            can.Children.Add(wrap);
            #endregion
        }

        static public void setRegion(String regiune)
        {
            region = regiune;
            tb6.Text = region;
        }

        static public String getRegion()
        {
            return region;
        }
    }
}
