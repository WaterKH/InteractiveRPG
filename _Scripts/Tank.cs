using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tank : Character {

	public static int numberOfClasses = 7;
	public static TreeDataStructure tankTree = new TreeDataStructure(numberOfClasses / 2);
	//public static int currentLevel = 0;

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
		//string[] temp = tankTree.find(base.getLevel());

		//for(int i = 0; i < temp.Length; ++i)
		//{
		//	Debug.Log(temp[i]);
		//}

		return tankTree.find(base.getLevel());
	}
}
