using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCatch : MonoBehaviour
{

    public GameObject[] skewerArray;
    private int skewers = 0;
    [SerializeField] private int maxSkewers;

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Fish") && (skewers < maxSkewers))
        {
            collision.gameObject.GetComponent<FishStick>().isStuck = true;
            collision.gameObject.GetComponent<FishStick>().harpoonPoint = skewerArray[skewers];
            collision.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            skewers++;
        }
    }
}
