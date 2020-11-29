using OfflineQuiz.ViewModel;
using System.Windows.Controls;

namespace OfflineQuiz.View
{
    /// <summary>
    /// Interaction logic for QuizView.xaml
    /// </summary>
    public partial class QuizView : UserControl
    {
        public QuizView()
        {
            InitializeComponent();
            this.DataContext = QuizViewModelFactory.CreateInstnce();
        }
    }
}
