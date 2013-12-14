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
				o.transform.parent = this.transform;
				o.transform.position = new Vector2(.5f * x, .5f * y);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
