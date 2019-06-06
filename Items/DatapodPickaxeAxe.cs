using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Items
{
	public class DatapodPickaxeAxe : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Datapod Pickaxe Axe");
		}

		public override void SetDefaults() {
			item.damage = 42;
			item.melee = true;
			item.width = 36;
			item.height = 48;
			item.useTime = 8;
			item.useAnimation = 21;
			item.pick = 200;
			item.axe = 24;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 10000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DatapodBar"), 18);
			recipe.AddIngredient(mod.ItemType("ChargedCell"), 18);
			recipe.AddTile(mod.TileType("DataCellCharger"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}