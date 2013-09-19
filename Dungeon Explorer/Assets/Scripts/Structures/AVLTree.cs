using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AVLTree<T>
{
	/// <summary>
	/// The total number of nodes.
	/// </summary>
	public int Count;
	
	/// <summary>
	/// The root node of the tree.
	/// </summary>
	public AVLTreeNode<uint, T> Root;
	
	/// <summary>
	/// Initializes a new instance of the <see cref="AVLTree`1"/> class with
	/// an empty root node.
	/// </summary>
	public AVLTree()
	{
		Count = 0;
		Root = null;
	}
	
	public AVLTreeNode<uint, T> Find(uint elementID)
	{
		if(Root != null)
		{
			return Root.Find(elementID, 0);
		}
		
		return null;
	}
	
	public bool Contains(uint elementID)
	{
		return (this.Find(elementID) != null);
	}
	
	public bool Delete(AVLTreeNode<uint, T> nodeToRemove)
	{
		if(Root != null)
		{
			if(nodeToRemove == Root)
			{
				Root = Root.DeleteRoot(Root);
				return true;
			}
			else
			{
				return Root.Delete(nodeToRemove);	
			}
		}
		
		return false;
	}
	
	public bool Delete(uint nodeValueToRemove)
	{
		if(Root != null)
		{
			AVLTreeNode<uint, T> nodeToRemove = Root.Find(nodeValueToRemove, 0);
			
			if(nodeToRemove != null)
			{
				bool result = this.Delete(nodeToRemove);
				
				if(result)
				{
					Count--;	
				}
				
				return result;
			}	
		}
		
		return false;
	}
	
	public void Insert(uint nodeKeyToAdd, T nodeValueToAdd)
	{
		if(Root == null)
		{
			Root = new AVLTreeNode<uint, T>(nodeKeyToAdd, nodeValueToAdd, null, null, null);	
			Root.height = 0;
			Count++;
			return;
		}
		
		AVLTreeNode<uint, T> newNode = new AVLTreeNode<uint, T>(nodeKeyToAdd, nodeValueToAdd,null,null,null);
		
		AVLTreeNode<uint, T>.Insert(Root,newNode);
		Count++;
		Root = AVLTreeNode<uint, T>.FindRoot(Root);
	}
	
	public List<AVLTreeNode<uint, T>> ToArray()
	{
		if(Root == null)
		{
			return new List<AVLTreeNode<uint, T>>();
		}
		else
		{
			return Root.ToArray();
		}
	}
	
	public List<T> ToValueArray()
	{
		List<T> valueArray = new List<T>();
		
		foreach(AVLTreeNode<uint, T> node in this.ToArray())
		{
			valueArray.Add(node.dataValue);	
		}
		
		return valueArray;
	}
	
	public List<uint> ToKeyArray()
	{
		List<uint> keyArray = new List<uint>();
		
		if(Root == null) return keyArray;
		
		foreach(AVLTreeNode<uint, T> node in this.ToArray())
		{
			keyArray.Add(node.getKey());	
		}
		
		return keyArray;
	}
	
	public override string ToString()
	{
		List<AVLTreeNode<uint, T>> nodeList = ToArray();
		
		string result = "Root = " + Root.getKey() + "\n";
		
		foreach(AVLTreeNode<uint, T> node in nodeList)
		{
				result += node.ToString() + "\n";
		}
		
		return result;
	}
}
