using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.Tiles
{
	public class PlatyrhynchiumOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 410;
			Main.tileShine2[Type] = true; 
			Main.tileShine[Type] = 255;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Vastium Ore");
			AddMapEntry(new Color(255, 255, 0), name);

			dustType = DustID.Platinum;
			drop = ModContent.ItemType<Items.Placeable.PlatyrhynchiumOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 3f;
			minPick = 225;
		}
	}
}