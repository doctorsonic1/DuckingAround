using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DuckingAround.Projectiles.Yoyos.Orbiting.Pegasus;
using Microsoft.Xna.Framework;
using System;

namespace DuckingAround.Projectiles.Yoyos
{
    public class PegasusProj : ModProjectile
	{
		public int Counter = 1;
		public int hitcounter;

		public bool yoyosSpawned;

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
		public override void AI()
		{
			if (!yoyosSpawned && projectile.owner == Main.myPlayer)
			{
				int num = 3;
				for (int index = 0; index < num; ++index)
				{
					float ai1 = (float)(360.0 / (double)num * (double)index * (Math.PI / 180.0));
					if (index == 0)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<PegasusOrbiting1>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 1)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<PegasusOrbiting2>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
					if (index == 2)
					{
						DuckingProjectile.NewProjectileDirectSafe(projectile.Center, Vector2.Zero, ModContent.ProjectileType<PegasusOrbiting3>(), projectile.damage, projectile.knockBack, projectile.owner, 5f, ai1).localAI[0] = (float)projectile.whoAmI;
					}
				}
				this.yoyosSpawned = true;
			}
			if (Main.player[projectile.owner].HeldItem.type != ModContent.ItemType<Items.Weapons.Yoyos.PegasusYoYo>())
			{
				return;
			}
			projectile.damage = Main.player[projectile.owner].GetWeaponDamage(Main.player[projectile.owner].HeldItem);
			projectile.knockBack = Main.player[projectile.owner].GetWeaponKnockback(Main.player[projectile.owner].HeldItem, Main.player[projectile.owner].HeldItem.knockBack);
		}
	}
}