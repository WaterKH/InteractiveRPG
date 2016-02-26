using UnityEngine;
using System.Collections;

public class Mage : Character {

	public static int numberOfClasses = 7;
	public static TreeDataStructure mageTree = new TreeDataStructure(numberOfClasses / 2);
	//public static int currentLevel = 0;
	//public int numberOfElements;

	public void addToMageTree(int index, string[] data)
	{
		mageTree.insert(mageTree.root, index, data);
	}

	public void printTree()
	{
		mageTree.printInOrder(mageTree.root);
	}

	public string[] getCurrentAttacksNames()
	{
		return mageTree.find(base.getLevel());
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
