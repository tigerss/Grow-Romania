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
using bing.testService;

namespace bing
{
    public partial class CampaniiPage : Page
    {
        public CampaniiPage()
        {
            InitializeComponent();
            ServiceReference2.CampaignsClient service = new ServiceReference2.CampaignsClient();
            service.SelectCampaignsAsync();
            donatiiStackPanel.Children.Clear();
            service.SelectCampaignsCompleted += new EventHandler<ServiceReference2.SelectCampaignsCompletedEventArgs>(sevice_SelectCampaignsCompleted);
            //service.SelectCampanieByIdAsync(1);
            //service.SelectCampanieByIdCompleted += new EventHandler<SelectCampanieByIdCompletedEventArgs>(service_SelectCampanieByIdCompleted);
        }

        //void service_SelectCampanieByIdCompleted(object sender, SelectCampanieByIdCompletedEventArgs e)
        //{
        //    Campanie C = e.Result;
        //    MessageBox.Show(C.dateIncaput);
        //}

        void sevice_SelectCampaignsCompleted(object sender, ServiceReference2.SelectCampaignsCompletedEventArgs e)
        {
            
            List<bing.ServiceReference2.Real> Camp = e.Result.ToList<bing.ServiceReference2.Real>();
            for (int i = 0; i < Camp.Count; i++)
            {
                String[] Foto= new String[10];
                int j = 0;
                for (int k = 0; k < 10; k++)
                {
                    switch (i)
                    {
                        case 0:
                                Foto[j++] = Camp[i].Imag1;break;
                        case 1:
                                Foto[j++] = Camp[i].Imag2;break;
                        case 2:
                                Foto[j++] = Camp[i].Imag3;break;
                        case 3:
                                Foto[j++] = Camp[i].Imag4;break;
                        case 4:
                                Foto[j++] = Camp[i].Imag5;break;
                        case 5:
                                Foto[j++] = Camp[i].Imag6;break;
                        case 6:
                                Foto[j++] = Camp[i].Imag7;break;
                        case 7:
                                Foto[j++] = Camp[i].Imag8;break;
                        case 8:
                                Foto[j++] = Camp[i].Imag9;break;
                        case 9:
                                Foto[j++] = Camp[i].Imag10;break;
                    }
                }
                campanii ItemCampanie = new campanii((Camp[i].BaniTotal - Camp[i].BaniStransi).ToString(),
                    Camp[i].NumeZona, Camp[i].NumeCampanie, Camp[i].ID, (float)Camp[i].BaniTotal,Camp[i].Descriere,Foto);
                donatiiStackPanel.Children.Add(ItemCampanie);
            }

        }

        public String[] GetFotos(bing.ServiceReference2.Real campanie)
        {
            String[] Foto = new String[5];
            int k = 0;
            for (int i = 0; i <= 10; i++)
            {
                // String img ="Imag"+i;
                if (campanie.Imag1 != null && k < 5)
                    Foto[k++] = campanie.Imag1;
                if (campanie.Imag2 != null && k < 5)
                    Foto[k++] = campanie.Imag2;
                if (campanie.Imag3 != null && k < 5)
                    Foto[k++] = campanie.Imag3;
                if (campanie.Imag4 != null && k < 5)
                    Foto[k++] = campanie.Imag4;
                if (campanie.Imag5 != null && k < 5)
                    Foto[k++] = campanie.Imag5;
                if (campanie.Imag6 != null && k < 5)
                    Foto[k++] = campanie.Imag6;
                if (campanie.Imag7 != null && k < 5)
                    Foto[k++] = campanie.Imag7;
                if (campanie.Imag8 != null && k < 5)
                    Foto[k++] = campanie.Imag8;
                if (campanie.Imag9 != null && k < 5)
                    Foto[k++] = campanie.Imag9;
                if (campanie.Imag10 != null && k < 5)
                    Foto[k++] = campanie.Imag10;
            }
            return Foto;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


    }
}
