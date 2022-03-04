using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{

    public float moveSpeed = 1f;
  
    private bool isWandering = false;
    private bool isWalking = false;
    private bool isMovingLeft = false;
    private bool isMovingRight = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            transform.Translate(0, movement * moveSpeed* Time.deltaTime, 0);
        }

        if (movingDirection == 2)
        {
            transform.Translate(0, -movement * moveSpeed * Time.deltaTime, 0);
        }

        if (movingDirection == 3)
        {
            transform.Translate(movement * Time.deltaTime , 0, 0);
        }

        yield return new WaitForSeconds(waitTime);

        isWandering = false; 
    }
}
