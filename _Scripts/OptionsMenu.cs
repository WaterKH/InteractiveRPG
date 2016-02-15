using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public MainMenu mainMenu;
	public SaveLoad saveLoad;

	public GameObject[] optionsText = new GameObject[4];

	public bool generalActive = false;
	public bool soundActive = false;
	public bool controlsActive = false;

	public General general;
	public Sound sound;
	public Controls controls;


	//MAJOR TODO MAKE EVERYTHING VARIABLE - Thus, have a Back method with parameters that let us decide
	// what we will be going back to. That way we only have one method. Same with the rest of the "Show/ No Show" methods
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

	public void General()
	{
		generalActive = true;
		for(int i = 0; i < optionsText.Length; ++i)
		{
			optionsText[i].GetComponent<Button>().interactable = false;
		}
		general.generalText[0].GetComponent<Button>().Select();
	}

	public void Sound()
	{
		soundActive = true;
		for(int i = 0; i < optionsText.Length; ++i)
		{
			optionsText[i].GetComponent<Button>().interactable = false;
		}
		sound.soundText[0].GetComponent<Button>().Select();
	}

	public void Controls()
	{
		controlsActive = true;
		for(int i = 0; i < optionsText.Length; ++i)
		{
			optionsText[i].GetComponent<Button>().interactable = false;
		}
		controls.controlsText[0].GetComponent<Button>().Select();
	}

	void Update()
	{
		if(generalActive)
		{
			general.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(general.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  1, Time.deltaTime * 2);
			general.gameObject.GetComponent<CanvasGroup>().interactable = true;
			general.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

			sound.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(sound.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  0, Time.deltaTime * 2);
			sound.gameObject.GetComponent<CanvasGroup>().interactable = false;
			sound.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;

			controls.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(controls.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  0, Time.deltaTime * 2);
			controls.gameObject.GetComponent<CanvasGroup>().interactable = false;
			controls.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		else if(soundActive)
		{
			sound.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(sound.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  1, Time.deltaTime * 2);
			sound.gameObject.GetComponent<CanvasGroup>().interactable = true;
			sound.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

			general.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(general.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  0, Time.deltaTime * 2);
			general.gameObject.GetComponent<CanvasGroup>().interactable = false;
			general.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;

			controls.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(controls.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  0, Time.deltaTime * 2);
			controls.gameObject.GetComponent<CanvasGroup>().interactable = false;
			controls.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		else if(controlsActive)
		{
			controls.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(controls.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  1, Time.deltaTime * 2);
			controls.gameObject.GetComponent<CanvasGroup>().interactable = true;
			controls.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

			general.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(general.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  0, Time.deltaTime * 2);
			general.gameObject.GetComponent<CanvasGroup>().interactable = false;
			general.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;

			sound.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(sound.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  0, Time.deltaTime * 2);
			sound.gameObject.GetComponent<CanvasGroup>().interactable = false;
			sound.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		else
		{
			general.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(general.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  0, Time.deltaTime * 2);
			general.gameObject.GetComponent<CanvasGroup>().interactable = false;
			general.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;

			sound.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(sound.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  0, Time.deltaTime * 2);
			sound.gameObject.GetComponent<CanvasGroup>().interactable = false;
			sound.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;

			controls.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(controls.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  0, Time.deltaTime * 2);
			controls.gameObject.GetComponent<CanvasGroup>().interactable = false;
			controls.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}
}
