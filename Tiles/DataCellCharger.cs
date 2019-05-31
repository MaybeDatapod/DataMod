using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
 
namespace DataMod.Tiles
{
    public class DataCellCharger : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Data Cell Charger");
            AddMapEntry(new Color(209, 217, 217), name);    //this defines the color and the name when you see this tile in the map
            animationFrameHeight = 36;  //this is the sprite frame height
        }
 
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 48, mod.ItemType("DataCellChargerItem"));//this defines what to drop when this tile is destroyed
        }
 
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)      //this adds light to the tile
        {                    //light  color
            r = 0.40f;   //red
            g = 0.75f;    // green
            b = 0.36f;   //blue
        }
 
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 8)  //this is the frames speed, the bigger is the value the slower are the frames
            {
                frameCounter = 0;
                frame++;
                if (frame > 3)   //this is where you add how may frames your spritesheet has but -1, so if it has 4 frames you put 3 etc.
                {
                    frame = 0;
                }
            }
        }
    }
}