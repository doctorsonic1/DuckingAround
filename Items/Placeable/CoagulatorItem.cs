using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Placeable
{
	public class CoagulatorItem : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coagulator");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150000;
			item.createTile = mod.TileType("Coagulator");
		}
	}
}