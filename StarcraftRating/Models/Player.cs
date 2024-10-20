using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarcraftRating.Models
{
	public class Player
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int rank { get; set; }
		public int last_rank { get; set; }
		public int gateway_id { get; set; }
		public int points { get; set; }
		public int wins { get; set; }
		public int loses { get; set; }
		public int dissconects { get; set; }
		public string? toon { get; set; }
		public string? battletag { get; set; }
		public string? avatar { get; set; }
		public string? feature_stat { get; set; }
		public int rating { get; set; }
		public int bucket { get; set; }
	}
}
