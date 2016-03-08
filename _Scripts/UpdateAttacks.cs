using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.UI;

public class UpdateAttacks : MonoBehaviour {

	public TriggersForAttackSystem triggersAttack;

	public int menuBubble = 0;
	public int whackBubble = 1;
	public int magicBubble = 2;

	public int tempCharacter;

	public float actualSpeed;
	public bool hasAttacked;

	public Dictionary<string, GameObject> attackTracks = new Dictionary<string, GameObject>();
	public GameObject currAttackHolder;

	public Button center_Menu;
	public Button center_Whack;
	public Button center_Magic;

	public Button currButton;

	void Awake()
	{
		foreach(Transform transform in currAttackHolder.GetComponentsInChildren<Transform>())
		{
			if(transform.name.Contains("Paths_"))
			{
				attackTracks.Add(transform.name, transform.gameObject);
				print(attackTracks[transform.name].name);
			}
		}
	}

	/************************************************************
	 * Circle arrangement code created by Unity Answers; Modified by Jacob Clark
	 *
	**/
	public void showAttacks()
	{
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
		//TODO Add names to attackMenu

		triggersAttack.systemAnimator[menuBubble].SetTrigger("Appear");

		currButton = center_Menu;
	}

	public void hoveredOverMagic(Button magic)
	{
		triggersAttack.systemAnimator[magicBubble].SetTrigger("Appear");
		triggersAttack.systemAnimator[menuBubble].SetTrigger("Disappear");

		currButton = center_Magic;
	}

	public void hoveredOverWhack()
	{
		triggersAttack.systemAnimator[whackBubble].SetTrigger("Appear");
		triggersAttack.systemAnimator[menuBubble].SetTrigger("Disappear");
	
		currButton = center_Whack;
	}

	public void hoveredOverBack(int currBubble)
	{
		triggersAttack.systemAnimator[currBubble].SetTrigger("Disappear");
		triggersAttack.systemAnimator[menuBubble].SetTrigger("Appear");

		currButton = center_Menu;
	}

	public void hoveredOverAttack(GameObject attack)
	{
		string attackName = attack.name;
		print(attackName);
		attackTracks[attackName].SetActive(true);
	}

	public void continueBattle()
	{
		hasAttacked = true;
	}

	void Update()
	{
		if(hasAttacked)
		{
			if(actualSpeed == Game.mainCharacter.getDexterity())
			{
				showAttacks();
				hasAttacked = false;
				actualSpeed = 0;
			}
			else 
			{
				actualSpeed += Time.deltaTime / 2;
			}
		}

		currButton.Select();
		//print(EventSystem.current.currentSelectedGameObject.name);
	}
}
