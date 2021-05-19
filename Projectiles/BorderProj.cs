using Terraria.ModLoader;

namespace DuckingAround.Projectiles
{
    public class BorderProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.rotation = 0f;
        }
        public override void AI()
        {
            projectile.rotation += 0.1f;
        }
    }
}