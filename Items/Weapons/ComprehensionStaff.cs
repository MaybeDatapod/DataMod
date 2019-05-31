using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Items.Weapons
{
	//imported from my tAPI mod because I'm lazy
	public class ComprehensionStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a Datapod to fight for you.");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
			item.summon = true;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("MiniPod");
			item.shootSpeed = 10f;
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return player.altFunctionUse != 2;
		}
		
		public override bool UseItem(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}
	}
}
