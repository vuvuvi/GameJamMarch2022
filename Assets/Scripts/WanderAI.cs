using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WanderAI : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;
    [SerializeField]
    float maxDistance;

    Vector2 wayPoint;

    private void Start()
    {
        StartCoroutine(Walking());
    }

    private void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) <range)
        {
            StartCoroutine(Walking()) ;
        }
    }

    void SetNewDestination ()
    {
        
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance),Random.Range(-maxDistance, maxDistance));

        
    }

    IEnumerator Walking()

    {

        int waitTime = Random.Range(0, 15);
        SetNewDestination();
        yield return new WaitForSeconds(waitTime);

    }

}
