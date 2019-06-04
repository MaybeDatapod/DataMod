using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod.NPCs.Boss
{
    public class Databoss : ModNPC
    {
        public override void SetDefaults()
        {
            npc.aiStyle = 5;  //5 is the flying AI
            npc.lifeMax = 60000;   //boss life
            npc.damage = 75;  //boss damage
            npc.defense = 20;    //boss defense
            npc.knockBackResist = 0f;
            npc.width = 120;
            npc.height = 120;
            animationType = NPCID.DemonEye;   //this boss will behavior like the DemonEye
            Main.npcFrameCount[npc.type] = 4;    //boss frame/animation 
            npc.value = Item.buyPrice(0, 40, 75, 45);
            npc.npcSlots = 1f;
            npc.boss = true;  
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/istationboss");
            npc.netAlways = true;
			npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;﻿
        }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Databoss");
		}﻿
        
        public override void BossLoot(ref string name, ref int potionType)
        {
			DataModWorld.downedDataboss = true;
            potionType = ItemID.GreaterHealingPotion;   //boss drops
			int choice = Main.rand.Next(4);
				if (choice == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DatapodSword"), 1);
				}
				else if (choice == 1)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DataBlaster"), 1);
				}
				else if (choice == 2)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DatapodBook"), 1);
				}
				else if (choice == 3)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ComprehensionStaff"), 1);
				}
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DataCellChargerItem"), 1);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DataCells"), Main.rand.Next(15, 25));
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Databomb"), Main.rand.Next(15, 25));
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulofWrite"), Main.rand.Next(20, 40));
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Book, Main.rand.Next(5, 15));
			if (Main.rand.Next(9) == 0)
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DatabossTrophyItem"), 1);//this is where you set what item to drop ,ItemID.VileMushroom is an example of how to add vanila items , Main.rand.Next(5, 10) it's the quantity,so it will chose a number from 5 to 10
            }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.579f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 0.6f);  //boss damage increase in expermode
        }
		public override void AI()
        {
            npc.ai[0]++;
            Player P = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;
 
            npc.ai[1]++;
            if (npc.ai[1] >= 230)  // 230 is projectile fire rate
            {
                float Speed = 20f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 50;  //projectile damage
                int type = ProjectileID.DeathLaser;  //put your projectile
                Main.PlaySound(23, (int)npc.position.X, (int)npc.position.Y, 17);
                float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                npc.ai[1] = 0;
            }
            if (npc.ai[0] % 600 == 3)  //Npc spown rate
 
            {
                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Datapod"));  //NPC name
            }
            npc.ai[1] += 0;
            if (npc.life <= 20000) { //when the boss has less than 70 health he will do the charge attack
                npc.ai[2]++;                //Charge Attack
				npc.ai[3]++;
				npc.ai[1]--;
			}
            if (npc.ai[2] >= 20)
            {
                npc.velocity.X *= 0.98f;
                npc.velocity.Y *= 0.98f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 12) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 12) * -1;
                }
                //Dust
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                npc.ai[2] = -300;
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
                int count = 30;
                for (int i = 1; i <= count; i++)
                {
                    int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 6, 0, 0, 100, color, 2.5f);
                    Main.dust[dust].noGravity = false;
                }
                return;
            }
			if (npc.ai[3] >= 30)  // 230 is projectile fire rate
            {
                float Speed = 20f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 50;  //projectile damage
                int type = ProjectileID.DeathLaser;  //put your projectile
                Main.PlaySound(23, (int)npc.position.X, (int)npc.position.Y, 17);
                float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                npc.ai[3] = 0;
            }
        }
    }
}