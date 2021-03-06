using Terraria;
using Terraria.ModLoader;

namespace DuckingAround.Buffs
{
    public class DuckyTotemBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Buff Powers");
            Description.SetDefault("Holding this weapon gives you a boost to your health");
			Main.buffNoTimeDisplay[Type] = true;
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.onHitDodge = true;
			player.lifeRegen += 15;
		}
    }
} 