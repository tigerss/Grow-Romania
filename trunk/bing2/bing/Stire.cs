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

namespace bing
{
    public class Stire
    {
        private string titlu;
        private string stiri;

        public string Stiri
        {
            get { return stiri; }
            set { stiri = value; }
        }

        public string Titlu
        {
            get { return titlu; }
            set { titlu = value; }
        }
        public Stire(string titlu, string stiri) { this.titlu = titlu; this.stiri = stiri; }
    }
}
