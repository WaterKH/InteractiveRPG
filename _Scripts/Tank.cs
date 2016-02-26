using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tank : Character {

	public static int numberOfClasses = 7;
	public static TreeDataStructure tankTree = new TreeDataStructure(numberOfClasses / 2);
	//public static int currentLevel = 0;
	//public int numberOfElements;

	public void addToTankTree(int index, string[] data)
	{
		tankTree.insert(tankTree.root, index, data);
	}

	public void printTree()
	{
		tankTree.printInOrder(tankTree.root);
	}

	public string[] getCurrentAttacksNames()
	{
		return tankTree.find(base.getLevel());
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
