using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace DataMod.Items.Weapons
{
    public class DatapodBook : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Book of Datapod");
		}
        public override void SetDefaults()
        {      
            item.damage = 123;                        
            item.magic = true;
            item.width = 28;
            item.height = 30;
            item.useTime = 15;
            item.useAnimation = 30;
            item.useStyle = 5;        //this is how the item is holded
            item.noMelee = true;
            item.knockBack = 2;        
            item.value = 100000;
            item.rare = 6;
            item.mana = 3;             //mana use
            item.UseSound = SoundID.Item21;            //this is the sound when you use the item
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("MagicCell");  //this make the item shoot your projectile
            item.shootSpeed = 16f;    //projectile speed when shoot
        }      
    }
}
