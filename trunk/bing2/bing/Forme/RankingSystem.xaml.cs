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
using bing.testService;
using System.ServiceModel;
using Forme;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;
using Microsoft.Maps.MapControl;

namespace bing.Forme
{
    public partial class RankingSystem : UserControl
    {
        List<getAchievement_Result> achievementsList = new List<getAchievement_Result>();

        ControlCuColturiRotunde achievements;
        Canvas myAchievements;
        ControlCuColturiRotunde challenges;
        Canvas myChallenges;
        bool achievementSelected = true;

        List<UIElement> goBack = new List<UIElement>();
        Canvas currentCanvas;

        static BasicHttpBinding bind = new BasicHttpBinding();
        static EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Service1.svc");
        bing.testService.Service1Client wcf = new bing.testService.Service1Client(bind, endpoint);
      
        public RankingSystem()
        {
            InitializeComponent();
          
            AtributeGlobale.i++;
            resetTabs();
            achievements.AddTextBlock(new TextBlock(), "Achievements", 23, 10, 10, "#FFFFFFFF");
            achievements.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 182, 61);
        }

        public void get_AchievementsFromDB()
        {
            #region Query Database
            wcf.getAchievementsFromDBCompleted += new EventHandler<testService.getAchievementsFromDBCompletedEventArgs>(wcf_getAchievementsFromDBCompleted);
            try
            {
                wcf.getAchievementsFromDBAsync(11);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        void wcf_getAchievementsFromDBCompleted(object sender, testService.getAchievementsFromDBCompletedEventArgs e)
        {
            #region Build Achievements List
            foreach (var a in e.Result)
            {
                achievementsList.Add(a);
            }
            #endregion

            //Aranjez & afisez Achievements-urile
            show_Achievements();
        }

        // Initializez Tab-urile Achievements & Challenges
        void resetTabs()
        {
            #region Control cu Taburi

            ControlCuColturiRotunde sus = new ControlCuColturiRotunde(LayoutRoot, LayoutRoot.Width - 2, 60, 0, 0, false, 1);
            sus.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            sus.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), LayoutRoot.Width, 62);

            achievements = new ControlCuColturiRotunde(LayoutRoot, 180, 60, 0, 1, false, 1);
            achievements.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            achievements.AddTextBlock(new TextBlock(), "Achievements", 23, 10, 10, "#FF959906");
            myAchievements = achievements.intoarce();

            challenges = new ControlCuColturiRotunde(LayoutRoot, 180, 60, 190, 1, false, 1);
            challenges.Colors("#FF252525", "#FF000000", new Point(0.5, 1), new Point(0.5, 0), 1);
            challenges.AddTextBlock(new TextBlock(), "Challenges", 23, 25, 10, "#FF959906");
            myChallenges = challenges.intoarce();

            myAchievements.MouseEnter += new MouseEventHandler(myAchievements_MouseEnter);
            myAchievements.MouseLeave += new MouseEventHandler(myAchievements_MouseLeave);
            myAchievements.MouseLeftButtonDown += new MouseButtonEventHandler(myAchievements_MouseLeftButtonDown);
            myChallenges.MouseEnter += new MouseEventHandler(myChallenges_MouseEnter);
            myChallenges.MouseLeave += new MouseEventHandler(myChallenges_MouseLeave);
            myChallenges.MouseLeftButtonDown += new MouseButtonEventHandler(myChallenges_MouseLeftButtonDown);

            #endregion
        }

        void myChallenges_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (achievementSelected == true)
            {
                resetTabs();
                achievementSelected = false;
                challenges.Children.Clear();
                challenges.AddTextBlock(new TextBlock(), "Challenges", 23, 25, 10, "#FFFFFFFF");
                challenges.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 182, 61);
                show_Challenges();
            }
        }

        void myChallenges_MouseLeave(object sender, MouseEventArgs e)
        {
            if (achievementSelected == true)
            {
                challenges.Children.Clear();
                challenges.AddTextBlock(new TextBlock(), "Challenges", 23, 25, 10, "#FF959906");
                achievements.Children.Clear();
                achievements.AddTextBlock(new TextBlock(), "Achievements", 23, 10, 10, "#FFFFFFFF");
            }
        }

        void myChallenges_MouseEnter(object sender, MouseEventArgs e)
        {
            if (achievementSelected == true)
            {
                challenges.Children.Clear();
                challenges.AddTextBlock(new TextBlock(), "Challenges", 23, 25, 10, "#FFFFFFFF");
                achievements.Children.Clear();
                achievements.AddTextBlock(new TextBlock(), "Achievements", 23, 10, 10, "#FF959906");
            }
        }

        void myAchievements_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (achievementSelected == false)
            {
                resetTabs();
                achievementSelected = true;
                achievements.Children.Clear();
                achievements.AddTextBlock(new TextBlock(), "Achievements", 23, 10, 10, "#FFFFFFFF");
                achievements.Border(new CornerRadius(0, 0, 0, 0), "#FF696c6e", new Thickness(1), 182, 61);
                show_Achievements();
            }
        }

        void myAchievements_MouseLeave(object sender, MouseEventArgs e)
        {
            if (achievementSelected == false)
            {
                achievements.Children.Clear();
                achievements.AddTextBlock(new TextBlock(), "Achievements", 23, 10, 10, "#FF959906");
                challenges.Children.Clear();
                challenges.AddTextBlock(new TextBlock(), "Challenges", 23, 25, 10, "#FFFFFFFF");
            }
        }

        void myAchievements_MouseEnter(object sender, MouseEventArgs e)
        {
            if (achievementSelected == false)
            {
                achievements.Children.Clear();
                achievements.AddTextBlock(new TextBlock(), "Achievements", 23, 10, 10, "#FFFFFFFF");
                challenges.Children.Clear();
                challenges.AddTextBlock(new TextBlock(), "Challenges", 23, 25, 10, "#FF959906");
            }
        }

        void show_Achievements()
        {
            #region Initializare
            Canvas canvas = new Canvas();
            canvas.Background = new SolidColorBrush(Colors.Black);
            canvas.Height = 650;
            canvas.Width = 750;

            scrollViewer.Content = canvas;
            #endregion

            show_Pictures(canvas);
        }

        void show_Pictures(Canvas canvas)
        {
            List<pictureWithText> urlPoze = new List<pictureWithText>();

            #region Adaug adresele pozelor
            urlPoze.Add(new pictureWithText("../Game/Achievements/hunger.png", "1. Ending hunger and poverty", (int)achievementsList[0].Expr8));
            urlPoze.Add(new pictureWithText("../Game/Achievements/education.png", "2. Achieving primary education for everyone", (int)achievementsList[0].Expr7));
            urlPoze.Add(new pictureWithText("../Game/Achievements/equality.png", "3. Promoting gender equality and empowerment", (int)achievementsList[0].Expr6));
            urlPoze.Add(new pictureWithText("../Game/Achievements/mortality.png", "4. Reducing child mortality", (int)achievementsList[0].Expr5));
            urlPoze.Add(new pictureWithText("../Game/Achievements/maternal_health.png", "5. Improving maternal health", (int)achievementsList[0].Expr4));
            urlPoze.Add(new pictureWithText("../Game/Achievements/disease.png", "6. Combating widespread disease", (int)achievementsList[0].Expr3));
            urlPoze.Add(new pictureWithText("../Game/Achievements/environment.png", "7. Ensuring environmental sustainability", (int)achievementsList[0].Expr2));
            urlPoze.Add(new pictureWithText("../Game/Achievements/partnership.png", "8. Developing a global partnership for development", (int)achievementsList[0].Expr1));
            #endregion

            double left = 10;
            double top = 10;
            double distanta = 80;

            foreach (pictureWithText urlPoza in urlPoze)
            {
                addPicture(canvas, urlPoza.getUrl(), left + 5, top + 6);
                addText(canvas, urlPoza.getText(), 85, top + 25);
                LoadingBar lb = new LoadingBar(canvas, urlPoza.getValue(), 460, top + 25);
                top += distanta;
            }

        }

        void addPicture(Canvas canvas, string imagine, double left, double top)
        {
            //ControlCuColturiRotunde pic1 = new ControlCuColturiRotunde(canvas, 66, 66, left, top, false, 1);
            //pic1.Colors("#FF6BB5DB", "#FF6BB5DB", new Point(0.5, 1), new Point(0.5, 0), 0.3);
            //pic1.Colturi(10, 10, new Rect(0, 0, 66, 66));

            ControlCuColturiRotunde p1 = new ControlCuColturiRotunde(canvas, 60, 60, left + 3, top + 3, true, 1);
            p1.Colturi(10, 10, new Rect(0, 0, 60, 60));
            p1.Background = new SolidColorBrush(Colors.Transparent);

            Image img = new Image() { Source = new BitmapImage(new Uri(imagine, UriKind.Relative)), Width = 50, Height = 50, Margin = new Thickness(0, 0, 0, 0) };
            Canvas can1 = new Canvas(); can1 = p1.intoarce(); can1.Children.Add(img);
            //pic1.Children.Add(p1);
        }

        void addText(Canvas canvas, string text, double left, double top)
        {
            TextBlock tb = new TextBlock()
            {
                Text = text,
                Margin = new Thickness(left, top, 12, 12),
                FontFamily = new FontFamily("Tahoma"),
                FontSize = 15,
                Foreground = new SolidColorBrush(Colors.White)
            };

            canvas.Children.Add(tb);
        }

        void show_Challenges()
        {
            Challenges challenges = new Challenges();
            scrollViewer.Content = challenges;
        }

        struct pictureWithText
        {
            string url;
            string text;
            int value;

            public pictureWithText(string url, string text, int value)
            {
                this.url = url;
                this.text = text;
                this.value = value;
            }

            #region Getters/Setters
            public string getUrl()
            {
                return url;
            }

            public string getText()
            {
                return text;
            }

            public int getValue()
            {
                return value;
            }
            #endregion
        }

        public void setBackButton(List<UIElement> list, Canvas canvas2)
        {
            goBack = list;
            currentCanvas = canvas2;
        }

        private void image1_MouseEnter(object sender, MouseEventArgs e)
        {
            image1.Width = 30;
            image1.Height = 30;
        }

        private void image1_MouseLeave(object sender, MouseEventArgs e)
        {
            image1.Width = 25;
            image1.Height = 25;
        }

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //cod sergiu
            PlaneProjection p = (PlaneProjection)currentCanvas.Projection;
            if (p != null)
            {
                if (p.RotationY == 0)
                {
                    if (AtributeGlobale.i == 1)
                    {
                        p.RotationY = 180;
                        AtributeGlobale.i = 0;
                    }
                    else { p.RotationY = 0; AtributeGlobale.i--; }

                    currentCanvas.Projection = p;
                }
            }
            //
            AtributeGlobale.achiv = false;
            currentCanvas.Children.Clear();
            foreach (UIElement elem in goBack)
            {
                currentCanvas.Children.Add(elem);
            }
        }
    }
}
