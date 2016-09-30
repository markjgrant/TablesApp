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
    [Activity(Label = "Tables Quiz")]
    public class WrongAnswerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.WrongAnswer);

            EditText finalNumber1 = FindViewById<EditText>(Resource.Id.finalNumber1);
            TextView finalCalSign = FindViewById<TextView>(Resource.Id.finalCalSign);
            EditText finalNumber2 = FindViewById<EditText>(Resource.Id.finalNumber2);
            EditText finalAnswer = FindViewById<EditText>(Resource.Id.finalAnswer);
            TextView finalScore = FindViewById<TextView>(Resource.Id.userScore);
            Button backToMain = FindViewById<Button>(Resource.Id.back2);

            var calSign = Intent.GetStringExtra("CalSign");
            var number1 = Intent.GetIntExtra("Number1Data", 0);
            var number2 = Intent.GetIntExtra("Number2Data", 0);
            var answer = Intent.GetIntExtra("AnswerData", 0);

            //display the correct answer.
            finalNumber1.Text = number1.ToString();
            finalCalSign.Text = calSign;
            finalNumber2.Text = number2.ToString();
            finalAnswer.Text = answer.ToString();

            //display the score.
            var score = Intent.GetIntExtra("ScoreData", 0);
            finalScore.Text = "Your score is " + score;

            //button to go back to main menu.
            backToMain.Click += delegate
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
        }
    }
}