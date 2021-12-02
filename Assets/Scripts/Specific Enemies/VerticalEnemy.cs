using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        VerticalEnemyMovement();
        DestoryOutOfRange();
    }
    void VerticalEnemyMovement()
    {
        // moves vertical enemies down
        if (CompareTag("Vertical Enemy"))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
}
