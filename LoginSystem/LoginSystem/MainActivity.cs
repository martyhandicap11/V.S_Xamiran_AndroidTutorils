using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Threading;
using Android.Views;

namespace LoginSystem
{
    [Activity(Label = "LoginSystem", MainLauncher = true)]
    public class MainActivity : Activity
    {

        private Button mBtnSignUp;
        private ProgressBar mProgressBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            mBtnSignUp.Click += (object sender, EventArgs args) =>
            {
                //Pull up dilaog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_SignUp signUpDialog = new dialog_SignUp();
                signUpDialog.Show(transaction, "dialog fragment");

                signUpDialog.mOnSignUpComplete += SignUpDialog_mOnSignUpComplete;
            };

        }

        private void SignUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            mProgressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeARequest);
            thread.Start();
        }

        private void ActLikeARequest()
        {
            Thread.Sleep(3000);

            RunOnUiThread(() => { mProgressBar.Visibility = ViewStates.Invisible; });
        }
    }
}

