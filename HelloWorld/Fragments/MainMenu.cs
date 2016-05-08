using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace HelloWorld.Fragments
{
    public class MainMenu : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.MainMenu, container, false);

            var btn_start_quiz = view.FindViewById<Button>(Resource.Id.btn_start_quiz);
            var btn_edit_drill = view.FindViewById<Button>(Resource.Id.btn_edit_drill);

            btn_start_quiz.Click += delegate
            {
                FragmentManager.BeginTransaction().Replace(Resource.Id.MainFragment, new Quiz()).AddToBackStack(null).Commit();
            };

            btn_edit_drill.Click += delegate
            {
                FragmentManager.BeginTransaction().Replace(Resource.Id.MainFragment, new EditDrill()).AddToBackStack(null).Commit();
            };

            return view;
        }
    }
}