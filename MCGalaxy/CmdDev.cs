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
		Command compilecmd = Command.Find("Compile");
		Command plugincmd  = Command.Find("Plugin");
		if (message.Length == 0 || message.ToLower() == "plugin") { Help(p); return; }
		if (message.ToLower().StartsWith("plugin")) {
			string newmessage = message.Split("plugin ")[1];
			compilecmd.Use(p, "plugin " + newmessage);
			plugincmd.Use(p, "unload " + newmessage);
			plugincmd.Use(p, "load " + newmessage);
			return;
		}
		compilecmd.Use(p, message);
		Command.Find("CmdUnload").Use(p, message);
		Command.Find("CmdLoad").Use(p, message);
		return;
	}
	public override void Help(Player p)
	{
		p.Message("&T/Dev");
		p.Message("&HCompiles, unloads, and loads a command or plugin.");
	}
}
