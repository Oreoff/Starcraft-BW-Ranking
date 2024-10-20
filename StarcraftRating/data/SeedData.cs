using StarcraftRating.Models;
using System.Text.Json;
using StarcraftRating.Controllers;
namespace StarcraftRating.data
{
	public class SeedData
	{
		private readonly PlayerContext _context;
		public SeedData(PlayerContext context)
		{
			_context = context;
		}

		public async Task AddPlayersAsync()
		{
			string json = await HttpRequestExample.GetRequest("http://127.0.0.1:64495/web-api/v1/leaderboard/12966?offset=0&length=25");
			var jsonDoc = JsonDocument.Parse(json);
			var rows = jsonDoc.RootElement.GetProperty("rows");
			List<Player> players = new List<Player>();

			foreach (var row in rows.EnumerateArray())
			{
				players.Add(new Player
				{
					rank = row[0].GetInt32(),
					last_rank = row[1].GetInt32(),
					gateway_id = row[2].GetInt32(),
					points = row[3].GetInt32(),
					wins = row[4].GetInt32(),
					loses = row[5].GetInt32(),
					dissconects = row[6].GetInt32(),
					toon = row[7].GetString(),
					battletag = row[8].GetString(),
					avatar = row[9].GetString(),
					feature_stat = row[10].GetString(),
					rating = row[11].GetInt32(),
					bucket = row[12].GetInt32(),
				});
			}
			await _context.Players.AddRangeAsync(players);
			await _context.SaveChangesAsync();
		}
	}
}
