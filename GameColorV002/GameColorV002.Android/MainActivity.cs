using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace GameColorV002.Droid
{
	[Activity (Label = "Даша не знает",Icon ="@drawable/bwb", Theme= "@style/Theme.DeviceDefault.NoActionBar.Fullscreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.SensorLandscape)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 
            base.OnCreate (bundle);
            global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new GameColorV002.App ());
		}
	}
}

