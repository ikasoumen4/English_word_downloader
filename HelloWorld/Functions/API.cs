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
        /// htmlÇÃcontentÇîÒìØä˙Ç≈éÊìæÇµÇ‹Ç∑ÅB
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

        public static async Task SaveTextFile(string path, string data, FileMode mode = FileMode.Create)
        {
            if (path == null || data == null) throw new NullReferenceException();

            await Task.Run(() => {

                var fs = new FileStream(path, mode);
                var sw = new StreamWriter(fs);
                sw.Write(data);
                sw.Close();
                fs.Close();
            });
        }


        public static void InitQuizData(this Fragments.IQuiz quiz)
        {
            quiz.word = null;
            quiz.mean = null;
            quiz.sound_path = null;
            quiz.IsDownloaded = false;
        }

        public static void CopyQuizData(this Fragments.IQuiz dest, Fragments.IQuiz copy_data)
        {
            dest.word = copy_data.word;
            dest.mean = copy_data.mean;
            dest.sound_path = copy_data.sound_path;
            dest.IsDownloaded = copy_data.IsDownloaded;
        }


    }
}