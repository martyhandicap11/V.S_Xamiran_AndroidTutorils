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

namespace SlidingTabLayoutTutorial
{
    class SlidingTabScrollView
    {
        private const int TITLE_OFFSET_DIPS = 24;
        private const int TAB_VIEW_PADDING_DIPS = 16;
        private const int TAB_VIEW_TEXT_SIZE_SP = 12;

        private int mTitleOffset;

        private int mTabViewLayoutID;
        private int mTabViewTextViewID;

        private ViewPager mViewPager;
        private ViewPager.IOnPageChangeListener mViewPagerPageChangeListener;

        private static SlidingTabStrip mTabStrip;

        private int mScrollState;

        public interface TabColorizer
        {
            int GetIndicatorColor(int position);
            int GetDividerColor(int position);
        }








    }// End of class

}// End of namespace