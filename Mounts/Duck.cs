using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using DuckingAround.Buffs;

namespace DuckingAround.Mounts
{
    public class Duck : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.buff = ModContent.BuffType<DuckMount>();
			mountData.heightBoost = 0;
			mountData.fallDamage = 0f;
			mountData.runSpeed = 11f;
			mountData.dashSpeed = 8f;
			mountData.flightTimeMax = 60;
			mountData.fatigueMax = 0;
			mountData.jumpHeight = 5;
			mountData.acceleration = 0.19f;
			mountData.jumpSpeed = 4f;
			mountData.blockExtraJumps = false;
			mountData.totalFrames = 12;
			mountData.constantJump = true;
			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 10;
			}
			mountData.playerYOffsets = array;
			mountData.xOffset = 9;
			mountData.bodyFrame = 4;
			mountData.yOffset = 4;
			mountData.playerHeadOffset = 3;
			mountData.standingFrameCount = 1;
			mountData.standingFrameDelay = 24;
			mountData.standingFrameStart = 9;
			mountData.runningFrameCount = 4;
			mountData.runningFrameDelay = 24;
			mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 4;
            mountData.flyingFrameDelay = 6;
            mountData.flyingFrameStart = 4;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 24;
            mountData.inAirFrameStart = 6;
            mountData.idleFrameCount = 1;
            mountData.idleFrameDelay = 24;
            mountData.idleFrameStart = 9;
            mountData.idleFrameLoop = true;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
			if (Main.netMode == NetmodeID.Server)
            {
				return;
			}
			mountData.textureWidth = mountData.backTexture.Width;
			mountData.textureHeight = mountData.backTexture.Height;
		}
		public override void UpdateEffects(Player player)
        {
			if (Main.raining)
			{
				mountData.flightTimeMax = 999999999;
			}
			if (!Main.raining)
			{
				mountData.flightTimeMax = 60;
			}
			if (!(Math.Abs(player.velocity.X) > 4f))
            {
				return;
			}
			Rectangle rect = player.getRect();
		}
		internal class DuckSpecificData
		{
			internal int count;
			internal float[] rotations;
			public DuckSpecificData()
			{
				count = 3;
				rotations = new float[count];
			}
		}
		public override void SetMount(Player player, ref bool skipDust)
        {
			player.mount._mountSpecificData = new DuckSpecificData();
		}
	}
}