using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DataMod {
public class DataMod : Mod
{
	static internal DataMod instance;
    public DataMod()
    {

       Properties = new ModProperties()
		{
			Autoload = true,
			AutoloadSounds = true,
			AutoloadGores = true

		};
		
    }
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if(bossChecklist != null)
            {
                 bossChecklist.Call("AddBossWithInfo", "Databoss", 9.5f, (Func<bool>)(() => DataModWorld.downedDataboss), "Use a [i:" + ItemType("SuspiciousStatistics") + "] at night");
            }

        }
}
}