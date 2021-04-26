using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections;

namespace DuckingAround.Projectiles.Pets
{
	public class DuckPet : ModProjectile
	{
		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Pet Duck");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}
		public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
		}
		public override bool PreAI()
        {
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false;
			return true;
		}
		public override void AI()
        {
			Player player = Main.player[projectile.owner];
			DuckingPlayer modPlayer = player.GetModPlayer<DuckingPlayer>();
			if (player.dead)
            {
				modPlayer.DuckPet = false;
				modPlayer.petCount = 0;
			}
			if (modPlayer.DuckPet)
            {
				projectile.timeLeft = 2;
			}
            int i = Main.rand.Next(6900);
			if(i <= 30 && modPlayer.petCount <= 4)
			{
				Projectile.NewProjectile(projectile.position.X + Main.rand.Next(20), projectile.position.Y + Main.rand.Next(20), 0f, 5f, mod.ProjectileType("DuckEgg"), 84, 10, projectile.owner, 0f, 400f);
                modPlayer.petCount += 1;
            }
		}
	}
}