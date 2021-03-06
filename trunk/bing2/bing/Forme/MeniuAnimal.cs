﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.Reflection.Emit;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using bing.testService;
using bing;
using System.Windows.Controls.Primitives;
using bing.Forme;

namespace Forme
{
    public class MeniuAnimal : UserControl
    {
        Canvas pan, canvas;
        Canvas canvas2;
        List<getAnimalStats_Result> lista;
        public MeniuAnimal(Canvas can, string Regiune, string Subregiune, string Locatie, List<getAnimalStats_Result> lista,Canvas canvas2)
        {
            canvas = can;
            this.lista = lista;
            
            this.canvas2 = canvas2;
            canvas.Children.Clear();
           
            #region Adresa + Nume animal
            ControlCuColturiRotunde adresscur = new ControlCuColturiRotunde(can, 230, 74, 0, 7, true, 1);
            adresscur.Colturi(13, 13, new Rect(0, 0, 230, 74));
            adresscur.Colors("#FFF0F8FF", "#FFF0F8FF", new Point(0.5, 1), new Point(0.5, 0), 0.3);
        //    ControlCuColturiRotunde dd = new ControlCuColturiRotunde(can, 200, 100, 200, 100, false, 1);
            Canvas wrap = new Canvas() { Margin = new Thickness(12, 12, 12, 12), Width = 210, Height = 60 };
            TextBlock tb1 = new TextBlock() { Text = "You are here: ", Margin = new Thickness(0, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            TextBlock tb2 = new TextBlock() { Text = Regiune, Margin = new Thickness(tb1.ActualWidth + 1, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            TextBlock tb3 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb1.ActualWidth + tb2.ActualWidth + 2, 1, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            TextBlock tb4 = new TextBlock() { Text = Subregiune, Margin = new Thickness(tb1.ActualWidth + tb2.ActualWidth + tb3.ActualWidth + 3, 1, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            if (tb4.Margin.Left + tb4.ActualWidth > 210)//trecere urm rand
                tb4.Margin = new Thickness(15, 18, 0, 0);
            TextBlock tb5 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb4.Margin.Left != 0 ? tb4.ActualWidth + 16 : 15, 18, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            if (tb4.Margin.Left != 15)
                tb5.Margin = new Thickness(15, 18, 0, 0);
            TextBlock tb6 = new TextBlock() { Text = Animalule.getRegion(), Margin = new Thickness(tb5.Margin.Left + tb5.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            TextBlock tb7 = new TextBlock() { Text = " >> ", Margin = new Thickness(tb6.Margin.Left + tb6.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Comic Sans MS"), FontWeight = FontWeights.SemiBold, FontSize = 8, Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 42, 116)) };
            TextBlock tb8 = new TextBlock() { Text = "Animale", Margin = new Thickness(tb7.Margin.Left + tb7.ActualWidth + 1, 18, 0, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 12, Foreground = new SolidColorBrush(Colors.Black), Cursor = Cursors.Hand };
            wrap.Children.Add(tb1); wrap.Children.Add(tb2); wrap.Children.Add(tb3); wrap.Children.Add(tb4); wrap.Children.Add(tb5); wrap.Children.Add(tb6); wrap.Children.Add(tb7); wrap.Children.Add(tb8);
            can.Children.Add(wrap);

            TextBlock tb9 = new TextBlock() { Text = lista[0].Nume, Margin = new Thickness(12, 48, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 23, Foreground = new SolidColorBrush(Colors.Black) };
            can.Children.Add(tb9);

            #endregion

            #region Descriere + Poze
            ControlCuColturiRotunde descriere = new ControlCuColturiRotunde(can, 230, 415, 0, 97, true, 1);
            descriere.Colturi(13, 13, new Rect(0, 0, 230, 415));
            //descriere.Colors("#FFF0F8FF", "#FFF0F8FF", new Point(0.5, 1), new Point(0.5, 0), 0.3);
            pan = new Canvas() { Margin = new Thickness(0, 80, 0, 0) };
            can.Children.Add(pan);

            TextBlock tb10 = new TextBlock() { Text = "Description", Margin = new Thickness(10, 5, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 22, Foreground = new SolidColorBrush(Colors.White) };
            pan.Children.Add(tb10);

            ControlCuColturiRotunde pic1 = new ControlCuColturiRotunde(pan, 66, 66, 8, 36, false, 1);
            pic1.Colors("#FF6BB5DB", "#FF6BB5DB", new Point(0.5, 1), new Point(0.5, 0), 0.3);
            pic1.Colturi(10, 10, new Rect(0, 0, 66, 66));
            ControlCuColturiRotunde p1 = new ControlCuColturiRotunde(pan, 60, 60, 11, 39, true, 1);
            p1.Colturi(10, 10, new Rect(0, 0, 60, 60));
            p1.Background = new SolidColorBrush(Colors.Transparent);
            Image img1;
            if (lista[0].Imagine1 != null)
            {
                img1 = new Image() { Source = new BitmapImage(new Uri(lista[0].Imagine1, UriKind.Relative)), Width = 60, Height = 60, Margin = new Thickness(0, 0, 0, 0) };
                Canvas can1 = new Canvas(); can1 = p1.intoarce(); can1.Children.Add(img1);
                pic1.Children.Add(p1);
            }

            ControlCuColturiRotunde pic2 = new ControlCuColturiRotunde(pan, 66, 66, 83, 36, false, 1);
            pic2.Colors("#FF6BB5DB", "#FF6BB5DB", new Point(0.5, 1), new Point(0.5, 0), 0.3);
            pic2.Colturi(10, 10, new Rect(0, 0, 66, 66));
            ControlCuColturiRotunde p2 = new ControlCuColturiRotunde(pan, 60, 60, 86, 39, true, 1);
            p2.Colturi(10, 10, new Rect(0, 0, 60, 60));
            p2.Background = new SolidColorBrush(Colors.Transparent);
            Image img2;
            if (lista[0].Imagine2 != null)
            {
                img2 = new Image() { Source = new BitmapImage(new Uri(lista[0].Imagine2, UriKind.Relative)), Width = 60, Height = 60, Margin = new Thickness(0, 0, 0, 0) };
                Canvas can2 = new Canvas(); can2 = p2.intoarce(); can2.Children.Add(img2);
                pic2.Children.Add(p2);
            }

            ControlCuColturiRotunde pic3 = new ControlCuColturiRotunde(pan, 66, 66, 158, 36, false, 1);
            pic3.Colors("#FF6BB5DB", "#FF6BB5DB", new Point(0.5, 1), new Point(0.5, 0), 0.3);
            pic3.Colturi(10, 10, new Rect(0, 0, 66, 66));
            ControlCuColturiRotunde p3 = new ControlCuColturiRotunde(pan, 60, 60, 161, 39, true, 1);
            p3.Colturi(10, 10, new Rect(0, 0, 60, 60));
            p3.Background = new SolidColorBrush(Colors.Transparent);
            Image img3;
            if (lista[0].Imagine3 != null)
            {
                img3 = new Image() { Source = new BitmapImage(new Uri(lista[0].Imagine3, UriKind.Relative)), Width = 60, Height = 60, Margin = new Thickness(0, 0, 0, 0) };
                Canvas can3 = new Canvas(); can3 = p3.intoarce(); can3.Children.Add(img3);
                pic3.Children.Add(p3);
            }

            //max 80-85 caractere
            TextBlock desc1 = new TextBlock() { Text = lista[0].Descriere.Length < 80 ? lista[0].Descriere : lista[0].Descriere.Substring(0, 80) + "...", Margin = new Thickness(8, 110, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Colors.White), TextWrapping = TextWrapping.Wrap, TextTrimming = TextTrimming.WordEllipsis, Width = 218, Height = 300 };
            TextBlock more1 = new TextBlock() { Text = "+ more info", Margin = new Thickness(150, 144, 12, 10), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Color.FromArgb(255, 139, 146, 5)), Cursor = Cursors.Hand };
            more1.MouseEnter += new MouseEventHandler(more1_MouseEnter);
            more1.MouseLeave += new MouseEventHandler(more1_MouseLeave);
            more1.MouseLeftButtonDown += new MouseButtonEventHandler(more1_MouseLeftButtonDown);
            pan.Children.Add(desc1);
            pan.Children.Add(more1);
            #endregion

            #region Life cycle
            Line l1 = new Line() { X1 = 8, X2 = 226, Y1 = 174, Y2 = 174, Stroke = new SolidColorBrush(Colors.White), StrokeThickness = 1 };
            pan.Children.Add(l1);

            TextBlock tb11 = new TextBlock() { Text = "Life cycle", Margin = new Thickness(10, 178, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 22, Foreground = new SolidColorBrush(Colors.White) };
            pan.Children.Add(tb11);
            TextBlock tb12 = new TextBlock() { Text = "Breeding Season: ", Margin = new Thickness(12, 208, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 15, Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 124, 170)) };
            pan.Children.Add(tb12);
            TextBlock tb13 = new TextBlock() { Text = String.Format("{0:MMM}", lista[0].DataInmultInceput) + " - " + String.Format("{0:MMM}", lista[0].DataInmultSfarsit), Margin = new Thickness(140, 208, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Colors.White) };
            pan.Children.Add(tb13);
            TextBlock tb14 = new TextBlock() { Text = "Hunting Season: ", Margin = new Thickness(12, 226, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 15, Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 124, 170)) };
            pan.Children.Add(tb14);
            TextBlock tb15 = new TextBlock() { Text = String.Format("{0:MMM}", lista[0].DataVanatInceput) + " - " + String.Format("{0:MMM}", lista[0].DataVanatSfarsit), Margin = new Thickness(140, 226, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Colors.White) };
            pan.Children.Add(tb15);
            TextBlock tb16 = new TextBlock() { Text = "Hibernation: ", Margin = new Thickness(12, 244, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 15, Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 124, 170)) };
            pan.Children.Add(tb16);
            TextBlock tb17 = new TextBlock() { Text = "-", Margin = new Thickness(140, 244, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Colors.White) };
            pan.Children.Add(tb17);
            TextBlock tb18 = new TextBlock() { Text = "Progeny per year: ", Margin = new Thickness(12, 262, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 15, Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 124, 170)) };
            pan.Children.Add(tb18);
            TextBlock tb19 = new TextBlock() { Text =lista[0].Pui_An.ToString(), Margin = new Thickness(140, 262, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Colors.White) };
            pan.Children.Add(tb19);
            #endregion
            //string istoric1 = "The Breedin Season began";
            //string istoric2 = "6 [b]Cocosi de Munte[/b] were eaten by 7 [b]Wolves[/b] and 2 [b]Cows[/b]";
            //string istoric3 = "The spontaneous fire killed 4 [b]Cocosi de munte[/b]";

            #region History

            Line l2 = new Line() { X1 = 8, X2 = 226, Y1 = 290, Y2 = 290, Stroke = new SolidColorBrush(Colors.White), StrokeThickness = 1 };
            pan.Children.Add(l2);
            TextBlock tb20 = new TextBlock() { Text = "History", Margin = new Thickness(10, 292, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 22, Foreground = new SolidColorBrush(Colors.White) };
            pan.Children.Add(tb20);
            if (lista.Count > 0)
            {
                TextBlock ist1 = new TextBlock() { Text = GetNormal(lista[0].Description), Margin = new Thickness(12, 322, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Colors.White), TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
                Rectangle r1 = new Rectangle() { Fill = new SolidColorBrush(Color.FromArgb(255, 26, 28, 30)), Width = 218, Height = 36, Margin = new Thickness(8, 322, 12, 12) };
                r1.Height = ist1.ActualHeight + 2;
                pan.Children.Add(r1); pan.Children.Add(ist1);
                AdaugaLinkuri(ref pan, lista[0].Nume, ist1.Margin.Left, ist1.Margin.Top);

                if (lista.Count > 1)
                {
                    TextBlock ist2 = new TextBlock() { Text = GetNormal(lista[1].Description), Margin = new Thickness(12, 322 + ist1.ActualHeight + 2, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Colors.White), TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
                    Rectangle r2 = new Rectangle() { Fill = new SolidColorBrush(Colors.Transparent), Width = 218, Height = 36, Margin = new Thickness(8, 322 + ist1.ActualHeight + 2, 12, 12) };
                    r2.Height = ist2.ActualHeight + 2;
                    pan.Children.Add(r2); pan.Children.Add(ist2);
                    AdaugaLinkuri(ref pan, lista[0].Nume, ist2.Margin.Left, ist2.Margin.Top);


                    if (lista.Count > 2)
                    {
                        TextBlock ist3 = new TextBlock() { Text = GetNormal(lista[2].Description), Margin = new Thickness(12, 322 + ist1.ActualHeight + ist2.ActualHeight + 4, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Colors.White), TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
                        Rectangle r3 = new Rectangle() { Fill = new SolidColorBrush(Color.FromArgb(255, 26, 28, 30)), Width = 218, Height = 36, Margin = new Thickness(8, 322 + ist1.ActualHeight + ist2.ActualHeight + 4, 12, 12) };
                        r3.Height = ist3.ActualHeight + 2;
                        pan.Children.Add(r3); pan.Children.Add(ist3);
                        AdaugaLinkuri(ref pan, lista[2].Nume, ist3.Margin.Left, ist3.Margin.Top);


                        if (lista.Count > 3)
                        {
                            TextBlock more2 = new TextBlock() { Text = "+ more info", Margin = new Thickness(150, 322 + ist1.ActualHeight + ist2.ActualHeight + ist3.ActualHeight + 6, 12, 10), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Color.FromArgb(255, 139, 146, 5)), Cursor = Cursors.Hand };
                            more2.MouseEnter += new MouseEventHandler(more1_MouseEnter);
                            more2.MouseLeave += new MouseEventHandler(more1_MouseLeave);
                            more2.MouseLeftButtonDown += new MouseButtonEventHandler(more2_MouseLeftButtonDown);
                            pan.Children.Add(more2);
                        }
                    }
                }
            }
            #endregion
        }

        void more2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
         //   canvas2.Children.Clear();
            stat s = new stat(canvas2,lista[0].Expr1);
        }

        void more1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Popup popup = new Popup();
            ExtendedDescription moreInfo = new ExtendedDescription(popup, lista[0].Nume, lista[0].Descriere);
            popup.Child = moreInfo;
            popup.VerticalOffset = 35;
            popup.HorizontalOffset = 380;
            popup.IsOpen = true;
            canvas.Children.Add(popup);
        }

        void more1_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Foreground = new SolidColorBrush(Color.FromArgb(255, 139, 146, 5));
        }

        void more1_MouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Foreground = new SolidColorBrush(Color.FromArgb(255, 208, 218, 8));
        }

        #region Linkuri secsi
        /// <summary>
        /// Creaza linkuri ce le pune peste cu cuv cheie
        /// </summary>
        /// <param name="pan">Canvasu curent</param>
        /// <param name="istoric">Stringu istoricului nenormalizat</param>
        /// <param name="left">marginea din stanga</param>
        /// <param name="top">marginea din dreapta</param>
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
                    add = new TextBlock() { Text = GetNormal(aux.Substring(aux.IndexOf("[b]"), aux.IndexOf("[/b]") - aux.IndexOf("[b]"))), Margin = new Thickness(left + test2.ActualWidth, top, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 124, 170)), TextWrapping = TextWrapping.Wrap, Cursor=Cursors.Hand };
                }
                else
                {
                    double addleft = GetLeftValueFor2Rows(istoric,for2rows++);
                    add = new TextBlock() { Text = GetNormal(aux.Substring(aux.IndexOf("[b]"), aux.IndexOf("[/b]") - aux.IndexOf("[b]"))), Margin = new Thickness(left + addleft, top + 16.9, 12, 12), FontFamily = new FontFamily("Tahoma"), FontSize = 14, Foreground = new SolidColorBrush(Color.FromArgb(255, 33, 124, 170)), TextWrapping = TextWrapping.Wrap, Cursor = Cursors.Hand };
                }
                add.MouseEnter += new MouseEventHandler(add_MouseEnter);
                add.MouseLeave += new MouseEventHandler(add_MouseLeave);
                pan.Children.Add(add);
            }
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
        /// Pt 2 randuri trebuie vazut de unde incepe al doilea rand
        /// </summary>
        /// <param name="istoric">Stringu tot</param>
        /// <returns>Stringu randului 2</returns>
        private double GetLeftValueFor2Rows(string istoric,byte nrcrt)
        {
            string aux=istoric;
            bool ok = true;
            while (ok)
            {
                TextBlock test = new TextBlock() { Text = GetNormal( aux=aux.Substring(0, aux.LastIndexOf(' '))), Margin = new Thickness(12, 0, 12, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 14, TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
                ok = (int)test.ActualHeight != 16;
            }
            istoric = aux = istoric.Substring(aux.Length).TrimStart();
            for (byte b = 0; b < nrcrt; b++) aux = aux.Substring(aux.IndexOf("[/b]") + 4);
            TextBlock test2 = new TextBlock() { Text = GetNormal(istoric.Substring(0, istoric.Length - aux.Length) + aux.Substring(0, aux.IndexOf("[b]"))), Margin = new Thickness(12, 0, 12, 0), FontFamily = new FontFamily("Tahoma"), FontSize = 14, TextWrapping = TextWrapping.Wrap, Width = 214, Height = 34 };
            return test2.ActualWidth;
        }

        /// <summary>
        /// Normalizeaza Stringu (Elimina [b] si [/b])
        /// </summary>
        /// <param name="istoric">Stringu nenormalizat</param>
        /// <returns>Stringu normalizat</returns>
        private string GetNormal(string istoric)
        {
            return istoric.Replace("[b]", "").Replace("[/b]", "");
        }
        #endregion
    }
}
