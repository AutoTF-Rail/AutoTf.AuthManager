using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using AutoTf.AuthManager.Avalonia.Browser.UserControls;
using AutoTf.AuthManager.Models;
using AutoTf.AuthManager.Models.Authentik;
using Avalonia;
using Avalonia.Controls;

namespace AutoTf.AuthManager.Avalonia.Browser.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private async void TabsListbox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (TabsListbox.SelectedItem is not TextBlock textBlock)
            return;
        
        if (textBlock.Text == "MFA Devices")
        {
            Console.WriteLine("Changing to MFA Devices tab.");
            ChildUserControl.Children.Add(new MfaDevicesView());
        }
    }
}