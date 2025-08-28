namespace Opx.Blazor.Maui.Tools
{
	public partial class AppStateServiceBase
	{
		public event Action OnStateMustChanged;
		
		private bool _mainAppLoaded = false;

		public bool IsMainAppLoaded
		{
			get => _mainAppLoaded;
			set
			{
				_mainAppLoaded = value;
			}
		}

		public void StateMustChanged()
		{
			NotifyStateChanged();
		}

		private void NotifyStateChanged() => OnStateMustChanged?.Invoke(); 
	}
}