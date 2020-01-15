using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DestroyByContact : MonoBehaviour
{
    [SerializeField]
    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;

    

    void Start()
    { 
        
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            
            Debug.Log("Cannot find 'GameController' script");
        }
        
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Bolt")
        {
            
            return;
        }
        if(explosion!= null) { 

            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Enemy" || other.tag == "Bolt") {
            Debug.Log("addSorce");
            //Pb.ProgressBar -= 1;
            

        }
        if (other.tag == "Player")
        {
            GameController.vida -= 25;
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            GameController.morte = 0;
            
            gameController.GameOver();
        }


        
        //gameController.AddScore();
        gameController.AddScore(scoreValue);
        
        Destroy(other.gameObject);
        
        Destroy(gameObject);
    }
    
}