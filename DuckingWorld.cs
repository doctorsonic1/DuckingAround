using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria.ID;

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

        public static int[] zombieGroup = { -26, -27, -28, -29, -30, -31, -32, -33, -34, -35, -36, -37, -44, -45, 3, 187, 188, 189, 200, 132, 590 };

        public static int[] enemySpawnList =
        {
            NPCID.ChaosElemental, NPCID.ArmoredSkeleton, NPCID.Corruptor, NPCID.CursedSkull,
            NPCID.FloatyGross, NPCID.GiantBat, NPCID.Hornet, NPCID.Nymph, NPCID.Pixie,
            NPCID.Skeleton, NPCID.Unicorn, NPCID.Werewolf, NPCID.Zombie
        };

        public override void PostUpdate()
        {
            DuckingAround.EggSpawnMethod();
            DuckingAround.EggNameMethod();
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
            writer.Write(NPCs.EnemySpawnerNPC.spawnerActive);
        }
        public override void NetReceive(BinaryReader reader)
        {
            downedPsion = reader.ReadInt32();
            spawnerX = reader.ReadInt32();
            spawnerY = reader.ReadInt32();
            NPCs.EnemySpawnerNPC.spawnerActive = reader.ReadInt32();
        }
        public override void Initialize()
        {
            NPCs.EnemySpawnerNPC.enemyCount = 0;
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