using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Windows.Input;
using AutoTf.AuthManager.Models;
using AutoTf.AuthManager.Models.Authentik;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;

namespace AutoTf.AuthManager.Avalonia.Browser.ViewModels;

public partial class MfaDeviceViewModel : ReactiveObject
{
    public ObservableCollection<TotpDevice> Devices { get; set; } = new ObservableCollection<TotpDevice>();

    public ICommand RefreshCommand { get; }

    public MfaDeviceViewModel()
    {
        RefreshCommand = new RelayCommand(LoadDevices, () => true);
        LoadDevices();
    }

    private async void LoadDevices()
    {
        try
        {
            Console.WriteLine("Reloading MFA devices.");
            
            Devices.Clear();
            
            string totpDevices = await HttpHelper.SendGetString(UrlHelper.GetApiUrlFromJs() + "/authenticators/all", false);
            
            JsonElement.ArrayEnumerator jsonArray = JsonDocument.Parse(totpDevices).RootElement.EnumerateArray();
            
            List<TotpDevice> result = jsonArray.Select(TotpDevice.Serialize).ToList();

            // List<TotpDevice> result = new List<TotpDevice>()
            // {
            //     new TotpDevice()
            //     {
            //         VerboseName = "Meow"
            //     },
            //     new TotpDevice()
            //     {
            //         VerboseName = "Meow"
            //     },
            //     new TotpDevice()
            //     {
            //         VerboseName = "Meow"
            //     },
            //     new TotpDevice(),
            //     new TotpDevice(),
            //     new TotpDevice(),
            // };
            foreach (TotpDevice totpDevice in result)
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
}