using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRecorder.helperclasses
{
    public static class ffmpegHelper
    {
        public static IEnumerable<T> MostCommonElement<T>(this IEnumerable<T> input)
        {
            var dict = input.ToLookup(x => x);
            if (dict.Count == 0)
                return Enumerable.Empty<T>();
            var maxCount = dict.Max(x => x.Count());
            return dict.Where(x => x.Count() == maxCount).Select(x => x.Key);
        }

        public static void DeleteFiles(string audioFile, string videoFile)
        {
            try
            {

                File.Delete(audioFile);
                File.Delete(videoFile);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public static void ImagesToVideo(string ffmpegpath, string guid, string CurrentRecordingFolderForImages, string outputPath, int frameRate, int quality, int avgFrameRate)
        {
            // -b:v {quality}
            Process process;
            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{ffmpegpath}",
                    Arguments = $@" -r {frameRate} -i {CurrentRecordingFolderForImages}\%d-{guid}.png -r {avgFrameRate} -vcodec libx264 -crf {quality} -pix_fmt yuv420p  {outputPath}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    RedirectStandardError = true
                },
                EnableRaisingEvents = true,

            };
            process.Start();

            string processOutput = null;
            while ((processOutput = process.StandardError.ReadLine()) != null)
            {
                //TO-DO handle errors
                Debug.WriteLine(processOutput);
            }
        }

        public static void AddAudioToVideo(string ffmpegpath, string VideoPath, string AudioPath, string outputPath)
        {
            Process process;

            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{ffmpegpath}",
                    Arguments = $" -i {VideoPath} -i {AudioPath} -map 0:v -map 1:a -c:v copy -shortest {outputPath} -y",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    RedirectStandardError = true
                },
                EnableRaisingEvents = true,
            };
            process.Start();

            string processOutput = null;
            while ((processOutput = process.StandardError.ReadLine()) != null)
            {
                // do something with processOutput
                Debug.WriteLine(processOutput);
            }
        }

        public static void DeleteFilesAndDir(string audioFile, string videoFile, string finalVideo, string folderPath)
        {
            try
            {

                File.Delete(finalVideo);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            try
            {

                File.Delete(audioFile);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            try
            {

                File.Delete(videoFile);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            try
            {
                Directory.Delete(folderPath, true);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
