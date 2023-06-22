using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    //always shows the current amount of lives

    [SerializeField]
    private Text _livesText;

    [SerializeField]
    private Text _statusText;

    //updates the lives after the lives changed
    public void updateLives (int health) 
    {
        _livesText.text = "Lives: " + health;
    }

    public void gameOver() 
    {
        _statusText.text = "Game Over";
    }

    public void win() 
    {
        _statusText.text = "You won";
    }
}
