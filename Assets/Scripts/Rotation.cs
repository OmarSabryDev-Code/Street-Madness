using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
   public float rotationSpeed = 50f;    // How fast it rotates
    public float floatAmplitude = 0.25f; // How high it floats
    public float floatFrequency = 1f;    // How fast it floats

    private Vector3 startPos;

    void Start()
    {
        // Remember starting position so we can float around it
        startPos = transform.position;
    }

    void Update()
    {
        // Rotate around the Y axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        // Float up and down using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
