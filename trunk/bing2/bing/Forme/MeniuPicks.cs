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
using System.Windows.Media.Imaging;
using bing.testService;
using System.Collections.Generic;
using System.ServiceModel;
using bing.Forme;

namespace Forme
{
    /// <summary>
    /// Meniul unde alegi animale plante,vine peste harta
    /// </summary>
    public class MeniuPicks:Canvas
    {
        private Image[] img = new Image[6];
        private static int imagecount = 0;
        private static short  imgcount=0;
        Polygon polygonInainte;
        Polygon polygonInapoi;
        private string[] poze;
        Canvas myMeniuPicksCanvas;
        Canvas MeniuDreapta;
        List<getAnimalStats_Result> listAnimalHistory = new List<getAnimalStats_Result>();
        List<getPlantHistory_Result> listPlantHistory = new List<getPlantHistory_Result>();

        static BasicHttpBinding bind = new BasicHttpBinding();
        static EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Service1.svc");
        bing.testService.Service1Client wcf = new bing.testService.Service1Client(bind, endpoint);

        Canvas parent;
        int width;
        int height;
        double opacity;
        double left;
        double top;
        ADDPozaCuBorder p;
        int isFromPadure = 1;
        bool animalSelected = true;
       
        /// <summary>
        /// Panelul e rascucit asa ca 0,0 este in dreapta sus
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color">e transparent oricum:P</param>
        /// <param name="opacity"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public MeniuPicks(Canvas canvas,int width,int height,string color,double opacity,double left,double top,Canvas Md)
        {

            parent = canvas;
            this.width = width;
            this.height = height;
            this.opacity = opacity;
            this.left = left;
            this.top = top;

            MeniuDreapta = Md;

            // Verific daca sunt in padure sau campie
            string zona = Animalule.getRegion();
            if (zona == "Padure") isFromPadure = 1;
            else if (zona == "Campie") isFromPadure = 0;

            // initializez Meniul
            initialize();
         
            ////HOLBANU
            //wcf.GetAnimalByIDCompleted += new EventHandler<bing.testService.GetAnimalByIDCompletedEventArgs>(wcf_GetAnimalByIDCompleted);
            //wcf.GetTop3IstoricAnimaleForUserXCompleted += new EventHandler<GetTop3IstoricAnimaleForUserXCompletedEventArgs>(wcf_GetTop3IstoricAnimaleForUserXCompleted);
            
            // Afisez animalele
            showAnimals();
        }

        /*
         * Initializez Canvas-ul meniului
         * Folosit si pentru a reseta Canvas-ul
         * */
        void initialize()
        {
            myMeniuPicksCanvas = new Canvas();
            myMeniuPicksCanvas.Width = width;
            myMeniuPicksCanvas.Height = height;
            myMeniuPicksCanvas.Background = new SolidColorBrush(Colors.Transparent);
            PlaneProjection ff = new PlaneProjection();
            ff.RotationY = 180;
            myMeniuPicksCanvas.Projection = ff;
            myMeniuPicksCanvas.Opacity = opacity;
            parent.Children.Add(myMeniuPicksCanvas);
            Canvas.SetLeft(myMeniuPicksCanvas, left);
            Canvas.SetTop(myMeniuPicksCanvas, top);
            #region butoninainte
            polygonInainte = new Polygon();
            polygonInainte.Opacity = 0.9;
            polygonInainte.Points = new PointCollection() { new Point(30, 50), new Point(40, 40), new Point(37, 50), new Point(40, 60), };
            polygonInainte.Fill = new SolidColorBrush(Colors.Yellow);
            polygonInainte.StrokeThickness = 2;
            polygonInainte.MouseLeftButtonDown += new MouseButtonEventHandler(polygon_MouseLeftButtonDown);
            //polygonInainte.MouseEnter += new MouseEventHandler(polygonInainte_MouseEnter);
            polygonInainte.Stroke = new SolidColorBrush(Colors.Gray);
            myMeniuPicksCanvas.Children.Add(polygonInainte);
            #endregion
            #region butoninapoi
            polygonInapoi = new Polygon();
            polygonInapoi.Opacity = 0.5;
            polygonInapoi.Points = new PointCollection() { new Point(640, 50), new Point(630, 40), new Point(633, 50), new Point(630, 60), };
            polygonInapoi.Fill = new SolidColorBrush(Colors.Red);
            polygonInapoi.StrokeThickness = 2;
            polygonInapoi.MouseLeftButtonDown += new MouseButtonEventHandler(polygonInapoi_MouseLeftButtonDown);
            polygonInapoi.Stroke = new SolidColorBrush(Colors.Gray);
            myMeniuPicksCanvas.Children.Add(polygonInapoi);
            #endregion
        }

        /*
         * Preia istoricul animalului selectat din baza de date
         * */
        void MeniuPicks_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage bi = (BitmapImage)((Image)sender).Source;
            Uri uri = bi.UriSource;

            if (animalSelected)
                wcf.getAnimalHistoryFromDBAsync(11, uri.OriginalString);
            else
                wcf.getPlantHistoryFromDBAsync(11, uri.OriginalString);

        }

        /*
         * Afiseaza urmatorul element din meniu
         * */
        void polygon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            if (imagecount < poze.Length-1)
            {
                // Sterg pozele cu border cu tot si le refac
                myMeniuPicksCanvas.Children.Clear();
                initialize();

                int i = 0;
                imgcount = 0;
                for (i = imagecount - 4; i <= imagecount + 1; i++,imgcount++)
                {
                    //img[imgcount].Source = new BitmapImage(new Uri(poze[i], UriKind.Relative));
                    img[imgcount] = new Image();
                    img[imgcount].MouseLeftButtonDown += MeniuPicks_MouseLeftButtonDown;
                    p = new ADDPozaCuBorder(myMeniuPicksCanvas, img[imgcount], 70, 70, poze[i], 520 - 90 * imgcount, 15);
                    p.Border(new CornerRadius(2, 2, 2, 2), ConvertToColor("#FFFFFFFF"), new Thickness(2), 71, 71);
                }
                imagecount++;
                if(imagecount >= poze.Length-1)
                {
                polygonInainte.Stroke = new SolidColorBrush(Colors.Gray);
                polygonInainte.Fill = new SolidColorBrush(Colors.Red);
                polygonInainte.Opacity = 0.5;
                }
                polygonInapoi.Stroke = new SolidColorBrush(Colors.Gray);
                polygonInapoi.Fill = new SolidColorBrush(Colors.Yellow);
                polygonInapoi.Opacity = 0.9;
            }
           
        }

        /*
         * Afiseaza elementul anterior din meniu
         * */
        void polygonInapoi_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imagecount-5>0)
            {
                imgcount = 0;
                for (int i = imagecount - 6; i < imagecount; i++,imgcount++)
                {
                    img[imgcount].Source = new BitmapImage(new Uri(poze[i], UriKind.Relative));
                }
                imagecount--;
                if(imagecount-5==0)
                {
               polygonInapoi.Stroke = new SolidColorBrush(Colors.Gray);
                polygonInapoi.Fill = new SolidColorBrush(Colors.Red);
                polygonInapoi.Opacity = 0.5;
                }
                polygonInainte.Stroke = new SolidColorBrush(Colors.Gray);
                polygonInainte.Fill = new SolidColorBrush(Colors.Yellow);
                polygonInainte.Opacity = 0.9;
            }
        }

        /*
         * Converteste string in Color
         * */
        private Color ConvertToColor(string colorString)
        {
            byte a = 255;

            byte r = (byte)(Convert.ToUInt32(colorString.Substring(3, 2), 16));
            byte g = (byte)(Convert.ToUInt32(colorString.Substring(5, 2), 16));
            byte b = (byte)(Convert.ToUInt32(colorString.Substring(7, 2), 16));
            return Color.FromArgb(a, r, g, b);
        }

        /*
         * Afiseaza animalele
         * */
        public void showAnimals()
        {
            wcf.GetAnimalFromDBCompleted += new EventHandler<GetAnimalFromDBCompletedEventArgs>(wcf_GetAnimalFromDBCompleted);
            wcf.getAnimalHistoryFromDBCompleted += new EventHandler<getAnimalHistoryFromDBCompletedEventArgs>(wcf_getAnimalHistoryFromDBCompleted);
            animalSelected = true;
            
            try
            {
                wcf.GetAnimalFromDBAsync(isFromPadure);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
         *  Construieste lista cu pozele animalelor adaugand URL-ul
         * */
        void wcf_GetAnimalFromDBCompleted(object sender, GetAnimalFromDBCompletedEventArgs e)
        {
            List<SelectAnimal_Result> listaTest = new List<SelectAnimal_Result>();
            foreach (var a in e.Result)
                listaTest.Add(a);

            // Verific daca am mai putin de 6 poze
            if (listaTest.Count < 6)
            {
                poze = new string[6];
                poze.Initialize();
            }
            else
                poze = new string[listaTest.Count];

            for (int i = 0; i < listaTest.Count; i++)
            {
                if (listaTest[i].Imagine1 != null)
                {
                    poze[i] = listaTest[i].Imagine1.ToString();
                }
                else
                {
                    poze[i] = "null";
                }
            }

            myMeniuPicksCanvas.Children.Clear();
            initialize();
            adaugaPoze();
        }

        /*
         * Afiseaza istoricul animalului in meniul din stanga
         * */
        void wcf_getAnimalHistoryFromDBCompleted(object sender, getAnimalHistoryFromDBCompletedEventArgs e)
        {
            listAnimalHistory.Clear();
            foreach (var a in e.Result)
                listAnimalHistory.Add(a);

            MeniuAnimal ss;
            if (listAnimalHistory.Count > 0)
                ss = new MeniuAnimal(MeniuDreapta, "Moldova", "Subregiune1", "Padure", listAnimalHistory,parent);
        }

        /*
         * Afiseaza plantele
         * */
        public void showPlants()
        {
            wcf.getPlantsFromDBCompleted += new EventHandler<getPlantsFromDBCompletedEventArgs>(wcf_getPlantsFromDBCompleted);
            wcf.getPlantHistoryFromDBCompleted += new EventHandler<getPlantHistoryFromDBCompletedEventArgs>(wcf_getPlantHistoryFromDBCompleted);
            animalSelected = false;
            
            try
            {
                wcf.getPlantsFromDBAsync(isFromPadure);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
         * Preia istoricul plantei din baza de date
         * Afiseaza informatiile in meniul din stanga
         * */
        void wcf_getPlantHistoryFromDBCompleted(object sender, getPlantHistoryFromDBCompletedEventArgs e)
        {
            listPlantHistory.Clear();
            foreach (var a in e.Result)
                listPlantHistory.Add(a);

            // Afiseaza istoricul in meniul din stanga
            if (listPlantHistory.Count > 0)
            {
                new MeniuPlanta(MeniuDreapta, "Moldova", "Subregiune1", "Padure", listPlantHistory); 
            }
        }

        /*
         *  Construieste lista cu pozele plantelor adaugand URL-ul
         * */
        void wcf_getPlantsFromDBCompleted(object sender, getPlantsFromDBCompletedEventArgs e)
        {
            List<getPlants_Result> listaTest = new List<getPlants_Result>();
            foreach (var a in e.Result)
                listaTest.Add(a);

            // Verific daca am mai putin de 6 poze
            if (listaTest.Count < 6)
            {
                poze = new string[6];
                poze.Initialize();
            }
            else
                poze = new string[listaTest.Count];

            for (int i = 0; i < listaTest.Count; i++)
            {
                if (listaTest[i].Imagine1 != null)
                {
                    poze[i] = listaTest[i].Imagine1.ToString();
                }
                else
                {
                    poze[i] = "null";
                }
            }

            myMeniuPicksCanvas.Children.Clear();
            initialize();
            adaugaPoze();
        }

        /**
         * Adauga poze in meniu
         * */
        void adaugaPoze()
        {
            img[0] = new Image();
            img[0].MouseLeftButtonDown += new MouseButtonEventHandler(MeniuPicks_MouseLeftButtonDown);
            ADDPozaCuBorder p = new ADDPozaCuBorder(myMeniuPicksCanvas, img[0], 70, 70, poze[0], 520, 15);
            p.Border(new CornerRadius(2, 2, 2, 2), ConvertToColor("#FFFFFFFF"), new Thickness(2), 71, 71);
            for (int i = 1; i < 6; i++)
            {

                img[i] = new Image();
                img[i].MouseLeftButtonDown += MeniuPicks_MouseLeftButtonDown;
                p = new ADDPozaCuBorder(myMeniuPicksCanvas, img[i], 70, 70, poze[i], 520 - 90 * i, 15);
                p.Border(new CornerRadius(2, 2, 2, 2), ConvertToColor("#FFFFFFFF"), new Thickness(2), 71, 71);
            }
            imagecount = 5;
        }

        /*
         * Ar trebui sa afiseze urmatorul element din meniu
         * cat timp mouse-ul intersecteaza sageata dreapta
         * 
         * Nu parcurge decat un element
         * */
        void polygonInainte_MouseEnter(object sender, MouseEventArgs e)
        {
            if (imagecount < poze.Length - 1)
            {
                int i = 0;
                imgcount = 0;
                for (i = imagecount - 4; i <= imagecount + 1; i++, imgcount++)
                {
                    img[imgcount].Source = new BitmapImage(new Uri(poze[i], UriKind.Relative));
                }
                imagecount++;
                if (imagecount >= poze.Length - 1)
                {
                    polygonInainte.Stroke = new SolidColorBrush(Colors.Gray);
                    polygonInainte.Fill = new SolidColorBrush(Colors.Red);
                    polygonInainte.Opacity = 0.5;
                }
                polygonInapoi.Stroke = new SolidColorBrush(Colors.Gray);
                polygonInapoi.Fill = new SolidColorBrush(Colors.Yellow);
                polygonInapoi.Opacity = 0.9;
            }
        }

        //List<IstoricAnimalPadureForUserX> templ;
        //HOLBAN
        //Animale temp;
        //void wcf_GetTop3IstoricAnimaleForUserXCompleted(object sender, GetTop3IstoricAnimaleForUserXCompletedEventArgs e)
        //{
        //    templ = new List<IstoricAnimalPadureForUserX>(3);
        //    foreach (var v in e.Result)
        //    {
        //        templ.Add(v);
        //    }
        //    MeniuAnimal add;

        //    if (temp != null)
        //        add = new MeniuAnimal(MeniuDreapta, "Moldova", "Moldova2", "Padure", temp, templ);
        //}
        //void wcf_GetAnimalByIDCompleted(object sender, bing.testService.GetAnimalByIDCompletedEventArgs e)
        //{
        //    temp = (Animale)e.Result;
        //    MeniuAnimal add;
        //    if (templ != null)
        //        add = new MeniuAnimal(MeniuDreapta, "Moldova", "Moldova2", "Padure", temp, templ);
        //}
    }
}
