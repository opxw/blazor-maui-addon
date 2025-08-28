using UIKit;

namespace Opx.Blazor.Maui.Tools.Platforms.iOS
{
    // All the code in this file is only included on iOS.
    public class iOSDeviceInfoService : IDeviceInfoService
	{
		public double GetStatusBarHeight()
		{
			return UIApplication.SharedApplication.StatusBarFrame.Height;
		}
	}
}
