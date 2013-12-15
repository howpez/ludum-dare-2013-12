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
		colony.Nucleus = this;
		tileGrid = GameObject.Find ("grid").GetComponent<TileGrid> ();
		TileQuery q = new TileQuery ();
		q.FindTileAt (tileGrid.width / 2, tileGrid.height / 2).Cell = this;
		this.transform.position = new Vector2 (tileGrid.width / 2, tileGrid.height / 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// nucleus grows tissue cell around it like a grower
	public override void EndTurn() {
		TileQuery q = new TileQuery ();
		TileBehavior tile = q.FindRandomEmptyAdjacent ((int)this.transform.position.x, (int)transform.position.y);
		if (tile != null) {
			tile.Cell = colony.MakeCell(CellTypeData.Empty, tile.x, tile.y);
		}
	}
}
