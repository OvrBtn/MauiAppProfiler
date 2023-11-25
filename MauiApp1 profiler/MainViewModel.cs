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
            SettingsText();
        }

        class User
        {
            public string Id;
            public string last_name;
            public string first_name;
            public string student_number;

            public User() { }
        }


        void SettingsText()
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            var result = JsonConvert.DeserializeObject<User>("{\"id\": \"123\", \"first_name\": \"A\", \"last_name\": \"B\", \"student_number\": \"1\"}");
            TestLabel = result.Id;
            stopwatch.Stop();
            var t = stopwatch.Elapsed.Milliseconds;
        }

        public string TestLabel
        {
            get => testLabel;
            set
            {
                testLabel = value;
                OnPropertyChanged();
            }
        }
        string testLabel;

    }
}
