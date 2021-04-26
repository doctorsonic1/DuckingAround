using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace DuckingAround
{
	[Label("Settings")]
	public class ConfigClient : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		[Header("Chug Jug Sound")]
		[Label("[i:300] Enables or disables Fortnite sound while Chug Jug is active.")]
		[DefaultValue(false)] public bool ChugJugSound { get; set; }
		public static Vector2 EnemySpawnSpot { get; set; }
		public static bool spawnerExists { get; set; }
		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
	}
}