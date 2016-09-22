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
    [Activity(Label = "QuizActivity")]
    public class QuizActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Quiz);

            TextView userScore = FindViewById<TextView>(Resource.Id.score);
            EditText firstNumber = FindViewById<EditText>(Resource.Id.number1);
            TextView calculationSign = FindViewById<TextView>(Resource.Id.calSign);
            EditText secondNumber = FindViewById<EditText>(Resource.Id.number2);
            Button option1 = FindViewById<Button>(Resource.Id.option1);
            Button option2 = FindViewById<Button>(Resource.Id.option2);
            Button option3 = FindViewById<Button>(Resource.Id.option3);
            Button option4 = FindViewById<Button>(Resource.Id.option4);
            Button backToMainMenu = FindViewById<Button>(Resource.Id.back1);

            var userSelectionAdd = Intent.GetBooleanExtra("CheckAddData", false);
            var userSelectionSub = Intent.GetBooleanExtra("CheckSubData", false);
            var userSelectionMult = Intent.GetBooleanExtra("CheckMultData", false);
            var userSelectionDiv = Intent.GetBooleanExtra("CheckDivData", false);

            int number1 = 0;
            int number2 = 0;
            int answer = 0;
            int ranNumber1 = 0;
            int ranNumber2 = 0;
            int ranNumber3 = 0;
            int ranNumber4 = 0;
            int score = 0;
            Random rnd = new Random();

            #region Addition Quiz
            if (userSelectionAdd)
            {
                calculationSign.Text = "+";

                AdditionQuiz();
            }
            #endregion
            #region Subtraction Quiz
            else if (userSelectionSub)
            {
                calculationSign.Text = "-";

                number1 = rnd.Next(1, 25);
                number2 = rnd.Next(1, 13);

                while (number2 > number1)
                {
                    while ((number1 - number2) > 12)
                    {
                        number2 = rnd.Next(1, 25);
                    }
                }

                firstNumber.Text = number1.ToString();
                secondNumber.Text = number2.ToString();

                answer = number1 - number2;

                PutAnswerInBox(answer);

                if (String.IsNullOrEmpty(option1.Text))
                {
                    ranNumber1 = rnd.Next(0, 13);
                    while (ranNumber1 == answer)
                    {
                        ranNumber1 = rnd.Next(0, 13);
                    }
                    option1.Text = ranNumber1.ToString();
                }
                if (String.IsNullOrEmpty(option2.Text))
                {
                    ranNumber2 = rnd.Next(0, 13);
                    while (ranNumber2 == answer || ranNumber2 == ranNumber1)
                    {
                        ranNumber1 = rnd.Next(0, 13);
                    }
                    option2.Text = ranNumber2.ToString();
                }
                if (String.IsNullOrEmpty(option3.Text))
                {
                    ranNumber3 = rnd.Next(0, 13);
                    while (ranNumber3 == answer || ranNumber3 == ranNumber2 || ranNumber3 == ranNumber1)
                    {
                        ranNumber1 = rnd.Next(0, 13);
                    }
                    option3.Text = ranNumber3.ToString();
                }
                if (String.IsNullOrEmpty(option4.Text))
                {
                    ranNumber4 = rnd.Next(0, 13);
                    while (ranNumber4 == answer || ranNumber4 == ranNumber3 || ranNumber4 == ranNumber2 || ranNumber4 == ranNumber1)
                    {
                        ranNumber1 = rnd.Next(0, 13);
                    }
                    option4.Text = ranNumber4.ToString();
                }

            }
            #endregion
            #region Multiplication Quiz
            else if (userSelectionMult)
            {
                calculationSign.Text = "*";

                PickRandomNumbers();

                number1 = int.Parse(firstNumber.Text);
                number2 = int.Parse(secondNumber.Text);
                answer = number1 * number2;

                PutAnswerInBox(answer);

                if (String.IsNullOrEmpty(option1.Text))
                {
                    ranNumber1 = rnd.Next(1, 145);
                    while (ranNumber1 == answer)
                    {
                        ranNumber1 = rnd.Next(1, 145);
                    }
                    option1.Text = ranNumber1.ToString();
                }
                if (String.IsNullOrEmpty(option2.Text))
                {
                    ranNumber2 = rnd.Next(1, 145);
                    while (ranNumber2 == answer || ranNumber2 == ranNumber1)
                    {
                        ranNumber1 = rnd.Next(1, 145);
                    }
                    option2.Text = ranNumber2.ToString();
                }
                if (String.IsNullOrEmpty(option3.Text))
                {
                    ranNumber3 = rnd.Next(1, 145);
                    while (ranNumber3 == answer || ranNumber3 == ranNumber2 || ranNumber3 == ranNumber1)
                    {
                        ranNumber1 = rnd.Next(1, 145);
                    }
                    option3.Text = ranNumber3.ToString();
                }
                if (String.IsNullOrEmpty(option4.Text))
                {
                    ranNumber4 = rnd.Next(1, 145);
                    while (ranNumber4 == answer || ranNumber4 == ranNumber3 || ranNumber4 == ranNumber2 || ranNumber4 == ranNumber1)
                    {
                        ranNumber1 = rnd.Next(1, 145);
                    }
                    option4.Text = ranNumber4.ToString();
                }
            }
            #endregion
            #region Division Quiz
            else if (userSelectionDiv)
            {
                
            }
            #endregion

            backToMainMenu.Click += delegate
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

            option1.Click += delegate
            {
                int numberInBox1 = 0;

                numberInBox1 = int.Parse(option1.Text);
                number1 = int.Parse(firstNumber.Text);
                number2 = int.Parse(secondNumber.Text);
                answer = Addition(number1, number2);

                if (numberInBox1 == answer)
                {
                    
                    option1.Text = null;
                    option2.Text = null;
                    option3.Text = null;
                    option4.Text = null;

                    score++;
                    userScore.Text = "Score: " + score.ToString();
                    AdditionQuiz();
                }
                else
                {
                    var intent = new Intent(this, typeof(WrongAnswerActivity));
                    StartActivity(intent);
                }
            };

            option2.Click += delegate
            {
                int numberInBox2 = 0;

                numberInBox2 = int.Parse(option2.Text);
                number1 = int.Parse(firstNumber.Text);
                number2 = int.Parse(secondNumber.Text);
                answer = Addition(number1, number2);

                if (numberInBox2 == answer)
                {
                    
                    option1.Text = null;
                    option2.Text = null;
                    option3.Text = null;
                    option4.Text = null;

                    score++;
                    userScore.Text = "Score: " + score.ToString();
                    AdditionQuiz();
                }
                else
                {
                    var intent = new Intent(this, typeof(WrongAnswerActivity));
                    StartActivity(intent);
                }
            };

            option3.Click += delegate
            {
                int numberInBox3 = 0;

                numberInBox3 = int.Parse(option3.Text);
                number1 = int.Parse(firstNumber.Text);
                number2 = int.Parse(secondNumber.Text);
                answer = Addition(number1, number2);

                if (numberInBox3 == answer)
                {
                    
                    option1.Text = null;
                    option2.Text = null;
                    option3.Text = null;
                    option4.Text = null;

                    score ++;
                    userScore.Text = "Score: " + score.ToString();
                    AdditionQuiz();
                }
                else
                {
                    var intent = new Intent(this, typeof(WrongAnswerActivity));
                    StartActivity(intent);
                }
            };

            option4.Click += delegate
            {
                int numberInBox4 = 0;

                numberInBox4 = int.Parse(option4.Text);
                number1 = int.Parse(firstNumber.Text);
                number2 = int.Parse(secondNumber.Text);
                answer = Addition(number1, number2);

                if (numberInBox4 == answer)
                {
                    
                    option1.Text = null;
                    option2.Text = null;
                    option3.Text = null;
                    option4.Text = null;

                    score++;
                    userScore.Text = "Score: " + score.ToString();
                    AdditionQuiz();
                }
                else
                {
                    var intent = new Intent(this, typeof(WrongAnswerActivity));
                    StartActivity(intent);
                }
            };
        }

        private int Addition(int number1, int number2)
        {            
            int answer = number1 + number2;
            return answer;
        }

        #region Methods
        private void AdditionQuiz()
        {
            EditText firstNumber = FindViewById<EditText>(Resource.Id.number1);
            EditText secondNumber = FindViewById<EditText>(Resource.Id.number2);
            Button option1 = FindViewById<Button>(Resource.Id.option1);
            Button option2 = FindViewById<Button>(Resource.Id.option2);
            Button option3 = FindViewById<Button>(Resource.Id.option3);
            Button option4 = FindViewById<Button>(Resource.Id.option4);

            int number1 = 0;
            int number2 = 0;
            int answer = 0;
            int ranNumber1 = 0;
            int ranNumber2 = 0;
            int ranNumber3 = 0;
            int ranNumber4 = 0;
            Random rnd = new Random();

            PickRandomNumbers();

            number1 = int.Parse(firstNumber.Text);
            number2 = int.Parse(secondNumber.Text);
            answer = Addition(number1, number2);

            PutAnswerInBox(answer);

            if (String.IsNullOrEmpty(option1.Text))
            {
                ranNumber1 = rnd.Next(2, 25);
                while (ranNumber1 == answer)
                {
                    ranNumber1 = rnd.Next(2, 25);
                }
                option1.Text = ranNumber1.ToString();
            }
            if (String.IsNullOrEmpty(option2.Text))
            {
                ranNumber2 = rnd.Next(2, 25);
                while (ranNumber2 == answer || ranNumber2 == ranNumber1)
                {
                    ranNumber1 = rnd.Next(2, 25);
                }
                option2.Text = ranNumber2.ToString();
            }
            if (String.IsNullOrEmpty(option3.Text))
            {
                ranNumber3 = rnd.Next(2, 25);
                while (ranNumber3 == answer || ranNumber3 == ranNumber2 || ranNumber3 == ranNumber1)
                {
                    ranNumber1 = rnd.Next(2, 25);
                }
                option3.Text = ranNumber3.ToString();
            }
            if (String.IsNullOrEmpty(option4.Text))
            {
                ranNumber4 = rnd.Next(2, 25);
                while (ranNumber4 == answer || ranNumber4 == ranNumber3 || ranNumber4 == ranNumber2 || ranNumber4 == ranNumber1)
                {
                    ranNumber1 = rnd.Next(2, 25);
                }
                option4.Text = ranNumber4.ToString();
            }
        }

        
        private void PutAnswerInBox(int answer)
        {
            Button option1 = FindViewById<Button>(Resource.Id.option1);
            Button option2 = FindViewById<Button>(Resource.Id.option2);
            Button option3 = FindViewById<Button>(Resource.Id.option3);
            Button option4 = FindViewById<Button>(Resource.Id.option4);

            Random rnd = new Random();

            int putAnswerInBox = rnd.Next(1, 5);
            if (putAnswerInBox == 1)
            {
                option1.Text = answer.ToString();
            }
            else if (putAnswerInBox == 2)
            {
                option2.Text = answer.ToString();
            }
            else if (putAnswerInBox == 3)
            {
                option3.Text = answer.ToString();
            }
            else if (putAnswerInBox == 4)
            {
                option4.Text = answer.ToString();
            }
        }

        private void PickRandomNumbers()
        {
            EditText firstNumber = FindViewById<EditText>(Resource.Id.number1);
            EditText secondNumber = FindViewById<EditText>(Resource.Id.number2);

            Random rnd = new Random();
            int num1 = rnd.Next(1, 13);
            int num2 = rnd.Next(1, 13);

            firstNumber.Text = num1.ToString();
            secondNumber.Text = num2.ToString();
        }
        #endregion
    }

}