using UnityEngine;
using System.Collections;

using Sophie;

public class NucleusBehavior : CellBehavior {

	private TileGrid tileGrid;

	public NucleusBehavior() {
		typeData = Sophie.CellTypeData.Nucleus;
	}

	// Use this for initialization
	new void Start () {
		base.Start ();
		Colorize ();
		colony.AddCell (this);
		tileGrid = GameObject.Find ("grid").GetComponent<TileGrid> ();
		tileGrid.GetTileAt (tileGrid.width / 2, tileGrid.height / 2).Cell = this;
		this.transform.position = new Vector2 (tileGrid.width / 2, tileGrid.height / 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// nucleus grows tissue cell around it like a grower
	public override void EndTurn() {
		TileBehavior tile = tileGrid.FindEmptyAdjacent ((int)this.transform.position.x, (int)transform.position.y);
		if (tile != null) {
			tile.Cell = colony.MakeCell(CellTypeData.Tissue, tile.x, tile.y);
		}
	}
}
