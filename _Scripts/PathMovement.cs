using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PathMovement : MonoBehaviour {

	public Camera mainCamera;

	public RectTransform path;
	public RectTransform initPath;
	public RectTransform finalPath;
	
	public bool attacking;
	public bool finished;

	public Image currZoneBackground;
	
	public Color green;
	public Color yellow;
	public Color red;
	public Color initialBackground;
	
	// Update is called once per frame
	void Update () 
	{
		if(attacking)
		{
			if(!finished)
			{
				path.localPosition = Vector2.Lerp(path.localPosition, 
				                                  finalPath.localPosition, Time.deltaTime);
				if(path.localPosition.x >= finalPath.localPosition.x - 4f)
				{
					finished = true;
				}
			}
			else
			{
				path.localPosition = initPath.localPosition;
				finished = false;
			}
		}

		// Change colors depending on which path you are on
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
		if(hit.transform != null)
		{
			if(hit.transform.tag == "GreenPath")
			{
				currZoneBackground.color = green;
			}
			else if(hit.transform.tag == "YellowPath")
			{
				currZoneBackground.color = yellow;
			}
			else if(hit.transform.tag == "RedPath")
			{
				currZoneBackground.color = red;
			}
			else
			{
				currZoneBackground.color = initialBackground;
			}
		}
	}
}
