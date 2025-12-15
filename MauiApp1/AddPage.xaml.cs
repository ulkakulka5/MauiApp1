using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class AddPage : ContentPage
{
    int selected_ml = 0;
    public AddPage()
    {

        InitializeComponent();
       
       
    }

    private void x250_Clicked(object sender, EventArgs e)
    {
        selected_ml = 250;
        HighlightButton(x250);
    }

    private void x500_Clicked(object sender, EventArgs e)
    {
        selected_ml = 500;
        HighlightButton(x500);
    }

    private void x180_Clicked(object sender, EventArgs e)
    {
        selected_ml = 180;
        HighlightButton(x180);
    }

    private async void custom_Clicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync(
            "Custom amount",
            "Enter ml:",
            keyboard: Keyboard.Numeric,
            maxLength: 4);

        if (int.TryParse(result, out int ml) && ml > 0)
        {
            selected_ml = ml;
            HighlightButton(custom);
        }
    }
    void HighlightButton(ImageButton selected)
    {
        x250.Opacity = 0.5;
        x500.Opacity = 0.5;
        x180.Opacity = 0.5;
        custom.Opacity = 0.5;

        selected.Opacity = 1;
    }


    private async void ok_Clicked(object sender, EventArgs e)
    {
        HydrationData.drunk_ml += selected_ml;
        await Navigation.PopAsync();
    }
}

   