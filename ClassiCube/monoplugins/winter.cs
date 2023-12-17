using System;
using ClassiCube;

namespace ClassiCube
{
	public class WinterPlugin : Plugin
	{
		public static bool Enabled = true;
		
		public override string Name { get { return "Winter"; } }
		public override int PluginApiVersion { get { return 1; } }
		public override void Run() {
			if (!Enabled || !Server.IsSingleplayer) return;
			Events.MapLoaded += OnMapLoaded;
		}
		public void OnMapLoaded(object sender, EventArgs e) {
			Env.SetWeather(2);
			Env.SetEdgeBlock(0);
			Env.SetSidesBlock(0);
			for (int i = 0; i < 6; i++)
				Block.ChangeTex(61, i, 50);
			for (int y = 0; y < World.GetHeight(); y++) {
				for (int x = 0; x < World.GetWidth(); x++) {
					for (int z = 0; z < World.GetLength(); z++) {
						int b = World.GetBlock(x,y,z);
						int b2 =
							b == 2 ? 61 :
							(
								b != 18 && y !=  0 &&
								(World.GetBlock(x,y-1,z) == 18)
							) ? 53 :
							b == 9 ? 60 :
							b == 37 ? 0 :
							b == 38 ? 0 :
							b;
						Game.SetBlock(x,y,z, b2);
					}
				}
			}
		}
	}
}