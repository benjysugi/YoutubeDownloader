using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace YoutubeDownloader.LinkProc {
    /// <summary>
    /// Summary description for YoutubeAudio
    /// </summary>
    public class YoutubeAudio : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "audio/mp3";

            try {
                string id = context.Request.Url.AbsoluteUri.Split('/').Last();

                string youtubeUri = "https://youtube.com/watch?v=" + id;

                string finalDlFolder = "";
                string wrapytdlPath = "";
                string ffmpegPath = "ffmpeg.exe";

                if (Debugger.IsAttached) {
                    finalDlFolder = "V:\\dlcache\\youtube\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    wrapytdlPath = "C:\\Git\\YoutubeDownloader\\bin\\tools\\wrapytdl.exe";
                    //Process.Start("C:\\src\\watchparty\\bin\\tools\\wrapytdl.exe", $"{youtubeUri} {finalDlFolder}").WaitForExit();
                }
                else {
                    finalDlFolder = "D:\\AbbWP\\dlcache\\youtube\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    wrapytdlPath = "C:\\VAVE_Bin\\watchparty\\tools\\wrapytdl.exe";
                    ffmpegPath = "C:\\VAVE_Bin\\watchparty\\tools\\ffmpeg.exe";
                    //Process.Start("C:\\VAVE_Bin\\watchparty\\tools\\wrapytdl.exe", $"{youtubeUri} {finalDlFolder}").WaitForExit();
                }

                using (var proc = new Process()) {
                    proc.StartInfo.FileName = wrapytdlPath;
                    proc.StartInfo.Arguments = $"{youtubeUri} {finalDlFolder}";
                    //proc.StartInfo.CreateNoWindow = !Debugger.IsAttached;
                    //proc.StartInfo.UseShellExecute = Debugger.IsAttached;

                    proc.Start();
                    proc.WaitForExit();

                    proc.Dispose();
                    proc.Close();
                }

                using (var proc = new Process()) {
                    proc.StartInfo.FileName = ffmpegPath;
                    proc.StartInfo.Arguments = $"-i {finalDlFolder + "\\video.mp4"} {finalDlFolder + "\\audio.mp3"}";
                    //proc.StartInfo.CreateNoWindow = !Debugger.IsAttached;
                    //proc.StartInfo.UseShellExecute = Debugger.IsAttached;

                    proc.Start();
                    proc.WaitForExit();

                    proc.Dispose();
                    proc.Close();
                }

                if (Directory.Exists(finalDlFolder)) {
                    if (File.Exists(finalDlFolder + "\\audio.mp3")) {
                        if (Debugger.IsAttached) {
                            context.Response.Write(finalDlFolder + "\\audio.mp3");
                        }
                        else {
                            context.Response.WriteFile(finalDlFolder + "\\audio.mp3");
                        }
                    }
                    else {
                        context.Response.ContentType = "text/plain";
                        context.Response.Write("Unable to find downloaded audio content.");
                    }
                }
                else {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Unable to find downloaded content folder.");
                }
            }
            catch (Exception ex) {
                if (Debugger.IsAttached) {
                    context.Response.Write(ex.ToString());
                }
                else {
                    context.Response.Write(ex.Message);
                }
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}