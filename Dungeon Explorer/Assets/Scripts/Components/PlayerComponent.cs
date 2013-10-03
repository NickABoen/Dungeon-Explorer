using UnityEngine;
using System.Collections;

public struct Player
{
	public uint EntityID;
	
	public ushort PlayerID;
}

public class PlayerComponent:GameComponent<Player>
{
	
}
