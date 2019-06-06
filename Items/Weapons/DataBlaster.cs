using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Items.Weapons
{
    public class DataBlaster : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Data Blaster");
		}
        public override void SetDefaults()
        {
            item.damage = 29;
            item.ranged = true;
            item.width = 44;
            item.height = 17;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 100000;
            item.rare = 2;
            item.UseSound = SoundID.Item40;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 4f;
            item.useAmmo = AmmoID.Bullet;
        }
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 0);
		}
    }
}