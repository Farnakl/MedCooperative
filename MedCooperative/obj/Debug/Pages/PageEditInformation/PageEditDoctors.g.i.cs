﻿#pragma checksum "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "00AECA6ACAC10E600DC6A1ADA9E205ED6A47A43BD75EBD2FC66C6894557541AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MedCooperative.Pages.PageEditInformation;
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


namespace MedCooperative.Pages.PageEditInformation {
    
    
    /// <summary>
    /// PageEditDoctors
    /// </summary>
    public partial class PageEditDoctors : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StFormView;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbName;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbCabinet;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbSpeciality;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StFormEdit;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbGender;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbStatus;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
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
            System.Uri resourceLocater = new System.Uri("/MedCooperative;component/pages/pageeditinformation/pageeditdoctors.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
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
            this.StFormView = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.TxbName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TxbCabinet = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
            this.TxbCabinet.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TxbCabinet_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CmbSpeciality = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.StFormEdit = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.CmbGender = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.CmbStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\..\Pages\PageEditInformation\PageEditDoctors.xaml"
            this.BtnEdit.Click += new System.Windows.RoutedEventHandler(this.BtnEdit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

