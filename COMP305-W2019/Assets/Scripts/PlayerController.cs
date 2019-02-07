using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //PUBLIC VARIABLES
    public float speed = 10.0f;
   


    //PRIVATE VARIABLES
    private Rigidbody2D rBody;

    //Reserved function runs only once when the object is created 
    //Used for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update

        void Update()
    {
       
    }
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        

        rBody.velocity = new Vector2(horiz*speed, rBody.velocity.y);
        
       
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     if( other.gameObject.name=="copCar")
    //     {
    //         Destroy(other.gameObject);
    //     }
    // }
}
