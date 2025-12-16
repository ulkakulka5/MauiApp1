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
        bool goal_ = HydrationData.goal;
        if (remaining < 0) remaining = 0;

        double percent = (double)drunk / HydrationData.goal_ml * 100;
        if (percent > 100) percent = 100;

        drunkLabel.Text = $"{drunk} ml";
        remainingLabel.Text = $"remaining {remaining} ml";
        percentLabel.Text = $"{(int)percent}%";

      

        if(drunk>=2000)
        {
            goal_ = true;
        }
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
        HydrationData.goal = false;
        UpdateUI();
    }

    private async void add_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPage());
        ScheduleReminder();
    }

    async void ScheduleReminder()
    {
        if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
        {
            await LocalNotificationCenter.Current.RequestNotificationPermission();
        }

        /*var notification = new NotificationRequest  
        {
            NotificationId = 1001,
            Title = "Pamiętaj o nawodnieniu",
            Description = $"Nie zapomnij wypić wody!",
            Schedule = new NotificationRequestSchedule{ NotifyTime = DateTime.Now.AddMinutes(1) }
        };*/
        var hour = DateTime.Now.Hour;
        if (hour==11 && HydrationData.goal==false)
        {
            var notification = new NotificationRequest
            {
                NotificationId = 1001,
                Title = "Pamiętaj o nawodnieniu",
                Description = $"Nie zapomnij wypić wody!",
                
            };
            LocalNotificationCenter.Current.Show(notification);
        }
        //LocalNotificationCenter.Current.Show(notification);
    }
}
