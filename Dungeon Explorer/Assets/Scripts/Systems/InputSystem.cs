using UnityEngine;
using System.Collections;

public static class InputSystem
{
	public static KeyCode MoveUp = KeyCode.W;
	public static KeyCode MoveDown = KeyCode.S;
	public static KeyCode MoveLeft = KeyCode.A;
	public static KeyCode MoveRight = KeyCode.D;
	
	public static bool Enabled = true;
	
	public static SpriteAnim[] MovementAnims = new SpriteAnim[4];
	
	public static void Update(ushort playerID)
	{
		if(!Enabled) return;
		
		uint playerEID = 0;
		
		foreach(Player p in ComponentManager.PlayerComponent.All)
		{
			if(playerID == p.PlayerID)
			{
				playerEID = p.EntityID;
				break;
			}
		}
		
		HandleKeysDown(playerEID);
		
		HandleKeysUp(playerEID);
	}
	
	private static void HandleKeysDown(uint playerEID)
	{
		if(Input.GetKeyDown(MoveUp))
		{
			SpriteAnim newSpriteAnim = SpriteHelper.SetMageAnim(playerEID, SpriteHelper.PlayerAnimList.Up);
			ComponentManager.SpriteAnimComponent.Add(newSpriteAnim.EntityID, newSpriteAnim);
			MovementAnims[0] = newSpriteAnim;
		}
		
		if(Input.GetKeyDown(MoveDown))
		{
			SpriteAnim newSpriteAnim = SpriteHelper.SetMageAnim(playerEID, SpriteHelper.PlayerAnimList.Down);
			ComponentManager.SpriteAnimComponent.Add(newSpriteAnim.EntityID, newSpriteAnim);
			MovementAnims[1] = newSpriteAnim;
		}
		
		if(Input.GetKeyDown(MoveLeft))
		{
			SpriteAnim newSpriteAnim = SpriteHelper.SetMageAnim(playerEID, SpriteHelper.PlayerAnimList.Left);
			ComponentManager.SpriteAnimComponent.Add(newSpriteAnim.EntityID, newSpriteAnim);
			MovementAnims[2] = newSpriteAnim;
		}
		
		if(Input.GetKeyDown(MoveRight))
		{
			SpriteAnim newSpriteAnim = SpriteHelper.SetMageAnim(playerEID, SpriteHelper.PlayerAnimList.Right);
			ComponentManager.SpriteAnimComponent.Add(newSpriteAnim.EntityID, newSpriteAnim);
			MovementAnims[3] = newSpriteAnim;
		}
	}
	
	private static void HandleKeysUp(uint playerEID)
	{
		if(Input.GetKeyUp(MoveUp))
		{
			ComponentManager.SpriteAnimComponent.Remove(MovementAnims[0].EntityID);
		}
		
		if(Input.GetKeyUp(MoveDown))
		{
			ComponentManager.SpriteAnimComponent.Remove(MovementAnims[1].EntityID);
		}
		
		if(Input.GetKeyUp(MoveLeft))
		{
			ComponentManager.SpriteAnimComponent.Remove(MovementAnims[2].EntityID);
		}
		
		if(Input.GetKeyUp(MoveRight))
		{
			ComponentManager.SpriteAnimComponent.Remove(MovementAnims[3].EntityID);
		}
	}
}
