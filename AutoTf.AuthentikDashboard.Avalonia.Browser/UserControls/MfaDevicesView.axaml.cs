using System;
using System.Collections.Generic;
using AutoTf.AuthentikDashboard.Models.Authentik;
using Avalonia.Controls;
using System.Linq;
using AutoTf.AuthentikDashboard.Avalonia.Browser.ViewModels;

namespace AutoTf.AuthentikDashboard.Avalonia.Browser.UserControls;

public partial class MfaDevicesView : UserControl
{
    public MfaDevicesView()
    {
        InitializeComponent();
        DataContext = new MfaDeviceViewModel();
    }

    // This breaks the MVVM pattern, but the property changed for the selected item doesn't work properly
    private void MfaDevicesList_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (DevicesList.SelectedItem is not MfaDevice device)
            return;
        DevicesList.SelectedItem = null;
        
        int deviceIndex = DevicesList.Items.IndexOf(device);
        List<MfaDevice> devices = DevicesList.Items.Select(x => (MfaDevice)x!).ToList();
        devices[deviceIndex].IsChecked = !device.IsChecked;
        DevicesList.ItemsSource = devices;
    }
}