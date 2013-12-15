﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TileGrid : MonoBehaviour {

	public int width;
	public int height;
	public GameObject tile;

	private TileBehavior[] tiles;


	// Use this for initialization
	void Start() {
		tiles = new TileBehavior[width * height];
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				GameObject o = (GameObject)Instantiate(tile);
				TileBehavior tb = (TileBehavior)o.GetComponent(typeof(TileBehavior));
				o.transform.parent = this.transform;
				o.transform.position = new Vector2(x, y);
				tb.x = x;
				tb.y = y;
				tiles[y * width + x] = tb;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public TileBehavior GetTileAt(int x, int y) {
		return tiles[x + y * width];
	}

	// checks for an empty neighbor tile
	public TileBehavior FindEmptyAdjacent(int x, int y) {
		for (int col = Math.Max(0, x - 1); col < Math.Min(width, x + 2); col++) {
			for (int row = Math.Max(0, y - 1); row < Math.Min(height, y + 2); row++) {
				if (tiles[row * width + col].Cell == null) {
					return tiles[row * width + col];
				}
			}
		}
		return null;
	}

	// returns all empty neighbor tiles
	public TileBehavior FindRandomEmptyAdjacent(int x, int y) {
		//make a list of empties
		List<TileBehavior> candidates = new List<TileBehavior>();
		for (int col = Math.Max(0, x - 1); col < Math.Min(width, x + 2); col++) {
			for (int row = Math.Max(0, y - 1); row < Math.Min(height, y + 2); row++) {
				if (tiles[row * width + col].Cell == null) {
					candidates.Add(tiles[row * width + col]);
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


}
