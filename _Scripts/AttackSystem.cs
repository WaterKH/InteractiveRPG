using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class AttackSystem : MonoBehaviour {

	public Dictionary<string, Dictionary<string, int>> attack_values = new Dictionary<string, Dictionary<string, int>>();
	public Dictionary<string, int> attacksForRogue = new Dictionary<string, int>();
	public Dictionary<string, int> attacksForMage = new Dictionary<string, int>();
	public Dictionary<string, int> attacksForTank = new Dictionary<string, int>();

	public string[] allAttacks;

	public const string rogue = "rogue";
	public const string mage = "mage";
	public const string tank = "tank";

	public TextAsset attacks;

	void Awake()
	{
		allAttacks = attacks.text.Split('\n');

		for(int i = 0; i < allAttacks.Length; ++i)
		{
			string singleAttack = allAttacks[i];

			switch(singleAttack.Split(',')[0])
			{
			case rogue:
				attacksForRogue.Add(singleAttack.Split(',')[1], int.Parse(singleAttack.Split(',')[2]));
				break;
			case mage:
				attacksForMage.Add(singleAttack.Split(',')[1], int.Parse(singleAttack.Split(',')[2]));
				break;
			case tank:
				attacksForTank.Add(singleAttack.Split(',')[1], int.Parse(singleAttack.Split(',')[2]));
				break;
			}
		} 

		attack_values.Add(rogue, attacksForRogue);
		attack_values.Add(mage, attacksForMage);
		attack_values.Add(tank, attacksForTank);
	}
}
