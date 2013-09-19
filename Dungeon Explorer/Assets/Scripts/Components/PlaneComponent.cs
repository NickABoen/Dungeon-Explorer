using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct PlaneLink
{
	public uint EntityID;
	
	public GameObject PlaneObject;
}

public class PlaneComponent:GameComponent<PlaneLink>
{
	
}