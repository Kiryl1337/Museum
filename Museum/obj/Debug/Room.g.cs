#pragma checksum "..\..\Room.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C9FB7A049179E0E2A0C8D873C1D0C7E7EE976855"
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
    /// Room
    /// </summary>
    public partial class Room : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\Room.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Room.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid roomGrid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Room.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button view_data;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Room.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer form;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Room.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox id;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Room.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox floor;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Room.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox square;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Room.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Room.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reset;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\Room.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_btn;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Room.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button update_btn;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\Room.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Museum;component/room.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Room.xaml"
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
            this.roomGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 27 "..\..\Room.xaml"
            this.roomGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.roomGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.view_data = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Room.xaml"
            this.view_data.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.form = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 5:
            this.id = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.floor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.square = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.reset = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\Room.xaml"
            this.reset.Click += new System.Windows.RoutedEventHandler(this.reset_btn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.add_btn = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\Room.xaml"
            this.add_btn.Click += new System.Windows.RoutedEventHandler(this.add_btn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.update_btn = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\Room.xaml"
            this.update_btn.Click += new System.Windows.RoutedEventHandler(this.update_btn_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.delete_btn = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\Room.xaml"
            this.delete_btn.Click += new System.Windows.RoutedEventHandler(this.delete_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

