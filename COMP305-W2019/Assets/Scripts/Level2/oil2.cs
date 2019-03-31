using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oil2 : MonoBehaviour
{
    // Start is called before the first frame update

    
    public float speed  = 2.0f;
    public int hitCount;
   // public GameObject boss;
    public int damage = 10;
    private Rigidbody2D rBody;
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        hitCount=0;
        //float horiz = Input.GetAxis("Horizontal");
       rBody.velocity = -transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        
       Debug.Log(other);
        PlayerController2 l1Boss = other.GetComponent<PlayerController2>();
        // Do something  
        // Destroy(gameObject);
        if(l1Boss != null)
        {
            
        }
        
        
    
    }
    
}

