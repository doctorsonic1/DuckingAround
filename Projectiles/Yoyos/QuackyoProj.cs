using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using DuckingAround.Projectiles.Yoyos.Orbiting.QuackYo;

namespace DuckingAround.Projectiles.Yoyos
{
	public class QuackyoProj : ModProjectile
	{
		public int Counter = 1;
		public int hitcounter;

		public bool yoyosSpawned;

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 650f;
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
			projectile.tileCollide = false;
		}
		public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
		{
			Player owner = Main.LocalPlayer;
			int rand = Main.rand.Next(20);
			if (rand < 7)
			{
				int healVal = 15;
				owner.statLife += healVal;
				owner.HealEffect(healVal, true);
			}
			Player player = Main.player[projectile.owner];
			++hitcounter;
			if (player.ownedProjectileCounts[556] < 5)
			{
				Projectile.NewProjectile(player.Center, Main.rand.NextVector2Circular(10f, 10f), ProjectileID.BlackCounterweight, projectile.damage, projectile.knockBack, projectile.owner);
			}
		}
		public override void AI()
		{
			if (!yoyosSpawned && projectile.owner == Main.myPlayer)
			{
				int num = 12;
				for (int index = 0; index < num; ++index)
				{
					float ai1 = (float)(360.0 / (double)num * (double)index * (Math.PI / 180.0));
					//bounty
					if (index == 0)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Bounty.BountyCopy1>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 1)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Bounty.BountyCopy2>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 1)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<QuackYoOrbiting>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 2)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Bounty.BountyCopy3>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}

					//destiny
					if (index == 3)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Destiny.DestinyCopy1>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 4)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Destiny.DestinyCopy2>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 4)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<QuackYoOrbiting1>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 5)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Destiny.DestinyCopy3>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}

					//freedom
					if (index == 6)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Freedom.FreedomCopy1>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 7)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Freedom.FreedomCopy2>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 7)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<QuackYoOrbiting2>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 8)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Freedom.FreedomCopy3>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}

					//pegasus
					if (index == 9)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Pegasus.PegasusCopy1>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 10)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Pegasus.PegasusCopy2>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 10)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<QuackYoOrbiting3>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 11)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<Orbiting.QuackYo.Pegasus.PegasusCopy3>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
				}
				this.yoyosSpawned = true;
			}
			if (Main.player[projectile.owner].HeldItem.type != ModContent.ItemType<Items.Weapons.Yoyos.QuackYo>())
			{
				return;
			}
			projectile.damage = Main.player[projectile.owner].GetWeaponDamage(Main.player[projectile.owner].HeldItem);
			projectile.knockBack = Main.player[projectile.owner].GetWeaponKnockback(Main.player[projectile.owner].HeldItem, Main.player[projectile.owner].HeldItem.knockBack);
		}
	}
}