using DuckingAround.Projectiles.Duckies;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Weapons.Duckies
{
	public class RubberDucky : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Rubber Ducky");
			Tooltip.SetDefault("Just your average tub toy.");
		}
		public override void SetDefaults()
		{
			item.damage = 20;
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
			item.shoot = ModContent.ProjectileType<RubberDuckProjectile>();
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Duck);
            recipe.AddIngredient(mod.GetItem("Rubber"));
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
	}
}