﻿using UnityEngine;
using System.Collections.Generic;
using Sophie;

public class ColonyBehavior : MonoBehaviour {

	public GameObject cellPrefab;
	private List<CellBehavior> cells;
	private NucleusBehavior nucleus;

	public NucleusBehavior Nucleus {
		get {
			return nucleus; 
		}
		set {
			nucleus = value; 
			AddCell(nucleus);
		}
	}

	// Use this for initialization
	void Start () {
		cells = new List<CellBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			EndTurn();
		}
	}

	public void EndTurn() {
		Events.Trigger ("EndTurn");
	}

	public void AddCell(CellBehavior cell) {
		cells.Add (cell);
	}
	
	public void RemoveCell(CellBehavior cell) {
		
	}

	public CellBehavior MakeCell(CellTypeData type, int x, int y) {
		GameObject cell = (GameObject)Instantiate(cellPrefab);
		cell.transform.position = new Vector2 (x, y);
		CellBehavior cb = cell.GetComponent<CellBehavior> ();
		cb.typeData = type;
		cb.Colorize ();
		cells.Add (cb);
		return cb;
	}
	
}
