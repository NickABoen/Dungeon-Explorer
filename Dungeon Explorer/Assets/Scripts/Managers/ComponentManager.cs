using UnityEngine;
using System.Collections.Generic;

public static class ComponentManager
{
	public static PositionComponent PositionComponent = new PositionComponent();
	public static SpriteComponent SpriteComponent = new SpriteComponent();
	public static PlaneComponent PlaneComponent = new PlaneComponent();
	public static SpriteAnimComponent SpriteAnimComponent = new SpriteAnimComponent();
	public static PlayerComponent PlayerComponent = new PlayerComponent();
    public static MovementComponent MovementComponent = new MovementComponent();
    public static RenderComponent RenderComponent = new RenderComponent();
	
	public static void RemoveFromAll(uint elementID)
	{
		PositionComponent.Remove(elementID);
		SpriteComponent.Remove(elementID);
		PlaneComponent.Remove(elementID);
		SpriteAnimComponent.Remove(elementID);
		PlayerComponent.Remove(elementID);
        MovementComponent.Remove(elementID);
        RenderComponent.Remove(elementID);
	}
}
