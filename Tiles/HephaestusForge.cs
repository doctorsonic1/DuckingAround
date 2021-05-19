using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using DuckingAround;
using Microsoft.Xna.Framework.Graphics;

namespace DuckingAround.Tiles
{
    public class HephaestusForge : ModTile
	{
		public int publicJ;
		public int publicI;
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Hephaestus' Forge");
            AddMapEntry(new Color(200, 200, 200), name);
			disableSmartCursor = true;
			adjTiles = new int[] {TileID.DemonAltar, TileID.AdamantiteForge, TileID.MythrilAnvil};
			animationFrameHeight = 72;
			dustType = DustID.Smoke;
		}
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.frameX < 10)
			{
				r = 1.2f;
				g = 0.05f;
				b = 0.05f;
			}
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Placeable.HephaestusForge>());
		}
		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			if (++frameCounter >= 6)
			{
				frame = ++frame % 4;
				frameCounter = 0;
			}
		}
	}
}