using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Potions
{
	public class ChugJug : ModItem
	{
		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Chug Jug");
			Tooltip.SetDefault("Your adolescence attracts enemies to your location.");
		}
		public override void SetDefaults()
        {
			item.width = 20;
			item.height = 26;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.maxStack = 30;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.value = Item.buyPrice(gold: 1);
		}
		public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("ChugJug"), 6000);
            return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddIngredient(ItemID.IronPickaxe);
			recipe.AddIngredient(ItemID.Wood);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}