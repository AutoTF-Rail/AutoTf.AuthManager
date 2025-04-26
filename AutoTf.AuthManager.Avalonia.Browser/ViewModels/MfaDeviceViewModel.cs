using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoTf.AuthManager.Models;
using AutoTf.AuthManager.Models.Authentik;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;

namespace AutoTf.AuthManager.Avalonia.Browser.ViewModels;

public partial class MfaDeviceViewModel : ReactiveObject
{
    public ObservableCollection<MfaDevice> Devices { get; set; } = new ObservableCollection<MfaDevice>();
    public ObservableCollection<MenuItem> EnrollMenus { get; set; } = new ObservableCollection<MenuItem>();

    private Dictionary<string, string> _enrollTitleToLinkMappings = new Dictionary<string, string>();

    public ICommand RefreshCommand { get; }
    public ICommand DeleteCommand { get; }

    public MfaDeviceViewModel()
    {
        RefreshCommand = new AsyncRelayCommand(LoadDevices, () => true);
        DeleteCommand = new AsyncRelayCommand(DeleteDevices, () => true);
        Task.Run(Initialize);
    }

    private async Task Initialize()
    {
       await LoadDevices();
       await LoadEnrollButtons();
    }

    private async Task LoadEnrollButtons()
    {
        try
        {
            Console.WriteLine("Loading enroll methods.");
            EnrollMenus.Clear();
            
            string content = await HttpHelper.SendGetString(WebInterop.GetApiUrlFromJs() + "/stages/all/user_settings", false);
            
            JsonElement.ArrayEnumerator jsonArray = JsonDocument.Parse(content).RootElement.EnumerateArray();
            
            List<UserSetting> result = jsonArray.Select(UserSetting.Serialize).ToList();

            foreach (UserSetting setting in result)
            {
                // This password part.. is just how it is. I don't know why...
                if (string.IsNullOrEmpty(setting.Title) || setting.Title.Contains("Password Stage"))
                    continue;
                
                
                _enrollTitleToLinkMappings.Add(setting.Title, setting.ConfigureUrl);
                
                MenuItem item = new MenuItem()
                {
                    Header = setting.Title
                };
                item.Click += EnrollMenuItem_Click;
                
                EnrollMenus.Add(item);
            }
            
            Console.WriteLine($"Successfully loaded {EnrollMenus.Count} enroll methods.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong when loading the user settings:");
            Console.WriteLine(e.ToString());
        }
    }

    private void EnrollMenuItem_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is not MenuItem menu)
            return;

        string? text = menu.Header?.ToString();

        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Could not start enroll flow due to empty menu item.");
            return;
        }
        
        Console.WriteLine("Clicked enroll menu: " + text);
        WebInterop.OpenUrl(WebInterop.GetApiUrlFromJs() + _enrollTitleToLinkMappings[text]);
    }

    private async Task LoadDevices()
    {
        try
        {
            Console.WriteLine("Reloading MFA devices.");
            
            Devices.Clear();
            
            string totpDevices = await HttpHelper.SendGetString(WebInterop.GetApiUrlFromJs() + "/authenticators/all", false);
            
            JsonElement.ArrayEnumerator jsonArray = JsonDocument.Parse(totpDevices).RootElement.EnumerateArray();
            
            List<MfaDevice> result = jsonArray.Select(MfaDevice.Serialize).ToList();

            foreach (MfaDevice totpDevice in result)
            {
                Console.WriteLine(totpDevice.Name);
                Devices.Add(totpDevice);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong when reloading the MFA devices:");
            Console.WriteLine(e.ToString());
        }
    }

    private async Task DeleteDevices()
    {
        List<MfaDevice> selectedDevices = Devices.Where(x => x.IsChecked).ToList();

        Console.WriteLine($"Selected {selectedDevices.Count()} Device(s) to delete.");
        if (!selectedDevices.Any())
            return;
        
        // To ensure the user doesn't make any changes while we are deleting a device.
        Devices.Clear();
        
        foreach (MfaDevice device in selectedDevices)
        {
            Console.WriteLine($"Deleting device {device.Name} - {device.VerboseName}.");
            await HttpHelper.SendDelete($"/authenticators/{device.Type}/{device.Pk}");
        }
        
        await LoadDevices();
    }
}