using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 200;
    public GameObject effect;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

   void Die()
   {
       Destroy(gameObject);
       SceneManager.LoadScene("End");
   }
}
