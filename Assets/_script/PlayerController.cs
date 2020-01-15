using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerStats {//vidaBar
    public float maxHealth;
    public float currentHealth;
}

public class PlayerController : MonoBehaviour
{
    //vidaBar
    public PlayerStats stats;

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform[] shotSpawns;
    public float fireRate;

    private float nextFire;
    private GameController gameController;
    private Rigidbody m_rigidbody;

    private int poder;

  

   

    int disparos;
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        poder = 1;
        disparos = 0;

        
    }

    void Update()
    {
       
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns) {
                if (poder == 1)
                {
                    Instantiate(shot, shotSpawns[2].position, shotSpawn.rotation);
                }
                if (poder == 2)
                {
                    disparos++;
                    Instantiate(shot, shotSpawns[1].position, shotSpawn.rotation);
                  
                    Instantiate(shot, shotSpawns[0].position, shotSpawn.rotation);
                    Debug.Log(disparos);
                    //Instantiate(shot, shotSpawns[2].position, shotSpawn.rotation);
                    if (disparos == 30)
                    {
                        poder = 1;
                        disparos = 0;
                    }
                }
                if (poder == 3)
                {
                    disparos++;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                   
                    //Instantiate(shot, shotSpawns[2].position, shotSpawn.rotation);
                    if (disparos == 40)
                    {
                        poder = 1;
                        disparos = 0;
                    }

                }
                

             }
            GetComponent<AudioSource>().Play();

             //gameController.OnShotFired();
        }
        
       
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        m_rigidbody.velocity = movement * speed;

        m_rigidbody.position = new Vector3
        (
            Mathf.Clamp(m_rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
           Mathf.Clamp(m_rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        m_rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, m_rigidbody.velocity.x * -tilt);
    }

    public void balas()
    {
        if (poder != 3)
        {
            poder++;
        }
    }
  
}
