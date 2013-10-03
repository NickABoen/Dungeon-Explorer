using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class RenderSystem
{
	private static List<uint> RemovalList = new List<uint>();
	
	public static void Update()
	{
		foreach(Sprite spr in ComponentManager.SpriteComponent.All)
		{
			PlaneLink plane = ComponentManager.PlaneComponent[spr.EntityID];
			Position position = ComponentManager.PositionComponent[spr.EntityID];
			
			plane.PlaneObject.transform.position = position.Center;
			plane.PlaneObject.GetComponent<QuadComponent>().ApplySprite(spr);
		}
		
		foreach(SpriteAnim sprAnim in ComponentManager.SpriteAnimComponent.All)
		{
			PlaneLink plane = ComponentManager.PlaneComponent[sprAnim.EntityID];
			Position position = ComponentManager.PositionComponent[sprAnim.EntityID];
			
			Sprite spr = sprAnim.AnimArray[sprAnim.AnimIndex];
			
			plane.PlaneObject.transform.position = position.Center;
			plane.PlaneObject.GetComponent<QuadComponent>().ApplySprite(spr);
		}
	}
	
	public static void testRender(Position pos, Sprite spr)
	{
		GameObject quad = GameObject.Find("Quad-Instance");
		
		quad.GetComponent<QuadComponent>().ApplySprite(spr);
	}
}
