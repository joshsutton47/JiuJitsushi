/****
* Created by: Jeremiah Underwood
* Date Created: April 23, 2022
* 
* Last Edited by: Jeremiah Underwood
* Last Edited: April 23, 2022
* 
* Description: Handles Fish Collisions
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCatch : MonoBehaviour
{

    public GameObject[] skewerArray;
    public List<GameObject> fishCaught;
    private int skewers = 0;
    [SerializeField] private int maxSkewers;

    void Update()       //keeping to make sure collisions with fish don't happne after skewer is full, might do in collision function instead
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Fish") && (skewers < maxSkewers))           //only skewer if collided wiht a fish, and space is available
        {
            collision.gameObject.GetComponent<FishStick>().isStuck = true;
            collision.gameObject.GetComponent<FishStick>().harpoonPoint = skewerArray[skewers];
            fishCaught.Add(collision.gameObject);
            collision.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            skewers++; //iterate number of skewers
        }
    }
}
