using System;
using System.Collections.Generic;
using System.Linq;

namespace OfflineQuiz.Model
{
    internal static class QuestionDetailsData
    {
        public const string MathsType = "Maths";
        public const string GKType = "General Knowdledge";
        public const string ApplicantInfo = "Applicant Info";
        public static List<QuizModel> GetMathsQuestions()
        {
            var questionDetails = new List<QuizModel>()
            {
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = "1+2",
                    Answer = "3",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = "3*2",
                    Answer = "6",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = "8*2/2",
                    Answer = "8",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = "8+2*2",
                    Answer = "12",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = "8*2+2",
                    Answer = "18",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = "8-2*2",
                    Answer = "4",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = "8*2-2",
                    Answer = "14",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = "2*2-4/4",
                    Answer = "3",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = @"7/7",
                    Answer = "1",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = "12*12",
                    Answer = "144",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = "111*111",
                    Answer = "12321",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "Math",
                    Question = "12/4",
                    Answer = "3",
                    IsSkip=false
                }
            };

            var random = new Random();
            var SelectedQuestions = questionDetails.OrderBy(x => random.Next()).Take(10);
            return SelectedQuestions.ToList();
        }

        public static List<QuizModel> GetGeneralKnowledgeQuestions()
        {
            var questionDetails = new List<QuizModel>()
            {
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of India",
                    Answer = "Delhi",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of Punjab",
                    Answer = "Chandigadh",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of Telangana",
                    Answer = "Hyderabad",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of Arunachal Pradesh",
                    Answer = "Itanagar",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of Assam",
                    Answer = "Dispur",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of Bihar",
                    Answer = "Patna",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of Chhattisgarh",
                    Answer = "Raipur",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of Goa",
                    Answer = "Panaji",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of Odisha",
                    Answer = "Bhubaneswar",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of Tamil Nadu",
                    Answer = "Chennai",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of West Bengal",
                    Answer = "Kolkata",
                    IsSkip=false
                },
                new QuizModel
                {
                    QuestionType = "General Knowledge",
                    Question = "Capital of Karnataka",
                    Answer = "Bengaluru",
                    IsSkip=false
                }
            };

            var random = new Random();
            var SelectedQuestions = questionDetails.OrderBy(x => random.Next()).Take(10);
            return SelectedQuestions.ToList();
        }


    }
}
