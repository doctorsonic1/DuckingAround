using Terraria;
using Terraria.ModLoader;

namespace DuckingAround.NPCs
{
    public class DuckingAroundGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            maxSpawns = 40;
        }
        public override bool CheckDead(NPC npc)
        {
            EnemySpawnerNPC.enemyCount -= 1;
            return true;
        }
    }
}