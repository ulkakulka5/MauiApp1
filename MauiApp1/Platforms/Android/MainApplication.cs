using Android.App;
using Android.Runtime;
using Android; // jeśli potrzebne

// Permissions do AndroidManifest (MAUI automatycznie je wstrzykuje)
[assembly: UsesPermission(Manifest.Permission.Vibrate)]
[assembly: UsesPermission("android.permission.SCHEDULE_EXACT_ALARM")] // Android 13+
[assembly: UsesPermission("android.permission.USE_EXACT_ALARM")]      // Android 13+, no prompt

// WAKE_LOCK i RECEIVE_BOOT_COMPLETED dodaj w Platforms/Android/AndroidManifest.xml
// <uses-permission android:name="android.permission.WAKE_LOCK" />
// <uses-permission android:name="android.permission.RECEIVE_BOOT_COMPLETED" />

namespace MauiApp1
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
