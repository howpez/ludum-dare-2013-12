using UnityEngine;
using System.Collections;

public class NucleusBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector2 (0, 0);
		SpriteRenderer r = this.GetComponent<SpriteRenderer> ();
		r.color = new Color (1.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
