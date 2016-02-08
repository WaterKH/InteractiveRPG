using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public TriggerElements triggerElem;
	public AttackUI attackUI;

	public static Character mainCharacter = new Character();

	public static Tank tank = new Tank();
	public static Mage mage = new Mage();
	public static Rogue rogue = new Rogue();

	public bool playerTurn = true; //TODO Rework this since we will be attacking based on speed

	void Update()
	{
		if(playerTurn)
		{
			playerTurn = false;
			attackUI.showAttacks();
		}
	}
}
