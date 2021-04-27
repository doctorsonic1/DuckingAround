using DuckingAround.Mounts;
using DuckingAround.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Mounts
{
    public class DuckEgg : ModItem
	{
		public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("This is a modded mount.");
		}

		public override void SetDefaults()
        {
			item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 30000;
			item.rare = ItemRarityID.Green;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Mount/GetOnDuck");
			item.noMelee = true;
			item.mountType = ModContent.MountType<Duck>();
		}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PlatyrhynchiumBar"), 10);
			recipe.AddTile(ModContent.TileType<HephaestusForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}