using System;

namespace Sophie
{
	public enum TileType {
		Empty,
		Blocked
	};

	public class TileGridGenerator
	{
		public TileGridGenerator ()
		{

		}

		public TileType[] GenerateEmpty(int width, int height) {
			TileType[] map = new TileType[width * height];
			for (int i = 0; i < map.Length; i++) {
				map[i] = TileType.Empty;
			}
			return map;
		}
	}
}
