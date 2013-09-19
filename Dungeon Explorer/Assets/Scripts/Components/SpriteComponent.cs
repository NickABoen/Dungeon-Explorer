using UnityEngine;
using System;

public struct Sprite
{
	public uint EntityID;
	
	public uint OwnerID;
	public string SpriteSheetName;
	public Vector2 SpritePosition;
	public Vector3 SpriteSize;
}

public class SpriteComponent : GameComponent<Sprite>
{
	
}

