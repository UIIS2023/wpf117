﻿#pragma checksum "..\..\..\Forme\FrmPisac.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "31082BA1928900AD348AC83AD2F94344DCD1A57077C780EA5AA8DB46A1EB1589"
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
using WPFKnjižara.Forme;


namespace WPFKnjižara.Forme {
    
    
    /// <summary>
    /// FrmPisac
    /// </summary>
    public partial class FrmPisac : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Forme\FrmPisac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPisacIme;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Forme\FrmPisac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPisacPrezime;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Forme\FrmPisac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button txtbtnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Forme\FrmPisac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button txtbtnOtkazi;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFKnjižara;component/forme/frmpisac.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forme\FrmPisac.xaml"
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
            this.txtPisacIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtPisacPrezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtbtnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Forme\FrmPisac.xaml"
            this.txtbtnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.txtbtnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtbtnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Forme\FrmPisac.xaml"
            this.txtbtnOtkazi.Click += new System.Windows.RoutedEventHandler(this.txtbtnOtkazi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

