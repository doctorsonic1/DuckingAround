using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DuckingAround.Projectiles.Yoyos.Orbiting.Destiny
{
    public class DestinyOrbiting3 : ModProjectile
    {
        public bool yoyosSpawned;
        public int Counter;
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            Projectile projectile = Main.projectile[(int)this.projectile.localAI[0]];
            ++this.projectile.timeLeft;
            this.projectile.rotation += 0.5f;
            if (!projectile.active || projectile.type != ModContent.ProjectileType<DestinyProj>() || projectile.owner != this.projectile.owner)
            {
                this.projectile.Kill();
            }
            else
            {
                if (this.projectile.owner == Main.myPlayer)
                {
                    float x = 36f;
                    this.projectile.position = projectile.Center + new Vector2(x, 0.0f).RotatedBy((double)this.projectile.ai[1]);
                    this.projectile.position.X -= (float)(this.projectile.width / 2);
                    this.projectile.position.Y -= (float)(this.projectile.height / 2);
                    this.projectile.ai[1] += 0.1570796f;
                    if ((double)this.projectile.ai[1] > 3.14159274101257)
                    {
                        this.projectile.ai[1] -= 6.283185f;
                        this.projectile.netUpdate = true;
                    }
                }
                this.projectile.damage = projectile.damage;
                this.projectile.knockBack = projectile.knockBack;
                if (++Counter <= 60)
                    return;
                Counter = 0;
            }
        }
    }
}