using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour
{
    [SerializeField]
    private string _newGameLevel;

    /**[SerializeField]
    private GameObject _player;**/

    public void NewGameButton()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    /**public void changePlayer ()
    {
        _player.changeColor();
    }**/

}
