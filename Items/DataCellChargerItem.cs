using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
 
namespace DataMod.Items      //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class DataCellChargerItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Data Cell Charger");
		}
        public override void SetDefaults()
        {
            item.width = 22;  //The size of the width of the hitbox in pixels.
            item.height = 32;   //The size of the height of the hitbox in pixels.
            item.maxStack = 1;  //This defines the items max stack
            item.useTurn = true;   //
            item.autoReuse = true;     //Weather your item will be used again after use while holding down, if false you will need to click again after use to use it again.
            item.useAnimation = 15;  //How long the item is used for.
            item.useTime = 10;     //How fast the item is used.
            item.useStyle = 1;    //The way your Weapon will be used, 1 is the regular sword swing for example
            item.consumable = true;   //Tells the game that this should be used up once placed
            item.rare = 10;   //The color the title of your Weapon when hovering over it ingame  
            item.value = Item.buyPrice(0, 50, 0, 0); // How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10gold)
            item.createTile = mod.TileType("DataCellCharger");  //This defines what type of tile this item will place   
        }
    }
}