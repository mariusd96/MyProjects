﻿#pragma checksum "..\..\..\Optiuni.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2FE857DBBA920E9BB97F3BEA97240267"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Inteligenta {
    
    
    /// <summary>
    /// Optiuni
    /// </summary>
    public partial class Optiuni : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\..\Optiuni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas1;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Optiuni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button setari;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Optiuni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button despre_soft;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Optiuni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deconectare;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Optiuni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button inapoi;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Inteligenta;component/optiuni.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Optiuni.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.canvas1 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.setari = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\Optiuni.xaml"
            this.setari.Click += new System.Windows.RoutedEventHandler(this.setari_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.despre_soft = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\Optiuni.xaml"
            this.despre_soft.Click += new System.Windows.RoutedEventHandler(this.despre_soft_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.deconectare = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\Optiuni.xaml"
            this.deconectare.Click += new System.Windows.RoutedEventHandler(this.deconectare_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.inapoi = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Optiuni.xaml"
            this.inapoi.Click += new System.Windows.RoutedEventHandler(this.inapoi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

