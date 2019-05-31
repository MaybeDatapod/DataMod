using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Items
{
    public class DataCells : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Data Cells");
			Tooltip.SetDefault("The stuff of Datapods");
		}
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 99;
            item.value = 100;
            item.rare = 1;
        }
    }
}
