using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace DuckingAround.Buffs
{
    public class ZenithBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Otherworldy Powers");
            Description.SetDefault("Holding this weapon gives you a boost to your health");
        }
    }
}