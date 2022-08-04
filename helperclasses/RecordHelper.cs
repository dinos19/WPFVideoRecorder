using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace VideoRecorder.helperclasses
{
    public class RecordHelper
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("New Frame Received")]
        public event EventHandler<BitmapSource> NewFrameReceived;
        public string FfmpegPath { get; set; }
        private string tmpPath = System.IO.Path.GetTempPath() + "kostas";

        public string ImageFilePath { get; set; }
        public string VideoFilePath { get; set; }
        public string AudioFilePath { get; set; }
        private string fileHashString { get; set; }
        public string FinalVideo { get; set; }
        public string CurrentRecordingFolderForImages { get; set; }
        public bool is64 { get; set; }
        public VideoRecordHelper videoRecordHelper { get; set; }
        public AudioRecordHelper audioRecordHelper { get; set; }
        private string guidName  { get; set; }

        public FilterInfoCollection LocalWebCamsCollection { get; set; }
        public VideoCaptureDevice LocalWebCam { get; set; }
        public FilterInfo SelectedDevice { get; set; }
        public  ObservableCollection<FilterInfo> deviceList { get; set; }
        private List<int> FpsReceived = null;

        public RecordHelper()
        {
            InitFields();
            deviceList = GetDevices();
            
                LocalWebCam = new VideoCaptureDevice(LocalWebCamsCollection[0].MonikerString);
                videoRecordHelper = new VideoRecordHelper(LocalWebCam, CurrentRecordingFolderForImages, guidName);
                videoRecordHelper.NewFrameReceived += VideoRecordHelper_NewFrameReceived;
            
                audioRecordHelper = new AudioRecordHelper();
           
            
            
        }

        private void InitFields()
        {
            string relativffmpegpath = "";
            is64 = Environment.Is64BitOperatingSystem;
            if (is64)
                relativffmpegpath = @"64\ffmpeg.exe";
            else
                relativffmpegpath = @"32\ffmpeg.exe";

            FfmpegPath = $@"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)}\ffmpeg".Replace("file:\\", "");
            FfmpegPath = $@"{FfmpegPath}\{relativffmpegpath}";
            guidName = Guid.NewGuid().ToString();
            CurrentRecordingFolderForImages = $@"{tmpPath}\{guidName}";
            if (!Directory.Exists(tmpPath))
                Directory.CreateDirectory(tmpPath);

            //FpsReceived = new List<int>();
        }

        private void SetNameFiles()
        {
            bool exists = false;
            guidName = Guid.NewGuid().ToString();

            VideoFilePath = $@"{tmpPath}\{guidName}.avi";
            AudioFilePath = $@"{tmpPath}\{guidName}.wav";

            FinalVideo = GetHashName(); //$@"{StorageFolder}\{guidName}.{SelectedQuality.Name}.mp4";
            //GetHashName();
            VideoFilePath = $@"{tmpPath}\{guidName}.mp4";
            CurrentRecordingFolderForImages = $@"{tmpPath}\{guidName}";

            exists = System.IO.Directory.Exists(CurrentRecordingFolderForImages);

            if (!exists)
                System.IO.Directory.CreateDirectory(CurrentRecordingFolderForImages);

            
        }

        private string GetHashName()
        {
            string strTempFileName = System.IO.Path.GetTempFileName();

            //make a hash for the name
            var sha256 = SHA256.Create();
            var hashstream = File.OpenRead(strTempFileName);
            var _sha256 = sha256.ComputeHash(hashstream);
            hashstream.Close();
            string _hash = BitConverter.ToString(_sha256).Replace("-", "").ToLowerInvariant();
            FinalVideo = tmpPath + "\\" + _hash + ".mp4";


            byte[] bytes = Encoding.UTF8.GetBytes(strTempFileName);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            fileHashString = string.Empty;
            foreach (byte x in hash)
            {
                fileHashString += String.Format("{0:x2}", x);
            }
            var finalPath = tmpPath + "\\" + fileHashString + ".mp4";
            return finalPath;
        }

        

        private void VideoRecordHelper_NewFrameReceived(object sender, object e)
        {
            EventHandler<BitmapSource> handler = NewFrameReceived;
            handler?.Invoke(null, sender as BitmapSource);
        }

        public ObservableCollection<FilterInfo> GetDevices()
        {
            ObservableCollection<FilterInfo> filterInfos = new ObservableCollection<FilterInfo>();
            LocalWebCamsCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            for (int i = 0; i < LocalWebCamsCollection.Count; i++)
                filterInfos.Add(LocalWebCamsCollection[i]);

            return filterInfos;
        }

        public void StartWebCam()
        {
            videoRecordHelper.StartWebCam();
        }

        public void deviceChanged(FilterInfo newCam)
        {
            SelectedDevice = newCam;
            videoRecordHelper.DeviceChanged(newCam) ;
        }

        internal void StartVideoRecording()
        {
            SetNameFiles();
            videoRecordHelper.SetNewRecordingFolder(CurrentRecordingFolderForImages,guidName);
            audioRecordHelper.SetNewAudioFilePath(AudioFilePath);
            videoRecordHelper.StartRecording();
        }

        internal void StartAudioRecording()
        {
            audioRecordHelper.StartRecording();
        }
        internal void StopRecording()
        {
            FpsReceived = videoRecordHelper.StopRecording();
            audioRecordHelper.StopRecording();
            CreateVideo();
        }

        private void CreateVideo()
        {
            Task.Run(() => {
                //var FpsReceived = 16;
                var mostCommonElement = ffmpegHelper.MostCommonElement(FpsReceived).ToList();
                ffmpegHelper.ImagesToVideo(FfmpegPath, guidName, CurrentRecordingFolderForImages, VideoFilePath, mostCommonElement[0], 5, 30);//LocalWebCam.VideoCapabilities[0].AverageFrameRate); ;
                ffmpegHelper.AddAudioToVideo(FfmpegPath, VideoFilePath, AudioFilePath, FinalVideo);
                //ffmpegHelper.DeleteFiles(AudioFilePath, VideoFilePath);
                //Directory.Delete(CurrentRecordingFolderForImages, true);

            });
            //show send btns event
        }
    }
}
