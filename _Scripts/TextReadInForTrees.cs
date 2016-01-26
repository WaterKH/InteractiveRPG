using UnityEngine;
using System.Collections;

public class TextReadInForTrees : MonoBehaviour {

	public TextAsset mageTextTree;
	public TextAsset rogueTextTree;
	public TextAsset tankTextTree;
	public string[] fullTextDividedByLine;
	
	// Use this for initialization
	void Awake () 
	{
		fullTextDividedByLine = tankTextTree.text.Split('\n');
		for(int i = 0; i < fullTextDividedByLine.Length; ++i)
		{
			Game.tank.addToTankTree(int.Parse(fullTextDividedByLine[i].Split('-')[1]), fullTextDividedByLine[i].Split('-')[0]);
		}
		Game.tank.printTree();
		Debug.Log("TANK TREE COMPLETED");
		fullTextDividedByLine = rogueTextTree.text.Split('\n');
		for(int i = 0; i < fullTextDividedByLine.Length; ++i)
		{
			Game.rogue.addToRogueTree(int.Parse(fullTextDividedByLine[i].Split('-')[1]), fullTextDividedByLine[i].Split('-')[0]);
		}
		Game.tank.printTree();
		Debug.Log("ROGUE TREE COMPLETED");
		fullTextDividedByLine = mageTextTree.text.Split('\n');
		for(int i = 0; i < fullTextDividedByLine.Length; ++i)
		{
			Game.mage.addToMageTree(int.Parse(fullTextDividedByLine[i].Split('-')[1]), fullTextDividedByLine[i].Split('-')[0]);
		}
		Game.tank.printTree();
		Debug.Log("MAGE TREE COMPLETED");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
