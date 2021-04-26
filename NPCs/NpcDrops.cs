using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq; 

namespace DuckingAround.NPCs
{
    public class NpcDrops : GlobalNPC
    {
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
                if (randGen == false && !Main.LocalPlayer.HasItem(mod.ItemType("NymphEgg")))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NymphEgg"));
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

            //vastium slime ore drops
            if (NPC.downedMoonlord == true && npc.type == mod.NPCType("VastiumSlime"))
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PlatyrhynchiumOre"), Main.rand.Next(26) + 7);
            }

            //acid drops
            if (npc.type == ModContent.NPCType<AcidicSlime>())
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Materials.Acid>());
            }
            //enemy egg drops
            else if (npc.type == NPCID.Skeleton && !Main.LocalPlayer.HasItem(mod.ItemType("SkeletonEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SkeletonEgg"), 1);
                }
            }
            else if (npc.type == NPCID.ChaosElemental && !Main.LocalPlayer.HasItem(mod.ItemType("ChaosEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosEgg"), 1);
                }
            }
            else if (npc.type == NPCID.CursedSkull && !Main.LocalPlayer.HasItem(mod.ItemType("CursedEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedEgg"), 1);
                }
            }
            else if (npc.type == NPCID.GiantBat && !Main.LocalPlayer.HasItem(mod.ItemType("GiantBatEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GiantBatEgg"), 1);
                }
            }
            else if (npc.type == NPCID.Hornet && !Main.LocalPlayer.HasItem(mod.ItemType("HornetEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HornetEgg"), 1);
                }
            }
            else if (npc.type == NPCID.Unicorn && !Main.LocalPlayer.HasItem(mod.ItemType("UnicornEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("UnicornEgg"), 1);
                }
            }
            else if (DuckingWorld.zombieGroup.Contains(npc.type) && !Main.LocalPlayer.HasItem(mod.ItemType("ZombieEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ZombieEgg"), 1);
                }
            }
            else if (npc.type == NPCID.ArmoredSkeleton && !Main.LocalPlayer.HasItem(mod.ItemType("ArmoredEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ArmoredEgg"), 1);
                }
            }
            else if (npc.type == NPCID.Pixie && !Main.LocalPlayer.HasItem(mod.ItemType("PixieEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PixieEgg"), 1);
                }
            }
            else if (npc.type == NPCID.Werewolf && !Main.LocalPlayer.HasItem(mod.ItemType("SkeletonEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WerewolfEgg"), 1);
                }
            }
            else if (npc.type == NPCID.Corruptor && !Main.LocalPlayer.HasItem(mod.ItemType("CorruptorEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CorruptorEgg"), 1);
                }
            }
            else if (npc.type == NPCID.FloatyGross && !Main.LocalPlayer.HasItem(mod.ItemType("FloatyEgg")))
            {
                if (Main.rand.Next(0, 10) == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FloatyEgg"), 1);
                }
            }
        }
	}
}