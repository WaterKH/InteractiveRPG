using UnityEngine;
using System.Collections;

public class UpdateAttacks : MonoBehaviour {

	public bool isShowing = false;
	public GameObject toShow;
	public GameObject toHide;

	public void showDescription(GameObject hoverObject)
    {
    	isShowing = true;
		toShow = hoverObject;
    }

    public void hideDescription(GameObject hoverObject)
    {
		isShowing = false;
		toHide = hoverObject;
    }
   
	void Update () {

		if(isShowing)
		{
			toShow.GetComponentInChildren<CanvasGroup>().alpha = 
			Mathf.Lerp(toShow.GetComponentInChildren<CanvasGroup>().alpha, 1, Time.deltaTime * 2);
			toShow.GetComponentInChildren<CanvasGroup>().interactable = true;
			toShow.GetComponentInChildren<CanvasGroup>().blocksRaycasts = true;
		}

		else
		{
			if(toHide != null)
			{
				toHide.GetComponentInChildren<CanvasGroup>().alpha = 
					Mathf.Lerp(toHide.GetComponentInChildren<CanvasGroup>().alpha, 0, Time.deltaTime * 2);
				toHide.GetComponentInChildren<CanvasGroup>().interactable = false;
				toHide.GetComponentInChildren<CanvasGroup>().blocksRaycasts = false;
			}
		}
	}
}
