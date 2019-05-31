using System; //what sources the code uses, these sources allow for calling of terraria functions, existing system functions and microsoft vector functions (probably more)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Projectiles //where it's stored. Replace Mod with the name of your mod. This file is stored in the folder \Mod Sources\(mod name, folder can't have spaces)\Projectiles.
{
    public class MagicCell : ModProjectile //the class of the projectile. Change EtherealBullet to the ID of your projectile. The ID has to match the name of the sprite for that item in your folder and can have no spaces.
    {
        public override void SetDefaults()
        {
            projectile.width = 44; //sprite is 2 pixels wide
            projectile.height = 44; //sprite is 20 pixels tall
            projectile.aiStyle = 3; //projectile moves in a straight line
            projectile.friendly  = true; //player projectile
            projectile.magic = true;
            projectile.timeLeft = 150; //lasts for 600 frames/ticks. Terraria runs at 60FPS, so it lasts 10 seconds.
			projectile.tileCollide = false;
			projectile.penetrate = 5;
        }
        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 74, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);   //spawns dust behind it, this is a spectral light blue dust. 15 is the dust, change that to what you want.
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(31, 180, false);
            target.AddBuff(32, 180, false);
			target.AddBuff(39, 180, false);
			target.AddBuff(68, 180, false);
        }

    }
}