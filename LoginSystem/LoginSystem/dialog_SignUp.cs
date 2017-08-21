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

namespace LoginSystem
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string mFirstName;
        private string mEmail;
        private string mPassword;

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public OnSignUpEventArgs(string firstname, string email, string password) : base()
        {
            FirstName = firstname;
            Email = email;
            Password = password;

        }
    }

    class dialog_SignUp : DialogFragment
    {
        private EditText mtxtFirstName;
        private EditText mtxtEmail;
        private EditText mtxtPassword;
        private Button mBtnsignUp;

        public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            mtxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mtxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mtxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mBtnsignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            mBtnsignUp.Click += mBtnsignUp_Click;

            return view;
        }

        private void mBtnsignUp_Click(object sender, EventArgs e)
        {
            //User has clicked the sign up button
            mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mtxtFirstName.Text,
                mtxtEmail.Text, mtxtPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);//Sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;//set the animation

        }
    }
}