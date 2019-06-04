using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace DataMod.NPCs
{
    public class NpcDrops : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
 
            if (npc.type == mod.NPCType("Databoss")) //this is where you choose what vanilla npc you want  , for a modded npc add this instead  if (npc.type == mod.NPCType("ModdedNpcName"))
            {
                if (!DataModWorld.spawnOre)
                {                                                          //Red  Green Blue
                    Main.NewText("The ground sparkles with green", 100, 200, 100);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lover value if you want less vains ore or higher value for more veins ore
                    {
                        int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 200); //this is the coordinates where the veins ore will spawn, so in Cavern layer
                        WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), mod.TileType("DatapodOre"), false, 0f, 0f, false, true);
                    }
                }
                DataModWorld.spawnOre = true;   //so the message and the ore spawn does not proc(show) when you kill EoC/npc again
            }
 }
         
    }
}