using DuckingAround.Projectiles.Duckies;
using DuckingAround.Items.Weapons;
using DuckingAround.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Weapons.Duckies
{
	public class NukeDuckyItem : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Ducky Nuke");
			Tooltip.SetDefault("Make a big quack in the ground.");
		}
		public override void SetDefaults()
		{
			item.shootSpeed = 25f;
			item.knockBack = 6.5f;
			item.width = 32;
			item.consumable = true;
			item.height = 28;
			item.maxStack = 3996;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/DuckQuack");
			item.scale = 1f;
			item.rare = ItemRarityID.Pink;
            item.ammo = item.type;
			item.shoot = ModContent.ProjectileType<NukeDuckyProjectile>();
		}
	}
}