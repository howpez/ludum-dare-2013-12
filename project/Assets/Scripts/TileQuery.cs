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

		// checks for an empty neighbor tile
		public TileBehavior FindEmptyAdjacent(int x, int y) {
			for (int col = Math.Max(0, x - 1); col < Math.Min(grid.width, x + 2); col++) {
				for (int row = Math.Max(0, y - 1); row < Math.Min(grid.height, y + 2); row++) {
					if (grid.Tiles[row * grid.width + col].Cell == null) {
						return grid.Tiles[row * grid.width + col];
					}
				}
			}
			return null;
		}
		
		// returns all empty neighbor tiles
		public TileBehavior FindRandomEmptyAdjacent(int x, int y) {
			//make a list of empties
			List<TileBehavior> candidates = new List<TileBehavior>();
			for (int col = Math.Max(0, x - 1); col < Math.Min(grid.width, x + 2); col++) {
				for (int row = Math.Max(0, y - 1); row < Math.Min(grid.height, y + 2); row++) {
					if (grid.Tiles[row * grid.width + col].Cell == null) {
						candidates.Add(grid.Tiles[row * grid.width + col]);
					}
				}		
			}
			if (candidates.Count > 0){
				//return a random one from the list
				System.Random rnd = new System.Random();
				int r = rnd.Next(0,candidates.Count);
				return candidates[r];
			}
			return null;
			
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
