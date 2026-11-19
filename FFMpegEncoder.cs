using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Media.Media3D;

namespace Windows_VideoEditor {
    public class FFMpegEncoder {

        private Process process_;
        private Stream stream_;


        public FFMpegEncoder() {
            process_ = new Process();
        }

        public void Save(string fileName, byte[] pixel, int width, int height, int fps = 60) {
            process_.StartInfo = new ProcessStartInfo {
                FileName = "ffmpeg",
                Arguments =
                    $"-y -f rawvideo " +
                    $"-pixel_format bgra " +
                    $"-video_size {width}x{height} " +
                    $"-framerate {fps} " +
                    $"-i pipe:0 " +
                    $"-c:v libx264 " +
                    $"-pix_fmt yuv420p " +
                    $"-crf 18 " +
                    $"\"{fileName}\"",
                UseShellExecute = false,
                RedirectStandardInput = true,
                CreateNoWindow = true
            };

            process_.Start();
            stream_ = process_.StandardInput.BaseStream;

            stream_.Write(pixel, 0, pixel.Length);
            stream_.Close();
            process_.WaitForExit();
        }

    }
}
