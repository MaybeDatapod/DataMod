using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.Projectiles
{

    public class DatapodProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 44;       //projectile width
            projectile.height = 44;  //projectile height
			projectile.aiStyle = 8;
            projectile.friendly = true;      //make that the projectile will not damage you
            projectile.melee = true;         // 
            projectile.tileCollide = true;   //make that the projectile will be destroed if it hits the terrain
            projectile.penetrate = 2;      //how many npc will penetrate
            projectile.timeLeft = 230;   //how many time this projectile has before disepire
            projectile.light = 0.75f;    // projectile light
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;  
        }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DatapodProjectile");
		}﻿
        public override void AI()           //this make that the projectile will face the corect way
        {                                                           // |
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;  
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 74, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
        }
    }
}