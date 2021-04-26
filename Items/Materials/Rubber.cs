using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Materials
{
	public class Rubber : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Rubber");
			Tooltip.SetDefault("It's not that kind of rubber...");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 999;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
		}
	}
}