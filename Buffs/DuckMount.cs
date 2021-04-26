using Terraria;
using Terraria.ModLoader;

namespace DuckingAround.Buffs
{
	public class DuckMount : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Rideable Duck");
			Description.SetDefault("Quack?");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.mount.SetMount(ModContent.MountType<Mounts.Duck>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}