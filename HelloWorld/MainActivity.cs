using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using HelloWorld.Fragments;
using HelloWorld.Functions;

using System.IO;


namespace HelloWorld
{
    [Activity(Label = "HelloWorld", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;


        Android.Media.SoundPool soundpool;

        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            var soundtext = FindViewById<TextView>(Resource.Id.MySuperTextView);

            var IsDownloading = false;

            button.Click += async delegate
            {
                if (IsDownloading) return;
                IsDownloading = true;

                var audio_url = "";
                var mean_text = "";

                var doc = new Scraping.en_hatsuon_info();
                await doc.DownloadhtmlAsync("photon");

                soundtext.Text = doc.GetSoundSourceURL();
                mean_text = doc.GetMeaning();

                var data = await API.DownloadFileAsync(soundtext.Text);

                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/photon.mp3";

                await API.SaveByteFile(path, data);
                


                new AlertDialog.Builder(this)
                .SetTitle(audio_url)
                .SetMessage(data.IsFixedSize.ToString())
                .SetPositiveButton("OK", delegate { })
                .Show();


                IsDownloading = false;

            };

            var transcation = FragmentManager.BeginTransaction();
            transcation.Add(Resource.Id.MainFragment, new Quiz(), "Quiz");
            transcation.Commit();

            

        }
        protected override void OnResume()
        {
            base.OnResume();
            //soundpool = new Android.Media.SoundPool(1,Android.Media.AudioManager.sta)
        }
    }
}

