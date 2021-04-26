using Terraria;
using Terraria.ID;

namespace DuckingAround
{
    public class DuckingNetcode
    {
        public static void SyncWorld()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                return;
            }
            NetMessage.SendData(MessageID.WorldData);
        }
    }
}