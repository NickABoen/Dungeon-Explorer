using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SpriteType
{
	Loop,
	PlayOnce,
	PingPong
}

public struct SpriteAnim
{
	public uint EntityID;
	
	public List<Sprite> AnimArray;
	public float TimeLeft;
	public float FPS;
	public int AnimIndex;
	public SpriteType AnimType;
	public int FrameIncrement;
}

public class SpriteAnimComponent : GameComponent<SpriteAnim>
{
	
}