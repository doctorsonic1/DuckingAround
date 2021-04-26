using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckingAround.NPCs
{
	public class VastiumSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platyrhynchium Slime");
			Main.npcFrameCount[npc.type] = 6;
		}
		public override void SetDefaults()
		{
			npc.width = 32;
			npc.height = 32;
			npc.damage = 47;
			npc.defense = 27;
			npc.lifeMax = Main.rand.Next(25) + 250;
			npc.knockBackResist = .095f;
			npc.aiStyle = 38;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.HitSound = SoundID.NPCHit1;
			npc.value = 3158f;
			npc.buffImmune[BuffID.Poisoned] = false;
			npc.buffImmune[BuffID.Confused] = false;
			npc.lavaImmune = true;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode == true && spawnInfo.player.ZoneRockLayerHeight)
			{
				return Main.rand.Next(1, 6) * .075f;
			}
			return 0f;
		}
		private const int AI_State_Slot = 0;
		private const int AI_Timer_Slot = 1;
		private const int AI_Flutter_Time_Slot = 2;

		private const int State_Asleep = 0;
		private const int State_Notice = 1;
		private const int State_Jump = 2;
		private const int State_Hover = 3;
		private const int State_Fall = 4;

		public float AI_State
		{
			get => npc.ai[AI_State_Slot];
			set => npc.ai[AI_State_Slot] = value;
		}

		public float AI_Timer
		{
			get => npc.ai[AI_Timer_Slot];
			set => npc.ai[AI_Timer_Slot] = value;
		}

		public float AI_FlutterTime
		{
			get => npc.ai[AI_Flutter_Time_Slot];
			set => npc.ai[AI_Flutter_Time_Slot] = value;
		}
		private const int Frame_Asleep = 0;
		private const int Frame_Notice = 1;
		private const int Frame_Falling = 2;
		private const int Frame_Flutter_1 = 3;
		private const int Frame_Flutter_2 = 4;
		private const int Frame_Flutter_3 = 5;
		
		public override void FindFrame(int frameHeight)
		{
			npc.spriteDirection = npc.direction;
			if (AI_State == State_Asleep) 
			{
				npc.frame.Y = Frame_Asleep * frameHeight;
			}
			else if (AI_State == State_Notice) 
			{
				if (AI_Timer < 10) 
				{
					npc.frame.Y = Frame_Notice * frameHeight;
				}
				else {
					npc.frame.Y = Frame_Asleep * frameHeight;
				}
			}
			else if (AI_State == State_Jump) 
			{
				npc.frame.Y = Frame_Falling * frameHeight;
			}
			else if (AI_State == State_Hover)
			{				
				npc.frameCounter++;
				if (npc.frameCounter < 10) 
				{
					npc.frame.Y = Frame_Flutter_1 * frameHeight;
				}
				else if (npc.frameCounter < 20) 
				{
					npc.frame.Y = Frame_Flutter_2 * frameHeight;
				}
				else if (npc.frameCounter < 30) 
				{
					npc.frame.Y = Frame_Flutter_3 * frameHeight;
				}
				else {
					npc.frameCounter = 0;
				}
			}
			else if (AI_State == State_Fall) 
			{
				npc.frame.Y = Frame_Falling * frameHeight;
			}
		}
	}
}		