using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameComponent<T>
{
	protected AVLTree<T> elements;
	
	public GameComponent()
	{
		elements = new AVLTree<T>();
	}
	
	public T this[uint entityID]
	{
		set{elements.Find(entityID).dataValue = value;}
		get{return elements.Find(entityID).dataValue;}
	}
	
	public IEnumerable<T> All
	{
		get{return elements.ToValueArray();}
	}
	
	public IEnumerable<uint> Keys
	{
		get{return elements.ToKeyArray();}
	}
	
	public void Add(uint elementID, T component)
	{
		elements.Insert(elementID, component);
	}
	
	public void Remove(uint elementID)
	{
		if(elements.Contains(elementID))
		{
			elements.Delete(elementID);
		}
	}
	
	public bool Contains(uint elementID)
	{
		return elements.Contains(elementID);
	}
	
	public int Count()
	{
		return elements.Count;
	}
	
	public List<T> ToList()
	{
		return elements.ToValueArray();	
	}
	
	public virtual void HandleTrigger(uint elementID, string type)
	{
		
	}
}