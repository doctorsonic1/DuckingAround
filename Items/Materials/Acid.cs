using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Materials
{
    public class Acid : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Acid");
			Tooltip.SetDefault("Can be combined with sap at a coagulator.");
			ItemID.Sets.ItemNoGravity[item.type] = false;
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