using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialGather : MonoBehaviour
{

    public float hitCount = 0;

    public GameObject brokenOrePrefab;

    void HitByRay()
    {
        hitCount += 1;
        Debug.Log("Object is hit");
        isObjectDestroyed();
    }

    void isObjectDestroyed()
    {
        if (hitCount == 5 && (gameObject.name != "PT_Ore_Rock_01"))
        {
            Destroy(gameObject);
        } 
        if (hitCount == 5 && (gameObject.name == "PT_Ore_Rock_01"))
        {
            GameObject brokenOre = Instantiate(brokenOrePrefab, transform.position, transform.rotation);
            Debug.Log("doet die iets?");
            brokenOre.name = "waaromdoetdiehetniet?";
            Destroy(gameObject);
            Debug.Log("hier wel? ");
        }
    }

}
