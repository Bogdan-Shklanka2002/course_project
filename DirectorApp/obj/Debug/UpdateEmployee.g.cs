#pragma checksum "..\..\UpdateEmployee.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "34CE7876216E5812C67F024E6AE9F508CB786A91006ADBB2DBC73C9C34654D1C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DirectorApp;
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


namespace DirectorApp {
    
    
    /// <summary>
    /// UpdateEmployee
    /// </summary>
    public partial class UpdateEmployee : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\UpdateEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid searchOrderGrid;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\UpdateEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\UpdateEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\UpdateEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox employeeNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\UpdateEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox employeeSurnameTextBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\UpdateEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox employeeFatherNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\UpdateEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox employeePositionComboBox;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\UpdateEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox employeeLoginTextBox;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\UpdateEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox employeePasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\UpdateEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateButton;
        
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
            System.Uri resourceLocater = new System.Uri("/DirectorApp;component/updateemployee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UpdateEmployee.xaml"
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
            this.searchOrderGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.searchTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.searchButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\UpdateEmployee.xaml"
            this.searchButton.Click += new System.Windows.RoutedEventHandler(this.searchButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.employeeNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.employeeSurnameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.employeeFatherNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.employeePositionComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.employeeLoginTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.employeePasswordTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.updateButton = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\UpdateEmployee.xaml"
            this.updateButton.Click += new System.Windows.RoutedEventHandler(this.updateButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

