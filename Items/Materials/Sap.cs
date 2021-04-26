using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Materials
{
	public class Sap : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Sap");
			Tooltip.SetDefault("Can be combined with acid at a coagulator.");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 23;
			item.maxStack = 999;
			item.rare = ItemRarityID.Blue;
		}
	}
}