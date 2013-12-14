using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	const float speed = 10.0f;

	// Update is called once per frame
	void Update () {
		var movement = Vector3.zero;
		movement.y = Input.GetAxis ("Vertical");
		movement.x = Input.GetAxis ("Horizontal");
		transform.Translate (movement * speed * Time.deltaTime, Space.Self);
	}
}
