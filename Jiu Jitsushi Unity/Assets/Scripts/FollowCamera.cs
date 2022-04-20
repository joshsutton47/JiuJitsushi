/*** 
 * Created by: Josh Sutton
 * Date created: April 18, 2022
 * 
 * Last editted by: Josh Sutton
 * Last edited:  April 18, 2022
 * 
 * Description: Controls the camera movement and object tracking
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    #region Variables
    /// Variables ///
<<<<<<< Updated upstream
    
=======

>>>>>>> Stashed changes
    [Header("Set in Inspector")]
    public GameObject POI;
    public float easing = 0.05f;

    [Header("Set Dynamically")]
    public float camZ;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        camZ = this.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 destination;
        if (POI == null)
        {
            destination = Vector3.zero;
            destination.z = camZ;
            transform.position = destination;
        }
        else
        {
            destination = POI.transform.position;
        }

        //Interpolate from the current camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);

        //Force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        transform.position = destination;

        //Camera.main.orthographicSize = destination.y + 10;
    }
}
