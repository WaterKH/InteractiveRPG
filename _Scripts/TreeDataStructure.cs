using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeDataStructure {

	public class Node
	{
		public string data;
		public int positionInTree;
		public Node left;
		public Node right;
		public Node parent;

		public Node(string aData, int aPos, Node aParent)
		{
			left = null;
			right = null;
			parent = aParent;
			data = aData;
			positionInTree = aPos;
		}
	}

	public Node root;
	public Node tempParent;

	public TreeDataStructure(int midPoint)
	{
		root = new Node("base", midPoint, null);
	}

	public void insert(Node node, int positionInTree, string theDataToBeStored)
	{
		if(positionInTree < node.positionInTree)
		{
			tempParent = node;
			if(node.left != null)
			{
				insert(node.left, positionInTree, theDataToBeStored);
			}
			else
			{
				node.left = new Node(theDataToBeStored, positionInTree, tempParent);
			}
		}
		else if(positionInTree > node.positionInTree)
		{
			tempParent = node;
			if(node.right != null)
			{
				insert(node.right, positionInTree, theDataToBeStored);
			}
			else
			{
				node.right = new Node(theDataToBeStored, positionInTree, tempParent);
			}
		}
	}

	public void printInOrder(Node node)
	{
		if(node != null)
		{
			printInOrder(node.left);
			Debug.Log("Current Data: " + node.data + " " + node.positionInTree);
			if(node.parent != null)
			{
				Debug.Log("Parent Data: " + node.parent.data + " " +  + node.parent.positionInTree);
			}
			else
			{
				Debug.Log("No Parent - If not root, rework code");
			}
			printInOrder(node.right);
		}
	}
}
