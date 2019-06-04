using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Items.Placeable
{
	public class DatapodOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Datapod Ore");
		}

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = mod.TileType("DatapodOre");
			item.width = 12;
			item.height = 12;
			item.value = 1500;
		}
	}
}