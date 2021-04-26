using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Projectiles
{
	public class Destructor : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Destructor Projectile");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}
		public override void SetDefaults()
		{
			projectile.width = 3;
			projectile.height = 3;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.penetrate = 1;
            projectile.scale = 2f;
			projectile.aiStyle = 2;
			projectile.timeLeft = 240;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 120;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
		}
		public override void AI()
		{
			Main.tile[(int)projectile.position.X / 16, (int)projectile.position.Y / 16].ClearTile();
			projectile.velocity.Y -= 0.0375f;
			projectile.timeLeft--;
		}
        public override void Kill(int timeLeft)
		{
			Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Electric);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Electric);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Electric);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Electric);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Electric);
		}
    }
}