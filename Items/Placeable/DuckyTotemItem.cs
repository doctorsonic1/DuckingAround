using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace DuckingAround.Items.Placeable
{
	public class DuckyTotemItem : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ducky Totem");
        }

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 34;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150000;
			item.createTile = TileType<Tiles.DuckyTotem>();
		}
	}
}