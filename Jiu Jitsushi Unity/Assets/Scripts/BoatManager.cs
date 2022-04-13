<<<<<<< Updated upstream
=======
/****
 * Created by: Thomas Nguyen
 * Date Created: April 13, 2022
 * 
 * 
 * Last Edited by: Thomas Nguyen
 * Lasted Edited: April 13, 2022
 * Description: Controls the cannon and the projectiles shot
 * 
****/

>>>>>>> Stashed changes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{

<<<<<<< Updated upstream
    [Header("Ship Movement")]
    public float speed = 10;

    [Space(10)]
    [Header("Projectile Settings")]
    public GameObject projectilePrefab; //the game object of the projectile
    public float projectileSpeed; //speed of the projectile
=======
    [Header("Set in Inspector")]
    public GameObject harpoonPrefab;
    public Transform firePoint;
    private Vector3 initialVelocity;

    [Header("Set Dynamically")]
    private bool mousePress = false;
    private Camera cam;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        
=======
        cam = Camera.main; //set the camera to the current scene's camera
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        //player input
        float xAxis = Input.GetAxis("Horizontal");

        //Change the transform based on the axis
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }

    }

    void FireProjectile()
    {
        GameObject projGo = Instantiate<GameObject>(projectilePrefab);
        //GameObject projGo = pool.GetObject();

        if (projGo != null)
        {
            projGo.transform.position = transform.position;
            Rigidbody rb = projGo.GetComponent<Rigidbody>();
            rb.velocity = Vector3.up * projectileSpeed;
        }

=======
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

        // translates the mouse position to 2D and makes the cannon follow the x and y direction
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = cam.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y);

        initialVelocity = direction;
        transform.up = direction;

    }

    private void boatShoot()
    {
        // Fires projectile, with additional force depending on the
        // distance of the mouse from the cannon
        GameObject harpoon = Instantiate(harpoonPrefab, firePoint.position, gameObject.transform.rotation);

        Rigidbody rb = harpoon.GetComponent<Rigidbody>();
        rb.AddForce(initialVelocity, ForceMode.Impulse);
>>>>>>> Stashed changes
    }

}
