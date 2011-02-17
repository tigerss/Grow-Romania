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
using bing.ServiceReference2;
using System.Windows.Data;
using bing.testService;

namespace bing
{
    public partial class campanii : UserControl
    {
        Canvas camp;
        int id;
        string textDescriere;
        String[] S = new String[10];//retin fotografiile
        public campanii()
        {
            InitializeComponent();
        }
        public campanii(string needs,string region, string name,int id,float total, string descriere, String[] Img)
        {
           
            InitializeComponent();
            NeedsBlock.Text = needs;
            totalMoneyTextBlock.Text = total.ToString();
            regiuneTextBlock.Text = region;
            numeCampanieTextBlock.Text = name;
            this.id = id;
            S = Img;
            textDescriere = descriere;
            Line L = new Line();
            Linie L1 = new Linie(1, 1, linieCanvas.Width, 1, "#FF717577", 1, linieCanvas, L);

            ControlCuColturiRotunde canvasforbutton = new ControlCuColturiRotunde(butonCanvas, 70, 34, 0, 0, false, 1);
            canvasforbutton.Colors("#FF969a07", "#FF7a7d04", new Point(0.5, 1), new Point(0.5, 0), null);
            //canvasforbutton.Border(new CornerRadius(10, 10, 10, 10), "#FF9fa13a", new Thickness(1), 70, 35);
            canvasforbutton.Colturi(10, 10, new Rect(0, 0, 70, 33));
            canvasforbutton.AddTextBlock(new TextBlock(), "+ Donate", 14, 0, 5, "#ffffffff");
            camp = canvasforbutton.intoarce();
            camp.Visibility = Visibility.Collapsed;
        }

        //private CampaniiPage GetParent()//aflu pagina pe care se afla userControl-ul??????
        //{
        //    StackPanel SP = (StackPanel)this.Parent;//parintele user-controlului
        //    StackPanel SP1 = (StackPanel)SP.Parent;
        //    ScrollViewer SV = (ScrollViewer)SP1.Parent;//bunicul
        //    Grid G = (Grid)SV.Parent;//strabunicuk
        //    CampaniiPage CP = (CampaniiPage)G.Parent;//campanii-pagina
        //    return CP;
        //}

        private void detailsHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {


           // LayoutRoot.Height = 400;
            if (((HyperlinkButton)sender).Content.ToString() == "details")
            {
                ((HyperlinkButton)sender).Content = " hide";
                camp.Visibility = Visibility.Visible;
                totalMoneyTextBlock.Visibility = Visibility.Visible;
                totalTextBlock.Visibility = Visibility.Visible;
                AddDescriptionAndPhotos();

                ServiceReference2.CampaignsClient service = new ServiceReference2.CampaignsClient();

                service.SelectComentariiAsync(id);//adaug comentariile existente deja
                service.SelectComentariiCompleted += new EventHandler<SelectComentariiCompletedEventArgs>(service_SelectComentariiCompleted);

               // service.SelectCampanieByIdAsync(id);//adaug descrierea
               // service.SelectCampanieByIdCompleted += new EventHandler<SelectCampanieByIdCompletedEventArgs>(service_SelectCampanieByIdCompleted);
               

                
               
              //  detaliiComentariiStackPanel.Children.Reverse();
            }
            else
            {
                ((HyperlinkButton)sender).Content = "details";
                detaliiComentariiStackPanel.Height = 0;
             //   detaliiStackPanel.Height = 0;
                camp.Visibility = Visibility.Collapsed;
                totalMoneyTextBlock.Visibility = Visibility.Collapsed;
                totalTextBlock.Visibility = Visibility.Collapsed;
                detaliiComentariiStackPanel.Children.Clear();
            }
            
        }

        public String[] GetFotos(String[] S)
        {
            String[] Foto = new String[5];
            int k=0;
            for (int i = 0; i < 10; i++)
            {
                if (S[i]!=null&&k<5)
                    Foto[k++] = S[i];
                
            }
            return Foto;
        }//selectez primele 5 poze care exista si care apar pe site
       
        void AddDescriptionAndPhotos()
        {
            
            TextBlock DescriereTextBlock = new TextBlock();
            DescriereTextBlock.Foreground = new SolidColorBrush(Colors.White);
            detaliiComentariiStackPanel.Height += 50;
          
          //  bing.ServiceReference2.Real C = e.Result;
            DescriereTextBlock.Text = textDescriere;
            DescriereTextBlock.Width = 750;//cum sa setez sa-mi apara textul pe mai multe linii?
            DescriereTextBlock.TextWrapping = TextWrapping.Wrap;
            
            double h = DescriereTextBlock.ActualHeight;
            detaliiComentariiStackPanel.Height += h;
            detaliiComentariiStackPanel.Children.Add(DescriereTextBlock);
                
                String[] Fotografii = GetFotos(S);
                FotografiiCampanii Fotos = new FotografiiCampanii();
                if (Fotografii.Count() != 0)
                {
                    for (int i = 0; i < Fotografii.Count(); i++)
                    {
                        Uri uri = new Uri(Fotografii[i], UriKind.Relative);
                        ImageSource img = new System.Windows.Media.Imaging.BitmapImage(uri);

                        switch (i)
                        {
                            case 0: { Fotos.image1.SetValue(Image.SourceProperty, img); break; }
                            case 1: { Fotos.image2.SetValue(Image.SourceProperty, img); break; }
                            case 2: { Fotos.image3.SetValue(Image.SourceProperty, img); break; }
                            case 3: { Fotos.image4.SetValue(Image.SourceProperty, img); break; }
                            case 4: { Fotos.image5.SetValue(Image.SourceProperty, img); break; }
                        }
                    }
                    detaliiComentariiStackPanel.Height += 124;
                    detaliiComentariiStackPanel.Children.Add(Fotos);
                }
            // detaliiStackPanel.Height = DescriereTextBlock.Height;
        }

        void service_SelectComentariiCompleted(object sender, SelectComentariiCompletedEventArgs e)
        {
            
            foreach (ComentariiDetaliat Comment in e.Result)
            {
                Comentariu com = new Comentariu(Comment.TextCampanie, Comment.Data.ToShortDateString(),Comment.Usr,Comment.Poza);
                detaliiComentariiStackPanel.Height += 121;
                detaliiComentariiStackPanel.Children.Add(com);
            }
            AddCommentControl addComment = new AddCommentControl(null,1); //aici tb sa adug poza userului logat
            addComment.idCampanieTextBlock.Text = id.ToString();    //adaug controlul de adaugat comentarii
            detaliiComentariiStackPanel.Children.Add(addComment);
            detaliiComentariiStackPanel.Height += 134;
        }
    }
}
