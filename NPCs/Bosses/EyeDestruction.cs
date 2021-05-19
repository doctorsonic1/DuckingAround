using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace DuckingAround.NPCs.Bosses
{
    public class EyeDestruction : ModNPC
    {
        private static Vector2 zeroVector = new Vector2(0f, 0f);

        private static bool spinDelay = false;
        private static bool moveDelay = false;
        private static bool far;
        private static bool superfar;

        private readonly int maxLife = 140000;
        private static int timer;
        private static int delay = 1200;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Destruction");
            Main.npcFrameCount[npc.type] = 18;
        }
        public override void SetDefaults()
        {
            npc.width = 72;
            npc.height = 72;
            npc.scale = 2f;
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
            bossBag = ModContent.ItemType<Items.LootBags.EyeDestructionBag>();
            music = MusicID.LunarBoss;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter += 0.25;
            npc.frameCounter %= 18;
            npc.frame.Y = frameHeight * (int)(npc.frameCounter);
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = maxLife + (numPlayers * (int)(0.05 * maxLife));
            npc.damage = 95;
        }
        public override void AI()
        {
            Main.NewText("npc.velocity = " + Convert.ToString(new Vector2((float)Math.Truncate(npc.velocity.X / 16), (float)Math.Truncate(npc.velocity.Y / 16))));
            Main.NewText("npc.position = " + Convert.ToString(new Vector2((float)Math.Truncate(npc.position.X / 16), (float)Math.Truncate(npc.position.Y / 16))));
            Main.NewText("npc.ai[0] = " + Convert.ToString(npc.ai[0]));
            Main.NewText("npc.ai[1] = " + Convert.ToString(npc.ai[1]));
            Main.NewText("npc.ai[2] = " + Convert.ToString(npc.ai[2]));
            Main.NewText("npc.ai[3] = " + Convert.ToString(npc.ai[3]));
            Main.NewText("delay = " + Convert.ToString(delay));
            Main.NewText("moveDelay = " + Convert.ToString(moveDelay));
            Main.NewText("superfar = " + Convert.ToString(superfar));
            Main.NewText("far = " + Convert.ToString(far));

            Player player = Main.player[npc.target];

            far = Vector2.Distance(player.Center, npc.Center) > 280f;
            superfar = Vector2.Distance(player.Center, npc.Center) > 700f;

            Vector2 velocity = Vector2.Normalize(player.Center - npc.Center);

            delay--;
            if (delay == 0)
            {
                moveDelay = true;
            }

            if (far && !moveDelay)
            {
                npc.ai[0] += (float)Math.PI / 30;
                npc.velocity = velocity.RotatedBy((double)Math.Sin(npc.ai[0])) * 6f;
                npc.velocity.X *= 1.685f;
            }
            if (moveDelay)
            {
                npc.velocity *= 0f;
                npc.ai[1] += 2f;
                if (npc.ai[1] % 4 == 0)
                {
                    int shotProj = Projectile.NewProjectile(npc.Center, Vector2.UnitX.RotatedBy(npc.ai[1] / 180 * Math.PI) * 10, ModContent.ProjectileType<Projectiles.BorderProj>(), 40, 2f);
                    Main.projectile[shotProj].timeLeft = 120;
                    Main.projectile[shotProj].netUpdate = true;
                }
                if (npc.ai[1] >= 360f)
                {
                    npc.ai[1] = 0f;
                    moveDelay = false;
                }
            }
            if (spinDelay)
            {
                if (npc.ai[3] <= 0f)
                {
                    float speed = 12f;
                    Vector2 move = npc.Center - player.Center;
                    npc.velocity = Vector2.Normalize(move) * speed;
                    npc.ai[3] = 30f;
                }
                npc.ai[3]--;
            }
            if (superfar && !spinDelay)
            {
                if (npc.ai[3] <= 0f)
                {
                    float speed = 35f;
                    Vector2 move = player.Center - npc.Center;
                    npc.velocity = Vector2.Normalize(move) * speed;
                    npc.ai[3] = 20f;
                }
                npc.ai[3]--;
            }
            if (!far && !spinDelay)
            {
                if (npc.ai[3] <= 0f)
                {
                    float speed = 25f;
                    Vector2 move = player.Center - npc.Center;
                    npc.velocity = Vector2.Normalize(move) * speed;
                    npc.ai[3] = 30f;
                }
                npc.ai[3]--;
            }

            //npc.ai[0] is moving rotation
            //npc.ai[1] is shooting projectile rotation
            if (npc.ai[0] >= 2f * (float)Math.PI)
            {
                npc.ai[0] = 0f;
            }
        }
    }
}
