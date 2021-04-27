using DuckingAround.Projectiles.Duckies;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Weapons.Duckies
{
	public class Ducky : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Ducky");
			Tooltip.SetDefault("Quack.");
		}
		public override void SetDefaults()
		{
			item.damage = 12;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 18;
			item.useTime = 15;
			item.shootSpeed = 10f;
			item.knockBack = 6.5f;
			item.width = 32;
			item.height = 28;
			item.maxStack = 999;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/DuckQuack");
			item.scale = 1f;
			item.rare = ItemRarityID.Pink;
			item.value = Item.sellPrice(silver: 10);
			item.consumable = true;
			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true; 
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<DuckyProjectile>();
		}
	}
}