﻿using System;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Forme;
using Microsoft.Maps.MapControl;
using Regiuni;
using System.ServiceModel;
using bing.testService;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using bing.Forme;

namespace bing
{
    public static class AtributeGlobale
    {
        public enum EnumRegiuni { NoRegionSelected = 0, Transilvania, Moldova, Baragan, Banat };
        public enum EnumSubRegiuni { NoSubRegionSelected = 0, SubRegion1, SubRegion2, SubRegion3, SubRegion4 };
        public enum EnumZone { NoZoneSelected = 0, Fields, Forest };
        public static EnumRegiuni RegiuneaCurenta=EnumRegiuni.NoRegionSelected;
        public static EnumSubRegiuni SubRegiuneaCurenta = EnumSubRegiuni.NoSubRegionSelected;
        public static EnumZone ZonaCurenta = EnumZone.NoZoneSelected;
        public static bool UserIsRegistering = false;
        public static int i = 0;
        public static bool achiv = false;
        public static bool tranz = false;
        public static bool upgrades = false;
       public static bool news = false;
    }
   
    public partial class MainPage : UserControl
    {
        
        /// <summary>
        /// Map Layeru principal
        /// </summary>
        private MapLayers maplayer ;
        internal static bool bZoomDisable = false;
        internal static bool bZoomEnable = false;
        public bool bIsZoomOut = false;
        static DispatcherTimer timer=new DispatcherTimer();

        /// <summary>
        /// Store the current instance for globally use
        /// </summary>
        private static MainPage instance;

        #region ButonPeste
        static DispatcherTimer dt = new DispatcherTimer();
        double width=707;
        double width2 = 0;
        Canvas pop;
        Image img;
        bool BRegion=false;

        // Back Button 2 Martie
        CBackButton backButton;
        #endregion

        public MainPage(int r)
        { }
        public MainPage()
        {
            //ServiceReference3.ServiceDecesClient wcf = new ServiceReference3.ServiceDecesClient(bind, endpoint);

            //wcf.PreiaDecesAsync(1);
            //wcf.PreiaDecesCompleted += new EventHandler<ServiceReference3.PreiaDecesCompletedEventArgs>(wcf_PreiaDecesCompleted);
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
        
            //trimit canvasul de deasupra hartii
            maplayer = new MapLayers(map, canvas2, MeniuDreapa);
            map.SetView(new Location(maplayer.latitudine, maplayer.longitudine), maplayer.zoom);
            map.Children.Add(maplayer.RomaniaMap());
            map.Children.Add(maplayer.PoligonMoldova());
            map.Children.Add(maplayer.PoligonTransilvania());
            map.Children.Add(maplayer.PoligonBaragan());
            map.Children.Add(maplayer.PoligonBanat());
            ArrangePage();

            // End of the constructor
            // Store the current instance
            instance = this;
        }
       // List<ServiceReference1.Istoric_Animal_Deces> lista2;
       // void wcf_PreiaDecesCompleted(object sender, ServiceReference3.PreiaDecesCompletedEventArgs e)
       // {
       ////     lista2 = new List<ServiceReference3.Istoric_Animal_Deces>();
       //     foreach (var c in e.Result)
       //     lista2.Add(c);
       // }
      

  
        private void ArrangePage()
        {
            //rezolutia ecranului
            canvas.Width = double.Parse(HtmlPage.Window.Eval("screen.width").ToString());
            canvas.Height = double.Parse(HtmlPage.Window.Eval("screen.height").ToString());
            HtmlDocument d = HtmlPage.Document;
            string c = d.QueryString.Count.ToString() ;
            //canvasu de sus
            btn2.Width = canvas.Width;
            // aranjenz in pagina gridu
            Canvas.SetLeft(LayoutRoot, canvas.Width / 2 - 500);
            Canvas.SetTop(LayoutRoot, 75);
            LoginForm add = new LoginForm(MeniuDreapa,canvas2,maplayer,map);
            
            MeniuSus m = new MeniuSus(btn2, canvas.Width,canvas2);
           
       #region Tranzactii Sergiu

          //  Tranzactii
       //     map.Visibility = Visibility.Collapsed;
        //   canvas2.Children.Clear();
      //      canvas2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
           //// Forme.t = new Forme.Tranzactii(canvas2);
       //  Forme.MyTranzactii t = new Forme.MyTranzactii(canvas2);
     //    bing_maps.Forme.MyTranzactii t = new bing_maps.Forme.MyTranzactii(canvas2);
            #endregion
        #region History
         //  Thread.Sleep(new TimeSpan(0, 0, 0,5));
          //  stat s = new stat(canvas2);
          //  canvas2.Children.Add(s);
            //History cs = new History();
            //canvas2.Children.Add(s);
            #endregion
            #region Holban
            //BasicHttpBinding bind = new BasicHttpBinding();
            //EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Service1.svc");
            //bing.testService.Service1Client wcf = new bing.testService.Service1Client(bind, endpoint);
            //wcf.GetAnimalByIDCompleted += new EventHandler<bing.testService.GetAnimalByIDCompletedEventArgs>(wcf_GetAnimalByIDCompleted);
            //wcf.GetTop3IstoricAnimaleForUserXCompleted += new EventHandler<GetTop3IstoricAnimaleForUserXCompletedEventArgs>(wcf_GetTop3IstoricAnimaleForUserXCompleted);
            //try
            //{
            //    wcf.GetAnimalByIDAsync(15);
            //    wcf.GetTop3IstoricAnimaleForUserXAsync(2, 15);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            #endregion
        }
        #region Holban
        //Animale temp;
        //List<IstoricAnimalPadureForUserX> templ;
        //void wcf_GetAnimalByIDCompleted(object sender, bing.testService.GetAnimalByIDCompletedEventArgs e)
        //{
        //    temp = (Animale)e.Result;
        //    MeniuAnimal add;
        //    if (templ != null)
        //        add = new MeniuAnimal(MeniuDreapa, "Moldova", "Moldova2", "Padure", temp, templ);
        //}

        //void wcf_GetTop3IstoricAnimaleForUserXCompleted(object sender, GetTop3IstoricAnimaleForUserXCompletedEventArgs e)
        //{
        //    templ = new List<IstoricAnimalPadureForUserX>(3);
        //    foreach (var v in e.Result)
        //    {
        //        templ.Add(v);
        //    }
        //    MeniuAnimal add;
        //    if (temp != null)
        //        add = new MeniuAnimal(MeniuDreapa, "Moldova", "Moldova2", "Padure", temp, templ);
        //}
        #endregion

        // Unused. Can be deleted
        private void SelectRegionButton()
        {
            if (Popup.Child == null)
            {
                pop = new Canvas()
                {
                    Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xcc, 0xdf, 0xf5)),
                    Opacity = .46,
                    Width = 50,
                    Height = 50,
                    Clip = new RectangleGeometry()
                    {
                        RadiusX = 10,
                        RadiusY = 10,
                        Rect = new Rect(0, 0, 100, 40)
                    },

                };
                //pop.MouseEnter += new MouseEventHandler(pop_MouseEnter);
                //pop.MouseLeave += new MouseEventHandler(pop_MouseLeave);
                img = new Image() { Source = new BitmapImage(new Uri("DesignImages/avion.png", UriKind.Relative)), Width = 38, Height = 21 };

                pop.Children.Add(img);
                Canvas.SetLeft(img, 6);
                Canvas.SetTop(img, 10);
                Popup.Child = pop;
                dt.Interval = new TimeSpan(0, 0, 0, 0, 20);
                dt.Tick += new EventHandler(dt_Tick);
            }
            else
            {
                Popup.IsOpen = true;
            }
        }

        // Can be deleted
        void pop_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BRegion == true)
            {

                BRegion = false;
                dt.Start();
            }
        }

        // Can be deleted
        void pop_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BRegion == false)
            {
                dt.Start();
                BRegion = true;
            }
        }

        // Can be deleted
        void dt_Tick(object sender, EventArgs e)
        {
            if (width < 600 && BRegion == true)
            {
                dt.Stop();
            }
            if (width > 700 && BRegion == false)
            {
                dt.Stop();
            }
            if (BRegion == true)
            {
                width = width - 1;
                width2 = width2 + 1;
            }
            else
            {
                width = width + 1;
                width2 = width2 - 1;
            }
            Popup.Width = Popup.Width + width;
            pop.Children.Remove(img);
            pop = new Canvas()
            {
                Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xcc, 0xdf, 0xf5)),
                Opacity = .46,
                Width = 50 + width2,
                Height = 50,
                Clip = new RectangleGeometry()
                {
                    RadiusX = 10,
                    RadiusY = 10,
                    Rect = new Rect(0, 0, 300, 40)
                },

            };
            pop.MouseLeave += new MouseEventHandler(pop_MouseLeave);
            pop.MouseEnter += new MouseEventHandler(pop_MouseEnter);
            pop.Children.Add(img);
            Popup.Child = pop;
            Canvas.SetLeft(Popup, width);
        }

        private void map_MouseWrong(object sender, MouseEventArgs e)
        {
            //if (!maplayer.bIsMousePressedBanat && !maplayer.bIsMousePressedBaragan && !maplayer.bIsMousePressedMoldova && !maplayer.bIsMousePressedTransilvania)
            //  map.SetView(new Location(maplayer.Lat, maplayer.Long), maplayer.Z);
        }
        private void map_TargetViewChanged(object sender, MapEventArgs e)
        {

            if (bZoomDisable == false)
            {

                if ((map != null))
                {
                    if (maplayer.Z != map.ZoomLevel)
                        map.SetView(new Location(maplayer.Lat, maplayer.Long), maplayer.Z);

                }
            }
            if (map != null && bZoomEnable == false)
            {
                if (maplayer.bIsMousePressedMoldova || maplayer.bIsMousePressedBaragan || maplayer.bIsMousePressedBanat || maplayer.bIsMousePressedTransilvania)
                {
                    bZoomDisable = true;
                    // ------------------
                    // Unusable
                    //Popup.IsOpen = true;
                    //SelectRegionButton();
                    //----------------------

                    // Add Back Button
                    backButton = CBackButton.getInstance();

                    // Verify Visibility
                    if (backButton.isButtonVisible() == false)
                        backButton.setVisibility(true);

                }
                if (maplayer.Z > 7.0)
                {
                    bZoomDisable = false;

                    bZoomEnable = true;
                }
            }

        }
        private void bpopupZoomut_Click(object sender, RoutedEventArgs e)
        {
            bZoomDisable = true;
            bZoomEnable = false;

            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (maplayer.Z < 6)
            {
                timer.Stop();
                maplayer.bIsMousePressedMoldova = false;
         //       Moldova m = new Moldova(map, canvas,MeniuDreapa,maplayer,lista);

                maplayer.poligonBanat.Visibility = maplayer.poligonBaragan.Visibility = maplayer.poligonMoldova.Visibility = maplayer.poligonTransilvania.Visibility = Visibility.Visible;
            }
            if (maplayer.bIsMousePressedMoldova)
            { maplayer.Z -= 0.1; maplayer.Long -= 0.19; maplayer.Lat -= 0.10; }
            map.SetView(new Location(maplayer.Lat, maplayer.Long), maplayer.Z);
        }
        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        /// <summary>
        /// Return the current Instance for global use
        /// </summary>
        /// <returns></returns>
        public static MainPage getInstance()
        {
            if (instance == null)
                return null;
            return instance;
        }

        /// <summary>
        /// Getter for MapLayers
        /// </summary>
        /// <returns></returns>
        public MapLayers getMapLayer()
        {
            return maplayer;
        }

        /// <summary>
        /// Getter for bZoomEnable
        /// </summary>
        /// <returns></returns>
        public bool getBZoomEnable()
        {
            return bZoomEnable;
        }

        /// <summary>
        /// Setter for bZoomEnable
        /// </summary>
        /// <param name="bEnableZoom"></param>
        public void setBZoomEnable(bool bEnableZoom)
        {
            bZoomEnable = bEnableZoom;
        }
    }
}
