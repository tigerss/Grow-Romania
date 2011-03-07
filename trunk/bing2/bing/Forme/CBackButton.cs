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
using Regiuni;
using Microsoft.Maps.MapControl;

namespace bing.Forme
{
    public class CBackButton
    {
        private static CBackButton instance;
        MainPage mainPage;
        Canvas m_parentCanvas;
        Canvas m_buttonCanvas;
        String m_Url;
        Image m_Image;
        double m_Top;
        double m_Left;
        bool isVisible;

        #region Variabile Animatie
        DoubleAnimation doubleAnimation1 = new DoubleAnimation();
        DoubleAnimation doubleAnimation2 = new DoubleAnimation();
        Storyboard storyBoard1 = new Storyboard();
        Storyboard storyBoard2 = new Storyboard();
        #endregion

        /// <summary>
        /// Private constructor, stops instantiation of more than one object
        /// </summary>
        /// <param name="url">Image Url</param>
        /// <param name="top">The distance from the top side of the Canvas</param>
        /// <param name="left">The distance from the Left side of the Canvas</param>
        private CBackButton(String url, double top, double left)
        {
            m_Url = url;
            m_Top = top;
            m_Left = left;
            mainPage = MainPage.getInstance();
            m_parentCanvas = mainPage.canvas2;
            isVisible = true;

            initialise();

            // Store this instance
            instance = this;
        }

        /// <summary>
        /// Initialisation of the button
        /// </summary>
        private void initialise()
        {
            m_Image = new Image()
            {
                Source = new BitmapImage(
                    new Uri(
                        m_Url,
                        UriKind.Relative
                        )
                        ),
                Width = 38,
                Height = 21
            };

            m_buttonCanvas = new Canvas()
            {
                Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xcc, 0xdf, 0xf5)),
                Opacity = .46,
                Width = 50,
                Height = 50,
                Clip = new RectangleGeometry()
                {
                    RadiusX = 10,
                    RadiusY = 10,
                    Rect = new Rect(0, 0, 150, 40)
                }
            };

            // Imagine
            m_buttonCanvas.Children.Add(m_Image);
            Canvas.SetTop(m_Image, 10);
            Canvas.SetLeft(m_Image, 6);

            // Adaug butonul la canvas-ul principal
            m_parentCanvas.Children.Add(m_buttonCanvas);
            Canvas.SetTop(m_buttonCanvas, m_Top);
            Canvas.SetLeft(m_buttonCanvas, m_Left);
            Canvas.SetZIndex(m_buttonCanvas, 3);

            // Events
            m_buttonCanvas.MouseEnter += new MouseEventHandler(m_buttonCanvas_MouseEnter);
            m_buttonCanvas.MouseLeave += new MouseEventHandler(m_buttonCanvas_MouseLeave);
            m_buttonCanvas.MouseLeftButtonUp += new MouseButtonEventHandler(m_buttonCanvas_MouseLeftButtonUp);
                
            setUpAnimation();
        }

        /// <summary>
        /// Mouse Clicked canvas event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_buttonCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            storyBoard1.Stop();
            onMouseClickBackButtonEvent();
        }

        /// <summary>
        /// Mouse Leave canvas event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_buttonCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            storyBoard1.Stop();
            storyBoard2.Begin();
        }

        /// <summary>
        /// Mouse Enter Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_buttonCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            storyBoard1.Begin();
            storyBoard2.Stop();
        }

        /// <summary>
        /// Set up button animation
        /// </summary>
        private void setUpAnimation()
        {
            doubleAnimation1.To = 125;
            doubleAnimation2.To = 632;

            storyBoard1.Duration = new Duration(new TimeSpan(0, 0, 0, 2));
            storyBoard1.SpeedRatio = 4;

            Storyboard.SetTarget(doubleAnimation1, m_buttonCanvas);
            Storyboard.SetTargetProperty(doubleAnimation1, new PropertyPath(Canvas.WidthProperty));
            Storyboard.SetTarget(doubleAnimation2, m_buttonCanvas);
            Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath(Canvas.LeftProperty));

            storyBoard1.Children.Add(doubleAnimation1);
            storyBoard1.Children.Add(doubleAnimation2);
        }

        /// <summary>
        /// Query the button visibility
        /// </summary>
        /// <returns> True/False </returns>
        public bool isButtonVisible()
        {
            return isVisible;
        }

        /// <summary>
        /// Set the button's visibility
        /// </summary>
        /// <param name="visible"></param>
        public void setVisibility(bool visible)
        {
            isVisible = visible;

            if (isVisible == true)
                m_buttonCanvas.Visibility = Visibility.Visible;
            else
                m_buttonCanvas.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Add the button to MainPage.Canvas2
        /// If the button is already added check it's visibility
        /// </summary>
        public void addButtonToCanvas()
        {
            // Verify if the button is already a child for Parent Canvas2
            if (m_parentCanvas.Children.Contains(m_buttonCanvas))
                if (isVisible == false)
                {
                    setVisibility(true);
                }
                else { }
            // The button is added to Canvas2
            else
            {
                m_parentCanvas.Children.Add(m_buttonCanvas);
                setVisibility(true);
            }
        }

        /// <summary>
        /// Remove the button from MainPage.Canvas2
        /// </summary>
        public void removeButtonFromCanvas()
        {
            m_parentCanvas.Children.Remove(m_buttonCanvas);
        }

        /// <summary>
        /// Get this instance. The instantiation takes place here
        /// Singleton Pattern
        /// </summary>
        /// <returns>The class instance</returns>
        public static CBackButton getInstance()
        {
            if (instance == null)
                return new CBackButton("../DesignImages/avion.png", 10, 707);
            return instance;
        }

        #region Go Back Button

        /// <summary>
        /// Standard Event for Back Button
        /// </summary>
        public void onMouseClickBackButtonEvent()
        {
            // User is watching the village
            if (AtributeGlobale.SubRegiuneaCurenta == AtributeGlobale.EnumSubRegiuni.NoSubRegionSelected)
            {
                resetToMapView();
            }
                // Padure sau Campie
            else if (AtributeGlobale.ZonaCurenta != AtributeGlobale.EnumZone.NoZoneSelected)
            {
                resetViewFromZoneToSubregion();
            }
                // Watching the Main Map
            else if (AtributeGlobale.SubRegiuneaCurenta != AtributeGlobale.EnumSubRegiuni.NoSubRegionSelected)
            {
                resetViewFromSubregionToMap();
            }
        }

        ///<summary>
        /// Reset to map view when Back Button is Pressed
        ///</summary>
        public void resetToMapView()
        {
            Map map = mainPage.map;
            MapLayers maplayer = mainPage.getMapLayer();

            map.Children.Clear();

            // Add a border
            if (mainPage.mainBorder.Parent == null)
            {
                mainPage.canvas2.Background = new SolidColorBrush(Colors.Transparent);
                mainPage.canvas2.Children.Add(mainPage.mainBorder);
            }

            map.Children.Add(maplayer.RomaniaMap());
            map.Children.Add(maplayer.PoligonMoldova());
            map.Children.Add(maplayer.PoligonTransilvania());
            map.Children.Add(maplayer.PoligonBaragan());
            map.Children.Add(maplayer.PoligonBanat());

            maplayer.PoligonMoldova().Visibility = System.Windows.Visibility.Visible;
            maplayer.PoligonBaragan().Visibility = System.Windows.Visibility.Visible;
            maplayer.PoligonTransilvania().Visibility = System.Windows.Visibility.Visible;
            maplayer.PoligonBanat().Visibility = System.Windows.Visibility.Visible;
            maplayer.Lat = maplayer.latitudine;
            maplayer.Long = maplayer.longitudine;
            maplayer.bIsMousePressedMoldova = false;
            maplayer.bIsMousePressedBaragan = false;
            maplayer.bIsMousePressedBanat = false;
            maplayer.bIsMousePressedTransilvania = false;
            maplayer.timer.Stop();
            maplayer.TimeIsOn = false;
            maplayer.Z = maplayer.zoom;

            map.SetView(new Location(maplayer.latitudine, maplayer.longitudine), maplayer.zoom);
            AtributeGlobale.RegiuneaCurenta = AtributeGlobale.EnumRegiuni.NoRegionSelected;
            AtributeGlobale.SubRegiuneaCurenta = AtributeGlobale.EnumSubRegiuni.NoSubRegionSelected;

            // Show the current region
            PaginaUser.getInstance().updateCurrentRegion();

            mainPage.setBZoomEnable(false);
            setVisibility(false);
        }

        /// <summary>
        /// Reset to map view when user is in the village
        /// </summary>
        public void resetViewFromSubregionToMap()
        {
            Canvas canvas2 = m_parentCanvas;
            Map map = mainPage.map;

            canvas2.Children.Clear();
            canvas2.Children.Add(map);
            addButtonToCanvas();

            Moldova.setGrade(0);
            PlaneProjection planeproj = new PlaneProjection();
            planeproj.RotationY = 0;
            canvas2.Projection = planeproj;
            map.Projection = planeproj;
            map.Visibility = System.Windows.Visibility.Visible;

            resetToMapView();
        }

        /// <summary>
        /// Reset the view from Campie/Padure to the current Subregion
        /// </summary>
        public void resetViewFromZoneToSubregion()
        {
            AtributeGlobale.ZonaCurenta = AtributeGlobale.EnumZone.NoZoneSelected;
            Moldova.setGrade(0);
            pesteHarta.setGrade(180);
            Moldova.getInstance().goToMoldova();
            PaginaUser.getInstance().updateCurrentRegion();
        }
        #endregion
    }
}
