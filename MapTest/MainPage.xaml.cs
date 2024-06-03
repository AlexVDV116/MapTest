using Microsoft.Maui.Controls.Maps;
using System.Collections.ObjectModel;
using Microsoft.Maui.Maps;

namespace MapTest;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Pin> Pins { get; set; }

    public MainPage()
    {
        InitializeComponent();
        Pins = new ObservableCollection<Pin>();
        AddPinsToMap();
        PinsListView.ItemsSource = Pins;
    }

    private void AddPinsToMap()
    {
        var testPin = new Pin
        {
            Label = "Test Pin",
            Address = "Test Address",
            Type = PinType.Place,
            Location = new Location(51.35389208318162, 5.2676415022391)
        };
        Map.Pins.Add(testPin);
        Pins.Add(testPin);
    }

    private void ItemListView_OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Pin selectedPin)
        {
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(selectedPin.Location, Distance.FromMeters(500)));
            
            // Optionally display pin details using DisplayAlert
            DisplayPinDetails(selectedPin);
        }

        ((ListView)sender).SelectedItem = null;
    }

    private  void DisplayPinDetails(Pin pin)
    {
        DisplayAlert("Pin Selected", $"Pin: {pin.Label}, Address: {pin.Address}", "OK");
    }
}