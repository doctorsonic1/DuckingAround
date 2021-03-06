using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DuckingAround.NPCs.Bosses;

namespace DuckingAround.Items.SpawnItems
{
    public class PsionSpawn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blight");
			Tooltip.SetDefault("Summons an ancient foe.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}
		public override void SetDefaults()
		{
			item.maxStack = 30;
			item.consumable = true;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Purple;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
		}

		public override bool UseItem(Player player)
		{
			if (!Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<EyeDestruction>()))
			{
				NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.EyeDestruction>());
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
