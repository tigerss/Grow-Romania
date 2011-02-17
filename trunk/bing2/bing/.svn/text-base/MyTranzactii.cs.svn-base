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
using bing.testService;
using System.Collections.Generic;
using Forme;
using System.Windows.Data;
using bing.ServiceReference1;
using bing;
using System.Windows.Media.Imaging;
using System.ServiceModel;


namespace bing_maps.Forme
{
    /// <summary>
    ///  IN Clasa customer tin Mytrades
    ///  In clasa selling tin buying si selling
    /// </summary>
    public class MyTranzactii
    {
        BasicHttpBinding bind = new BasicHttpBinding();
        EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Tranzactii.svc");
        #region ButoaneSearch
           static ControlCuColturiRotunde CRCuvant;
           static ControlCuColturiRotunde CRRegiune;
           static ControlCuColturiRotunde search;
           static ControlCuColturiRotunde lol;
           static  ControlCuColturiRotunde CRQA;
         Image lupa;
        #endregion
        #region Variabile obiecte si liste
        Canvas CreateOffer;
        Canvas Search ;
        Canvas chceck;
        bool check=false;
        StackPanel sp;
        TextBox KeyWords;
        ScrollViewer sv = new ScrollViewer();
        List<string> Toateanimalele;
        List<Tranzactie> ltranzactie;
        List<string> ListaFrime=new List<string>();
        Selling[] sells;
       static Selling[] Buying;
        List<TranzactiiCumparare> lTranzactiecumparare;
        Canvas canvas2;
        ComboBox cbType = new ComboBox();
        ComboBox cbBuySell = new ComboBox();
        ComboBox cbSpecies = new ComboBox();
        ComboBox cbShipping = new ComboBox();
        ComboBox cbRegiune = new ComboBox();
        ComboBox cbSortPQ = new ComboBox();
        ComboBox cbSortAD = new ComboBox();
        TextBox numar = new TextBox();
        TextBox pret = new TextBox();
        private Canvas adaugaoferta;
        #endregion
        #region variabile Tranzactii
        Canvas MyTrades;
        ControlCuColturiRotunde Trades;
        private bool mousepresstrades = false;
        private bool mousepressbuy = false;
        private bool mousepresssell = false;
        private static bool adauga = true;
        Canvas Buy;
        ControlCuColturiRotunde CBuy;
        Canvas Sell;
        ControlCuColturiRotunde CSell;
        #endregion
        public MyTranzactii(Canvas canvas2)
        {
            Search = new Canvas();
            CreateOffer = new Canvas();
            this.canvas2 = canvas2;
            canvas2.Children.Clear();

            ControlCuColturiRotunde sus = new ControlCuColturiRotunde(canvas2, canvas2.Width - 2, 60, 0, 0, false, 1);
            sus.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            sus.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), canvas2.Width, 62);
            #region Trades
            Trades = new ControlCuColturiRotunde(canvas2, 160, 60, 0, 1, false, 1);
            Trades.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            Trades.AddTextBlock(new TextBlock(), "My Trades", 23, 20, 10, "#FF959906");
            MyTrades = Trades.intoarce();
            MyTrades.MouseEnter += new MouseEventHandler(MyTrades_MouseEnter);
            MyTrades.MouseLeave += new MouseEventHandler(MyTrades_MouseLeave);
            MyTrades.MouseLeftButtonDown += new MouseButtonEventHandler(MyTrades_MouseLeftButtonDown);
            #endregion
            #region Cbuy
            CBuy = new ControlCuColturiRotunde(canvas2, 80, 60, 162, 1, false, 1);
            CBuy.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            CBuy.AddTextBlock(new TextBlock(), "Buy", 23, 20, 10, "#FF959906");
            Buy = CBuy.intoarce();
            Buy.MouseEnter += new MouseEventHandler(Buy_MouseEnter);
            Buy.MouseLeave += new MouseEventHandler(Buy_MouseLeave);
            Buy.MouseLeftButtonDown += new MouseButtonEventHandler(Buy_MouseLeftButtonDown);
            #endregion
            #region Sell
            CSell = new ControlCuColturiRotunde(canvas2, 80, 60, 244, 1, false, 1);
            CSell.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            CSell.AddTextBlock(new TextBlock(), "Sell", 23, 20, 10, "#FF959906");
            Sell = CSell.intoarce();
            Sell.MouseEnter += new MouseEventHandler(Sell_MouseEnter);
            Sell.MouseLeave += new MouseEventHandler(Sell_MouseLeave);
            Sell.MouseLeftButtonDown += new MouseButtonEventHandler(Sell_MouseLeftButtonDown);
            #endregion
            #region Conectare Service
            try
            {
                bing.ServiceReference1.TranzactiiClient tc = new bing.ServiceReference1.TranzactiiClient(bind,endpoint);
                tc.GetToateAnimaleleAsync();
                tc.GetToateAnimaleleCompleted += new EventHandler<bing.ServiceReference1.GetToateAnimaleleCompletedEventArgs>(tc_GetToateAnimaleleCompleted);
                Toateanimalele = new List<string>();
                tc.gettranzAsync("test");
                tc.gettranzCompleted += new EventHandler<bing.ServiceReference1.gettranzCompletedEventArgs>(tc_gettranzCompleted);
                tc.GetTranzactieCumparareAsync();
                tc.GetTranzactieCumparareCompleted += new EventHandler<GetTranzactieCumparareCompletedEventArgs>(tc_GetTranzactieCumparareCompleted);
                tc.GetToateFirmeleAsync();
                tc.GetToateFirmeleCompleted += new EventHandler<GetToateFirmeleCompletedEventArgs>(tc_GetToateFirmeleCompleted);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            #endregion
            adaugaSearch();
            CRCuvant.Ascunde();
            CRRegiune.Ascunde();
            CRQA.Ascunde();
            search.Ascunde();
            lol.Ascunde();
            lupa = new Image() { Width = 28, Height = 27, Source = new BitmapImage(new Uri("DesignImages/lupa.png", UriKind.Relative)) };
            canvas2.Children.Add(lupa);
            lupa.Visibility = Visibility.Collapsed;
            Canvas.SetLeft(lupa, 10);
            Canvas.SetTop(lupa, 80);
        }

        public bing.UnitTranzactii UnitTranzactii
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        #region Service
        void tc_gettranzCompleted(object sender, bing.ServiceReference1.gettranzCompletedEventArgs e)
        {
            ltranzactie = new List<Tranzactie>(30);
            foreach (var v in e.Result)
                ltranzactie.Add(v);
        
        }
        void tc_GetToateFirmeleCompleted(object sender, GetToateFirmeleCompletedEventArgs e)
        {
          
            foreach (var v in e.Result)
                ListaFrime.Add(v);
         
        }

        void tc_GetToateAnimaleleCompleted(object sender, bing.ServiceReference1.GetToateAnimaleleCompletedEventArgs e)
        {
            foreach (var gv in e.Result)
                Toateanimalele.Add(gv);
            
        }
        void tc_GetTranzactieCumparareCompleted(object sender, GetTranzactieCumparareCompletedEventArgs e)
        {
            lTranzactiecumparare = new List<TranzactiiCumparare>(30);
           
           
            foreach (var v in e.Result)
                lTranzactiecumparare.Add(v);
            int n = 0;
            int m = 0;
            for (int j = 0; j < lTranzactiecumparare.Count;j++ )
            {
                if (lTranzactiecumparare[j].Cumparare.Substring(0,1) == "1") n++;
                else m++;
            }
             sells = new Selling[n];
             Buying = new Selling[m];
             n = m = 0;
            for (int i = 0; i < lTranzactiecumparare.Count; i++)
            {
                if (lTranzactiecumparare[i].Cumparare.Substring(0, 1) == "1")
                {
                    sells[n] = new Selling(lTranzactiecumparare[i].Nume + "\nFrom: " + lTranzactiecumparare[i].Regiune + " By: " + lTranzactiecumparare[i].Usr,
                                          lTranzactiecumparare[i].Numar.ToString(), lTranzactiecumparare[i].Pret.ToString(),
                                          lTranzactiecumparare[i].Usr, lTranzactiecumparare[i].Regiune,lTranzactiecumparare[i].ID,lTranzactiecumparare[i].Nume);
                    n++;
                }
                else
                {
                    Buying[m] = new Selling(lTranzactiecumparare[i].Nume + "\nFrom: " + lTranzactiecumparare[i].Regiune + " By: " + lTranzactiecumparare[i].Usr,
                                      lTranzactiecumparare[i].Numar.ToString(), lTranzactiecumparare[i].Pret.ToString(),
                                       lTranzactiecumparare[i].Usr, lTranzactiecumparare[i].Regiune, lTranzactiecumparare[i].ID,lTranzactiecumparare[i].Nume);
                    m++;
                }
            }

        
            
        }
        #endregion
        #region Apaspebutoanele de sus
        void adaugaSearch()
        {
            #region Keywords
            KeyWords = new TextBox();
            CRCuvant = new ControlCuColturiRotunde(canvas2, 286, 39, 50, 73, false, 1);
            CRCuvant.Colors("#FF465d6a", "#FF5c7084", new Point(0.5, 1), new Point(0.5, 0), null);
            CRCuvant.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 288, 40);
            CRCuvant.Colturi(10, 10, new Rect(0, 0, 286, 38));
            
            CRCuvant.AddTextBlock(new TextBlock(), "Keywords:", 15, 5, 10, null);
            CRCuvant.AddTextBox(KeyWords, "", 170, 30, 0, 15, "#FF000000", "#FF000000", "#FF581818", "#FFBE4141", null, true, 90, 5);
            #endregion Keywords
            #region Regiune
            try
            {
                CRRegiune = new ControlCuColturiRotunde(canvas2, 206, 39, 355, 73, false, 1);
                CRRegiune.Colors("#FF465d6a", "#FF5c7084", new Point(0.5, 1), new Point(0.5, 0), null);
                CRRegiune.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
                CRRegiune.Colturi(10, 10, new Rect(0, 0, 206, 38));
                CRRegiune.AddTextBlock(new TextBlock(), "Region :", 14, 5, 10, "#FF000000");
                string[] regiuni = new string[] { "Moldova", "Transilvania", "Dobrogea", "Oltenia", "Banat" };

                for (int i = 0; i < regiuni.Length; i++)
                {
                    ComboBoxItem cbiBuySell = new ComboBoxItem();
                    cbiBuySell.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
                    cbiBuySell.Content = regiuni[i];
                    cbiBuySell.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                    cbRegiune.Items.Add(cbiBuySell);
                }
                cbRegiune.Width = 120;
                cbRegiune.SelectedIndex = 0;
                cbRegiune.Style = (Style)Application.Current.Resources["ComboBoxStyle1"];
                CRRegiune.AddDropDown(cbRegiune, "#FF000000", "#00000000", 15, 85, 7);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            #endregion Regiune
            #region Buton Search
             search = new ControlCuColturiRotunde(canvas2, 126, 39, 580, 73, false, 1);
            search.Colors("#FF969a07", "#FF7a7d04", new Point(0.5, 1), new Point(0.5, 0), null);
            search.Border(new CornerRadius(10, 10, 10, 10), "#FF9fa13a", new Thickness(1), 128, 40);
            search.Colturi(10, 10, new Rect(0, 0, 126, 38));
            search.AddTextBlock(new TextBlock(), "Search", 17, 40, 5, "#ffe0e1c0");
            search.Cursor = Cursors.Hand;
            Search = search.intoarce();
            Search.MouseLeftButtonDown += new MouseButtonEventHandler(Search_MouseLeftButtonDown);
            #endregion Buton Search
            #region SearchDAQA
             lol = new ControlCuColturiRotunde(canvas2, 26, 29, 10, 130, false, 1);
            lol.Colors("#FF465d6a", "#FF5c7084", new Point(0.5, 1), new Point(0.5, 0), null);
            lol.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 28, 30);
            lol.Colturi(10, 10, new Rect(0, 0, 26, 28));
            chceck = lol.intoarce();
            chceck.MouseLeftButtonDown += new MouseButtonEventHandler(chceck_MouseLeftButtonDown);

             CRQA = new ControlCuColturiRotunde(canvas2, 326, 39, 50, 123, false, 1);
            CRQA.Colors("#FF465d6a", "#FF5c7084", new Point(0.5, 1), new Point(0.5, 0), null);
            CRQA.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 328, 40);
            CRQA.Colturi(10, 10, new Rect(0, 0, 326, 38));
            CRQA.AddTextBlock(new TextBlock(), "Order by :", 14, 5, 10, "#FF000000");
            string[] alege = new string[] { "Price", "Quantity" };
            for (int i = 0; i < alege.Length; i++)
            {
                ComboBoxItem cbiBuySell = new ComboBoxItem();
                cbiBuySell.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
                cbiBuySell.Content = alege[i];
                cbiBuySell.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                cbSortPQ.Items.Add(cbiBuySell);
            }
            cbSortPQ.Width = 100;
            cbSortPQ.SelectedIndex = 0;
            cbSortPQ.Style = (Style)Application.Current.Resources["ComboBoxStyle1"];
            CRQA.AddDropDown(cbSortPQ, "#FF000000", "#00000000", 15, 85, 7);
            string[] alege2 = new string[] { "Descending", "Ascending" };
            for (int i = 0; i < alege.Length; i++)
            {
                ComboBoxItem cbiBuySell = new ComboBoxItem();
                cbiBuySell.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
                cbiBuySell.Content = alege2[i];
                cbiBuySell.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                cbSortAD.Items.Add(cbiBuySell);
            }
            cbSortAD.Width = 120;
            cbSortAD.SelectedIndex = 0;
            cbSortAD.Style = (Style)Application.Current.Resources["ComboBoxStyle1"];
            CRQA.AddDropDown(cbSortAD, "#FF000000", "#00000000", 15, 175, 7);
            #endregion
        }
        void MyTrades_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 0, 3,0));
            lupa.Visibility = Visibility.Collapsed;
           
            CRCuvant.Ascunde();
            CRRegiune.Ascunde();
            CRQA.Ascunde();
            search.Ascunde();
            lol.Ascunde();
            canvas2.Children.Remove(sv);
            #region ButoanDesSusNormal
            CBuy.Children.Clear();
            CBuy.AddTextBlock(new TextBlock(), "Buy", 23, 20, 10, "#FF959906");
            CBuy.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 80, 60);
            Buy.Height = 59;
            CSell.Children.Clear();
            CSell.AddTextBlock(new TextBlock(), "Sell", 23, 20, 10, "#FF959906");
            CSell.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 80, 60);
            Sell.Height = 59;
            #endregion
            mousepresstrades = true;
            mousepressbuy = mousepresssell = false;

                try
                {
                    if (adauga == true)
                    {
                        #region Canvasu din Stanga


                        CreateOffer.Background = new SolidColorBrush(Colors.Transparent);
                        CreateOffer.Width = 200;
                        CreateOffer.Height = 400;
                        canvas2.Children.Add(CreateOffer);
                        Canvas.SetLeft(CreateOffer, 15);
                        Canvas.SetTop(CreateOffer, 100);
                        TextBlock t = new TextBlock() { Text = "Create an offer", FontSize = 17, FontFamily = new FontFamily("Tahoma"), Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x7d, 0x91, 0x96)) };
                        CreateOffer.Children.Add(t);
                        Canvas.SetLeft(t, 5);
                        Canvas.SetTop(t, 0);
                        #endregion Canvasu din stanga
                        #region SellBuy
                        ControlCuColturiRotunde CRBuySell = new ControlCuColturiRotunde(CreateOffer, 206, 39, 0, 40, false, 1);
                        CRBuySell.Colors("#FF465d6a", "#FF5c7084", new Point(0.5, 1), new Point(0.5, 0), null);
                        CRBuySell.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
                        CRBuySell.Colturi(10, 10, new Rect(0, 0, 206, 38));
                        CRBuySell.AddTextBlock(new TextBlock(), "I want to:", 15, 5, 10, null);


                        ComboBoxItem cbiBuySell = new ComboBoxItem();
                        cbiBuySell.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
                        cbiBuySell.Content = "Buy";

                        cbiBuySell.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                        cbBuySell.Width = 120;
                        cbBuySell.Items.Add(cbiBuySell);
                        cbiBuySell = new ComboBoxItem();
                        cbiBuySell.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
                        cbiBuySell.Content = "Sell";
                        cbBuySell.Items.Add(cbiBuySell);

                        cbBuySell.SelectedIndex = 0;
                        cbBuySell.Style = (Style)Application.Current.Resources["ComboBoxStyle1"];

                        CRBuySell.AddDropDown(cbBuySell, "#FF000000", "#00000000", 15, 85, 7);

                        cbBuySell.MouseEnter += new MouseEventHandler(cb_MouseEnter);
                        cbBuySell.MouseLeave += new MouseEventHandler(cb_MouseLeave);

                        #endregion BuySell
                        #region Type
                        ControlCuColturiRotunde CRType = new ControlCuColturiRotunde(CreateOffer, 206, 39, 0, 90, false, 1);
                        CRType.Colors("#FF465d6a", "#FF5c7084", new Point(0.5, 1), new Point(0.5, 0), null);
                        CRType.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
                        CRType.Colturi(10, 10, new Rect(0, 0, 206, 38));
                        CRType.AddTextBlock(new TextBlock(), "Type:", 15, 5, 10, null);




                        ComboBoxItem cbiType = new ComboBoxItem();
                        cbiType.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
                        cbiType.Content = "Fauna";
                        cbiType.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));

                        cbType.Items.Add(cbiType);

                        cbiType = new ComboBoxItem();
                        cbiType.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
                        cbiType.Content = "Vegetation";

                        cbType.Items.Add(cbiType);

                        CRType.AddDropDown(cbType, "#FF000000", "#00000000", 15, 55, 7);
                        cbType.Width = 150;
                        cbType.SelectedIndex = 0;
                        cbType.Style = (Style)Application.Current.Resources["ComboBoxStyle1"];
                        cbType.MouseEnter += new MouseEventHandler(cbType_MouseEnter);
                        cbType.MouseLeave += new MouseEventHandler(cbType_MouseLeave);
                        #endregion Type
                        #region Species
                        ControlCuColturiRotunde CRSpecies = new ControlCuColturiRotunde(CreateOffer, 206, 39, 0, 140, false, 1);
                        CRSpecies.Colors("#FF465d6a", "#FF5c7084", new Point(0.5, 1), new Point(0.5, 0), null);
                        CRSpecies.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
                        CRSpecies.Colturi(10, 10, new Rect(0, 0, 206, 38));
                        CRSpecies.AddTextBlock(new TextBlock(), "Species:", 15, 5, 10, null);

                        //string[] ss = new string[] {"sorici","ursulet","cocolino","petrescu","kek","donici","motorga","guster","petarde","ursulet 2","jjj","rexona","for men" };
                        ComboBoxItem cbiSpecies;
                        for (int i = 0; i < Toateanimalele.Count; i++)
                        {
                            cbiSpecies = new ComboBoxItem();
                            cbiSpecies.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
                            cbiSpecies.Content = Toateanimalele[i];
                            cbiSpecies.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));

                            cbSpecies.Items.Add(cbiSpecies);
                        }


                        CRSpecies.AddDropDown(cbSpecies, "#FF000000", "#00000000", 15, 75, 7);
                        cbSpecies.Width = 130;
                        //   cbSpecies.SelectedIndex = 0;
                        cbSpecies.Style = (Style)Application.Current.Resources["ComboBoxStyle1"];
                        cbSpecies.MouseEnter += new MouseEventHandler(cbSpecies_MouseEnter);
                        cbSpecies.MouseLeave += new MouseEventHandler(cbSpecies_MouseLeave);
                        #endregion Species
                        #region Quantity
                        ControlCuColturiRotunde CRQuantity = new ControlCuColturiRotunde(CreateOffer, 206, 39, 0, 190, false, 1);
                        CRQuantity.Colors("#FF465d6a", "#FF5c7084", new Point(0.5, 1), new Point(0.5, 0), null);
                        CRQuantity.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
                        CRQuantity.Colturi(10, 10, new Rect(0, 0, 206, 38));
                        CRQuantity.AddTextBlock(new TextBlock(), "Quantity:", 15, 5, 10, null);
                        CRQuantity.AddTextBox(numar, "", 100, 30, 0, 15, "#FF000000", "#FF000000", "#FF581818", "#FFBE4141", null, true, 90, 5);
                        #endregion Quantity
                        #region Price
                        ControlCuColturiRotunde CRPrice = new ControlCuColturiRotunde(CreateOffer, 206, 39, 0, 240, false, 1);
                        CRPrice.Colors("#FF465d6a", "#FF5c7084", new Point(0.5, 1), new Point(0.5, 0), null);
                        CRPrice.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
                        CRPrice.Colturi(10, 10, new Rect(0, 0, 206, 38));
                        CRPrice.AddTextBlock(new TextBlock(), "Price:", 15, 5, 10, null);
                        CRPrice.AddTextBox(pret, "", 110, 30, 0, 15, "#FF000000", "#FF000000", "#FF581818", "#FFBE4141", null, true, 50, 5);
                        #endregion Price
                        #region Shipping

                        ControlCuColturiRotunde CRShipping = new ControlCuColturiRotunde(CreateOffer, 206, 39, 0, 290, false, 1);
                        CRShipping.Colors("#FF465d6a", "#FF5c7084", new Point(0.5, 1), new Point(0.5, 0), null);
                        CRShipping.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
                        CRShipping.Colturi(10, 10, new Rect(0, 0, 206, 38));
                        CRShipping.AddTextBlock(new TextBlock(), "Shipping", 15, 5, 10, null);


                        cbShipping.Width = 120;
                        for (int i = 0; i < ListaFrime.Count; i++)
                        {
                            ComboBoxItem cbiShipping = new ComboBoxItem();
                            cbiShipping.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
                            cbiShipping.Content = ListaFrime[i];
                            cbiShipping.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                            cbShipping.Items.Add(cbiShipping);

                        }
                        cbShipping.SelectedIndex = 0;
                        cbShipping.Style = (Style)Application.Current.Resources["ComboBoxStyle1"];

                        CRShipping.AddDropDown(cbShipping, "#FF000000", "#00000000", 15, 85, 7);

                        cbShipping.MouseEnter += new MouseEventHandler(cbShipping_MouseEnter);
                        cbShipping.MouseLeave += new MouseEventHandler(cbShipping_MouseLeave);
                        #endregion Shipping
                        #region Grid

                        //DonationsDataGrid.Height = 420;
                        //DonationsDataGrid.Width = 490;
                        //DonationsDataGrid.Background = new SolidColorBrush(Colors.Black);
                        //DonationsDataGrid.RowBackground = new SolidColorBrush(Colors.Black);
                        //DonationsDataGrid.AlternatingRowBackground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1a, 0x1c, 0x1e));
                        //DonationsDataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                        //DonationsDataGrid.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;

                        //DonationsDataGrid.AutoGenerateColumns = false;

                        //Customer[] c = new Customer[ltranzactie.Count];

                        //for (int i = 0; i < ltranzactie.Count; i++)
                        //{
                        //    c[i] = new Customer("Traded " + ltranzactie[i].Numar + " " + ltranzactie[i].Nume + " with " + ltranzactie[i].Vanzator);
                        //}
                        //DonationsDataGrid.ItemsSource = c;
                        //Binding b = new Binding("FirstName");
                        //DataGridTextColumn tg = new DataGridTextColumn();
                        //tg.Width = new DataGridLength(480);
                        //tg.FontSize = 14;
                        //tg.Foreground = new SolidColorBrush(Colors.White);
                        //tg.Binding = b;

                        //DonationsDataGrid.Columns.Add(tg);

                        //canvas2.Children.Add(DonationsDataGrid);
                        //Canvas.SetLeft(DonationsDataGrid, 250);
                        //Canvas.SetTop(DonationsDataGrid, 80);

                        #endregion Grid
                        #region Buton
                        ControlCuColturiRotunde ccr = new ControlCuColturiRotunde(CreateOffer, 206, 39, 0, 340, false, 1);
                        ccr.Colors("#FF969a07", "#FF7a7d04", new Point(0.5, 1), new Point(0.5, 0), null);
                        ccr.Border(new CornerRadius(10, 10, 10, 10), "#FF9fa13a", new Thickness(1), 208, 40);
                        ccr.Colturi(10, 10, new Rect(0, 0, 206, 38));
                        ccr.AddTextBlock(new TextBlock(), "Post offer", 17, 70, 5, "#ffe0e1c0");
                        ccr.Cursor = Cursors.Hand;
                        adaugaoferta = ccr.intoarce();
                        adaugaoferta.MouseLeftButtonDown += new MouseButtonEventHandler(adaugaoferta_MouseLeftButtonDown);
                        #endregion
                        adauga = false;
                    }
                    else
                    {
                        canvas2.Children.Add(CreateOffer);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
              
          }
        void Buy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lupa.Visibility = Visibility.Visible;
            canvas2.Children.Remove(sv);
            canvas2.Children.Remove(CreateOffer);
            CRCuvant.Arata();
            CRRegiune.Arata();
            CRQA.Arata();
            search.Arata();
            lol.Arata();
            mousepressbuy = true;
            mousepresssell = mousepresstrades = false;
            Trades.Children.Clear();
            Trades.AddTextBlock(new TextBlock(), "My Trades", 23, 20, 10, "#FF959906");
            Trades.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
            MyTrades.Height = 59;
            CSell.Children.Clear();
            CSell.AddTextBlock(new TextBlock(), "Sell", 23, 20, 10, "#FF959906");
            CSell.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 80, 60);
            Sell.Height = 59;
            
            
            
           #region BazaDeDate
            sp = new StackPanel() {VerticalAlignment=VerticalAlignment.Top };
            sv = new ScrollViewer() { VerticalScrollBarVisibility = ScrollBarVisibility.Auto, Height=380, BorderThickness=new Thickness(0)};
            sv.Content = sp;
            for (int i = 0; i < Buying.Length; i++)
            {
                sp.Children.Add(new UnitTranzactii(Buying[i].numea, Buying[i].NumeRegiune, Buying[i].NumeUser.Trim(), "Airline", short.Parse(Buying[i].numar), float.Parse(Buying[i].price),Buying[i].ID,true));
            }
            canvas2.Children.Add(sv);
            #endregion BazadeDate
           
            Canvas.SetLeft(sv, 10);
            Canvas.SetTop(sv, 170);
            MyTrades.Height = 59;
        }
        void chceck_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            check = true;
        }
        void Search_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            #region Buying
            TranzactiiClient tc = new TranzactiiClient(bind,endpoint);
            ComboBoxItem regiune = (ComboBoxItem)cbRegiune.SelectedItem;
           if (check == false)
            {
                tc.CautaAsync(regiune.Content.ToString(), KeyWords.Text, 1, false, false, true);
            }
            else
            {
                ComboBoxItem DA = (ComboBoxItem)cbSortAD.SelectedItem;
            ComboBoxItem QA = (ComboBoxItem)cbSortPQ.SelectedItem;
                if(QA.Content.ToString()=="Price" && DA.Content.ToString()=="Ascending")
                {
                    tc.CautaAsync(regiune.Content.ToString(), KeyWords.Text, 1, true, true, false);
                }
                else if (QA.Content.ToString() == "Quantity" && DA.Content.ToString() == "Ascending")
                {
                    tc.CautaAsync(regiune.Content.ToString(), KeyWords.Text, 1, false, true, false);
                }
                else if (QA.Content.ToString() == "Quantity" && DA.Content.ToString() == "Descending")
                {
                    tc.CautaAsync(regiune.Content.ToString(), KeyWords.Text, 1, false, false, false);
                }
                else if (QA.Content.ToString() == "Price" && DA.Content.ToString() == "Descending")
                {
                    tc.CautaAsync(regiune.Content.ToString(), KeyWords.Text, 1, true, false, false);
                }
            }
            tc.CautaCompleted += new EventHandler<CautaCompletedEventArgs>(tc_CautaCompleted);
            #endregion
        }
        void tc_CautaCompleted(object sender, CautaCompletedEventArgs e)
        { sp.Children.Clear();
            List<TranzactiiCumparare> t = new List<TranzactiiCumparare>();
            foreach (var r in e.Result)
                t.Add(r);
            for (int i = 0; i < t.Count; i++)
            { 
               sp.Children.Add(new UnitTranzactii(t[i].Nume,t[i].Regiune,t[i].Usr.Trim(),"Airline",(short)t[i].Numar,(float)t[i].Pret,t[i].ID,true));

            }
        }
        void Sell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lupa.Visibility = Visibility.Visible;
            CRCuvant.Arata();
            CRRegiune.Arata();
            CRQA.Arata();
            search.Arata();
            lol.Arata();
            #region Schimbari design
            canvas2.Children.Remove(CreateOffer);
        //    canvas2.Children.Remove(DonationsDataGrid);
            canvas2.Children.Remove(sv);
            mousepresssell = true;
            mousepressbuy = mousepresstrades = false;
            Trades.Children.Clear();
            Trades.AddTextBlock(new TextBlock(), "My Trades", 23, 20, 10, "#FF959906");
            Trades.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
            MyTrades.Height = 59;
            CBuy.Children.Clear();
            CBuy.AddTextBlock(new TextBlock(), "Buy", 23, 20, 10, "#FF959906");
            CBuy.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 80, 60);
            Buy.Height = 59;
            #endregion
             #region BazaDeDate
            sp = new StackPanel() { VerticalAlignment = VerticalAlignment.Top };
            sv = new ScrollViewer() { VerticalScrollBarVisibility = ScrollBarVisibility.Auto, Height = 380, BorderThickness = new Thickness(0) };
            sv.Content = sp;
            for (int i = 0; i < sells.Length; i++)
            {
                sp.Children.Add(new UnitTranzactii(sells[i].numea, sells[i].NumeRegiune, sells[i].NumeUser.Trim(), "Airline", short.Parse(sells[i].numar), float.Parse(sells[i].price), sells[i].ID, false));
            }
            canvas2.Children.Add(sv);
            #endregion BazadeDate
            
            Canvas.SetLeft(sv, 10);
            Canvas.SetTop(sv, 170);
            MyTrades.Height = 59;
        }
        #endregion
        #region Evenimente ComboBoxuri
        void cbShipping_MouseLeave(object sender, MouseEventArgs e)
        {
            cbShipping.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
        }
        void cbShipping_MouseEnter(object sender, MouseEventArgs e)
        {
            cbShipping.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
        }
        void cbSpecies_MouseLeave(object sender, MouseEventArgs e)
        {
            cbSpecies.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
        }
        void cbSpecies_MouseEnter(object sender, MouseEventArgs e)
        {
            cbSpecies.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
        }
        void cbType_MouseLeave(object sender, MouseEventArgs e)
        {
            cbType.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
        }
        void cbType_MouseEnter(object sender, MouseEventArgs e)
        {
            cbType.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
        }
        void cb_MouseLeave(object sender, MouseEventArgs e)
        {
            cbBuySell.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
        }
        void cb_MouseEnter(object sender, MouseEventArgs e)
        {
            cbBuySell.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x95, 0x99, 0x06));
        }
        #endregion
        #region Evenimente  trades cbuy sell

        void Sell_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepresssell == false)
            {
                CSell.Children.Clear();
                CSell.AddTextBlock(new TextBlock(), "Sell", 23, 20, 10, "#FF959906");
                CSell.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 80, 60);
                Sell.Height = 59;
            }
        }
        void Sell_MouseEnter(object sender, MouseEventArgs e)
        {
            CSell.Children.Clear();
            CSell.AddTextBlock(new TextBlock(), "Sell", 23, 20, 10, "#FFFFFFFF");
            CSell.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 82, 61);
            Sell.Height = 63;
            
        }
        void Buy_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepressbuy == false)
            {
                CBuy.Children.Clear();
                CBuy.AddTextBlock(new TextBlock(), "Buy", 23, 20, 10, "#FF959906");
                CBuy.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 80, 60);
                Buy.Height = 59;
            }
        }
        void Buy_MouseEnter(object sender, MouseEventArgs e)
        {
            CBuy.Children.Clear();
            CBuy.AddTextBlock(new TextBlock(), "Buy", 23, 20, 10, "#FFFFFFFF");
            CBuy.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 82, 61);
            Buy.Height = 63;
          
        }
        void MyTrades_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepresstrades == false)
            {
                Trades.Children.Clear();
                Trades.AddTextBlock(new TextBlock(), "My Trades", 23, 20, 10, "#FF959906");
                Trades.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
                MyTrades.Height = 59;
            }
        }
        void MyTrades_MouseEnter(object sender, MouseEventArgs e)
        {
            Trades.Children.Clear();
            Trades.AddTextBlock(new TextBlock(), "My Trades", 23, 20, 10, "#FFFFFFFF");
            Trades.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 162, 61);
            MyTrades.Height = 63;
           
        }
        #endregion
        void adaugaoferta_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TranzactiiClient tc = new TranzactiiClient();
            ComboBoxItem cSpecii = (ComboBoxItem)cbSpecies.SelectedItem;
            ComboBoxItem cBuySell = (ComboBoxItem)cbBuySell.SelectedItem;
            ComboBoxItem cFirma = (ComboBoxItem)cbShipping.SelectedItem;
            if (cBuySell.Content.ToString() == "Sell")
            {//le introduce lu buying
                tc.AddTranzactieAsync("test", cSpecii.Content.ToString(), int.Parse(numar.Text), cFirma.Content.ToString(), int.Parse(pret.Text), "1", "NULL");
            }
            else
            {
                tc.AddTranzactieAsync("test", cSpecii.Content.ToString(), int.Parse(numar.Text), cFirma.Content.ToString(), int.Parse(pret.Text), "NULL", "1");
            }
            tc.AddTranzactieCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(tc_AddTranzactieCompleted);
           
        }
        void tc_AddTranzactieCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("au fost adaugate");
        }
    }
    public  class Customer
    {
        public  String FirstName { get; set; }
        public Customer(string firstName)
        {
            this.FirstName = firstName;
            
        }

      
       
    }
    public class Selling

    {
        public string NumeAnimal{get; set;}
        public string numea { get; set; }
        public string numar{get;set;}
        public string price{get;set;}
        public string NumeUser{get; set;}
        public string NumeRegiune{get;set;}
        public int ID { get; set; }
        public Selling()
        { }
        public Selling(string NumeAnimal,string  numar,string price,string NumeUser,string NumeRegiune,int id,string numea)
        {
            this.NumeAnimal=NumeAnimal;
            this.NumeRegiune=NumeRegiune;
            this.numar=numar;
            this.price=price;
            this.NumeUser=NumeUser;
            this.ID = id;
            this.numea = numea;
        }
     
    }
}