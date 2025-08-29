using FastEnumUtility;

namespace Opx.Blazor.Maui.Tools.Toolkit
{
	public enum SnackbarStyle
	{
		[Label("")]
		Default,
		
		[Label("#2980B9")]
		Primary,
		
		[Label("#D35400")]
		Warning,
		
		[Label("#C0392B")]
		Danger,

		[Label("#16A085")]
		Success,

		[Label("#2C3E50")]
		Darken,
	}
}