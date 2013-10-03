using UnityEngine;
using System.Collections.Generic;

public static class IDManager 
{
	
	private static uint IDCount = 0;
	
	private static Queue<uint> AvailableIDs = new Queue<uint>();
	
	public static uint GetNewID()
	{
		if(AvailableIDs.Count > 0)
		{
			return AvailableIDs.Dequeue();	
		}
		
		return IDCount++;
	}
	
	public static void DestroyID(uint ID)
	{
		AvailableIDs.Enqueue(ID);
	}
	
}
