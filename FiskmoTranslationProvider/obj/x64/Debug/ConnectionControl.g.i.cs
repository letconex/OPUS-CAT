﻿#pragma checksum "..\..\..\ConnectionControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B8F1DEB4D27672E2E6E597270A3D661C123736F3D7D8D2CE08E0853F2558A5CE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FiskmoTranslationProvider;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace FiskmoTranslationProvider {
    
    
    /// <summary>
    /// ConnectionControl
    /// </summary>
    public partial class ConnectionControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FiskmoTranslationProvider.ConnectionControl _this;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox UseCustomConnection;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ServicePortBoxElement;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ServiceAddressBoxElement;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveAsDefaultButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RetryConnectionButton;
        
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
            System.Uri resourceLocater = new System.Uri("/FiskmoTranslationProvider;component/connectioncontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ConnectionControl.xaml"
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
            this._this = ((FiskmoTranslationProvider.ConnectionControl)(target));
            return;
            case 2:
            this.UseCustomConnection = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.ServicePortBoxElement = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\ConnectionControl.xaml"
            this.ServicePortBoxElement.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ServicePortBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ServiceAddressBoxElement = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.SaveAsDefaultButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\ConnectionControl.xaml"
            this.SaveAsDefaultButton.Click += new System.Windows.RoutedEventHandler(this.SaveAsDefault_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RetryConnectionButton = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\ConnectionControl.xaml"
            this.RetryConnectionButton.Click += new System.Windows.RoutedEventHandler(this.RetryConnection_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

