namespace MauiApp1_profiler
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            timerLabel.Text = "Timer MainPage.ctor: " + stopwatch.Elapsed.Milliseconds.ToString();
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            var viewModel = BindingContext as MainViewModel;
            await viewModel.Init();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
