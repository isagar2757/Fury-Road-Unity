using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarsController : MonoBehaviour
{
     //PUBLIC VARIABLES
     /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "road" || other.gameObject.name=="copCar")
        {
            Destroy(other.gameObject);
        }
    }
}

