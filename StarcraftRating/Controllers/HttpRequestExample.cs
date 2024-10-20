namespace StarcraftRating.Controllers
{
	public class HttpRequestExample
	{
		private static readonly HttpClient client = new HttpClient();

		public static async Task<string> GetRequest(string url)
		{
			try
			{
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				return responseBody;
			}
			catch (HttpRequestException e)
			{
				return $"Error: {e.Message}";
			}
		}
	}
}
