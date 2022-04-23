/****
 * Created by: Thomas Nguyen
 * Date Created: April 13, 2022
 * 
 * 
 * Last Edited by: Jeremiah Underwood
 * Lasted Edited: April 23, 2022
 * Description: Controls the Boat movement and fires harpoons
 * 
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{
    [Header("Ship Movement")]
    public float boatSpeed = 10;

    [Space(10)]
    [Header("Projectile Settings")]
    //public float projectileSpeed; //speed of the projectile
    public GameObject[] harpoonPrefabs;

    [Header("Set Dynamically")]
    private Camera cam;
    public Transform firePoint; //moved from set in inspector
    [HideInInspector] public int harpoonType = 0;    //0 = basic, 1 = long (testing)

    public bool harpoonThrown = false;


    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main; //set the camera to the current scene's camera

    }

    // Update is called once per frame
    void Update()
    {

        //player input
        float xAxis = Input.GetAxis("Horizontal");

        //Change the transform based on the axis
        Vector3 pos = transform.position;
        pos.x += xAxis * boatSpeed * Time.deltaTime;
        transform.position = pos;

        // detects whether the mouse is clicking
        if (!harpoonThrown && Input.GetKeyDown(KeyCode.Space))
        {
            boatShoot();
        }

    }

    private void boatShoot()
    {
        harpoonThrown = true;
        GameObject harpoon = Instantiate(harpoonPrefabs[harpoonType], firePoint.position, Quaternion.identity);
        Debug.Log(harpoonType);

        if (harpoon != null)
        {
            //harpoon.transform.position = transform.position;
            Rigidbody rb = harpoon.GetComponent<Rigidbody>();
            //rb.velocity = Vector3.down * projectileSpeed;
        }
    }

}
