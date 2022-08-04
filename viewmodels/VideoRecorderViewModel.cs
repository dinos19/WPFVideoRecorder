using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using VideoRecorder.helperclasses;
using VideoRecorder.models;

namespace VideoRecorder.viewmodels
{
    public class VideoRecorderViewModel : INotifyPropertyChanged
    {
        public RecordHelper recordHelper { get; set; }
        private ObservableCollection<FilterInfo> _deviceList;
        public ObservableCollection<FilterInfo> DeviceList
        {
            get
            {
                return _deviceList;
            }
            set
            {
                _deviceList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CameraQualityModel> _qualityList;
        public ObservableCollection<CameraQualityModel> QualityList
        {
            get
            {
                return _qualityList;
            }
            set
            {
                _qualityList = value;
                OnPropertyChanged();
            }
        }

        private FilterInfo _selectedDevice;
        public FilterInfo SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }
            set
            {
                _selectedDevice = value;
                OnPropertyChanged();
            }
        }

        

        private CameraQualityModel _selectedQuality;
        public CameraQualityModel SelectedQuality
        {
            get
            {
                return _selectedQuality;
            }
            set
            {
                _selectedQuality = value;
                OnPropertyChanged();
            }
        }

        private bool _recording;
        public bool Recording
        {
            get
            {
                return _recording;
            }
            set
            {
                _recording = value;
                OnPropertyChanged();
            }
        }

        private ImageSource _currentFrame;
        public ImageSource CurrentFrame
        {
            get
            {
                return _currentFrame;
            }
            set
            {
                _currentFrame = value;
                OnPropertyChanged();
            }
        }

        private string recordingTimeText;
        public string RecordingTimeText
        {
            get
            {
                return recordingTimeText;
            }
            set
            {
                recordingTimeText = value;
                OnPropertyChanged();
            }
        }

        public VideoRecorderViewModel()
        {
            
            QualityList = new ObservableCollection<CameraQualityModel>();
            recordHelper = new RecordHelper();
            DeviceList = recordHelper.deviceList;
            SelectedDevice = DeviceList[0];
            recordHelper.NewFrameReceived += RecordHelper_NewFrameReceived;
            recordHelper.StartWebCam();
        }
        internal void StartRecording()
        {
            Recording = true;
            
            recordHelper.StartVideoRecording();
            recordHelper.StartAudioRecording();
        }
        internal void StopRecording()
        {
            Recording = false;
            recordHelper.StopRecording();
        }

        private void RecordHelper_NewFrameReceived(object sender, object e)
        {
            //Dispatcher.CurrentDispatcher.Invoke(() => {

            //var bi = new BitmapImage();
            // bi.BeginInit();
            // MemoryStream ms = new MemoryStream();
            // e.Save(ms, ImageFormat.Bmp);
            // bi.StreamSource = ms;
            // bi.CacheOption = BitmapCacheOption.OnLoad;
            // bi.EndInit();
            // bi.Freeze();
            // CurrentFrame = bi;
            //CurrentFrame = FileHelper.Convert((Bitmap)e.Clone()); ;
            //});

            //CurrentFrame = e as BitmapSource;//FileHelper.Convert(e);
            Dispatcher.CurrentDispatcher.Invoke(() => {

                var bitmaps = e as BitmapSource;
                if (bitmaps == null) return;
                bitmaps.Freeze();
                CurrentFrame = bitmaps;//FileHelper.Convert(e);
                bitmaps = null;
            });
            
        }

        public void CameraDeviceChanged(FilterInfo newCam)
        {
            SelectedDevice = newCam;
            recordHelper.deviceChanged(newCam);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
