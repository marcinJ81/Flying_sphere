using UnityEngine;
using System.Collections;
using Assets;
using System.Linq;

public class AngleControl : MonoBehaviour
{
    public float rotationAngle { get; private set; }
    public GameObject InfoTextObject;
    private StrategyForChangeAngleAndVelocity strategy;
    // Use this for initialization
    private void Awake()
    {
        strategy = new StrategyForChangeAngleAndVelocity();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode key = SKeyDetecion.KeysDown().Any() ? SKeyDetecion.KeysDown().First() : KeyCode.AltGr;
        if ((key == KeyCode.RightArrow || key == KeyCode.LeftArrow))
        {
            this.rotationAngle = strategy.StrategyTochange(key, this.rotationAngle);
        }
        //Textmesh not exist in unity interface
        //STextMeshShowInfo.ShowRotationAngle(InfoTextObject.GetComponent(typeof(TextMesh)) as TextMesh,this.rotationAngle);
    }
}
