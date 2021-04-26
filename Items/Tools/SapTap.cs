using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DuckingAround.Items.Tools
{
	public class SapTap : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sap tap");
			Tooltip.SetDefault("Tap sap from a tree.");
		}

		public override void SetDefaults()
		{
			item.melee = true;
			item.width = 31;
			item.height = 30;
			item.useTime = 15;
			item.useAnimation = 15;
			item.rare = ItemRarityID.Red;
			item.autoReuse = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
		}
		public override bool CanUseItem(Player player)
		{
			bool returnVal;
			int i = (int)Main.MouseWorld.X / 16;
			int j = (int)Main.MouseWorld.Y / 16;
			int type;
			if (WorldGen.InWorld(i, j))
			{
				type = Framing.GetTileSafely(i, j).type;
				if (type == TileID.Trees && DuckingAround.PlayerFromTile(player, i, j))
				{
					returnVal = true;
				}
				else
				{
					returnVal = false;
				}
			}
			else
			{
				returnVal = false;
			}
			return returnVal;
		}
        public override bool UseItem(Player player)
        {
			if (Main.rand.Next(0, 10) == 5)
			{
				player.QuickSpawnItem(ModContent.ItemType<Items.Materials.Sap>());
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SapTapGlug"));
			}
			else
			{
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SapTapTap"));
			}
			return true;
		}
        public override Vector2? HoldoutOrigin()
        {
			return new Vector2(-10, 0);
        }
    }
}
