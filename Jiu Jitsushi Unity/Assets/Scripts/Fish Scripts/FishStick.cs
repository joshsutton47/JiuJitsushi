/****
* Created by: Jeremiah Underwood
* Date Created: April 23, 2022
* 
* Last Edited by: Jeremiah Underwood
* Last Edited: April 23, 2022
* 
* Description: Controls fish sticking to harpoon
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStick : MonoBehaviour
{

    public GameObject harpoonPoint;
    public bool isStuck = false;
    private bool isMoveEnabled = true;

    void Update()
    {
        if (isStuck)
        {
            this.transform.position = harpoonPoint.transform.position;
            this.transform.rotation = harpoonPoint.transform.rotation;
            this.transform.Rotate(0, 0, 90, Space.Self);
        }
    }
}
