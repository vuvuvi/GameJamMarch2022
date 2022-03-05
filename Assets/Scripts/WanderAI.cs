using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WanderAI : MonoBehaviour
{
    [SerializeField]
    float minSpeed;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float minDistance;
    [SerializeField]
    float maxDistance;
    [SerializeField]
    float minWaitingTime;
    [SerializeField]
    float maxWaitingTime;

    float minDelta;
    Vector4 boardBounds;

    float currentSpeed;

    float waitTime;

    Vector2 wayPoint;



    public void Init(Vector3 boardBounds)
    {
        this.boardBounds = boardBounds;
    }



    private void Start()
    {
        SetNewDestination();
        waitTime = 1f;
    }

    private void Update()
    {
        waitTime += Time.deltaTime;
        // Debug.Log("Wait Time = " + waitTime);

        if (waitTime > 8)
        {

            waitTime = 0f;
        }

        else if (waitTime == 0)
        {

        }
        else
        {
            Move();
        }

        if (Vector2.Distance(transform.position, wayPoint) < minDelta)
        {
            SetNewDestination();
        }
    }

    private void SetNewDestination()
    {
        float distance = Random.Range(minDistance, maxDistance);
        float directionRadAngle = Mathf.Deg2Rad * Random.Range(0f, 360f);
        wayPoint = transform.position + new Vector3(Mathf.Cos(directionRadAngle), Mathf.Sin(directionRadAngle)) * distance;
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        Debug.DrawLine(transform.position, new Vector3(wayPoint.x, wayPoint.y, transform.position.z), Color.red, 5f);
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, currentSpeed * Time.deltaTime);
    }

    private void Wait()
    {
        // change anim
        // sit if long time
    }



    public enum State
    {
        MOVING,
        WAITING
    }
}




