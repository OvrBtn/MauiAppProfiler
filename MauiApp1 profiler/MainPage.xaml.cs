namespace MauiApp1_profiler
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            viewModel = new MainViewModel();
            viewModel.OnFinished = SetContext;

            Task.Run(() =>
            {
                viewModel.Init();
            });

            //viewModel.Init();

            stopwatch.Stop();
            timerLabel.Text = "Timer MainPage.ctor: " + stopwatch.Elapsed.Milliseconds.ToString();
        }

        void SetContext()
        {
            BindingContext = viewModel;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
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
