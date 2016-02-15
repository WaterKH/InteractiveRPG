using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sound : MonoBehaviour {

	public OptionsMenu options;

	public GameObject[] soundText = new GameObject[4];

	public void Back()
	{
		for(int i = 0; i < options.optionsText.Length; ++i)
		{
			options.optionsText[i].GetComponent<Button>().interactable = true;
		}
		options.optionsText[0].GetComponent<Button>().Select();
		options.soundActive = false;
	}
}
