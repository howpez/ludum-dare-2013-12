﻿using UnityEngine;

using System.Collections;
using Sophie;

public class TileBehavior : MonoBehaviour {

	public int x;
	public int y;
	private CellBehavior cell;

	public CellBehavior Cell {
		get { return cell; }
		set { cell = value; }
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {
		GameObject o = GameObject.Find ("selector");
		if (o != null) {
			o.transform.position = this.transform.position;
		}
	}

	void OnMouseDown() {
		if (cell != null)
			return;
		CellChoiceBehavior[] behaviors = FindObjectsOfType<CellChoiceBehavior> ();
		foreach (CellChoiceBehavior b in behaviors) {
			if (b.IsSelected) {
				ColonyBehavior colony = GameObject.Find ("colony").GetComponent<ColonyBehavior> ();
				cell = colony.MakeCell (b.CellType, x, y);
			}
		}
		if (cell != null) {
			foreach (CellChoiceBehavior b in behaviors) {
				b.SelectRandomCellType();
			}
		}
	}
}
