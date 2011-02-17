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
using System.Windows.Navigation;
using bing.ServiceReference2;

namespace bing
{
    public partial class DonatiiPage : Page
    {
        int id=2;//este id-ul userului logat!!!!!!
        
        public DonatiiPage()
        {
            InitializeComponent();
            donatiiStackPanel.Children.Clear();
            ServiceReference2.CampaignsClient service = new ServiceReference2.CampaignsClient();
            service.SelectDonationsByUserIdAsync(id);
            service.SelectDonationsByUserIdCompleted += new EventHandler<ServiceReference2.SelectDonationsByUserIdCompletedEventArgs>(service_SelectDonationsByUserIdCompleted);
        }

        void service_SelectDonationsByUserIdCompleted(object sender, ServiceReference2.SelectDonationsByUserIdCompletedEventArgs e)
        {
            foreach (DonatiiDetalii donatiaMea in e.Result)
            {
                Donatie don = new Donatie(donatiaMea.Data.ToString(), donatiaMea.NumeCampanie, (float)donatiaMea.SumaBani,donatiaMea.Probleme,donatiaMea.numeJudet,donatiaMea.numeOcol,donatiaMea.DonationId);
                mainStackPanel.Children.Add(don);
            }
        }


        

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
