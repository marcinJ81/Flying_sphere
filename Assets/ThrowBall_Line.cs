using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TypeArcPointCalcuate
{
    ZeroYZ,
    XYZ,
    XYZero
}
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
        lr.SetPositions(CalculateArcArray(velocity,angle,TypeArcPointCalcuate.ZeroYZ));
        DrawHelpLine(CalculateArcArray(velocity, angle, TypeArcPointCalcuate.ZeroYZ).Last());
        DrawHelpLine(CalculateArcArray(velocity, angle, TypeArcPointCalcuate.XYZero).Last());
        DrawHelpLine(CalculateArcArray(velocity, angle,10, TypeArcPointCalcuate.XYZ).Last());
        //draw circle
           CreatePoints(CalculateArcArray(velocity, angle, TypeArcPointCalcuate.ZeroYZ).Last());
       // Debug.Log("max distance z point = " + CalculateArcArray(velocity, angle).LastOrDefault().z.ToString("n2"));
    }

    private void DrawHelpLine(Vector3 endPosition)
    {
        Debug.DrawLine(Vector3.zero, endPosition, Color.green, 2.5f);
    }
    public Vector3[] CalculateArcArray(float velocity, float angle, TypeArcPointCalcuate typeArcPointCalcuate)
    {
        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;

        Vector3[] arcArray = new Vector3[resolution + 1];
        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPointXYZ(t, maxDistance, typeArcPointCalcuate);
        }
        return arcArray;
    }
    public Vector3[] CalculateArcArray(float velocity, float angle, float sideTriangle, TypeArcPointCalcuate typeArcPointCalcuate)
    {
        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;

        Vector3[] arcArray = new Vector3[resolution + 1];
        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPointXYZ(t, maxDistance,sideTriangle,typeArcPointCalcuate);
        }
        return arcArray;
    }

    private Vector3 CalculateArcPointXYZ(float t, float maxDistance, TypeArcPointCalcuate typeArcPointCalcuate)
    {
        float s = t * maxDistance;
        float y = s * Mathf.Tan(radianAngle) - ((g * s * s) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        float x = 0;
        float z = 5;
        if (TypeArcPointCalcuate.XYZ == typeArcPointCalcuate)
        {
            x = Mathf.Sqrt((s * s) +  (z*z));
            //c = SQRT((a*a)+(b*b)) pitagoras    
        }
        if (TypeArcPointCalcuate.XYZero == typeArcPointCalcuate)
        {
            x = s;
        }
        if (TypeArcPointCalcuate.ZeroYZ == typeArcPointCalcuate)
        {
            z = s;
        }
        return new Vector3(x, y, z);
    }
    private Vector3 CalculateArcPointXYZ(float t, float maxDistance,float sideTriangle ,TypeArcPointCalcuate typeArcPointCalcuate)
    {
        float s = t * maxDistance;
        float y = s * Mathf.Tan(radianAngle) - ((g * s * s) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        float x = sideTriangle;
        float z = s;
        if (TypeArcPointCalcuate.XYZ == typeArcPointCalcuate)
        {
            //x = Mathf.Sqrt((s * s) + (z * z));
           //c = SQRT((a*a)+(b*b)) pitagoras    
        }
        if (TypeArcPointCalcuate.XYZero == typeArcPointCalcuate)
        {
            x = s;
        }
        if (TypeArcPointCalcuate.ZeroYZ == typeArcPointCalcuate)
        {
            z = s;
        }
        return new Vector3(x, y, z);
    }

    private void CreatePoints( Vector3 maxDistance)
    {
        if (maxDistance.z > 0)
        {
            int segments = 50;
           
            float x;
            float z;


            float angle = 1f;

            for (int i = 0; i < (segments + 1); i++)
            {
                z = Mathf.Sin(SAngleToRadian.AngleToRadian(angle)) * maxDistance.z;
                x = Mathf.Cos(SAngleToRadian.AngleToRadian(angle)) * maxDistance.z;

                Vector3 endPoint = new Vector3(x, 0, z);
                Debug.DrawLine(maxDistance, endPoint, Color.red, 2.5f);
                angle += (360f / segments);
            }
        }
    }
}

