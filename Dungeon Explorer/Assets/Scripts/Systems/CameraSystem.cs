using UnityEngine;
using System;
using System.Collections.Generic;

public static class CameraSystem
{
    public static void Update()
    {
        foreach (uint key in ComponentManager.CameraComponent.Keys)
        {
            Camera cam = ComponentManager.CameraComponent[key];
            Position camPos = ComponentManager.PositionComponent[key];

            cam.CameraObject.SetActive(cam.Enabled);

            if (cam.HasTarget)
            {
                Position targetPos = ComponentManager.PositionComponent[cam.TargetID];

                camPos.Center = targetPos.Center;
                float cameraZ = cam.CameraObject.transform.position.z;
                cam.CameraObject.transform.position = new Vector3(camPos.Center.x, camPos.Center.y, cameraZ);
            }

            ComponentManager.PositionComponent[key] = camPos;
            ComponentManager.CameraComponent[key] = cam;

        }
    }

    public static void EnableCamera(uint cameraID)
    {
        foreach (uint key in ComponentManager.CameraComponent.Keys)
        {
            Camera cam = ComponentManager.CameraComponent[key];

            if (key == cameraID)
                cam.Enabled = true;
            else
                cam.Enabled = false;

            ComponentManager.CameraComponent[key] = cam;
        }
    }
}