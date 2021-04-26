using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Projectiles.Yoyos
{
    public class SimpleProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 8000f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 23f;
		}
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.scale = 1f;
			projectile.aiStyle = 99;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.life -= 2000000000;
        }
    }
}
