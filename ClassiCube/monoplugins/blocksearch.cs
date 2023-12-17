using System;
using ClassiCube;

namespace ClassiCube
{
	public class BlockSearchPlugin : Plugin
	{
		public override string Name { get { return "BlockSearchPlugin"; } }
		public override int PluginApiVersion { get { return 1; } }
		public override void Run() {
			Command.Register(new BlockSearchCommand());
		}
		
		public class BlockSearchCommand : Command {
			public override string Name { get { return "blocksearch"; } }
			public override void Help() {
				Chat.Add("&a/client monocmd blocksearch [block]");
				Chat.Add("&eSearches for the specified block.");
				Chat.Add("&eReturns the coordinates of each block found.");
			}
			public override void Execute(string args) {
				if (args.Length == 0 || args == null) {
					Help();
					return;
				}
				int block;
				if (!int.TryParse(args, out block)) {
					Chat.Add("Could not parse {0} as an integer.", args);
					return;
				}
				for (int y = 0; y < World.GetHeight(); y++) {
					for (int x = 0; x < World.GetWidth(); x++) {
						for (int z = 0; z < World.GetLength(); z++) {
							if (World.GetBlock(x,y,z) == block)
								Chat.Add( " ".Join(x,y,z) );
						}
					}
				}
			}
		}
	}
}