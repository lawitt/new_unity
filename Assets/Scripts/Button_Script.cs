using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour
{
    //button is shown on start screen or between levels, when pressed the next level starts
    [SerializeField]
    private string _newGameLevel;

    //start next level
    public void NewGameButton()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

}
