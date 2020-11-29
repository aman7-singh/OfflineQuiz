using OfflineQuiz.ViewModel;
using System.Windows.Controls;

namespace OfflineQuiz.View
{
    /// <summary>
    /// Interaction logic for ResultTab.xaml
    /// </summary>
    public partial class ResultTab : UserControl
    {
        public ResultTab()
        {
            InitializeComponent();
            this.DataContext = MainWindowViewModelFactory.CreateInstnce();
        }
    }
}
