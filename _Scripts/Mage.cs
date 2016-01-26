using UnityEngine;
using System.Collections;

public class Mage : Character {

	public static int numberOfClasses = 7;
	public static TreeDataStructure mageTree = new TreeDataStructure(numberOfClasses / 2);

	public void addToMageTree(int index, string data)
	{
		mageTree.insert(mageTree.root, index, data);
	}

	public void printTree()
	{
		mageTree.printInOrder(mageTree.root);
	}
}
