using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

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