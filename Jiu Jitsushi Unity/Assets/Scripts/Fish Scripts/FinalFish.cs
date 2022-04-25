/****
* Created by: Jeremiah Underwood
* Date Created: April 24, 2022
* 
* Last Edited by: Jeremiah Underwood
* Last Edited: April 25, 2022
* 
* Description: Controls fish basic movement and ends game
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //libraries for accessing scenes

public class FinalFish : MonoBehaviour
{
    [Header("Fish Settings")]
    public float maxSpeed = 1f;
    private float speed;
    public float leftAndrightEdge = 10f;
    public float chanceToChangeDirections = 0.01f;
    private bool turningRight = false;
    private bool turningLeft = false;
    public int score = 100;

    BoatManager bm;

    private void Start()
    {
        speed = maxSpeed;
    }

    private void FixedUpdate()
    {
        if (turningLeft == true)
        {
            speed -= .01f * maxSpeed;
            if (speed < 0)                                    //flip directions when ready, a bit jank of a solution but it will do for now
            {
                Vector3 newScale = transform.localScale;
                newScale.y = -1;
                transform.localScale = newScale;
            }
            if (speed <= -maxSpeed)
            {
                speed = -maxSpeed;
                turningLeft = false;
            }
        }
        if (turningRight == true)
        {
            speed += .01f * maxSpeed;
            if (speed > 0)                                         //see above
            {
                Vector3 newScale = transform.localScale;
                newScale.y = 1;
                transform.localScale = newScale;
            }
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

    public void OnDestroy()
    {
        SceneManager.LoadScene("end_scene");         //ends game when this fish is caught
    }
}
