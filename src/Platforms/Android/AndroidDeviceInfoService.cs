using Android.App;
using Android.Content.Res;
using Application = Android.App.Application;

namespace Opx.Blazor.Maui.Tools.Platforms.Android
{
    // All the code in this file is only included on Android.
    public class AndroidDeviceInfoService : IDeviceInfoService
    {
		public double GetStatusBarHeight()
		{
			int resourceId = Application.Context.Resources.GetIdentifier("status_bar_height", "dimen", "android");
			if (resourceId > 0)
			{
				return Application.Context.Resources.GetDimensionPixelSize(resourceId) / DeviceDisplay.MainDisplayInfo.Density;
			}
			return 0;
		}
	}
}
