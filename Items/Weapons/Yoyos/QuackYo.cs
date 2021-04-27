using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DuckingAround.Projectiles.Yoyos;

namespace DuckingAround.Items.Weapons.Yoyos
{
    public class QuackYo : ModItem
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
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
            item.crit = 23;
            item.buffType = 8;
            item.shoot = ModContent.ProjectileType<QuackyoProj>();
        }
    }
}