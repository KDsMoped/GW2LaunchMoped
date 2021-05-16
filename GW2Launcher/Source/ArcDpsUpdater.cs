using System.Net;

namespace GW2Launcher
{
    class ArcDpsUpdater
    {
        private string path;

        public ArcDpsUpdater(string destPath)
        {
            path = destPath;
        }

        public void Download()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(
                    new System.Uri("https://www.deltaconnected.com/arcdps/x64/d3d9.dll"),
                    path + "\\d3d9.dll");
            }
        }

    }
}
