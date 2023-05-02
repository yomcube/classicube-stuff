using System;
using MCGalaxy;
namespace MCGalaxy {
	internal static class LCStuff {
		public static Random rnd = new Random();
		
		/* How much you need to pay */
		public static int amount = 5;
		/* The height of the multiplier's RNG */
		public static int multiplierheight = 6;
		public static int multiplier;
		
		public static string[] options = {
				"♥",
				"♦",
				"♣",
				"♠",
				"☻"
		};
		public static string[] column1 = {"", "", "", "", ""};
		public static string[] column2 = {"", "", "", "", ""};
		
		public static string currency;
		
		public static void Initialize() {
			for (int i=0; i < column1.Length; i++) {
				column1[i] = options[rnd.Next(options.Length)];
			}
			for (int i=0; i < column2.Length; i++) {
				column2[i] = options[rnd.Next(options.Length)];
			}
			multiplier = rnd.Next(multiplierheight);
			currency   = new ServerConfig().Currency; 
		}
	}
	public class CmdLuckyChance : Command
	{
		public override string name { get { return "LuckyChance"; } }
		public override string shortcut { get { return "lc"; } }
		public override string type { get { return "other"; } }
		public override bool museumUsable { get { return true; } }
		public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
		public override void Use(Player p, string message)
		{
			LCStuff.Initialize();
			if (p.money < LCStuff.amount) {
				p.Message("&fNot enough " + LCStuff.currency);
				return;
			}
			p.SetMoney(p.money - LCStuff.amount);
			
			// Not sure why column1 and column2 wouldn't be the
			// same length, but here's a check for it just in case.
			if (LCStuff.column1.Length != LCStuff.column2.Length) {
				p.Message("&cInternal error.");
				Logger.Log(LogType.Error, "LuckyChance: column1 and column2 are different lengths.");
				return;
			}
			int matched = 0;
			for (int i=0; i < LCStuff.column1.Length && i < LCStuff.column2.Length; i++) {
				string color = "&c";
				if (LCStuff.column1[i] == LCStuff.column2[i]) {matched++; color = "&a";}
				p.Message(string.Format("{0}{1} &f: {0}{2}", color, LCStuff.column1[i], LCStuff.column2[i]));
			}
			p.Message(string.Format("&fMultiplier: {0}", LCStuff.multiplier));
			p.Message(string.Format("&f{1} {0} earned",
				LCStuff.currency,
				matched * LCStuff.multiplier));
			p.SetMoney(p.money + (matched * LCStuff.multiplier));
		}
		public override void Help(Player p)
		{
			p.Message("&T/LuckyChance");
			p.Message(string.Format("&HA chance to get up to {0} {1} by paying {2} {1}",
				(LCStuff.column1.Length * LCStuff.multiplierheight),
				new ServerConfig().Currency,
				LCStuff.amount));
			p.Message();
			p.Message("Made by TomCube2");
			p.Message("His website is https://yomcube.github.io");
		}
	}
}
