using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //PUBLIC VARIABLES
    public float speed = 10.0f;
    public GameObject CoinSprite,obstacle1,fuelCar;
    public GameObject enemy1,enemy2,enemy3,copCar;
    
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
        if(copCar.activeSelf == false)
        {
            copCar.SetActive(true);
        }
        

         Debug.Log("COP Self: " + copCar.activeSelf);
    }
    void FixedUpdate()
    {
        // float horiz = Input.GetAxis("Horizontal");
        

        // rBody.velocity = new Vector2(horiz*speed, rBody.velocity.y);

        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		rBody.AddForce(movement * speed);
        
       
    }

   	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("coin")) {
			other.gameObject.SetActive(false);
            Invoke("checkCollision",2f);
            scoreCount += 10;
            setScore();
            
		}
        else
        if (other.gameObject.CompareTag("fuel")) {
			other.gameObject.SetActive(false);
            Invoke("checkCollision",2f);
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
            Invoke("checkCollision",2f);
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
			other.gameObject.SetActive(false);
            Invoke("checkCollision",2f);
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
        scoreTxt.text = "Score: "+ scoreCount.ToString();
    }

    void setHealth()
    {
        healthTxt.text = "Health: "+ health.ToString();
    }
}
