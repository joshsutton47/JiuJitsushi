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
    [Header("Movement")]
    public float fallSpeed;                       //base speed the harpoon falls
    public float fallChange;                      //amount the fallspeed will change with the w and s keys
    public float fallAccel;                       //how fast the speed of the harpoon changes
    public float fallSnap;                        //threshhold for the falling to snap to the correct speed
    public float speed = 10;                     //turn speed
    public float accel = 1;                      //how quickly the harpoon will go to it's maximum move commit
    public float snapSpeed = 1;                   //how quickly the harpoon will return to 0
    private float moveCommit;                       //increases to a maximum of 1 depending on how long it's been moving in one direction;
    [SerializeField] private float rotationMult;    //how far the harpoon will multiply

    [Header("Camera Settings")]
    private FollowCamera cam;

    // Start is called before the first frame update
    void Start()
    {
        moveCommit = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //player input
        int xAxis = 0;
        int yAxis = 0;
        if (Input.GetKey(KeyCode.A)) xAxis -= 1;
        if (Input.GetKey(KeyCode.D)) xAxis += 1;
        if (Input.GetKey(KeyCode.W)) yAxis -= 1;
        if (Input.GetKey(KeyCode.S)) yAxis += 2;

        //chagne move commit
        float moveCommitChange = 0;
        if (xAxis == 0)
        {                                              //goes back to 0 or changes based on direction
            if (Mathf.Abs(moveCommit) < 0.1) moveCommit = 0;
            else
            {
                moveCommitChange = -moveCommit * snapSpeed * Time.deltaTime;
                moveCommit += moveCommitChange;
            }
        }
        else
        {
            moveCommitChange = xAxis * accel * Time.deltaTime;
            float moveComAbs = Mathf.Abs(moveCommit);               //absolute value of move commit
            if (!(Mathf.Abs(moveCommit + moveCommitChange) > 1)) moveCommit += moveCommitChange;   //change move commit if not already at +/- 1
            else moveCommit = moveCommit / moveComAbs;
        }

        //Change the transform based on the axis
        Vector3 pos = transform.position;
        pos.x += speed * moveCommit;
        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, 0, moveCommit * rotationMult);                      //rotates with movement

        //change fall speed
        float speedGoal = -fallSpeed - (fallChange * yAxis);
        float currentSpeed = this.GetComponent<Rigidbody>().velocity.y;
        float speedChange = (Mathf.Abs(currentSpeed) - Mathf.Abs(speedGoal));
        if (Mathf.Abs(speedChange) < fallSnap)
        {
            //this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, speedGoal, this.GetComponent<Rigidbody>().velocity.z);
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, speedGoal, 0);
        }
        else
        {
            //this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, currentSpeed + (speedChange * fallAccel), this.GetComponent<Rigidbody>().velocity.z);
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, currentSpeed + (speedChange * fallAccel), 0);
        }
        //Debug.Log(currentSpeed);

        //keep above max depth

        pos = transform.position;  //reuse pos keyword since previous use is over
        if (pos.y < GameManager.maxDepth) pos.y = GameManager.maxDepth;
        transform.position = pos;


    }
    private void OnEnable()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
        cam.POI = this.gameObject;

    }

    private void OnDestroy()
    {
        cam.POI = GameObject.FindGameObjectWithTag("Boat");
    }
}