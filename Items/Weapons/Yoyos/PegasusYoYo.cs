using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DuckingAround.Projectiles.Yoyos;

namespace DuckingAround.Items.Weapons.Yoyos
{
    public class PegasusYoYo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pegasus");
            Tooltip.SetDefault("Soar across the skies with no limits...");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 168;
            item.melee = true;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.channel = true;
            item.knockBack = 2f;
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = -12;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
            item.crit = 23;
            item.shoot = ModContent.ProjectileType<PegasusProj>();
        }
    }
}