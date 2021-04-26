using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DuckingAround.NPCs;
using DuckingAround.Items;

namespace DuckingAround.Items.LootBags
{
	public class PsionBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Purple;
			item.expert = true;
		}
		public override bool CanRightClick()
		{
			return true;
		}
		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			player.QuickSpawnItem(ModContent.ItemType<Potions.ChugJug>(), Main.rand.Next(3) + 3);
			player.QuickSpawnItem(ModContent.ItemType<Mounts.DuckEgg>());
			player.QuickSpawnItem(ModContent.ItemType<Pets.DuckPet>());
			if (DuckingWorld.downedPsion == 1)
			{
				player.QuickSpawnItem(ModContent.ItemType<Placeable.PlatyrhynchiumOre>(), Main.rand.Next(87,108));
			}
		}
		public override int BossBagNPC => ModContent.NPCType<EyeDestruction>();
	}
}
