using UnityEngine;
using System.Collections;

public class TileGridInstantiation : MonoBehaviour {

	public int width;
	public int height;
	public GameObject tile;

	// Use this for initialization
	void Start() {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				GameObject o = (GameObject)Instantiate(tile);
				o.transform.position = new Vector2(x, y);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
