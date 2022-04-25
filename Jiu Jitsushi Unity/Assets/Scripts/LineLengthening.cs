using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineLengthening : MonoBehaviour
{
    public Text text;
    public float[] lengthChanges = { 90, 60 }; // the different lengths to change the line per purchase
    public int[] costs = { 1000, 2500 }; // the different costs of the line length changes
    private int purchases = 0;
    
    // Start is called before the first frame
    private void Start()
    {
        text.text = "Increase Line Length\nCost: $" + costs[purchases].ToString();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void AddLength()      //adds line length
    {

        if (GameManager.score >= costs[purchases])                   //only lengthen line if player has enough money
        {
            GameManager.GM.UpdateScore(-1 * costs[purchases]);          //pay
            GameManager.maxDepth -= lengthChanges[purchases];            //increase depth
            purchases++;                                                    //iterate number of purchases
        }
        if (purchases > 1) Destroy(this.gameObject);                                //destroy object if not needed
        text.text = "Increase Line Length\nCost: $" + costs[purchases].ToString();       //change text

    }
}
