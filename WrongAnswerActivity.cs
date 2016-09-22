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

namespace Tables_Quiz
{
    [Activity(Label = "WrongAnswerActivity")]
    public class WrongAnswerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.WrongAnswer);

            TextView score = FindViewById<TextView>(Resource.Id.userScore);
            Button backToMain = FindViewById<Button>(Resource.Id.back2);

            backToMain.Click += delegate
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
        }
    }
}