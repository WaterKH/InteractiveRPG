using UnityEngine;
using System.Collections;

public class Character {

	public float health;
	public float strength;
	public float fortitude;
	public float dexterity;
	public float willpower;
	public float spirit;

	public int numberOfAttacks;
	public int  numberOfElements;

	public int currentCharacter; // !!NOTE!! - Mage = 0, Rogue = 1, Tank = 2, Enemy = -1

	public float experiencePoints;
	public int currentLevel;

	public string[] levels = new string[20];

	public Character()
	{
		health = 0.0f;
		strength = 0.0f;
		fortitude = 0.0f;
		dexterity = 0.0f;
		willpower = 0.0f;
		spirit = 0.0f;

		numberOfAttacks = 3;
		numberOfElements = 2;

		currentCharacter = 0;

		experiencePoints = 0.0f;
		currentLevel = 0;
	}

	public Character(float aHealth, float aStrength, float aFortitude, float aDexterity, float aWillpower, float aSpirit,
					int numberOfAtts, int numberOfElems, int character)
	{
		this.setHealth(aHealth);
		this.setStrength(aStrength);
		this.setFortitude(aFortitude);
		this.setDexterity(aDexterity);
		this.setWillpower(aWillpower);
		this.setSpirit(aSpirit);

		this.setNumberOfAttacks(numberOfAtts);
		this.setNumberOfElements(numberOfElems);

		this.setCurrentCharacter(character);

		this.setEXP(0);
		this.setLevel(0);
	}

	/*************************************************
	 * Basic Accessors
	**/
	//TODO Do we want all of these floats?
	public float getHealth()
	{
		return health;
	}
	public float getStrength()
	{
		return strength;
	}
	public float getFortitude()
	{
		return fortitude;
	}
	public float getDexterity()
	{
		return dexterity;
	}
	public float getWillpower()
	{
		return willpower;
	}
	public float getSpirit()
	{
		return spirit;
	}

	public int getNumberOfAttacks()
	{
		return numberOfAttacks;
	}
	public int getNumberOfElements()
	{
		return numberOfElements;
	}

	public int getCurrentCharacter()
	{
		return currentCharacter;
	}

	public float getEXP()
	{
		return experiencePoints;
	}
	public int getLevel()
	{
		return currentLevel;
	}

	/*************************************************
	 * Basic Mutators
	**/
	//TODO Do we want all of these floats?
	public void setHealth(float aHealth)
	{
		health = aHealth;
	} 
	public void setStrength(float aStrength)
	{
		strength = aStrength;
	}
	public void setFortitude(float aFortitude)
	{
		fortitude = aFortitude;
	}
	public void setDexterity(float aDexterity)
	{
		dexterity = aDexterity;
	}
	public void setWillpower(float aWillpower)
	{
		willpower = aWillpower;
	}
	public void setSpirit(float aSpirit)
	{
		spirit = aSpirit;
	}

	public void setNumberOfAttacks(int anAttackNumber)
	{
		numberOfAttacks = anAttackNumber;
	}
	public void setNumberOfElements(int anElemNumber)
	{
		numberOfElements = anElemNumber;
	}

	public void setCurrentCharacter(int character)
	{
		currentCharacter = character;
	}

	public void setEXP(float EXP)
	{
		experiencePoints = EXP;
	}
	public void setLevel(int level)
	{
		currentLevel = level;
	}

	/******************************************************************************
	 * General Functions
	 *
	**/
	public void levelUp()
	{
		this.setLevel(this.getLevel() + 1);

		this.increaseHealth(float.Parse(levels[this.getLevel()].Split(',')[0]));
		this.increaseAttack(float.Parse(levels[this.getLevel()].Split(',')[1]));
		this.increaseEvasion(float.Parse(levels[this.getLevel()].Split(',')[2]));
		this.increaseSpecial();
		this.increaseRegenSP();
		this.increaseCrits();
	}

	public void increaseHealth(float aHealth)
	{
		this.setHealth(this.getHealth() + aHealth);
	}
	public void increaseAttack(float anAtt)
	{
		this.setStrength(this.getStrength() + anAtt);
	}
	public void increaseEvasion(float aDex)
	{
		this.setDexterity(this.getDexterity() + aDex);
	}
	public void increaseSpecial()
	{
		
	}
	public void increaseRegenSP()
	{
		
	}
	public void increaseCrits()
	{
		
	}
}
