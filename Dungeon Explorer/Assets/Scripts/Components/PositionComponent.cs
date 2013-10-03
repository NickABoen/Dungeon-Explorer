using UnityEngine;
using System;

public struct Position
{
	public uint EntityID;
	
	public Vector3 Center;
}

public class PositionComponent : GameComponent<Position>
{
	
}

