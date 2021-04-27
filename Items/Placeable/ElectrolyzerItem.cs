using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Placeable
{
	public class ElectrolyzerItem : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electrolyzer");
        }

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150000;
			item.createTile = ModContent.TileType<Tiles.Electrolyzer>();
		}
	}
}