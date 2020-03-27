using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace COVID_19.Classes
{
    class OpenURL
    {
        public static void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        public static Image GetImageFromUrl(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            // if you have proxy server, you may need to set proxy details like below 
            //httpWebRequest.Proxy = new WebProxy("proxyserver",port){ Credentials = new NetworkCredential(){ UserName ="uname", Password = "pw"}};

            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    if (Properties.Settings.Default.isInternet)
                    {
                        return Image.FromStream(stream);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static bool Ping(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Timeout = 3000;
                request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
                request.Method = "HEAD";

                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string DownloadJson(string _url, string _name)
        {
            string x = string.Empty;
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\APIJson";
            try
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(_url);

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    else
                    {
                        File.Delete(@"" + Path.Combine(path, string.Format("{0}.json", _name)));
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, string.Format("{0}.json", _name)), true))
                        {
                            outputFile.WriteLine(json);
                            x = string.Format("Downloading and saving: {0}.json file to ~\\APIJson\\", _name);
                        }
                    }

                }
            }
            catch (System.Exception ex)
            {
                File.Delete(@"" + Path.Combine(path, string.Format("{0}.json", _name)));
                x = ex.Message;
            }
            return x;
        }
    }
}
