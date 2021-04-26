using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.EnemyEggs
{
	public class PixieEgg : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pixie Egg");
			Tooltip.SetDefault("Used with the enemy spawner.");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = 100;
			item.rare = ItemRarityID.Purple;
		}
	}
}