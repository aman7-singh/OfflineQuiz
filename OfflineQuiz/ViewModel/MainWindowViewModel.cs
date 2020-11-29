using OfflineQuiz.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace OfflineQuiz.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand _checkCommand;
        private QuizViewModel quizViewModel = QuizViewModelFactory.CreateInstnce();
        private List<QuizModel> _incorrectMathAns;
        private List<QuizModel> _incorrectGKAns;
        private string _mathResultMsg;
        private string _gkResultMsg;

        public string MathResultMsg
        {
            get { return _mathResultMsg; }
            set
            {
                _mathResultMsg = value;
                OnPropertyRaised(nameof(MathResultMsg));
            }
        }
        public string GKResultMsg
        {
            get { return _gkResultMsg; }
            set
            {
                _gkResultMsg = value;
                OnPropertyRaised(nameof(GKResultMsg));
            }
        }
        public List<QuizModel> IncorrectGKAns
        {
            get { return _incorrectGKAns; }
            set
            {
                _incorrectGKAns = value;
                OnPropertyRaised(nameof(IncorrectGKAns));
            }
        }
        public List<QuizModel> IncorrectMathAns
        {
            get { return _incorrectMathAns; }
            set
            {
                _incorrectMathAns = value;
                OnPropertyRaised(nameof(IncorrectMathAns));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CheckCommand
        {
            get
            {
                return _checkCommand ?? (_checkCommand = new RelayCommand(() => CheckQuestion(), () => CanExecute));
            }

        }
        private void CheckQuestion()
        {
            IncorrectMathAns = GetMathResult(quizViewModel.MathQuestions);
            IncorrectGKAns = GetGkResult(quizViewModel.GKQuestions);
            System.Windows.MessageBox.Show("Your answere is submitted");
            var MathRslt = IncorrectMathAns.Count > 5 ? "FAIL" : "PASS";
            var GKRslt = IncorrectGKAns.Count > 5 ? "FAIL" : "PASS";
            MathResultMsg = $" Date: {DateTime.Today.Date} \n {IncorrectMathAns.Count} out of 10 questions is incorrrect. - {MathRslt}";
            GKResultMsg = $" Date: {DateTime.Today.Date} \n {IncorrectGKAns.Count} out of 10 questions is incorrrect. - {GKRslt} ";
        }

        public static List<QuizModel> GetMathResult(List<QuizModel> quizzes)
        {
            List<QuizModel> inCorrectAns = new List<QuizModel>();
            var ansData = QuestionDetailsData.GetMathsQuestions();

            foreach (var q in quizzes)
            {
                if (!ansData.Any(m => m.Answer.ToLower().Trim() == q.Answer.ToLower().Trim()
                && m.Question.ToLower().Trim() == q.Question.ToLower().Trim()))
                {
                    inCorrectAns.Add(q);
                }
            }
            return inCorrectAns;
        }

        public static List<QuizModel> GetGkResult(List<QuizModel> quizzes)
        {
            List<QuizModel> inCorrectAns = new List<QuizModel>();
            var ansData = QuestionDetailsData.GetGeneralKnowledgeQuestions();

            foreach (var q in quizzes)
            {
                if (!ansData.Any(m => m.Answer.ToLower().Trim() == q.Answer.ToLower().Trim()
                && m.Question.ToLower().Trim() == q.Question.ToLower().Trim()))
                {
                    inCorrectAns.Add(q);
                }
            }
            return inCorrectAns;
        }

        public bool CanExecute
        {
            get
            {
                return true;
            }
        }
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
    public static class MainWindowViewModelFactory
    {
        private static MainWindowViewModel _instnce;
        public static MainWindowViewModel CreateInstnce()
        {
            if (_instnce == null)
            {
                _instnce = new MainWindowViewModel();
            }
            return _instnce;
        }

    }
}
