using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AttackSystem : MonoBehaviour {

	public float attackValue;

	//public Text textAttack;

	public GameObject[] Arrows;

	public GameObject currEvent;
	public GameObject lastEvent;

	// Update is called once per frame
	void Update () {

		currEvent = EventSystem.current.currentSelectedGameObject;
		if(currEvent != lastEvent && currEvent != null)
		{
			if(currEvent.name.Split('_')[0] == "Selection")
			{
				int index = int.Parse(currEvent.name.Split('_')[2]);
				Arrows[index].SetActive(true);
				if(lastEvent != null)
				{
					Arrows[int.Parse(lastEvent.name.Split ('_')[2])].SetActive(false);
				}
				lastEvent = currEvent;
			}
		}

		//textAttack.text = attackValue.ToString();
	
	}
}
