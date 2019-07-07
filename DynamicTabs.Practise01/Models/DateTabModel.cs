using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicTabs.Practise01.Models
{
    public class DateTabModel : INotifyPropertyChanged
    {
        public string ModelName { get; }
        private int timeRan;
        public int TimeRan
        {
            get
            {
                return timeRan;
            }
            set
            {
                timeRan = value;
                OnPropertyChanged(nameof(TimeRan));
            }
        }

        public DateTabModel(int tabId)
        {
            ModelName = $"My name is Tabby{tabId}.";
            StartRunning();
        }

        public async void StartRunning()
        {
            while (true)
            {
                await Task.Delay(1000);
                TimeRan++;
            }            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
