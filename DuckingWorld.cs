using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using System.IO;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace DuckingAround
{
    public class WorldGenMethods : ModWorld
    {
        public static void SpawnOre(int type, double frequency, float depth, float depthLimit)
        {
            int maxTilesX = Main.maxTilesX;
            int maxTilesY = Main.maxTilesY;
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
            for (int index = 0; index < (int)((double)(maxTilesX * maxTilesY) * frequency); ++index)
            {
                int i = WorldGen.genRand.Next(0, maxTilesX);
                int j = WorldGen.genRand.Next((int)((double)maxTilesY * (double)depth), (int)((double)maxTilesY * (double)depthLimit));
                if (type == ModContent.TileType<Tiles.PlatyrhynchiumOre>())
                {
                    WorldGen.OreRunner(i, j, (double)WorldGen.genRand.Next(7, 14), WorldGen.genRand.Next(7, 14), (ushort)type);
                }
            }
        }
    }
    public class DuckingWorld : ModWorld
    {
        public static Vector2 EnemySpawn = new Vector2(0.0f, 0.0f);
        public static Player closest;

        public static bool spawnOre = false;
        public static int spawnerActive;
        public static int downedPsion = 0;      //used for boolean checks

        public static int enemyID = NPCID.Duck;
        public static int spawnerX;
        public static int spawnerY;
        public static int frameInt;
        public static int spawnRate;

        public static string EnemyName;

        public static int[] enemySpawnList =
        {
            NPCID.ChaosElemental,
            NPCID.ArmoredSkeleton,
            NPCID.Corruptor,
            NPCID.CursedSkull,
            NPCID.FloatyGross,
            NPCID.GiantBat,
            NPCID.Hornet,
            NPCID.Nymph,
            NPCID.Pixie,
            NPCID.Skeleton,
            NPCID.Unicorn,
            NPCID.Werewolf,
            NPCID.Zombie
        };
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
                    if (npcID == NPCID.Duck)
                    {
                        EnemyName = "Ducks";
                    }
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

        public override void PostUpdate()
        {
            EggSpawnMethod();
            EggNameMethod();
            if (NPC.downedMechBoss1)
            { spawnRate = 600; }

            if (NPC.downedMechBoss2)
            { spawnRate = 480; }

            if (NPC.downedMechBoss3)
            { spawnRate = 360; }

            if (NPC.downedPlantBoss)
            { spawnRate = 240; }

            if (NPC.downedGolemBoss)
            { spawnRate = 120; }
        }
        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(downedPsion);
            writer.Write(spawnerX);
            writer.Write(spawnerY);
            writer.Write(NPCs.Towns.EnemySpawnerNPC.EnemySpawnerNPC.spawnerActive);
        }
        public override void NetReceive(BinaryReader reader)
        {
            downedPsion = reader.ReadInt32();
            spawnerX = reader.ReadInt32();
            spawnerY = reader.ReadInt32();
            NPCs.Towns.EnemySpawnerNPC.EnemySpawnerNPC.spawnerActive = reader.ReadInt32();
        }
        public override void Initialize()
        {
            NPCs.Towns.EnemySpawnerNPC.EnemySpawnerNPC.enemyCount = 0;
        }
        public override TagCompound Save()
        {
            return new TagCompound
            {
                { "downedPsion", downedPsion },
                { "spawnerActive", spawnerActive }
            };
        }
        public override void Load(TagCompound tag)
        {
            downedPsion = tag.GetInt("downedPsion");
            spawnerActive = tag.GetInt("spawnerActive");
        }
        public static void SpawnerSpawn(int player, int type)
        {
            NPC.SpawnOnPlayer(player, type);
            NetMessage.SendData(MessageID.SyncPlayer);
            NetMessage.SendData(MessageID.SyncNPC);
            NetMessage.SendData(MessageID.WorldData);
        }
    }
}