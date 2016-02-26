using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UpdateAttacks : MonoBehaviour {

	public bool isShowing = false;
	public GameObject toShow;
	public GameObject toHide;
	public bool elements = false;

	public AttackUI attackUI;

	public Animator ElemAnimator;

	void Awake()
	{
		attackUI = GameObject.Find("Attacks[Canvas]").GetComponent<AttackUI>();
	}

	public void showDescription(GameObject hoverObject)
    {
    	if(!elements)
    	{
    		isShowing = true;
			toShow = hoverObject;
    	}
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

	public void ClickedAttackButton (GameObject button)
	{
		Debug.Log("Clicked");
		for(int i = 0; i < attackUI.attackUIElements.Length; ++i)
		{
			if(attackUI.attackUIElements[i] != null)
			{
				Debug.Log(attackUI.attackUIElements[i].name);
				attackUI.attackUIElements[i].GetComponent<UpdateAttacks>().elements = true;
			}
		}
		attackUI.showElements(button);
		//ElemAnimator.SetBool("ElemAppear", true);
	}
}
