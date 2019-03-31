using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss3 : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 200;
    public GameObject effect,oil;

   
    public void TakeDamage(int damage)
    {
        
        oilRelease();
        health -= damage;
        if(health <= 0)
        {
            Die();
        }

    }

   void Die()
   {
       Destroy(gameObject);
       SceneManager.LoadScene("Win");
   }

    void oilRelease()
    {
       
        // Create a new bullet at “transform.position” 
        // Which is the current position of the ship
        // Quaternion.identity = add the bullet with no rotation
        Instantiate(oil, transform.position, transform.rotation);
    }
}
