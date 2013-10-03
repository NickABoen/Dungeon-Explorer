using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class MovementSystem
{
    private static List<uint> RemovalList = new List<uint>();

    public static void Update()
    {
        /*foreach (uint key in ComponentManager.MovementComponent.Keys)
        {
            Movement m = ComponentManager.MovementComponent[key];

            ProcessMovement(m);

            //TODO: Movement System: determine sprite anims

            SpriteAnim anim = ComponentManager.SpriteAnimComponent[m.EntityID];

            if ((m.FacingDirection != m.OldFacingDirection) || (m.MoveDirection != m.OldMoveDirection))
            {
                switch (m.FacingDirection)
                {
                    case FacingDirection.North:
                        {
                            if (m.MoveDirection == Vector2.zero)
                            {
                                anim = SpriteHelper.SetMageAnim(m.EntityID, SpriteHelper.PlayerAnimList.IdleUp);
                            }
                            else
                            {
                                anim = SpriteHelper.SetMageAnim(m.EntityID, SpriteHelper.PlayerAnimList.Up);
                            }
                            break;
                        }

                    case FacingDirection.South:
                        {
                            if (m.MoveDirection == Vector2.zero)
                            {
                                anim = SpriteHelper.SetMageAnim(m.EntityID, SpriteHelper.PlayerAnimList.IdleDown);
                            }
                            else
                            {
                                anim = SpriteHelper.SetMageAnim(m.EntityID, SpriteHelper.PlayerAnimList.Down);
                            }
                            break;
                        }

                    case FacingDirection.West:
                        {
                            if (m.MoveDirection == Vector2.zero)
                            {
                                anim = SpriteHelper.SetMageAnim(m.EntityID, SpriteHelper.PlayerAnimList.IdleLeft);
                            }
                            else
                            {
                                anim = SpriteHelper.SetMageAnim(m.EntityID, SpriteHelper.PlayerAnimList.Left);
                            }
                            break;
                        }

                    case FacingDirection.East:
                        {
                            if (m.MoveDirection == Vector2.zero)
                            {
                                anim = SpriteHelper.SetMageAnim(m.EntityID, SpriteHelper.PlayerAnimList.IdleRight);
                            }
                            else
                            {
                                anim = SpriteHelper.SetMageAnim(m.EntityID, SpriteHelper.PlayerAnimList.Right);
                            }
                            break;
                        }
                }
            }

            m.OldFacingDirection = m.FacingDirection;
            m.OldMoveDirection = m.MoveDirection;
            ComponentManager.SpriteAnimComponent[m.EntityID] = anim;
            ComponentManager.MovementComponent[key] = m;
        }*/
        
        foreach (uint key in ComponentManager.MovementComponent.Keys)
        {
            Movement movement = ComponentManager.MovementComponent[key];
            SpriteAnim currentAnim = ComponentManager.SpriteAnimComponent[key];
            SpriteAnim newAnim;

            if (movement.MoveDirection.x == 0 && movement.MoveDirection.y == 0)
            {
                switch (movement.FacingDirection)
                {
                    case FacingDirection.North:
                        {
                            newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.IdleUp);
                            break;
                        }

                    case FacingDirection.East:
                        {
                            newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.IdleRight);
                            break;
                        }

                    case FacingDirection.West:
                        {
                            newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.IdleLeft);
                            break;
                        }

                    default:
                        {
                            newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.IdleDown);
                            break;
                        }
                }
            }
                //NE
            else if (movement.MoveDirection.x > 0 && movement.MoveDirection.y > 0)
            {
                if (movement.LastKey == InputSystem.MoveRight)
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Right);
                else
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Up);
            }
                //E
            else if (movement.MoveDirection.x > 0 && movement.MoveDirection.y == 0)
            {
                newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Right);
            }
                //SE
            else if (movement.MoveDirection.x > 0 && movement.MoveDirection.y < 0)
            {
                if (movement.LastKey == InputSystem.MoveRight)
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Right);
                else
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Down);
            }
                //N
            else if (movement.MoveDirection.x == 0 && movement.MoveDirection.y > 0)
            {
                newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Up);
            }
                //S
            else if (movement.MoveDirection.x == 0 && movement.MoveDirection.y < 0)
            {
                newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Down);
            }
                //SW
            else if (movement.MoveDirection.x < 0 && movement.MoveDirection.y > 0)
            {
                if (movement.LastKey == InputSystem.MoveLeft)
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Left);
                else
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Down);
            }
                //W
            else if (movement.MoveDirection.x < 0 && movement.MoveDirection.y == 0)
            {
                newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Left);
            }
                //NW
            else if (movement.MoveDirection.x < 0 && movement.MoveDirection.y < 0)
            {
                if (movement.LastKey == InputSystem.MoveLeft)
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Left);
                else
                    newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.Up);
            }
                //Default Idle Down
            else
            {
                newAnim = SpriteHelper.SetMageAnim(key, SpriteHelper.PlayerAnimList.IdleDown);
            }

            if (currentAnim.AnimArray != newAnim.AnimArray)
            {
                ComponentManager.SpriteAnimComponent[key] = newAnim;
            }

            movement.OldFacingDirection = movement.FacingDirection;
            movement.OldMoveDirection = movement.MoveDirection;
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
