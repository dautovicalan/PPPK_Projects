﻿#pragma checksum "..\..\EditPersonPage - Copy.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B6A2CCC99A14A812EC0B5713DADFB809E3911D36A76327D73FB2EA64CF55FAEB"
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
using Zadatak;


namespace Zadatak {
    
    
    /// <summary>
    /// EditPersonPage
    /// </summary>
    public partial class EditPersonPage : Zadatak.FramedPage, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\EditPersonPage - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridContainter;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\EditPersonPage - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\EditPersonPage - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbFirstName;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\EditPersonPage - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbLastName;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\EditPersonPage - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbAge;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\EditPersonPage - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbEmail;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\EditPersonPage - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCommit;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\EditPersonPage - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnUpload;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\EditPersonPage - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border PictureBorder;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\EditPersonPage - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Picture;
        
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
            System.Uri resourceLocater = new System.Uri("/Zadatak;component/editpersonpage%20-%20copy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditPersonPage - Copy.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.GridContainter = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\EditPersonPage - Copy.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TbFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TbLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TbAge = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TbEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BtnCommit = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\EditPersonPage - Copy.xaml"
            this.BtnCommit.Click += new System.Windows.RoutedEventHandler(this.BtnCommit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnUpload = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\EditPersonPage - Copy.xaml"
            this.BtnUpload.Click += new System.Windows.RoutedEventHandler(this.BtnUpload_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.PictureBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            this.Picture = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
