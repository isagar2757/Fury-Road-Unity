using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{

    //PUBLIC VARIABLES
    public float speed = 10.0f;
    public GameObject CoinSprite,obstacle1,fuelCar, fuel1 , CoinSprite2;
    public GameObject enemy1,enemy2,enemy3,copCar, truck2;

    public GameObject boss;

    public GameObject bullet;
    
     public Text scoreTxt,healthTxt;

     public int scoreCount,health;


    //  public Animator obstacleAnim;

    //PRIVATE VARIABLES
    private Rigidbody2D rBody;

    //Reserved function runs only once when the object is created 
    //Used for initialization
    void Start()
    {
        scoreCount = 0;
        health = 5;
        rBody = GetComponent<Rigidbody2D>();
        boss.SetActive(false);
        // obstacleAnim = gameObject.GetComponent<Animator>();
        // InvokeRepeating("animSpeed",10f,10f);
        // InvokeRepeating("checkCollision",4f,4f);
       // CoinSprite = GameObject.Find("CoinSprite");
        
        
    }
    // Start is called before the first frame update

    // void animSpeed()
    // {
    //      obstacleAnim.speed += 0.3f;
    //      Debug.Log("Animation Speed " + obstacleAnim.speed);
    // }
        void Update()
    {
       if (Input.GetKeyDown("space")) {
        // Create a new bullet at “transform.position” 
        // Which is the current position of the ship
        // Quaternion.identity = add the bullet with no rotation
        Instantiate(bullet, transform.position, transform.rotation);
    }
    }

    void checkCollision()
    {
        if(CoinSprite.activeSelf == false)
        {
            CoinSprite.SetActive(true);
        }
        else
        if(fuelCar.activeSelf == false)
        {
            fuelCar.SetActive(true);
        }
        else
        if(obstacle1.activeSelf == false)
        {
            obstacle1.SetActive(true);
        }
        else
        if(enemy1.activeSelf == false)
        {
            enemy1.SetActive(true);
        }
        else
        if(enemy2.activeSelf == false)
        {
            enemy2.SetActive(true);
        }
        else
        if(enemy3.activeSelf == false)
        {
            enemy3.SetActive(true);
        }
        else
        if(truck2.activeSelf == false)
        {
            truck2.SetActive(true);
        }
        else
        if(CoinSprite2.activeSelf == false)
        {
            CoinSprite2.SetActive(true);
        }
        else
        if(fuel1.activeSelf == false)
        {
            fuel1.SetActive(true);
        }
        else
        if(copCar.activeSelf == false)
        {
            copCar.SetActive(true);
        }
        

         Debug.Log("COP Self: " + copCar.activeSelf);
    }
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        

        rBody.velocity = new Vector2(horiz*speed, rBody.velocity.y);

        

        // float moveHorizontal = Input.GetAxis("Horizontal");
		// float moveVertical = Input.GetAxis("Vertical");

		// Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		// rBody.AddForce(movement * speed);
        
       
    }

   	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("coin")) {
			other.gameObject.SetActive(false);
            Invoke("checkCollision",4f);
            if(scoreCount<100)
            {
                scoreCount += 10;
                setScore();
            }
            else
            {
                bringBoss();
            }
            
            
            
		}
        else
        if (other.gameObject.CompareTag("fuel")) {
			other.gameObject.SetActive(false);
            Invoke("checkCollision",4f);
            if(health < 5)
            {
                health += 1;
            }
            setHealth();
            
		}
        else
        if (other.gameObject.CompareTag("obstacle")) {
            Debug.Log("Obstacle");
			other.gameObject.SetActive(false);
            Invoke("checkCollision",4f);
            if(health >1 )
            {
                health -= 1;
            }
            else
            {
                SceneManager.LoadScene("End");
            }
            
            setHealth();
            
		}
        else
        if (other.gameObject.CompareTag("cop")) {
            Debug.Log("cop");
            Debug.Log(health);
			other.gameObject.SetActive(false);
            Invoke("checkCollision",4f);
            if(health >2 )
            {
                health -= 2;
            }
            else
            {
                SceneManager.LoadScene("End");
            }
            
            setHealth();
            
		}
	}

    void setScore()
    {
        scoreTxt.text = "Score: "+ scoreCount.ToString()+"/100";
    }

    void setHealth()
    {
        healthTxt.text = "Health: "+ health.ToString()+"/5";
    }

    void bringBoss()
    {
        CoinSprite.SetActive(false);
        CoinSprite2.SetActive(false);
        obstacle1.SetActive(false);
        fuelCar.SetActive(false);
        fuel1.SetActive(false);
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        copCar.SetActive(false);
        truck2.SetActive(false);

        // Background2 bg2= GetComponent<Background2>();
        // bg2.scrollSpeed = 0f;
        boss.SetActive(true);
        
    }
}
