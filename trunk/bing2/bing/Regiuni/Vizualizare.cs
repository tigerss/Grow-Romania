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
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Collections.Generic;
using bing.ServiceReference1;

namespace bing.Regiuni
{
    public class Vizualizare
    {
        Canvas c;
        Canvas md;

        public Vizualizare(Canvas canv, Canvas md, List<HistoryPadure_Result> lista)
        {
            c = canv;
            this.md = md;
            
            md.Children.Clear();
            Animalule an = new Animalule();
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
            ButonAnimat plante = new ButonAnimat(c, "DesignImages/tree.png", 60, 707, false, p, "Plants");
            ButonAnimat animale = new ButonAnimat(c, "DesignImages/paw.jpg", 110, 707, true, p, "Animals");
        }
    }
}
