using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using HelloWorld.Fragments;

namespace HelloWorld
{
    [Activity(Label = "HelloWorld", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            var superText = FindViewById<TextView>(Resource.Id.MySuperTextView);

            button.Click += delegate
            {
                superText.Text = string.Format("Last Text from button was: {0}", button.Text);
                button.Text = string.Format("{0} clicks!", count++);
            };

            var transcation = FragmentManager.BeginTransaction();
            transcation.Add(Resource.Id.MainFragment, new Quiz(), "Quiz");
            transcation.Commit();

            

        }

    }
}

