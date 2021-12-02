using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;

    public bool sideSpawnedOn;

    private float outOfBoundsX = 14;
    private float outOfBoundsY = -3;
    
   
    public void DestoryOutOfRange()
    {
        // destroys object once out of range
        if (transform.position.x > outOfBoundsX || transform.position.x < -outOfBoundsX || transform.position.y < outOfBoundsY)
        {
            Destroy(gameObject);
        }
        
    }
}

