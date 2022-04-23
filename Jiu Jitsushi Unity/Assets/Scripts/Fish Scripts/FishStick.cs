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
        if (isStuck)                                                       //only activate if need be
        {
            this.transform.position = harpoonPoint.transform.position;       //move to position
            this.transform.rotation = harpoonPoint.transform.rotation;        //rotate
            this.transform.Rotate(0, 0, 90, Space.Self);                     //rotate again so not sticking strait up
        }
    }
}
