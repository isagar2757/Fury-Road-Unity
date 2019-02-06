using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarControl : MonoBehaviour
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
        
       
    }
}

