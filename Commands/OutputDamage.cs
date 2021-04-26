using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using DuckingAround.Items.Placeable;
using DuckingAround;


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