using UnityEngine;

public class EnemyStraightLineScript : MonoBehaviour {
	
	public float xMove = (float) -1.0;
	public float yMove = (float) 0;
	public bool isTurnBased = false;
	public bool isMoving = false;
	public int numFrames = 30;
	Vector3 target;

	// Update is called once per frame
	void Update () 
	{

		if (!isTurnBased)
		{
			Vector3 movement = new Vector3(xMove, yMove, 0);
			movement *= Time.deltaTime;
			
			transform.Translate (movement);
		}

		if (isTurnBased && Input.GetKeyUp("space"))
		{
			isMoving = true;
			target = new Vector3(transform.position.x + xMove, transform.position.y + yMove, transform.position.z);
		}

		if (isTurnBased && isMoving)
		{
			float newX = xMove / numFrames;
			float newY = yMove / numFrames;
			Vector3 movement = new Vector3(newX, newY, 0);
			transform.Translate(movement);

			if (
				(xMove < 0 && transform.position.x <= target.x) || 
			    (xMove > 0 && transform.position.x >= target.x) ||
			    (yMove < 0 && transform.position.y <= target.y) ||
			    (yMove > 0 && transform.position.y >= target.y) 
			   )
			{
				isMoving = false;
				transform.position = target;
			}


		}


	}


}