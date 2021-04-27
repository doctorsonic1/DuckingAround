using Terraria;
using Terraria.ModLoader;

namespace DuckingAround.Buffs
{
    public class DeathProtDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Death Protection Debuff");
            Description.SetDefault("You cannot reactivate death protection.");
			longerExpertDebuff = true;
			Main.debuff[Type] = true;
        }
	}
} 