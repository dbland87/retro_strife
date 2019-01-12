using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFinder : MonoBehaviour
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

    public Vector2 firstPosition;
    public Vector2 secondPosition;
    public Vector2 thirdPosition;
    public Vector2 fourthPosition;
    public Vector2 fifthPosition;
    public Vector2 sixthPosition;

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
        firstPosition = cam.ScreenToWorldPoint(new Vector2(totalWidth * firstPositionXRatio, totalHeight * firstPositionYRatio));
        secondPosition = cam.ScreenToWorldPoint(new Vector2(totalWidth * secondPositionXRatio, totalHeight * secondPositionYRatio));
        thirdPosition = cam.ScreenToWorldPoint(new Vector2(totalWidth * thirdPositionXRatio, totalHeight * thirdPositionYRatio));
        fourthPosition = cam.ScreenToWorldPoint(new Vector2(totalWidth * fourthPositionXRatio, totalHeight * fourthPositionYRatio));
        fifthPosition = cam.ScreenToWorldPoint(new Vector2(totalWidth * fifthPositionXRatio, totalHeight * fifthPositionYRatio));
        sixthPosition = cam.ScreenToWorldPoint(new Vector2(totalWidth * sixthPositionXRatio, totalHeight * sixthPositionYRatio));
    }

    public Vector2 getVector2FromPositionId(int positionId) 
    {
        switch (positionId) 
        {
            case 0: return firstPosition;
            case 1: return secondPosition;
            case 2: return thirdPosition;
            case 3: return fourthPosition;
            case 4: return fifthPosition;
            case 5: return sixthPosition;
            default: 
            {
                Debug.Log("Cannot find Vector2 corresponding with supplied position id: " + positionId);
                return new Vector2(0,0);
            }
        }
    }
}
