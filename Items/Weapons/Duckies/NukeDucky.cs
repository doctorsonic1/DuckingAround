using DuckingAround.Projectiles.Duckies;
using DuckingAround.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Weapons.Duckies
{
	public class NukeDucky : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Explosive Ducky");
			Tooltip.SetDefault("Why would you do this?.");
		}
		public override void SetDefaults()
		{
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = false;
            item.value = 5000;
            item.rare = ItemRarityID.Green;
		}
	}
}