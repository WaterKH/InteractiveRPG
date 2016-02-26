using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerElements : MonoBehaviour {

	public Animator ElemAnimator;
	public Animator MovementAnimator;

	public PathMovement pathMovement;
	public AttackUI attackUI;

	public GameObject currPath;
	public GameObject parentPathHolder;
	public string currPathName;

	public void attackSelected()
	{
		for(int i = 0; i < attackUI.attackUIElements.Length; ++i)
		{
			attackUI.attackUIElements[i].GetComponent<UpdateAttacks>().elements = true;
		}
		ElemAnimator.SetBool("ElemAppear", true);
	}
	public void attackDeselected()
	{
		for(int i = 0; i < attackUI.attackUIElements.Length; ++i)
		{
			attackUI.attackUIElements[i].GetComponent<UpdateAttacks>().elements = false;
		}
		ElemAnimator.SetBool("ElemAppear", false);
	}

	public void elementalSelected()
	{
		pathMovement.attacking = true;
		currPath = Instantiate(Resources.Load(currPathName) as GameObject);
		currPath.transform.SetParent(parentPathHolder.transform, false);
		pathMovement.initPath = GameObject.FindGameObjectWithTag("InitialPath").GetComponent<RectTransform>();
		pathMovement.path = GameObject.FindGameObjectWithTag("Path").GetComponent<RectTransform>();
		pathMovement.finalPath = GameObject.FindGameObjectWithTag("FinalPath").GetComponent<RectTransform>();
		for(int i = 0; i < attackUI.attackUIElements.Length; ++i)
		{
			attackUI.attackUIElements[i].GetComponent<UpdateAttacks>().elements = true;
		}
	}

	public void returnToPrevious()
	{
		if(MovementAnimator.GetBool("OpenAttMenu") && ElemAnimator.GetBool ("ElemAppear"))
		{
			attackDeselected();
		}
		else if(MovementAnimator.GetBool("OpenAttMenu"))
		{
			attackDeselected();
		}
	}
}
