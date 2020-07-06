using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// https://www.youtube.com/watch?v=iLlWirdxass
/// https://en.wikipedia.org/wiki/Projectile_motion
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class ThrowBall_Line : MonoBehaviour
{
    private LineRenderer lr;

    public GameObject TargetCircle;
    public float velocity = 1;
    public float angle = 1;
    public int resolution = 20;
    private float g;
    private float radianAngle;
    private Target_script targetScript;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics2D.gravity.y);
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
        targetScript = FindObjectOfType(typeof(Target_script)) as Target_script;
    }
    void Update()
    {
        OnValidate(targetScript.velocity, targetScript.angle);
        
    }

   
    private void OnValidate()
    { }

    private void OnValidate(float velocity, float angle)
    {
        if ((lr != null && Application.isPlaying))
        {
            this.angle = angle;
            this.velocity = velocity;
            RenderArc(velocity, angle);
        }
    }

    private void RenderArc(float velocity, float angle)
    {
        lr.positionCount = resolution + 1;
        lr.SetPositions(CalculateArcArray(velocity,angle));
        DrawHelpLine(CalculateArcArray(velocity, angle).Last());
        Debug.Log("max distance z point = " + CalculateArcArray(velocity, angle).LastOrDefault().z.ToString("n2"));
    }

    private void DrawHelpLine(Vector3 endPosition)
    {

        Debug.DrawLine(Vector3.zero, endPosition, Color.green, 2.5f);
    }

    public Vector3[] CalculateArcArray(float velocity, float angle)
    {
        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;

        Vector3[] arcArray = new Vector3[resolution + 1];
        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }
        return arcArray;
    }
    private Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float z = t * maxDistance;
        float y = z * Mathf.Tan(radianAngle) - ((g * z * z) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));       
        return new Vector3(0,y,z);
    }

}
