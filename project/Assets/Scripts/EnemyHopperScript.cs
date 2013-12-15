using UnityEngine;

public class EnemyHopperScript : MonoBehaviour {
	
	public float xMove = (float) -3.0;
	public float yMove = (float) 0;
	public bool isTurnBased = false;
	public bool isMoving = false;
	Vector3 target;
	
	// Update is called once per frame
	void Update () 
	{
		
		if (!isTurnBased)
		{
			;
		}
		
		if (isTurnBased && Input.GetKeyUp("space"))
		{
			target = new Vector3(transform.position.x + xMove, transform.position.y + yMove, transform.position.z);
			transform.position = target;
		}

		
		
	}
	
	
}