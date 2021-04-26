using Terraria;
using Microsoft.Xna.Framework;
namespace DuckingAround.Projectiles
{
    class DuckingProjectile
    {
        public static Projectile NewProjectileDirectSafe(Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0.0f, float ai1 = 0.0f)
        {
            int index = Projectile.NewProjectile(pos, vel, type, damage, knockback, owner, ai0, ai1);
            return index >= 1000 ? (Projectile)null : Main.projectile[index];
        }
    }
}
