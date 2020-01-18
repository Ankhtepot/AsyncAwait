using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwait
{ //   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int MainWindowWidth = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            ColorBlock.Margin = new Thickness(0, 0, MainWindowWidth - (int)ColorBlock.Width, 0);

            StatusTextBlock.Text = "...working...";
            await MoveBlockAsync(3);
            StatusTextBlock.Text = "Process finished";


            //var task = Wait5Seconds();
            //StatusTextBlock.Text = "...working...";
            //await Wait5Seconds();
        }

        private async Task Wait5Seconds()
        {
            await Task.Delay(5000);
        }

        private async Task MoveBlockAsync(int lines)
        {
            int startLeftPos = MainWindowWidth - (int)ColorBlock.Width;
            int topMargin = 0;

            for (int i = 0; i < lines; i++)
            {
                for (int w = startLeftPos; w > -startLeftPos; w -= 5)
                {
                    ChangeImageMargin(new Thickness(0, topMargin, w, 0));
                    await Task.Delay(1);
                }

                topMargin += 20;
            }
        }

        private void ChangeImageMargin(Thickness newMargin)
        {
            ColorBlock.Margin = new Thickness(0, newMargin.Top, newMargin.Right, 0);
        }

        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindowWidth = (int)e.NewSize.Width;
            Thickness newMargin = ColorBlock.Margin;
            newMargin.Right = MainWindowWidth - ColorBlock.Width;
            ColorBlock.Margin = newMargin;
        }
    }
}
