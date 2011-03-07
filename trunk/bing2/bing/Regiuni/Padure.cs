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
using bing.Forme;
using System.Collections.Generic;
using System.ServiceModel;
using bing.ServiceReference1;

namespace bing.Regiuni
{
    public class Padure
    {
        Canvas c;
        Canvas md;
        BasicHttpBinding bind = new BasicHttpBinding();
        EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Tranzactii.svc");
        public Padure(Canvas canv,Canvas md)
        {
            c = canv;
            this.md = md;
            
            md.Children.Clear();
            ServiceReference1.TranzactiiClient tc = new ServiceReference1.TranzactiiClient(bind, endpoint);
            tc.GetHistoryPadureCompleted += new EventHandler<ServiceReference1.GetHistoryPadureCompletedEventArgs>(tc_GetHistoryPadureCompleted);
            tc.GetHistoryPadureAsync();
         
        }

        void tc_GetHistoryPadureCompleted(object sender, ServiceReference1.GetHistoryPadureCompletedEventArgs e)
        {
            Animalule an = new Animalule();
            List<HistoryPadure_Result> lista = new List<HistoryPadure_Result>();
            foreach (var c in e.Result)
            {
                lista.Add(c);
            }
            an.Aranjeaza(lista);
            md.Children.Add(an);
        }
       public void Peste()
        {
           
            #region BackgroundCanvas
            Canvas background = new Canvas()
            {
                Width = 663,
                Height = 100,
                Background = new SolidColorBrush(Colors.Black),
                Opacity = 0.5,
                
            };
            #endregion

            c.Children.Add(background);
            Canvas.SetTop(background, 370);
            Canvas.SetLeft(background, 50);
            MeniuPicks p = new MeniuPicks(c, 663, 100, "", 1, 50, 370,md);

            c.Children.Add(p);
        }
    }
}
