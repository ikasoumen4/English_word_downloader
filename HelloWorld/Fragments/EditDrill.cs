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
    public class EditDrill : Fragment
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

            var view = inflater.Inflate(Resource.Layout.EditDrill, container, false);

            var list = view.FindViewById<ListView>(Resource.Id.mylistview);
            var btn = view.FindViewById<Button>(Resource.Id.btn_add_list);

            var items = new List<string>()
            {
                "Bob",
                "Tom",
                "Jim"
            };

            
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, items);

            list.Adapter = adapter;

            btn.Click += delegate
            {
                adapter.Add("test");
            };



            //return base.OnCreateView(inflater, container, savedInstanceState);
            return view;
        }
    }
}