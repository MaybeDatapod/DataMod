using Terraria.ModLoader;

namespace DataMod.Items.Placeable
{
	public class DatabossTrophyItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Databoss Trophy");
			Tooltip.SetDefault("You had the right stuff");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;			
			item.rare = 1;
			item.createTile = mod.TileType("DatabossTrophy");
			item.placeStyle = 0;
		}
	}
}