using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenOre : MonoBehaviour
{

    float delay = 5;
    public GameObject ore; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delay);
        Instantiate(ore, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
