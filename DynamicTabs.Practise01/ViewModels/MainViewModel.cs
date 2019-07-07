using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;

namespace DynamicTabs.Practise01.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand NewTabCommand { get; }
        private readonly ObservableCollection<ITab> tabs;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<ITab> Tabs { get; }
        private int selectedTabIndex;
        public int SelectedTabIndex
        {
            get
            {
                return selectedTabIndex;
            }
            set
            {
                selectedTabIndex = value;
                OnPropertyChanged(nameof(SelectedTabIndex));
            }
        }

        public MainViewModel()
        {
            NewTabCommand = new DelegateCommand(NewTab);
            tabs = new ObservableCollection<ITab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;
            Tabs = tabs;

            NewTab(null);
        }
        ~MainViewModel()
        {
            tabs.CollectionChanged -= Tabs_CollectionChanged;
        }

        private static int TabId = 0;

        private void NewTab(object obj)
        {
            Tabs.Add(new DateTabViewModel(TabId++));
            SelectedTabIndex = Tabs.Count - 1;
        }

        private void Tabs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ITab tab;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (ITab)e.NewItems[0];
                    tab.CloseRequested += OnTabCloseRequested;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    tab = (ITab)e.OldItems[0];
                    tab.CloseRequested -= OnTabCloseRequested;
                    break;
            }
        }

        private void OnTabCloseRequested(object sender, EventArgs e)
        {
            if (Tabs.Count > 1)
                Tabs.Remove((ITab)sender);
        }
    }
}
