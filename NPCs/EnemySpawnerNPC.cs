using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DuckingAround.NPCs
{
	[AutoloadHead]
	public class EnemySpawnerNPC : ModNPC
	{
		private int center
		{
			get => (int)npc.ai[0];
			set => npc.ai[0] = value;
		}
		private int captiveType
		{
			get => (int)npc.ai[1];
			set => npc.ai[1] = value;
		}
		public static int enemyCount = 0;
		public static int spawnerActive;
		public static int playerClosest;
		public override string Texture => "DuckingAround/NPCs/EnemySpawnerNPC";

		public override string[] AltTextures => new[] { "DuckingAround/NPCs/EnemySpawnerNPC_Alt_1" };

		public override bool Autoload(ref string name)
		{
			name = "Enemy Spawner";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 16;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 32;
			npc.height = 55;
			npc.aiStyle = -1;
			npc.lifeMax = 250;
			npc.scale = 1.5f;
			npc.knockBackResist = 0f;
			npc.lifeRegenCount = 100;
			npc.noGravity = true;
			npc.immortal = true;
			npc.netAlways = true;
			npc.dontTakeDamageFromHostiles = true;
		}
		public override void FindFrame(int frameHeight)
		{
			this.npc.frameCounter += .20;
			this.npc.frameCounter %= (double)Main.npcFrameCount[this.npc.type];
			this.npc.frame.Y = (int)this.npc.frameCounter * frameHeight;
		}
		public override string TownNPCName()
		{
			return "EnemySpawner";
		}
        public override void SetChatButtons(ref string button, ref string button2)
        {
			button = "Enable spawner";
			button2 = "Disable spawner";
		}
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				Player player = Main.player[this.npc.FindClosestPlayer()];
				DuckingWorld.spawnerX = (int)player.position.X;
				DuckingWorld.spawnerY = (int)player.position.Y - 64;
				DuckingWorld.spawnerActive = 1;
				NetMessage.SendData(MessageID.WorldData);
			}
			else
			{
				DuckingWorld.spawnerActive = 0;
				NetMessage.SendData(MessageID.WorldData);
			}
		}
        public override string GetChat()
        {
			if (DuckingWorld.spawnerActive == 1)
			{
				return "I am currently spawning " + DuckingAround.EggNameMethod() + ".";
			}
			else
			{
				return "I am not currently active.";
			}
		}
		public override void AI()
		{
			if (Main.slimeRain)
			{
				Main.StopSlimeRain();
				NetMessage.SendData(MessageID.WorldData);
			}
			else if (DuckingWorld.spawnerActive == 1 && Main.rand.Next(0, DuckingWorld.spawnRate) == 60 && enemyCount <= 50)
			{
				DuckingAround.HandleNPC(DuckingAround.EggSpawnMethod());
				enemyCount += 1;
			}
		}
		public static void SetPosition(NPC npc)
		{
			EnemySpawnerNPC modNPC = npc.modNPC as EnemySpawnerNPC;
			if (modNPC != null)
			{
				Vector2 center = Main.npc[modNPC.center].Center;
				double angle = Main.npc[modNPC.center].ai[3] + 2.0 * Math.PI * modNPC.captiveType / 5.0;
				npc.position = center + 300f * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) - npc.Size / 2f;
			}
		}
    }
}