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
    public partial class AddCommentControl : UserControl
    {
        Canvas camp;
        int tip;
        public AddCommentControl()
        {
            InitializeComponent();
            ControlCuColturiRotunde canvasforbutton = new ControlCuColturiRotunde(butonCanvas, 70, 34, 0, 0, false, 1);
            canvasforbutton.Colors("#FF969a07", "#FF7a7d04", new Point(0.5, 1), new Point(0.5, 0), null);
            //canvasforbutton.Border(new CornerRadius(10, 10, 10, 10), "#FF9fa13a", new Thickness(1), 70, 35);
            canvasforbutton.Colturi(10, 10, new Rect(0, 0, 70, 33));
            canvasforbutton.AddTextBlock(new TextBlock(), "Add reply", 14, 0, 5, "#ffffffff");
            camp = canvasforbutton.intoarce();
            camp.MouseLeftButtonDown += new MouseButtonEventHandler(camp_MouseLeftButtonDown);
        }

        public AddCommentControl(string image,int Tip)
        {
            InitializeComponent();
            ControlCuColturiRotunde canvasforbutton = new ControlCuColturiRotunde(butonCanvas, 70, 34, 0, 0, false, 1);
            canvasforbutton.Colors("#FF969a07", "#FF7a7d04", new Point(0.5, 1), new Point(0.5, 0), null);
            //canvasforbutton.Border(new CornerRadius(10, 10, 10, 10), "#FF9fa13a", new Thickness(1), 70, 35);
            canvasforbutton.Colturi(10, 10, new Rect(0, 0, 70, 33));
            canvasforbutton.AddTextBlock(new TextBlock(), "Add reply", 14, 0, 5, "#ffffffff");
            camp = canvasforbutton.intoarce();
            camp.MouseLeftButtonDown += new MouseButtonEventHandler(camp_MouseLeftButtonDown);
            if (image != null)
            {
                Uri uri = new Uri(image, UriKind.Relative);
                ImageSource img = new System.Windows.Media.Imaging.BitmapImage(uri);
                userImage.SetValue(Image.SourceProperty, img);
            }
            tip = Tip;
        }
        void camp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ServiceReference2.CampaignsClient service = new ServiceReference2.CampaignsClient();
            if (tip == 1)
            {
                service.InsertCommentAsync(commentTextBox.Text, Int32.Parse(idCampanieTextBlock.Text), 2);//tb sa inlocuiesc cu id-ul user-ului logat acum
                service.InsertCommentCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(service_InsertCommentCompleted);
                //    succesTextBlock.Visibility = Visibility.Visible; //tb sa pun vreun text
                commentTextBox.Text = "";
            }
            else
            {
                service.InsertCommentDonationsAsync(commentTextBox.Text,Int32.Parse(idCampanieTextBlock.Text),11);
                service.InsertCommentDonationsCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(service_InsertCommentDonationsCompleted);
                commentTextBox.Text = "";
            }
        }

        void service_InsertCommentDonationsCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
        }

        void service_InsertCommentCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

        }
       
    }
}
