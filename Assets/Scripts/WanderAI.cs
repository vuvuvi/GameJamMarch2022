using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAI : MonoBehaviour
{
    public bool isWandering = false;
    public float moveSpeed = 1f;
    void FixedUpdate()
    {
        if (!isWandering)
        {
            StartCoroutine(Wander());
        }


    }

    IEnumerator Wander()
    {
        int movement = Random.Range(0, 5);

        int waitTime = Random.Range(1, 5);

        int movingDirection = Random.Range(1, 3);

        isWandering = true;

        if (movingDirection == 1)
        {
            transform.Translate(0, movement * moveSpeed * Time.deltaTime, 0);
        }

        if (movingDirection == 2)
        {
            transform.Translate(0, -movement * moveSpeed * Time.deltaTime, 0);
        }

        if (movingDirection == 3)
        {
            transform.Translate(movement * Time.deltaTime, 0, 0);
        }

        yield return new WaitForSeconds(waitTime);

        isWandering = false;
    }
}
