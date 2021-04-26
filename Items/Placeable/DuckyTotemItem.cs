using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace DuckingAround.Items.Placeable
{
	public class DuckyTotemItem : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ducky Totem");
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
			item.createTile = mod.TileType("DuckyTotem");
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.VortexMonolith, 1);
			recipe.AddIngredient(ItemID.NebulaMonolith, 1);
			recipe.AddIngredient(ItemID.StardustMonolith, 1);
			recipe.AddIngredient(ItemID.SolarMonolith, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddIngredient(mod.GetItem("PlatyrhynchiumBar"), 15);
            recipe.AddIngredient(mod.GetItem("IronDucky"), 500);
            recipe.AddIngredient(mod.GetItem("RubberDucky"), 500);
            recipe.AddIngredient(mod.GetItem("MeteorDucky"), 500);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}