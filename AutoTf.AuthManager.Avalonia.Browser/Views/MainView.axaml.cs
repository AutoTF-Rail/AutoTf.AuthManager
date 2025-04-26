using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
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
        
        Console.WriteLine(UrlHelper.GetApiUrlFromJs());
        
        if (textBlock.Text == "MFA Devices")
        {
            Console.WriteLine("Changing to MFA Devices tab.");
            List<TotpDevice>? totpDevices = await HttpHelper.SendGet<List<TotpDevice>>(UrlHelper.GetApiUrlFromJs() + "/authenticators/all", false);
            Console.WriteLine(totpDevices?.Count);
        }
    }
}