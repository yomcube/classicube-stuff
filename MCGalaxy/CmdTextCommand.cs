using System;
using System.IO;
using MCGalaxy;
public class CmdTextCommand : Command
{
	public override string name { get { return "TextCommand"; } }
	public override string shortcut { get { return "txtcmd"; } }
	public override string type { get { return "Information"; } }
	public override bool museumUsable { get { return true; } }
	public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
	public const string textcommanddir = "textcommands";
	public override void Use(Player p, string message)
	{
		if (message.Length == 0) { Help(p); return; }
		if (!Directory.Exists(textcommanddir)) { Directory.CreateDirectory(textcommanddir); }
		string file = string.Format("{0}/{1}.txt", textcommanddir, message.ToLower());
		if (!File.Exists(file)) { p.Message("&c" + file + " does not exist."); return; }
		foreach (string line in File.ReadAllLines(file)) {
			p.Message(line);
		}
	}
	public override void Help(Player p)
	{
		p.Message("&T/TextCommand");
		p.Message("&HReads the contents of a file in " + textcommanddir + "/");
	}
}