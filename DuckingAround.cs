using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using ReLogic.Graphics;
using System.IO;
using DuckingAround.Projectiles.Duckies;
using DuckingAround.Tiles;
using System;
using Microsoft.Xna.Framework;

namespace DuckingAround
{
	public class DuckingAround : Mod
	{
		public static DuckingAround instance;
		public static DynamicSpriteFont exampleFont;
		internal UserInterface MomUserInterface;
		public static string EnemyName;

		public static int[] enemySpawnList =
		{ 
			NPCID.ChaosElemental, NPCID.ArmoredSkeleton, NPCID.Corruptor, NPCID.CursedSkull,
			NPCID.FloatyGross, NPCID.GiantBat, NPCID.Hornet, NPCID.Nymph, NPCID.Pixie,
			NPCID.Skeleton,NPCID.Unicorn, NPCID.Werewolf, NPCID.Zombie
		};

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
        public static int EggSpawnMethod()
		{
			int npcID = NPCID.Duck;
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}
				foreach (Item item in player.inventory)
				{
					if (item.type == ModContent.ItemType<Items.EnemyEggs.ChaosEgg>())
					{
						npcID = NPCID.ChaosElemental;
						EnemyName = "Chaos Elementals";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.ArmoredEgg>())
					{
						npcID = NPCID.ArmoredSkeleton;
						EnemyName = "Armored Skeletons";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.CorruptorEgg>())
					{
						npcID = NPCID.Corruptor;
						EnemyName = "Corruptors";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.CursedSkullEgg>())
					{
						npcID = NPCID.CursedSkull;
						EnemyName = "Cursed Skulls";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.FloatyEgg>())
					{
						npcID = NPCID.FloatyGross;
						EnemyName = "Floaty Grosses";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.GiantBatEgg>())
					{
						npcID = NPCID.GiantBat;
						EnemyName = "Giant Bats";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.HornetEgg>())
					{
						npcID = NPCID.Hornet;
						EnemyName = "Hornets";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.NymphEgg>())
					{
						npcID = NPCID.Nymph;
						EnemyName = "Nymphs";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.PixieEgg>())
					{
						npcID = NPCID.Pixie;
						EnemyName = "Pixies";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.SkeletonEgg>())
					{
						npcID = NPCID.Skeleton;
						EnemyName = "Skeletons";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.UnicornEgg>())
					{
						npcID = NPCID.Unicorn;
						EnemyName = "Unicorns";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.WerewolfEgg>())
					{
						npcID = NPCID.Werewolf;
						EnemyName = "Werewolves";
					}
					else if (item.type == ModContent.ItemType<Items.EnemyEggs.ZombieEgg>())
					{
						npcID = NPCID.Zombie;
						EnemyName = "Zombies";
					}
				}
			}
			DuckingWorld.enemyID = npcID;
			return npcID;
		}
		public static string EggNameMethod()
		{
			return EnemyName;
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
			Terraria.Player player = syncData ? Main.player[whoAmI] : Main.LocalPlayer;
			int index;
			if (type == ModContent.NPCType<NPCs.EnemySpawnerNPC>())
			{
				index = NPC.NewNPC((int)player.Bottom.X, (int)player.position.Y - 64, type);
			}
			else
			{
				index = NPC.NewNPC((int)Main.npc[NPC.FindFirstNPC(ModContent.NPCType<NPCs.EnemySpawnerNPC>())].position.X + DuckingAround.Negativity(800, 3), (int)player.Bottom.Y - 96, type);
			}
			if (syncID >= 0)
			{
				return;
			}
			Main.npc[index].SetDefaults(syncID);
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
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("DuckingAround:IronBars", 20);
			recipe.AddRecipeGroup("DuckingAround:SilverBars", 2);
			recipe.AddRecipeGroup("DuckingAround:GoldBars", 2);
			recipe.AddRecipeGroup("DuckingAround:CopperBars", 2);
			recipe.AddIngredient(ItemID.Wire, 50);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.MetalDetector);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.MallardDuck, 25);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(ItemID.Duck, 25);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Explosives);
			recipe.AddIngredient(ItemID.Duck, 20);
			recipe.AddTile(ModContent.TileType<HephaestusForge>());
			recipe.SetResult(ModContent.ItemType<Items.Weapons.Duckies.NukeDucky>(), 20);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.RocketIII, 20);
			recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Duckies.NukeDucky>(), 5);
			recipe.AddTile(ModContent.TileType<HephaestusForge>());
			recipe.SetResult(ModContent.ItemType<Items.Weapons.Duckies.NukeDuckyItem>(), 20);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.PlatyrhynchiumBar>(), 18);
			recipe.AddIngredient(ItemID.SoulofMight, 12);
			recipe.AddIngredient(ItemID.SoulofLight, 12);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(ModContent.TileType<HephaestusForge>());
			recipe.SetResult(ModContent.ItemType<Items.Weapons.Melee.DuckyWrath>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PlatyrhynchiumOre>(), 6);
			recipe.AddTile(ModContent.TileType<HephaestusForge>());
			recipe.SetResult(ModContent.ItemType<Items.Materials.PlatyrhynchiumBar>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.Sap>(), 3);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.Acid>(), 1);
			recipe.AddTile(ModContent.TileType<Coagulator>());
			recipe.SetResult(ModContent.ItemType<Items.Materials.Rubber>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Wire, 50);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.MachineParts>(), 25);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.Rubber>(), 15);
			recipe.AddRecipeGroup("DuckingAround:IronBars", 15);
			recipe.AddRecipeGroup("DuckingAround:GoldBars", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<Items.Placeable.CoagulatorItem>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.LunarBar, 20);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddIngredient(ItemID.GravityGlobe);
			recipe.AddIngredient(ItemID.Hoverboard);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ModContent.ItemType<Items.Accessories.Hoverboard>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.SoulofFlight, 100);
			recipe.AddIngredient(ItemID.WingsNebula);
			recipe.AddIngredient(ItemID.WingsSolar);
			recipe.AddIngredient(ItemID.WingsStardust);
			recipe.AddIngredient(ItemID.WingsNebula);
			recipe.AddIngredient(ItemID.GiantHarpyFeather);
			recipe.AddIngredient(ItemID.BrokenBatWing);
			recipe.AddIngredient(ItemID.FireFeather);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ModContent.ItemType<Items.Accessories.InfiniteFlightAccessory>());
			recipe.AddRecipe();
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
		public static bool PlayerFromTile(Player player, int xPos, int yPos)
		{
			if (Math.Abs(((int)player.position.X / 16) - xPos) < 5 && Math.Abs(((int)player.position.Y / 16) - yPos) < 5)
			{
				return true;
			}
			else
			{ 
				return false; 
			}
		}
	}
	public static class Config
    {
		public static bool PlaySoundForChugJug = false;
		public static bool SpawnerExists;
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