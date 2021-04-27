using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;

namespace DuckingAround.Commands
{
    public class SpawnZombie : ModCommand
	{
		public override CommandType Type
		=> CommandType.Chat;
		
		public override string Command
		=> "spawnzombie";
		
		public override string Description
		=> "Resets state of spawnOre for killing Psion.";
		public override void Action(CommandCaller caller, string input, string[] args)
		{
			Player player = Main.player[Player.FindClosest(new Vector2(Main.spawnTileX, Main.spawnTileY), Player.defaultWidth, Player.defaultHeight)];
			NPC.SpawnOnPlayer(player.whoAmI, DuckingWorld.enemyID);
			DuckingNetcode.SyncWorld();
		}
	}
}