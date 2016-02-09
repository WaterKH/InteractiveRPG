using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public MainMenu mainMenu;
	public SaveLoad saveLoad;

	public GameObject[] optionsText = new GameObject[4];

	public void Back()
	{
		for(int i = 0; i < mainMenu.menuText.Length; ++i)
		{
			if(i == 1)
			{
				if(saveLoad.hasLoad)
				{
					mainMenu.menuText[i].GetComponent<Button>().interactable = true;
				}
			}
			else
			{
				mainMenu.menuText[i].GetComponent<Button>().interactable = true;
			}
		}
		mainMenu.menuText[0].GetComponent<Button>().Select();
		mainMenu.optionsActive = false;
	}
}
