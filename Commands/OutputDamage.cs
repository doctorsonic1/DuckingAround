using System;
using Terraria;
using Terraria.ModLoader;


namespace DuckingAround.Commands
{
    public class DamageTaken : ModCommand
	{
		public override CommandType Type
		=> CommandType.Chat;
		
		public override string Command
		=> "damage";
		
		public override string Description
		=> "Outputs damage taken by player since loading world.";
		public override void Action(CommandCaller caller, string input, string[] args)
		{
			Player player = Main.LocalPlayer;
			DuckingPlayer modPlayer = Main.LocalPlayer.GetModPlayer<DuckingPlayer>();
			string takenDamage = Convert.ToString(modPlayer.damageTaken);
			Main.NewText(takenDamage, 40, 80, 100);
		}
	}
}