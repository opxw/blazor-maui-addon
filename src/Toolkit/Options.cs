using CommunityToolkit.Maui.Core;

namespace Opx.Blazor.Maui.Tools.Toolkit
{
	public class BzToastOptions
	{
		public int FontSize { get; set; } = 14;
		public ToastDuration Duration { get; set; } = ToastDuration.Short;
	}

	public class BzSnackbarOptions
	{
		public SnackbarOptions Options { get; set; } = new()
		{
			CornerRadius = 0,
		};

		public string ActionText { get; set; } = "OK";
		public int Duration { get; set; } = 2;
	}
}