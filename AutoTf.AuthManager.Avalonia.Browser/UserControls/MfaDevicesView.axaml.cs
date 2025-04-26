using AutoTf.AuthManager.Avalonia.Browser.ViewModels;
using Avalonia.Controls;

namespace AutoTf.AuthManager.Avalonia.Browser.UserControls;

public partial class MfaDevicesView : UserControl
{
    public MfaDevicesView()
    {
        InitializeComponent();
        DataContext = new MfaDeviceViewModel();
    }
}