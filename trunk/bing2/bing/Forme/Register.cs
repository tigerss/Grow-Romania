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
using System.Windows.Threading;
using System.Text.RegularExpressions;
using System.ServiceModel;
using bing.testService;
using bing;

namespace Forme
{
    public class Register
    {
        #region Membrii
        private Canvas CanPrincipal;
        //---
        private Canvas RegisterMeniu;
     //   private Canvas RegisterMeniuAlDoileaDeCriza;
        private ControlCuColturiRotunde canvasforbutton;
        private TextBox firstname;
        private TextBox lastname;
        private TextBox username;
        private PasswordBox pass;
        private PasswordBox passre;
        private TextBox mail;
        /// <summary>
        /// Canvasu gri inchis
        /// </summary>
        private Canvas errtrans;
        /// <summary>
        /// Canvasu trasnparent de deasupra
        /// </summary>
        private Canvas err;
        private TextBlock errrortext;
     //   private Canvas ret;
        //--
        private ControlCuColturiRotunde b1;
        private ControlCuColturiRotunde b2;
        private ControlCuColturiRotunde b3;
        private ControlCuColturiRotunde b4;
        private ControlCuColturiRotunde b5;
        private ControlCuColturiRotunde b6;
        /// <summary>
        /// Timmeru pt erori
        /// </summary>
        private DispatcherTimer timmer;
        /// <summary>
        /// timmeru care verif daca s-a selectat o regiune
        /// </summary>
        private DispatcherTimer RegionChooserTimmer;
        /// <summary>
        /// Choose your region
        /// </summary>
        TextBlock tbinit;
        //--
        private string regiune_global;
        #endregion
        public Register(Canvas can, string regiune)
        {
            CanPrincipal = can;
            AtributeGlobale.UserIsRegistering = true;
            //---
            regiune_global = regiune;
            RegisterMeniu = new Canvas() { Background = new SolidColorBrush(Colors.Transparent), Margin = new Thickness(436, 10, 0, 0), Width = 357, Height = 500, Opacity = 1, Visibility = Visibility.Collapsed };
            can.Children.Add(RegisterMeniu);
            TextBlock tb1 = new TextBlock() { Text = "Welcome to "+regiune, FontFamily = new FontFamily("Tahoma"), FontSize = 22, FontWeight=FontWeights.SemiBold, Foreground = new SolidColorBrush(Colors.White) };
            tb1.Margin = new Thickness((RegisterMeniu.ActualWidth - tb1.ActualWidth) / 2, 25, 10, 10);
            RegisterMeniu.Children.Add(tb1);

            double left = (RegisterMeniu.ActualWidth - 206) / 2;
            double left2 = (RegisterMeniu.ActualWidth - 250) / 2;
            #region First name
            b1 = new ControlCuColturiRotunde(RegisterMeniu, 206, 39, left, 90, true, 0.43);
            ControlCuColturiRotunde t1 = new ControlCuColturiRotunde(RegisterMeniu, 90, 39, left, 90, true, 1) { Background = new SolidColorBrush(Colors.Transparent)};
            b1.Opacity = 0.43;
            firstname  = new TextBox();
            b1.Colors("#FF9bc7d1", "#FFd5e4e7", new Point(0.5, 1), new Point(0.5, 0), null);
            b1.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
            b1.Colturi(10, 10, new Rect(0, 0, 206, 38));
            t1.AddTextBlock(new TextBlock(), "First name:", 15, 5, 10, null);
            b1.AddTextBox(firstname, "", 100, 30, 0, 14, "#FF992929", "#FF9F1C1C", "#FF581818", "#FFBE4141", null, true, 95, 5);
            #endregion
            #region Last name
            b2 = new ControlCuColturiRotunde(RegisterMeniu, 206, 39, left, 135, true, 0.43);
            ControlCuColturiRotunde t2 = new ControlCuColturiRotunde(RegisterMeniu, 90, 39, left, 135, true, 1) { Background = new SolidColorBrush(Colors.Transparent) };
            b2.Opacity = 0.43;
            lastname = new TextBox();
            b2.Colors("#FF9bc7d1", "#FFd5e4e7", new Point(0.5, 1), new Point(0.5, 0), null);
            b2.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
            b2.Colturi(10, 10, new Rect(0, 0, 206, 38));
            t2.AddTextBlock(new TextBlock(), "Last name:", 15, 5, 10, null);
            b2.AddTextBox(lastname, "", 100, 30, 0, 14, "#FF992929", "#FF9F1C1C", "#FF581818", "#FFBE4141", null, true, 95, 5);
            #endregion
            #region Username
            b3 = new ControlCuColturiRotunde(RegisterMeniu, 206, 39, left, 180, true, 0.43);
            ControlCuColturiRotunde t3 = new ControlCuColturiRotunde(RegisterMeniu, 90, 39, left, 180, true, 1) { Background = new SolidColorBrush(Colors.Transparent) };
            b3.Opacity = 0.43;
            username = new TextBox();
            b3.Colors("#FF9bc7d1", "#FFd5e4e7", new Point(0.5, 1), new Point(0.5, 0), null);
            b3.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
            b3.Colturi(10, 10, new Rect(0, 0, 206, 38));
            t3.AddTextBlock(new TextBlock(), "Username:", 15, 5, 10, null);
            b3.AddTextBox(username, "", 100, 30, 0, 14, "#FF992929", "#FF9F1C1C", "#FF581818", "#FFBE4141", null, true, 95, 5);
            #endregion
            #region Password
            b4 = new ControlCuColturiRotunde(RegisterMeniu, 206, 39, left, 225, true, 0.43);
            ControlCuColturiRotunde t4 = new ControlCuColturiRotunde(RegisterMeniu, 90, 39, left, 225, true, 1) { Background = new SolidColorBrush(Colors.Transparent) };
            b4.Opacity = 0.43;
            pass = new PasswordBox();
            b4.Colors("#FF9bc7d1", "#FFd5e4e7", new Point(0.5, 1), new Point(0.5, 0), null);
            b4.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
            b4.Colturi(10, 10, new Rect(0, 0, 206, 38));
            t4.AddTextBlock(new TextBlock(), "Password:", 15, 5, 10, null);
            b4.AddPasswordTextBox(pass, "", 100, 30, 0, 14, "#FF992929", "#FF9F1C1C", "#FF581818", "#FFBE4141", "#FFBE4141", true, 95, 5);
            #endregion
            #region PasswordRetype
            b5 = new ControlCuColturiRotunde(RegisterMeniu, 206, 39, left, 270, true, 0.43);
            ControlCuColturiRotunde t5 = new ControlCuColturiRotunde(RegisterMeniu, 90, 39, left, 270, true, 1) { Background = new SolidColorBrush(Colors.Transparent) };
            b5.Opacity = 0.43;
            passre = new PasswordBox();
            b5.Colors("#FF9bc7d1", "#FFd5e4e7", new Point(0.5, 1), new Point(0.5, 0), null);
            b5.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
            b5.Colturi(10, 10, new Rect(0, 0, 206, 38));
            t5.AddTextBlock(new TextBlock(), "Retype:", 15, 5, 10, null);
            b5.AddPasswordTextBox(passre, "", 100, 30, 0, 14, "#FF992929", "#FF9F1C1C", "#FF581818", "#FFBE4141", "#FFBE4141", true, 95, 5);
            #endregion
            #region Mail
            b6 = new ControlCuColturiRotunde(RegisterMeniu, 206, 39, left, 315, true, 0.43);
            ControlCuColturiRotunde t6 = new ControlCuColturiRotunde(RegisterMeniu, 90, 39, left, 315, true, 1) { Background = new SolidColorBrush(Colors.Transparent) };
            b6.Opacity = 0.43;
            mail = new TextBox();
            b6.Colors("#FF9bc7d1", "#FFd5e4e7", new Point(0.5, 1), new Point(0.5, 0), null);
            b6.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40);
            b6.Colturi(10, 10, new Rect(0, 0, 206, 38));
            t6.AddTextBlock(new TextBlock(), "E-mail:", 15, 5, 10, null);
            b6.AddTextBox(mail, "", 100, 30, 0, 14, "#FF992929", "#FF9F1C1C", "#FF581818", "#FFBE4141", null, true, 95, 5);
            #endregion
            #region Registerbutton

            canvasforbutton = new ControlCuColturiRotunde(RegisterMeniu, 206, 39, left, 360, false, 1);
            canvasforbutton.Colors("#FF969a07", "#FF7a7d04", new Point(0.5, 1), new Point(0.5, 0), null);
            canvasforbutton.Border(new CornerRadius(10, 10, 10, 10), "#FF9fa13a", new Thickness(1), 208, 40);
            canvasforbutton.Colturi(10, 10, new Rect(0, 0, 206, 38));
            canvasforbutton.AddTextBlock(new TextBlock(), "Register", 17, 68, 5, "#ffe0e1c0");
            Canvas butonlogin = canvasforbutton.intoarce();
            butonlogin.Cursor = Cursors.Hand;
            butonlogin.MouseEnter += new MouseEventHandler(butonlogin_MouseEnter);
            butonlogin.MouseLeave += new MouseEventHandler(butonlogin_MouseLeave);
            butonlogin.MouseLeftButtonDown += new MouseButtonEventHandler(butonlogin_MouseLeftButtonDown);
            #endregion
            #region Error
            err = new Canvas()
            {
                Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xcc, 0xdf, 0xf5)),
                Opacity = .43,
                Width = 250,
                Height = 70,
                Clip = new RectangleGeometry()
                {
                    RadiusX = 10,
                    RadiusY = 10,
                    Rect = new Rect(0, 0, 250, 70)
                },
                Margin = new Thickness(left2, 420, 3, 10),
                Visibility = Visibility.Collapsed
            };
            errtrans = new Canvas() { Background = new SolidColorBrush(Colors.Transparent), Width = 250, Height = 70, Margin = new Thickness(left2, 420, 3, 10),Visibility = Visibility.Collapsed };
            Image img2 = new Image() { Source = new BitmapImage(new Uri("DesignImages/triunghi.png", UriKind.Relative)), Width = 26, Height = 26, Opacity = 1, OpacityMask = new SolidColorBrush(Colors.Black), Margin = new Thickness(10, 4, 0, 0) };
            TextBlock errtext = new TextBlock() { Text = "Error", FontFamily = new FontFamily("tahoma"), FontSize = 18, FontWeight = FontWeights.Bold, Margin = new Thickness(43, 6, 0, 0) };
            errrortext = new TextBlock() { Text = "", FontFamily = new FontFamily("tahoma"), FontSize = 12, Margin = new Thickness(20, 34, 0, 0) };
            errtrans.Children.Add(img2); errtrans.Children.Add(errtext); errtrans.Children.Add(errrortext);
            RegisterMeniu.Children.Add(err);
            RegisterMeniu.Children.Add(errtrans);
            #endregion
            #region Avionas catre alta zona
            /*ret = new Canvas()
            {
                Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xcc, 0xdf, 0xf5)),
                Opacity = .47,
                Width = 200,
                Height = 50,
                Clip = new RectangleGeometry()
                {
                    RadiusX = 10,
                    RadiusY = 10,
                    Rect = new Rect(0, 0, 250, 40)
                },
                Margin=new Thickness(555,5,3,10),
                Cursor=Cursors.Hand
            };
            ret.MouseLeftButtonDown += new MouseButtonEventHandler(ret_MouseLeftButtonDown);
            Image img = new Image() { Source = new BitmapImage(new Uri("DesignImages/avion.png", UriKind.Relative)), Width = 50, Height = 26, Opacity=1, OpacityMask=new SolidColorBrush(Colors.Black) };
            ret.Children.Add(img);
            Canvas.SetLeft(img, 5);
            Canvas.SetTop(img, 7);
            RegisterMeniu.Children.Add(ret);
            TextBlock text = new TextBlock() { Text = "Another Region", FontSize = 20, Margin = new Thickness(56, 7, 0, 0), FontFamily = new FontFamily("Tahoma") };
            ret.Children.Add(text);*/
            #endregion
            timmer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 200) };
            timmer.Tick += new EventHandler(timmer_Tick);

            #region Choose your region
            tbinit = new TextBlock() { Text = "Choose your region", FontFamily = new FontFamily("Tahoma"), FontSize = 22, FontWeight = FontWeights.SemiBold, Foreground = new SolidColorBrush(Colors.White), Margin = new Thickness(508, 50, 0, 0) };
            CanPrincipal.Children.Add(tbinit);
            RegionChooserTimmer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 100) };
            RegionChooserTimmer.Tick += new EventHandler(RegionChooserTimmer_Tick);
            RegionChooserTimmer.Start();
            #endregion
        }
        void RegionChooserTimmer_Tick(object sender, EventArgs e)
        {
            if (AtributeGlobale.RegiuneaCurenta != AtributeGlobale.EnumRegiuni.NoRegionSelected)
            {
                RegionChooserTimmer.Stop();
                RegisterMeniu.Visibility = Visibility.Visible;
                tbinit.Visibility = Visibility.Collapsed;
            }
        }
        void ret_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RegisterMeniu.Visibility = Visibility.Collapsed;
            tbinit.Visibility = Visibility.Visible;
            AtributeGlobale.RegiuneaCurenta = AtributeGlobale.EnumRegiuni.NoRegionSelected;
            RegionChooserTimmer.Start();
        }
        /// <summary>
        /// True afisaza borderu rosu, False nu il afisaza
        /// </summary>
        private bool IsRed { get; set; }
        private byte Ticks { get; set; }
        void timmer_Tick(object sender, EventArgs e)
        {
            if (Ticks < 13)
            {
                string culoare = "#FF88B4BB"; byte grosime = 1; byte width = 208; byte height = 40;
                if (IsRed == false)
                    { culoare = "#FFba0000"; grosime = 2; width = 210; height = 42; }
                if (b1.Tag != null) if (b1.Tag.ToString() == "true") b1.Border(new CornerRadius(10, 9, 9, 9), culoare, new Thickness(grosime),width , height);
                if (b2.Tag != null) if (b2.Tag.ToString() == "true") b2.Border(new CornerRadius(10, 9, 9, 9), culoare, new Thickness(grosime), width, height);
                if (b3.Tag != null) if (b3.Tag.ToString() == "true") b3.Border(new CornerRadius(10, 9, 9, 9), culoare, new Thickness(grosime), width, height);
                if (b4.Tag != null) if (b4.Tag.ToString() == "true") b4.Border(new CornerRadius(10, 9, 9, 9), culoare, new Thickness(grosime), width, height);
                if (b5.Tag != null) if (b5.Tag.ToString() == "true") b5.Border(new CornerRadius(10, 9, 9, 9), culoare, new Thickness(grosime), width, height);
                if (b6.Tag != null) if (b6.Tag.ToString() == "true") b6.Border(new CornerRadius(10, 9, 9, 9), culoare, new Thickness(grosime), width, height);
                Ticks++; IsRed = !IsRed;
            }
            else { timmer.Stop(); }
        }
        void butonlogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //resetez valorile
            string errormessage=String.Empty;
            errtrans.Visibility = err.Visibility = Visibility.Collapsed;

            #region Date gresite
            //No null textboxes
            if (firstname.Text == String.Empty) { errormessage = "All the fields are mandatory"; b1.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b1.Tag = null; b1.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            if (lastname.Text == String.Empty) { errormessage = "All the fields are mandatory"; b2.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b2.Tag = null; b2.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            if (username.Text == String.Empty) { errormessage = "All the fields are mandatory"; b3.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b3.Tag = null; b3.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            if (pass.Password == String.Empty) { errormessage = "All the fields are mandatory"; b4.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b4.Tag = null; b4.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            if (passre.Password == String.Empty) { errormessage = "All the fields are mandatory"; b5.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b5.Tag = null; b5.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            if (mail.Text == String.Empty) { errormessage = "All the fields are mandatory"; b6.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b6.Tag = null; b6.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            if (errormessage != String.Empty) { errtrans.Visibility = err.Visibility = Visibility.Visible; errrortext.Text = errormessage; return; }

            //verif nume si prenume numai litere expr reg
            Regex rgx = new Regex(@"[^A-Za-z -]", RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(firstname.Text);
            if (matches.Count > 0)
            { errormessage = "First name may contain only characters"; b1.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b1.Tag = null; b1.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            matches = rgx.Matches(lastname.Text);
            if (matches.Count > 0)
            { errormessage = "Last name may contain only characters"; b2.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b2.Tag = null; b2.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            if (errormessage != String.Empty) { errtrans.Visibility = err.Visibility = Visibility.Visible; errrortext.Text = errormessage; return; }

            //username fara spatii albe, doar litere,cif si -_. cu expr reg
            rgx = new Regex(@"[^A-Za-z0-9_.-]", RegexOptions.IgnoreCase);
            matches = rgx.Matches(username.Text);
            if (matches.Count > 0)
                { errormessage = "Username may contain only characters,\n digits, _ - and ."; b3.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b3.Tag = null; b3.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            if (errormessage != String.Empty) { errtrans.Visibility = err.Visibility = Visibility.Visible; errrortext.Text = errormessage; return; }

            //verif match pass
            if(pass.Password!=passre.Password)
                { errormessage = "Password mismatch"; b5.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b5.Tag = null; b5.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            if (errormessage != String.Empty) { errtrans.Visibility = err.Visibility = Visibility.Visible; errrortext.Text = errormessage; return; }

            //verif strong pass
            if(pass.Password.Length<6)
                { errormessage = "Password is weak. You must have at\n least 6 characters"; b4.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b4.Tag = null; b4.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            if (errormessage != String.Empty) { errtrans.Visibility = err.Visibility = Visibility.Visible; errrortext.Text = errormessage; return; }

            //verif email
            rgx = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}", RegexOptions.IgnoreCase);
            matches = rgx.Matches(mail.Text);
            if (matches.Count == 0)
                { errormessage = "Invalid E-mail"; b6.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; }
            else { b6.Tag = null; b6.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
            if (errormessage != String.Empty) { errtrans.Visibility = err.Visibility = Visibility.Visible; errrortext.Text = errormessage; return; }
            #endregion

            //verif user unic - altfel link forgot pass
            BasicHttpBinding bind = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress("http://localhost:11201/Service1.svc");
            bing.testService.Service1Client wcf = new bing.testService.Service1Client(bind, endpoint);
            wcf.GetUserByUsernameCompleted += new EventHandler<bing.testService.GetUserByUsernameCompletedEventArgs>(wcf_GetUserByUsernameCompleted);
            wcf.GetUserByUsernameAsync(username.Text.ToLower());

            //verif mail unic - altfel link forgot pass
            wcf.GetUserByEmailCompleted += new EventHandler<bing.testService.GetUserByEmailCompletedEventArgs>(wcf_GetUserByEmailCompleted);
            wcf.GetUserByEmailAsync(mail.Text.ToLower());

            //--creare user nou
            System.Threading.Thread.Sleep(1000);
            wcf.RegisterUserCompleted += new EventHandler<RegisterUserCompletedEventArgs>(wcf_RegisterUserCompleted);
            wcf.RegisterUserAsync(firstname.Text, lastname.Text, username.Text, pass.Password, mail.Text, regiune_global);
        }
        #region Servicii
        void wcf_RegisterUserCompleted(object sender, RegisterUserCompletedEventArgs e)
        {
            if ((bool)e.Result == false)
                MessageBox.Show("A aparut o eroare la inregistrare");
        }
        void wcf_GetUserByEmailCompleted(object sender, bing.testService.GetUserByEmailCompletedEventArgs e)
        {
            if ((Usr)e.Result != null)
            { errrortext.Text = "There is another account registered with\n this e-mail. Forgot your Username?"; b6.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; errtrans.Visibility = err.Visibility = Visibility.Visible; }
            else { b6.Tag = null; b6.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
        }
        void wcf_GetUserByUsernameCompleted(object sender, bing.testService.GetUserByUsernameCompletedEventArgs e)
        {
            if ((Usr)e.Result != null)
            { errrortext.Text = "Username is taken"; b3.Tag = "true"; timmer.Start(); IsRed = false; Ticks = 0; errtrans.Visibility = err.Visibility = Visibility.Visible; }
            else { b3.Tag = null; b3.Border(new CornerRadius(10, 9, 9, 9), "#FF88B4BB", new Thickness(1), 208, 40); }
        }
        #endregion


        void butonlogin_MouseLeave(object sender, MouseEventArgs e)
        {
            canvasforbutton.Colors("#FF7a7d04", "#FF969a07", new Point(0.5, 1), new Point(0.5, 0), null);
        }
        void butonlogin_MouseEnter(object sender, MouseEventArgs e)
        {
           canvasforbutton.Colors("#FF7a7d04", "#FFe2e810", new Point(0.5, 1), new Point(0.5, 0), null);
        }
    }
}
