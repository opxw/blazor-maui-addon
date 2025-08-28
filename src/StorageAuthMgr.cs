using System.IdentityModel.Tokens.Jwt;

namespace Opx.Blazor.Maui.Tools
{
	public partial class StorageAuthMgr
	{
		public string BearerToken { get; set; } = string.Empty;

		public async Task SaveToLocalAsync(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentNullException(nameof(key));

			if (!string.IsNullOrWhiteSpace(BearerToken))
				await SecureStorage.SetAsync(key, BearerToken);
		}

		public async Task<string?> ReadFromLocalAsync(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentNullException(nameof(key));

			return await SecureStorage.GetAsync(key);
		}

		public async Task LoadFromLocalAsync(string key)
		{
			var token = await ReadFromLocalAsync(key);
			BearerToken = token;
		}

		public async Task RemoveFromLocalAsync(string key)
		{
			await Task.Delay(10);
			SecureStorage.Remove(key);
		}

		public JwtPayload GetPayload()
		{
			return GetPayload(BearerToken);
		}

		public JwtPayload GetPayload(string token)
		{
			if (string.IsNullOrWhiteSpace(token))
				throw new ArgumentNullException(nameof(token));

			var handler = new JwtSecurityTokenHandler();
			var jwt = handler.ReadJwtToken(token);

			return jwt.Payload;
		}

		public bool IsKeyExists => !string.IsNullOrWhiteSpace(BearerToken);
	}
}