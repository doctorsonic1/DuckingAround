using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Weapons
{
    public class PlatyrhynchiumBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platyrhynchium Bullet");
            Tooltip.SetDefault("Made from other-wordly metals...");
        }
        public override void SetDefaults()
        {
            item.damage = 35;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 9999;
            item.consumable = true;
            item.knockBack = 0f;
            item.value = 10;
            item.rare = ItemRarityID.Green;
            item.shoot = mod.ProjectileType("PlatyrhynchiumBullet");
            item.shootSpeed = 23f;
            item.ammo = item.type;
        }
        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("PlatyrhynchiumBar"), 1);
            recipe.AddIngredient(ItemID.LunarBar, 1);
            recipe.AddTile(null, "HephaestusForge");
            recipe.SetResult(this, 333);
            recipe.AddRecipe();
        }
    }
}