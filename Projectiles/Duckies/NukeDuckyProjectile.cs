using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace DuckingAround.Projectiles.Duckies
{
    public class NukeDuckyProjectile : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.hide = true;
			projectile.aiStyle = -1;
			projectile.knockBack = 1f;
			projectile.damage = 0;
			projectile.timeLeft = 180;
		}
		public override void Kill(int timeLeft)
		{
			Player owner = Main.player[projectile.owner];
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 158);
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 158);
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 158);
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			}
			for (int i = 0; i < 10; i++)
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 20, (float)Main.rand.Next(-8,8), (float)Main.rand.Next(-8,8), mod.ProjectileType("NukeDuckyExplosionProjectile"), 84, 10, projectile.owner, 0f, 400f);
			}
		}
		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
		{
			if (projectile.ai[0] == 1f)
			{
				int npcIndex = (int)projectile.ai[1];
				if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active)
				{
					if (Main.npc[npcIndex].behindTiles)
					{
						drawCacheProjsBehindNPCsAndTiles.Add(index);
					}
					else {
						drawCacheProjsBehindNPCs.Add(index);
					}
					return;
				}
			}
			drawCacheProjsBehindProjectiles.Add(index);
		}
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = height = 10;
			return true;
		}
		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
			{
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			return projHitbox.Intersects(targetHitbox);
		}
		public int TargetWhoAmI
		{
			get => (int)projectile.ai[1];
			set => projectile.ai[1] = value;
		}
		private const int BufferSize = 2;
		private Vector2[] positionBuffer = new Vector2[BufferSize];
		private int bufferTail = 0;
		private bool bufferFull;
		public override void PostAI()
		{
			positionBuffer[bufferTail] = projectile.position;
			bufferTail++;
			if (bufferTail >= BufferSize)
			{
				bufferFull = true;
				bufferTail = 0;
			}
			int dustAmount = bufferFull ? BufferSize : bufferTail;
			for (int i = 0; i < dustAmount; i++)
			{
				Dust dust =  Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 158);
			}
		}
		public float movementFactor
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}
        private const float maxTicks = 56.25f;
        private const int alphaReduction = 25;
		public override void AI()
        {
            if (projectile.alpha > 0)
            {
                projectile.alpha -= alphaReduction;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            if (projectile.ai[0] == 0f)
            {
                projectile.ai[1] += 1f;
                if (projectile.ai[1] >= maxTicks)
                {
                    float velXmult = 0.98f;
                    float velYmult = 0.35f;
                    projectile.ai[1] = maxTicks;
                    projectile.velocity.X = projectile.velocity.X * velXmult;
                    projectile.velocity.Y = projectile.velocity.Y + velYmult;
                }
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            }
            if (projectile.ai[0] == 1f)
            {
                projectile.ignoreWater = true;
                projectile.tileCollide = false;
                int aiFactor = 100;
                bool killProj = false;
                bool hitEffect = true;
                projectile.localAI[0] += 1f;
                hitEffect = projectile.localAI[0] % 30f == 0f;
                int projTargetIndex = (int)projectile.ai[1];
                if (projectile.localAI[0] >= (float)(60 * aiFactor))
                {
                    killProj = true;
                }
                else if (projTargetIndex < 0 || projTargetIndex >= 200)
                {
                    killProj = true;
                }
                else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
                {
                    projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
                    projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
                    if (hitEffect)
                    {
                        Main.npc[projTargetIndex].HitEffect(0, 1.0);
                    }
                }
                else
                {
                    killProj = true;
                }

                if (killProj)
                {
                    projectile.Kill();
                }
            }
        }
	}
}