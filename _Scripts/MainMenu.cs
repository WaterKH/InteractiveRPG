using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

	public GameObject[] menuText = new GameObject[4];
	public bool optionsActive;

	public OptionsMenu options;


	void Start()
	{
		menuText[0].GetComponent<Button>().Select();
	}

	public void Options()
	{
		menuText[2].GetComponent<HoverMenu>().moveObject = false;
		for(int i = 0; i < menuText.Length; ++i)
		{
			menuText[i].GetComponent<Button>().interactable = false;
		}
		optionsActive = true;
		options.optionsText[0].GetComponent<Button>().Select();
	}

	void Update()
	{
		if(optionsActive)
		{
			
			options.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(options.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  1, Time.deltaTime * 2);
			options.gameObject.GetComponent<CanvasGroup>().interactable = true;
			options.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
		else
		{
			options.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(options.gameObject.GetComponent<CanvasGroup>().alpha, 
																			  0, Time.deltaTime * 2);
			options.gameObject.GetComponent<CanvasGroup>().interactable = false;
			options.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}
}
