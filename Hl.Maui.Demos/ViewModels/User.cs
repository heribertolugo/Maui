using CommunityToolkit.Mvvm.ComponentModel;

namespace Hl.Maui.Demos.ViewModels;

public class User : ObservableObject
{
    private string _userName = string.Empty;
    private string _password = string.Empty;
    private bool _isActive = false;

    public string UserName
    {
        get => this._userName;
        set
        {
            base.SetProperty(ref this._userName, value);
        }
    }
    public string Password
    {
        get => this._password;
        set
        {
            base.SetProperty(ref this._password, value);
        }
    }
    public bool IsActive
    {
        get => this._isActive;
        set
        {
            base.SetProperty(ref this._isActive, value);
        }
    }
}
