using UnityEngine;
using System.Collections;

public class Rogue : Character {

	public static int numberOfClasses = 7;
	public static TreeDataStructure rogueTree = new TreeDataStructure(numberOfClasses / 2);
	//public static int currentLevel = 0;

	public void addToRogueTree(int index, string[] data)
	{
		rogueTree.insert(rogueTree.root, index, data);
	}

	public void printTree()
	{
		rogueTree.printInOrder(rogueTree.root);
	}

	public string[] getCurrentAttacksNames()
	{
		//string[] temp = rogueTree.find(currentLevel);

		//for(int i = 0; i < temp.Length; ++i)
		//{
		//	Debug.Log(temp[i]);
		//}
		return rogueTree.find(base.getLevel());

	}
}
