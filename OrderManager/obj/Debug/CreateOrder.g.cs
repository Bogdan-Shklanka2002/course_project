﻿#pragma checksum "..\..\CreateOrder.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B9899F4EB0A2E1C236DA69D13E8FBACD28BC965A0BAA09889C4440A74F03F244"
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


namespace OrderManager {
    
    
    /// <summary>
    /// CreateOrder
    /// </summary>
    public partial class CreateOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox deviceComboBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox statusComboBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateOrder;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox typeOrderComboBox;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox workmanComboBox;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceTextBox;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isNewClient;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid searchGrid;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchClient;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addClient;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox descriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\CreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createOrder;
        
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
            System.Uri resourceLocater = new System.Uri("/OrderManager;component/createorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreateOrder.xaml"
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
            this.deviceComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.statusComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.dateOrder = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.typeOrderComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.workmanComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.priceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.isNewClient = ((System.Windows.Controls.CheckBox)(target));
            
            #line 103 "..\..\CreateOrder.xaml"
            this.isNewClient.Click += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.searchGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.searchTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.searchClient = ((System.Windows.Controls.Button)(target));
            
            #line 117 "..\..\CreateOrder.xaml"
            this.searchClient.Click += new System.Windows.RoutedEventHandler(this.searchClient_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.addClient = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\CreateOrder.xaml"
            this.addClient.Click += new System.Windows.RoutedEventHandler(this.addClient_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.descriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.createOrder = ((System.Windows.Controls.Button)(target));
            
            #line 127 "..\..\CreateOrder.xaml"
            this.createOrder.Click += new System.Windows.RoutedEventHandler(this.createOrder_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
