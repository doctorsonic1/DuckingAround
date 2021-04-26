using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace DuckingAround.Items.Weapons.Yoyos
{
    public class MuckAround : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duck You");
            Tooltip.SetDefault("Read the name.");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 600;
            item.melee = true;
            item.ranged = false;
            item.summon = false;
            item.thrown = false;
            item.magic = false;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.channel = true;
            item.knockBack = 2f;
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("QuackyoProj");
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
            item.crit = 23;
            item.buffType = 8;
        }
        public override void HoldItem(Terraria.Player player) => player.stringColor = 5;
        /*
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 45f * 0.0174f;
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / 40f;
            double offsetAngle;
            int i;
            for (i = 0; i < 4; i++)
            {
                offsetAngle = startAngle + deltaAngle * i;
                if (i == 0)
                {
                    Projectile.NewProjectile(player.position.X, player.position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("DestinyProjCopy"), damage, knockBack, item.owner);
                }
                else if (i == 1)
                {
                    Projectile.NewProjectile(player.position.X, player.position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("PegasusProjCopy"), damage, knockBack, item.owner);
                }
                else if (i == 2)
                {
                    Projectile.NewProjectile(player.position.X, player.position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("BountyHunterProjCopy"), damage, knockBack, item.owner);
                }
                else if (i == 3)
                {
                    Projectile.NewProjectile(player.position.X, player.position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("FreedomProjCopy"), damage, knockBack, item.owner);
                }
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }*/
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("PegasusYoYo"));
            recipe.AddIngredient(mod.GetItem("DestinyYoYo"));
            recipe.AddIngredient(mod.GetItem("FreedomYoYo"));
            recipe.AddIngredient(mod.GetItem("BountyHunterYoYo"));
            recipe.AddIngredient(mod.GetItem("DestinyYoYo"));
            recipe.AddIngredient(mod.GetItem("PlatyrhynchiumBar"), 7);
            recipe.AddIngredient(ItemID.Terrarian, 1);
            recipe.AddIngredient(ItemID.YoyoBag, 1);
            recipe.AddTile(null, "HephaestusForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}