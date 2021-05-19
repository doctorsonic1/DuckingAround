using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace DuckingAround
{
    public class yourmodItem : GlobalItem
    {
        public static int[] potions =
            { ItemID.LesserManaPotion, ItemID.ManaPotion, ItemID.GreaterManaPotion, ItemID.SuperManaPotion, ItemID.WoodenSword};
        public override bool CanUseItem(Item item, Player player)
        {
            if (player.HasBuff(ModContent.BuffType<Buffs.DeathProtDebuff>()) && potions.Contains(item.type))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}