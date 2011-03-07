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
using Microsoft.Maps.MapControl;

namespace bing
{
    public class ListaReal
    {
       
        public Location x;
        public string nume;
        public string locatie;
        public int InivelProblema;
        public ListaReal(Location loc,string nume,string locatie,int InivelProblema)
        {
            this.x = loc;
            this.nume = nume;
            this.locatie = locatie;
            this.InivelProblema = InivelProblema;
        }
    
    }
}
