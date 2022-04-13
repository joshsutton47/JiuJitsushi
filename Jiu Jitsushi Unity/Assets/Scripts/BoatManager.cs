using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{

    [Header("Ship Movement")]
    public float speed = 10;

    [Space(10)]
    [Header("Projectile Settings")]
    public GameObject projectilePrefab; //the game object of the projectile
    public float projectileSpeed; //speed of the projectile

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

    }

}
