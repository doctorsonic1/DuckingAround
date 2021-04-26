using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace DuckingAround.Buffs
{
    public class DeathProtBuff : ModBuff
    {
		DuckingPlayer modPlayer = Main.LocalPlayer.GetModPlayer<DuckingPlayer>();
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Death Protection");
            Description.SetDefault("You cannot take damage.");
			canBeCleared = true;
        }
		public override void Update(Player player, ref int buffIndex)
		{
			DuckingPlayer modPlayer = Main.LocalPlayer.GetModPlayer<DuckingPlayer>();
			if(modPlayer.removeBuff == true)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				modPlayer.removeBuff = false;
			}
			if (player.HasBuff(mod.BuffType("DeathProtBuff")))
			{
				modPlayer.removeDeathProt = false;
			}
			else
			{
				modPlayer.removeDeathProt = true;
			}
		}
	}
} 