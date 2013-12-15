using UnityEngine;
using System.Collections.Generic;

using Sophie;

public class CellChoiceBehavior : MonoBehaviour {

	private CellTypeData cellType;
	private bool selected;
	private static System.Random randy = new System.Random ();

	public bool IsSelected {
		get { return selected; }
	}

	public CellTypeData CellType {
		get { return cellType; }
	}

	// Use this for initialization
	void Start () {
		SelectRandomCellType ();
	}

	// selects a random, buildable cell type
	public void SelectRandomCellType() {
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
	}


}
