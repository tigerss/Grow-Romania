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
using System.ServiceModel;
using bing.testService;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;

namespace bing
{
    public partial class Challenges : UserControl
    {
        DispatcherTimer t = new DispatcherTimer();
        int i = 0;

        static BasicHttpBinding bind = new BasicHttpBinding();
        static EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Service1.svc");
        bing.testService.Service1Client wcf = new bing.testService.Service1Client(bind, endpoint);
        List<getChallenges_Result> challengesList = new List<getChallenges_Result>();

        public Challenges()
        {
            InitializeComponent();

            border6.Opacity = border7.Opacity = border8.Opacity = border9.Opacity=border10.Opacity = 0;
            border11.Opacity = border12.Opacity = border13.Opacity = border14.Opacity = border15.Opacity = 0;
            LayoutRoot.Children.Clear();

            get_ChallengesFromDB();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            if (((Image)sender).Name == "i1")
            {
                DynamicTextBoxName.Visibility = Visibility.Visible;
                DynamicTextBoxName.Text = "Upgrade your profits";
                Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border1) - 60);
                Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border1) - 30);
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
                DynamicTextBoxName.Text = "Flood";
                Canvas.SetLeft(DynamicTextBoxName, Canvas.GetLeft(border9));
                Canvas.SetTop(DynamicTextBoxName, Canvas.GetTop(border6) - 30);
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            DynamicTextBoxName.Visibility = Visibility.Collapsed;
        }

        public void updateChallenges()
        {
            wcf.updateChallengeCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(wcf_updateChallengeCompleted);
            try
            {
                wcf.updateChallengeAsync(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void wcf_updateChallengeCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            get_ChallengesFromDB();
        }

        /// <summary>
        /// Get challenges from database
        /// </summary>
        public void get_ChallengesFromDB()
        {
            wcf.getChallengesFromDBCompleted += new EventHandler<testService.getChallengesFromDBCompletedEventArgs>(wcf_getChallengesFromDBCompleted);
            try
            {
                wcf.getChallengesFromDBAsync(11);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// Call showImages() after the Challenges are received from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wcf_getChallengesFromDBCompleted(object sender, testService.getChallengesFromDBCompletedEventArgs e)
        {
            #region Build Challenges List
            foreach (var a in e.Result)
            {
                challengesList.Add(a);
            }
            #endregion

            showImages();
        }

        /// <summary>
        /// Afiseaza challenge-urile
        /// </summary>
        void showImages()
        {
            int startLeft = 70;
            int startTop = 50;
            int iDistanceX = 130;
            int iDistanceY = 100;
            int left = startLeft;
            int top = startTop;
            
            // Max number of challenges per Row
            int challengesPerRow = 5;
            int maxPerRow = startLeft + challengesPerRow * iDistanceX;
            //-------  

            foreach (getChallenges_Result challenge in challengesList)
            {
                if (challenge.isCompleted == null)
                    challenge.isCompleted = false;
                newImage(challenge.Imagine1, left, top, (bool)challenge.isCompleted);
                left += iDistanceX;

                // Trec pe randul urmator
                if (left >= maxPerRow )
                {
                    left = startLeft;
                    top += iDistanceY;
                }
            }
        }

        /// <summary>
        /// Seteaza Challenge-ul
        /// </summary>
        /// <param name="path"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="isCompleted"></param>
        void newImage(string path, int left, int top, bool isCompleted)
        {
            double opacity;
            if (isCompleted)
            {
                opacity = 1d;
            }
            else
            {
                opacity = 0.3d;
            }
            Image img = new Image() { Source = new BitmapImage(new Uri(path, UriKind.Relative)), Width = 50, Height = 50, Margin = new Thickness(left, top, 0, 0), Opacity = opacity };
            img.MouseEnter += new MouseEventHandler(img_MouseEnter);
            img.MouseLeave += new MouseEventHandler(img_MouseLeave);
            img.MouseLeftButtonUp += new MouseButtonEventHandler(img_MouseLeftButtonUp);
            LayoutRoot.Children.Add(img);
        }

        /// <summary>
        /// Afiseaza descrierea Challenge-ului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void img_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Get the original URI string
            BitmapImage bi = (BitmapImage)((Image)sender).Source;
            Uri uri = bi.UriSource;
            string path = uri.OriginalString;

            // Find the challenge where the image URI equals the database URI
            foreach (getChallenges_Result challenge in challengesList)
            {
                if (challenge.Imagine1 == path)
                {
                    Popup popup = new Popup();
                    ExtendedDescription moreInfo = new ExtendedDescription(popup, challenge.Nume, challenge.Descriere);
                    popup.Child = moreInfo;
                    popup.VerticalOffset = 25;
                    popup.HorizontalOffset = 150;
                    popup.IsOpen = true;
                    LayoutRoot.Children.Add(popup);
                    break;
                }
            }

        }

        void img_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = (Image)sender;

            if (img.Opacity < 1)
                img.Opacity = 0.3d;
        }

        void img_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = (Image)sender;

            if (img.Opacity < 1)
                img.Opacity = 0.8d;
        }
    }
}
