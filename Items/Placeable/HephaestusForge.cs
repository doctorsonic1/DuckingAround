using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace DuckingAround.Items.Placeable
{
	public class HephaestusForge : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Powers of an ancient Greek god have been channeled into this forge...");
            DisplayName.SetDefault("Hephaestus' Forge");
        }

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 34;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150000;
			item.createTile = mod.TileType("HephaestusForge");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteForge, 1);
			recipe.AddIngredient(ItemID.MythrilAnvil, 1);
			recipe.AddIngredient(ItemID.CrystalBall, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.AddIngredient(mod.GetItem("PlatyrhynchiumOre"), 35);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumForge, 1);
			recipe.AddIngredient(ItemID.OrichalcumAnvil, 1);
			recipe.AddIngredient(ItemID.CrystalBall, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.AddIngredient(mod.GetItem("PlatyrhynchiumOre"), 35);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}