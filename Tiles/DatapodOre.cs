using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Tiles
{
    public class DatapodOre : ModTile
    {
        public override void SetDefaults()
        {
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 675;
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("DatapodOre");   //put your CustomBlock name
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Datapod Ore");
            AddMapEntry(new Color(100, 200, 100), name);
			soundType = 21;
			soundStyle = 1;
			mineResist = 4f;
			minPick = 180;
        }
      
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 0.25f;
            g = 0.75f;
            b = 0.25f;
        }
    }
}
