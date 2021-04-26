using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Materials
{
	public class PlatyrhynchiumBar : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Platyrhynchium Bar");
			Tooltip.SetDefault("This is a modded item.");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = 70000;
			item.rare = ItemRarityID.Blue;
		}
	}
}