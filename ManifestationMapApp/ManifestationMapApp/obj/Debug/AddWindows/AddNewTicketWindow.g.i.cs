﻿#pragma checksum "..\..\..\AddWindows\AddNewTicketWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9764394EF4BD8C3561BE2B2FA14CB9E9CE9A17B7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ManifestationMapApp;
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


namespace ManifestationMapApp {
    
    
    /// <summary>
    /// AddNewTicketWindow
    /// </summary>
    public partial class AddNewTicketWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtID;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDesc;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label error;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rtgColour;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChoseColour;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblErrorIDNaN;
        
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
            System.Uri resourceLocater = new System.Uri("/ManifestationMapApp;component/addwindows/addnewticketwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
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
            this.txtID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtDesc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.error = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.rtgColour = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 7:
            this.btnChoseColour = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\AddWindows\AddNewTicketWindow.xaml"
            this.btnChoseColour.Click += new System.Windows.RoutedEventHandler(this.BtnChoseColour_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblErrorIDNaN = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

