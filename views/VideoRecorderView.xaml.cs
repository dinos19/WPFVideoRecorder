using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VideoRecorder.viewmodels;

namespace VideoRecorder.views 
{
    /// <summary>
    /// Interaction logic for VideoRecorderView.xaml
    /// </summary>
    public partial class VideoRecorderView : UserControl
    {
        VideoRecorderViewModel videoRecorderViewModel;
        public VideoRecorderView()
        {
            InitializeComponent();
             videoRecorderViewModel = new VideoRecorderViewModel();
            
            this.DataContext = videoRecorderViewModel;
        }

        private void availableDevicesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            videoRecorderViewModel.CameraDeviceChanged((FilterInfo)availableDevicesComboBox.SelectedItem);
        }

        private void availableCamQualitiesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StartRecordingBtn_Click(object sender, RoutedEventArgs e)
        {
            videoRecorderViewModel.StartRecording();
        }

        private void stopRecBtn_Click(object sender, RoutedEventArgs e)
        {
            videoRecorderViewModel.StopRecording();
        }
    }
}
