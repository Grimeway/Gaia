using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    public Transform orientation;

    /// <summary>
    /// this function is used for the orientation of the player and the playercam. 
    /// </summary>
    void Update()
    {
        transform.rotation = orientation.transform.rotation;
    }
}
