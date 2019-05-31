using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Items
{
    public class SuperchargedStatistics : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Supercharged Statistics");
			Tooltip.SetDefault("Use at your own risk.");
		}
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 100;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {           
            return !NPC.AnyNPCs(mod.NPCType("Databoss"));  //you can't spawn this boss multiple times
            return !Main.dayTime;   //can use only at night
        }
        public override bool UseItem(Player player)
        {
			for (int i = 0; i < 100; i++) {
				NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Databoss"));   //boss spawn
			}
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);

            return true;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ChargedCell"), 300);
			recipe.AddIngredient(ItemID.Wire, 100);
			recipe.AddIngredient(ItemID.SoulofLight, 100);
			recipe.AddIngredient(ItemID.SoulofSight, 50);
			recipe.AddIngredient(ItemID.Book, 10);
			recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
