using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF_MVVM_Test.Annotations;

namespace WPF_MVVM_Test;

public class ViewModel : INotifyPropertyChanged
{
    private string text = "TestText";

    public string Text
    {
        get => text;
        set
        {
            if (text != value)
            {
                text = value;
                RaisePropertyChanged();
            }
        }
    }
    
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    #endregion
    
    private ViewCommand _clearCommand;
    public ViewCommand ClearCommand
    {
        get => this._clearCommand ?? (this._clearCommand = new ViewCommand(
            _ => this.Text= "",
            _ => !string.IsNullOrEmpty(this.Text)));
    }
}