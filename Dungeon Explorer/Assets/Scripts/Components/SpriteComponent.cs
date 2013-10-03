using UnityEngine;
using System;

public struct Sprite
{
	public uint EntityID;
	
	public string SpriteSheetName;
	public Vector2 SpritePosition;
	public Vector2 SpriteSize;
}

public class SpriteComponent : GameComponent<Sprite>
{
	
}

