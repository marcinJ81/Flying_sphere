using UnityEngine;
using System.Collections;

public class AngleControl : MonoBehaviour
{
    public float rotationAngle { get; private set; }
    public GameObject InfoTextObject;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode key = SKeyDetecion.KeysDown().Any() ? SKeyDetecion.KeysDown().First() : KeyCode.AltGr;
        if ((key == KeyCode.RightArrow || key == KeyCode.LeftArrow))
        {
            this.angle = strategy.StrategyTochange(key, this.angle);
        }
        if (key == KeyCode.DownArrow || key == KeyCode.UpArrow)
        {
            this.velocity = strategy.StrategyTochange(key, this.velocity);
        }
        ShowSpeedDistanceMassAboutBall(InfoTextObject.GetComponent(typeof(TextMesh)) as TextMesh);
    }
}
