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

namespace bing.Regiuni
{
    public class Padure
    {
        Canvas c;
        Canvas md;
        public Padure(Canvas canv,Canvas md)
        {
            c = canv;
            this.md = md;
            
            md.Children.Clear();
            Animalule an = new Animalule();
            an.Aranjeaza();
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
           //si se cheama automat MeniuPicks:D
           //si aici iar trimiti parametru si il preiei din constructor
           //faza e ca se trimit asincron si nu apuca sa ajunga daca dai sa isi faca load
           //din MeniuPicks si iti va da eroare
           //ok e misto facut
           //mai poti face o chestie
           //sa pui pur si simplu animalele de mana
           //si mai faci un vector cu iduri si apoi cand apesi pe un animal se duce in baza dupa
           //info la idu ala

            MeniuPicks p = new MeniuPicks(c, 663, 100, "", 1, 50, 370,md);

            c.Children.Add(p);
        }
    }
}
