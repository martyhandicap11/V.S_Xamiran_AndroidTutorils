using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views.InputMethods;
using Animations;
using System.Linq;

namespace Animations
{
    [Activity(Label = "AnimationTutorial", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<Friend> mFriends;
        private ListView mListView;
        private EditText mSearch;
        private LinearLayout mContainer;
        private bool mAnimatedDown;
        private bool mIsAnimating;
        private FriendsAdapter mAdapter;

        private TextView mTxtHeaderFirstname;
        private TextView mTxtHeaderLastname;
        private TextView mTxtHeaderAge;
        private TextView mTxtHeaderGender;

        private bool mFirstnameAscending;
        private bool mLastnameAscending;
        private bool mAgeAscending;
        private bool mGenderAscending;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mListView = FindViewById<ListView>(Resource.Id.listView);
            mSearch = FindViewById<EditText>(Resource.Id.etSearch);
            mContainer = FindViewById<LinearLayout>(Resource.Id.llContainer);

            mTxtHeaderFirstname = FindViewById<TextView>(Resource.Id.txtHeaderFirstname);
            mTxtHeaderLastname = FindViewById<TextView>(Resource.Id.txtHeaderLastname);
            mTxtHeaderAge = FindViewById<TextView>(Resource.Id.txtHeaderAge);
            mTxtHeaderGender = FindViewById<TextView>(Resource.Id.txtHeaderGender);

            mTxtHeaderFirstname.Click += MTxtHeaderFirstname_Click;
            mTxtHeaderLastname.Click += MTxtHeaderLastname_Click;
            mTxtHeaderAge.Click += MTxtHeaderAge_Click;
            mTxtHeaderGender.Click += MTxtHeaderGender_Click;



            mSearch.Alpha = 0;
            mContainer.BringToFront();
            mSearch.TextChanged += MSearch_TextChanged;

            mFriends = new List<Friend>();
            mFriends.Add(new Friend { FirstName = "Bob", LastName = "Smith", Age = "33", Gender = "Male" });
            mFriends.Add(new Friend { FirstName = "Tom", LastName = "Smith", Age = "45", Gender = "Male" });
            mFriends.Add(new Friend { FirstName = "Julie", LastName = "Smith", Age = "2020", Gender = "Unknown" });
            mFriends.Add(new Friend { FirstName = "Molly", LastName = "Smith", Age = "21", Gender = "Female" });
            mFriends.Add(new Friend { FirstName = "Joe", LastName = "Lopez", Age = "22", Gender = "Male" });
            mFriends.Add(new Friend { FirstName = "Ruth", LastName = "White", Age = "81", Gender = "Female" });
            mFriends.Add(new Friend { FirstName = "Sally", LastName = "Johnson", Age = "54", Gender = "Female" });

            mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, mFriends);
            mListView.Adapter = mAdapter;
        }

        private void MTxtHeaderGender_Click(object sender, EventArgs e)
        {
            List<Friend> filterFriends;

            if (!mGenderAscending)
            {
                filterFriends = (from friend in mFriends
                                 orderby friend.Gender
                                 select friend).ToList<Friend>();

                //Refresh the listview
                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filterFriends);
                mListView.Adapter = mAdapter;

            }
            else
            {
                filterFriends = (from friend in mFriends
                                 orderby friend.Gender descending
                                 select friend).ToList<Friend>();

                //Refresh the listview
                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filterFriends);
                mListView.Adapter = mAdapter;
            }
            mGenderAscending = !mGenderAscending;
        }

        private void MTxtHeaderAge_Click(object sender, EventArgs e)
        {
            List<Friend> filterFriends;

            if (!mAgeAscending)
            {
                filterFriends = (from friend in mFriends
                                 orderby friend.Age
                                 select friend).ToList<Friend>();

                //Refresh the listview
                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filterFriends);
                mListView.Adapter = mAdapter;

            }
            else
            {
                filterFriends = (from friend in mFriends
                                 orderby friend.Age descending
                                 select friend).ToList<Friend>();

                //Refresh the listview
                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filterFriends);
                mListView.Adapter = mAdapter;
            }
            mAgeAscending = !mAgeAscending;
        }

        private void MTxtHeaderLastname_Click(object sender, EventArgs e)
        {
            List<Friend> filterFriends;

            if (!mLastnameAscending)
            {
                filterFriends = (from friend in mFriends
                                 orderby friend.LastName
                                 select friend).ToList<Friend>();

                //Refresh the listview
                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filterFriends);
                mListView.Adapter = mAdapter;

            }
            else
            {
                filterFriends = (from friend in mFriends
                                 orderby friend.LastName descending
                                 select friend).ToList<Friend>();

                //Refresh the listview
                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filterFriends);
                mListView.Adapter = mAdapter;
            }
            mLastnameAscending = !mLastnameAscending;
        }

        private void MTxtHeaderFirstname_Click(object sender, EventArgs e)
        {
            List<Friend> filterFriends;

            if (!mFirstnameAscending)
            {
                filterFriends = (from friend in mFriends
                                 orderby friend.FirstName 
                                 select friend).ToList<Friend>();

                //Refresh the listview
                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filterFriends);
                mListView.Adapter = mAdapter;

            }
            else
            {
                filterFriends = (from friend in mFriends
                                 orderby friend.FirstName descending
                                 select friend).ToList<Friend>();

                //Refresh the listview
                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filterFriends);
                mListView.Adapter = mAdapter;
            }
            mFirstnameAscending = !mFirstnameAscending;
        }

        private void MSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<Friend> searchedFriends = (from friend in mFriends
                                            where friend.FirstName.Contains(mSearch.Text,StringComparison.OrdinalIgnoreCase)
                                            || friend.LastName.Contains(mSearch.Text,StringComparison.OrdinalIgnoreCase)
                                            || friend.Age.Contains(mSearch.Text,StringComparison.OrdinalIgnoreCase)
                                            || friend.Gender.Contains(mSearch.Text,StringComparison.OrdinalIgnoreCase)
                                            select friend).ToList<Friend>();

            mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, searchedFriends);
            mListView.Adapter = mAdapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Resource.Id.search:
                    //Search icon has been clicked

                    mSearch.Visibility = ViewStates.Visible;

                    if (mIsAnimating)
                    {
                        return true;
                    }

                    if (!mAnimatedDown)
                    {
                        //Listview is up
                        MyAnimation anim = new MyAnimation(mListView, mListView.Height - mSearch.Height);
                        anim.Duration = 500;
                        mListView.StartAnimation(anim);
                        anim.AnimationStart += anim_AnimationStartDown;
                        anim.AnimationEnd += anim_AnimationEndDown;
                        mContainer.Animate().TranslationYBy(mSearch.Height).SetDuration(500).Start();
                    }

                    else
                    {
                        //Listview is down
                        MyAnimation anim = new MyAnimation(mListView, mListView.Height + mSearch.Height);
                        anim.Duration = 500;
                        mListView.StartAnimation(anim);
                        anim.AnimationStart += anim_AnimationStartUp;
                        anim.AnimationEnd += anim_AnimationEndUp;
                        mContainer.Animate().TranslationYBy(-mSearch.Height).SetDuration(500).Start();
                    }

                    mAnimatedDown = !mAnimatedDown;
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        void anim_AnimationEndUp(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
            mSearch.ClearFocus();
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
        }

        void anim_AnimationEndDown(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
        }

        void anim_AnimationStartDown(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearch.Animate().AlphaBy(1.0f).SetDuration(500).Start();
        }

        void anim_AnimationStartUp(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearch.Animate().AlphaBy(-1.0f).SetDuration(300).Start();
        }
    }
}

