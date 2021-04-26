using Terraria.ModLoader;
using System;
using Terraria;

namespace DuckingAround.Commands
{
	public class DownedPsion : ModCommand
	{
		public override CommandType Type
		=> CommandType.Chat;
		
		public override string Command
		=> "psion";
		
		public override string Description
		=> "Resets state of spawnOre for killing Psion.";
		public override void Action(CommandCaller caller, string input, string[] args)
		{
			Main.NewText(Convert.ToString(DuckingWorld.downedPsion), 20, 20, 20);
		}
	}
}