using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;

    public bool sideSpawnedOn;

    private float outOfBoundsX = 14;
    private float outOfBoundsY = -3;
    // Start is called before the first frame update
    void Start()
    {
        SideSpawnedOn();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalEnemyMovement();
        VerticalEnemyMovement();
        DestoryOutOfRange();
    }
    void SideSpawnedOn()
    {
        //enemy spawned on right side
        if (transform.position.x > 0)
        {
            sideSpawnedOn = true;
        }
        //enemy spawned on left side
        else if (transform.position.x < 0)
        {
            sideSpawnedOn = false;
        }
    }
    void HorizontalEnemyMovement()
    {
        //movement left or right for horizontal enemies depending on spawn location
        if (sideSpawnedOn == true && CompareTag("Horizontal Enemy"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else if (sideSpawnedOn == false && CompareTag("Horizontal Enemy"))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
    void VerticalEnemyMovement()
    {
        // moves vertical enemies down
        if (CompareTag("Vertical Enemy"))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
    void DestoryOutOfRange()
    {
        // destroys object once out of range
        if (transform.position.x > outOfBoundsX || transform.position.x < -outOfBoundsX || transform.position.y < outOfBoundsY)
        {
            Destroy(gameObject);
        }
        
    }
}

