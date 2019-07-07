using System;
using System.Windows.Input;

namespace DynamicTabs.Practise01
{
    public interface ITab
    {
        string TabName { get; set; }
        ICommand CloseCommand { get; }
        event EventHandler CloseRequested;
    }

    public abstract class Tab : ITab
    {
        public Tab()
        {
            CloseCommand = new DelegateCommand(p => CloseRequested?.Invoke(this, EventArgs.Empty));
        }
        public string TabName { get; set; }
        public ICommand CloseCommand { get; }
        public event EventHandler CloseRequested;
    }
}

