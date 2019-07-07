using DynamicTabs.Practise01.Models;
using System;

namespace DynamicTabs.Practise01.ViewModels
{
    class DateTabViewModel : Tab
    {
        public string FixedString { get; } = "Hello World!";
        public DateTabModel MyDateTabModel { get; }

        public DateTabViewModel(int tabId)
        {
            Name = DateTime.Now.ToString();
            MyDateTabModel = new DateTabModel(tabId);
        }
    }
}
