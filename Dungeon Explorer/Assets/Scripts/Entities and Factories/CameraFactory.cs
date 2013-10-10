using UnityEngine;
using System;
using System.Collections.Generic;

public static class CameraFactory
{
    public static uint CreateCamera(bool isEnabled)
    {
        uint id = IDManager.GetNewID();

        Camera newCam = new Camera()
        {
            EntityID = id,
            Enabled = isEnabled,
            HasTarget = false,
            TargetID = 0
        };
        ComponentManager.CameraComponent.Add(id, newCam);

        Position newPosition = new Position()
        {
            EntityID = id,
            Center = Vector3.zero
        };
        ComponentManager.PositionComponent.Add(id, newPosition);

        return newCam.EntityID;
    }

    public static uint CreateCamera(uint targetID, bool isEnabled)
    {
        uint id = IDManager.GetNewID();

        Camera newCam = new Camera()
        {
            EntityID = id,
            Enabled = isEnabled,
            HasTarget = true,
            TargetID = targetID
        };
        ComponentManager.CameraComponent.Add(id, newCam);

        Position newPosition = new Position()
        {
            EntityID = id,
            Center = Vector3.zero
        };
        ComponentManager.PositionComponent.Add(id, newPosition);

        return newCam.EntityID;
    }
}
