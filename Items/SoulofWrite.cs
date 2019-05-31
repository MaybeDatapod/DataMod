using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace DataMod.Items
{
    public class SoulofWrite : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of Write");
			Tooltip.SetDefault("The essence of reading and writing skills");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = 100;
            item.rare = 5;
            item.maxStack = 999;
        }
    }
}