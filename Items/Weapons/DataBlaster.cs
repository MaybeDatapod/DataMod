using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Items.Weapons
{
    public class DataBlaster : ModItem
    {
	int shot = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Data Blaster");
		}
        public override void SetDefaults()
        {
            item.damage = 29;
            item.ranged = true;
            item.width = 88;
            item.height = 34;
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
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			shot++;
			if (shot == 4) {
				shot = 0;
			}
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(-3+(shot*2)));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
    }
}