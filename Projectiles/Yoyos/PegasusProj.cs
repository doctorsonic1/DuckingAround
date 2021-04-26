using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DuckingAround.Projectiles.Yoyos
{
    public class PegasusProj : ModProjectile
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
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.scale = 1f;
			projectile.penetrate = -1;
			projectile.tileCollide = true;
        }
        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {

            Player owner = Main.player[projectile.owner];
            int rand = Main.rand.Next(4);
            if (rand == 1)
            {
                n.AddBuff(BuffID.Ichor, 30 * 60);
            }
        }
		public override bool PreAI()
		{
			Main.player[Main.myPlayer].yoyoString = false;
			return true;
		}
		public override void AI()
		{
			Lighting.AddLight(projectile.position, 0.85f, 0.85f, 0.85f);
			bool flag1 = false;
			bool flag2 = false;
			if (projectile.owner == Main.myPlayer)
			{
				++projectile.localAI[0];
				if (flag1)
				projectile.localAI[0] += (float) Main.rand.Next(10, 31) * 0.1f;
				float num1 = projectile.localAI[0] / 60f / (float) ((1.0 + (double) Main.player[Main.myPlayer].meleeSpeed) / 2.0);
				float num2 = ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type];
				if ((double) num2 != -1.0 && (double) num1 > (double) num2)
				projectile.ai[0] = -1f;
			}
			if (Main.player[Main.myPlayer].dead)
			{
				projectile.Kill();
			}
			else
			{
				if (!flag2 && !flag1)
				{
					Main.player[Main.myPlayer].heldProj = projectile.whoAmI;
					Main.player[Main.myPlayer].itemAnimation = 2;
					Main.player[Main.myPlayer].itemTime = 2;
					if ((double) projectile.position.X + (double) (projectile.width / 2) > (double) Main.player[Main.myPlayer].position.X + (double) (Main.player[Main.myPlayer].width / 2))
					{
						Main.player[Main.myPlayer].ChangeDir(1);
						projectile.direction = 1;
					}
					else
					{
						Main.player[Main.myPlayer].ChangeDir(-1);
						projectile.direction = -1;
					}
				}
				projectile.timeLeft = 6;
				float num1 = ProjectileID.Sets.YoyosMaximumRange[projectile.type];
				float num2 = ProjectileID.Sets.YoyosTopSpeed[projectile.type];
				if (Main.player[Main.myPlayer].yoyoString)
				num1 = (float) ((double) num1 * 1.25 + 30.0);
				float num3 = num1 / (float) ((1.0 + (double) Main.player[Main.myPlayer].meleeSpeed * 3.0) / 4.0);
				float num4 = num2 / (float) ((1.0 + (double) Main.player[Main.myPlayer].meleeSpeed * 3.0) / 4.0);
				float num5 = (float) (14.0 - (double) num4 / 2.0);
				if ((double) num5 < 1.00999999046326)
				num5 = 1.01f;
				float num6 = (float) (5.0 + (double) num4 / 2.0);
				if (flag1)
				num6 += 20f;
				if ((double) projectile.ai[0] >= 0.0)
				{
					if ((double) projectile.velocity.Length() > (double) num4)
					projectile.velocity = projectile.velocity * 0.98f;
					bool flag3 = false;
					bool flag4 = false;
					Vector2 vector2_1 = Main.player[Main.myPlayer].Center - projectile.Center;
					if ((double) vector2_1.Length() > (double) num3)
					{
						flag3 = true;
						if ((double) vector2_1.Length() > (double) num3 * 1.3)
						flag4 = true;
					}
					if (projectile.owner == Main.myPlayer)
					{
						if (!Main.player[Main.myPlayer].channel || Main.player[Main.myPlayer].stoned || Main.player[Main.myPlayer].frozen)
						{
							projectile.ai[0] = -1f;
							projectile.ai[1] = 0.0f;
							projectile.netUpdate = true;
						}
						else
						{
							Vector2 vector2_2 = Main.ReverseGravitySupport(Main.MouseScreen) + Main.screenPosition;
							float x = vector2_2.X;
							float y = vector2_2.Y;
							Vector2 vector2_3 = new Vector2(x, y) - Main.player[Main.myPlayer].Center;
							if ((double) vector2_3.Length() > (double) num3)
							{
								vector2_3.Normalize();
								Vector2 vector2_4 = vector2_3 * num3;
								Vector2 vector2_5 = Main.player[Main.myPlayer].Center + vector2_4;
								x = vector2_5.X;
								y = vector2_5.Y;
							}
							if ((double) projectile.ai[0] != (double) x || (double) projectile.ai[1] != (double) y)
							{
								Vector2 vector2_4 = new Vector2(x, y) - Main.player[Main.myPlayer].Center;
								if ((double) vector2_4.Length() > (double) num3 - 1.0)
								{
									vector2_4.Normalize();
									vector2_4 *= num3 - 1f;
									Vector2 vector2_5 = Main.player[Main.myPlayer].Center + vector2_4;
									x = vector2_5.X;
									y = vector2_5.Y;
								}
								projectile.ai[0] = x;
								projectile.ai[1] = y;
								projectile.netUpdate = true;
							}
						}
					}
					if (flag4 && projectile.owner == Main.myPlayer)
					{
						projectile.ai[0] = -1f;
						projectile.netUpdate = true;
					}
					if ((double) projectile.ai[0] >= 0.0)
					{
						Vector2 vector2_2 = new Vector2(projectile.ai[0], projectile.ai[1]) - projectile.Center;
						double num7 = (double) projectile.velocity.Length();
						float num8 = vector2_2.Length();
						if ((double) num8 > (double) num6)
						{
							vector2_2.Normalize();
							float num9 = (double) num8 > (double) num4 * 2.0 ? num4 : num8 / 2f;
							vector2_2 *= num9;
							projectile.velocity = (projectile.velocity * (num5 - 1f) + vector2_2) / num5;
						}
						else if (flag1)
						{
							if ((double) projectile.velocity.Length() < (double) num4 * 0.6)
							{
								vector2_2 = projectile.velocity;
								vector2_2.Normalize();
								vector2_2 *= num4 * 0.6f;
								projectile.velocity = (projectile.velocity * (num5 - 1f) + vector2_2) / num5;
							}
						}
						else
						projectile.velocity = projectile.velocity * 0.8f;
						if (flag1 && !flag3 && (double) projectile.velocity.Length() < (double) num4 * 0.6)
						{
							projectile.velocity.Normalize();
							projectile.velocity = projectile.velocity * (num4 * 0.6f);
						}
					}
				}
				else
				{
					float num7 = (float) (int) ((double) num5 * 0.8);
					float num8 = num4 * 1.5f;
					projectile.tileCollide = false;
					Vector2 vector2 = Main.player[Main.myPlayer].position - projectile.Center;
					float num9 = vector2.Length();
					if ((double) num9 < (double) num8 + 10.0 || (double) num9 == 0.0)
					{
						projectile.Kill();
					}
					else
					{
						vector2.Normalize();
						vector2 *= num8;
						projectile.velocity = (projectile.velocity * (num7 - 1f) + vector2) / num7;
					}
				}
				projectile.rotation += 0.45f;
			}
		}
    }
}