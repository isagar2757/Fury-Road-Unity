using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 0.3f;

   
    // void Start()
    // {
    //     InvokeRepeating("MoveBG",0.5f,0.5f);
    // }

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

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("copCar")) {
			other.gameObject.SetActive(false);
		}
	}
}
