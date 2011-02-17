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
using bing.ServiceReference2;

namespace bing
{
    public partial class Donatie : UserControl
    {
        string Probleme;
        string Judet;
        string OcolSilvic;
        int idDonatie;
        public Donatie()
        {
            InitializeComponent();
        }
        public Donatie(string date,string numeCampanie,float suma,string probleme,string judet,string ocolSilvic,int id)
        {
            InitializeComponent();
            numeCampanieTextBlock.Text = numeCampanie;
            MoneyTextBlock.Text = suma.ToString();
            Probleme = probleme;
            OcolSilvic = ocolSilvic;
            Judet = judet;
            idDonatie = id;
    //        Line L = new Line() {X1=10, X2=20, Y1=10, Y2=100 , };
         //   Linie L1 = new Linie(1, 1, linieCanvas.Width, 1, "#FF717577", 1, linieCanvas, L);
        }

        private void detailsHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            if (((HyperlinkButton)sender).Content.ToString() == "details")
            {
                ((HyperlinkButton)sender).Content = " hide";
                ServiceReference2.CampaignsClient service = new ServiceReference2.CampaignsClient();
                DonatieDetalii don = new DonatieDetalii(OcolSilvic,Judet,Probleme);
                detaliiComentariiStackPanel.Children.Add(don);
                detaliiComentariiStackPanel.Height += 100;
                service.SelectDonatiiComentariiByDonatieAsync(idDonatie);
                service.SelectDonatiiComentariiByDonatieCompleted += new EventHandler<ServiceReference2.SelectDonatiiComentariiByDonatieCompletedEventArgs>(service_SelectDonatiiComentariiByDonatieCompleted);
                
            }
            else
            {
                ((HyperlinkButton)sender).Content = "details";
                detaliiComentariiStackPanel.Height = 0;
                detaliiComentariiStackPanel.Children.Clear();
            }
        }

        void service_SelectDonatiiComentariiByDonatieCompleted(object sender, ServiceReference2.SelectDonatiiComentariiByDonatieCompletedEventArgs e)
        {
            foreach (ComentariiDonatiiType comment in e.Result)
            {
                Comentariu ComentariuControl = new Comentariu(comment.TextComentariu, comment.Data.ToString(), comment.Usr, comment.Poza);
                detaliiComentariiStackPanel.Children.Add(ComentariuControl);
                detaliiComentariiStackPanel.Height += 122;
            }
            AddCommentControl CommentToAdd = new AddCommentControl(null,2);
            detaliiComentariiStackPanel.Children.Add(CommentToAdd);
            CommentToAdd.idCampanieTextBlock.Text = idDonatie.ToString();
            detaliiComentariiStackPanel.Height += 135;
        }
    }
}
