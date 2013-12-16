using UnityEngine;
using System.Collections;
using Sophie;

public class CellBehavior : MonoBehaviour {

	public CellTypeData typeData;
	protected ColonyBehavior colony;

	// Use this for initialization
	protected void Start () {
		colony = GameObject.Find ("colony").GetComponent<ColonyBehavior> ();
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
