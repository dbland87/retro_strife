using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{

    Camera cam;
    private int totalHeight;
    private int totalWidth;
    private float firstPositionXRatio = .25F;
    private float firstPositionYRatio = .20F;
    private float secondPositionXRatio = .35F;
    private float secondPositionYRatio = .32F;
    private float thirdPositionXRatio = .25F;
    private float thirdPositionYRatio = .50F;
    private float fourthPositionXRatio = .75F;
    private float fourthPositionYRatio = .20F;
    private float fifthPositionXRatio = .85F;
    private float fifthPositionYRatio = .32F;
    private float sixthPositionXRatio = .75F;
    private float sixthPositionYRatio = .50F;

    public Vector3 firstPosition;
    public Vector3 secondPosition;
    public Vector3 thirdPosition;
    public Vector3 fourthPosition;
    public Vector3 fifthPosition;
    public Vector3 sixthPosition;

    void Awake() {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        totalHeight = Screen.height;
        totalWidth = Screen.width;
        calculatePositions(totalWidth, totalHeight);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    private void calculatePositions(int screenWidth, int screeHeight)
    {
        firstPosition = cam.ScreenToWorldPoint(new Vector3(totalWidth * firstPositionXRatio, totalHeight * firstPositionYRatio));
        secondPosition = cam.ScreenToWorldPoint(new Vector3(totalWidth * secondPositionXRatio, totalHeight * secondPositionYRatio));
        thirdPosition = cam.ScreenToWorldPoint(new Vector3(totalWidth * thirdPositionXRatio, totalHeight * thirdPositionYRatio));
        fourthPosition = cam.ScreenToWorldPoint(new Vector3(totalWidth * fourthPositionXRatio, totalHeight * fourthPositionYRatio));
        fifthPosition = cam.ScreenToWorldPoint(new Vector3(totalWidth * fifthPositionXRatio, totalHeight * fifthPositionYRatio));
        sixthPosition = cam.ScreenToWorldPoint(new Vector3(totalWidth * sixthPositionXRatio, totalHeight * sixthPositionYRatio));
    }
}
