using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nBalas : MonoBehaviour
{

    PlayerController controlo;
    private GameController gameController;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
           // controlo = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
       
        if (gameControllerObject != null)//modificar para o player
        {
            gameController = gameControllerObject.GetComponent<GameController>();
            Debug.Log("Testestets");
            controlo = gameControllerObject.GetComponent<PlayerController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");

        }
        controlo = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        
        if (other.tag == "Player")
        {
            controlo.balas();
            Destroy(gameObject);

        }


    }
}
