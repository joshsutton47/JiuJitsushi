/****
 * Created by: Thomas Nguyen
 * Date Created: April 13, 2022
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

public class BoatManager : MonoBehaviour
{
    [Header("Ship Movement")]
    public float speed = 10;

    [Space(10)]

    [Header("Set in Inspector")]
    public GameObject[] harpoonPrefabs;
    public GameObject harpoonPrefab;
    private Vector3 initialVelocity;

    [Header("Set Dynamically")]
    private bool mousePress = false;
    private Camera cam;
    public Transform firePoint; //moved from set in inspector

    [HideInInspector] public int harpoonType = 0; //index to be used for what harpoon is used. We should figure out a set up for this later.


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
        pos.x += xAxis * speed * Time.deltaTime;
        transform.position = pos;

        // detects whether the mouse is clicking
        if (Input.GetMouseButtonDown(0))
        {
            mousePress = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mousePress = false;
            boatShoot();
        }

    }

    void FireProjectile()
    {
        /*
        GameObject projGo = Instantiate<GameObject>(projectilePrefab);
        //GameObject projGo = pool.GetObject();

        if (projGo != null)
        {
            projGo.transform.position = transform.position;
            Rigidbody rb = projGo.GetComponent<Rigidbody>();
            rb.velocity = Vector3.up * projectileSpeed;
        }*/




        // translates the mouse position to 2D and makes the boat follow the x and y direction (maybe use this for person on boat or something later)
        /***
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = cam.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y);

        initialVelocity = direction;
        transform.up = direction;
        ***/

    }

    private void boatShoot()
    {

        // Fires projectile, with additional force depending on the
        // distance of the mouse from the boat
        firePoint = this.transform;
        //GameObject harpoon = Instantiate(harpoonPrefabs[harpoonType], firePoint.position, gameObject.transform.rotation);
        GameObject harpoon = Instantiate(harpoonPrefab, firePoint.position, gameObject.transform.rotation);

        Rigidbody rb = harpoon.GetComponent<Rigidbody>();
        rb.AddForce(initialVelocity, ForceMode.Impulse);
    }

}
