using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace DuckingAround.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class Hoverboard : ModItem
	{
		public bool flying;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You can float and stuff.");
		}
		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 32;
			item.accessory = true;
			item.rare = ItemRarityID.Blue;
			item.useTime = 120;
		}
        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax += 1200;
		}
        public override bool WingUpdate(Player player, bool inUse)
		{
			if (inUse)
			{
				Dust.NewDust(player.Center + new Vector2(0f, 5f), player.width, player.height, DustID.Fire, 0f, 0f, 150, default(Color), 1.5f);
				player.armorEffectDrawShadow = true;
				flying = true;
			}
			if (!inUse)
			{
				flying = false;
				for (int i = 3; i < 8 + player.extraAccessorySlots; i++)
				{
					Item item = player.armor[i];
					if (item.type == ModContent.ItemType<Hoverboard>())
					{
						player.hideVisual[i] = true;
					}
				}
			}
			return false;
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
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, 
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			maxCanAscendMultiplier = .86f;
			constantAscend = 0.035f;
			ascentWhenRising = 0.15f;
			maxAscentMultiplier = 2f;
			if (player.controlDown)
			{
				player.velocity.Y = 0;
			}
		}
		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 25f;
			acceleration *= 6.5f;
		}
	}
}