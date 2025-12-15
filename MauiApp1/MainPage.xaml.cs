namespace MauiApp1;

public partial class MainPage : ContentPage
{
    const int circleHeight = 260;
    public MainPage()
    {
        InitializeComponent();
        UpdateUI();
    }

    protected override void OnAppearing() // wywo³ywane przy ka¿dym wejœciu na stronê!!
    {
        base.OnAppearing();// zawsze wywo³uj bazow¹ implementacjê, bez tego b³êdy
        UpdateUI();
    }

    void UpdateUI()
    {
        int drunk = HydrationData.drunk_ml;
        int remaining = HydrationData.goal_ml - drunk;

        if (remaining < 0)
            remaining = 0;

        double percent = (double)drunk / HydrationData.goal_ml * 100;
        if (percent > 100)
            percent = 100;

        drunkLabel.Text = $"{drunk} ml";
        remainingLabel.Text = $"remaining {remaining} ml";
        percentLabel.Text = $"{(int)percent}%";

        waterFill.HeightRequest = circleHeight * (percent / 100);
    }
    private async void Reset_Tapped(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert(
            "Reset",
            "Reset today's progress?",
            "Yes",
            "Cancel");

        if (!confirm)
            return;

        HydrationData.drunk_ml = 0;

        UpdateUI();
    }


    private async void add_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPage());
    }
}
