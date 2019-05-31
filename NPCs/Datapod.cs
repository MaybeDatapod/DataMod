using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

                                                            //By Al0n37
namespace DataMod.NPCs
{
    public class Datapod : ModNPC
    {
        public override void SetDefaults()
        {
            npc.width = 50;
            npc.height = 40;
            npc.damage = 20;
            npc.defense = 5;
            npc.lifeMax = 100;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 44;
            Main.npcFrameCount[npc.type] = 4; 
            aiType = NPCID.Harpy;  //npc behavior
            animationType = NPCID.Harpy;
			npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;﻿
        }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Datapod");
		}﻿

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			Tile tile = Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY];
            return spawnInfo.spawnTileY < Main.rockLayer && !Main.dayTime && spawnInfo.player.ZoneOverworldHeight ? 0.1f : 0f; //spown at day
        }
		
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter -= 0.2F; // Determines the animation speed. Higher value = faster animation.
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;

            npc.spriteDirection = npc.direction;
        }
        public override void NPCLoot()  //Npc drop
        {
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DataCells"), Main.rand.Next(0, 3)); //Item spawn
            }

        }
    }
}