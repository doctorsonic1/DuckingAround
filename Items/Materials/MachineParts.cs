using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Materials
{
	public class MachineParts : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Machine Parts");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 999;
			item.rare = ItemRarityID.Blue;
		}
	}
}