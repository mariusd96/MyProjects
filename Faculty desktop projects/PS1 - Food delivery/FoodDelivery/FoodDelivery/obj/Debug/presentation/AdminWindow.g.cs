﻿#pragma checksum "..\..\..\presentation\AdminWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4EE9A0587BFD4959EAD7835E7A398199"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FoodDelivery.presentation;
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


namespace FoodDelivery.presentation {
    
    
    /// <summary>
    /// AdminWindow
    /// </summary>
    public partial class AdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\presentation\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel TitleBar;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\presentation\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button userOptions;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\presentation\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Logout;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\presentation\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minimize;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\presentation\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\presentation\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createCont;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\presentation\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateCont;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\presentation\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateMenu;
        
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
            System.Uri resourceLocater = new System.Uri("/FoodDelivery;component/presentation/adminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\presentation\AdminWindow.xaml"
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
            this.TitleBar = ((System.Windows.Controls.DockPanel)(target));
            
            #line 30 "..\..\..\presentation\AdminWindow.xaml"
            this.TitleBar.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TitleBar_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.userOptions = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\presentation\AdminWindow.xaml"
            this.userOptions.Click += new System.Windows.RoutedEventHandler(this.userOptions_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Logout = ((System.Windows.Controls.MenuItem)(target));
            
            #line 38 "..\..\..\presentation\AdminWindow.xaml"
            this.Logout.Click += new System.Windows.RoutedEventHandler(this.Logout_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.minimize = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\presentation\AdminWindow.xaml"
            this.minimize.Click += new System.Windows.RoutedEventHandler(this.minimize_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.createCont = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\presentation\AdminWindow.xaml"
            this.createCont.Click += new System.Windows.RoutedEventHandler(this.createCont_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.updateCont = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\presentation\AdminWindow.xaml"
            this.updateCont.Click += new System.Windows.RoutedEventHandler(this.updateCont_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.updateMenu = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\presentation\AdminWindow.xaml"
            this.updateMenu.Click += new System.Windows.RoutedEventHandler(this.updateMenu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

