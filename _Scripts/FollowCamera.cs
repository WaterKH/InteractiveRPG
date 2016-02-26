using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public bool clearToFollow_Horizontal_Left = true;
	public bool clearToFollow_Horizontal_Right = true;
	public bool clearToFollow_Vertical_Up = true;
	public bool clearToFollow_Vertical_Down = true;

	public float xDirOfPlayer;
	public float yDirOfPlayer;

	public PlayerMovement playerMovement;
	public Camera mainCamera;
	
	// Update is called once per frame
	void Update () 
	{
		if(clearToFollow_Horizontal_Left && !clearToFollow_Horizontal_Right)
		{
			//Debug.Log(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, mainCamera.nearClipPlane)).x);
			if(PlayerMovement.move.x < 0 && xDirOfPlayer < mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, mainCamera.nearClipPlane)).x)
			{
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
															 new Vector3(xDirOfPlayer, gameObject.transform.position.y, -12),
															 Time.deltaTime * 2);
			}
		}
		else if(!clearToFollow_Horizontal_Left && clearToFollow_Horizontal_Right)
		{
			//Debug.Log(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, mainCamera.nearClipPlane)).x);
			if(PlayerMovement.move.x > 0 && xDirOfPlayer > mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, mainCamera.nearClipPlane)).x)
			{
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
															 new Vector3(xDirOfPlayer, gameObject.transform.position.y, -12),
															 Time.deltaTime * 2);
			}
		}
		else
		{
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
															 new Vector3(xDirOfPlayer, gameObject.transform.position.y, -12),
															 Time.deltaTime * 2);
		}

		if(clearToFollow_Vertical_Up && !clearToFollow_Vertical_Down)
		{
			if(PlayerMovement.move.y > 0 && yDirOfPlayer > mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, mainCamera.nearClipPlane)).y)
			{
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
															 new Vector3(gameObject.transform.position.x, yDirOfPlayer, -12),
															 Time.deltaTime * 2);
			}
		}
		else if(!clearToFollow_Vertical_Up && clearToFollow_Vertical_Down)
		{
			if(PlayerMovement.move.y < 0 && yDirOfPlayer < mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, mainCamera.nearClipPlane)).y)
			{
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
															 new Vector3(gameObject.transform.position.x, yDirOfPlayer, -12),
															 Time.deltaTime * 2);
			}
		}
		else
		{
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
															 new Vector3(gameObject.transform.position.x, yDirOfPlayer, -12),
															 Time.deltaTime * 2);
		}
	}

	public void OnTriggerStay2D(Collider2D col)
	{
		//Debug.Log("Hit");
		if(col.tag.Equals("EdgeBarrier"))
		{
		//Debug.Log("EDGE BARRIER ");
			if(col.name.Equals("Bottom"))
			{
				clearToFollow_Vertical_Down = false;
			}
			else if(col.name.Equals("Top"))
			{
				clearToFollow_Vertical_Up = false;
			}

			if(col.name.Equals("Left_1"))
			{
			//Debug.Log("Hit");
				clearToFollow_Horizontal_Left = false;
			}
			else if(col.name.Equals("Right_1"))
			{
				clearToFollow_Horizontal_Right = false;
			}
		}
	}

	public void OnTriggerExit2D(Collider2D col)
	{
//		Debug.Log("Exit");
		if(col.tag.Equals("EdgeBarrier"))
		{
			if(col.name.Equals("Bottom"))
			{
				clearToFollow_Vertical_Down = true;
			}
			else if(col.name.Equals("Top"))
			{
				clearToFollow_Vertical_Up = true;
			}

			if(col.name.Equals("Left_1"))
			{
				clearToFollow_Horizontal_Left = true;
			}
			else if(col.name.Equals("Right_1"))
			{
				clearToFollow_Horizontal_Right = true;
			}
		}
	}
}
