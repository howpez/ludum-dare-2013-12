using UnityEngine;
using System.Collections;

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
}
