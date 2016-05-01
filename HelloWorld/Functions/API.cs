using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace HelloWorld.Functions
{
    public static class API
    {
        /// <summary>
        /// html‚Ìcontent‚ğ”ñ“¯Šú‚Åæ“¾‚µ‚Ü‚·B
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="encoding"></param>
        /// <returns>content</returns>
        public static async Task<String> DownloadHtmlAsync(string uri, System.Text.Encoding encoding)
        {
            var wc = new WebClient();
            wc.Encoding = encoding;
            var html = await wc.DownloadStringTaskAsync(uri);
            wc.Dispose();
            return html;
        }

        public static async Task<Byte[]> DownloadFileAsync(string uri)
        {
            var wc = new WebClient();
            var data = await wc.DownloadDataTaskAsync(uri);
            wc.Dispose();
            return data;
        }





        public static async Task SaveByteFile(string path, Byte[] data,FileMode mode = FileMode.Create)
        {
            if (path == null || data == null) throw new NullReferenceException();


            await Task.Run(() =>
            {
                var fs = new FileStream(path, mode);
                var bw = new BinaryWriter(fs);
                bw.Write(data);
                bw.Close();
                fs.Close();
            });
        }


    }
}