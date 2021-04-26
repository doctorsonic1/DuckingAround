using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DuckingAround.NPCs
{
    public class EyeDestruction : ModNPC
    {        
        public int maxLife = 140000;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Destruction");
            Main.npcFrameCount[npc.type] = 18;
        }
        public override void SetDefaults()
        {
            npc.width = 72;
            npc.height = 72;
            npc.damage = 70;
            npc.defense = 20;
            npc.lifeMax = maxLife;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.npcSlots = 15f;
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
            npc.dontCountMe = true;
            bossBag = mod.ItemType("PsionBag");
        }
        public override void FindFrame(int frameHeight)
        {
            int frameTime = 4;
            npc.frameCounter++;

            if (npc.frameCounter < frameTime)
            { npc.frame.Y = frameHeight; }

            else if (npc.frameCounter < frameTime * 2)
            { npc.frame.Y = frameHeight * 2; }

            else if (npc.frameCounter < frameTime * 3)
            { npc.frame.Y = frameHeight * 3; }

            else if (npc.frameCounter < frameTime * 4)
            { npc.frame.Y = frameHeight * 4; }

            else if (npc.frameCounter < frameTime * 5)
            { npc.frame.Y = frameHeight * 5; }

            else if (npc.frameCounter < frameTime * 6)
            { npc.frame.Y = frameHeight * 6; }

            else if (npc.frameCounter < frameTime * 7)
            { npc.frame.Y = frameHeight * 7; }

            else if (npc.frameCounter < frameTime * 8)
            { npc.frame.Y = frameHeight * 8; }

            else if (npc.frameCounter < frameTime * 9)
            { npc.frame.Y = frameHeight * 9; }

            else if (npc.frameCounter < frameTime * 10)
            { npc.frame.Y = frameHeight * 10; }

            else if (npc.frameCounter < frameTime * 11)
            { npc.frame.Y = frameHeight * 11; }

            else if (npc.frameCounter < frameTime * 12)
            { npc.frame.Y = frameHeight * 12; }

            else if (npc.frameCounter < frameTime * 13)
            { npc.frame.Y = frameHeight * 13; }

            else if (npc.frameCounter < frameTime * 14)
            { npc.frame.Y = frameHeight * 14; }

            else if (npc.frameCounter < frameTime * 15)
            { npc.frame.Y = frameHeight * 15; }

            else if (npc.frameCounter < frameTime * 16)
            { npc.frame.Y = frameHeight * 16; }

            else if (npc.frameCounter < frameTime * 17)
            { npc.frame.Y = frameHeight * 17; }

            else { npc.frameCounter = 0; }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = maxLife + (numPlayers * (int)(0.05 * maxLife));
            npc.damage = 95;
        }
        public override void NPCLoot()
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
                if(!NPC.downedMoonlord && Main.hardMode && Main.expertMode)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Placeable.PlatyrhynchiumOre>(), Main.rand.Next(72, 94));
                }
                else if (!NPC.downedMoonlord && Main.hardMode && !Main.expertMode)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Placeable.PlatyrhynchiumOre>(), Main.rand.Next(62, 75));
                }
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Mounts.DuckEgg>());
            }
            WorldGenMethods.SpawnOre(ModContent.TileType<Tiles.PlatyrhynchiumOre>(), 0.000055, 0.45f, 0.65f);
            DuckingNetcode.SyncWorld();
        }
        public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            if (damage >= 500)
            {
                damage = 350;
            }
            crit = false;
        }
        public override void ModifyHitByProjectile(Projectile projectile,  ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (damage >= 500)
            {
                damage = 350;
            }
            crit = false;
        }
        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (npc.life > (0.67 * npc.lifeMax))
            {
                npc.aiStyle = 31;
                music = MusicID.LunarBoss;

            }
            if (npc.life >= (0.33 * npc.lifeMax) && npc.life < (0.67 * npc.lifeMax))
            {
                npc.aiStyle = 110;
            }
            if (npc.life < (0.33 * npc.lifeMax))
            {
                npc.aiStyle = 69;
                Vector2 velocity = player.Center - npc.Center;
                int type = 468;
                if (Main.rand.Next(0, 59) == 5)
                {
                    Projectile.NewProjectile(npc.Center, velocity, type, 75, 2f);
                }
                music = MusicID.LunarBoss;
            }
        }
    }
}      