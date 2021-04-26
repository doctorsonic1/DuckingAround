using DuckingAround.Items.Weapons.Duckies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Projectiles.Duckies
{
	public class MeteorDuckProjectile : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 2;
			projectile.hide = true;
			//projectile.aiStyle = 2;
			projectile.knockBack = 1f;
			projectile.damage = 0;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else {
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/DuckDeath"), projectile.position);
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
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
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/DuckDeath"), (int)projectile.position.X, (int)projectile.position.Y);
			if (projectile.owner == Main.myPlayer)
			{
				int item =
				Main.rand.NextBool(10)
					? Item.NewItem(projectile.getRect(), ModContent.ItemType<MeteorDucky>())
					: 0;
				if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0)
				{
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
				}
			}
		}
		public int TargetWhoAmI
		{
			get => (int)projectile.ai[1];
			set => projectile.ai[1] = value;
		}
		public override void AI()
		{
            projectile.rotation += (float)projectile.direction * 0.2f;
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 30f)
			{
				projectile.ai[0] = 15f;
				projectile.velocity.Y = projectile.velocity.Y + 1.5f;
			}
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
		private const int BufferSize = 5;
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
	}
}