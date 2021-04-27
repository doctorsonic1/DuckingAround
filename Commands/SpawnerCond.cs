using System;
using Terraria;
using Terraria.ModLoader;


namespace DuckingAround.Commands
{
    public class SpawnerCond : ModCommand
	{
		public override CommandType Type
		=> CommandType.Chat;
		
		public override string Command
		=> "spawnercond";
		
		public override string Description
		=> "Returns state of spawner and enemy count.";
		public override void Action(CommandCaller caller, string input, string[] args)
		{
			string goop = Convert.ToString(DuckingWorld.spawnerActive);
			string goop2 = Convert.ToString(NPCs.EnemySpawnerNPC.enemyCount);
			Main.NewText(goop , 40, 80, 100);
			Main.NewText(goop2, 40, 80, 100);
		}
	}
}