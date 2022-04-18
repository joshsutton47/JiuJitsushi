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
    public float speed = 1f;
    public float leftAndrightEdge = 10f;
    public float chanceToChangeDirections = 0.01f;

    private void Start()
    {
        Debug.Log("Started");
    }
    // Update is called once per frame
    void Update()
    {
        //Fish moves every frame
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndrightEdge || pos.x > leftAndrightEdge)
        {
            Invoke("ChangeDirection", 0f);
        }

    }//end Update()

    private void FixedUpdate()
    {
        //Debug.Log("Tried");
        if (Random.value < chanceToChangeDirections)
        {
            Invoke("ChangeDirection", 0f);
        }
    }

    private void ChangeDirection()
    {
        speed *= -1;
    }
}
