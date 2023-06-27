using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    //change the scene from "level 1" to "level 2"

    [SerializeField]
    private UI_Script _uiManager;

    [SerializeField]
    private string _nextScene;
    
    private void OnTriggerEnter(Collider other)
    {
        //if player reaches goal, change level
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(_nextScene);
        }
    }
}
