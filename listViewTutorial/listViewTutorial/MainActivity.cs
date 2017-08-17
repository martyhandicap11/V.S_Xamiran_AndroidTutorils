using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;

namespace listViewTutorial
{
    [Activity(Label = "listViewTutorial", MainLauncher = true)]
    public class MainActivity : Activity
    {

        private List<Person> mItems;
        private ListView mListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mListView = FindViewById<ListView>(Resource.Id.myListView);

            mItems = new List<Person>();

            mItems.Add(new Person() { FirstName = "Joe", LastName = "Smith", Age = "22", Gender = "Male" });
            mItems.Add(new Person() { FirstName = "Tom", LastName = "Tom", Age = "35", Gender = "Male" });
            mItems.Add(new Person() { FirstName = "Sally", LastName = "Susan", Age = "88", Gender = "Female" });

            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);

            mListView.Adapter = adapter;
            mListView.ItemClick += mListView_ItemClick;
            mListView.ItemClick += mListView_ItemLongClick;

            //+= subscribes event adversely -= unsubcribes

            mListView.ItemClick += MListView_ItemClick2;
        }

        private void MListView_ItemClick2(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.Write("Second Method");
        }

        private void mListView_ItemLongClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].LastName);
        }

        void mListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].FirstName);
        }
    }
    }


