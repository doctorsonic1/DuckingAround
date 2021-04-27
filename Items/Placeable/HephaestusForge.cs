using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Placeable
{
    public class HephaestusForge : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Powers of an ancient Greek god have been channeled into this forge...");
            DisplayName.SetDefault("Hephaestus' Forge");
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
			item.createTile = ModContent.TileType<Tiles.HephaestusForge>();
		}
	}
}