using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;

namespace DuckingAround.NPCs
{
    public class DuckingAroundGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public static int[] enemySpawnList =
        {
            NPCID.ChaosElemental, NPCID.ArmoredSkeleton, NPCID.Corruptor, NPCID.CursedSkull,
            NPCID.FloatyGross, NPCID.GiantBat, NPCID.Hornet, NPCID.Nymph, NPCID.Pixie,
            NPCID.Skeleton, NPCID.Unicorn, NPCID.Werewolf, NPCID.Zombie
        };

        public static int[] zombieGroup = { -26, -27, -28, -29, -30, -31, -32, -33, -34, -35, -36, -37, -44, -45, 3, 187, 188, 189, 200, 132, 590 };

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            maxSpawns = 40;
        }
        public override bool CheckDead(NPC npc)
        {
            Towns.EnemySpawnerNPC.EnemySpawnerNPC.enemyCount -= 1;
            return true;
        }
        public override bool PreNPCLoot(NPC npc)
        {
            //remove drops from vanilla enemies with NPCLoader.blockloot
            int randGenNum = Main.rand.Next(2);
            bool randGen;
            if (randGenNum == 1)
            {
                randGen = true;
            }
            else
            {
                randGen = false;
            }
            if (npc.type == NPCID.LostGirl || npc.type == NPCID.Nymph)
            {
                if (randGen == true)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MetalDetector);
                }
                if (randGen == false && !Main.LocalPlayer.HasItem(ModContent.ItemType<Items.EnemyEggs.NymphEgg>()))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.EnemyEggs.NymphEgg>());
                }
                NPCLoader.blockLoot.Add(ItemID.MetalDetector);
            }
            if (npc.type == NPCID.VoodooDemon)
            {
                int item = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GuideVoodooDoll);
                ItemID.Sets.ItemNoGravity[Main.item[item].type] = true;
            }
            NPCLoader.blockLoot.Add(ItemID.GuideVoodooDoll);
            return true;
        }
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == ModContent.NPCType<Bosses.EyeDestruction>())
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int centerX = (int)(npc.position.X + (float)(npc.width / 4)) / 16;
                    int centerY = (int)(npc.position.Y + (float)(npc.height / 4)) / 16;
                    int halfLength = npc.width / 2 / 16 + 1;
                    for (int x = centerX - halfLength; x <= centerX + halfLength; x++)
                    {
                        for (int y = centerY - halfLength; y <= centerY + halfLength; y++)
                        {
                            if ((x == centerX - halfLength || x == centerX + halfLength || y == centerY - halfLength || y == centerY + halfLength) && !Main.tile[x, y].active())
                            {
                                Main.tile[x, y].type = TileID.AdamantiteBeam;
                                Main.tile[x, y].active(true);
                            }
                            Main.tile[x, y].lava(false);
                            Main.tile[x, y].liquid = 0;
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendTileSquare(-1, x, y, 1);
                            }
                            else
                            {
                                WorldGen.SquareTileFrame(x, y, true);
                            }
                        }
                    }
                }
                if (Main.expertMode)
                {
                    npc.DropBossBags();
                }
                else
                {
                    if (!NPC.downedMoonlord && Main.hardMode && Main.expertMode)
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Placeable.PlatyrhynchiumOre>(), Main.rand.Next(72, 94));
                    }
                    else if (!NPC.downedMoonlord && Main.hardMode && !Main.expertMode)
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Placeable.PlatyrhynchiumOre>(), Main.rand.Next(62, 75));
                    }
                    Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Mounts.DuckEgg>());
                }
                WorldGenMethods.SpawnOre(ModContent.TileType<Tiles.PlatyrhynchiumOre>(), 0.000035, 0.45f, 0.65f);
                DuckingNetcode.SyncWorld();
            }
            //vastium slime ore drops
            if (NPC.downedMoonlord == true && npc.type == ModContent.NPCType<Enemies.PlatyrhynchiumSlime>())
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Placeable.PlatyrhynchiumOre>(), Main.rand.Next(26) + 7);
            }
            //acid drops
            if (npc.type == ModContent.NPCType<Enemies.AcidicSlime>())
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Materials.Acid>());
            }
            //machine part drops
            if (npc.type == ModContent.NPCType<Enemies.RobotFlier>())
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Materials.MachineParts>());
            }
            //enemy egg drops
            if (zombieGroup.Contains(npc.type) && !Main.LocalPlayer.HasItem(ModContent.ItemType<Items.EnemyEggs.ZombieEgg>()))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.EnemyEggs.ZombieEgg>(), 1);
                }
            }
            if (enemySpawnList.Contains(npc.type) && Main.rand.Next(0, 10) == 4)
            {
                string name = npc.FullName;
                string trimmed = string.Concat(name.Where(c => !Char.IsWhiteSpace(c))) + "Egg";
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(trimmed), 1);
            }
        }
    }
}