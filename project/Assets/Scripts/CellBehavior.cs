using UnityEngine;
using System.Collections;
using Sophie;

public class CellBehavior : MonoBehaviour {

	public CellTypeData typeData;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Colorize() {
		SpriteRenderer r = this.GetComponent<SpriteRenderer> ();
		if (r != null && typeData != null) {
			r.color = typeData.Color;
		}
	}
}
