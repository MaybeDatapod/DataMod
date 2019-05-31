using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Items.Weapons
{
	public class DatapodSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Datapod's Wrath");
			Tooltip.SetDefault("Do you have the right stuff?");
		}
		public override void SetDefaults()
		{
			item.damage = 139;
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 100000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DatapodProjectile");
			item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 6);
			recipe.AddIngredient(ItemID.Nanites, 12);
			recipe.AddIngredient(ItemID.TerraBlade, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
