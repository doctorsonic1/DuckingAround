using Terraria;
using Terraria.ModLoader;


namespace DuckingAround.Commands
{
    public class KillEverything : ModCommand
	{
		public override CommandType Type
		=> CommandType.Chat;

		public override string Command
		=> "killall";

		public override string Description
		=> "Kills everything except the player.";
		public override void Action(CommandCaller caller, string input, string[] args)
		{
			for (int k = 0; k < 200; k++)
			{
				NPC npc = Main.npc[k];
				if (!npc.active)
				{
					continue;
				}
				npc.life = 0;
				npc.netUpdate = true;
			}
		}
	}
}