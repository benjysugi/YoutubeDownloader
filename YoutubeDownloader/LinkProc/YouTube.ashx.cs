using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace YoutubeDownloader.LinkProc {
    /// <summary>
    /// Summary description for YouTube
    /// </summary>
    public class YouTube : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "video/mp4";

            try {
                string id = context.Request.Url.AbsoluteUri.Split('/').Last();

                string youtubeUri = "https://youtube.com/watch?v=" + id;

                string finalDlFolder = "";
                string wrapytdlPath = "";

                if (Debugger.IsAttached) {
                    finalDlFolder = "V:\\dlcache\\youtube\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    wrapytdlPath = "C:\\project\\YoutubeDownloader\\bin\\tools\\wrapytdl.exe";
                    //Process.Start("C:\\src\\watchparty\\bin\\tools\\wrapytdl.exe", $"{youtubeUri} {finalDlFolder}").WaitForExit();
                }
                else {
                    finalDlFolder = "D:\\AbbWP\\dlcache\\youtube\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    wrapytdlPath = "C:\\VAVE_Bin\\watchparty\\tools\\wrapytdl.exe";
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

                if (Directory.Exists(finalDlFolder)) {
                    if (File.Exists(finalDlFolder + "\\video.mp4")) {
                        if (Debugger.IsAttached) {
                            context.Response.Write(finalDlFolder + "\\video.mp4");
                        }
                        else {
                            context.Response.WriteFile(finalDlFolder + "\\video.mp4");
                        }
                    }
                    else {
                        context.Response.Write("Unable to find downloaded video content.");
                    }
                }
                else {
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