﻿#pragma checksum "..\..\LogAdmin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0EEEF233E0BD770049545EC812B98573"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Scientia_interfejs_alpha;
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


namespace Scientia_interfejs_alpha {
    
    
    /// <summary>
    /// LogAdmin
    /// </summary>
    public partial class LogAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\LogAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtboxlog;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\LogAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtboxpsw;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\LogAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnzaloguj;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\LogAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\LogAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnkontakt;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\LogAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnwroc;
        
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
            System.Uri resourceLocater = new System.Uri("/Scientia_interfejs_alpha;component/logadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LogAdmin.xaml"
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
            this.txtboxlog = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtboxpsw = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.btnzaloguj = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\LogAdmin.xaml"
            this.btnzaloguj.Click += new System.Windows.RoutedEventHandler(this.Btnzaloguj_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.btnkontakt = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\LogAdmin.xaml"
            this.btnkontakt.Click += new System.Windows.RoutedEventHandler(this.btnkontakt_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnwroc = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\LogAdmin.xaml"
            this.btnwroc.Click += new System.Windows.RoutedEventHandler(this.btnwroc_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

