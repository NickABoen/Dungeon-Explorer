using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

public class AVLTreeNode<K,V>
{
	/// <summary>
	/// The left child.
	/// </summary>
	public AVLTreeNode<K,V> Left;
	
	/// <summary>
	/// The right child.
	/// </summary>
	public AVLTreeNode<K,V> Right;
	
	/// <summary>
	/// The parent node.
	/// </summary>
	public AVLTreeNode<K,V> Parent;
	
	/// <summary>
	/// The height of this node.
	/// </summary>
	public int height;
	
	private K dataKey;
	
	/// <summary>
	/// The value of this node of type T.
	/// </summary>
	public V dataValue;
	
	/// <summary>
	/// The object used to compare generic types.
	/// </summary>
	private static Comparer comparisonObject;
	
	/// <summary>
	/// Initializes a new instance of the <see cref="AVLTreeNode`1"/> class.
	/// </summary>
	/// <param name='val'>
	/// Value to assign to this node.
	/// </param>
	/// <param name='parent'>
	/// Parent of this node; nullable.
	/// </param>
	/// <param name='left'>
	/// Left child of this node; nullable.
	/// </param>
	/// <param name='right'>
	/// Right child of this node; nullable.
	/// </param>
	public AVLTreeNode(K key, V val, AVLTreeNode<K,V> parent, AVLTreeNode<K,V> left, AVLTreeNode<K,V> right)
	{
		dataKey = key;
		dataValue = val;
		Left = left;
		Right = right;
		Parent = parent;
		height = -1;
		comparisonObject = new Comparer(new CultureInfo(""));
	}
	
	private static K maxValue(K val1, K val2)
	{
		int result = comparisonObject.Compare(val1, val2);
		
		if(result < 0)
		{
			return val2;
		}
		else
		{
			return val1;
		}
	}
	
	private static int maxInt(int val1, int val2)
	{
		return (val1 > val2) ? val1 : val2;	
	}
	
	public static AVLTreeNode<K,V> FindRoot(AVLTreeNode<K,V> startNode)
	{
		AVLTreeNode<K,V> currentNode = startNode;
		
		while(currentNode.Parent != null)
		{
			currentNode = currentNode.Parent;	
		}
		
		return currentNode;
	}
	
	private static AVLTreeNode<K,V> findMinNode(AVLTreeNode<K,V> node)
	{
		AVLTreeNode<K,V> currentNode = node;
		
		while(currentNode.Left != null)
		{
			currentNode = currentNode.Left;	
		}
		
		return currentNode;
	}
	
	private static AVLTreeNode<K,V> findMaxNode(AVLTreeNode<K,V> node)
	{
		AVLTreeNode<K,V> currentNode = node;
		
		while(currentNode.Right != null)
		{
			currentNode = currentNode.Right;	
		}
		
		return currentNode;
	}
	
	private static void setHeights(AVLTreeNode<K,V> startNode)
	{
		setSubHeight(startNode);
		setSuperHeight(startNode);
	}
	
	private static void setSubHeight(AVLTreeNode<K,V> startNode)
	{
		if(startNode.Left != null)
		{
			setHeights(startNode.Left);	
		}
		
		if(startNode.Right != null)
		{
			setHeights(startNode.Right);	
		}
		
		int leftHeight, rightHeight;
		
		if(startNode.Left == null)
		{
			leftHeight = -1;	
		}
		else
		{
			leftHeight = startNode.Left.height;	
		}
		
		if(startNode.Right == null)
		{
			rightHeight = -1;	
		}
		else
		{
			rightHeight = startNode.Right.height;	
		}
		
		startNode.height = maxInt(leftHeight,rightHeight) + 1;
	}
	
	private static void setSuperHeight(AVLTreeNode<K,V> startNode)
	{	
		if(startNode != null)
		{
			if(startNode.Parent == null) return;
			startNode = startNode.Parent;	
		}
		else
		{
			return;
		}
		
		int leftHeight = (startNode.Left == null) ? -1 : startNode.Left.height;
		int rightHeight = (startNode.Right == null) ? -1 : startNode.Right.height;
		
		startNode.height = maxInt(leftHeight, rightHeight) + 1;
	}
	
	private static AVLTreeNode<K,V> SingleRotateLeft(AVLTreeNode<K,V> k2)
	{
		AVLTreeNode<K,V> k1 = k2.Left;
		
		if(k1 == null)
		{
			return k2;	
		}
		
		k2.Left = k1.Right;
		k1.Right = k2;
		
		int k1LeftHeight = (k1.Left == null) ? -1 : k1.Left.height;
		int k2RightHeight = (k2.Right == null) ? -1 : k2.Right.height;
		int k2LeftHeight = (k2.Left == null) ? -1 : k2.Left.height;
		
		k2.height = maxInt(k2LeftHeight, k2RightHeight) + 1;
		k1.height = maxInt(k1LeftHeight, k2.height) + 1;
		
		k1.Parent = k2.Parent;
		
		if(k2.Parent != null)
		{
			if(	k2.Parent.Left == k2)
			{
				k2.Parent.Left = k1;
			}
			else
			{
				k2.Parent.Right = k1;
			}
		}
		
		k2.Parent = k1;
		
		return k1;
	}
	
	private static AVLTreeNode<K,V> SingleRotateRight(AVLTreeNode<K,V> k1)
	{
		AVLTreeNode<K,V> k2 = k1.Right;
		
		if(k2 == null)
		{
			return k1;	
		}
		
		k1.Right = k2.Left;
		k2.Left = k1;
		
		int k1LeftHeight = (k1.Left == null) ? -1 : k1.Left.height;
		int k1RightHeight = (k1.Right == null) ? -1 : k1.Right.height;
		int k2RightHeight = (k2.Right == null) ? -1 : k2.Right.height;
		
		k1.height = maxInt(k1LeftHeight, k1RightHeight) + 1;
		k2.height = maxInt(k2RightHeight, k1.height) + 1;
		
		k2.Parent = k1.Parent;
		
		if(k1.Parent != null)
		{
			if(	k1.Parent.Left == k1)
			{
				k1.Parent.Left = k2;
			}
			else
			{
				k1.Parent.Right = k2;
			}
		}
		
		k1.Parent = k2;
		
		return k2;
	}
	
	private static AVLTreeNode<K,V> DoubleRotateLeft(AVLTreeNode<K,V> k3)
	{
		//Rotate between k1 and k2
		k3.Left = SingleRotateRight(k3.Left);
		
		//Rotate between k3 and k2
		return SingleRotateLeft(k3);
	}
	
	private static AVLTreeNode<K,V> DoubleRotateRight(AVLTreeNode<K,V> k1)
	{
		//Rotate between k3 and k2
		k1.Right = SingleRotateLeft(k1.Right);
		
		//Rotate between k1 and k2
		return SingleRotateRight(k1);
	}
	
	public K getKey()
	{
		return dataKey;	
	}
	
	/// <summary>
	/// Find the specified nodeValue.
	/// </summary>
	/// <param name='nodeValue'>
	/// Node value.
	/// </param>
	public AVLTreeNode<K,V> Find(K keyValue, int currentHeight)
	{
		this.height = currentHeight;
		
		int compareResult = comparisonObject.Compare(this.dataKey, keyValue);
		
		if(compareResult == 0)
		{
			return this;	
		}
		
		if(compareResult > 0)
		{
			if(this.Left == null)
			{
				return null;	
			}
			else
			{
				return this.Left.Find(keyValue, currentHeight + 1);	
			}
		}
		else if(compareResult < 0)
		{
			if(this.Right == null)
			{
				return null;	
			}
			else
			{
				return this.Right.Find(keyValue, currentHeight + 1);	
			}
		}
		
		return null;
	}
	
	/// <summary>
	/// Delete the specified Node.
	/// </summary>
	/// <param name='nodeToRemove'>
	/// Node to remove.
	/// </param>
	public bool Delete(AVLTreeNode<K,V> nodeToRemove)
	{
		AVLTreeNode<K,V> bestOfLeast;
		
		bool onParentLeft = true;
		
		int compareResult = comparisonObject.Compare(nodeToRemove.dataKey, nodeToRemove.Parent.dataKey);
		
		if(compareResult > 0)
		{
			onParentLeft = false;	
		}
		
		if(nodeToRemove.Left == null)
		{
			if(onParentLeft)
			{
				nodeToRemove.Parent.Left = nodeToRemove.Right;
			}
			else
			{
				nodeToRemove.Parent.Right = nodeToRemove.Right;
			}
			
			return true;
		}
		else if(nodeToRemove.Right == null)
		{
			if(onParentLeft)
			{
				nodeToRemove.Parent.Left = nodeToRemove.Left;
			}
			else
			{
				nodeToRemove.Parent.Right = nodeToRemove.Left;
			}
			
			return true;
		}
		
		bestOfLeast = findMaxNode(nodeToRemove.Left);
		
		nodeToRemove.dataKey = bestOfLeast.dataKey;
		nodeToRemove.dataValue = bestOfLeast.dataValue;
		
		bool deletedBestOfLeast = Delete(bestOfLeast);
		
		if(deletedBestOfLeast)
		{
			setHeights(bestOfLeast);
			
			bestOfLeast.Left = null;
			bestOfLeast.Right = null;
			return true;
		}
		
		return false;
	}
	
	public AVLTreeNode<K,V> DeleteRoot(AVLTreeNode<K,V> rootNode)
	{
		AVLTreeNode<K,V> replacementNode = null;
		bool isLeftSide = false;
		
		if(rootNode.Left != null)
		{
			replacementNode = findMaxNode(rootNode.Left);
			isLeftSide = true;
		}
		else if(rootNode.Right != null)
		{
			replacementNode = findMinNode(rootNode.Right);
			isLeftSide = false;
		}
		else
		{
			return null;
		}
		
		rootNode.dataKey = replacementNode.dataKey;
		rootNode.dataValue = replacementNode.dataValue;
		
		bool deletedBestOfLeast = Delete(replacementNode);
		
		if(deletedBestOfLeast)
		{
			setHeights(replacementNode);
			
			replacementNode.Left = null;
			replacementNode.Right = null;
		}
		
		return rootNode;
	}
	
	/// <summary>
	/// Insert the specified node.
	/// </summary>
	/// <param name='nodeToAdd'>
	/// Node to add.
	/// </param>
	public static void Insert(AVLTreeNode<K,V> currentNode, AVLTreeNode<K,V> nodeToAdd)
	{
		int compareResult = comparisonObject.Compare(nodeToAdd.dataKey, currentNode.dataKey);
		
		if(compareResult > 0)
		{
			if(currentNode.Right == null)
			{
				currentNode.Right = nodeToAdd;
				nodeToAdd.Parent = currentNode;
				nodeToAdd.height = 0;
			}
			else
			{
				AVLTreeNode<K,V>.Insert(currentNode.Right, nodeToAdd);
			}
			
			int rightNodeHeight = (currentNode.Right == null) ? -1 : currentNode.Right.height;
			int leftNodeHeight = (currentNode.Left == null) ? -1 : currentNode.Left.height;
			
			if( (rightNodeHeight - leftNodeHeight) == 2)
			{
				int subResult = comparisonObject.Compare(nodeToAdd.dataKey, currentNode.Right.dataKey);
				if( subResult > 0)
				{
					currentNode = SingleRotateRight(currentNode);
				}
				else
				{
					currentNode = DoubleRotateRight(currentNode);
				}
			}
		}
		else if(compareResult < 0)
		{
			if(currentNode.Left == null)
			{
				currentNode.Left = nodeToAdd;
				nodeToAdd.Parent = currentNode;
				nodeToAdd.height = 0;
			}
			else
			{
				AVLTreeNode<K,V>.Insert(currentNode.Left, nodeToAdd);
			}
			
			int rightNodeHeight = (currentNode.Right == null) ? -1 : currentNode.Right.height;
			int leftNodeHeight = (currentNode.Left == null) ? -1 : currentNode.Left.height;
			
			if((leftNodeHeight - rightNodeHeight) == 2)
			{
				int subResult = comparisonObject.Compare(nodeToAdd.dataKey, currentNode.Left.dataKey);
				
				if(subResult < 0)
				{
					currentNode = SingleRotateLeft(currentNode);
				}
				else
				{
					currentNode = DoubleRotateLeft(currentNode);
				}
			}
		}
		else
		{
			return;
		}
		
		int leftHeight = (currentNode.Left == null) ? -1 : currentNode.Left.height;
		int rightHeight = (currentNode.Right == null) ? -1 : currentNode.Right.height;
		
		currentNode.height = maxInt(leftHeight, rightHeight) + 1;
	}
	
	public List<AVLTreeNode<K,V>> ToArray(List<AVLTreeNode<K,V>> array = null)
	{
		if(array == null)
		{
			array = new List<AVLTreeNode<K,V>>();
		}
		
		array.Add(this);
		
		if(this.Left != null)
		{
			this.Left.ToArray(array);
		}
		
		if(this.Right != null)
		{
			this.Right.ToArray(array);
		}
		
		return array;
	}
	
	public override string ToString ()
	{
		string childDirection = (this.Parent == null) ? "" : ((this.Parent.Left == this) ? "L" : "R");
		string parentString = (this.Parent == null) ? childDirection : "P" + this.Parent.dataKey + " -> " + childDirection;
		
		string leftChild = (this.Left == null) ? "L = null" : "L = " + this.Left.dataKey;
		string rightChild = (this.Right == null) ? "R = null" : "R = " + this.Right.dataKey;
		
		return this.height + ": " + parentString + this.dataKey + ";" + leftChild + " " + rightChild;
	}
}
