using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Forme;

namespace bing.Forme
{
    public class ApasaDonatii
    {
        Canvas ch;
        #region variabile pt taburi
        Canvas MyDonations;
        ControlCuColturiRotunde Donations;
        private bool mousepressDonations = false;
        Canvas Campaigns;
        ControlCuColturiRotunde CCampaigns;
        #endregion
        public ApasaDonatii(Canvas canvas)
        {

            ch = canvas;
            ch.Children.Clear();
            Line l1 = new Line();
            Line l2 = new Line();
            Line l3 = new Line();
            Line l4 = new Line();
            //  double lung = ch.MaxHeight;
            // MessageBox.Show(lung.ToString());
            Linie lsus = new Linie(0, 0, ch.Width, 0, "#FF8b8e8f", 2.5, ch, l1);
            Linie lstanga = new Linie(0, 0, 0, ch.Height, "#FF8b8e8f", 2.5, ch, l2);
            Linie ljos = new Linie(0, ch.Height, ch.Width, ch.Height, "#FF8b8e8f", 2.5, ch, l3);
            Linie ldreapta = new Linie(ch.Width, 0, ch.Width, ch.Height, "#FF8b8e8f", 2.5, ch, l4);

            ControlCuColturiRotunde sus = new ControlCuColturiRotunde(ch, ch.Width - 2, 60, 0, 0, false, 1);
            sus.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            sus.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), ch.Width, 62);

            #region Donations
            Donations = new ControlCuColturiRotunde(ch, 190, 60, 0, 1, false, 1);
            Donations.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            Donations.AddTextBlock(new TextBlock(), "My Donations", 23, 20, 10, "#FF959906");
            MyDonations = Donations.intoarce();
            MyDonations.MouseEnter += new MouseEventHandler(MyDonations_MouseEnter);
            MyDonations.MouseLeave += new MouseEventHandler(MyDonations_MouseLeave);
            MyDonations.MouseLeftButtonDown += new MouseButtonEventHandler(MyDonations_MouseLeftButtonDown);
            #endregion

            #region CCampaigns
            CCampaigns = new ControlCuColturiRotunde(ch, 240, 60, 192, 1, false, 1);
            CCampaigns.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            CCampaigns.AddTextBlock(new TextBlock(), "Active Campaigns", 23, 20, 10, "#FF959906");
            Campaigns = CCampaigns.intoarce();
            Campaigns.MouseEnter += new MouseEventHandler(Campaigns_MouseEnter);
            Campaigns.MouseLeave += new MouseEventHandler(Campaigns_MouseLeave);
            Campaigns.MouseLeftButtonDown += new MouseButtonEventHandler(Campaigns_MouseLeftButtonDown);
            #endregion
        }
        void Campaigns_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        //aici?ce?undei butonul de donatii?

            // ch.Children.Clear();
            // MessageBox.Show("ok");
            //campanii C = new campanii("sfgh");
            CampaniiPage CP = new CampaniiPage();
            CP.Width = ch.Width;
            Canvas.SetLeft(CP, 0);
            Canvas.SetTop(CP, 0);
            ch.Children.Add(CP);
            //MessageBox.Show(DP.ActualWidth.ToString() + C.ActualHeight);

        }
        void MyDonations_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // ch.Children.Clear();
            DonatiiPage DP = new DonatiiPage();
            DP.Width = ch.Width;
            Canvas.SetLeft(DP, 0);
            Canvas.SetTop(DP, 0);
            ch.Children.Add(DP);
        }
        void Campaigns_MouseLeave(object sender, MouseEventArgs e)
        {
            CCampaigns.Children.Clear();
            CCampaigns.AddTextBlock(new TextBlock(), "Active Campaigns", 23, 20, 10, "#FF959906");
            CCampaigns.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 240, 60);
            Campaigns.Height = 59;
        }
        void Campaigns_MouseEnter(object sender, MouseEventArgs e)
        {
            CCampaigns.Children.Clear();
            CCampaigns.AddTextBlock(new TextBlock(), "Active Campaigns", 23, 20, 10, "#FFFFFFFF");
            CCampaigns.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 242, 61);
            Campaigns.Height = 63;
        }
        void MyDonations_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepressDonations == false)
            {
                Donations.Children.Clear();
                Donations.AddTextBlock(new TextBlock(), "My Donations", 23, 20, 10, "#FF959906");
                Donations.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 190, 60);
                MyDonations.Height = 59;
            }
        }
        void MyDonations_MouseEnter(object sender, MouseEventArgs e)
        {
            Donations.Children.Clear();
            Donations.AddTextBlock(new TextBlock(), "My Donations", 23, 20, 10, "#FFFFFFFF");
            Donations.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 192, 61);
            MyDonations.Height = 63;
        }
    }
}
