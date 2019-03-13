using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //PUBLIC VARIABLES
    public float speed = 10.0f;
    public GameObject CoinSprite;
    public GameObject obstacle1;
    public GameObject fuelCar;
    
     public Text scoreTxt;
     public Text healthTxt;

     public int scoreCount;
     public int health;

    //PRIVATE VARIABLES
    private Rigidbody2D rBody;

    //Reserved function runs only once when the object is created 
    //Used for initialization
    void Start()
    {
        scoreCount = 0;
        health = 5;
        rBody = GetComponent<Rigidbody2D>();
        // InvokeRepeating("checkCollision",4f,4f);
       // CoinSprite = GameObject.Find("CoinSprite");
        
        
    }
    // Start is called before the first frame update

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
        

         //Debug.Log("Coin Self: " + CoinSprite.activeSelf);
    }
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        

        rBody.velocity = new Vector2(horiz*speed, rBody.velocity.y);
        
       
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
                SceneManager.LoadScene("Level1");
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
