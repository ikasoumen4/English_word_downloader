using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
//using Android.Support.V4.App Android 1.6 (API level 4) 以降を対象としたライブラリで、Fragment などが使えるようになる。
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace HelloWorld.Fragments
{

    public class Quiz : Fragment
    {

        private List<string> items = new List<string>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            //var button = Activity.FindViewById<Button>(Resource.Id.MyButton);



            //リスト設定
            //var view_list = Activity.FindViewById<ListView>(Resource.Id.mylistview);

            //items.Add("Bob");
            //items.Add("Tom");
            //items.Add("Jim");

            //ArrayAdapter<string> adapter = new ArrayAdapter<string>(null, Android.Resource.Layout.SimpleListItem1, items);

            //view_list.Adapter = adapter;
            var transactoin = ChildFragmentManager.BeginTransaction();
            transactoin.Commit();

            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Quiz, container, false);
            return view;
        }
    }
}