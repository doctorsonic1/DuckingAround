using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.NPCs
{
    public class RobotFlier : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Robot Flier");
			Main.npcFrameCount[npc.type] = 6;
		}
		public override void SetDefaults()
		{
			npc.width = 16;
			npc.height = 32;
			npc.damage = 47;
			npc.defense = 27;
			npc.lifeMax = Main.rand.Next(300, 350);
			npc.knockBackResist = .395f;
			npc.aiStyle = 14;
			npc.scale = 1.5f;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.HitSound = SoundID.NPCHit1;
			npc.value = 958f;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.lavaImmune = true;
			npc.friendly = false;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode && spawnInfo.player.ZoneSkyHeight)
			{
				return Main.rand.Next(1, 6) * .125f;
			}
			else
			{
				return 0f;
			}
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

			else { npc.frameCounter = 0; }
		}
    }
}