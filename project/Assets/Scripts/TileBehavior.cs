using UnityEngine;
using System.Collections;

public class TileBehavior : MonoBehaviour {

	public int x;
	public int y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {
		GameObject o = GameObject.Find ("selector");
		if (o != null) {
			o.transform.position = this.transform.position;
		}
	}

	void OnMouseDown() {
		GameObject grid = GameObject.Find ("grid");
		TileGrid tg = grid.GetComponent<TileGrid> ();
		GameObject tileOnUp = tg.getTileAt (x, y + 1);
		TileBehavior tb = tileOnUp.GetComponent<TileBehavior>();
		print (string.Format ("x: {0}, y: {1}", tb.x, tb.y));
	}
}
