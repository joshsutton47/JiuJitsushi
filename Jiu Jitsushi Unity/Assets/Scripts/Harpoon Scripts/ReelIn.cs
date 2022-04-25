/*** 
 * Created by: Jeremiah Underwood
 * Date created: April 24, 2022
 * 
 * Last editted by: Jeremiah Underwood
 * Last edited:  April 24, 2022
 * 
 * Description: Controls the reeling in function
 ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelIn : MonoBehaviour
{

    private bool isReeling = false;
    private Vector3 spawnPos;
    public float reelSpeed;
    public BoatManager source;        //reference set when harpoon fired, to enable boat after return

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartReel();
        }
    }
    private void FixedUpdate()
    {
        if (isReeling)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnPos, reelSpeed);
            if ((this.transform.position - spawnPos).magnitude < 1)
            {
                source.enabled = true;
                foreach (GameObject item in this.GetComponent<FishCatch>().fishCaught)
                {
                    Destroy(item);
                }
                source.source.PlayOneShot(source.money, 1f);
                Destroy(this.gameObject);
            }
        }
    }

    void StartReel()
    {
        if (!isReeling) //set up the reeling in when space is pressed
        {
            isReeling = true;
            this.GetComponent<HarpoonManager>().enabled = false;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
            this.GetComponent<CapsuleCollider>().enabled = false;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnEnable()
    {
        spawnPos = this.transform.position;   //set the point to return to
        spawnPos.z += 1;
    }
}
