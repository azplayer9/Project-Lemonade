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
    float timer;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer > 0.1f) { 
            timer = 0;
            Vector3 worldSpace = spriteMaskCamera.ScreenToWorldPoint(Input.mousePosition);
            worldSpace.z = 0;
            float distance = Vector3.Distance(worldSpace, playerLocation.position);
            if (distance <= radius && Time.timeScale == 1) {
                GameObject temp_1 = Instantiate(spriteMask_1, worldSpace, Quaternion.identity);
                GameObject temp_2 = Instantiate(spriteMask_2, worldSpace, Quaternion.identity);

                Destroy(temp_1,0.2f);
                Destroy(temp_2,0.2f);                

            }
        }
    }
    
}
