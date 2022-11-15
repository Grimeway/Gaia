using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    public Transform orientation;

    void start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = orientation.transform.rotation;
    }
}
