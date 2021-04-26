using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;


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
			if (NPC.AnyNPCs(ModContent.NPCType<NPCs.EnemySpawnerNPC>()))
			{
				Main.npc[NPC.FindFirstNPC(ModContent.NPCType<NPCs.EnemySpawnerNPC>())].position.X = player.position.X;
				Main.npc[NPC.FindFirstNPC(ModContent.NPCType<NPCs.EnemySpawnerNPC>())].position.Y = player.position.Y - 64;
				return false;
			}
            else
			{
				DuckingAround.HandleNPC(ModContent.NPCType<NPCs.EnemySpawnerNPC>());
				return true;
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 30);
			recipe.AddIngredient(ItemID.MythrilBar, 30);
			recipe.AddIngredient(ItemID.CobaltBar, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 30);
			recipe.AddIngredient(ItemID.OrichalcumBar, 30);
			recipe.AddIngredient(ItemID.PalladiumBar, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
