using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Items
{
    public class DatapodBar : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Datapod Bar");
		}
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 24;
            item.maxStack = 999;
            item.value = 8000;
            item.rare = 7;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DatapodOre"), 4);
			recipe.AddIngredient(mod.ItemType("DataCells"), 1);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
