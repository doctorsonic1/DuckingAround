using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Weapons
{
    public class EndlessBulletPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Platyrhynchium Bullet Pouch");
            Tooltip.SetDefault("Unlimited power...");
        }
        public override void SetDefaults()
        {
            item.damage = 35;
            item.ranged = true;
            item.width = 26;
            item.height = 34;
            item.maxStack = 1;
            item.consumable = false;
            item.knockBack = 0f;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.shoot = mod.ProjectileType("PlatyrhynchiumBullet");
            item.shootSpeed = 23f;
            item.ammo = AmmoID.Bullet;
        }
        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("PlatyrhynchiumBullet"), 3996);
            recipe.AddIngredient(mod.GetItem("PlatyrhynchiumBar"), 15);
			recipe.AddIngredient(ItemID.EndlessMusketPouch, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 25);
            recipe.AddIngredient(ItemID.SoulofLight, 25);
            recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.AddTile(null, "HephaestusForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}