using NUnit.Framework;
using OfflineQuiz.ViewModel;
using OfflineQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OfflineQuizTest
{
    [TestFixture]
    public class QuizViewModelTest
    {
        public const string MathsType = "Maths";
        public const string GKType = "General Knowdledge";
        public const string ApplicantInfo = "Applicant Info";

        [Test]
        public void NextCommandTest()
        {
            //Arrange
            var sat = new QuizViewModel();
            sat.GetQuizOfSelectedype(MathsType);

            //Act
            ICommand command = sat.NextCommand;
            command.Execute(true);

            //Assert
            Assert.IsFalse(sat.Quizzes[0].IsSkip);
            Assert.AreEqual("Question No. 2 :  Answer below query", sat.QuestionNum.Trim());
        }
        [Test]
        public void PreviousCommandTest()
        {
            //Arrange
            var sat = new QuizViewModel();
            ICommand nxtCommand = sat.NextCommand;
            nxtCommand.Execute(true);

            //Act
            ICommand command = sat.PreviousCommand;
            command.Execute(true);

            //Assert
            Assert.AreEqual("Question No. 1 :  Answer below query", sat.QuestionNum.Trim());
        }

        [Test]
        public void SkipCommandTest()
        {
            //Arrange
            var sat = new QuizViewModel();
            sat.GetQuizOfSelectedype(MathsType);
            //Act
            ICommand command = sat.SkipCommand;
            command.Execute(true);

            //Assert
            Assert.AreEqual("Question No. 2 :  Answer below query", sat.QuestionNum.Trim());
            Assert.IsTrue(sat.Quizzes[0].IsSkip);
        }
    }
}
