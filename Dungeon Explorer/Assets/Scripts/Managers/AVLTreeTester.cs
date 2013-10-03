﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AVLTreeTester : MonoBehaviour {
    public uint PlayerID;

	// Use this for initialization
	void Start () {
		/*
		Sprite newSprite = SpriteHelper.SetMageSprite(newEID, SpriteHelper.CharPosition.Down2);
		
		newSpriteAnim.AnimArray.Add(SpriteHelper.SetMageSprite(0,SpriteHelper.CharPosition.Down2));
		newSpriteAnim.AnimArray.Add(SpriteHelper.SetMageSprite(0,SpriteHelper.CharPosition.Down1));
		newSpriteAnim.AnimArray.Add(SpriteHelper.SetMageSprite(0,SpriteHelper.CharPosition.Down2));
		newSpriteAnim.AnimArray.Add(SpriteHelper.SetMageSprite(0,SpriteHelper.CharPosition.Down3));
		*/

        PlayerID = PlayerFactory.CreatePlayer();
	}
	
	// Update is called once per frame
	void Update () {
		
		InputSystem.Update();
        MovementSystem.Update();
		AnimSystem.Update();
		RenderSystem.Update();
	}
}
