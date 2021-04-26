using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Accessories
{
	public class Hoverboard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Floaty Boy");
			Tooltip.SetDefault("You can float and stuff.");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 24;
			item.accessory = true;
			item.rare = ItemRarityID.Blue;
			item.wingSlot = 22;
		}
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.wingTime = 100;
			player.carpet = true;
		}
        public override bool CanEquipAccessory(Player player, int slot)
        {
			if (NPC.downedMoonlord && Main.hardMode)
			{
				return true;
			}
			else
			{
				return false;
			}
        }
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = .86f;
			maxAscentMultiplier = 2f;
			constantAscend = 0.035f;
		}
		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 25f;
			acceleration *= 6.5f;
		}
	}
}