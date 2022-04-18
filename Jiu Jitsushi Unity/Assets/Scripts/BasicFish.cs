/****
* Created by: Sage
* Date Created: April 13, 2022
* 
* Last Edited by: Sag
* Last Edited: April 13, 2022
* 
* Description: Controls fish basic movement
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFish : MonoBehaviour
{
    public float maxSpeed = 1f;
    public float speed = 1f;
    public float leftAndrightEdge = 10f;
    public float chanceToChangeDirections = 0.01f;
    private bool turningRight = false;
    private bool turningLeft = false;

    private void Start()
    {
    
    }
    // Update is called once per frame
    /*void Update()
    {
        if(turning == true)
        {

            return;
        }
        //Fish moves every frame
        
        if (pos.x < -leftAndrightEdge || pos.x > leftAndrightEdge)
        {
            Invoke("ChangeDirection", 0f);
        }

    }//end Update()*/

    private void FixedUpdate()
    {

        if (Random.value < chanceToChangeDirections)
        if(turningLeft == true)
        {
            speed -= .01f * maxSpeed;
            if(speed <= -maxSpeed)
            {
                speed = -maxSpeed;
                turningLeft = false;
            }
        }
        if (turningRight == true)
        {
            speed += .01f * maxSpeed;
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
                turningRight = false;
            }
        }
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x > leftAndrightEdge)
        {
            turningLeft = true;
        }
        if (pos.x < -leftAndrightEdge)
        {
            turningRight = true;
        }
    }
}
