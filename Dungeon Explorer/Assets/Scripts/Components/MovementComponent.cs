using UnityEngine;
using System;

public enum FacingDirection
{
    South = 0,
    West = 1,
    East = 2,
    North = 3
}

public struct Movement
{
    public uint EntityID;

    public Vector2 MoveDirection;

    public Vector2 OldMoveDirection;

    public FacingDirection FacingDirection;

    public FacingDirection OldFacingDirection;

    public KeyCode LastKey;

    public float Speed;
}

public class MovementComponent : GameComponent<Movement>
{
    public FacingDirection GetFacingFromID(uint id)
    {
        Vector2 direction = elements.Find(id).dataValue.MoveDirection;
        return GetFacingFromDirection(direction);
    }

    public FacingDirection GetFacingFromDirection(Vector2 direction)
    {
        if (direction.x > 0 && direction.x > Math.Abs(direction.y))
            return FacingDirection.East;
        else if (direction.x < 0 && Math.Abs(direction.x) > Math.Abs(direction.y))
            return FacingDirection.West;
        else if (direction.y < 0)
            return FacingDirection.North;

        return FacingDirection.South;
    }
}

