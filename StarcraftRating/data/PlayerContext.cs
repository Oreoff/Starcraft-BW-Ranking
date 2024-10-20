using Microsoft.EntityFrameworkCore;
using StarcraftRating.Models;
using System;

namespace StarcraftRating.data
{
	public class PlayerContext:DbContext
	{
		public DbSet<Player> Players { get; set; }
		public PlayerContext(DbContextOptions<PlayerContext> options) : base(options) { }
		
	}

}
