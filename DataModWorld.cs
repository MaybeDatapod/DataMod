using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
using Terraria.ModLoader.IO;

namespace DataMod
{
	public class DataModWorld : ModWorld
	{
		private const int saveVersion = 0;
		public static bool downedDataboss = false;
		public override void Initialize()
		{
			downedDataboss = false;
		}
		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedDataboss) downed.Add("Databoss");


			return new TagCompound {
				{"downed", downed}
			};
		}

		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedDataboss = downed.Contains("Databoss");
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedDataboss = flags[0];
			}
			else
			{
				ErrorLogger.Log("DataMod: Unknown loadVersion: " + loadVersion);
			}
		}

		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = downedDataboss;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedDataboss = flags[0];
		}

	}
}