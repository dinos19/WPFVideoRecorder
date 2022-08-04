﻿#pragma checksum "..\..\..\views\VideoRecorderView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "868338F8E5549F718F87A572ADE44918563143A03BC14892EE6A509CE4700900"
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
using VideoRecorder.views;


namespace VideoRecorder.views {
    
    
    /// <summary>
    /// VideoRecorderView
    /// </summary>
    public partial class VideoRecorderView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 54 "..\..\..\views\VideoRecorderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CurrentFrame;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\views\VideoRecorderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RecordingTimeText;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\views\VideoRecorderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox availableDevicesComboBox;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\views\VideoRecorderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button stopRecBtn;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\views\VideoRecorderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendFileBtn;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\views\VideoRecorderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartRecordingBtn;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\views\VideoRecorderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button takeSnapshotBtn;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\views\VideoRecorderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveToBtn;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\views\VideoRecorderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelRecord;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\views\VideoRecorderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox availableCamQualitiesComboBox;
        
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
            System.Uri resourceLocater = new System.Uri("/VideoRecorder;component/views/videorecorderview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\views\VideoRecorderView.xaml"
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
            this.CurrentFrame = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.RecordingTimeText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.availableDevicesComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 78 "..\..\..\views\VideoRecorderView.xaml"
            this.availableDevicesComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.availableDevicesComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.stopRecBtn = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\views\VideoRecorderView.xaml"
            this.stopRecBtn.Click += new System.Windows.RoutedEventHandler(this.stopRecBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.sendFileBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.StartRecordingBtn = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\views\VideoRecorderView.xaml"
            this.StartRecordingBtn.Click += new System.Windows.RoutedEventHandler(this.StartRecordingBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.takeSnapshotBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.saveToBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.cancelRecord = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.availableCamQualitiesComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 112 "..\..\..\views\VideoRecorderView.xaml"
            this.availableCamQualitiesComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.availableCamQualitiesComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
