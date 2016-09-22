using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Tables_Quiz
{
    [Activity(Label = "Tables_Quiz", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            RadioButton addition = FindViewById<RadioButton>(Resource.Id.radioButton5);
            RadioButton subtraction = FindViewById<RadioButton>(Resource.Id.radioButton6);
            RadioButton multiplication = FindViewById<RadioButton>(Resource.Id.radioButton8);
            RadioButton division = FindViewById<RadioButton>(Resource.Id.radioButton7);
            Button startQuiz = FindViewById<Button>(Resource.Id.start);

            startQuiz.Click += delegate
            {
                var intent = new Intent(this, typeof(QuizActivity));

                var userSelectionAdd = false;
                var userSelectionSub = false;
                var userSelectionMult = false;
                var userSelectionDiv = false;

                if (addition.Checked)
                {
                    userSelectionAdd = true;
                }
                if (subtraction.Checked)
                {
                    userSelectionSub = true;
                }
                if (multiplication.Checked)
                {
                    userSelectionMult = true;
                }
                if (division.Checked)
                {
                    userSelectionDiv = true;
                }

                intent.PutExtra("CheckAddData", userSelectionAdd);
                intent.PutExtra("CheckSubData", userSelectionSub);
                intent.PutExtra("CheckMultData", userSelectionMult);
                intent.PutExtra("CheckDivData", userSelectionDiv);

                StartActivity(intent);
            };
        }

        
    }
}

