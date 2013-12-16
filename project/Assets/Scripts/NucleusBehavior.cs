using UnityEngine;
using System.Collections;

using Sophie;

public class NucleusBehavior : CellBehavior {

	private TileGrid tileGrid;
	private EventDelegate endTurnDelegate;

	public NucleusBehavior() {
		typeData = Sophie.CellTypeData.Nucleus;
	}

	// Use this for initialization
	new void Start () {
		base.Start ();
		endTurnDelegate = new EventDelegate (EndTurn);
		Events.Listen ("EndTurn", endTurnDelegate);

		Colorize ();
		colony.Nucleus = this;
		tileGrid = GameObject.Find ("grid").GetComponent<TileGrid> ();
		TileQuery q = new TileQuery ();
		q.FindTileAt (tileGrid.width / 2, tileGrid.height / 2).Cell = this;
		this.transform.position = new Vector2 (tileGrid.width / 2, tileGrid.height / 2);
	}

	void OnDisable()
	{
		if (!gameObject.activeSelf)
		{
			Events.Cancel("EndTurn", endTurnDelegate);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	// nucleus grows tissue cell around it like a grower
	void EndTurn(object args) {
		TileQuery q = new TileQuery ();
		TileBehavior tile = q.FindRandomEmptyAdjacent ((int)this.transform.position.x, (int)transform.position.y);
		if (tile != null) {
			tile.Cell = colony.MakeCell(CellTypeData.Empty, tile.x, tile.y);
		}
	}
}
