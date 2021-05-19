using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace DuckingAround.Items.SpawnItems
{
    public class EnemySpawnerSpawn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enemy Spawner");
			Tooltip.SetDefault("Summons an NPC that spawns enemies near the player.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}
		public override void SetDefaults()
		{
			item.maxStack = 30;
			item.consumable = false;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Purple;
			item.useAnimation = 1;
			item.useTime = 1;
			item.useStyle = ItemUseStyleID.HoldingUp;
		}

		public override bool UseItem(Player player)
		{
			if (NPC.AnyNPCs(ModContent.NPCType<NPCs.Towns.EnemySpawnerNPC.EnemySpawnerNPC>()))
			{
				Main.npc[NPC.FindFirstNPC(ModContent.NPCType<NPCs.Towns.EnemySpawnerNPC.EnemySpawnerNPC>())].position.X = player.position.X;
				Main.npc[NPC.FindFirstNPC(ModContent.NPCType<NPCs.Towns.EnemySpawnerNPC.EnemySpawnerNPC>())].position.Y = player.position.Y - 64;
				return false;
			}
            else
			{
				DuckingAround.HandleNPC(ModContent.NPCType<NPCs.Towns.EnemySpawnerNPC.EnemySpawnerNPC>());
				return true;
			}
		}
	}
}
