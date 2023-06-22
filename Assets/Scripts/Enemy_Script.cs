using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    //enemies come from the top and can damage the player if the collide
    //if they don't collide the spawn again at the top of the game
    
    //speed with which enemies come down
    [SerializeField]
    private float _enemySpeed = 3f;

    [SerializeField]
    private float _height;

    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        //if they reach the bottom, spwan again to the top
        if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(Random.Range(-15f, 15f), _height, 0f);
        }

    }

    //function for collision with bullets and player
    void OnTriggerEnter(Collider other) 
    {

        //if collise with bullet, remove both objects
        if (other.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        //if collise with player, remove enemy and reduce the lives of player
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            other.GetComponent<Player_Script>().damage();
        }
    }
}
