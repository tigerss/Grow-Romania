﻿#pragma checksum "D:\Proiecte\IC\trunk\bing2\bing\History.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "97E8ABA6248D685608CD280AAE85DA31"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace bing {
    
    
    public partial class History : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TabControl tabControl1;
        
        internal System.Windows.Controls.TabItem Individual;
        
        internal System.Windows.Controls.DataGrid dataGrid1;
        
        internal System.Windows.Controls.DataGridTemplateColumn Coloana1;
        
        internal System.Windows.Controls.DataVisualization.Charting.Chart MyPie;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        internal System.Windows.Controls.TextBlock textBlock2;
        
        internal System.Windows.Controls.TabItem All;
        
        internal System.Windows.Controls.DataVisualization.Charting.Chart AllChart;
        
        internal System.Windows.Controls.DataVisualization.Charting.LinearAxis LinearAxis;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/bing;component/History.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.tabControl1 = ((System.Windows.Controls.TabControl)(this.FindName("tabControl1")));
            this.Individual = ((System.Windows.Controls.TabItem)(this.FindName("Individual")));
            this.dataGrid1 = ((System.Windows.Controls.DataGrid)(this.FindName("dataGrid1")));
            this.Coloana1 = ((System.Windows.Controls.DataGridTemplateColumn)(this.FindName("Coloana1")));
            this.MyPie = ((System.Windows.Controls.DataVisualization.Charting.Chart)(this.FindName("MyPie")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock2")));
            this.All = ((System.Windows.Controls.TabItem)(this.FindName("All")));
            this.AllChart = ((System.Windows.Controls.DataVisualization.Charting.Chart)(this.FindName("AllChart")));
            this.LinearAxis = ((System.Windows.Controls.DataVisualization.Charting.LinearAxis)(this.FindName("LinearAxis")));
        }
    }
}

