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

            //variables for holding the value of the type of quiz chosen.
            var userSelectionAdd = Intent.GetBooleanExtra("CheckAddData", false);
            var userSelectionSub = Intent.GetBooleanExtra("CheckSubData", false);
            var userSelectionMult = Intent.GetBooleanExtra("CheckMultData", false);
            var userSelectionDiv = Intent.GetBooleanExtra("CheckDivData", false);

            int number1 = 0;
            int number2 = 0;
            int answer = 0;
            int score = 0;
            Random rnd = new Random();

            //checks for calculation sign to be used and the type of quiz chosen.
            //sends calculation sign to WrongAnswerActivity to display correct answer.
            if (userSelectionAdd)
            {
                calculationSign.Text = "+";

                AdditionQuiz();

                string finalCalSign = "+";
                var intent = new Intent(this, typeof(WrongAnswerActivity));
                intent.PutExtra("CalSign", finalCalSign);
                StartActivity(intent);
            }
            else if (userSelectionSub)
            {
                calculationSign.Text = "-";

                SubtractionQuiz();

                string finalCalSign = "-";
                var intent = new Intent(this, typeof(WrongAnswerActivity));
                intent.PutExtra("CalSign", finalCalSign);
                StartActivity(intent);
            }
            else if (userSelectionMult)
            {
                calculationSign.Text = "x";

                MultiplicationQuiz();

                string finalCalSign = "x";
                var intent = new Intent(this, typeof(WrongAnswerActivity));
                intent.PutExtra("CalSign", finalCalSign);
                StartActivity(intent);
            }
            else if (userSelectionDiv)
            {
                calculationSign.Text = "/";

                DivisionQuiz();

                string finalCalSign = "/";
                var intent = new Intent(this, typeof(WrongAnswerActivity));
                intent.PutExtra("CalSign", finalCalSign);
                StartActivity(intent);
            }

            //button to go back to main menu.
            backToMainMenu.Click += delegate
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

            #region Multiple Choice 1 Button
            //button for first selection box
            option1.Click += delegate
            {
                int numberInBox1 = 0;

                //if user picked addition quiz.
                if (userSelectionAdd)
                {
                    numberInBox1 = int.Parse(option1.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 + number2;

                    //checks if the correct answer is equal to the number in the box 1.
                    if (numberInBox1 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        AdditionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                //if user picked subtraction quiz.
                else if (userSelectionSub)
                {
                    numberInBox1 = int.Parse(option1.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 - number2;

                    //checks if the correct answer is equal to the number in the box 1.
                    if (numberInBox1 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        SubtractionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                //if user picked multiplication quiz
                else if (userSelectionMult)
                {
                    numberInBox1 = int.Parse(option1.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 * number2;

                    //checks if the correct answer is equal to the number in the box 1.
                    if (numberInBox1 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        MultiplicationQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                //if user picked division quiz.
                else if (userSelectionDiv)
                {
                    numberInBox1 = int.Parse(option1.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 / number2;

                    //checks if the correct answer is equal to the number in the box 1.
                    if (numberInBox1 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        DivisionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
            };
            #endregion

            #region Multiple Choice 2 Button
            //button for second selection box
            option2.Click += delegate
            {
                int numberInBox2 = 0;

                //if user picked addition quiz.
                if (userSelectionAdd)
                {
                    numberInBox2 = int.Parse(option2.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 + number2;

                    //checks if the correct answer is equal to the number in the box 2.
                    if (numberInBox2 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        AdditionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                //if user picked subtraction quiz.
                else if (userSelectionSub)
                {
                    numberInBox2 = int.Parse(option2.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 - number2;

                    //checks if the correct answer is equal to the number in the box 2.
                    if (numberInBox2 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        SubtractionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                // if user picks multiplication quiz.
                else if (userSelectionMult)
                {
                    numberInBox2 = int.Parse(option2.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 * number2;

                    //checks if the correct answer is equal to the number in the box 2.
                    if (numberInBox2 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        MultiplicationQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                // if user picks division quiz.
                else if (userSelectionDiv)
                {
                    numberInBox2 = int.Parse(option2.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 / number2;

                    //checks if the correct answer is equal to the number in the box 2.
                    if (numberInBox2 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        DivisionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
            };
            #endregion

            #region Multiple Choice 3 Button
            //button for third selection box
            option3.Click += delegate
            {
                int numberInBox3 = 0;

                // if user picks addition quiz
                if (userSelectionAdd)
                {
                    numberInBox3 = int.Parse(option3.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 + number2;

                    //checks if the correct answer is equal to the number in the box 3.
                    if (numberInBox3 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        AdditionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                // if user picks subtraction quiz.
                else if (userSelectionSub)
                {
                    numberInBox3 = int.Parse(option3.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 - number2;

                    //checks if the correct answer is equal to the number in the box 3.
                    if (numberInBox3 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        SubtractionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                // if user picks multiplication quiz.
                else if (userSelectionMult)
                {
                    numberInBox3 = int.Parse(option3.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 * number2;

                    //checks if the correct answer is equal to the number in the box 3.
                    if (numberInBox3 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        MultiplicationQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                // if user picks division quiz
                else if (userSelectionDiv)
                {
                    numberInBox3 = int.Parse(option3.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 / number2;

                    //checks if the correct answer is equal to the number in the box 3.
                    if (numberInBox3 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        DivisionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
            };
            #endregion

            #region Multiple Choice 4 Button
            //button for fourth selection box.
            option4.Click += delegate
            {
                int numberInBox4 = 0;

                // if user picks addition quiz
                if (userSelectionAdd)
                {
                    numberInBox4 = int.Parse(option4.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 + number2;

                    //checks if the correct answer is equal to the number in the box 4.
                    if (numberInBox4 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        AdditionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                // if user picks subtraction quiz
                if (userSelectionSub)
                {
                    numberInBox4 = int.Parse(option4.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 - number2;

                    //checks if the correct answer is equal to the number in the box 4.
                    if (numberInBox4 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        SubtractionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                // if user picks multiplication quiz.
                else if (userSelectionMult)
                {
                    numberInBox4 = int.Parse(option4.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 * number2;

                    //checks if the correct answer is equal to the number in the box 4.
                    if (numberInBox4 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        MultiplicationQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
                // if user picks division quiz.
                else if (userSelectionDiv)
                {
                    numberInBox4 = int.Parse(option4.Text);
                    number1 = int.Parse(firstNumber.Text);
                    number2 = int.Parse(secondNumber.Text);
                    answer = number1 / number2;

                    //checks if the correct answer is equal to the number in the box 4.
                    if (numberInBox4 == answer)
                    {
                        score++;
                        userScore.Text = "Score: " + score.ToString();

                        ContinueQuiz();

                        DivisionQuiz();
                    }
                    else
                    {
                        SendCorrectAnswer(number1, number2, answer);
                        SendFinalScore(score);
                    }
                }
            };
            #endregion
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
            answer = number1 + number2;

            PutAnswerInBox(answer);

            //Place wrong answers in remaining empty boxes.
            //Check that all numbers are different in each box.
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

        private void SubtractionQuiz()
        {
            EditText firstNumber = FindViewById<EditText>(Resource.Id.number1);
            EditText secondNumber = FindViewById<EditText>(Resource.Id.number2);

            int number1 = 0;
            int number2 = 0;
            int answer = 0;
            Random rnd = new Random();

            number1 = rnd.Next(1, 25);
            number2 = rnd.Next(1, 13);

            //Ensure the difference between the two numbers is never greater than 12.
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

            WrongAnswers12Numbers(answer);
        }

        private void MultiplicationQuiz()
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
            answer = number1 * number2;

            PutAnswerInBox(answer);

            //Place wrong answers in remaining empty boxes.
            //Check that all numbers are different in each box.
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

        private void DivisionQuiz()
        {
            EditText firstNumber = FindViewById<EditText>(Resource.Id.number1);
            EditText secondNumber = FindViewById<EditText>(Resource.Id.number2);
            
            int number1 = 0;
            int number2 = 0;
            int answer = 0;           
            Random rnd = new Random();

            //Ensure answer is always a whole number.
            number2 = rnd.Next(1, 13);
            number1 = number2 * (rnd.Next(1, 13));

            firstNumber.Text = number1.ToString();
            secondNumber.Text = number2.ToString();

            answer = number1 / number2;

            PutAnswerInBox(answer);

            WrongAnswers12Numbers(answer);           
        }

        private void WrongAnswers12Numbers(int answer)
        {
            Button option1 = FindViewById<Button>(Resource.Id.option1);
            Button option2 = FindViewById<Button>(Resource.Id.option2);
            Button option3 = FindViewById<Button>(Resource.Id.option3);
            Button option4 = FindViewById<Button>(Resource.Id.option4);

            int ranNumber1 = 0;
            int ranNumber2 = 0;
            int ranNumber3 = 0;
            int ranNumber4 = 0;
            Random rnd = new Random();

            //Place wrong answers in remaining empty boxes.
            //Check that all numbers are different in each box.
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

        private void SendCorrectAnswer(int number1, int number2, int answer)
        {
            var intent = new Intent(this, typeof(WrongAnswerActivity));
            //Send the correct answer for display to WrongAnswerActivity.cs.
            intent.PutExtra("Number1Data", number1);
            intent.PutExtra("Number2Data", number2);
            intent.PutExtra("AnswerData", answer);
            StartActivity(intent);
        }

        private void SendFinalScore(int score)
        {
            var intent = new Intent(this, typeof(WrongAnswerActivity));
            //Send the user score for display to WrongAnswerActivity.cs.
            intent.PutExtra("ScoreData", score);
            StartActivity(intent);
        }
        
        private void ContinueQuiz()
        {
            Button option1 = FindViewById<Button>(Resource.Id.option1);
            Button option2 = FindViewById<Button>(Resource.Id.option2);
            Button option3 = FindViewById<Button>(Resource.Id.option3);
            Button option4 = FindViewById<Button>(Resource.Id.option4);

            //Set the option boxes to null.
            option1.Text = null;
            option2.Text = null;
            option3.Text = null;
            option4.Text = null;          
        }

        private void PutAnswerInBox(int answer)
        {
            Button option1 = FindViewById<Button>(Resource.Id.option1);
            Button option2 = FindViewById<Button>(Resource.Id.option2);
            Button option3 = FindViewById<Button>(Resource.Id.option3);
            Button option4 = FindViewById<Button>(Resource.Id.option4);

            Random rnd = new Random();

            int putAnswerInBox = rnd.Next(1, 5);

            //Place the correct answer in any one of the boxes.
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