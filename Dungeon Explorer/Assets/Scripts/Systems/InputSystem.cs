using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class InputSystem
{
	public static KeyCode MoveUp = KeyCode.W;
	public static KeyCode MoveDown = KeyCode.S;
	public static KeyCode MoveLeft = KeyCode.A;
	public static KeyCode MoveRight = KeyCode.D;
	
	public static bool Enabled = true;
	
	public static SpriteAnim[] MovementAnims = new SpriteAnim[5];
	
	public static void Update()
	{
		if(!Enabled) return;

        foreach (Player p in ComponentManager.PlayerComponent.All)
        {
            HandleKeysDown(p.EntityID);

            HandleKeysUp(p.EntityID);
        }
	}
	
	private static void HandleKeysDown(uint playerEID)
	{
        Movement playerMovement = ComponentManager.MovementComponent[playerEID];

        if (Input.GetKeyDown(MoveUp))
        {
            playerMovement.MoveDirection.y += 1;
            playerMovement.FacingDirection = FacingDirection.North;
        }

        if (Input.GetKeyDown(MoveDown))
        {
            playerMovement.MoveDirection.y -= 1;
            playerMovement.FacingDirection = FacingDirection.South;
        }

        if (Input.GetKeyDown(MoveLeft))
        {
            playerMovement.MoveDirection.x -= 1;
            playerMovement.FacingDirection = FacingDirection.West;
        }

        if (Input.GetKeyDown(MoveRight))
        {
            playerMovement.MoveDirection.x += 1;
            playerMovement.FacingDirection = FacingDirection.East;
        }

        ComponentManager.MovementComponent[playerEID] = playerMovement;

	}
	
	private static void HandleKeysUp(uint playerEID)
	{
        Movement playerMovement = ComponentManager.MovementComponent[playerEID];

        if (Input.GetKeyUp(MoveUp))
        {
            playerMovement.MoveDirection.y -= 1;
        }

        if (Input.GetKeyUp(MoveDown))
        {
            playerMovement.MoveDirection.y += 1;
        }

        if (Input.GetKeyUp(MoveLeft))
        {
            playerMovement.MoveDirection.x += 1;
        }

        if (Input.GetKeyUp(MoveRight))
        {
            playerMovement.MoveDirection.x -= 1;
        }

        ComponentManager.MovementComponent[playerEID] = playerMovement;
	}

    private static void ReplaceAnim(uint AnimEntityID, SpriteAnim newAnim)
    {
        SpriteAnim targetAnim = ComponentManager.SpriteAnimComponent[AnimEntityID];
        
    }
}
