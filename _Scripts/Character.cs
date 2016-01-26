using UnityEngine;
using System.Collections;

public class Character {

	public float health;
	public float strength;
	public float fortitude;
	public float dexterity;
	public float willpower;
	public float spirit;

	public Character()
	{
		health = 0.0f;
		strength = 0.0f;
		fortitude = 0.0f;
		dexterity = 0.0f;
		willpower = 0.0f;
		spirit = 0.0f;
	}

	public Character(float aHealth, float aStrength, float aFortitude, float aDexterity, float aWillpower, float aSpirit)
	{
		this.setHealth(aHealth);
		this.setStrength(aStrength);
		this.setFortitude(aFortitude);
		this.setDexterity(aDexterity);
		this.setWillpower(aWillpower);
		this.setSpirit(aSpirit);
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
}
