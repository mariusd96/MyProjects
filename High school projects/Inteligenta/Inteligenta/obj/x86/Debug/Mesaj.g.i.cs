﻿#pragma checksum "..\..\..\Mesaj.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DC880928CBFA2E36374FBFAD2C7E4212"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
    /// Mesaj
    /// </summary>
    public partial class Mesaj : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\Mesaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border1;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Mesaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas1;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Mesaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas2;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Mesaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Mesaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label text;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Mesaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ok;
        
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
            System.Uri resourceLocater = new System.Uri("/Inteligenta;component/mesaj.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Mesaj.xaml"
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
            this.border1 = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.canvas1 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.canvas2 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 4:
            this.close = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\Mesaj.xaml"
            this.close.Click += new System.Windows.RoutedEventHandler(this.close_Click);
            
            #line default
            #line hidden
            
            #line 59 "..\..\..\Mesaj.xaml"
            this.close.MouseEnter += new System.Windows.Input.MouseEventHandler(this.close_MouseEnter);
            
            #line default
            #line hidden
            
            #line 59 "..\..\..\Mesaj.xaml"
            this.close.MouseLeave += new System.Windows.Input.MouseEventHandler(this.close_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.text = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.ok = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\Mesaj.xaml"
            this.ok.Click += new System.Windows.RoutedEventHandler(this.ok_Click);
            
            #line default
            #line hidden
            
            #line 62 "..\..\..\Mesaj.xaml"
            this.ok.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ok_MouseEnter);
            
            #line default
            #line hidden
            
            #line 62 "..\..\..\Mesaj.xaml"
            this.ok.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ok_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
