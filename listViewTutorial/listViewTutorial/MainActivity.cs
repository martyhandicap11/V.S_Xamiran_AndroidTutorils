using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace listViewTutorial
{
    [Activity(Label = "listViewTutorial", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //int count = 1;
        private List<string> mItems;
        private ListView mListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mListView = FindViewById<ListView>(Resource.Id.myListView);

            mItems = new List<string>();
            mItems.Add("Bob");
            mItems.Add("Tom");
            mItems.Add("Jim");

            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);

            string indexTest = adapter.mItems[1];



            mListView.Adapter = adapter;


        }
    }
}

