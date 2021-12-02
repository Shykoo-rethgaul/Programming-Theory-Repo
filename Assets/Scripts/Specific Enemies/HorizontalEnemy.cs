using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        SideSpawnedOn();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalEnemyMovement();
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
}
