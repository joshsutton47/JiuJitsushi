/****
 * Created by: Thomas Nguyen
 * Date Created: April 13, 2022
 * 
 * 
 * Last Edited by: Thomas Nguyens
 * Lasted Edited: April 24, 2022
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
    public Vector3 firePoint; //moved from set in inspector, also changed from a transform to just a vector to fix some bugs
    [HideInInspector] public int harpoonType = 0;    //0 = basic, 1 = long (testing)

    public bool harpoonThrown = false;

    public AudioSource source;
    public AudioClip splash;
    public AudioClip money;

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
        firePoint = transform.position;
        firePoint.z += 1;

        // detects whether the mouse is clicking
        if (!harpoonThrown && Input.GetKeyDown(KeyCode.Space))
        {
            boatShoot();
        }

    }

    private void boatShoot()
    {
        source.PlayOneShot(splash, 1f);
        //harpoonThrown = true;                                                                                   //doing this will make this variable obsolete, but it will be left in as to not confuse
        GameObject harpoon = Instantiate(harpoonPrefabs[harpoonType], firePoint, Quaternion.identity);
        harpoon.GetComponent<ReelIn>().source = this;

        /*if (harpoon != null)
        {
            harpoon.transform.position = transform.position;
            Rigidbody rb = harpoon.GetComponent<Rigidbody>();
            rb.velocity = Vector3.down * projectileSpeed;
        }*/
        this.enabled = false;                                                   //different way of making sure multiple harpoons arent thrown that will also prevent boat from moving
    }

    public void harpoonSwap()
    {
        harpoonType++;
        //GameObject harpoon = Instantiate<GameObject>(harpoonPrefabs[harpoonType]);
    }

}
