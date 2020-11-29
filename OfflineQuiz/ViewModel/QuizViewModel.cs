using OfflineQuiz.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace OfflineQuiz.ViewModel
{
    public class QuizViewModel : INotifyPropertyChanged
    {


        public List<QuizModel> Quizzes;
        private ICommand _nextCommand;
        private ICommand _previousCommand;
        private ICommand _skipCommand;

        private string _questionType = QuestionDetailsData.MathsType;
        private bool _isSkip;

        public readonly List<QuizModel> MathQuestions;
        public readonly List<QuizModel> GKQuestions;

        private int _questionNum;
        private string _answer;
        private string _question;
        public bool IsPreviousEnable
        {
            get
            {
                if (_questionNum > 0)
                {
                    return true;
                }
                return false;
            }
        }
        public bool IsNextEnable
        {
            get
            {
                if (_questionNum >= 9)
                {
                    return false;
                }
                return true;
            }
        }
        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new RelayCommand(() => NextQuestion(), () => CanExecute));
            }
        }
        public ICommand PreviousCommand
        {
            get
            {
                return _previousCommand ?? (_previousCommand = new RelayCommand(() => PreviousQuestion(), () => CanExecute));
            }
        }
        public ICommand SkipCommand
        {
            get
            {
                return _skipCommand ?? (_skipCommand = new RelayCommand(() => SkipQuestion(), () => CanExecute));
            }
        }

        public string QuestionNum
        {
            get { return $"Question No. {_questionNum + 1 } :  Answer below query "; }
            set
            {
                _questionNum = Convert.ToInt32(value);
                OnPropertyRaised(nameof(QuestionNum));
            }
        }
        public bool IsSkip
        {
            get { return Quizzes[_questionNum].IsSkip; }
            set
            {
                _isSkip = value;
                OnPropertyRaised(nameof(IsSkip));
            }
        }
        public string Question
        {
            get
            {
                if (Quizzes == null || Quizzes.Count == 0 || _questionNum < 0)
                {
                    return "Invalid question";
                }
                return Quizzes[_questionNum].Question;
            }
            set
            {
                _question = value;
                OnPropertyRaised(nameof(Question));
            }
        }
        public string QuestionType
        {
            get
            {
                return _questionType;
            }
            set
            {
                _questionType = value;
                GetQuizOfSelectedype(value);
                OnPropertyRaised(nameof(QuestionType));
            }
        }
        public string Answer
        {
            get
            {
                try
                {
                    return Quizzes[_questionNum].Answer;
                }
                catch
                {
                    return "Enter Your answer here";
                }
            }
            set
            {
                _answer = value;
                Quizzes[_questionNum].Answer = value;
                OnPropertyRaised(nameof(Answer));
            }
        }

        public QuizViewModel()
        {
            MathQuestions = QuestionDetailsData.GetMathsQuestions();
            GKQuestions = QuestionDetailsData.GetGeneralKnowledgeQuestions();
            _questionNum = 0;
            MathQuestions.ForEach(m => m.Answer = "");
            GKQuestions.ForEach(g => g.Answer = "");
        }
        private void NextQuestion()
        {
            _questionNum = _questionNum + 1;
            OnPropertyRaised(nameof(IsNextEnable));
            OnPropertyRaised(nameof(IsPreviousEnable));
            OnPropertyRaised(nameof(QuestionNum));
            OnPropertyRaised(nameof(IsSkip));
            OnPropertyRaised(nameof(Answer));
            OnPropertyRaised(nameof(Question));
        }
        private void PreviousQuestion()
        {
            _questionNum = _questionNum - 1;
            OnPropertyRaised(nameof(IsNextEnable));
            OnPropertyRaised(nameof(IsPreviousEnable));
            OnPropertyRaised(nameof(QuestionNum));
            OnPropertyRaised(nameof(IsSkip));
            OnPropertyRaised(nameof(Question));
            OnPropertyRaised(nameof(Answer));
        }
        private void SkipQuestion()
        {
            if (_questionNum == 9)
            {
                Quizzes[_questionNum].IsSkip = true;
                return;
            }
            Quizzes[_questionNum].IsSkip = true;
            _questionNum = _questionNum + 1;
            OnPropertyRaised(nameof(IsNextEnable));
            OnPropertyRaised(nameof(IsPreviousEnable));
            OnPropertyRaised(nameof(QuestionNum));
            OnPropertyRaised(nameof(Question));
            OnPropertyRaised(nameof(Answer));
        }


        public bool CanExecute
        {
            get
            {
                return true;
            }
        }


        public void GetQuizOfSelectedype(string QuesType)
        {
            switch (QuesType)
            {
                case QuestionDetailsData.MathsType:
                    Quizzes = MathQuestions;
                    break;
                case QuestionDetailsData.GKType:
                    Quizzes = GKQuestions;
                    break;
                default:
                    Quizzes = new List<QuizModel>();
                    break;
            }
            OnPropertyRaised(nameof(Question));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }

    public static class QuizViewModelFactory
    {
        private static QuizViewModel _instnce;
        public static QuizViewModel CreateInstnce()
        {
            if (_instnce == null)
            {
                _instnce = new QuizViewModel();
            }
            return _instnce;
        }

    }
}
