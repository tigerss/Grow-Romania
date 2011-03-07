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
using bing;
using System.Windows.Media.Imaging;
using bing.ServiceReference1;


namespace bing.Forme
{
    public partial class Animalule : UserControl
    {
        /// <summary>
        /// Setting the current region
        /// </summary>
        static string region;
        static TextBlock tb6 = new TextBlock();

        /// <summary>
        /// Show Animals/Plants
        /// </summary>
        TextBlock tb8;

        /// <summary>
        /// The current instance
        /// </summary>
        private static Animalule instance;

        public Animalule()
        {
            InitializeComponent();
           // Imagine1.Source = new BitmapImage(new Uri("Game/bear.jpg", UriKind.Relative));

            // Store the current instance
            instance = this;
        }
        private string GetNormal(string istoric)
        {
            return istoric.Replace("[b]", "").Replace("[/b]", "");
        }
        public void Aranjeaza(List<HistoryPadure_Result> lista)
        {
            #region Adresa + Nume animal
            ControlCuColturiRotunde adresscur = new ControlCuColturiRotunde(can, 230, 74, 0, 7, true, 1);
            adresscur.Colturi(13, 13, new Rect(0, 0, 230, 74));
            adresscur.Colors("#FFF0F8FF", "#FFF0F8FF", new Point(0.5, 1), new Point(0.5, 0), 0.3);

            Canvas wrap = new Canvas() { Margin = new Thickness(12, 12, 12, 12), Width = 210, Height = 60 };
            TextBlock tb1 = new TextBlock() { Text = "You are here: ", Margin = new Thickness(0, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            TextBlock tb2 = new TextBlock() { Text = AtributeGlobale.RegiuneaCurenta.ToString(), Margin = new Thickness(tb1.ActualWidth + 1, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            TextBlock tb3 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb1.ActualWidth + tb2.ActualWidth + 2, 1, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            TextBlock tb4 = new TextBlock() { Text = AtributeGlobale.SubRegiuneaCurenta.ToString(), Margin = new Thickness(tb1.ActualWidth + tb2.ActualWidth + tb3.ActualWidth + 3, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            if (tb4.Margin.Left + tb4.ActualWidth > 210)//trecere urm rand
                tb4.Margin = new Thickness(15, 18, 0, 0);
            TextBlock tb5 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb4.Margin.Left != 0 ? tb4.ActualWidth + 16 : 15, 18, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            if (tb4.Margin.Left != 15)
                tb5.Margin = new Thickness(15, 18, 0, 0);
            TextBlock tb6 = new TextBlock() { Text = AtributeGlobale.ZonaCurenta.ToString(), Margin = new Thickness(tb5.Margin.Left + tb5.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            TextBlock tb7 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb6.Margin.Left + tb6.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            tb8 = new TextBlock() { Text = "Animals", Margin = new Thickness(tb7.Margin.Left + tb7.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            wrap.Children.Add(tb1); wrap.Children.Add(tb2); wrap.Children.Add(tb3); wrap.Children.Add(tb4); wrap.Children.Add(tb5); wrap.Children.Add(tb6); wrap.Children.Add(tb7); wrap.Children.Add(tb8);
            can.Children.Add(wrap);

            // Alex
            // Evenimente
            tb2.MouseLeftButtonUp += new MouseButtonEventHandler(tb2_MouseLeftButtonUp);
            tb4.MouseLeftButtonUp += new MouseButtonEventHandler(tb4_MouseLeftButtonUp);
            #endregion
            #region history
            //Line l2 = new Line() { X1 = 8, X2 = 226, Y1 = 290, Y2 = 290, Stroke = new SolidColorBrush(Colors.White), StrokeThickness = 1 };
            //can.Children.Add(l2);
            //TextBlock tb20 = new TextBlock() { Text = "History", Margin = new Thickness(10, 292, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 22, Foreground = new SolidColorBrush(Colors.White) };
            //can.Children.Add(tb20);
            int top = 342;
            int left = 0;
            if (lista.Count > 0)
            {
                TextBlock ist1 = new TextBlock() { Text = GetNormal(lista[0].Description), Margin = new Thickness(left+4, top, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Colors.White), TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
                Rectangle r1 = new Rectangle() { Fill = new SolidColorBrush(Color.FromArgb(255, 26, 28, 30)), Width = 218, Height = 36, Margin = new Thickness(left, top, 12, 12) };
                r1.Height = ist1.ActualHeight + 2;
                can.Children.Add(r1); can.Children.Add(ist1);
                AdaugaLinkuri(ref can, lista[0].Nume, ist1.Margin.Left, ist1.Margin.Top);

                if (lista.Count > 1)
                {
                    TextBlock ist2 = new TextBlock() { Text = GetNormal(lista[1].Description), Margin = new Thickness(left+4, top + ist1.ActualHeight + 2, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Colors.White), TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
                    Rectangle r2 = new Rectangle() { Fill = new SolidColorBrush(Colors.Transparent), Width = 218, Height = 36, Margin = new Thickness(left, top + ist1.ActualHeight + 2, 12, 12) };
                    r2.Height = ist2.ActualHeight + 2;
                    can.Children.Add(r2); can.Children.Add(ist2);
                    AdaugaLinkuri(ref can, lista[0].Nume, ist2.Margin.Left, ist2.Margin.Top);


                    if (lista.Count > 2)
                    {
                        TextBlock ist3 = new TextBlock() { Text = GetNormal(lista[2].Description), Margin = new Thickness(left+4, 342 + ist1.ActualHeight + ist2.ActualHeight + 4, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Colors.White), TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
                        Rectangle r3 = new Rectangle() { Fill = new SolidColorBrush(Color.FromArgb(255, 26, 28, 30)), Width = 218, Height = 36, Margin = new Thickness(left, 342 + ist1.ActualHeight + ist2.ActualHeight + 4, 12, 12) };
                        r3.Height = ist3.ActualHeight + 2;
                        can.Children.Add(r3); can.Children.Add(ist3);
                        AdaugaLinkuri(ref can, lista[2].Nume, ist3.Margin.Left, ist3.Margin.Top );


                        if (lista.Count > 3)
                        {
                            //TextBlock more2 = new TextBlock() { Text = "+ more info", Margin = new Thickness(150, 322 + ist1.ActualHeight + ist2.ActualHeight + ist3.ActualHeight + 6, 12, 10), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Color.FromArgb(255, 139, 146, 5)), Cursor = Cursors.Hand };
                            //more2.MouseEnter += new MouseEventHandler(more2_MouseEnter);
                            //more2.MouseLeave += new MouseEventHandler(more2_MouseLeave);
                            //more2.MouseLeftButtonDown += new MouseButtonEventHandler(more2_MouseLeftButtonDown);
                            //can.Children.Add(more2);
                        }
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Go to the current Subregion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tb4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CNavigationSystem.getInstance().goToCurrentSubRegion();
        }

        /// <summary>
        /// Go to the current Region
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tb2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CNavigationSystem.getInstance().goToCurrentRegion();
        }

        //void more2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
      
        //}

        //void more2_MouseEnter(object sender, MouseEventArgs e)
        //{
            
        //}

        //void more2_MouseLeave(object sender, MouseEventArgs e)
        //{
           
        //}
        private void AdaugaLinkuri(ref Canvas pan, string istoric, double left, double top)
        {
            byte for2rows = 0;
            for (string aux = istoric; aux.Contains("[b]") == true; aux = aux.Substring(aux.IndexOf("[/b]") + 4))
            {
                TextBlock test = new TextBlock() { Text = GetNormal(istoric.Substring(0, istoric.Length - aux.Length) + aux.Substring(0, aux.IndexOf("[/b]"))), Margin = new Thickness(12, 0, 12, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 14, TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
                TextBlock add;
                if ((int)test.ActualHeight == 16)
                {
                    TextBlock test2 = new TextBlock() { Text = GetNormal(istoric.Substring(0, istoric.Length - aux.Length) + aux.Substring(0, aux.IndexOf("[b]"))), Margin = new Thickness(12, 0, 12, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 14, TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
                    add = new TextBlock() { Text = GetNormal(aux.Substring(aux.IndexOf("[b]"), aux.IndexOf("[/b]") - aux.IndexOf("[b]"))), Margin = new Thickness(left + test2.ActualWidth, top, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 124, 170)), TextWrapping = TextWrapping.Wrap, Cursor = Cursors.Hand };
                }
                else
                {
                    double addleft = GetLeftValueFor2Rows(istoric, for2rows++);
                    add = new TextBlock() { Text = GetNormal(aux.Substring(aux.IndexOf("[b]"), aux.IndexOf("[/b]") - aux.IndexOf("[b]"))), Margin = new Thickness(left + addleft, top + 16.9, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 124, 170)), TextWrapping = TextWrapping.Wrap, Cursor = Cursors.Hand };
                }
                add.MouseEnter += new MouseEventHandler(add_MouseEnter);
                add.MouseLeave += new MouseEventHandler(add_MouseLeave);
                pan.Children.Add(add);
            }
        }
        private double GetLeftValueFor2Rows(string istoric, byte nrcrt)
        {
            string aux = istoric;
            bool ok = true;
            while (ok)
            {
                TextBlock test = new TextBlock() { Text = GetNormal(aux = aux.Substring(0, aux.LastIndexOf(' '))), Margin = new Thickness(12, 0, 12, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 14, TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
                ok = (int)test.ActualHeight != 16;
            }
            istoric = aux = istoric.Substring(aux.Length).TrimStart();
            for (byte b = 0; b < nrcrt; b++) aux = aux.Substring(aux.IndexOf("[/b]") + 4);
            TextBlock test2 = new TextBlock() { Text = GetNormal(istoric.Substring(0, istoric.Length - aux.Length) + aux.Substring(0, aux.IndexOf("[b]"))), Margin = new Thickness(12, 0, 12, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 14, TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
            return test2.ActualWidth;
        }

        void add_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 124, 170));
        }

        void add_MouseEnter(object sender, MouseEventArgs e)
        {//54A3C4
            ((TextBlock)sender).Foreground = new SolidColorBrush(Color.FromArgb(255, 0x54, 0xa3, 0xc4));
        }

        /// <summary>
        /// Show animals or plants 
        /// </summary>
        /// <param name="animalsOrPlants"></param>
        public void setNaturalSelection(string animalsOrPlants)
        {
            tb8.Text = animalsOrPlants;
        }

        /// <summary>
        /// Setter for the current region
        /// Folosit pentru a intra in Campie/Padure
        /// </summary>
        /// <param name="regiune"></param>
        static public void setRegion(String regiune)
        {
            region = regiune;
            tb6.Text = region;
        }

        /// <summary>
        /// Getter for the current region
        /// Folosit pentru a intra in Padure/Campie
        /// </summary>
        /// <returns></returns>
        static public String getRegion()
        {
            return region;
        }

        /// <summary>
        /// Return the current instance for global use
        /// </summary>
        /// <returns></returns>
        static public Animalule getInstance()
        {
            if (instance == null)
                return null;
            return instance;
        }
    }
}
