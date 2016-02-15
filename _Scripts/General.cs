using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class General : MonoBehaviour {

	public OptionsMenu options;

	public GameObject[] generalText = new GameObject[4];

	public void Back()
	{
		for(int i = 0; i < options.optionsText.Length; ++i)
		{
			options.optionsText[i].GetComponent<Button>().interactable = true;
		}
		options.optionsText[0].GetComponent<Button>().Select();
		options.generalActive = false;
	}
}
