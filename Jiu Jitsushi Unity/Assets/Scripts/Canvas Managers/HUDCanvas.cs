/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: 
 * Last Edited: 
 * 
 * Description: Updates Heads Up Display (HUD) canvas referencing the game manager
****/

/*** Using Namespaces ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : MonoBehaviour
{
    /*** VARIABLES ***/

    GameManager gm; //reference to game manager

    [Header("Canvas SETTINGS")]
    public Text scoreTextbox; //textbox for the score
    public Text highScoreTextbox; //textbox for highscore
    
    //GM Data
    private int score;
    private int highscore;
    
    /*** MEHTODS ***/
    private void Start()
    {
        gm = GameManager.GM; //find the game manager

        SetHUD();
    }//end Start

    // Update is called once per frame
    void Update()
    {
        GetGameStats();
        SetHUD();
    }//end Update()

    void GetGameStats()
    {
        score = gm.Score;
        highscore = gm.HighScore;
    }

    void SetHUD()
    {
        //if texbox exsists update value
        if (scoreTextbox) { scoreTextbox.text = "CASH: $" + score; }
        if (highScoreTextbox) { highScoreTextbox.text = "High Score " + highscore; }

    }//end SetHUD()

}
