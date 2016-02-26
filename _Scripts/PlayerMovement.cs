using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public static Vector3 move;
	public FollowCamera followCam;

	public float speed = 5f;

	// Update is called once per frame
	void LateUpdate () 
	{
		move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;

		followCam.xDirOfPlayer = gameObject.transform.position.x;
		followCam.yDirOfPlayer = gameObject.transform.position.y;
	}
}
