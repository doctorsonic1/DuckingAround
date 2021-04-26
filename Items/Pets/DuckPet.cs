using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Items.Pets
{
	public class DuckPet : ModItem
	{
		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Duck");
			Tooltip.SetDefault("Duck");
		}
		public override void SetDefaults()
        {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.DuckPet>();
			item.buffType = ModContent.BuffType<Buffs.DuckPet>();
		}
		public override void UseStyle(Player player)
        {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}