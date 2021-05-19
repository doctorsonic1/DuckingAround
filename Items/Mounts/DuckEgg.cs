using DuckingAround.Mounts;
using DuckingAround.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Mounts
{
    public class DuckEgg : ModItem
	{
		public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("It's a rideable duck.");
		}

		public override void SetDefaults()
        {
			item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 30000;
			item.rare = ItemRarityID.Green;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Mount/GetOnDuck");
			item.noMelee = true;
			item.mountType = ModContent.MountType<Duck>();
		}
	}
}