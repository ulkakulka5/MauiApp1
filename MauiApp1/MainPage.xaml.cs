namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

   

    private async void add_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPage());
    }
}
