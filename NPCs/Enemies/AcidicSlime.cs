using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace DuckingAround.NPCs.Enemies
{
	public class AcidicSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acidic Slime");
			Main.npcFrameCount[npc.type] = 6;
		}
		public override void SetDefaults()
		{
			npc.width = 16;
			npc.height = 32;
			npc.damage = 47;
			npc.defense = 27;
			npc.lifeMax = Main.rand.Next(400, 450);
			npc.knockBackResist = .095f;
			npc.aiStyle = -1;
			npc.scale = 1.5f;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.HitSound = SoundID.NPCHit1;
			npc.value = 958f;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.lavaImmune = true;
			npc.friendly = false;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode && spawnInfo.player.ZoneCorrupt)
			{
				return Main.rand.Next(1, 6) * .125f;
			}
			else
			{
				return 0f;
			}
		}

        private const int AI_State_Slot = 0;
		private const int AI_Timer_Slot = 1;
		private const int AI_Flutter_Time_Slot = 2;
		private const int AI_Unused_Slot_3 = 3;

		private const int Local_AI_Unused_Slot_0 = 0;
		private const int Local_AI_Unused_Slot_1 = 1;
		private const int Local_AI_Unused_Slot_2 = 2;
		private const int Local_AI_Unused_Slot_3 = 3;

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
		public override void AI()
		{
			if (AI_State == State_Asleep)
			{
				npc.TargetClosest(true);
				if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 900f)
				{
					AI_State = State_Notice;
					AI_Timer = 0;
				}
			}
			else if (AI_State == State_Notice)
			{
				if (Main.player[npc.target].Distance(npc.Center) < 900f)
				{
					AI_Timer++;
					if (AI_Timer >= 20)
					{
						AI_State = State_Jump;
						AI_Timer = 0;
					}
				}
				else
				{
					npc.TargetClosest(true);
					if (!npc.HasValidTarget || Main.player[npc.target].Distance(npc.Center) > 1300f)
					{
						AI_State = State_Asleep;
						AI_Timer = 0;
					}
				}
			}
			else if (AI_State == State_Jump)
			{
				AI_Timer++;
				if (AI_Timer == 1)
				{
					npc.velocity = new Vector2(npc.direction * 2, -10f);
				}
				else if (AI_Timer > 40)
				{
					AI_State = State_Hover;
					AI_Timer = 0;
				}
			}
			else if (AI_State == State_Hover)
			{
				AI_Timer += 1;
				if (AI_Timer == 1 && Main.netMode != NetmodeID.MultiplayerClient)
				{
					AI_FlutterTime = Main.rand.NextBool() ? 100 : 50;
					npc.netUpdate = true;
				}
				npc.velocity += new Vector2(0, -.35f);
				if (Math.Abs(npc.velocity.X) < 4)
				{
					npc.velocity += new Vector2(npc.direction * .4f, 0);
				}
				if (AI_Timer > AI_FlutterTime)
				{
					AI_State = State_Fall;
					AI_Timer = 0;
				}
			}
			else if (AI_State == State_Fall)
			{
				if (npc.velocity.Y == 0)
				{
					npc.velocity.X = 0;
					AI_State = State_Asleep;
					AI_Timer = 0;
				}
			}
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
				else
				{
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
				else
				{
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