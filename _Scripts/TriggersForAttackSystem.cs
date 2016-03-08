using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggersForAttackSystem : MonoBehaviour {

	public Animator MenuAnimator;
	public Animator WhackAnimator;
	public Animator MagicAnimator;

	public Animator[] systemAnimator;
	//public Animator ElemAnimator;
	//public Animator MovementAnimator;

	public PathMovement pathMovement;
	public AttackUI attackUI;

	public GameObject currPath;
	public GameObject parentPathHolder;
	public string currPathName;

}
