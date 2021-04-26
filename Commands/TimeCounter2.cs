using System;
using Terraria;
using Terraria.ModLoader;


namespace DuckingAround.Commands
{
	public class TimeCounter2 : ModCommand
	{
		public override CommandType Type
		=> CommandType.Chat;
		
		public override string Command
		=> "time";
		
		public override string Description
		=> "TimeCounter2";
		public override void Action(CommandCaller caller, string input, string[] args)
		{
			DuckingPlayer modPlayer = Main.LocalPlayer.GetModPlayer<DuckingPlayer>();
			int timeCtr = modPlayer.timeCounter2;
			Main.NewText(Convert.ToString(timeCtr), 40, 80, 100);
		}
	}
}