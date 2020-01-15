using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private bool gameOver;

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GameObject Poder;

    public GameObject addPlayer;


    public Text scoreText;
    public Text vidaText;

    
   // private bool gameOver;
    private float score;
    public static int vida;

    private int contar;
    private int dificuldade;

    public static float morte;

    public static float  nivel;






    // public GUIText ScoreText { get => scoreText; set => scoreText = value; }

    void Start()
    {
        Instantiate(addPlayer, transform.position, transform.rotation);

        menuGameOver.SetActive(false);
        Time.timeScale = 0;
        gameOver = false;
        score = 0;
        //
        vida = 100;
        
        //slider.maxValue = maxSlide;
        //slider.value = maxSlide;
        UpdateScore();
        UpdateVida();

        nivel = 1;

        dificuldade = 1;

        StartCoroutine(SpawnWaves());
        morte = vida;
       // morte = maxSlide;
    }
    private void Update()
    {
        
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Application.LoadLevel(Application.loadedLevel);

                SceneManager.LoadScene(0);
            }
       

        if (morte != vida)//vida
        {
            
            morte = vida;//vida
            StartCoroutine(tempo());
            //Instantiate(addPlayer, transform.position, transform.rotation);
        }
        if (morte <= 0) {
            DestroyByContact.Destroy(gameObject);
          
        }
            
            
        
        if(score > 500)nivel = 2; 
        if(score > 1000) nivel = 3;
        if(score > 1100) nivel = 4;



    }



    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)

        {
            
            for (int i = 0; i < hazardCount; i++)
            {
                
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                /*
                 bool flag = (Radm.value > 0.5f);
                 if(flag){
                    spawValues.z(35 or -35); 
                }
                 */
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                //GameObject clone = Instantiate(hazard, spawnPosition, spawnRotation);
                //ReverseDirection(clone);

                if (dificuldade == 1) {                   
                    Instantiate(hazards[0],spawnPosition, spawnRotation);
                }
                if (dificuldade == 2) {
                    int random = Random.Range(0, 2);
                    Debug.Log("dificuldade2 " + random);
                    Instantiate(hazards[random], spawnPosition, spawnRotation);
                    
                    //Instantiate(hazards[1], spawnPosition, spawnRotation);
                }
                if (dificuldade == 3)
                {
                    int random = Random.Range(0, 3);
                    Debug.Log("dificuldade3 " + random);
                    Instantiate(hazards[random], spawnPosition, spawnRotation);

                    //Instantiate(hazards[1], spawnPosition, spawnRotation);
                }
                if (dificuldade == 4)
                {
                    int random = Random.Range(0, 4);
                    Debug.Log("dificuldade4 " + random);
                    Instantiate(hazards[random], spawnPosition, spawnRotation);

                    //Instantiate(hazards[1], spawnPosition, spawnRotation);
                }
               if (dificuldade == 5)
                {
                    int random = Random.Range(0, 5);
                    Debug.Log("dificuldade5 " + random);
                    Instantiate(hazards[random], spawnPosition, spawnRotation);

                    
                }

                if (dificuldade >= 6) {
                    Instantiate(hazard, spawnPosition, spawnRotation);
                }

                

                yield return new WaitForSeconds(spawnWait);
                
            }

            contar += hazardCount;
            if (contar >= 20)
            {
                Instantiate(Poder, new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z), Quaternion.identity);
                dificuldade++;
                contar =0;
            }


            yield return new WaitForSeconds(waveWait);

          

        }
    }
   void ReverseDirection(GameObject clone) {
        ///clone.transform.rotation.y = 0;
        
        clone.GetComponent<Mover>().speed = 5;
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void AddVidas(int newVidaValue) {
        vida += newVidaValue;
        
    }
    //para aparecre no ecra do game as eprecoes do score 0++
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        UpdateVida();
    }
    void UpdateVida() {
        vidaText.text = "Health: " + vida;
    }
    
    
    public void GameOver()
    {
        if (vida == 0)
        {
            
            gameOver = true;
            // gameOverText.text = "Game Over";
            Time.timeScale = 1;
            AudioListener.pause = false;
            menuGameOver.SetActive(true);
            
        }
    }
    IEnumerator tempo()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(addPlayer, transform.position, transform.rotation);
    }

}

