using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace DuckingAround.Items.Materials
{
    public class AmalgamatedSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coagulated Soul");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.ItemNoGravity[item.type] = true;
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
		}
		public override void SetDefaults()
		{
			item.width = 33;
			item.height = 33;
			item.maxStack = 999;
			item.rare = ItemRarityID.Blue;
		}
    }
}