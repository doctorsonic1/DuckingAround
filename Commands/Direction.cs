using Terraria.ModLoader;
using System;
using Terraria;

namespace DuckingAround.Commands
{
	public class Direction : ModCommand
	{
		public override CommandType Type
		=> CommandType.Chat;
		
		public override string Command
		=> "direction";
		
		public override string Description
		=> "Resets state of spawnOre for killing Psion.";
		public override void Action(CommandCaller caller, string input, string[] args)
		{
			Player player = Main.LocalPlayer;
			Main.NewText(Convert.ToString(player.direction), 20, 20, 20);     //left is -1, right is 1
		}
	}
}