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
using bing.Forme;
using Regiuni;

namespace bing
{
    public class CNavigationSystem
    {
        /// <summary>
        /// Store the current instance for global use
        /// </summary>
        private static CNavigationSystem instance;

        /// <summary>
        /// Standard constructor
        /// </summary>
        private CNavigationSystem()
        {
        }

        /// <summary>
        /// Used for instantiation
        /// </summary>
        /// <returns> Returns the current instance or a new instance </returns>
        public static CNavigationSystem getInstance()
        {
            if (instance == null)
                return new CNavigationSystem();
            return instance;
        }

        /// <summary>
        /// Navigate to the current Region
        /// </summary>
        public void goToCurrentRegion()
        {
            string regiuneaCurenta = AtributeGlobale.RegiuneaCurenta.ToString();

            // Going backwards from Campie/Padure to Subregiune
            if (AtributeGlobale.ZonaCurenta != AtributeGlobale.EnumZone.NoZoneSelected)
            {
                Moldova.setGrade(0);
                pesteHarta.setGrade(180);
            }

            CBackButton.getInstance().resetViewFromSubregionToMap();

            switch (regiuneaCurenta)
            {
                case "Moldova":
                    {
                        MapLayers.getInstance().lol();
                        break;
                    }

                case "Banat":
                    {
                        break;
                    }

                case "Baragan":
                    {
                        break;
                    }

                case "Transilvania":
                    {
                        break;
                    }
            }
            
        }

        /// <summary>
        /// Navigate to the current Subregion
        /// </summary>
        public void goToCurrentSubRegion()
        {
            CBackButton.getInstance().resetViewFromZoneToSubregion();
        }
    }
}