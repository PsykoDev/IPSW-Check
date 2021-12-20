using System;
using System.Net.Http;

namespace ipsw.Data.Request
{
	public class Request
	{
		internal static async Task<string> Http()
        {
			var baseAddress = new Uri("https://api.ipsw.me/v4/");

				using (var httpClient = new HttpClient { BaseAddress = baseAddress })
				{

					httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
					using (var response = await httpClient.GetAsync($"device/{Program.Identifier}?ipsw"))
					{

						string responseData = await response.Content.ReadAsStringAsync();
						return responseData;
					}
				}
		}

		internal static async Task<string> Find()
        {
			var baseAddress = new Uri("https://api.ipsw.me/v4/");
			using (var httpClient = new HttpClient { BaseAddress = baseAddress })
			{

				httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

				using (var response = await httpClient.GetAsync("devices"))
				{

					string responseData = await response.Content.ReadAsStringAsync();
					return responseData;
				}
			}
		}
    }
}

