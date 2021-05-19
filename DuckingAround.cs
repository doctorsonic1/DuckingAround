using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using System;
using System.IO;
using ReLogic.Graphics;
using Microsoft.Xna.Framework;

namespace DuckingAround
{
	public class DuckingAround : Mod
	{
		public static DuckingAround instance;
		public static DynamicSpriteFont exampleFont;
		internal UserInterface MomUserInterface;
		public static int Negativity(int someNum, int negativeChance)
		{
			if (Main.rand.Next(0, negativeChance) == 1)
			{
				return (someNum * -1);
			}
			else
			{
				return someNum;
			}
		}
		public override void Load()
		{
			DuckingAround.instance = this;
		}
		public static bool RandomBool(int EqualVal, int Upperbound)
		{
			if (Main.rand.Next(0, Upperbound) == EqualVal)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static void HandleNPC(int type, int syncID = 0, bool forceHandle = false, int whoAmI = 0)
		{
			if ((forceHandle ? 1 : (Main.netMode == NetmodeID.SinglePlayer ? 1 : 0)) != 0)
				DuckingAround.SpawnNPC(type, forceHandle, syncID, whoAmI);
			else
				DuckingAround.SyncNPC(type, syncID);
		}
		public static void SyncNPC(int type, int syncID = 0)
		{
			ModPacket packet = DuckingAround.instance.GetPacket();
			packet.Write((byte)0);
			packet.Write(type);
			packet.Write(syncID);
			packet.Send();
		}
		private static void SpawnNPC(int type, bool syncData = false, int syncID = 0, int whoAmI = 0)
		{
            Player player = syncData ? Main.player[whoAmI] : Main.LocalPlayer;
			int index;
			if (type == ModContent.NPCType<NPCs.Towns.EnemySpawnerNPC.EnemySpawnerNPC>())
			{
				index = NPC.NewNPC((int)player.Bottom.X, (int)player.position.Y - 64, type);
			}
			else
			{
				index = NPC.NewNPC((int)Main.npc[NPC.FindFirstNPC(ModContent.NPCType<NPCs.Towns.EnemySpawnerNPC.EnemySpawnerNPC>())].position.X + DuckingAround.Negativity(800, 3), (int)player.Bottom.Y - 96, type);
			}
			if (syncID >= 0)
			{
				return;
			}
			Main.npc[index].SetDefaults(syncID);
		}
		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			DuckingMessageType sheetMessageType = (DuckingMessageType)reader.ReadByte();
			switch (sheetMessageType)
			{
				case DuckingMessageType.SpawnNPC:
					int type = reader.ReadInt32();
					int num = reader.ReadInt32();
					int syncID = num;
					int whoAmI1 = whoAmI;
					DuckingAround.HandleNPC(type, syncID, true, whoAmI1);
					break;
				default:
					this.Logger.Warn((object)("Unknown Message type: " + (object)sheetMessageType));
					break;
			}
		}
		public static bool PlayerFromTile(Player player, int xPos, int yPos, int distance)
		{
			if (Math.Abs(((int)player.position.X / 16) - xPos) < distance && Math.Abs(((int)player.position.Y / 16) - yPos) < distance)
			{
				return true;
			}
			else
			{ 
				return false; 
			}
		}
		public override void AddRecipeGroups()
		{
			RecipeGroup iron = new RecipeGroup(() => "Any Iron Bar", new int[]
			{ ItemID.IronBar, ItemID.LeadBar });
			RecipeGroup.RegisterGroup("DuckingAround:IronBars", iron);

			RecipeGroup gold = new RecipeGroup(() => "Any Gold Bar", new int[]
			{ ItemID.PlatinumBar, ItemID.GoldBar });
			RecipeGroup.RegisterGroup("DuckingAround:GoldBars", gold);

			RecipeGroup copper = new RecipeGroup(() => "Any Copper Bar", new int[]
			{ ItemID.CopperBar, ItemID.TinBar });
			RecipeGroup.RegisterGroup("DuckingAround:CopperBars", copper);

			RecipeGroup silver = new RecipeGroup(() => "Any Silver Bar", new int[]
			{ ItemID.SilverBar, ItemID.TungstenBar });
			RecipeGroup.RegisterGroup("DuckingAround:SilverBars", silver);
		}
	}
    class SpawnRateMultiplierGlobalNPC : GlobalNPC
    {
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			float chugJugMult = 20f;
			DuckingPlayer modPlayer = Main.LocalPlayer.GetModPlayer<DuckingPlayer>();
			if(player.HasBuff(mod.BuffType("ChugJug")))
			{
				modPlayer.timeCounter++;
				spawnRate = (int)(spawnRate / chugJugMult);
				maxSpawns = (int)(maxSpawns * chugJugMult);
			}
		}
    }
}