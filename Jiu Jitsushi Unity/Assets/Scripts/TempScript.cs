using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScript : MonoBehaviour
{
    public GameObject harpoon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (harpoon.transform.position.y > -245)
        {
            Vector3 newTrans = new Vector3(this.transform.position.x, harpoon.transform.position.y, this.transform.position.z);
            this.transform.position = newTrans;
        }
        Debug.Log(harpoon.GetComponent<Rigidbody>().velocity);
    }
}
