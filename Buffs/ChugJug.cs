using Terraria.ModLoader;

namespace DuckingAround.Buffs
{
    public class ChugJug : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Chug Jug");
            Description.SetDefault("The child predators in the area are onto you.");
			canBeCleared = true;
        }
    }
}