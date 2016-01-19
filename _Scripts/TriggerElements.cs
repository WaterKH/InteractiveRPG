using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerElements : MonoBehaviour {

	public Animator ElemAnimator;
	public Animator MovementAnimator;

	public PathMovement pathMovement;

	public GameObject currPath;
	public GameObject parentPathHolder;
	public string currPathName;

	public void directionSelected()
	{
		ElemAnimator.SetBool("ElemAppear", true);
	}
	public void directionDeselected()
	{
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
	}

	public void attackSelected()//Button attack)
	{
		MovementAnimator.SetBool("OpenAttMenu", true);
		currPathName = "Paths_Thrust";
		//currPathName = attack.name;
	}
	public void attackDeselected()
	{
		MovementAnimator.SetBool("OpenAttMenu", false);
	}

	public void returnToPrevious()
	{
		if(MovementAnimator.GetBool("OpenAttMenu") && ElemAnimator.GetBool ("ElemAppear"))
		{
			directionDeselected();
		}
		else if(MovementAnimator.GetBool("OpenAttMenu"))
		{
			attackDeselected();
		}
	}
}
