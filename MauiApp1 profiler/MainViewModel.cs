using Studencki_USOS_PUT_MAUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MauiApp1_profiler
{
    internal class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {

        }

        public async Task Init()
        {
            SetText();
            OnFinished?.Invoke();
        }

        class User
        {
            public string id;
            public string last_name;
            public string first_name;
            public string student_number;

            public User() { }
        }

        public Action OnFinished;

        void SetText()
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            var result = JsonConvert.DeserializeObject<User>("{\"id\": \"123\", \"first_name\": \"A\", \"last_name\": \"B\", \"student_number\": \"1\"}");
            TestLabel = "ID: " + result.id;
            stopwatch.Stop();
            TimerLabel = "Timer elapsed miliseconds ViewModel: " + stopwatch.Elapsed.Milliseconds.ToString();
        }

        public string TestLabel
        {
            get => testLabel;
            set
            {
                testLabel = value;
                OnPropertyChanged(nameof(TestLabel));
            }
        }
        string testLabel;


        public string TimerLabel
        {
            get => timerLabel;
            set
            {
                timerLabel = value;
                OnPropertyChanged(nameof(TimerLabel));
            }
        }
        string timerLabel;

    }
}
