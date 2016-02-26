using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttackUI : MonoBehaviour {

	public GameObject[] attackUIElements = new GameObject[8];
	public GameObject[] elementUIHolder = new GameObject[4];
	public GameObject parent;
	public GameObject centerObject;
	public bool alphaChanging = false;

	/************************************************************
	 * Circle arrangement code created by Unity Answers; Modified by Jacob Clark
	 *
	**/
	public void showAttacks()
	{
		int numberOfUIAttackElems = Game.mainCharacter.numberOfAttacks;
		string[] nameOfAttacks;
		switch(Game.mainCharacter.currentCharacter)
		{
		case 0: // MAGE
			nameOfAttacks = Game.mage.getCurrentAttacksNames();
			break;
		case 1: // ROGUE
			nameOfAttacks = Game.rogue.getCurrentAttacksNames();
			break;
		case 2: // TANK
			nameOfAttacks = Game.tank.getCurrentAttacksNames();
			break;
		default:
			return;
		}
		float angle = 0.5f;
		float rad = 2f;
		float timer = 0.25f;


		for(int i = 0; i < numberOfUIAttackElems; ++i)
		{
			float theta = (2 * Mathf.PI / numberOfUIAttackElems) * i + 1;
			Vector2 pos = new Vector2 ((Mathf.Sin(theta * angle) * rad), (Mathf.Cos(theta * angle) * rad));

			GameObject attackOrb = Instantiate(Resources.Load("AttackUI") as GameObject);

			alphaChanging = true;
			StartCoroutine(startShowing(attackOrb));
			//attackOrb.GetComponent<CanvasGroup>().alpha = 1;
			//attackOrb.GetComponent<CanvasGroup>().interactable = true;
			//attackOrb.GetComponent<CanvasGroup>().blocksRaycasts = true;

			attackOrb.transform.position = pos;
			attackOrb.name = nameOfAttacks[i];
			attackOrb.transform.SetParent(parent.transform, false);
			attackOrb.GetComponentInChildren<Text>().text = nameOfAttacks[i];

			attackUIElements[i] = attackOrb;

			timer = 0.5f;
			angle = timer;
		}
    }

    //NOT WORKING CORRECTLY TODO
    IEnumerator startShowing(GameObject attackOrb)
    {
    	while(alphaChanging)
    	{
			attackOrb.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(attackOrb.GetComponent<CanvasGroup>().alpha,
																			1, Time.deltaTime * 2);

			if(attackOrb.GetComponent<CanvasGroup>().alpha > 0.9f)
			{
				attackOrb.GetComponent<CanvasGroup>().alpha = 1;
				attackOrb.GetComponent<CanvasGroup>().blocksRaycasts = true;
				attackOrb.GetComponent<CanvasGroup>().interactable = true;
				alphaChanging = false;
			}
    	}
    	yield return new WaitForSeconds(0.0f);
    }

    public void showElements(GameObject attackSelected)
    {
    	int numberOfElements = Game.mainCharacter.numberOfElements;

		float angle = 0.5f;
		float rad = 1f;
		float timer = 0.25f;

		for(int i = 0; i < numberOfElements; ++i)
		{
			float theta = (2 * Mathf.PI / 3) * i + 2.2f;
			Vector2 pos = new Vector2 ((Mathf.Sin(theta * angle) * rad), (Mathf.Cos(theta * angle) * rad));

			GameObject elementOrb = Instantiate(Resources.Load("ElementUI") as GameObject);

			alphaChanging = true;
			StartCoroutine(startShowing(elementOrb));

			elementOrb.transform.position = pos;
			elementOrb.transform.SetParent(attackSelected.transform.parent.transform, false);

			elementUIHolder[i] = elementOrb;

			timer = 0.5f;
			angle = timer;
		}
    }
}
