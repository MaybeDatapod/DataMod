using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace DataMod.Items
{
    public class ChargedCell : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charged Cells");
			Tooltip.SetDefault("Data Cells charged with magic energy");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = 100;
            item.rare = 5;
            item.maxStack = 999;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DataCells"), 5);
			recipe.AddIngredient(mod.ItemType("SoulofWrite"), 1);
			recipe.AddTile(null, "DataCellCharger");
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}