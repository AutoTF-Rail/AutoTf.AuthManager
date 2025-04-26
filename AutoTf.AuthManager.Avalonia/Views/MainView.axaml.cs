using Avalonia.Controls;

namespace AutoTf.AuthManager.Avalonia.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void TabsListbox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (TabsListbox.SelectedItem is not TextBlock textBlock)
            return;
        
        if (textBlock.Text == "MFA Devices")
        {
            Console.WriteLine("Changing to MFA Devices tab.");
        }
    }
}