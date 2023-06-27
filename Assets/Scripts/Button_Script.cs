using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour
{
    [SerializeField]
    private string _newGameLevel;

    public void NewGameButton()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

}
