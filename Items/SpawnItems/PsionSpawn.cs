using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace DuckingAround.Items.SpawnItems
{
    public class PsionSpawn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blight");
			Tooltip.SetDefault("Summons an ancient foe.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}
		public override void SetDefaults()
		{
			item.maxStack = 30;
			item.consumable = true;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Purple;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
		}

		public override bool UseItem(Player player)
		{
			if (!Main.dayTime)
			{
				NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Psion"));
				return true;
			}
			else
			{
				return false;
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarOre, 20);
			recipe.AddIngredient(ItemID.SpectreBar, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
