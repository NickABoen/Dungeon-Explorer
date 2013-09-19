using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AnimSystem
{
	private static List<uint> RemovalList = new List<uint>();
	
	public static void Update()
	{
		foreach(uint key in ComponentManager.SpriteAnimComponent.Keys)
		{
			SpriteAnim anim = ComponentManager.SpriteAnimComponent[key];
			
			anim.TimeLeft -= Time.deltaTime;
			
			if(anim.TimeLeft <= 0)
			{
				anim.TimeLeft = 1 / anim.FPS;
				
				switch (anim.AnimType)
				{
					case SpriteType.Loop:
					{
						anim.AnimIndex = (anim.AnimIndex >= anim.AnimArray.Count - 1) ? 0 : anim.AnimIndex + anim.FrameIncrement;
						break;
					}
					
					case SpriteType.PingPong:
					{
						if(anim.AnimIndex + 1 >= anim.AnimArray.Count || anim.AnimIndex <= 0)
						{
							anim.FrameIncrement *= -1;
						}
					
						anim.AnimIndex += anim.FrameIncrement;
						
						break;
					}
						
					case SpriteType.PlayOnce:
					{
						if(anim.AnimIndex + 1 >= anim.AnimArray.Count)
						{
							RemovalList.Add(anim.EntityID);
						}
						anim.AnimIndex += anim.FrameIncrement;
						
						break;
					}
						
					default:
					{
						RemovalList.Add(anim.EntityID);
					
						break;
					}
					
				}
			}
			
			ComponentManager.SpriteAnimComponent[key] = anim;
		}
		
		foreach(uint key in RemovalList)
		{
			ComponentManager.SpriteAnimComponent.Remove(key);
		}
		RemovalList.Clear();
	}
}

