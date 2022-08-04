using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRecorder.helperclasses
{
    public class AudioRecordHelper
    {
        private WaveIn waveSource = null;
        private WaveFileWriter waveFile = null;
        private string AudioFilePath = "";
        private bool _recording;

        public AudioRecordHelper()
        {
            //AudioFilePath = Audiopath;
            waveSource = new WaveIn();
            waveSource.WaveFormat = new WaveFormat(8000, 1);
            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);


            waveSource.StartRecording();
        }

        public void StartRecording()
        {
            _recording = true;
            waveFile = new WaveFileWriter(AudioFilePath, waveSource.WaveFormat);

        }

        public void StopRecording()
        {
            _recording = false;
            if (waveFile != null)
                waveFile.Dispose();
        }

        private void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                //waveSource.Dispose();
                //waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }
        }

        private void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null && _recording)
            {
                //Console.WriteLine("waveSource_DataAvailable : " + e.BytesRecorded);
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        internal void SetNewAudioFilePath(string audiopath)
        {

            AudioFilePath = audiopath;


        }
    }
}
