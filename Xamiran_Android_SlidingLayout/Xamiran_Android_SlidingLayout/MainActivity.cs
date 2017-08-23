using Android.App;
using Android.Widget;
using Android.OS;

namespace Xamiran_Android_SlidingLayout
{
    [Activity(Label = "Xamiran_Android_SlidingLayout", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

