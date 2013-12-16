using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

using Sophie;

public class TileGrid : MonoBehaviour {

	public int width;
	public int height;
	public GameObject tile;
	public GameObject highlight;

	private TileBehavior[] tiles;
	private TileType[] map;
	private Stack<GameObject> highlights = new Stack<GameObject>();
	private EventDelegate placeCellDelegate;

	public TileBehavior[] Tiles {
		get { return tiles; }
	}

	TileGrid()
	{
		placeCellDelegate = new EventDelegate (OnPlaceCell);
	}

	// Use this for initialization
	void Start() {
		TileGridGenerator gen = new TileGridGenerator ();
		map = gen.GenerateEmpty (width, height);
				
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
		Events.Listen ("PlaceCell", placeCellDelegate);
	}
	
	void OnDisable()
	{
		if (!gameObject.activeSelf)
		{
			Events.Cancel("PlaceCell", placeCellDelegate);
		}
	}

	public void OnPlaceCell(object args) {
		ClearHighlights ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void HighlightBuildableCells() {
		ClearHighlights ();
		TileQuery q = new TileQuery ();
		List<TileBehavior> res = q.FindBuildableTiles ();
		foreach (TileBehavior tb in res) {
			GameObject clone = (GameObject)Instantiate(highlight);
			clone.transform.parent = tb.transform;
			clone.transform.position = tb.transform.position;
			highlights.Push(clone);
		}
	}

	public void ClearHighlights() {
		while (highlights.Count > 0) {
			Destroy(highlights.Pop());
		}
	}
}
