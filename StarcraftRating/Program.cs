using System;
using System.Net.Http;
using System.Threading.Tasks;

HttpClient client = new HttpClient();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => HttpRequestExample.GetRequest("http://127.0.0.1:57055/web-api/v1/leaderboard-by-friends/12966"));
app.Run();
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