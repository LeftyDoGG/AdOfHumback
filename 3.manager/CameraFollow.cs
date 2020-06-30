using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The position that camera will be following.
    public float smooth = 5f; // camera speed. 
    Vector3 offset; // The initial offset from the target.

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
    
        Vector3 targetCampos = target.position + offset; // Create a postion the camera is aiming for based on the offset from the target.
        transform.position = Vector3.Lerp (transform.position, targetCampos,smooth); // Smoothly between the camera's current position and it's target position.
    }
}
