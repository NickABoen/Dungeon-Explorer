using UnityEngine;
using System.Collections.Generic;

public static class SpriteHelper
{
	#region Mage
	
	public enum CharPosition
	{
		Left1,
		Left2,
		Left3,
		Right1,
		Right2,
		Right3,
		Down1,
		Down2,
		Down3,
		Up1,
		Up2,
		Up3,
        IdleUp,
        IdleDown,
        IdleLeft,
        IdleRight
	}
	
	public enum PlayerAnimList
	{
		Left,
		Right,
		Up,
		Down,
        IdleUp,
        IdleDown,
        IdleLeft,
        IdleRight
	}
	
	public static Sprite SetMageSprite(uint ownerID, CharPosition charPos)
	{
		Sprite newSprite = new Sprite()
		{
			EntityID = ownerID
		};
		
		switch(charPos)
		{
		case CharPosition.Right1:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(64,198);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
		}

        case CharPosition.IdleRight:
		case CharPosition.Right2:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(80,198);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
		}
		case CharPosition.Right3:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(96,198);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
		}
		case CharPosition.Left1:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(64,234);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
		}

        case CharPosition.IdleLeft:
		case CharPosition.Left2:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(80,234);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
		}
		case CharPosition.Left3:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(96,234);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
		}

		case CharPosition.Down1:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(64,216);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
        }

        case CharPosition.IdleDown:
		case CharPosition.Down2:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(80,216);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
		}
		case CharPosition.Down3:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(96,216);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
		}
		case CharPosition.Up1:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(64,180);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
		}

        case CharPosition.IdleUp:
		case CharPosition.Up2:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(80,180);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
		}
		case CharPosition.Up3:
		{
			newSprite.SpriteSheetName = "Sprite Sheets/PlaceholderCharacterSheet1";
			newSprite.SpritePosition = new Vector2(96,180);
			newSprite.SpriteSize = new Vector2(16,18);
			break;
		}
		default:
		{
			Debug.LogError("An Error occurred: CharPosition does not exist");
			return new Sprite();
		}
		}
		
		return newSprite;
	}
	
	public static SpriteAnim SetMageAnim(uint ownerID, PlayerAnimList anim)
	{
		SpriteAnim spriteAnim = new SpriteAnim()
		{
			EntityID = ownerID,
			AnimArray = new List<Sprite>(),
			FPS = 10,
			AnimIndex = 0,
			TimeLeft = 0,
			FrameIncrement = 1,
			AnimType = SpriteType.Loop
		};
		
		switch (anim)
		{
			case PlayerAnimList.Left:
			{
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Left2));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Left1));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Left2));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Left3));
			
				break;
			}
				
			case PlayerAnimList.Right:
			{
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Right2));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Right1));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Right2));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Right3));
			
				break;
			}
				
			case PlayerAnimList.Up:
			{
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Up2));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Up1));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Up2));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Up3));
			
				break;
			}
				
			case PlayerAnimList.Down:
			{
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Down2));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Down1));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Down2));
				spriteAnim.AnimArray.Add(SetMageSprite(ownerID,CharPosition.Down3));
			
				break;
            }
            case PlayerAnimList.IdleUp:
            {
                spriteAnim.FrameIncrement = 0;
                spriteAnim.AnimArray.Add(SetMageSprite(ownerID, CharPosition.IdleUp));

                break;
            }
            case PlayerAnimList.IdleDown:
            {
                spriteAnim.FrameIncrement = 0;
                spriteAnim.AnimArray.Add(SetMageSprite(ownerID, CharPosition.IdleDown));

                break;
            }
            case PlayerAnimList.IdleLeft:
            {
                spriteAnim.FrameIncrement = 0;
                spriteAnim.AnimArray.Add(SetMageSprite(ownerID, CharPosition.IdleLeft));

                break;
            }
            case PlayerAnimList.IdleRight:
            {
                spriteAnim.FrameIncrement = 0;
                spriteAnim.AnimArray.Add(SetMageSprite(ownerID, CharPosition.IdleRight));

                break;
            }

			default:
			{
				throw new UnityException("PlayerAnimList is null or does not exist");
			}
			
		}
		
		return spriteAnim;
	}
	
	#endregion
}
