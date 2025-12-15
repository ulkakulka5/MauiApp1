using Microsoft.Maui.Controls;
using Plugin.LocalNotification;
using System;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    const int circleHeight = 260;

    public MainPage()
    {
        InitializeComponent();
        UpdateUI();
        ScheduleReminder(); 
    }

    protected override void OnAppearing()  //override służy do zmiany zachowania metody dziedziczonej z klasy bazowej
    {
        base.OnAppearing(); //wywołuje oryginalną implementację metody OnAppearing z klasy bazowej ContentPage
        UpdateUI();
    }

    void UpdateUI()
    {
        int drunk = HydrationData.drunk_ml;
        int remaining = HydrationData.goal_ml - drunk;

        if (remaining < 0) remaining = 0;

        double percent = (double)drunk / HydrationData.goal_ml * 100;
        if (percent > 100) percent = 100;

        drunkLabel.Text = $"{drunk} ml";
        remainingLabel.Text = $"remaining {remaining} ml";
        percentLabel.Text = $"{(int)percent}%";

        waterFill.HeightRequest = circleHeight * (percent / 100);
        dateLabel.Text = DateTime.Now.ToString("dd.MM.yyyy");
    }

    private async void Reset_Tapped(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert(
            "Reset",
            "Reset today's progress?",
            "Yes",
            "Cancel");

        if (!confirm) return;

        HydrationData.drunk_ml = 0;
        UpdateUI();
    }

    private async void add_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPage());
    }

    void ScheduleReminder()
    {
        var reminderTime = DateTime.Now.AddMinutes(1);

        var notification = new NotificationRequest
        {
            NotificationId = 1001,
            Title = "Pamiętaj o nawodnieniu",
            Description = $"Nie zapomnij wypić wody!",
            Schedule = { NotifyTime = reminderTime }
        };

        LocalNotificationCenter.Current.Show(notification);
    }
}
