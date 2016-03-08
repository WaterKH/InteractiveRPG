using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public TriggersForAttackSystem triggerElem;
	public AttackUI attackUI;
	public EnemyInBattle enemyInBattle;

	public static Character mainCharacter = new Character();

	public static Tank tank = new Tank();
	public static Mage mage = new Mage();
	public static Rogue rogue = new Rogue();

	public bool playerTurn = true; //TODO Rework this since we will be attacking based on speed
	public bool battleStart = true; //TODO add battleStart to a function

	void Update()
	{
		/*if(playerTurn)
		{
			playerTurn = false;
			attackUI.showAttacks();
		}*/
		if(battleStart)
		{
			battleStart = false;
			enemyInBattle.SpawnEnemy();
		}
	}
}
