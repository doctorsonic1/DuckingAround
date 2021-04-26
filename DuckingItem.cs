using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround
{
    public class DuckingItem : GlobalItem
    {
        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (item.type == ItemID.PlatinumCoin)
            {
                ItemID.Sets.ItemNoGravity[item.type] = true;
            }
            if (item.type == ItemID.GoldCoin)
            {
                ItemID.Sets.ItemNoGravity[item.type] = true;
            }
            if (item.type == ItemID.SilverCoin)
            {
                ItemID.Sets.ItemNoGravity[item.type] = true;
            }
            if (item.type == ItemID.CopperCoin)
            {
                ItemID.Sets.ItemNoGravity[item.type] = true;
            }
            if (item.type == ItemID.Feather)
            {
                ItemID.Sets.ItemNoGravity[item.type] = true;
            }
            if (item.type == ItemID.GiantHarpyFeather)
            {
                ItemID.Sets.ItemNoGravity[item.type] = true;
            }
            if (item.type == ItemID.WyvernBanner)
            {
                ItemID.Sets.ItemNoGravity[item.type] = true;
            }
            if (item.type == ItemID.HarpyBanner)
            {
                ItemID.Sets.ItemNoGravity[item.type] = true;
            }
        }
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.GuideVoodooDoll)
            {
                item.consumable = true;
                item.useAnimation = 15;
                item.useTime = 15;
                item.useStyle = ItemUseStyleID.HoldingUp;
            }
        }
        public override bool UseItem(Item item, Player player)
        {
            if (item.type == ItemID.GuideVoodooDoll)
            {
                player.DropSelectedItem();
                ItemID.Sets.ItemNoGravity[item.type] = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}