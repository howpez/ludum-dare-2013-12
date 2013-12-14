using UnityEngine;
using System.Collections;

public class CellBehavior : MonoBehaviour {

	public Color color;

	// Use this for initialization
	void Start () {
		SpriteRenderer r = this.GetComponent<SpriteRenderer> ();
		if (r != null) {
			r.color = color;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
