using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    [SerializeField] private float parallaxEffectMultiplier;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    // Start is called before the first frame update
    private void Start()
    {
        // Set up with the main camera
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        // Move relative to the camera
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        //float parallaxEffectMultiplier = .5f;

        transform.position += deltaMovement * parallaxEffectMultiplier;
        lastCameraPosition = cameraTransform.position;
    }
}
