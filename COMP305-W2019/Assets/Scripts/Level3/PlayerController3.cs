using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController3 : MonoBehaviour
{

    //PUBLIC VARIABLES
    public float speed = 10.0f;
    public GameObject CoinSprite,cloud, cloud1, island, island1, fuel1 , CoinSprite1;
    public GameObject enemy1,enemy2,enemy3;

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
        if(CoinSprite1.activeSelf == false)
        {
            CoinSprite1.SetActive(true);
        }
        else
        if(island.activeSelf == false)
        {
            island.SetActive(true);
        }
        else
        if(enemy1.activeSelf == false)
        {
            enemy1.SetActive(true);
        }
        else
        if(island1.activeSelf == false)
        {
            island1.SetActive(true);
        }
        else
        if(cloud.activeSelf == false)
        {
            cloud.SetActive(true);
        }
        else
        if(cloud1.activeSelf == false)
        {
            cloud1.SetActive(true);
        }
        else
        if(fuel1.activeSelf == false)
        {
            fuel1.SetActive(true);
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
            
            if(scoreCount<100)
            {
                scoreCount += 10;
                Invoke("checkCollision",2f);
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
            
            if(health < 5)
            {
                health += 1;
                Invoke("checkCollision",2f);
            }
            setHealth();
            
		}
        else
        if (other.gameObject.CompareTag("obstacle")) {
            Debug.Log("Obstacle");
			other.gameObject.SetActive(false);
            
            if(health >1 )
            {
                health -= 1;
                Invoke("checkCollision",2f);
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
            
            if(health >2 )
            {
                health -= 2;
                Invoke("checkCollision",2f);
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
        CoinSprite1.SetActive(false);
        island.SetActive(false);
        island1.SetActive(false);
        fuel1.SetActive(false);
        cloud.SetActive(false);
        cloud1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        

        // Background2 bg2= GetComponent<Background2>();
        // bg2.scrollSpeed = 0f;
        boss.SetActive(true);
        
    }
}
