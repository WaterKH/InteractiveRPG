using UnityEngine;
using System.Collections;

public class Enemy : Character {

	public Enemy() : base()
	{
		
	}

	public Enemy(float aHealth, float aStrength, float aFortitude, float aDexterity, float aWillpower, float aSpirit,
					int numberOfAttacks, int character) : base(aHealth, aStrength, aFortitude, aDexterity, aWillpower,
															   aSpirit, numberOfAttacks, character)
	{

	}
	
}
