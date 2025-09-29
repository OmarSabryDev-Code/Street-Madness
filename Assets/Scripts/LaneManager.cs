using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LaneManager : MonoBehaviour
{
    public static LaneManager Instance;

    public float laneOffset = 2.5f; // Distance between lanes
    public int currentLane = 2; // Start at middle (0 to 4)

    private void Awake()
    {
        Instance = this;
    }

    public Vector3 GetLanePosition(int laneIndex)
    {
        return new Vector3((laneIndex - 2) * laneOffset, 0, 0); // Centered at 0
    }
}
