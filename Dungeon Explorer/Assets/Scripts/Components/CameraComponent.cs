using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct Camera
{
    public uint EntityID;

    public bool Enabled;

    public bool HasTarget;

    public uint TargetID;

    public GameObject CameraObject;
}

public class CameraComponent : GameComponent<Camera>
{
    public override void Add(uint elementID, Camera component)
    {
        component.CameraObject = (GameObject)Object.Instantiate(Resources.Load("Prefabs/Camera"));
        base.Add(elementID, component);
    }
}