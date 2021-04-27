using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using DuckingAround.Items.Placeable;

namespace DuckingAround.Tiles
{
    public class DuckyTotem : ModTile
    {
        public override void SetDefaults()
        {
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 3;			
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Ducky Totem");
			AddMapEntry(new Color(200, 200, 200), name);
        }
		public override bool NewRightClick(int i, int j)
		{
			DuckingPlayer modPlayer = Main.LocalPlayer.GetModPlayer<DuckingPlayer>();
			Player player = Main.LocalPlayer;
			modPlayer.respawnSpot = player.position;
			Main.PlaySound(SoundID.Mech, i * 16, j * 16, 0);
			HitWire(i, j);
			if(!player.HasBuff(mod.BuffType("DeathProtDebuff")) && !player.HasBuff(mod.BuffType("DeathProtBuff")))
			{
				player.AddBuff(mod.BuffType("DeathProtBuff"), 30 * 60);
				player.AddBuff(mod.BuffType("DeathProtDebuff"), 300 * 60);
			}
			return true;
		}
		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.showItemIcon = true;
			player.showItemIcon2 = ModContent.ItemType<DuckyTotemItem>();
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("DuckyTotemItem"));
		}
    }
}