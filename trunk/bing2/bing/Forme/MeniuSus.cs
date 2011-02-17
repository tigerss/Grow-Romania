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
using System.Windows.Media.Imaging;
using bing;

namespace Forme
{
    public class MeniuSus
    {
       private Image home;
       private Image info;
       private Image help;
       private Image contact;
       private Image donatii;
       Canvas ch;
      
        public MeniuSus(Canvas can,double ScreenWidth,Canvas canvasmijloc)
       {
          
            home = new Image();
            info = new Image();
            help = new Image();
            contact = new Image();
            donatii = new Image();
            ch = canvasmijloc;
            #region home
            ADDPoza addhouse = new ADDPoza(home,72,18,"DesignImages/buttons_03.png");
            can.Children.Add(home);
            Canvas.SetLeft(home, ScreenWidth/2+134);
            Canvas.SetTop(home, 32);
            home.MouseEnter += new MouseEventHandler(home_MouseEnter);
            home.MouseLeave += new MouseEventHandler(home_MouseLeave);
#endregion
            #region info
            addhouse = new ADDPoza(info, 56, 18, "DesignImages/buttons_05.png");
            can.Children.Add(info);
            Canvas.SetLeft(info, ScreenWidth / 2 + 205);
            Canvas.SetTop(info, 32);
            info.MouseEnter += new MouseEventHandler(info_MouseEnter);
            info.MouseLeave += new MouseEventHandler(info_MouseLeave);
            #endregion
            #region help
            addhouse = new ADDPoza(help, 62, 18, "DesignImages/buttons_07.png");
            can.Children.Add(help);
            Canvas.SetLeft(help, ScreenWidth / 2 + 260);
            Canvas.SetTop(help, 32);
            help.MouseEnter += new MouseEventHandler(help_MouseEnter);
            help.MouseLeave += new MouseEventHandler(help_MouseLeave);
            #endregion
            #region contact
            addhouse = new ADDPoza(contact, 112, 18, "DesignImages/buttons_09.png");
            can.Children.Add(contact);
            Canvas.SetLeft(contact, ScreenWidth / 2 + 320);
            Canvas.SetTop(contact, 32);
            contact.MouseEnter += new MouseEventHandler(contact_MouseEnter);
            contact.MouseLeave += new MouseEventHandler(contact_MouseLeave);
            #endregion
            #region donatii
            addhouse = new ADDPoza(donatii, 92, 18, "DesignImages/buttons_11.png");
            can.Children.Add(donatii);
            Canvas.SetLeft(donatii, ScreenWidth / 2 + 435);
            Canvas.SetTop(donatii, 32);
            donatii.MouseEnter += new MouseEventHandler(donatii_MouseEnter);
            donatii.MouseLeave += new MouseEventHandler(donatii_MouseLeave);
            donatii.MouseLeftButtonDown += new MouseButtonEventHandler(donatii_MouseLeftButtonDown);
            #endregion
            #region Nume
            TextBlock t = new TextBlock();
            t.Text = "GrowRomania";
            t.Foreground = new SolidColorBrush(Colors.White);
            t.FontSize = 22;
            can.Children.Add(t);
            Canvas.SetLeft(t, ScreenWidth / 2 - 470);
            Canvas.SetTop(t, 32);
           #endregion
       }

        #region variabile pt taburi
        Canvas MyDonations;
        ControlCuColturiRotunde Donations;
        private bool mousepressDonations = false;
        Canvas Campaigns;
        ControlCuColturiRotunde CCampaigns;
        #endregion

        void donatii_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {//ce s cu liniile astea?stai putin...e conturul ala de la pagina
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
//tu mai demult mi-ai aratat ca ai pus datagrid acolo, da dar l-am sters pai dar cum il adaugai in mijloc?
            //stai
        }

        void AfisareSubmeniuDonatii()
        {
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

             ch.Children.Clear();
             AfisareSubmeniuDonatii();
            // MessageBox.Show("ok");
            //campanii C = new campanii("sfgh");
            CampaniiPage CP = new CampaniiPage();
            CP.Width = ch.Width;
            Canvas.SetLeft(CP, 0);
            Canvas.SetTop(CP, 0);
            ch.Children.Add(CP);
            //MessageBox.Show(DP.ActualWidth.ToString() + C.ActualHeight);

        }

      

        #region Evenimente

        void MyDonations_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ch.Children.Clear();
            AfisareSubmeniuDonatii();
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


        void contact_MouseLeave(object sender, MouseEventArgs e)
        {
            contact.Source = new BitmapImage(new Uri("DesignImages/buttons_09.png", UriKind.Relative));
        }

        void contact_MouseEnter(object sender, MouseEventArgs e)
        {
            contact.Source = new BitmapImage(new Uri("DesignImages/hover_09.png", UriKind.Relative));
        }

        void help_MouseLeave(object sender, MouseEventArgs e)
        {
            help.Source = new BitmapImage(new Uri("DesignImages/buttons_07.png", UriKind.Relative));
        }

        void help_MouseEnter(object sender, MouseEventArgs e)
        {
            help.Source = new BitmapImage(new Uri("DesignImages/hover_07.png", UriKind.Relative));
        }

        void info_MouseLeave(object sender, MouseEventArgs e)
        {
            info.Source = new BitmapImage(new Uri("DesignImages/buttons_05.png", UriKind.Relative));
        }

        void info_MouseEnter(object sender, MouseEventArgs e)
        {
            info.Source = new BitmapImage(new Uri("DesignImages/hover_05.png", UriKind.Relative));
        }

        void home_MouseLeave(object sender, MouseEventArgs e)
        {
            home.Source = new BitmapImage(new Uri("DesignImages/buttons_03.png", UriKind.Relative));
           
        }

        void home_MouseEnter(object sender, MouseEventArgs e)
        {
            home.Source = new BitmapImage(new Uri("DesignImages/hover_03.png", UriKind.Relative));
        }

        void donatii_MouseLeave(object sender, MouseEventArgs e)
        {
            donatii.Source = new BitmapImage(new Uri("DesignImages/buttons_11.png", UriKind.Relative));
        }

        void donatii_MouseEnter(object sender, MouseEventArgs e)
        {
            donatii.Source = new BitmapImage(new Uri("DesignImages/hover_11.png", UriKind.Relative));
        }
        #endregion
    }
}
