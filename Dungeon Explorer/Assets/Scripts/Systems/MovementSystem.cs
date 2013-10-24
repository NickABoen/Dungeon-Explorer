using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class MovementSystem
{
    private static List<uint> RemovalList = new List<uint>();

    public static void Update()
    {        
        foreach (uint key in ComponentManager.MovementComponent.Keys)
        {
            Movement movement = ComponentManager.MovementComponent[key];
            SpriteAnim currentAnim = ComponentManager.SpriteAnimComponent[key];
            SpriteAnim newAnim;

            ProcessMovement(movement);

            if (movement.MoveDirection.x == 0 && movement.MoveDirection.y == 0)
            {
                switch (movement.FacingDirection)
                {
                    case FacingDirection.North:
                        {
                            newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.IdleUp);
                            break;
                        }

                    case FacingDirection.East:
                        {
                            newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.IdleRight);
                            break;
                        }

                    case FacingDirection.West:
                        {
                            newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.IdleLeft);
                            break;
                        }

                    default:
                        {
                            newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.IdleDown);
                            break;
                        }
                }
            }
                //NE
            else if (movement.MoveDirection.x > 0 && movement.MoveDirection.y > 0)
            {
                if (movement.LastKey == InputSystem.MoveRight)
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Right);
                else
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Up);
            }
                //E
            else if (movement.MoveDirection.x > 0 && movement.MoveDirection.y == 0)
            {
                newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Right);
            }
                //SE
            else if (movement.MoveDirection.x > 0 && movement.MoveDirection.y < 0)
            {
                if (movement.LastKey == InputSystem.MoveRight)
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Right);
                else
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Down);
            }
                //N
            else if (movement.MoveDirection.x == 0 && movement.MoveDirection.y > 0)
            {
                newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Up);
            }
                //S
            else if (movement.MoveDirection.x == 0 && movement.MoveDirection.y < 0)
            {
                newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Down);
            }
                //NW
            else if (movement.MoveDirection.x < 0 && movement.MoveDirection.y > 0)
            {
                if (movement.LastKey == InputSystem.MoveLeft)
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Left);
                else
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Up);
            }
                //W
            else if (movement.MoveDirection.x < 0 && movement.MoveDirection.y == 0)
            {
                newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Left);
            }
                //SW
            else if (movement.MoveDirection.x < 0 && movement.MoveDirection.y < 0)
            {
                if (movement.LastKey == InputSystem.MoveLeft)
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Left);
                else
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.Down);
            }
                //Default Idle Down
            else
            {
                newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.AnimList.IdleDown);
            }

            if (currentAnim.AnimID != newAnim.AnimID)
            {
                ComponentManager.SpriteAnimComponent[key] = newAnim;
            }
        }
    }

    private static void ProcessMovement(Movement m)
    {
        try
        {
            Position p = ComponentManager.PositionComponent[m.EntityID];

            p.Center += (Vector3)(m.MoveDirection * m.Speed);

            ComponentManager.PositionComponent[m.EntityID] = p;
        }
        catch (NullReferenceException e)
        {
            Debug.Log("MovementSystem 26: A null reference exception was caught with m = " + m.EntityID);
            return;
        }
    }
}