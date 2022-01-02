using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.Core.Utilities
{
    public class WebUtils
    {
        public static void DownloadFile(string sourceUrl, string destPath)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(sourceUrl), destPath);
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public static void DownloadFileAsync(string sourceUrl, string destPath)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileAsync(new Uri(sourceUrl), destPath);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
