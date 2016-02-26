using UnityEngine;
using System.Collections;

public class Enemy : Character {

	public bool isAttackingEnemy;

	public Enemy() : base()
	{
		
	}

	public Enemy(float aHealth, float aStrength, float aFortitude, float aDexterity, float aWillpower, float aSpirit,
					int numberOfAtts, int numberOfElems, int character) : base(aHealth, aStrength, aFortitude, aDexterity, 
															   aWillpower, aSpirit, numberOfAtts, numberOfElems, character)
	{

	}

	public void setAttackEnemy(bool attackEnemy)
	{
		isAttackingEnemy = attackEnemy;
	}

	public bool getAttackEnemy()
	{
		return isAttackingEnemy;
	}
}
