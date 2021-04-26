using Terraria.ModLoader;


namespace DuckingAround.Commands
{
	public class ResetSpawnOre : ModCommand
	{
		public override CommandType Type
		=> CommandType.Chat;
		
		public override string Command
		=> "spawnore";
		
		public override string Description
		=> "Resets state of spawnOre for killing Psion.";
		public override void Action(CommandCaller caller, string input, string[] args)
		{
			DuckingWorld.downedPsion = 0;
		}
	}
}