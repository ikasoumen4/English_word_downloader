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


        //int count = 1;


        //Android.Media.SoundPool soundpool;

        
        //Bundleは通常nullだが、savedinstanceでbundleに値を設定した場合はインスタンスが存在する
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            var root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var words_path = root + "/words/";
            var sounds_path = root + "/sounds/";

            if (System.IO.File.Exists(words_path) == false) System.IO.Directory.CreateDirectory(words_path);
            if (System.IO.File.Exists(sounds_path) == false) System.IO.Directory.CreateDirectory(sounds_path);



            var transcation = FragmentManager.BeginTransaction();
            //transcation.Add(Resource.Id.MainFragment, new Quiz(), "Quiz");
            transcation.Add(Resource.Id.MainFragment, new MainMenu(), nameof(MainMenu));

            transcation.Commit();

            

        }
        protected override void OnResume()
        {
            base.OnResume();
            //soundpool = new Android.Media.SoundPool(1,Android.Media.AudioManager.sta)
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            //if (soundpool != null) soundpool.Release();
        }


        ////状態保存
        //protected override void OnSaveInstanceState(Bundle outState)
        //{
            
        //}

        ////状態復元
        //protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        //{
        //}
    }
}

