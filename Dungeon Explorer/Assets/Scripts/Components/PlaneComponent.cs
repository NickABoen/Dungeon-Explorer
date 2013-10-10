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
    public void Add(uint elementID)
    {
        PlaneLink component = new PlaneLink()
        {
            EntityID = elementID,

            PlaneObject = (GameObject)Object.Instantiate(Resources.Load("Prefabs/Quad"))
        };

        Add(elementID, component);
    }
}