using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Windows.Threading;
using System.IO;

namespace VideoRecorder.helperclasses
{
    public class VideoRecordHelper
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("New Frame Received")]
        public event EventHandler<BitmapSource> NewFrameReceived;


        private bool _recording;
        private List<int> FpsReceived = null;

        DispatcherTimer fpsTimer;
        VideoCaptureDevice LocalWebCam { get; set; }
        string CurrentRecordingFolderForImages { get; set; }
        string guidName { get; set; }
        int imgNumber { get; set; }
        private Bitmap currentreceivedframebitmap = null;
        public VideoRecordHelper(VideoCaptureDevice localWebCam, string currentRecordingFolderForImages, string GuidName)
        {

            guidName = GuidName;
            CurrentRecordingFolderForImages = currentRecordingFolderForImages;
            LocalWebCam = localWebCam;
            LocalWebCam.NewFrame += new NewFrameEventHandler(Cam_NewFrame);
            FpsReceived = new List<int>();
        }

        public void SetNewRecordingFolder(string newfolder, string newguid)
        {
            CurrentRecordingFolderForImages = newfolder;
            guidName = newguid;
        }
        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //handle frames from camera
            try
            {
                


                using (currentreceivedframebitmap = eventArgs.Frame)
                {
                    //HandleNewFrame(Bitmap newFrame);
                    if (_recording)
                    {

                        currentreceivedframebitmap.Save($@"{CurrentRecordingFolderForImages}/{imgNumber}-{guidName}.png", ImageFormat.Png);
                        imgNumber++;
                    }


                    //CurrentFrame = new Bitmap(eventArgs.Frame);
                    var bitmapsource = FileHelper.Convert(currentreceivedframebitmap);
                    Dispatcher.CurrentDispatcher.Invoke(() =>
                    {
                        EventHandler<BitmapSource> handler = NewFrameReceived;
                        handler?.Invoke(bitmapsource, null);
                    });
                }
                    

                
                //Dispatcher.BeginInvoke(new ThreadStart(delegate
                //{
                //    imageFrames.Source = Convert(CurrentFrame);
                //}));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        internal void StartRecording()
        {
            imgNumber = 0;
            _recording = true;
        }

        public void DeviceChanged(FilterInfo newCam)
        {
            LocalWebCam.SignalToStop();
            LocalWebCam.Stop();
            LocalWebCam.NewFrame -= new NewFrameEventHandler(Cam_NewFrame);
            LocalWebCam = new VideoCaptureDevice(newCam.MonikerString);
            LocalWebCam.NewFrame += new NewFrameEventHandler(Cam_NewFrame);
            LocalWebCam.Start();
        }

        public void StartWebCam()
        {
            FpsReceived.Clear();
            LocalWebCam.Start();
            fpsTimer = new DispatcherTimer();
            fpsTimer.Interval = TimeSpan.FromSeconds(1);
            fpsTimer.Tick += FpsTimer_Tick;
            fpsTimer.Start();
        }

        private void FpsTimer_Tick(object sender, EventArgs e)
        {
            if (_recording)
            {
                //Console.WriteLine(LocalWebCam.FramesReceived);
                FpsReceived.Add(LocalWebCam.FramesReceived);
            }
        }

        internal List<int> StopRecording()
        {
            _recording = false;
            return FpsReceived;
        }


    }
}
