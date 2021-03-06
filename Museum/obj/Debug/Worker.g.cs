#pragma checksum "..\..\Worker.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2DE4AB4F80960AAE2349D1085E611607E83122A4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Museum;
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


namespace Museum {
    
    
    /// <summary>
    /// Worker
    /// </summary>
    public partial class Worker : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid workerGrid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button view_data;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer form;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FIO;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox choosePosition;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox login;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reset;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_btn;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button update_btn;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\Worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete_btn;
        
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
            System.Uri resourceLocater = new System.Uri("/Museum;component/worker.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Worker.xaml"
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
            this.Label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.workerGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 27 "..\..\Worker.xaml"
            this.workerGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.workerGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.view_data = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Worker.xaml"
            this.view_data.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.form = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 5:
            this.FIO = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.choosePosition = ((System.Windows.Controls.ComboBox)(target));
            
            #line 49 "..\..\Worker.xaml"
            this.choosePosition.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.choosePosition_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.reset = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\Worker.xaml"
            this.reset.Click += new System.Windows.RoutedEventHandler(this.reset_btn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.add_btn = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\Worker.xaml"
            this.add_btn.Click += new System.Windows.RoutedEventHandler(this.add_btn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.update_btn = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\Worker.xaml"
            this.update_btn.Click += new System.Windows.RoutedEventHandler(this.update_btn_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.delete_btn = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\Worker.xaml"
            this.delete_btn.Click += new System.Windows.RoutedEventHandler(this.delete_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

