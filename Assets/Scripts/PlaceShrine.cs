using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceShrine : MonoBehaviour
{

    public GameObject shrine;
    public GameObject text;
    public GameObject shrineText;
    private bool triggerEntered = false;

    /// <summary>
    /// a simple check to see if the player is in the cube in order to build the shrine. also shows story text when the shrine is build. 
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && triggerEntered == true)
        {
            Instantiate(shrine, transform.position, transform.rotation);
            shrineText.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            shrineText.SetActive(false);
        }
    }
    
    //a variable set to see if the player is in or outside of the cube
    private void OnTriggerEnter()
    {
        text.SetActive(true);
        triggerEntered = true;
    }

    private void OnTriggerExit()
    {
        text.SetActive(false);
        triggerEntered = false;
    }

    
}
