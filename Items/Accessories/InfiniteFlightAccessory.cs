using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Accessories
{
	public class InfiniteFlightAccessory : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fedora of Flight");
			Tooltip.SetDefault("Allows infinite flight.");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 24;
			item.accessory = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(gold: 1);
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			DuckingPlayer modPlayer = Main.LocalPlayer.GetModPlayer<DuckingPlayer>();
			player.accRunSpeed = 6f;
			player.moveSpeed += 0.05f;
			modPlayer.infiniteFlight = true;
		}
	}
}