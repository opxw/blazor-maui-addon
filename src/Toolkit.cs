using CommunityToolkit.Maui.Core;

namespace Opx.Blazor.Maui.Tools
{
	public static class Toolkit
	{
		public static async Task Toast(string msg, double fontSize = 12, ToastDuration duration = ToastDuration.Short,
			CancellationToken cancellation = default)
		{
			var toast = CommunityToolkit.Maui.Alerts.Toast.Make(msg, duration, fontSize);
			await toast.Show(cancellation);
		}

		public static async Task SnackBar(string msg, string actionText = "OK",
			int duration = 2, Func<Task>? action = null, SnackbarOptions options = null, CancellationToken cancellation = default)
		{
			var snackbar = CommunityToolkit.Maui.Alerts.Snackbar.Make(msg, async() => { action(); }, actionText, TimeSpan.FromSeconds(duration), 
				options);
			await snackbar.Show(cancellation);
		}
	}
}