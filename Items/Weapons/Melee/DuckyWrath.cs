using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Weapons.Melee
{
    public class DuckyWrath : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Rain extra-dimensional duckies on your foes...");
		}

		public override void SetDefaults()
		{
			item.damage = 369;
			item.melee = true;
			item.width = 50;
			item.height = 54;
			item.useTime = 10;
			item.useAnimation = 7;
			item.knockBack = 6;
			item.value = Item.buyPrice(gold: 10);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 25;
			item.scale = 2f;
			item.shootSpeed = 20f;
			item.shoot = ProjectileID.StarWrath;
			item.useStyle = ItemUseStyleID.SwingThrow;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) 
		{
			if (Main.rand.NextBool(3)) 
			{
				Dust dust = Dust.NewDustDirect(player.position, hitbox.X, hitbox.Y, DustID.Vortex);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
		{
			target.AddBuff(BuffID.OnFire, 60);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 400f)
			{
				ceilingLimit = player.Center.Y - 400f;
			}
			for (int i = 0; i < 10; i++)
			{
				position = player.Center + new Vector2((-(float)Main.rand.Next(-801, 801) * player.direction), -600f);
				position.Y -= (100 * i);
				Vector2 heading = target - position;
				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}
				if (heading.Y < 2f)
				{
					heading.Y = 2f;
				}
				heading.Normalize();
				heading *= new Vector2(speedX, speedY).Length();
				speedX = heading.X;
				speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("DuckyWrathProjectile"), damage, knockBack, player.whoAmI, 0f, ceilingLimit);
			}
			return false;
		}
	}
}