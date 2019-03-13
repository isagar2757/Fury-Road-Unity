using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 0.6f;
    

   
    void Start()
    {
        

        InvokeRepeating("scrollSpeedIncrese",30f,30f);
    }

    void scrollSpeedIncrese()
    {
        scrollSpeed += 0.2f;
        Debug.Log("Scroll Speed Increased: " + scrollSpeed);
    }
    // void MoveBG()
    // {
    //     GetComponent<Renderer>().material.mainTextureOffset = 
    //         new Vector2(GetComponent<Renderer>().material.mainTextureOffset.x + scrollSpeed,0);
    // }

    // Update is called once per frame
    void Update()
    {
       

             GetComponent<Renderer>().material.mainTextureOffset = 
            new Vector2(0,Time.time * scrollSpeed);
    }

    
}
