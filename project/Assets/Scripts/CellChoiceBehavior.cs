﻿using UnityEngine;
using System.Collections.Generic;

using Sophie;

public class CellChoiceBehavior : MonoBehaviour {

	private CellTypeData cellType;
	private bool selected;
	private static System.Random randy = new System.Random ();
	private EventDelegate placeCellDelegate;

	public bool IsSelected {
		get { return selected; }
	}

	public CellTypeData CellType {
		get { return cellType; }
	}

	// Use this for initialization
	void Start () {
		SelectRandomCellType (null);
		placeCellDelegate = new EventDelegate (SelectRandomCellType);
		Events.Listen ("PlaceCell", placeCellDelegate);
	}

	void OnDisable()
	{
		if (!gameObject.activeSelf)
		{
			Events.Cancel("PlaceCell", placeCellDelegate);
		}
	}

	// selects a random, buildable cell type
	public void SelectRandomCellType(object args) {
		List<CellTypeData> cellTypes = CellTypeData.GetBuildable ();
		cellType = cellTypes [randy.Next(0, cellTypes.Count)];
		SpriteRenderer render = this.GetComponent<SpriteRenderer> ();
		if (render != null) {
			render.color = cellType.Color;
		}
		selected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Deselect() {
		selected = false;
	}

	void Select() {
		selected = true;
	}

	void OnMouseDown() {
		CellChoiceBehavior[] behaviors = FindObjectsOfType<CellChoiceBehavior> ();
		foreach (CellChoiceBehavior b in behaviors) {
			b.Deselect();
		}
		this.Select ();
		// highlight potential build locations
		GameObject.Find ("grid").GetComponent<TileGrid> ().HighlightBuildableCells ();
	}
}