using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using DuckingAround.Items.Accessories;

namespace DuckingAround
{
	public class DuckingPlayer : ModPlayer
	{
		private int _playerIndex = -1;
		public Player GameInstance => Main.player[this._playerIndex];

		public int defenseModifier = 1;
		public int damageTaken = 0;
		public int petCount = 0;
		public int timeCounter = 0;
		public int timeCounter2 = 0;

		public bool removeBuff;
		public bool DuckPet;
		public bool infiniteFlight = false;
		public bool removeDeathProt = true;
		public bool canTakeDamage = true;

		public Vector2 respawnSpot;

		public override void PostUpdateEquips()
		{
			Player player = Main.LocalPlayer;
			player.statDefense *= defenseModifier;
			if(timeCounter%300 == 1 && ModContent.GetInstance<ConfigClient>().ChugJugSound)
			{
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Buffs/ChugJug").WithVolume(.7f).WithPitchVariance(.5f));
			}
			if (infiniteFlight == true)
			{
				Main.LocalPlayer.wingTime = 1;
			}
		}
        public override void ResetEffects()
		{
			for (int i = 3; i < 8 + player.extraAccessorySlots; i++)
			{
				Item item = player.armor[i];

				if (item.type == ModContent.ItemType<InfiniteFlightAccessory>())
				{
					infiniteFlight = true;
				}
				else if (item.type != ModContent.ItemType<InfiniteFlightAccessory>())
				{
					infiniteFlight = false;
				}
			}
		}
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			DuckingPlayer modPlayer = Main.LocalPlayer.GetModPlayer<DuckingPlayer>();
			if(modPlayer.canTakeDamage == false)
			{
				damageTaken = 0;
				damage = 0;
				return true;
			}
			Player player = Main.LocalPlayer;
			if(player.HasBuff(mod.BuffType("DeathProtBuff")) && !player.dead)
			{
				damageTaken += Convert.ToInt32(damage) - 3;
				if(damageTaken >= player.statLife / 2)
				{
					player.position = modPlayer.respawnSpot;
					string takenDamage = Convert.ToString(modPlayer.damageTaken);
					Main.NewText(takenDamage, 40, 80, 100);
					damage = player.statLife / 2;
					damageTaken = 0; 
					removeBuff = true;
				}
			}
			return true;
		}
    }	
}