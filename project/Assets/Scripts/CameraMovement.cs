using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	const float speed = 10.0f;

	// Use this for initialization
	void Start () {
		TileGrid grid = GameObject.Find ("grid").GetComponent<TileGrid> ();
		transform.position = new Vector2 (grid.width / 2, grid.height / 2);
	}
	
	// Update is called once per frame
	void Update () {
		var movement = Vector3.zero;
		movement.y = Input.GetAxis ("Vertical");
		movement.x = Input.GetAxis ("Horizontal");
		transform.Translate (movement * speed * Time.deltaTime, Space.Self);
	}
}
