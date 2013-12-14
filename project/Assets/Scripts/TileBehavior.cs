using UnityEngine;
using System.Collections;

public class TileBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {
		GameObject o = GameObject.Find ("selector");
		o.transform.position = this.transform.position;
	}
}
