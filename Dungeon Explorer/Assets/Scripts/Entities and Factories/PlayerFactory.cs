using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class PlayerFactory
{
    public const int MAX_PLAYERS = 4;
    public const float BASE_SPEED = 1.0f;

    public static uint CreatePlayer()
    {
        int playerCount = ComponentManager.PlayerComponent.Count();

        if (playerCount >= MAX_PLAYERS)
            return uint.MaxValue;

        uint playerID = IDManager.GetNewID();

        Player player = new Player()
        {
            EntityID = playerID,
            PlayerID = (ushort)playerCount
        };
        ComponentManager.PlayerComponent.Add(playerID, player);

        Position playerPosition = new Position()
        {
            EntityID = playerID,
            Center = new Vector3()
        };
        ComponentManager.PositionComponent.Add(playerID, playerPosition);

        PlaneLink playerPlane = new PlaneLink()
        {
            EntityID = playerID,
            
            //Change to create new Plane Object
            PlaneObject = GameObject.Find("Quad-Instance")
        };
        ComponentManager.PlaneComponent.Add(playerID, playerPlane);

        Movement playerMovement = new Movement()
        {
            EntityID = playerID,
            MoveDirection = Vector2.zero,
            Speed = BASE_SPEED
        };
        ComponentManager.MovementComponent.Add(playerID, playerMovement);

        SpriteAnim playerAnim = new SpriteAnim()
        {
            EntityID = playerID,
            AnimArray = new List<Sprite>(),
            AnimIndex = 0,
            AnimType = SpriteType.Loop,
            FPS = 1.0f,
            FrameIncrement = 0,
            TimeLeft = 1.0f
        };
        playerAnim = SpriteHelper.SetMageAnim(playerAnim.EntityID, SpriteHelper.AnimList.IdleDown);
        ComponentManager.SpriteAnimComponent.Add(playerID, playerAnim);

        RenderEntity playerRender = new RenderEntity()
        {
            EntityID = playerID
        };
        ComponentManager.RenderComponent.Add(playerID, playerRender);

        return playerID;
    }
}
