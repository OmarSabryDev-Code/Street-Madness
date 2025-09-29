using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPickup : MonoBehaviour
{
    public Color trailColor = Color.red; // set per paintbrush in Inspector

    private bool collected = false; // prevent double-triggering

    private void OnEnable()
    {
        // Every time this object is re-enabled (in a new segment), reset collected state
        collected = false;
        gameObject.SetActive(true);
        Debug.Log($"{name} activated at {transform.position}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!collected && other.CompareTag("Player"))
        {
            collected = true;

            // Change trail color
            TrailRenderer trail = other.GetComponentInChildren<TrailRenderer>();
            if (trail != null)
            {
                trail.material.color = trailColor;
            }

            Debug.Log($"Paintbrush {name} collected by {other.name}, color changed to {trailColor}");

            // Instead of destroying, just disable so prefab is unaffected
            gameObject.SetActive(false);
        }
    }
}
