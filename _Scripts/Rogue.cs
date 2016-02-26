using UnityEngine;
using System.Collections;

public class Rogue : Character {

	public static int numberOfClasses = 7;
	public static TreeDataStructure rogueTree = new TreeDataStructure(numberOfClasses / 2);
	//public static int currentLevel = 0;
	//public int numberOfElements;

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
		return rogueTree.find(base.getLevel());
	}

	/*public void setNumberOfElements(int elems)
	{
		numberOfElements = elems;
	}

	public int getNumberOfElements()
	{
		return numberOfElements;
	}*/
}
