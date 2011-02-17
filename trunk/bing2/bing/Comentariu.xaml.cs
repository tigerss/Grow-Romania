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

namespace bing
{
    public partial class Comentariu : UserControl
    {
        public Comentariu()
        {
            InitializeComponent();
        }
        public Comentariu(string text, string date, string username, string image)
        {
            InitializeComponent();

            if (image != null)
            {
                Uri uri = new Uri(image, UriKind.Relative);
                ImageSource img = new System.Windows.Media.Imaging.BitmapImage(uri);
                userImage.SetValue(Image.SourceProperty, img);
            }

            dateTextBlock.Text = date;
            userNameTextBlock.Text = username;
            commentTextBlock.Text = text;
            linieCanvas.Width = 600;   //tb sa stabilesc lungimea liniei in raport cu latimea paginii, nu in pixeli
            Line L = new Line();
            Linie L1 = new Linie(1, 1, linieCanvas.Width, 1, "#FF717577", 1, linieCanvas, L);
        }
    }
}
