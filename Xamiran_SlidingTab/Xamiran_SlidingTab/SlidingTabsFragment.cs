using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;

namespace Xamiran_SlidingTab
{
    class SlidingTabsFragment : Fragment
    {
        private SlidingTabsFragment mSlidingTabScrollView;
        private ViewPager mViewPager;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_sample, container, false);

        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            mViewPager.Adapter = new SamplePageAdapter();

            mSlidingTabScrollView.mViewPager = mViewPager;
        }

        public class SamplePagerAdapter : PagerAdapter
        {

        }

    }// end of class
}//end of namespace  