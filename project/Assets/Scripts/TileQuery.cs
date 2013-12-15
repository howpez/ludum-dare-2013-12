using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sophie
{
	public class TileQuery
	{
		private TileGrid grid;

		public TileQuery() {
			grid = GameObject.Find ("grid").GetComponent<TileGrid>();
		}

		public TileBehavior FindTileAt(int x, int y)
		{
			return grid.Tiles[x + y * grid.width];
		}

		public List<TileBehavior> FindBuildableTiles()
		{
			TileBehavior[] tiles = grid.Tiles;
			bool[] visited = new bool[tiles.Length];
			ColonyBehavior colony = GameObject.Find ("colony").GetComponent<ColonyBehavior> ();
			return FindEmptyAdjacent ((int)colony.Nucleus.transform.position.x, (int)colony.Nucleus.transform.position.y,
			                          tiles, visited);
		}

		private List<TileBehavior> FindEmptyAdjacent(int x, int y, TileBehavior[] tiles, bool[] visited)
		{
			List<TileBehavior> res = new List<TileBehavior> ();
			int idx = y * grid.width + x;
			if (visited [idx])
				return res;
			visited [idx] = true;

			if (tiles [idx].Cell == null) {
				res.Add (tiles [idx]);
			} else {
				if (x > 0) {
					res.AddRange (FindEmptyAdjacent (x - 1, y, tiles, visited));
				}
				if (x < grid.width - 1) {
					res.AddRange (FindEmptyAdjacent (x + 1, y, tiles, visited));
				}
				if (y > 0) {
					res.AddRange (FindEmptyAdjacent (x, y - 1, tiles, visited));
				}
				if (y < grid.height - 1) {
					res.AddRange (FindEmptyAdjacent (x, y + 1, tiles, visited));
				}
			}
			return res;
		}

		public bool CanBuildAt(int x, int y) 
		{
			if (grid.Tiles [x + y * grid.width].Cell != null) 
				return false;

			// check adjacent tiles
			if (x > 0) {
				if (grid.Tiles[x - 1 + y * grid.width].Cell != null)
					return true;
			}
			if (x < grid.width - 1) {
				if (grid.Tiles[x + 1 + y * grid.width].Cell != null)
					return true;
			}
			if (y > 0) {
				if (grid.Tiles[x + (y - 1) * grid.width].Cell != null)
					return true;
			}
			if (y < grid.height - 1) {
				if (grid.Tiles[x + (y + 1) * grid.width].Cell != null)
					return true;
			}
			return false;
		}
	}
}
