using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenOre : MonoBehaviour
{

    float delay = 5;
    public GameObject ore; 

    // function to destroy itself after a while and spawn in a new gameobject of 'ore' 
    void Start()
    {
        Destroy(gameObject, delay);
        Instantiate(ore, transform.position, transform.rotation);
    }

}
