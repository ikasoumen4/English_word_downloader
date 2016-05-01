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

using System.Threading.Tasks;
using HelloWorld.Functions;
using HtmlAgilityPack;

namespace HelloWorld.Scraping
{
    public class en_hatsuon_info : ScrapingBase
    {

        public override Encoding GetEncoding()
        {
            return System.Text.Encoding.UTF8;
        }

        public override string GetUrl()
        {
            return "http://en.hatsuon.info/";
        }

        public override string GetDownloadURL(string word)
        {
            return "http://en.hatsuon.info/word/" + word;
        }

        public override string GetMeaning()
        {
            //XpathがないとSelectNodesが使えない　代わりにDescendantsを使う。
            return doc.DocumentNode.Descendants()
                .Where(n =>
                    n.Name == "div"
                    && n.Attributes["class"] != null
                    && n.Attributes["class"].Value == "font1")
                .Where(n => n.InnerText.StartsWith("主な意味："))
                .SingleOrDefault().InnerText;
        }

        public override string GetSoundSourceURL()
        {
            return GetDownloadURL("") + doc.GetElementbyId("audio1").Element("source").Attributes["src"]?.Value ?? "";
        }

        

        
    }
}