using UnityEngine;
using System.Collections;

public static class STextMeshShowInfo 
{
    public static TextMesh ShowSpeedDistanceMassAboutBall(TextMesh textmesh, float angle, float velocity)
    {
        textmesh.text = "left decreases(arrow) || right increases; Angle : " + angle.ToString("n2");
        textmesh.text += "\ndown decreases(arrow) || up increases; Velocity : " + velocity.ToString("n2");

        return textmesh;
    }

    public static TextMesh ShowRotationAngle(TextMesh textmesh, float anglerotation)
    {
        textmesh.text = "A (Key) - decreases || D (Key) - increases; Angle : " + anglerotation.ToString("n2");
        
        return textmesh;
    }

}
