using OfflineQuiz.ViewModel;
using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Threading;
namespace OfflineQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _timer;
        TimeSpan _time;
        public MainWindow()
        {
            InitializeComponent();
            TabControl.SelectedIndex = 0;
            SubmitBtn.IsEnabled = false;
            ResultTab.IsEnabled = false;
            GKTab.IsEnabled = false;
            MathTab.IsEnabled = false;
            AppInfoTab.IsEnabled = true;

            SubmitBtn.DataContext = MainWindowViewModelFactory.CreateInstnce();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _time = TimeSpan.FromMinutes(20);
                _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    TimeLbl.Content = _time.ToString("c");
                    if (_time == TimeSpan.Zero)
                    {
                        ButtonAutomationPeer peer = new ButtonAutomationPeer(SubmitBtn);
                        var invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                        invokeProv.Invoke();
                        _timer.Stop();
                    }
                    _time = _time.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);
                _timer.Start();
            }
            finally
            {
                GKTab.IsEnabled = true;
                MathTab.IsEnabled = true;
                AppInfoTab.IsEnabled = false;
                SubmitBtn.IsEnabled = true;
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl.SelectedIndex = TabControl.SelectedIndex < 0 ? 0 : TabControl.SelectedIndex;

            QuizViewModelFactory.CreateInstnce().QuestionType = (TabControl.SelectedItem as TabItem).Header.ToString();
        }
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            SubmitBtn.IsEnabled = false;
            MathTab.IsEnabled = false;
            GKTab.IsEnabled = false;
            ResultTab.IsEnabled = true;
        }
    }
}
