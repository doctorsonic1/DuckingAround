using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.EnemyEggs
{
	public class FloatyEgg : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Floaty Gross Egg");
			Tooltip.SetDefault("Used with the enemy spawner.");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.rare = ItemRarityID.Purple;
		}
	}
}