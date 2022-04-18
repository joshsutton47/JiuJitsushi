/****
 * Created by: Jeremiah Underwood
 * Date Created: April 18, 2022
 * 
 * 
 * Last Edited by: Jeremiah Underwood
 * Lasted Edited: April 18, 2022
 * Description: Controls the cannon and the projectiles shot
 * 
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonManager : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject boat;

    [Header("Movement")]
    public float speed = 10;

    //private Vector3 boatLocation;
    //public float easing = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player input
        float xAxis = Input.GetAxis("Horizontal");

        //Change the transform based on the axis
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        transform.position = pos;

        // Fragments of moving the harpoon back to the boat
        /*if(Input.GetKeyDown(KeyCode.Space)){
            if(boat != null)
            {
                Debug.Log("space pressed");
                boatLocation = Vector3.Lerp(transform.position, boatLocation, easing);
                this.gameObject.transform.position = boatLocation;

            }
        }*/
    }

    
}
