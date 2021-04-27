using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using DuckingAround.Items.Placeable;

namespace DuckingAround.Tiles
{
    public class Electrolyzer : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = false;
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 , 16 };
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Electrolyzer");
			disableSmartCursor = true;
			animationFrameHeight = 54;
	}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<ElectrolyzerItem>());
		}
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
			if (++frameCounter >= 3)
			{
				frameCounter = 0;
				frame = ++frame % 12;
			}
		}
	}
}