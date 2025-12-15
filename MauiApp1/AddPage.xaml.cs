using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class AddPage : ContentPage
{
  
    public AddPage()
    {

        InitializeComponent();
       
       
    }

    private void x250_Clicked(object sender, EventArgs e)
    {
        
    }

    private void x500_Clicked(object sender, EventArgs e)
    {

    }

    private void x180_Clicked(object sender, EventArgs e)
    {

    }

    private void custom_Clicked(object sender, EventArgs e)
    {

    }

    private async void ok_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
