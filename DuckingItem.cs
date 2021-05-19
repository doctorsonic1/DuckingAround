using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DuckingAround.Items.Potions;
using DuckingAround.Items.Placeable;
using DuckingAround.Items.Materials;
using DuckingAround.Items.SpawnItems;
using DuckingAround.Items.Accessories;
using DuckingAround.Items.Weapons.Guns;
using DuckingAround.Items.Weapons.Melee;
using DuckingAround.Items.Weapons.Yoyos;
using DuckingAround.Items.Weapons.Duckies;

namespace DuckingAround
{
    public class DuckingItem : GlobalItem
	{
		public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (item.type == ItemID.PlatinumCoin || item.type == ItemID.GoldCoin || item.type == ItemID.SilverCoin || item.type == ItemID.CopperCoin
				|| item.type == ItemID.Feather || item.type == ItemID.GiantHarpyFeather || item.type == ItemID.WyvernBanner || item.type == ItemID.HarpyBanner)
            {
                ItemID.Sets.ItemNoGravity[item.type] = true;
            }
        }
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.GuideVoodooDoll)
            {
                item.consumable = true;
                item.useAnimation = 15;
                item.useTime = 15;
                item.useStyle = ItemUseStyleID.SwingThrow;
            }
        }
        public override bool UseItem(Item item, Player player)
        {
            if (item.type == ItemID.GuideVoodooDoll)
            {
                player.DropSelectedItem();
                ItemID.Sets.ItemNoGravity[item.type] = false;
                return true;
            }
            else
            {
                return false;
            }
		}
		public override void AddRecipes()
		{
			//accessory crafting recipes

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("DuckingAround:IronBars", 20);
			recipe.AddRecipeGroup("DuckingAround:SilverBars", 2);
			recipe.AddRecipeGroup("DuckingAround:GoldBars", 2);
			recipe.AddRecipeGroup("DuckingAround:CopperBars", 2);
			recipe.AddIngredient(ItemID.Wire, 50);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.MetalDetector);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 20);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddIngredient(ItemID.GravityGlobe);
			recipe.AddIngredient(ItemID.Hoverboard);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ModContent.ItemType<Hoverboard>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(ItemID.GravitationPotion, 15);
			recipe.AddIngredient(ItemID.FeatherfallPotion, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.GravityGlobe);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofFlight, 100);
			recipe.AddIngredient(ItemID.WingsNebula);
			recipe.AddIngredient(ItemID.WingsSolar);
			recipe.AddIngredient(ItemID.WingsStardust);
			recipe.AddIngredient(ItemID.WingsNebula);
			recipe.AddIngredient(ItemID.GiantHarpyFeather);
			recipe.AddIngredient(ItemID.BrokenBatWing);
			recipe.AddIngredient(ItemID.FireFeather);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ModContent.ItemType<InfiniteFlightAccessory>());
			recipe.AddRecipe();

			//duck crafting recipes

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MallardDuck, 25);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(ItemID.Duck, 25);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Explosives);
			recipe.AddIngredient(ItemID.Duck, 20);
			recipe.AddTile(ModContent.TileType<Tiles.HephaestusForge>());
			recipe.SetResult(ModContent.ItemType<NukeDucky>(), 20);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RocketIII, 20);
			recipe.AddIngredient(ModContent.ItemType<NukeDucky>(), 5);
			recipe.AddTile(ModContent.TileType<Tiles.HephaestusForge>());
			recipe.SetResult(ModContent.ItemType<NukeDuckyItem>(), 20);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Duck);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ModContent.ItemType<Ducky>(), 50);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Duck);
			recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ModContent.ItemType<IronDucky>(), 50);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Duck);
			recipe.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ModContent.ItemType<MeteorDucky>(), 50);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Duck);
			recipe.AddIngredient(ModContent.ItemType<Rubber>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ModContent.ItemType<RubberDucky>(), 50);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Duck);
			recipe.AddIngredient(ModContent.ItemType<PlatyrhynchiumBar>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ModContent.ItemType<PlatyrhynchiumDucky>(), 50);
			recipe.AddRecipe();


			//material crafting

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PlatyrhynchiumOre>(), 6);
			recipe.AddTile(ModContent.TileType<Tiles.HephaestusForge>());
			recipe.SetResult(ModContent.ItemType<PlatyrhynchiumBar>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Sap>(), 3);
			recipe.AddIngredient(ModContent.ItemType<Acid>(), 1);
			recipe.AddTile(ModContent.TileType<Tiles.Coagulator>());
			recipe.SetResult(ModContent.ItemType<Rubber>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddTile(ModContent.TileType<Tiles.Coagulator>());
			recipe.SetResult(ModContent.ItemType<AmalgamatedSoul>(), 5);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AmalgamatedSoul>());
			recipe.AddTile(ModContent.TileType<Tiles.Electrolyzer>());
			recipe.SetResult(ItemID.SoulofSight, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AmalgamatedSoul>());
			recipe.AddTile(ModContent.TileType<Tiles.Electrolyzer>());
			recipe.SetResult(ItemID.SoulofFright, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AmalgamatedSoul>());
			recipe.AddTile(ModContent.TileType<Tiles.Electrolyzer>());
			recipe.SetResult(ItemID.SoulofMight, 3);
			recipe.AddRecipe();

			//tile item crafting recipes

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.VortexMonolith, 1);
			recipe.AddIngredient(ItemID.NebulaMonolith, 1);
			recipe.AddIngredient(ItemID.StardustMonolith, 1);
			recipe.AddIngredient(ItemID.SolarMonolith, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(ModContent.ItemType<PlatyrhynchiumBar>(), 15);
			recipe.AddIngredient(ModContent.ItemType<IronDucky>(), 150);
			recipe.AddIngredient(ModContent.ItemType<RubberDucky>(), 150);
			recipe.AddIngredient(ModContent.ItemType<MeteorDucky>(), 150);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<Items.Placeable.DuckyTotemItem>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wire, 50);
			recipe.AddIngredient(ModContent.ItemType<MachineParts>(), 25);
			recipe.AddIngredient(ModContent.ItemType<Rubber>(), 15);
			recipe.AddIngredient(ItemID.EmptyBucket, 3);
			recipe.AddIngredient(ItemID.HoneyDispenser);
			recipe.AddRecipeGroup("DuckingAround:IronBars", 15);
			recipe.AddRecipeGroup("DuckingAround:GoldBars", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<Items.Placeable.CoagulatorItem>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wire, 50);
			recipe.AddIngredient(ModContent.ItemType<MachineParts>(), 25);
			recipe.AddIngredient(ModContent.ItemType<Rubber>(), 15);
			recipe.AddIngredient(ItemID.BottomlessBucket);
			recipe.AddIngredient(ItemID.SteampunkBoiler);
			recipe.AddRecipeGroup("DuckingAround:IronBars", 15);
			recipe.AddRecipeGroup("DuckingAround:GoldBars", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<Items.Placeable.ElectrolyzerItem>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteForge, 1);
			recipe.AddIngredient(ItemID.MythrilAnvil, 1);
			recipe.AddIngredient(ItemID.CrystalBall, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(ModContent.ItemType<PlatyrhynchiumOre>(), 35);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<HephaestusForge>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumForge, 1);
			recipe.AddIngredient(ItemID.OrichalcumAnvil, 1);
			recipe.AddIngredient(ItemID.CrystalBall, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(ModContent.ItemType<PlatyrhynchiumOre>(), 35);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<HephaestusForge>());
			recipe.AddRecipe();

			//potion crafting recipes

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddIngredient(ItemID.IronPickaxe);
			recipe.AddIngredient(ItemID.Wood);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(ModContent.ItemType<ChugJug>());
			recipe.AddRecipe();

			//spawn item crafting recipes

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 30);
			recipe.AddIngredient(ItemID.MythrilBar, 30);
			recipe.AddIngredient(ItemID.CobaltBar, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<EnemySpawnerSpawn>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 30);
			recipe.AddIngredient(ItemID.OrichalcumBar, 30);
			recipe.AddIngredient(ItemID.PalladiumBar, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<EnemySpawnerSpawn>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarOre, 20);
			recipe.AddIngredient(ItemID.SpectreBar, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<PsionSpawn>());
			recipe.AddRecipe();

			//yoyo crafting recipes

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.CorruptYoyo);
			recipe.AddIngredient(ItemID.HelFire);
			recipe.AddIngredient(ItemID.Chik);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<DestinyYoYo>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.CrimsonYoyo);
			recipe.AddIngredient(ItemID.HelFire);
			recipe.AddIngredient(ItemID.Chik);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<DestinyYoYo>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.Amarok);
			recipe.AddIngredient(ItemID.Kraken);
			recipe.AddIngredient(ItemID.Code1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<BountyHunterYoYo>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.WoodYoyo);
			recipe.AddIngredient(ItemID.Gradient);
			recipe.AddIngredient(ItemID.Yelets);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<FreedomYoYo>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.TheEyeOfCthulhu);
			recipe.AddIngredient(ItemID.FormatC);
			recipe.AddIngredient(ItemID.Rally);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<PegasusYoYo>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<PegasusYoYo>());
			recipe.AddIngredient(ModContent.ItemType<DestinyYoYo>());
			recipe.AddIngredient(ModContent.ItemType<FreedomYoYo>());
			recipe.AddIngredient(ModContent.ItemType<BountyHunterYoYo>());
			recipe.AddIngredient(ModContent.ItemType<PlatyrhynchiumBar>(), 14);
			recipe.AddIngredient(ItemID.Terrarian, 1);
			recipe.AddIngredient(ItemID.YoyoBag, 1);
			recipe.AddTile(ModContent.TileType<Tiles.HephaestusForge>());
			recipe.SetResult(ModContent.ItemType<QuackYo>());
			recipe.AddRecipe();

			//melee weapon crafting

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<PlatyrhynchiumBar>(), 18);
			recipe.AddIngredient(ItemID.SoulofMight, 12);
			recipe.AddIngredient(ItemID.SoulofLight, 12);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(ModContent.TileType<Tiles.HephaestusForge>());
			recipe.SetResult(ModContent.ItemType<DuckyWrath>());
			recipe.AddRecipe();

			//ranged weapon crafting
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<PlatyrhynchiumBar>(), 15);
			recipe.AddIngredient(ModContent.ItemType<NukeDucky>(), 15);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(ItemID.FireworksLauncher);
			recipe.AddIngredient(ItemID.RocketLauncher);
			recipe.AddTile(ModContent.TileType<Tiles.HephaestusForge>());
			recipe.SetResult(ModContent.ItemType<FowlPlay>());
			recipe.AddRecipe();

			//tool crafting recipes

			recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("DuckingAround:IronBars", 5);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.EmptyBucket);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ModContent.ItemType<Items.Tools.SapTap>());
			recipe.AddRecipe();
		}
	}
}