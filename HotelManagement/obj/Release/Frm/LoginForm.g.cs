﻿#pragma checksum "..\..\..\Frm\LoginForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "14406874802D675AD166D1C0F48346A10BB664799446B707581725CE67CC18A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HotelManagement.Frm;
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


namespace HotelManagement.Frm {
    
    
    /// <summary>
    /// LoginForm
    /// </summary>
    public partial class LoginForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Frm\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbUser;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Frm\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox tbPass;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Frm\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPassUnmask;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Frm\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ShowPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/HotelManagement;component/frm/loginform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Frm\LoginForm.xaml"
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
            this.tbUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbPass = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.tbPassUnmask = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ShowPassword = ((System.Windows.Controls.TextBlock)(target));
            
            #line 17 "..\..\..\Frm\LoginForm.xaml"
            this.ShowPassword.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ShowPassword_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\Frm\LoginForm.xaml"
            this.ShowPassword.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ShowPassword_PreviewMouseUp);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\Frm\LoginForm.xaml"
            this.ShowPassword.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ShowPassword_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 19 "..\..\..\Frm\LoginForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

