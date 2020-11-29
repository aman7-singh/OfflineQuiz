namespace OfflineQuiz.Model
{
    public class QuizModel
    {
        private string _question;
        private string _answer;
        private string _questionType;
        private bool _isSkip;

        public bool IsSkip
        {
            get { return _isSkip; }
            set { _isSkip = value; }
        }
        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }
        public string QuestionType
        {
            get { return _questionType; }
            set { _questionType = value; }
        }
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }

    }

}
