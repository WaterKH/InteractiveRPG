using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverMenu : MonoBehaviour, ISelectHandler, IDeselectHandler {

	public Transform toMoveTo;
	public Transform toMoveBack;
	public bool moveObject;

	public void OnSelect(BaseEventData eventData)
	{
		moveObject = true;
	}

	public void OnDeselect(BaseEventData eventData)
	{
		moveObject = false;
	}

	void Update()
	{
		if(moveObject)
		{
			this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, toMoveTo.position, Time.deltaTime * 5);
		}
		else
		{
			this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, toMoveBack.position, Time.deltaTime * 2);
		}
	}
}
