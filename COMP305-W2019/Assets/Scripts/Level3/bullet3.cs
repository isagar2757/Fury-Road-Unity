using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bullet3 : MonoBehaviour
{
    // Start is called before the first frame update

    
    public float speed  = 6.0f;
    public int hitCount;
   // public GameObject boss;
    public int damage = 10;
    private Rigidbody2D rBody;
    public GameObject effect;

    public Text bossHealthTxt;

    public int bossHealth = 200;
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        hitCount=0;
        //float horiz = Input.GetAxis("Horizontal");
       rBody.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        
       Debug.Log(other);
        boss3 l1Boss = other.GetComponent<boss3>();
        // Do something  
        // Destroy(gameObject);
        if(l1Boss != null)
        {
            Instantiate(effect, transform.position, transform.rotation);
            bossHealth = l1Boss.TakeDamage(damage);
            bossHealthTxt.text = "Boss : "+ bossHealth.ToString();
            
        }
        
        
       
    
    }
    
}

