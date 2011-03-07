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
using Microsoft.Maps.MapControl;
using System.Windows.Controls.Primitives;
using bing.Forme;

namespace bing
{
    public class Writer2
    {
        public Writer2() { }
        public Writer2(string writerName, int numOfTypes)
        {
            Name = writerName;
            Types = numOfTypes;
        }
        public string Name { get; set; }
        public int Types { get; set; }
    }
    public partial class Info : UserControl
    {
        private bool mousepressjudetstanga = false;
        private bool mousepressmijloc = false;
        private bool mousepressdreapta = false;
        Canvas CanvasGoBack;
        ControlCuColturiRotunde ControlGoBack;
        ControlCuColturiRotunde ControlJudetStanga;
        Canvas CanvasjudetStanga;
        Canvas CanvasjudetMijloc;
        ControlCuColturiRotunde ControlJudetMijloc;
        Canvas Canvasjudetdreapta;
        ControlCuColturiRotunde ControlJudetDreapta;
        List<bing.ServiceReference1.ProceduraRealJudet_Result> lista2 = new List<ServiceReference1.ProceduraRealJudet_Result>();
        int WidthLeng1=0;
        int WidthLeng2=0;
        int WidthLeng3=0;
        Map m;
        Canvas can;
        Popup popup;

        public Info(List<bing.ServiceReference1.ProceduraRealJudet_Result> lista,int number,Map m,Canvas can)
        {
            this.m = m;
            this.can = can;
            // Caut buton-ul de back printre Copiii lui Canvas si il retin
            // pentru a-l adauga la iesirea din meniul Info
            foreach (UIElement child in can.Children.ToArray())
            {
                if (child.GetType().ToString() == "System.Windows.Controls.Primitives.Popup")
                {
                    popup = (Popup)child;
                }
            }
            can.Children.Clear();

            System.Collections.ObjectModel.ObservableCollection<Writer2> W2 = new System.Collections.ObjectModel.ObservableCollection<Writer2>();
            InitializeComponent();
            foreach (var c in lista)
            {
                if (c.ID == number)
                {
                    lista2.Add(c);
                    
                }
            }
          //  double d = double.Parse(lista2[0].CalitateAer.ToString());
            Rectangle.Width = (double.Parse(lista2[0].CalitateAer.ToString()) * 147) / 5;
            textBlockQ.Text = lista2[0].CalitateAer.ToString();
            Rectangle2.Width = (double.Parse(lista2[0].PoluareSol.ToString()) * 147) / 500000;
            textBlockS.Text = lista2[0].PoluareSol.ToString();
            #region Textblockuri
            try
            {
                foresttextBlock.Text = lista2[0].ProcentPadure.ToString();
                naturalRtextBlock.Text = lista2[0].RezervatiiNaturale.ToString();
                nationalparktextBlock.Text = lista2[0].ParcuriNationale.ToString();
                towntextBlock.Text = lista2[0].NrOrase.ToString();
                ExtractiveItextBlock.Text = lista2[0].IndustriaExtractiva.ToString();
                processingItextBlock.Text = lista2[0].IndustriaPrelucrativa.ToString();
                powerplantstextBlock.Text = lista2[0].NrTermocentrale.ToString();
                hydropowertextblock.Text = lista2[0].NrHidrocentrale.ToString();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
            #endregion
            W2.Add(new Writer2("National Parks",int.Parse(lista2[0].ParcuriNationale.ToString())));
            W2.Add(new Writer2("Forest", (int)lista2[0].ProcentPadure));
            W2.Add(new Writer2("Natural Reservations",lista2[0].RezervatiiNaturale));
            W2.Add(new Writer2("Towns", lista2[0].NrOrase));
            
          
           myPie.DataContext = W2;

            ControlCuColturiRotunde sus = new ControlCuColturiRotunde(LayoutRoot, LayoutRoot.Width - 2, 60, 0, 0, false, 1);
            sus.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            sus.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), LayoutRoot.Width, 62);

            ControlGoBack = new ControlCuColturiRotunde(LayoutRoot, 146, 39, 570, 10, true, 1);
            ControlGoBack.AddTextBlock(new TextBlock(), "back to main zone", 14, 10, 5, "#FF959906");
            ControlGoBack.Border(new CornerRadius(10, 10, 10, 10), "#FF9fa13a", new Thickness(1), 148, 40);
            ControlGoBack.Colturi(10, 10, new Rect(0, 0, 146, 38));
            
            CanvasGoBack = ControlGoBack.intoarce();
            CanvasGoBack.MouseEnter += new MouseEventHandler(CanvasGoBack_MouseEnter);
            CanvasGoBack.MouseLeave += new MouseEventHandler(CanvasGoBack_MouseLeave);
            CanvasGoBack.MouseLeftButtonDown += new MouseButtonEventHandler(CanvasGoBack_MouseLeftButtonDown);
            #region Stanga
            WidthLeng1 = 8 * lista2[0].Nume.Length;
            ControlJudetStanga = new ControlCuColturiRotunde(LayoutRoot, WidthLeng1, 60, 0, 1, false, 1);
            ControlJudetStanga.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            ControlJudetStanga.AddTextBlock(new TextBlock(), lista2[0].Nume, 23, 20, 10, "#FF959906");
            CanvasjudetStanga = ControlJudetStanga.intoarce();
            CanvasjudetStanga.MouseEnter += new MouseEventHandler(MyTrades_MouseEnter);
            CanvasjudetStanga.MouseLeave += new MouseEventHandler(MyTrades_MouseLeave);
            CanvasjudetStanga.MouseLeftButtonDown += new MouseButtonEventHandler(CanvasjudetStanga_MouseLeftButtonDown);
            #endregion
            #region Mijloc
            if (lista2.Count >= 2)
            {
                WidthLeng2 = 8 * lista2[1].Nume.Length;
                ControlJudetMijloc = new ControlCuColturiRotunde(LayoutRoot, WidthLeng2, 60, WidthLeng1+2, 1, false, 1);
                ControlJudetMijloc.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
                ControlJudetMijloc.AddTextBlock(new TextBlock(), lista2[1].Nume, 23, 20, 10, "#FF959906");
                CanvasjudetMijloc = ControlJudetMijloc.intoarce();
                CanvasjudetMijloc.MouseEnter += new MouseEventHandler(Buy_MouseEnter);
                CanvasjudetMijloc.MouseLeave += new MouseEventHandler(Buy_MouseLeave);
            }
            CanvasjudetMijloc.MouseLeftButtonDown += new MouseButtonEventHandler(CanvasjudetMijloc_MouseLeftButtonDown);
            #endregion
            #region Dreapta
            if (lista2.Count >= 3)
            {
                WidthLeng3 = 8 * lista2[2].Nume.Length;
                ControlJudetDreapta = new ControlCuColturiRotunde(LayoutRoot, WidthLeng3, 60,WidthLeng1+ WidthLeng2+4, 1, false, 1);
                ControlJudetDreapta.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
                ControlJudetDreapta.AddTextBlock(new TextBlock(), lista2[2].Nume, 23, 20, 10, "#FF959906");
                Canvasjudetdreapta = ControlJudetDreapta.intoarce();
                Canvasjudetdreapta.MouseEnter += new MouseEventHandler(Sell_MouseEnter);
                Canvasjudetdreapta.MouseLeave += new MouseEventHandler(Sell_MouseLeave);
                Canvasjudetdreapta.MouseLeftButtonDown += new MouseButtonEventHandler(Canvasjudetdreapta_MouseLeftButtonDown);
            }
            #endregion
        }

        void CanvasGoBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            can.Children.Clear();
            can.Children.Add(m);

            // Alex
            // Add the Back Button
            CBackButton.getInstance().addButtonToCanvas();

            // Add the border
            MainPage.getInstance().canvas2.Children.Add(MainPage.getInstance().mainBorder);
        }

        void CanvasGoBack_MouseLeave(object sender, MouseEventArgs e)
        {
            ControlGoBack.AddTextBlock(new TextBlock(), "back to main zone", 14, 10, 5, "#FF959906");
        }

        void CanvasGoBack_MouseEnter(object sender, MouseEventArgs e)
        {
            ControlGoBack.AddTextBlock(new TextBlock(), "back to main zone", 14, 10, 5, "#FFFFFFFF");
        }

      

        void CanvasjudetMijloc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Collections.ObjectModel.ObservableCollection<Writer2> W2 = new System.Collections.ObjectModel.ObservableCollection<Writer2>();
            mousepressmijloc = true;
            mousepressjudetstanga = mousepressdreapta = false;
            ControlJudetStanga.Children.Clear();
            ControlJudetStanga.AddTextBlock(new TextBlock(),lista2[0].Nume, 23, 20, 10, "#FF959906");
            ControlJudetStanga.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
            CanvasjudetStanga.Height = 59;
            if (lista2.Count >= 3)
            {
                ControlJudetDreapta.Children.Clear();
                ControlJudetDreapta.AddTextBlock(new TextBlock(), lista2[2].Nume, 23, 20, 10, "#FF959906");
                ControlJudetDreapta.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
                Canvasjudetdreapta.Height = 59;
            }
            foresttextBlock.Text = lista2[1].ProcentPadure.ToString();
            naturalRtextBlock.Text = lista2[1].RezervatiiNaturale.ToString();
            nationalparktextBlock.Text = lista2[1].ParcuriNationale.ToString();
            towntextBlock.Text = lista2[0].NrOrase.ToString();
            ExtractiveItextBlock.Text = lista2[1].IndustriaExtractiva.ToString();
            processingItextBlock.Text = lista2[1].IndustriaPrelucrativa.ToString();
            powerplantstextBlock.Text = lista2[1].NrTermocentrale.ToString();
            hydropowertextblock.Text = lista2[1].NrHidrocentrale.ToString();
            W2.Add(new Writer2("National Parks", int.Parse(lista2[1].ParcuriNationale.ToString())));
            W2.Add(new Writer2("Forest", (int)lista2[1].ProcentPadure));
            W2.Add(new Writer2("Natural Reservations", lista2[1].RezervatiiNaturale));
            W2.Add(new Writer2("Towns", lista2[1].NrOrase));

            Rectangle.Width = (double.Parse(lista2[1].CalitateAer.ToString()) * 147) / 5;
            textBlockQ.Text = lista2[1].CalitateAer.ToString();
            Rectangle2.Width = (double.Parse(lista2[1].PoluareSol.ToString()) * 147) / 500000;
            textBlockS.Text = lista2[1].PoluareSol.ToString();
            myPie.DataContext = W2;
        }

        void CanvasjudetStanga_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Collections.ObjectModel.ObservableCollection<Writer2> W2 = new System.Collections.ObjectModel.ObservableCollection<Writer2>();
            #region ButoanDesSusNormal
            mousepressjudetstanga = true;
            mousepressdreapta = mousepressmijloc = false;
            ControlJudetMijloc.Children.Clear();
            ControlJudetMijloc.AddTextBlock(new TextBlock(), lista2[1].Nume, 23, 20, 10, "#FF959906");
            ControlJudetMijloc.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
            CanvasjudetMijloc.Height = 59;
            if (lista2.Count >= 3)
            {
                ControlJudetDreapta.Children.Clear();
                ControlJudetDreapta.AddTextBlock(new TextBlock(), lista2[2].Nume, 23, 20, 10, "#FF959906");
                ControlJudetDreapta.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
                Canvasjudetdreapta.Height = 59;
            }
            #endregion
            foresttextBlock.Text = lista2[0].ProcentPadure.ToString();
            naturalRtextBlock.Text = lista2[0].RezervatiiNaturale.ToString();
            nationalparktextBlock.Text = lista2[0].ParcuriNationale.ToString();
            towntextBlock.Text = lista2[0].NrOrase.ToString();
            ExtractiveItextBlock.Text = lista2[0].IndustriaExtractiva.ToString();
            processingItextBlock.Text = lista2[0].IndustriaPrelucrativa.ToString();
            powerplantstextBlock.Text = lista2[0].NrTermocentrale.ToString();
            hydropowertextblock.Text = lista2[0].NrHidrocentrale.ToString();
            W2.Add(new Writer2("National Parks", int.Parse(lista2[0].ParcuriNationale.ToString())));
            W2.Add(new Writer2("Forest", (int)lista2[0].ProcentPadure));
            W2.Add(new Writer2("Natural Reservations", lista2[0].RezervatiiNaturale));
            W2.Add(new Writer2("Towns", lista2[0].NrOrase));
            Rectangle.Width = (double.Parse(lista2[0].CalitateAer.ToString()) * 147) / 5;
            textBlockQ.Text = lista2[0].CalitateAer.ToString();
            Rectangle2.Width = (double.Parse(lista2[0].PoluareSol.ToString()) * 147) / 500000;
            textBlockS.Text = lista2[0].PoluareSol.ToString();
            myPie.DataContext = W2;
        }
        void Canvasjudetdreapta_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Collections.ObjectModel.ObservableCollection<Writer2> W2 = new System.Collections.ObjectModel.ObservableCollection<Writer2>();
          
            mousepressdreapta = true;
            mousepressjudetstanga = mousepressmijloc = false;
            ControlJudetStanga.Children.Clear();
            ControlJudetStanga.AddTextBlock(new TextBlock(), lista2[0].Nume, 23, 20, 10, "#FF959906");
            ControlJudetDreapta.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
            CanvasjudetStanga.Height = 59;
            ControlJudetMijloc.Children.Clear();
            ControlJudetMijloc.AddTextBlock(new TextBlock(), lista2[1].Nume, 23, 20, 10, "#FF959906");
            ControlJudetMijloc.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), 160, 60);
            CanvasjudetMijloc.Height = 59;

            ControlJudetDreapta.Children.Clear();
            ControlJudetDreapta.AddTextBlock(new TextBlock(), lista2[2].Nume, 23, 20, 10, "#FFFFFFFF");
            ControlJudetDreapta.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), WidthLeng3 + 2, 61);
            Canvasjudetdreapta.Height = 63;

            foresttextBlock.Text = lista2[2].ProcentPadure.ToString();
            naturalRtextBlock.Text = lista2[2].RezervatiiNaturale.ToString();
            nationalparktextBlock.Text = lista2[2].ParcuriNationale.ToString();
            towntextBlock.Text = lista2[2].NrOrase.ToString();
            ExtractiveItextBlock.Text = lista2[2].IndustriaExtractiva.ToString();
            processingItextBlock.Text = lista2[2].IndustriaPrelucrativa.ToString();
            powerplantstextBlock.Text = lista2[2].NrTermocentrale.ToString();
            hydropowertextblock.Text = lista2[2].NrHidrocentrale.ToString();
            W2.Add(new Writer2("National Parks", int.Parse(lista2[2].ParcuriNationale.ToString())));
            W2.Add(new Writer2("Forest", (int)lista2[2].ProcentPadure));
            W2.Add(new Writer2("Natural Reservations", lista2[2].RezervatiiNaturale));
            W2.Add(new Writer2("Towns", lista2[2].NrOrase));
            Rectangle.Width = (double.Parse(lista2[2].CalitateAer.ToString()) * 147) / 5;
            textBlockQ.Text = lista2[2].CalitateAer.ToString();
            Rectangle2.Width = (double.Parse(lista2[2].PoluareSol.ToString()) * 147) / 500000;
            textBlockS.Text = lista2[2].PoluareSol.ToString();
            myPie.DataContext = W2;
        }
        #region MouseEnter/Leaver
        void MyTrades_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepressjudetstanga == false)
            {
                ControlJudetStanga.Children.Clear();
                ControlJudetStanga.AddTextBlock(new TextBlock(), lista2[0].Nume, 23, 20, 10, "#FF959906");
                ControlJudetStanga.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), WidthLeng1, 60);
                CanvasjudetStanga.Height = 59;
            }
        }
        void MyTrades_MouseEnter(object sender, MouseEventArgs e)
        {
            ControlJudetStanga.Children.Clear();
            ControlJudetStanga.AddTextBlock(new TextBlock(), lista2[0].Nume, 23, 20, 10, "#FFFFFFFF");
            ControlJudetStanga.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), WidthLeng1+2, 61);
            CanvasjudetStanga.Height = 63;

        }
        void Buy_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepressmijloc == false)
            {
                ControlJudetMijloc.Children.Clear();
                ControlJudetMijloc.AddTextBlock(new TextBlock(), lista2[1].Nume, 23, 20, 10, "#FF959906");
                ControlJudetMijloc.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), WidthLeng2, 60);
                CanvasjudetMijloc.Height = 59;
            }
        }
        void Buy_MouseEnter(object sender, MouseEventArgs e)
        {
            ControlJudetMijloc.Children.Clear();
            ControlJudetMijloc.AddTextBlock(new TextBlock(), lista2[1].Nume, 23, 20, 10, "#FFFFFFFF");
            ControlJudetMijloc.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), WidthLeng2+2, 61);
            CanvasjudetMijloc.Height = 63;

        }
        void Sell_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mousepressdreapta == false)
            {
                ControlJudetDreapta.Children.Clear();
                ControlJudetDreapta.AddTextBlock(new TextBlock(), lista2[2].Nume, 23, 20, 10, "#FF959906");
                ControlJudetDreapta.Border(new CornerRadius(0, 0, 0, 0), "#00000000", new Thickness(1), WidthLeng3, 60);
                Canvasjudetdreapta.Height = 59;
            }
        }
        void Sell_MouseEnter(object sender, MouseEventArgs e)
        {
            
            ControlJudetDreapta.Children.Clear();
            ControlJudetDreapta.AddTextBlock(new TextBlock(), lista2[2].Nume, 23, 20, 10, "#FFFFFFFF");
            ControlJudetDreapta.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), WidthLeng3+2, 61);
            Canvasjudetdreapta.Height = 63;
        }
        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
