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
using Android.Util;
using Android.Graphics;

namespace Xamiran_Android_SlidingLayout
{
   public class SlidingTabStrip : LinearLayout
    {
        //Copy and paste from here................................................................
        private const int DEFAULT_BOTTOM_BORDER_THICKNESS_DIPS = 2;
        private const byte DEFAULT_BOTTOM_BORDER_COLOR_ALPHA = 0X26;
        private const int SELECTED_INDICATOR_THICKNESS_DIPS = 8;
        private int[] INDICATOR_COLORS = { 0x19A319, 0x0000FC };
        private int[] DIVIDER_COLORS = { 0xC5C5C5 };

        private const int DEFAULT_DIVIDER_THICKNESS_DIPS = 1;
        private const float DEFAULT_DIVIDER_HEIGHT = 0.5f;

        //Bottom border
        private int mBottomBorderThickness;
        private Android.Graphics.Paint mBottomBorderPaint;
        private int mDefaultBottomBorderColor;

        //Indicator
        private int mSelectedIndicatorThickness;
        private Android.Graphics.Paint mSelectedIndicatorPaint;

        //Divider
        private Android.Graphics.Paint mDividerPaint;
        private float mDividerHeight;

        //Selected position and offset
        private int mSelectedPosition;
        private float mSelectionOffset;

        //Tab colorizer
        private SlidingTabScrollView.TabColorizer mCustomTabColorizer;
        private SimpleTabColorizer mDefaultTabColorizer;
        //Stop copy and paste here........................................................................

        //Constructor
        public SlidingTabStrip(Context context) : this(context, null)
        {

        }
        
        public SlidingTabStrip (Context context, IAttributeSet attrs) : base(context,attrs)
        {
            SetWillNotDraw(false);

            float density = Resources.DisplayMetrics.Density;

            TypedValue outValue = new TypedValue();
            context.Theme.ResolveAttribute(Android.Resource.Attribute.ColorForeground, outValue, true);
            int themeForeGround = outValue.Data;
            mDefaultBottomBorderColor = SetColorAlpha(themeForeGround, DEFAULT_BOTTOM_BORDER_COLOR_ALPHA);

            mDefaultTabColorizer = new SimpleTabColorizer();
            mDefaultTabColorizer.IndicatorColors =INDICATOR_COLORS;
            mDefaultTabColorizer.DeviderColors = DIVIDER_COLORS;

            mBottomBorderThickness = (int)(DEFAULT_BOTTOM_BORDER_THICKNESS_DIPS * density);
            mBottomBorderPaint = new Android.Graphics.Paint();
            mBottomBorderPaint.Color = GetColorFromInteger(0xC5C5C5);//GREY

            mSelectedIndicatorThickness = (int)(SELECTED_INDICATOR_THICKNESS_DIPS * density);
            mSelectedIndicatorPaint = new Paint();

            mDividerHeight = DEFAULT_DIVIDER_HEIGHT;
            mDividerPaint = new Paint();
            mDividerPaint.StrokeWidth = (int)(DEFAULT_DIVIDER_THICKNESS_DIPS * density);

        }// End of SlidingTabStrip

        public SlidingTabScrollView.TabColorizer CustomTabColorizer
        {
            set
            {
                mCustomTabColorizer = value;
                this.Invalidate();
            }
        }
        
        public int [] SelectedIndicatorColors
        {
            set
            {
                mCustomTabColorizer = null;
                mDefaultTabColorizer.IndicatorColors = value;
                this.Invalidate();
            }
        }
        
        public int [] DividerColors
        {
            set
            {
                mCustomTabColorizer = null;
                mDefaultTabColorizer.DeviderColors = value;
                this.Invalidate();
            }
        }

        private Color GetColorFromInteger(int color)
        {
            return Color.Rgb(Color.GetRedComponent(color),
                             Color.GetGreenComponent(color),
                             Color.GetBlueComponent(color)
                             );
        }

        private int SetColorAlpha(int color, byte alpha)
        {
            return Color.Argb(alpha, Color.GetRedComponent(color),
                                     Color.GetGreenComponent(color),
                                     Color.GetBlueComponent(color));
        }

        private class SimpleTabColorizer : SlidingTabScrollView.TabColorizer
        {
            private int[] mIndicatorColors;
            private int[] mDeviderColors;

            public int GetIndicatorColor(int position)
            {
                return mIndicatorColors[position % mIndicatorColors.Length];
            }

            public int GetDividerColors(int position)
            {
                return mDeviderColors[position % mDeviderColors.Length];
            }

            public int GetDeviderColor(int position)
            {
                throw new NotImplementedException();
            }

            public int[] IndicatorColors
            {
                set { mIndicatorColors = value; }

            }

            public int[] DeviderColors
            {
                set { mDeviderColors = value; }

            }

        }

   }// end of class
}//end of namespace