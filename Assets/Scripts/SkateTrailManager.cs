using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateTrailManager : MonoBehaviour
{
    [SerializeField] private TrailRenderer trail;

    void Start()
    {
        if (trail == null)
            trail = GetComponent<TrailRenderer>();
    }

    public void ChangeTrailColor(Color newColor)
    {
        trail.startColor = newColor;
        trail.endColor = newColor * 0.8f; // Slightly darker fade
    }
}