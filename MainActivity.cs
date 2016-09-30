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
    [Activity(Label = "Tables Quiz", MainLauncher = true, Icon = "@drawable/einstein")]
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

                //variables to hold the type of quiz chosen.
                var userSelectionAdd = false;
                var userSelectionSub = false;
                var userSelectionMult = false;
                var userSelectionDiv = false;

                //variable for chosen quiz type is given a true value.
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

                //variables are sent to QuizActivity.cs.
                intent.PutExtra("CheckAddData", userSelectionAdd);
                intent.PutExtra("CheckSubData", userSelectionSub);
                intent.PutExtra("CheckMultData", userSelectionMult);
                intent.PutExtra("CheckDivData", userSelectionDiv);

                StartActivity(intent);
            };
        }

        
    }
}

