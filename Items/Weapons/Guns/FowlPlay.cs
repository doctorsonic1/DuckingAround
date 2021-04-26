using Microsoft.Xna.Framework;
using DuckingAround.Items.Weapons.Duckies;
using DuckingAround.Items.Materials;
using DuckingAround.Projectiles.Duckies;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Weapons.Guns
{
	public class FowlPlay : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Fowl Play");
			Tooltip.SetDefault("Shoots supersonic duck rockets that split on contact.");
		}

		public override void SetDefaults()
		{
			item.damage = 269;
			item.ranged = true;
			item.width = 31;
			item.height = 25;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4f;
			item.scale = 1f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/FowlPlayShoot");
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.useAmmo = ModContent.ItemType<NukeDuckyItem>();
			item.shoot = ModContent.ProjectileType<NukeDuckyProjectile>();
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<PlatyrhynchiumBar>(), 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
		{
			mult *= player.bulletDamage;
		}

		public override Vector2? HoldoutOffset()
		{
			return Vector2.Zero;
		}
	}
}