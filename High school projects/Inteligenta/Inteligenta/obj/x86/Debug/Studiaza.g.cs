﻿#pragma checksum "..\..\..\Studiaza.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4488C9EE2696846FB349F9BE90DB8968"
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
    /// Studiaza
    /// </summary>
    public partial class Studiaza : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 84 "..\..\..\Studiaza.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas1;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Studiaza.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button definire;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Studiaza.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button teorii;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Studiaza.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button masurarea_inteligentei;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Studiaza.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Inteligenta;component/studiaza.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Studiaza.xaml"
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
            this.definire = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\Studiaza.xaml"
            this.definire.Click += new System.Windows.RoutedEventHandler(this.definire_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.teorii = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Studiaza.xaml"
            this.teorii.Click += new System.Windows.RoutedEventHandler(this.teorii_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.masurarea_inteligentei = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\Studiaza.xaml"
            this.masurarea_inteligentei.Click += new System.Windows.RoutedEventHandler(this.masurarea_inteligentei_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.inapoi = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\Studiaza.xaml"
            this.inapoi.Click += new System.Windows.RoutedEventHandler(this.inapoi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

