using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintMechanic : MonoBehaviour
{
    [SerializeField] GameObject spriteMask_1;
    [SerializeField] GameObject spriteMask_2;
    [SerializeField] Camera spriteMaskCamera;
    [SerializeField] Transform playerLocation;
    [SerializeField] float radius;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            Vector3 worldSpace = spriteMaskCamera.ScreenToWorldPoint(Input.mousePosition);
            worldSpace.z = 0;
            float distance = Vector3.Distance(worldSpace, playerLocation.position);
            if (distance <= radius) {
                Instantiate(spriteMask_1, worldSpace, Quaternion.identity);
                Instantiate(spriteMask_2, worldSpace, Quaternion.identity);
            }
        }
    }
}
