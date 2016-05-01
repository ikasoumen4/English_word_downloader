using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Functions;
using HelloWorld.Scraping;

namespace Test
{
    [TestClass]
    public class AwaitTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            var doc = new en_hatsuon_info();
            doc.DownloadhtmlAsync("photon").Wait();

            var sound = doc.GetSoundSourceURL();
            Assert.IsNotNull(sound);

            var task = API.DownloadFileAsync(sound);
            task.Wait();


            Assert.IsNotNull(task.Result);

            System.Console.WriteLine(sound);
            System.Console.WriteLine(task.Result.Length);

        }
    }
}
