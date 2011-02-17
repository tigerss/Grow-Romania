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
using bing.testService;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;

namespace bing
{
    public partial class ExtendedDescription : UserControl
    {
        Popup popup;
        List<getAnimalStats_Result> list;

        public ExtendedDescription(Popup popup, List<getAnimalStats_Result> lista)
        {
            InitializeComponent();
            list = lista;
            this.popup = popup;

            showFields();
            loadData();
            //loadImages();
        }

        private void showFields()
        {
            Border border = new Border()
            {
                Opacity = 1,
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                BorderThickness = new Thickness((double)3),
                CornerRadius = new CornerRadius(10),
                Width = 472,
                Height = 336,
                Margin = new Thickness(0,8,170,0),
            };
            border.SetValue(Canvas.LeftProperty,(double)-3);
            border.SetValue(Canvas.TopProperty, (double)-11);
            canvas1.Children.Add(border);
            canvas1.Background = new SolidColorBrush(Colors.Black);
            textBlock1.FontFamily = new FontFamily("Tahoma");
            textBlock1.Foreground = new SolidColorBrush(Colors.White);
            textBlock2.FontFamily = new FontFamily("Tahoma");
            textBlock2.Foreground = new SolidColorBrush(Colors.White);
            textBlock3.FontFamily = new FontFamily("Tahoma");
            textBlock3.Foreground = new SolidColorBrush(Colors.White);
            textBlock4.FontFamily = new FontFamily("Tahoma");
            textBlock4.Foreground = new SolidColorBrush(Color.FromArgb(255, 139, 146, 5));
            textBlock4.Cursor = Cursors.Hand;
            textBlock4.MouseLeftButtonDown += new MouseButtonEventHandler(textBlock4_MouseLeftButtonDown);
            textBlock4.MouseEnter += new MouseEventHandler(textBlock4_MouseEnter);
            textBlock4.MouseLeave += new MouseEventHandler(textBlock4_MouseLeave);
        }

        void textBlock4_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Foreground = new SolidColorBrush(Color.FromArgb(255, 139, 146, 5));
        }

        void textBlock4_MouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Foreground = new SolidColorBrush(Color.FromArgb(255, 208, 218, 8));
        }

        void textBlock4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            closePopup();
        }

        // Afisez datele animalului
        private void loadData()
        {
            textBlock1.Text = list[0].Nume;
            textBlock3.Text = list[0].Descriere;
        }

        //private void loadImages()
        //{
        //    if (list[0].Imagine1 != null)
        //    {
        //        image1.Source = new BitmapImage(new Uri(list[0].Imagine1, UriKind.Relative));
        //    }
        //    if (list[0].Imagine2 != null)
        //    {
        //        image2.Source = new BitmapImage(new Uri(list[0].Imagine2, UriKind.Relative));
        //    }
        //    if (list[0].Imagine3 != null)
        //    {
        //        image3.Source = new BitmapImage(new Uri(list[0].Imagine3, UriKind.Relative));
        //    }
        //}

        private void closePopup()
        {
            popup.IsOpen = false;
        }
    }
}
