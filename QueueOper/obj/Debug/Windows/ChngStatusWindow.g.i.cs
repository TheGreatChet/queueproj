﻿#pragma checksum "..\..\..\Windows\ChngStatusWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0E2E5176481FDC2F5EDD70C89040A41149E25FD48808D8A141BC5CAFC379D014"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QueueOper.Windows;
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


namespace QueueOper.Windows {
    
    
    /// <summary>
    /// ChngStatusWindow
    /// </summary>
    public partial class ChngStatusWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Windows\ChngStatusWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NumLbl;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Windows\ChngStatusWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PrevStatusTb;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Windows\ChngStatusWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox NewStatusCb;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Windows\ChngStatusWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveChngBtn;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Windows\ChngStatusWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelChngBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/QueueOper;component/windows/chngstatuswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\ChngStatusWindow.xaml"
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
            this.NumLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.PrevStatusTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.NewStatusCb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.SaveChngBtn = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\Windows\ChngStatusWindow.xaml"
            this.SaveChngBtn.Click += new System.Windows.RoutedEventHandler(this.SaveChngBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CancelChngBtn = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\Windows\ChngStatusWindow.xaml"
            this.CancelChngBtn.Click += new System.Windows.RoutedEventHandler(this.CancelChngBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

