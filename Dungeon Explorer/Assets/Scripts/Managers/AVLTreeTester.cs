using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AVLTreeTester : MonoBehaviour {
	
	float fps = 10;
	float currentTime = 0;
	short currentAnim = 0;
	Sprite[] anims = new Sprite[4];
	
	// Use this for initialization
	void Start () {
		//RenderSystem.testRender(new Position(), new Sprite(), SpriteHelper.MageLeft1);
		
		uint newEID = IDManager.GetNewID();
		
		Player newPlayer = new Player()
		{
			EntityID = newEID,
			PlayerID = 1
		};
		
		Position newPosition = new Position()
		{
			EntityID = newEID,
			Center = new Vector3(0,0,0)
		};
		
		PlaneLink newPlane = new PlaneLink()
		{
			EntityID = newEID,
			PlaneObject = GameObject.Find("Quad-Instance")
		};
		
		SpriteAnim newSpriteAnim = new SpriteAnim()
		{
			EntityID = IDManager.GetNewID(),
			FPS = 10,
			TimeLeft = 0,
			AnimIndex = 0,
			AnimArray = new List<Sprite>(),
			AnimType = SpriteType.PlayOnce,
			FrameIncrement = 1
		};
		
		Sprite newSprite = SpriteHelper.SetMageSprite(newEID, SpriteHelper.CharPosition.Down2);
		
		newSpriteAnim.AnimArray.Add(SpriteHelper.SetMageSprite(0,SpriteHelper.CharPosition.Down2));
		newSpriteAnim.AnimArray.Add(SpriteHelper.SetMageSprite(0,SpriteHelper.CharPosition.Down1));
		newSpriteAnim.AnimArray.Add(SpriteHelper.SetMageSprite(0,SpriteHelper.CharPosition.Down2));
		newSpriteAnim.AnimArray.Add(SpriteHelper.SetMageSprite(0,SpriteHelper.CharPosition.Down3));
		
		ComponentManager.PlayerComponent.Add(newPlayer.EntityID, newPlayer);
		ComponentManager.PositionComponent.Add (newPosition.EntityID, newPosition);
		ComponentManager.PlaneComponent.Add(newPlane.EntityID, newPlane);
		ComponentManager.SpriteComponent.Add(newSprite.EntityID, newSprite);
		//ComponentManager.SpriteAnimComponent.Add(newSpriteAnim.EntityID, newSpriteAnim);
	}
	
	// Update is called once per frame
	void Update () {
		
		InputSystem.Update(1);
		AnimSystem.Update();
		RenderSystem.RenderAll();
	
	}
}
