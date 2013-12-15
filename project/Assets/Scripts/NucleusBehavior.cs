using UnityEngine;
using System.Collections;

public class NucleusBehavior : CellBehavior {

	public NucleusBehavior() {
		typeData = Sophie.CellTypeData.Nucleus;
	}

	// Use this for initialization
	void Start () {
		Colorize ();
		GameObject.Find ("colony").GetComponent<ColonyBehavior>().AddCell (this);
		GameObject.Find ("grid").GetComponent<TileGrid> ().GetTileAt (0, 0).Cell = this;
		this.transform.position = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
