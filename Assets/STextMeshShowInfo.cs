using UnityEngine;
using System.Collections;
using Assets;

public static class STextMeshShowInfo
{
    public static void ShowAngleAndVelocity(TextMesh textmesh, float angle, float velocity)
    {
        textmesh.text = "left decreases(arrow) || right increases; Angle : " + angle.ToString("n2");
        textmesh.text += "\ndown decreases(arrow) || up increases; Velocity : " + velocity.ToString("n2");     
    }

    public static void ShowRotationAngle(TextMesh textmesh, float angleRotation)
    {
        textmesh.text = "A (Key) - decreases || D (Key) - increases; Rotation Angle : " + angleRotation.ToString("n2");  
    }

}
