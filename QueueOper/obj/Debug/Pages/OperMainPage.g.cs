#pragma checksum "..\..\..\Pages\OperMainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "45539686B5066EF66F7129DF580CE75C45EB655F089E8B1489A31287AB2C40E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QueueOper.Pages;
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


namespace QueueOper.Pages {
    
    
    /// <summary>
    /// OperMainPage
    /// </summary>
    public partial class OperMainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Pages\OperMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView QueryLw;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Pages\OperMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ChngStatusBtn;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Pages\OperMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem DelBtn;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Pages\OperMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NumLbl;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Pages\OperMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DateCb;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Pages\OperMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartNewQuBtn;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Pages\OperMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClearThisQuBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/QueueOper;component/pages/opermainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\OperMainPage.xaml"
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
            this.QueryLw = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.ChngStatusBtn = ((System.Windows.Controls.MenuItem)(target));
            
            #line 60 "..\..\..\Pages\OperMainPage.xaml"
            this.ChngStatusBtn.Click += new System.Windows.RoutedEventHandler(this.ChngStatusBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DelBtn = ((System.Windows.Controls.MenuItem)(target));
            
            #line 64 "..\..\..\Pages\OperMainPage.xaml"
            this.DelBtn.Click += new System.Windows.RoutedEventHandler(this.DelBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NumLbl = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.DateCb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 92 "..\..\..\Pages\OperMainPage.xaml"
            this.DateCb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DateCb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StartNewQuBtn = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\..\Pages\OperMainPage.xaml"
            this.StartNewQuBtn.Click += new System.Windows.RoutedEventHandler(this.StartNewQuBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ClearThisQuBtn = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\..\Pages\OperMainPage.xaml"
            this.ClearThisQuBtn.Click += new System.Windows.RoutedEventHandler(this.ClearThisQuBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

