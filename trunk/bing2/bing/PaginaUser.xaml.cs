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
using System.Windows.Media.Imaging;
using bing_maps;
using Microsoft.Maps.MapControl;
using Regiuni;
using System.Windows.Threading;
using System.ServiceModel;
using System.Globalization;
using bing.Forme;
namespace bing
{
    public partial class PaginaUser : UserControl
    {
        MapLayers mymap;
        Map map;
        private bool RealGame = false;
        DispatcherTimer timer = new DispatcherTimer();
        BasicHttpBinding bind = new BasicHttpBinding();
        List<Stire> ls = new List<Stire>();
        StiriDesign sd;
        Canvas canvas2;
        BusyIndicator bInidic;
        EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Tranzactii.svc");

        // Alex
        /// <summary>
        /// Variabile care arata regiunea curenta
        /// Necesita actualizare la schimbarea regiunii, subregiunii, zonei
        /// </summary>
        TextBlock tb1;
        TextBlock tb2;
        TextBlock tb3;
        TextBlock tb4;
        TextBlock tb5;
        TextBlock tb6;

        /// <summary>
        /// Store the current instance for global use
        /// </summary>
        private static PaginaUser instance;
       
        public PaginaUser(BusyIndicator bIndic,List<ServiceReference1.LoginFunction_Result> lista,MapLayers mymap,Map map,Canvas canvas2)
        {
            InitializeComponent();
            this.canvas2 = canvas2;
            this.mymap = mymap;
            this.map = map;
            this.bInidic = bIndic;
            #region Adresa + Nume animal
            ControlCuColturiRotunde adresscur = new ControlCuColturiRotunde(LayoutRoot, 230, 100, 0, 7, true, 1);
            adresscur.Colturi(13, 13, new Rect(0, 0, 230, 100));
            adresscur.Colors("#FFF0F8FF", "#FFF0F8FF", new Point(0.5, 1), new Point(0.5, 0), 0.3);
            //    ControlCuColturiRotunde dd = new ControlCuColturiRotunde(can, 200, 100, 200, 100, false, 1);
            Canvas wrap = new Canvas() { Margin = new Thickness(12, 12, 12, 12), Width = 210, Height = 70 };
            tb1 = new TextBlock() { Text = "You are here: ", Margin = new Thickness(0, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            tb2 = new TextBlock() { Text = "Regiunea Curenta", Margin = new Thickness(tb1.ActualWidth + 1, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            tb3 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb1.ActualWidth + tb2.ActualWidth + 2, 1, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            tb4 = new TextBlock() { Text = "Subregiunea", Margin = new Thickness(tb1.ActualWidth + tb2.ActualWidth + tb3.ActualWidth + 3, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            if (tb4.Margin.Left + tb4.ActualWidth > 210)//trecere urm rand
                tb4.Margin = new Thickness(15, 18, 0, 0);
            tb5 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb4.Margin.Left != 0 ? tb4.ActualWidth + 16 : 15, 18, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            if (tb4.Margin.Left != 15)
                tb5.Margin = new Thickness(15, 18, 0, 0);
            tb6 = new TextBlock() { Text = "Zona Campie/Padure", Margin = new Thickness(tb5.Margin.Left + tb5.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            //TextBlock tb7 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb6.Margin.Left + tb6.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            //TextBlock tb8 = new TextBlock() { Text = "Animals", Margin = new Thickness(tb7.Margin.Left + tb7.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            wrap.Children.Add(tb1); wrap.Children.Add(tb2); wrap.Children.Add(tb3); wrap.Children.Add(tb4); wrap.Children.Add(tb5); wrap.Children.Add(tb6); //wrap.Children.Add(tb7); wrap.Children.Add(tb8);
            LayoutRoot.Children.Add(wrap);

            TextBlock tb9 = new TextBlock() { Text = "Welcome,", Margin = new Thickness(12, 48, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black) };
            TextBlock tb10 = new TextBlock() { Text = lista[0].Nume, Margin = new Thickness(12, 58, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 23, Foreground = new SolidColorBrush(Colors.Black) };
            LayoutRoot.Children.Add(tb9);
            LayoutRoot.Children.Add(tb10);
            #endregion
            ImageSourceConverter c = new ImageSourceConverter();
            image1.Source = (ImageSource)c.ConvertFromString("Game/deer.jpg");
            Donatii.Text = lista[0].NrDonatii.ToString() + " Donations";
            Banidonati.Text = lista[0].BaniDonati.ToString() + " RON donated";
            Rank.Text = "Rank: "+lista[0].Rank.ToString();
            Scor.Text = "Scor: " + lista[0].Scor;
            mymap.lol();
            
            bIndic.IsBusy = false;

            // Alex
            // Evenimente
            tb2.MouseLeftButtonUp += new MouseButtonEventHandler(tb2_MouseLeftButtonUp);

            // Update region
            updateCurrentRegion();

            // Store the current instance
            instance = this;
        }

        #region MOUSE ENTER MOUSE  MOVE

        /// <summary>
        /// Event for clicking on the Region
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tb2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CNavigationSystem.getInstance().goToCurrentRegion();
        }
        
        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("dfsd");
        }

        private void Achivments_MouseEnter(object sender, MouseEventArgs e)
        {
            Achivments.Opacity = 0.9;
        }

        private void Achivments_MouseLeave(object sender, MouseEventArgs e)
        {
            Achivments.Opacity =1;
        }

        private void Challanges_MouseEnter(object sender, MouseEventArgs e)
        {
            Challanges.Opacity = 0.9;
        }

        private void Challanges_MouseLeave(object sender, MouseEventArgs e)
        {
            Challanges.Opacity = 1;
        }

        private void Upgrades_MouseEnter(object sender, MouseEventArgs e)
        {
            Upgrades.Opacity = 0.9;
        }

        private void Upgrades_MouseLeave(object sender, MouseEventArgs e)
        {
            Upgrades.Opacity = 1;
        }
        #endregion
        
        private void News_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlaneProjection p = (PlaneProjection)canvas2.Projection;
            if (p != null)
            {
                if (p.RotationY < 270)
                    p.RotationY = 0;
                canvas2.Projection = p;
            }
            ServiceReference1.TranzactiiClient tc = new ServiceReference1.TranzactiiClient(bind, endpoint);
            tc.GetStiriCompleted += new EventHandler<ServiceReference1.GetStiriCompletedEventArgs>(tc_GetStiriCompleted);
            tc.GetStiriAsync();
        }

        void tc_GetStiriCompleted(object sender, ServiceReference1.GetStiriCompletedEventArgs e)
        {
            ls.Clear();
            foreach(var z in e.Result)
            {
                ls.Add(new Stire(z.Titlu,z.Stire));
            }
             sd = new StiriDesign(ls);
             canvas2.Children.Clear();
             canvas2.Children.Add(sd);
           
        }

        private void Donations_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (canvas2.Children.Contains(sd))
            {
              canvas2.Children.Clear();
              canvas2.Children.Add(map);
            }
            if (RealGame == false)
            {
                bInidic.IsBusy = true;
                ServiceReference1.TranzactiiClient tc = new ServiceReference1.TranzactiiClient(bind, endpoint);
                tc.HartaCuCampaniiCompleted += new EventHandler<ServiceReference1.HartaCuCampaniiCompletedEventArgs>(tc_HartaCuCampaniiCompleted);
                tc.HartaCuCampaniiAsync();
               
            }
            else
            {
                map.Children.Clear();
                map.Children.Add(mymap.RomaniaMap());
                mymap.lol();
                Donations.Text = "Donation";
                RealGame = false;
            }
        }

        void tc_HartaCuCampaniiCompleted(object sender, ServiceReference1.HartaCuCampaniiCompletedEventArgs e)
        {
           
            List<ListaReal> list = new List<ListaReal>();
           
            foreach (var c in e.Result)
            {
                list.Add(new ListaReal(new Location(double.Parse(c.Latitudine), double.Parse(c.Longitudine)), c.NumeCampanie,c.PctLocatie,c.NivelProblema));
            }
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            mymap.AddPushPin(list);
            RealGame = true;
            Donations.Text = "Back to game";
            bInidic.IsBusy = false;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (mymap.Z < 6)
            {
                timer.Stop();
                mymap.bIsMousePressedMoldova = false;
            

                mymap.poligonBanat.Visibility = mymap.poligonBaragan.Visibility = mymap.poligonMoldova.Visibility = mymap.poligonTransilvania.Visibility = Visibility.Visible;
            }
            if (mymap.bIsMousePressedMoldova)
            { mymap.Z -= 0.1; mymap.Long -= 0.19; mymap.Lat -= 0.10; }
            map.SetView(new Location(mymap.Lat, mymap.Long), mymap.Z);
        }

        private void Upgrades_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ServiceReference1.TranzactiiClient tc = new ServiceReference1.TranzactiiClient(bind,endpoint);
            tc.GetProceduraUpgradesCompleted += new EventHandler<ServiceReference1.GetProceduraUpgradesCompletedEventArgs>(tc_GetProceduraUpgradesCompleted);
            tc.GetProceduraUpgradesAsync(11);
         
        }

        void tc_GetProceduraUpgradesCompleted(object sender, ServiceReference1.GetProceduraUpgradesCompletedEventArgs e)
        {
            if (AtributeGlobale.upgrades == false)
            {
                //PlaneProjection p = (PlaneProjection)canvas2.Projection;
                //if (p != null)
                //{
                //    if (p.RotationY < 270)
                //    {
                //        p.RotationY = 0;
                //        canvas2.Projection = p;
                //    }
                //}

                List<UIElement> listaelem = canvas2.Children.ToList<UIElement>();
                //foreach (UIElement c in canvas2.Children) { listaelem.Add(c); }
                ServiceReference1.ProcedureUpgrades_Result l = e.Result[0];
                Upgrades up = new Upgrades(l, canvas2);
                ListaUielements();
                canvas2.Children.Clear();
                canvas2.Children.Add(up);
                up.Back(listaelem);
                AtributeGlobale.upgrades = true;
                AtributeGlobale.achiv =  AtributeGlobale.tranz=AtributeGlobale.news = false;
            }
        }

        private void Achivments_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AtributeGlobale.achiv == false)
            {
                AtributeGlobale.achiv = true;
                AtributeGlobale.upgrades = AtributeGlobale.tranz = AtributeGlobale.news = false;
                ListaUielements();
                RankingSystem ranking = new RankingSystem();
                ranking.get_AchievementsFromDB();
                // temp este o lista cu copiii lui canvas2
                // este folosita pentru a ma intoarce la harta
              List<UIElement> temp = new List<UIElement>();
               temp = canvas2.Children.ToList<UIElement>();
                ////////////////////////////////////////////
                canvas2.Children.Clear();
                canvas2.Children.Add(ranking);
                ranking.setBackButton(temp, canvas2);
            }
        }

        private void Challanges_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AtributeGlobale.tranz == false)
            {
                AtributeGlobale.tranz = true;
                AtributeGlobale.upgrades = AtributeGlobale.achiv = AtributeGlobale.news = false;
                ListaUielements();
                List<UIElement> listaelem = canvas2.Children.ToList<UIElement>();
                canvas2.Background = new SolidColorBrush(Colors.Black);
                bing_maps.Forme.MyTranzactii my = new bing_maps.Forme.MyTranzactii(canvas2);
                my.Back(listaelem);
            }
        }
        private void ListaUielements()
        {
            PlaneProjection p = (PlaneProjection)canvas2.Projection;
            if (p != null)
            {
                if (p.RotationY < 270)
                {
                    p.RotationY = 0;
                    canvas2.Projection = p;
                }
            }
        }

        /// <summary>
        /// Updates the current region, subregion, zone
        /// </summary>
        public void updateCurrentRegion()
        {
            tb2.Text = AtributeGlobale.RegiuneaCurenta.ToString();
            tb4.Text = AtributeGlobale.SubRegiuneaCurenta.ToString();
            tb6.Text = AtributeGlobale.ZonaCurenta.ToString();

            // TextBlock Regiune
            if (tb2.Text == AtributeGlobale.EnumRegiuni.NoRegionSelected.ToString())
            {
                tb2.Text = "Map Overview";
            }
            else
            {
                tb2.Visibility = System.Windows.Visibility.Visible;
            }

            // TextBlock Subregiune + TextBlock dintre Regiune >> Subregiune
            if (tb4.Text == AtributeGlobale.EnumSubRegiuni.NoSubRegionSelected.ToString())
            {
                tb3.Visibility = System.Windows.Visibility.Collapsed;
                tb4.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                tb3.Visibility = System.Windows.Visibility.Visible;
                tb4.Visibility = System.Windows.Visibility.Visible;
            }

            // TextBlock Zona + TextBlock dintre Subregiune >> Zona
            if (tb6.Text == AtributeGlobale.EnumZone.NoZoneSelected.ToString())
            {
                tb5.Visibility = System.Windows.Visibility.Collapsed;
                tb6.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                tb5.Visibility = System.Windows.Visibility.Visible;
                tb6.Visibility = System.Windows.Visibility.Visible;
            }

            // Settings for  ">>"
            tb3.Margin = new Thickness(tb1.ActualWidth + tb2.ActualWidth + 2, 1, 0, 0);
            tb5.Margin = new Thickness(tb4.Margin.Left != 0 ? tb4.ActualWidth + 16 : 15, 18, 0, 0);
        }

        /// <summary>
        /// Returns the current instance for global use
        /// </summary>
        /// <returns></returns>
        public static PaginaUser getInstance()
        {
            if (instance == null)
                return null;
            return instance;
        }
    }
}
