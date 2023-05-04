using System;
using MCGalaxy;

public class CmdDev : Command
{
	public override string name { get { return "Dev"; } }
	public override string type { get { return "other"; } }
	public override bool museumUsable { get { return true; } }
	public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
	public override void Use(Player p, string message)
	{
		if (message.Length == 0) { Help(p); return; }
		try {
			Command.Find("Compile").Use(p, message);
		} catch {}
		try {
			Command.Find("CmdUnload").Use(p, message);
		} catch {}
		Command.Find("CmdLoad").Use(p, message);
	}
	public override void Help(Player p)
	{
		p.Message("&T/Dev");
		p.Message("&HCompiles, unloads, and loads a command.");
	}
}